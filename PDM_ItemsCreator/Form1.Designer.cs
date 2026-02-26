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
            this.lblStatus = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnBrowseDest = new System.Windows.Forms.Button();
            this.txtDestFolder = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbFileType = new System.Windows.Forms.ComboBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtExcelPath = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rtbLogs = new System.Windows.Forms.RichTextBox();
            this.btnStartMigration = new System.Windows.Forms.Button();
            this.pbMigracion = new System.Windows.Forms.ProgressBar();
            this.btnNuevaMigracion = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(2145, 53);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(264, 32);
            this.lblStatus.TabIndex = 2;
            this.lblStatus.Text = "Estado de conexión";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblStatus);
            this.groupBox2.Controls.Add(this.btnBrowseDest);
            this.groupBox2.Controls.Add(this.txtDestFolder);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.cmbFileType);
            this.groupBox2.Controls.Add(this.btnBrowse);
            this.groupBox2.Controls.Add(this.txtExcelPath);
            this.groupBox2.Location = new System.Drawing.Point(33, 125);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(2544, 290);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "1. Configuración de Migración";
            // 
            // btnBrowseDest
            // 
            this.btnBrowseDest.Location = new System.Drawing.Point(26, 207);
            this.btnBrowseDest.Name = "btnBrowseDest";
            this.btnBrowseDest.Size = new System.Drawing.Size(247, 48);
            this.btnBrowseDest.TabIndex = 5;
            this.btnBrowseDest.Text = "Buscar Destino";
            this.btnBrowseDest.UseVisualStyleBackColor = true;
            this.btnBrowseDest.Click += new System.EventHandler(this.btnBrowseDest_Click);
            // 
            // txtDestFolder
            // 
            this.txtDestFolder.Location = new System.Drawing.Point(357, 213);
            this.txtDestFolder.Name = "txtDestFolder";
            this.txtDestFolder.Size = new System.Drawing.Size(2052, 38);
            this.txtDestFolder.TabIndex = 4;
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
            this.btnBrowse.Location = new System.Drawing.Point(26, 127);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(247, 47);
            this.btnBrowse.TabIndex = 1;
            this.btnBrowse.Text = "Buscar Excel";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtExcelPath
            // 
            this.txtExcelPath.Location = new System.Drawing.Point(357, 132);
            this.txtExcelPath.Name = "txtExcelPath";
            this.txtExcelPath.Size = new System.Drawing.Size(2052, 38);
            this.txtExcelPath.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rtbLogs);
            this.groupBox3.Controls.Add(this.btnStartMigration);
            this.groupBox3.Location = new System.Drawing.Point(33, 436);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(2544, 634);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "2. Ejecución y Monitoreo";
            // 
            // rtbLogs
            // 
            this.rtbLogs.Location = new System.Drawing.Point(26, 133);
            this.rtbLogs.Name = "rtbLogs";
            this.rtbLogs.Size = new System.Drawing.Size(2494, 474);
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
            this.btnStartMigration.Click += new System.EventHandler(this.btnStartMigration_Click);
            // 
            // pbMigracion
            // 
            this.pbMigracion.Location = new System.Drawing.Point(59, 1120);
            this.pbMigracion.Name = "pbMigracion";
            this.pbMigracion.Size = new System.Drawing.Size(2500, 45);
            this.pbMigracion.TabIndex = 7;
            // 
            // btnNuevaMigracion
            // 
            this.btnNuevaMigracion.Location = new System.Drawing.Point(841, 1292);
            this.btnNuevaMigracion.Name = "btnNuevaMigracion";
            this.btnNuevaMigracion.Size = new System.Drawing.Size(294, 58);
            this.btnNuevaMigracion.TabIndex = 6;
            this.btnNuevaMigracion.Text = "Nueva Migración";
            this.btnNuevaMigracion.UseVisualStyleBackColor = true;
            this.btnNuevaMigracion.Click += new System.EventHandler(this.btnNuevaMigracion_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(1657, 1292);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(301, 54);
            this.btnSalir.TabIndex = 8;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2705, 1422);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.pbMigracion);
            this.Controls.Add(this.btnNuevaMigracion);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtExcelPath;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnStartMigration;
        private System.Windows.Forms.RichTextBox rtbLogs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbFileType;
        private System.Windows.Forms.Button btnBrowseDest;
        private System.Windows.Forms.TextBox txtDestFolder;
        private System.Windows.Forms.ProgressBar pbMigracion;
        private System.Windows.Forms.Button btnNuevaMigracion;
        private System.Windows.Forms.Button btnSalir;
    }
}

