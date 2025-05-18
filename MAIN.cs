using System.Diagnostics;
using System.Windows.Forms;

namespace SafeBackup
{
    public partial class MAIN : Form
    {
        private string? selectedFolderPathSource = null;
        private int selectedIndex = 0;

        public MAIN()
        {
            InitializeComponent();
        }

        private void MAIN_Load(object sender, EventArgs e)
        {
            int major = 1, minor = 0, patch = 0;
            lblVersion.Text = $"(V{major}.{minor}.{patch})";

            LoadDrivers(selectedIndex);
        }

        private void LoadDrivers(int index)
        {
            try
            {
                string[] drives = Environment.GetLogicalDrives();
                comboBoxBackupDrives.Items.Clear();
                comboBoxBackupDrives.Items.AddRange(drives);
                comboBoxBackupDrives.SelectedIndex = selectedIndex;
            }
            catch
            {
                comboBoxBackupDrives.SelectedIndex = 0;
            }
        }

        private void btnSourceFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbdSourceFolder = new FolderBrowserDialog();

            fbdSourceFolder.Description = "Vyberte zdrojovou složku.";
            fbdSourceFolder.InitialDirectory = @"C:\";

            if (fbdSourceFolder.ShowDialog() == DialogResult.OK)
            {
                selectedFolderPathSource = fbdSourceFolder.SelectedPath;
                lblSourcePath.Text = $"SOURCE: {selectedFolderPathSource}";
            }
        }

        private void btnLoadPaths_Click(object sender, EventArgs e)
        {

        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Program zálohuje vybranou složku ze zdrojového adresáøe, nakopíruje na vybraný drive (napø. D:\\ ), do složky \\Backup\\Backup_Files, kde budou zálohy seøazené dle datumu. Taktéž vytvoøí log z již provedné zálohy a uloží jej do složky \\Backup\\Backup_Logs. Dìkuji za používání aplikace! @JH",
                "Nápovìda",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            if (selectedFolderPathSource == null)
            {
                MessageBox.Show(
                "Pøed zálohováním vyber zdrojovou složku.",
                "Nápovìda",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            }
            else
            {
                string selectedDriver = comboBoxBackupDrives.SelectedItem?.ToString();
                DialogResult result = MessageBox.Show($"Opravdu chcete zálohovat složku {selectedFolderPathSource} na disk {selectedDriver}?", "Potvrzení", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    if (Directory.Exists(Path.Combine(selectedDriver, "Backup"))){
                        //copies all files from selected folder path source to @"\Backup\Backup_Files");
                        string destination = Path.Combine(selectedDriver, "Backup", "Backup_Files");
                        var args = $"\"{selectedFolderPathSource}\" \"{destination}\" /E /Z /R:3 /W:5";

                        using var proc = Process.Start(new ProcessStartInfo("robocopy", args) { UseShellExecute = false, CreateNoWindow = true });
                        proc.WaitForExit();

                        MessageBox.Show(proc.ExitCode < 8 ? "Záloha probìhla úspìšnì." : $"Robocopy skonèilo s chybou. Exit code: {proc.ExitCode}");
                    }
                    else
                    {
                        Directory.CreateDirectory(selectedDriver + @"\Backup");
                        Directory.CreateDirectory(selectedDriver + @"\Backup\Backup_Files");
                        Directory.CreateDirectory(selectedDriver + @"\Backup\Backup_Logs");
                        //MessageBox.Show("Neexistuje");
                    }
                    //checks if folder Backup exists
                    //creates inside of a selected driver a folder \Backup\Backup_Files\Backup-2025-05-18
                    //and Backup\Backup_Logs\Backup_Log_2025-05-08.txt 
                }
                else
                {
                    MessageBox.Show(
                    "Záloha se neprovedla.",
                    "Upozornìní",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                }
            }
        }

        private void timerLoadDrivers_Tick(object sender, EventArgs e)
        {
            LoadDrivers(selectedIndex);
        }

        private void comboBoxBackupDrives_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedIndex = comboBoxBackupDrives.SelectedIndex;
        }
    }
}
