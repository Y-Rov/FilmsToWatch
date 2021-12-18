using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FilmsToWatch
{
    public partial class NewFilmForm : Form
    {
        public NewFilmForm()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(titleTextBox.Text) || string.IsNullOrWhiteSpace(directorTextBox.Text) ||
                string.IsNullOrWhiteSpace(genreTextBox.Text) || string.IsNullOrWhiteSpace(actorsRichTextBox.Text) ||
                string.IsNullOrWhiteSpace(languageTextBox.Text))
            {
                MessageBox.Show(@"All cells must be filled!", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MainMenuForm.AvailableFilms.Exists(film => film.Title == titleTextBox.Text))
            {
                MessageBox.Show($@"Film ""{titleTextBox.Text}"" already exists!", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MainMenuForm.IsDataSaved = false;
            Film newFilm = new Film
            {
                Id = MainMenuForm.AvailableFilms.Count + 1,
                Title = titleTextBox.Text,
                Director = directorTextBox.Text,
                Genre = genreTextBox.Text,
                ActorList = actorsRichTextBox.Text.Split(';', ',').Select(email => email.Trim()).ToList(),
                ProductionCompany = productionTextBox.Text,
                Language = languageTextBox.Text,
                ReleaseYear = (int)releaseYearNumericUpDown.Value,
                RunningTimeInMinutes = (int)runningTimeNumericUpDown.Value,
                Budget = budgetNumericUpDown.Value
            };
            MainMenuForm.AvailableFilms.Add(newFilm);
            MessageBox.Show($@"Film ""{newFilm.Title}"" was added successfully!", @"Success", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
    }
}
