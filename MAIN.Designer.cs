namespace SafeBackup
{
    partial class MAIN
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            btnSourceFolder = new Button();
            lblTitle = new Label();
            lblVersion = new Label();
            btnLoadPaths = new Button();
            btnBackup = new Button();
            btnHelp = new Button();
            comboBoxBackupDrives = new ComboBox();
            lblSourcePath = new Label();
            timerLoadDrivers = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // btnSourceFolder
            // 
            btnSourceFolder.BackColor = Color.White;
            btnSourceFolder.Location = new Point(12, 119);
            btnSourceFolder.Name = "btnSourceFolder";
            btnSourceFolder.Size = new Size(360, 100);
            btnSourceFolder.TabIndex = 0;
            btnSourceFolder.Text = "VYBRAT ZDROJOVOU SLOŽKU";
            btnSourceFolder.UseVisualStyleBackColor = false;
            btnSourceFolder.Click += btnSourceFolder_Click;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(12, 19);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(167, 15);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "CHYTRÉ ZÁLOHOVACÍ ŘEŠENÍ";
            // 
            // lblVersion
            // 
            lblVersion.AutoSize = true;
            lblVersion.Location = new Point(323, 19);
            lblVersion.Name = "lblVersion";
            lblVersion.Size = new Size(49, 15);
            lblVersion.TabIndex = 2;
            lblVersion.Text = "(V.1.0.0)";
            // 
            // btnLoadPaths
            // 
            btnLoadPaths.Location = new Point(12, 52);
            btnLoadPaths.Name = "btnLoadPaths";
            btnLoadPaths.Size = new Size(209, 34);
            btnLoadPaths.TabIndex = 3;
            btnLoadPaths.Text = "NAČÍST ULOŽENÉ CESTY";
            btnLoadPaths.UseVisualStyleBackColor = true;
            btnLoadPaths.Click += btnLoadPaths_Click;
            // 
            // btnBackup
            // 
            btnBackup.BackColor = Color.White;
            btnBackup.Location = new Point(66, 236);
            btnBackup.Name = "btnBackup";
            btnBackup.Size = new Size(225, 34);
            btnBackup.TabIndex = 4;
            btnBackup.Text = "ZÁLOHUJ";
            btnBackup.UseVisualStyleBackColor = false;
            btnBackup.Click += btnBackup_Click;
            // 
            // btnHelp
            // 
            btnHelp.Location = new Point(297, 235);
            btnHelp.Name = "btnHelp";
            btnHelp.Size = new Size(75, 34);
            btnHelp.TabIndex = 6;
            btnHelp.Text = "?";
            btnHelp.UseVisualStyleBackColor = true;
            btnHelp.Click += btnHelp_Click;
            // 
            // comboBoxBackupDrives
            // 
            comboBoxBackupDrives.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxBackupDrives.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            comboBoxBackupDrives.FormattingEnabled = true;
            comboBoxBackupDrives.Location = new Point(12, 236);
            comboBoxBackupDrives.Name = "comboBoxBackupDrives";
            comboBoxBackupDrives.Size = new Size(48, 33);
            comboBoxBackupDrives.TabIndex = 7;
            comboBoxBackupDrives.SelectedIndexChanged += comboBoxBackupDrives_SelectedIndexChanged;
            // 
            // lblSourcePath
            // 
            lblSourcePath.AutoSize = true;
            lblSourcePath.Location = new Point(12, 101);
            lblSourcePath.Name = "lblSourcePath";
            lblSourcePath.Size = new Size(231, 15);
            lblSourcePath.TabIndex = 8;
            lblSourcePath.Text = "SOURCE: Prosím vyberte zdrojovou složku.";
            // 
            // timerLoadDrivers
            // 
            timerLoadDrivers.Enabled = true;
            timerLoadDrivers.Interval = 1000;
            timerLoadDrivers.Tick += timerLoadDrivers_Tick;
            // 
            // MAIN
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(384, 285);
            Controls.Add(lblSourcePath);
            Controls.Add(comboBoxBackupDrives);
            Controls.Add(btnHelp);
            Controls.Add(btnBackup);
            Controls.Add(btnLoadPaths);
            Controls.Add(lblVersion);
            Controls.Add(lblTitle);
            Controls.Add(btnSourceFolder);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "MAIN";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SafeBackup";
            Load += MAIN_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSourceFolder;
        private Label lblTitle;
        private Label lblVersion;
        private Button btnLoadPaths;
        private Button btnBackup;
        private Button btnHelp;
        private ComboBox comboBoxBackupDrives;
        private Label lblSourcePath;
        private System.Windows.Forms.Timer timerLoadDrivers;
    }
}
