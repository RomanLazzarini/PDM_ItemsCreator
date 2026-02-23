using EPDM.Interop.epdm; // Fundamental: La API de PDM
using System.Collections.Generic;
using ExcelDataReader;   // La librería que acabas de instalar
using System;
using System.Data;       // Para manejar los datos en formato Tabla
using System.Drawing;
using System.IO;         // Para abrir el archivo físico
using System.Windows.Forms;

namespace PDM_ItemsCreator
{
    public partial class Form1 : Form
    {
        // Variable global para mantener la sesión de la bóveda abierta
        private IEdmVault5 vault = null;

        // Diccionario para mapear el ComboBox con la ruta relativa del template en PDM
        private Dictionary<string, string> templatePaths = new Dictionary<string, string>
        {
            { "Pieza de SolidWorks (.sldprt)", @"\INGENIERIA\BIBLIOTECA\TEMPLATES FILES\BasePieza.sldprt" },
            { "Ensamblaje de SolidWorks (.sldasm)", @"\INGENIERIA\BIBLIOTECA\TEMPLATES FILES\BaseEnsamblaje.sldasm" },
            { "Elemento virtual pieza (.sldprt.cvd)", @"\INGENIERIA\BIBLIOTECA\TEMPLATES FILES\BaseVirtualPieza.sldprt.cvd" },
            { "Elemento virtual ensamblaje (.sldasm.cvd)", @"\INGENIERIA\BIBLIOTECA\TEMPLATES FILES\BaseVirtualEnsamblaje.sldasm.cvd" },
            { "Word (.docx)", @"\INGENIERIA\BIBLIOTECA\TEMPLATES FILES\BaseWord.docx" },
            { "Excel (.xlsx)", @"\INGENIERIA\BIBLIOTECA\TEMPLATES FILES\BaseExcel.xlsx" }
        };

        public Form1()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                // Limpiamos la consola al intentar una nueva conexión
                rtbLogs.Clear();

                vault = new EdmVault5();
                string vaultName = txtVaultName.Text.Trim();

