using System;
using System.Drawing;
using System.Windows.Forms;
using EPDM.Interop.epdm; // Fundamental: La API de PDM

namespace PDM_ItemsCreator
{
    public partial class Form1 : Form
    {
        // Variable global para mantener la sesión de la bóveda abierta
        private IEdmVault5 vault = null;

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
    }
}