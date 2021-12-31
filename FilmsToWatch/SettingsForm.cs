using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
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
        private bool _firstLaunch = true;
        private SerializedSettings _currentSettings = new SerializedSettings();

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
                Owner.MainMenuStrip.BackColor = backgroundColorDialog.Color;
                _currentSettings.BackgroundColorArgb = Owner.BackColor.ToArgb();
            }
        }

        private bool TestEnteredCityName(string uri)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
                request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    return true;
                }
            }
            catch (WebException)
            {
                unknownCityLabel.Visible = true; 
                unknownCityLabel.Text = @"This city is unknown for weather server!";
                return false;
            }
        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            unknownCityLabel.Visible = false;
            Match resolutionMatch = Regex.Match(windowSizeComboBox.Text, @"^(\d+)x(\d+)$");

            if (string.IsNullOrWhiteSpace(weatherCityComboBox.Text))
            {
                unknownCityLabel.Visible = true;
                unknownCityLabel.Text = @"The city name can't be empty!";
                return;
            }

            if (!resolutionMatch.Success
                || !TestEnteredCityName("https://api.openweathermap.org/data/2.5/weather?q=" + weatherCityComboBox.Text + @"&units=metric&appid=a97a0c62ad17f8d59e77931f5af8aeba")) return;

            Owner.Size = new Size(Convert.ToInt32(resolutionMatch.Groups[1].Value), Convert.ToInt32(resolutionMatch.Groups[2].Value));
            Owner.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - Owner.Width) / 2, (Screen.PrimaryScreen.WorkingArea.Height - Owner.Height) / 2);

            if (!string.IsNullOrWhiteSpace(weatherCityComboBox.Text) ||
                !WeatherCityName.Equals(weatherCityComboBox.Text))
            {
                WeatherCityName = weatherCityComboBox.Text;
            }

            SerializedSettings newSerializedSettings = new SerializedSettings
            {
                BackgroundColorArgb = backgroundPictureBox.BackColor.ToArgb(),
                CityName = WeatherCityName,
                WindowSize = new Size(Convert.ToInt32(resolutionMatch.Groups[1].Value), Convert.ToInt32(resolutionMatch.Groups[2].Value))
            };

            XmlSerializer formatter = new XmlSerializer(typeof(SerializedSettings));
            using (FileStream fs = new FileStream(Path.GetDirectoryName(Application.ExecutablePath) + @"\Settings.xml", FileMode.Create))
            {
                formatter.Serialize(fs, newSerializedSettings);
            }

            unknownCityLabel.Visible = false;
            Dispose(true);
            Close();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            backgroundPictureBox.BackColor = Owner.BackColor;
        }

        private void WindowSizeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_firstLaunch)
            {
                _firstLaunch = false;
                return;
            }
            Match resolutionMatch = Regex.Match(windowSizeComboBox.Text, @"^(\d+)x(\d+)$");
            if (!resolutionMatch.Success) return;
            Owner.Size = new Size(Convert.ToInt32(resolutionMatch.Groups[1].Value),
                Convert.ToInt32(resolutionMatch.Groups[2].Value));
            Owner.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - Owner.Width) / 2,
                (Screen.PrimaryScreen.WorkingArea.Height - Owner.Height) / 2);
        }
    }
}
