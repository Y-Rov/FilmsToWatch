using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace FilmsToWatch
{
    public partial class SettingsForm : Form
    {

        public static string WeatherCityName = "Ivano-Frankivsk";

        public SettingsForm()
        {
            InitializeComponent();
            windowSizeComboBox.SelectedIndex = 0;
            weatherCityComboBox.SelectedIndex = 0;
        }

        private void ColorChoosingButton_Click(object sender, EventArgs e)
        {
            if (backgroundColorDialog.ShowDialog() == DialogResult.OK)
            {
                backgroundPictureBox.BackColor = backgroundColorDialog.Color;
                Owner.BackColor = backgroundColorDialog.Color;
            }
        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            Match positiveNumberMatch = Regex.Match(windowSizeComboBox.Text, @"^(\d+)x(\d+)$");
            if (positiveNumberMatch.Success)
            {
                Owner.Size = new Size(Convert.ToInt32(positiveNumberMatch.Groups[1].Value), Convert.ToInt32(positiveNumberMatch.Groups[2].Value));
                Owner.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - Owner.Width) / 2, (Screen.PrimaryScreen.WorkingArea.Height - Owner.Height) / 2);
                if (!string.IsNullOrWhiteSpace(weatherCityComboBox.Text) || !WeatherCityName.Equals(weatherCityComboBox.Text))
                {
                    WeatherCityName = weatherCityComboBox.Text;
                }
                Close();
                SerializedSettings newSerializedSettings = new SerializedSettings()
                {
                    AlphaChannel = backgroundPictureBox.BackColor.A,
                    RedChannel = backgroundPictureBox.BackColor.R,
                    GreenChannel = backgroundPictureBox.BackColor.G,
                    BlueChannel = backgroundPictureBox.BackColor.B,
                    CityName = WeatherCityName,
                    WindowSize = new Size(Convert.ToInt32(positiveNumberMatch.Groups[1].Value), Convert.ToInt32(positiveNumberMatch.Groups[2].Value))
                };
                XmlSerializer formatter = new XmlSerializer(typeof(SerializedSettings));
                using (FileStream fs = new FileStream(Path.GetDirectoryName(Application.ExecutablePath) + @"\Settings.xml", FileMode.OpenOrCreate))
                {
                    formatter.Serialize(fs, newSerializedSettings);
                }
            }
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            backgroundPictureBox.BackColor = Owner.BackColor;
        }
    }
}
