namespace PDM_ItemsCreator
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtVaultName = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbFileType = new System.Windows.Forms.ComboBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtExcelPath = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rtbLogs = new System.Windows.Forms.RichTextBox();
            this.btnStartMigration = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtVaultName
            // 
            this.txtVaultName.Location = new System.Drawing.Point(20, 57);
            this.txtVaultName.Name = "txtVaultName";
            this.txtVaultName.Size = new System.Drawing.Size(204, 38);
            this.txtVaultName.TabIndex = 0;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(266, 46);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(277, 58);
            this.btnConnect.TabIndex = 1;
            this.btnConnect.Text = "Conectar a PDM";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(37, 163);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(92, 32);
            this.lblStatus.TabIndex = 2;
            this.lblStatus.Text = "label1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtVaultName);
            this.groupBox1.Controls.Add(this.lblStatus);
            this.groupBox1.Controls.Add(this.btnConnect);
            this.groupBox1.Location = new System.Drawing.Point(33, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(609, 274);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "1. Conexión a PDM";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.cmbFileType);
            this.groupBox2.Controls.Add(this.btnBrowse);
            this.groupBox2.Controls.Add(this.txtExcelPath);
            this.groupBox2.Location = new System.Drawing.Point(685, 52);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1443, 239);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "2. Configuración de Migración";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(313, 32);
            this.label1.TabIndex = 3;
            this.label1.Text = "Tipo de Archivo a crear:";
            // 
            // cmbFileType
            // 
            this.cmbFileType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFileType.FormattingEnabled = true;
            this.cmbFileType.Items.AddRange(new object[] {
            "Pieza de SolidWorks (.sldprt)",
            "Elemento virtual pieza (.sldprt.cvd)",
            "Ensamblaje de SolidWorks (.sldasm)",
            "Elemento virtual ensamblaje (.sldasm.cvd)",
            "Word (.docx)",
            "Excel (.xlsx)"});
            this.cmbFileType.Location = new System.Drawing.Point(357, 62);
            this.cmbFileType.Name = "cmbFileType";
            this.cmbFileType.Size = new System.Drawing.Size(712, 39);
            this.cmbFileType.TabIndex = 2;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(1122, 64);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(247, 37);
            this.btnBrowse.TabIndex = 1;
            this.btnBrowse.Text = "Buscar Excel";
            this.btnBrowse.UseVisualStyleBackColor = true;
            // 
            // txtExcelPath
            // 
            this.txtExcelPath.Location = new System.Drawing.Point(9, 157);
            this.txtExcelPath.Name = "txtExcelPath";
            this.txtExcelPath.Size = new System.Drawing.Size(1360, 38);
            this.txtExcelPath.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rtbLogs);
            this.groupBox3.Controls.Add(this.btnStartMigration);
            this.groupBox3.Location = new System.Drawing.Point(33, 368);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1799, 395);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "3. Ejecución y Monitoreo";
            // 
            // rtbLogs
            // 
            this.rtbLogs.Location = new System.Drawing.Point(26, 133);
            this.rtbLogs.Name = "rtbLogs";
            this.rtbLogs.Size = new System.Drawing.Size(1748, 225);
            this.rtbLogs.TabIndex = 1;
            this.rtbLogs.Text = "";
            // 
            // btnStartMigration
            // 
            this.btnStartMigration.Location = new System.Drawing.Point(26, 61);
            this.btnStartMigration.Name = "btnStartMigration";
            this.btnStartMigration.Size = new System.Drawing.Size(312, 51);
            this.btnStartMigration.TabIndex = 0;
            this.btnStartMigration.Text = "Iniciar migración";
            this.btnStartMigration.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2133, 1073);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtVaultName;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtExcelPath;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnStartMigration;
        private System.Windows.Forms.RichTextBox rtbLogs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbFileType;
    }
}

