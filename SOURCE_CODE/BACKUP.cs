using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SafeBackup
{
    public partial class BACKUP : Form
    {
        public BACKUP()
        {
            InitializeComponent();
        }

        private void BACKUP_Load(object sender, EventArgs e)
        {

        }

        public void UpdateStatus(string message)
        {
            if (lblStatus.InvokeRequired)
            {
                lblStatus.Invoke(new Action(() => lblStatus.Text = message));
            }
            else
            {
                lblStatus.Text = message;
            }
        }

        public void UpdateProgress(int percent)
        {
            if (pbBackup.InvokeRequired)
            {
                pbBackup.Invoke(new Action(() => pbBackup.Value = percent));
            }
            else
            {
                pbBackup.Value = percent;
            }
        }
    }
}