                if (string.IsNullOrEmpty(vaultName))
                {
                    MessageBox.Show("Por favor, ingrese el nombre de la bóveda.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                LogMessage("Intentando conectar a la bóveda: " + vaultName + "...", Color.Black);

                // LoginAuto usa la sesión actual de Windows/PDM. 
                // this.Handle.ToInt32() vincula posibles ventanas emergentes de PDM a nuestra app
                vault.LoginAuto(vaultName, this.Handle.ToInt32());

                if (vault.IsLoggedIn)
                {
                    lblStatus.Text = "Conectado";
                    lblStatus.ForeColor = Color.Green;
                    LogMessage("Conexión exitosa con PDM. Sesión iniciada.", Color.Green);
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Desconectado";
                lblStatus.ForeColor = Color.Red;
                MessageBox.Show("Error al conectar con PDM:\n" + ex.Message, "Error crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogMessage("Fallo en la conexión: " + ex.Message, Color.Red);
            }
        }

        // Método auxiliar para imprimir mensajes en el RichTextBox con colores
        private void LogMessage(string message, Color color)
        {
            rtbLogs.SelectionStart = rtbLogs.TextLength;
            rtbLogs.SelectionLength = 0;
            rtbLogs.SelectionColor = color;
            rtbLogs.AppendText($"[{DateTime.Now.ToString("HH:mm:ss")}] {message}\n");
            rtbLogs.SelectionColor = rtbLogs.ForeColor; // Restaura el color original
            rtbLogs.ScrollToCaret();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Title = "Seleccionar planilla de datos";
                    // Filtramos para que solo muestre archivos Excel
                    openFileDialog.Filter = "Archivos de Excel (*.xlsx;*.xls)|*.xlsx;*.xls";
                    openFileDialog.FilterIndex = 1;
                    openFileDialog.RestoreDirectory = true;

                    // Si el usuario selecciona un archivo y le da a OK
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        // Escribimos la ruta en el TextBox
                        txtExcelPath.Text = openFileDialog.FileName;
                        LogMessage($"Archivo origen seleccionado: {openFileDialog.FileName}", Color.Blue);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al seleccionar el archivo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogMessage("Error seleccionando Excel: " + ex.Message, Color.Red);
            }
        }

        private void btnStartMigration_Click(object sender, EventArgs e)
        {
            if (vault == null || !vault.IsLoggedIn)
            {
                MessageBox.Show("Debe conectarse a la bóveda de PDM primero.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(txtExcelPath.Text) || string.IsNullOrEmpty(txtDestFolder.Text) || cmbFileType.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, complete todos los campos (Excel, Carpeta Destino y Tipo de Archivo).", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string excelPath = txtExcelPath.Text;
            string selectedFileType = cmbFileType.Text;
            string destFolderPath = txtDestFolder.Text;

            try
            {
                // 1. Obtener carpetas y templates de PDM
                IEdmFolder5 destFolder = vault.GetFolderFromPath(destFolderPath);
                if (destFolder == null)
                {
                    LogMessage("Error: No se encontró la carpeta de destino.", Color.Red);
                    return;
                }

                string templateRelPath = templatePaths[selectedFileType];
                string templateFullPath = Path.Combine(vault.RootFolderPath, templateRelPath.TrimStart('\\'));

                IEdmFolder5 templateFolder = null;
                IEdmFile5 templateFile = vault.GetFileFromPath(templateFullPath, out templateFolder);

                if (templateFile == null)
                {
                    LogMessage($"Error: No se encontró el template base.", Color.Red);
                    return;
                }

                string extension = Path.GetExtension(templateFile.Name);
                LogMessage($"Iniciando migración con template: {templateFile.Name}", Color.Blue);

                // Asegurar que el template base esté en la caché local
                templateFile.GetFileCopy(this.Handle.ToInt32());

                // 2. Leer el Excel
                using (var stream = File.Open(excelPath, FileMode.Open, FileAccess.Read))
                {
                    using (var reader = ExcelReaderFactory.CreateReader(stream))
                    {
                        var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                        {
                            ConfigureDataTable = (_) => new ExcelDataTableConfiguration() { UseHeaderRow = true }
                        });

                        DataTable table = result.Tables[0];
                        int creados = 0;

                        // 3. Iterar, Crear y Mapear Variables
                        foreach (DataRow row in table.Rows)
                        {
                            string baseName = row["Name"]?.ToString() ?? "Elemento_Sin_Nombre";

                            // Sanitización
                            baseName = baseName.Replace("\"", " pulg").Replace("/", "-").Replace("\\", "-");
                            foreach (char c in Path.GetInvalidFileNameChars()) { baseName = baseName.Replace(c.ToString(), ""); }

                            string newFileName = baseName;
                            if (!newFileName.EndsWith(extension, StringComparison.InvariantCultureIgnoreCase))
                            {
                                newFileName += extension;
                            }

                            try
                            {
                                LogMessage($"   -> 1. Clonando base...", Color.Gray);
                                destFolder.CopyFile(templateFile.ID, templateFolder.ID, this.Handle.ToInt32(), newFileName, (int)EdmCopyFlag.EdmCpy_Simple);

                                string newFilePath = Path.Combine(destFolderPath, newFileName);
                                IEdmFolder5 parentFolder = null;
                                IEdmFile5 newFile = vault.GetFileFromPath(newFilePath, out parentFolder);

                                if (newFile != null)
                                {
                                    LogMessage($"   -> 2. Check-In inicial (Materializando Versión 1)...", Color.Gray);
                                    newFile.UnlockFile(this.Handle.ToInt32(), "Creación inicial desde template base");

                                    System.Threading.Thread.Sleep(1000); // Pausa estratégica

                                    LogMessage($"   -> 3. Check-Out para inyección de datos...", Color.Gray);
                                    // Refrescamos puntero
                                    newFile = vault.GetFileFromPath(newFilePath, out parentFolder);
                                    newFile.LockFile(parentFolder.ID, this.Handle.ToInt32());

                                    System.Threading.Thread.Sleep(1000); // Pausa estratégica

                                    vault.RefreshFolder(destFolderPath);
                                    System.IO.File.SetAttributes(newFilePath, System.IO.FileAttributes.Normal);

                                    LogMessage($"   -> 4. Escribiendo metadatos...", Color.Gray);

                                    // >>> EL CAMBIO CLAVE: String vacío ("") para enlace directo a BD <<<
                                    IEdmEnumeratorVariable8 varEnum = (IEdmEnumeratorVariable8)newFile.GetEnumeratorVariable("");

                                    string product = row["Product"]?.ToString() ?? "";
                                    string revision = row["Revision"]?.ToString() ?? "";
                                    string unidad = row["Unidad_de_medida"]?.ToString() ?? "";

                                    varEnum.SetVar("Product", "", product);
                                    varEnum.SetVar("Revision", "", revision);
                                    varEnum.SetVar("Unidad_de_medida", "", unidad);

                                    varEnum.CloseFile(true);

                                    LogMessage($"   -> 5. Check-In final (Nace Versión 2 parametrizada)...", Color.Gray);
                                    // Recargamos el puntero por última vez antes del guardado final
                                    newFile = vault.GetFileFromPath(newFilePath, out parentFolder);
                                    newFile.UnlockFile(this.Handle.ToInt32(), "Carga de metadatos vía PDM_ItemsCreator");

                                    LogMessage($"Éxito: {newFileName} finalizado correctamente.", Color.Green);
                                    creados++;
                                }
                            }
                            catch (Exception ex)
                            {
                                LogMessage($"Fallo al procesar {newFileName}: {ex.Message}", Color.Red);
                            }
                        }

                        LogMessage($"Migración finalizada. Se crearon y parametrizaron {creados} archivos.", Color.Blue);
                    }
                }
            }
            catch (Exception ex)
            {
                LogMessage("Error crítico: " + ex.Message, Color.Red);
            }
        }

        private void btnBrowseDest_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                fbd.Description = "Seleccione la carpeta de destino dentro de la bóveda PDM";
                // Si quieres, puedes setear RootFolder para que abra directamente en el disco de PDM

                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    txtDestFolder.Text = fbd.SelectedPath;
                    LogMessage($"Carpeta destino seleccionada: {fbd.SelectedPath}", Color.Blue);
                }
            }
        }
    }
}