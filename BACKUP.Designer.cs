namespace SafeBackup
{
    partial class BACKUP
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pbBackup = new ProgressBar();
            lblStatus = new Label();
            SuspendLayout();
            // 
            // pbBackup
            // 
            pbBackup.Location = new Point(30, 58);
            pbBackup.Name = "pbBackup";
            pbBackup.Size = new Size(448, 43);
            pbBackup.TabIndex = 0;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(104, 20);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(38, 15);
            lblStatus.TabIndex = 1;
            lblStatus.Text = "label1";
            // 
            // BACKUP
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(521, 232);
            Controls.Add(lblStatus);
            Controls.Add(pbBackup);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            HelpButton = true;
            Name = "BACKUP";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "BACKUP";
            Load += BACKUP_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ProgressBar pbBackup;
        private Label lblStatus;
    }
}