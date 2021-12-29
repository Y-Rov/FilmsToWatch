using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FilmsToWatch
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
            windowSizeComboBox.SelectedIndex = 0;
        }

        private void ColorChoosingButton_Click(object sender, EventArgs e)
        {

        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            Match positiveNumberMatch = Regex.Match(windowSizeComboBox.Text, @"^(\d+)x(\d+)$");
            if (positiveNumberMatch.Success)
            {
                Owner.Size = new Size(Convert.ToInt32(positiveNumberMatch.Groups[1].Value), Convert.ToInt32(positiveNumberMatch.Groups[2].Value));
                Owner.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - Owner.Width) / 2, (Screen.PrimaryScreen.WorkingArea.Height - Owner.Height) / 2);
            }

        }
    }
}
