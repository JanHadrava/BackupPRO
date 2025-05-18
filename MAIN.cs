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

            fbdSourceFolder.Description = "Vyberte zdrojovou slo�ku.";
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
                "Program z�lohuje vybranou slo�ku ze zdrojov�ho adres��e, nakop�ruje na vybran� drive (nap�. D:\\ ), do slo�ky \\Backup\\Backup_Files, kde budou z�lohy se�azen� dle datumu. Takt� vytvo�� log z ji� provedn� z�lohy a ulo�� jej do slo�ky \\Backup\\Backup_Logs. D�kuji za pou��v�n� aplikace! @JH",
                "N�pov�da",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            if (selectedFolderPathSource == null)
            {
                MessageBox.Show(
                "P�ed z�lohov�n�m vyber zdrojovou slo�ku.",
                "N�pov�da",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            }
            else
            {
                string selectedDriver = comboBoxBackupDrives.SelectedItem?.ToString();
                DialogResult result = MessageBox.Show($"Opravdu chcete z�lohovat slo�ku {selectedFolderPathSource} na disk {selectedDriver}?", "Potvrzen�", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    if (Directory.Exists(Path.Combine(selectedDriver, "Backup"))){
                        //copies all files from selected folder path source to @"\Backup\Backup_Files");
                        string destination = Path.Combine(selectedDriver, "Backup", "Backup_Files");
                        var args = $"\"{selectedFolderPathSource}\" \"{destination}\" /E /Z /R:3 /W:5";

                        using var proc = Process.Start(new ProcessStartInfo("robocopy", args) { UseShellExecute = false, CreateNoWindow = true });
                        proc.WaitForExit();

                        MessageBox.Show(proc.ExitCode < 8 ? "Z�loha prob�hla �sp�n�." : $"Robocopy skon�ilo s chybou. Exit code: {proc.ExitCode}");
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
                    "Z�loha se neprovedla.",
                    "Upozorn�n�",
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
