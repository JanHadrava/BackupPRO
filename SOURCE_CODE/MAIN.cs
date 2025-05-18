using System.Diagnostics;
using System.Windows.Forms;
using System.Globalization;

namespace SafeBackup
{
    public partial class MAIN : Form
    {
        private string? selectedFolderPathSource = null;

        private int selectedIndex = 0;
        private string? selectedDrive;

        public MAIN()
        {
            InitializeComponent();
        }

        private void MAIN_Load(object sender, EventArgs e)
        {
            int major = 1, minor = 0, patch = 0;
            lblVersion.Text = $"(V{major}.{minor}.{patch})";

            LoadDrivers(selectedIndex);
            selectedDrive = comboBoxBackupDrives.SelectedItem?.ToString() ?? string.Empty;

            if (!string.IsNullOrEmpty(selectedDrive))
                GetDriveFreeSpace(selectedDrive);
        }

        private void LoadDrivers(int index)
        {
            try
            {
                string[] drives = Environment.GetLogicalDrives();
                comboBoxBackupDrives.Items.Clear();
                comboBoxBackupDrives.Items.AddRange(drives);
                comboBoxBackupDrives.SelectedIndex = selectedIndex;

                comboBoxBackupDrives.SelectedIndex = 1;
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

                long s = GetDirectorySize(selectedFolderPathSource);
                double sizeInMB = s / (1024.0 * 1024);
                llSourcePath.Text = sizeInMB.ToString("F2", CultureInfo.InvariantCulture) + " MB";

                llSourcePath.Enabled = true;
            }
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
            if (string.IsNullOrEmpty(selectedFolderPathSource))
            {
                MessageBox.Show(
                    "Pøed zálohováním vyber zdrojovou složku.",
                    "Nápovìda",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            string selectedDrive = comboBoxBackupDrives.SelectedItem?.ToString() ?? string.Empty;


            if (string.IsNullOrEmpty(selectedDrive))
            {
                MessageBox.Show("Vyber cílový disk pro zálohu.");
                return;
            }

            DriveInfo drive = new DriveInfo(selectedDrive);

            if (!drive.IsReady)
            {
                MessageBox.Show("Vybraný disk není pøipraven.");
                return;
            }

            // Show drive info
            double totalGB = drive.TotalSize / (1024.0 * 1024 * 1024);
            double freeGB = drive.TotalFreeSpace / (1024.0 * 1024 * 1024);
            double usedGB = (drive.TotalSize - drive.TotalFreeSpace) / (1024.0 * 1024 * 1024);

            MessageBox.Show($"Disk: {selectedDrive}\nCelková velikost: {totalGB:F2} GB\nVyužito: {usedGB:F2} GB\nVolné místo: {freeGB:F2} GB");

            // Confirm backup
            DialogResult backupConfirm = MessageBox.Show(
                $"Opravdu chcete zálohovat složku:\n{selectedFolderPathSource}\n\nna disk:\n{selectedDrive}?",
                "Potvrzení zálohy",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (backupConfirm != DialogResult.Yes)
            {
                MessageBox.Show("Záloha byla zrušena.", "Upozornìní", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Create folder paths
            string formattedDate = DateTime.Now.ToString("yyyy-MM-dd");
            string backupFolder = Path.Combine(selectedDrive, "Backup", "Backup_Files", $"Backup_{formattedDate}");
            string logsFolder = Path.Combine(selectedDrive, "Backup", "Backup_Logs");

            // Create base folders if they don't exist
            Directory.CreateDirectory(Path.Combine(selectedDrive, "Backup"));
            Directory.CreateDirectory(Path.Combine(selectedDrive, "Backup", "Backup_Files"));
            Directory.CreateDirectory(logsFolder);

            // Check for existing backup
            if (Directory.Exists(backupFolder))
            {
                DialogResult overwriteConfirm = MessageBox.Show(
                    $"Složka \"{backupFolder}\" již existuje. Chcete ji pøepsat?",
                    "Potvrzení pøepsání",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (overwriteConfirm != DialogResult.Yes)
                {
                    MessageBox.Show("Záloha nebyla provedena.");
                    return;
                }

                // Delete existing backup folder
                Directory.Delete(backupFolder, true);
            }

            Directory.CreateDirectory(backupFolder);

            // Calculate source folder size
            long folderSizeBytes = GetDirectorySize(selectedFolderPathSource);
            double folderSizeMB = folderSizeBytes / (1024.0 * 1024);
            MessageBox.Show($"Velikost zálohované složky: {folderSizeMB:F2} MB");

            // Run robocopy
            string robocopyArgs = $"\"{selectedFolderPathSource}\" \"{backupFolder}\" /E /Z /R:3 /W:5 /LOG:\"{Path.Combine(logsFolder, $"Backup_Log_{formattedDate}.txt")}\"";

            try
            {
                var process = System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = "robocopy",
                    Arguments = robocopyArgs ?? string.Empty,
                    UseShellExecute = false,
                    CreateNoWindow = true
                });

                if (process == null)
                {
                    MessageBox.Show("Nepodaøilo se spustit zálohovací proces.");
                    return;
                }

                process.WaitForExit();

                MessageBox.Show(process.ExitCode < 8
                    ? "Záloha probìhla úspìšnì."
                    : $"Záloha skonèila s chybou. Robocopy Exit Code: {process.ExitCode}");

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Chyba pøi zálohování: {ex.Message}");
            }
        }

        private long GetDirectorySize(string folderPath)
        {
            if (!Directory.Exists(folderPath))
                return 0;

            long totalSize = 0;

            try
            {
                foreach (string file in Directory.GetFiles(folderPath, "*", SearchOption.AllDirectories))
                {
                    try
                    {
                        FileInfo info = new FileInfo(file);
                        totalSize += info.Length;
                    }
                    catch { continue; }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Chyba pøi ètení složky: {ex.Message}");
            }

            return totalSize;
        }

        private void GetDriveFreeSpace(string driveLetter)
        {
            try
            {
                DriveInfo drive = new DriveInfo(driveLetter);

                if (drive.IsReady)
                {
                    long freeSpace = drive.AvailableFreeSpace;
                    double freeSpaceGB = freeSpace / (1024.0 * 1024 * 1024);
                    llDriveFreeSpace.Text = "FREE SPACE: " + freeSpaceGB.ToString("F2", CultureInfo.InvariantCulture) + " GB";
                }
                else
                {
                    llDriveFreeSpace.Text = "Drive not ready.";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error accessing drive: {ex.Message}");
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

        private void btnLoadPaths_Click(object sender, EventArgs e)
        {

        }

        private void btnSavePaths_Click(object sender, EventArgs e)
        {

        }

        private void llSourcePath_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!string.IsNullOrEmpty(selectedFolderPathSource))
                Process.Start("explorer.exe", selectedFolderPathSource);
        }

        private void llDriveFreeSpace_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!string.IsNullOrEmpty(selectedDrive))
                Process.Start("explorer.exe", selectedDrive);

        }
    }
}