using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CsvHelper;
using CsvHelper.Configuration;

namespace FilmsToWatch
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            errorLabel.Visible = false;
            if (string.IsNullOrWhiteSpace(usernameTextBox.Text) || string.IsNullOrWhiteSpace(passwordTextBox.Text))
            {
                MessageBox.Show(@"All fields must be non-empty or non-only-whitespace!", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var reader = new StreamReader(Path.GetDirectoryName(Application.ExecutablePath) + @"\Users.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                while (csv.Read())
                {
                    var user = csv.GetRecord<User>();
                    if (!user.Name.Equals(usernameTextBox.Text)) continue;
                    errorLabel.Visible = true;
                    return;
                }
            }

            User registeredUser = new User { Name = usernameTextBox.Text, Password = passwordTextBox.Text };
            using (var stream = File.Open(Path.GetDirectoryName(Application.ExecutablePath) + @"\Users.csv", FileMode.Append))
            using (var writer = new StreamWriter(stream))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecord(registeredUser);
                csv.NextRecord();
            }

            DialogResult = DialogResult.OK;
            MessageBox.Show(@"You have been registered successfully! Now, please log in to your account!", @"Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Dispose(true);
            Close();
        }
    }
}
