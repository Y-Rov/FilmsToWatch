using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using IronXL;
using IronXL.Options;

namespace FilmsToWatch
{
    public partial class MainMenuForm : Form
    {
        public static List<Film> AvailableFilms = new List<Film>();
        public static bool IsDataSaved = true;
        public MainMenuForm()
        {
            InitializeComponent();
            FillFilmsDataGridView();
        }

        private void FillRow(ref WorkSheet sheet, int index)
        {
            char tableLetter = 'A';
            for (int i = 0; i < filmsDataGridView.RowCount - 2; i++, ++tableLetter)
            {
                if (i == 0 || i == 7 || i == 8)
                {
                    filmsDataGridView.Rows[index - 2].Cells[i].Value = sheet[$"{tableLetter}{index}"].IntValue;
                    filmsDataGridView.Rows[index - 2].Cells[i].Style.Font = new Font(sheet[$"{tableLetter}{index}"].Style.Font.Name, sheet[$"{tableLetter}{index}"].Style.Font.Height);
                }
                else
                {
                    filmsDataGridView.Rows[index - 2].Cells[i].Value = sheet[$"{tableLetter}{index}"].StringValue;
                    filmsDataGridView.Rows[index - 2].Cells[i].Style.Font = new Font(sheet[$"{tableLetter}{index}"].Style.Font.Name, sheet[$"{tableLetter}{index}"].Style.Font.Height);
                }
            }
            filmsDataGridView.Rows[index - 2].Cells[9].Value = sheet[$"{tableLetter}{index}"].DecimalValue;
            filmsDataGridView.Rows[index - 2].Cells[9].Style.Font = new Font(sheet[$"{tableLetter}{index}"].Style.Font.Name, sheet[$"{tableLetter}{index}"].Style.Font.Height);
        }

        private void FillFilmsDataGridView()
        {
            filmsDataGridView.AllowUserToAddRows = true;
            WorkBook workbook = WorkBook.Load(Path.GetDirectoryName(Application.ExecutablePath) + "\\Films2.xlsx");
            WorkSheet sheet = workbook.WorkSheets.First();
            int columnNumber = 0;
            foreach (var columnName in sheet["A1:J1"])
            {
                filmsDataGridView.Columns.Add(columnName.ToString(), columnName.ToString());
                filmsDataGridView.Columns[columnNumber].HeaderCell.Style.Font = new Font(columnName.Style.Font.Name, columnName.Style.Font.Height);
                filmsDataGridView.Columns[columnNumber].HeaderCell.Style.Alignment = (DataGridViewContentAlignment)columnName.Style.HorizontalAlignment;
                ++columnNumber;
            }

            filmsDataGridView.Rows[0].Height = sheet.Rows[0].Height / 12;
            filmsDataGridView.Rows.Add(sheet.RowCount - 1);
            int a = filmsDataGridView.RowCount;
            for (int i = 2; i <= sheet.RowCount; i++)
            {
                filmsDataGridView.Rows[i - 1].Height = sheet.Rows[i - 1].Height / 12;
                FillRow(ref sheet, i);
                Film film = new Film
                {
                    Id = sheet[$"A{i}"].IntValue,
                    Title = sheet[$"B{i}"].StringValue,
                    Director = sheet[$"C{i}"].StringValue,
                    Genre = sheet[$"D{i}"].StringValue,
                    ActorList = sheet[$"E{i}"].StringValue.Split(';', ',').Select(email => email.Trim()).ToList(),
                    RunningTimeInMinutes = sheet[$"F{i}"].IntValue,
                    ProductionCompany = sheet[$"G{i}"].StringValue,
                    ReleaseYear = sheet[$"H{i}"].IntValue,
                    Language = sheet[$"I{i}"].StringValue,
                    Budget = sheet[$"J{i}"].DecimalValue
                };
                AvailableFilms.Add(film);
            }

            filmsDataGridView.AllowUserToAddRows = false;
            workbook.Close();
        }

        private void ShowProgram()
        {
            Show();
            WindowState = FormWindowState.Normal;
        }

        private void TrayIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;

            switch (WindowState)
            {
                case FormWindowState.Normal:
                    Hide();
                    WindowState = FormWindowState.Minimized;
                    break;
                case FormWindowState.Minimized:
                    ShowProgram();
                    break;
                default:
                    ShowProgram();
                    break;
            }
        }

        private void MainMenuForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            trayIcon.ShowBalloonTip(5000);
            e.Cancel = true;
        }

        private void CloseMenuItem_Click(object sender, EventArgs e)
        {
            trayIcon.Dispose();
            Dispose(true);
            Application.ExitThread();
        }

        private void TrayIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ShowProgram();
        }

        private void FilmsDataGridView_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 || e.ColumnIndex == 5 || e.ColumnIndex == 7 || e.ColumnIndex == 9)
            {
                if (filmsDataGridView[e.ColumnIndex, e.RowIndex].Value == null)
                {

                }
            }

        }

        private void FilmsDataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            filmsDataGridView.Rows[e.RowIndex].ErrorText = string.Empty;
            if (string.IsNullOrWhiteSpace(e.FormattedValue.ToString()))
            {
                filmsDataGridView.Rows[e.RowIndex].ErrorText = "Cell can not be empty!";
                e.Cancel = true;
                return;
            }

            if (e.ColumnIndex == 0 || e.ColumnIndex == 7 || e.ColumnIndex == 8 || e.ColumnIndex == 9)
            {
                Match positiveNumberMatch = Regex.Match(e.FormattedValue.ToString(), @"^[1-9]\d*$");
                if (!positiveNumberMatch.Success)
                {
                    filmsDataGridView.Rows[e.RowIndex].ErrorText = "Cell should be a positive number!";
                    e.Cancel = true;
                }
            }
        }

        private void AddNewFilmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int lastFilmCount = AvailableFilms.Count;
            Form addFilmForm = new NewFilmForm();
            addFilmForm.ShowDialog();
            addFilmForm.Dispose();
            filmsDataGridView.AllowUserToAddRows = true;
            for (int i = lastFilmCount; i < AvailableFilms.Count; i++)
            {
                filmsDataGridView.Rows.Add(AvailableFilms[i].Id, AvailableFilms[i].Title, AvailableFilms[i].Director,
                    AvailableFilms[i].Genre, AvailableFilms[i].ActorList.ToArray(), AvailableFilms[i].ProductionCompany, 
                    AvailableFilms[i].Language, AvailableFilms[i].ReleaseYear,
                    AvailableFilms[i].RunningTimeInMinutes, AvailableFilms[i].Budget);
            }

            filmsDataGridView.AllowUserToAddRows = false;
        }

        private void SaveDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WorkBook workBook = WorkBook.Load(Path.GetDirectoryName(Application.ExecutablePath) + "\\Films2.xlsx");
            //WorkSheet sheet = workbook.WorkSheets.First();
        }
    }
}
