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
            btnChooseSourceFolder = new Button();
            lblTitle = new Label();
            lblVersion = new Label();
            btnLoadPaths = new Button();
            btnBackup = new Button();
            btnHelp = new Button();
            comboBoxBackupDrives = new ComboBox();
            lblSourcePath = new Label();
            timerLoadDrivers = new System.Windows.Forms.Timer(components);
            btnSavePaths = new Button();
            llSourcePath = new LinkLabel();
            llDriveFreeSpace = new LinkLabel();
            SuspendLayout();
            // 
            // btnChooseSourceFolder
            // 
            btnChooseSourceFolder.BackColor = Color.White;
            btnChooseSourceFolder.Location = new Point(12, 119);
            btnChooseSourceFolder.Name = "btnChooseSourceFolder";
            btnChooseSourceFolder.Size = new Size(360, 100);
            btnChooseSourceFolder.TabIndex = 0;
            btnChooseSourceFolder.Text = "VYBRAT ZDROJOVOU SLOŽKU";
            btnChooseSourceFolder.UseVisualStyleBackColor = false;
            btnChooseSourceFolder.Click += btnSourceFolder_Click;
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
            btnBackup.Location = new Point(66, 247);
            btnBackup.Name = "btnBackup";
            btnBackup.Size = new Size(225, 34);
            btnBackup.TabIndex = 4;
            btnBackup.Text = "ZÁLOHUJ";
            btnBackup.UseVisualStyleBackColor = false;
            btnBackup.Click += btnBackup_Click;
            // 
            // btnHelp
            // 
            btnHelp.Location = new Point(297, 246);
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
            comboBoxBackupDrives.Location = new Point(12, 247);
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
            // btnSavePaths
            // 
            btnSavePaths.Location = new Point(227, 52);
            btnSavePaths.Name = "btnSavePaths";
            btnSavePaths.Size = new Size(145, 34);
            btnSavePaths.TabIndex = 9;
            btnSavePaths.Text = "ULOŽIT CESTY";
            btnSavePaths.UseVisualStyleBackColor = true;
            btnSavePaths.Click += btnSavePaths_Click;
            // 
            // llSourcePath
            // 
            llSourcePath.AutoSize = true;
            llSourcePath.Cursor = Cursors.Hand;
            llSourcePath.Enabled = false;
            llSourcePath.LinkBehavior = LinkBehavior.AlwaysUnderline;
            llSourcePath.Location = new Point(323, 101);
            llSourcePath.Name = "llSourcePath";
            llSourcePath.Size = new Size(46, 15);
            llSourcePath.TabIndex = 10;
            llSourcePath.TabStop = true;
            llSourcePath.Text = "0.00MB";
            llSourcePath.LinkClicked += llSourcePath_LinkClicked;
            // 
            // llDriveFreeSpace
            // 
            llDriveFreeSpace.AutoSize = true;
            llDriveFreeSpace.Location = new Point(10, 227);
            llDriveFreeSpace.Name = "llDriveFreeSpace";
            llDriveFreeSpace.Size = new Size(111, 15);
            llDriveFreeSpace.TabIndex = 11;
            llDriveFreeSpace.TabStop = true;
            llDriveFreeSpace.Text = "FREE SPACE: 0.00GB";
            llDriveFreeSpace.LinkClicked += llDriveFreeSpace_LinkClicked;
            // 
            // MAIN
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(384, 292);
            Controls.Add(llDriveFreeSpace);
            Controls.Add(llSourcePath);
            Controls.Add(btnSavePaths);
            Controls.Add(lblSourcePath);
            Controls.Add(comboBoxBackupDrives);
            Controls.Add(btnHelp);
            Controls.Add(btnBackup);
            Controls.Add(btnLoadPaths);
            Controls.Add(lblVersion);
            Controls.Add(lblTitle);
            Controls.Add(btnChooseSourceFolder);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "MAIN";
            Text = "SafeBackup";
            Load += MAIN_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnChooseSourceFolder;
        private Label lblTitle;
        private Label lblVersion;
        private Button btnLoadPaths;
        private Button btnBackup;
        private Button btnHelp;
        private ComboBox comboBoxBackupDrives;
        private Label lblSourcePath;
        private System.Windows.Forms.Timer timerLoadDrivers;
        private Button btnSavePaths;
        private LinkLabel llSourcePath;
        private LinkLabel llDriveFreeSpace;
    }
}
