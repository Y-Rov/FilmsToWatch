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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            errorLabel.Visible = false;
            if (string.IsNullOrWhiteSpace(usernameTextBox.Text) || string.IsNullOrWhiteSpace(passwordTextBox.Text))
            {
                MessageBox.Show(@"All fields must be non-empty or non-only-whitespace!", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var readConfiguration = new CsvConfiguration(CultureInfo.InvariantCulture) { MissingFieldFound = null };
            bool admin = false;
            bool doesUserExist = false;
            User user = null;
            using (var reader = new StreamReader(Path.GetDirectoryName(Application.ExecutablePath) + @"\Users.csv"))
            using (var csv = new CsvReader(reader, readConfiguration))
            {
                while (csv.Read())
                {
                    user = csv.GetRecord<User>();
                    if (!user.Name.Equals(usernameTextBox.Text) || !user.Password.Equals(passwordTextBox.Text)) continue;
                    doesUserExist = true;
                    if (!user.Name.Equals("==Creator==")) break;
                    admin = true;
                    break;
                }

                if (!doesUserExist)
                {
                    errorLabel.Visible = true;
                    return;
                }
            }

            AuthorizedUser authorizedUser = new AuthorizedUser { Name = user.Name, Password = user.Password, IsAdmin = admin };
            if (rememberUserCheckBox.Checked)
            {
                using (var writer = new StreamWriter(Path.GetDirectoryName(Application.ExecutablePath) + @"\AuthorizedUser.csv"))
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csv.WriteHeader<AuthorizedUser>();
                    csv.NextRecord();
                    csv.WriteRecord(authorizedUser);
                    csv.NextRecord();
                }
            }
            MainMenuForm.AuthorizedUser = authorizedUser;
            Close();
        }
    }
}
