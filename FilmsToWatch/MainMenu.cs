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

namespace FilmsToWatch
{
    public partial class MainMenuForm : Form
    {
        private List<Film> availableFilms = new List<Film>();
        public MainMenuForm()
        {
            InitializeComponent();
            FillFilmsDataGridView();
        }

        private void FillRow(ref WorkSheet sheet, int index)
        {
            filmsDataGridView.Rows[index - 2].Cells[0].Value = sheet[$"A{index}"].IntValue;
            filmsDataGridView.Rows[index - 2].Cells[0].Style.Font = new Font(sheet[$"A{index}"].Style.Font.Name, sheet[$"A{index}"].Style.Font.Height);
            filmsDataGridView.Rows[index - 2].Cells[1].Value = sheet[$"B{index}"].StringValue;
            filmsDataGridView.Rows[index - 2].Cells[1].Style.Font = new Font(sheet[$"B{index}"].Style.Font.Name, sheet[$"B{index}"].Style.Font.Height);
            filmsDataGridView.Rows[index - 2].Cells[2].Value = sheet[$"C{index}"].StringValue;
            filmsDataGridView.Rows[index - 2].Cells[2].Style.Font = new Font(sheet[$"C{index}"].Style.Font.Name, sheet[$"C{index}"].Style.Font.Height);
            filmsDataGridView.Rows[index - 2].Cells[3].Value = sheet[$"D{index}"].StringValue;
            filmsDataGridView.Rows[index - 2].Cells[3].Style.Font = new Font(sheet[$"D{index}"].Style.Font.Name, sheet[$"D{index}"].Style.Font.Height);
            filmsDataGridView.Rows[index - 2].Cells[4].Value = sheet[$"E{index}"].StringValue;
            filmsDataGridView.Rows[index - 2].Cells[4].Style.Font = new Font(sheet[$"E{index}"].Style.Font.Name, sheet[$"E{index}"].Style.Font.Height);
            filmsDataGridView.Rows[index - 2].Cells[5].Value = sheet[$"F{index}"].IntValue;
            filmsDataGridView.Rows[index - 2].Cells[5].Style.Font = new Font(sheet[$"F{index}"].Style.Font.Name, sheet[$"F{index}"].Style.Font.Height);
            filmsDataGridView.Rows[index - 2].Cells[6].Value = sheet[$"G{index}"].StringValue;
            filmsDataGridView.Rows[index - 2].Cells[6].Style.Font = new Font(sheet[$"G{index}"].Style.Font.Name, sheet[$"G{index}"].Style.Font.Height);
            filmsDataGridView.Rows[index - 2].Cells[7].Value = sheet[$"H{index}"].IntValue;
            filmsDataGridView.Rows[index - 2].Cells[7].Style.Font = new Font(sheet[$"H{index}"].Style.Font.Name, sheet[$"H{index}"].Style.Font.Height);
            filmsDataGridView.Rows[index - 2].Cells[8].Value = sheet[$"I{index}"].StringValue;
            filmsDataGridView.Rows[index - 2].Cells[8].Style.Font = new Font(sheet[$"I{index}"].Style.Font.Name, sheet[$"I{index}"].Style.Font.Height);
            filmsDataGridView.Rows[index - 2].Cells[9].Value = sheet[$"J{index}"].DecimalValue;
            filmsDataGridView.Rows[index - 2].Cells[9].Style.Font = new Font(sheet[$"J{index}"].Style.Font.Name, sheet[$"J{index}"].Style.Font.Height);
        }

        private void FillFilmsDataGridView()
        {
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

            filmsDataGridView.Rows.Add(sheet.RowCount - 1);
            for (int i = 2; i < sheet.RowCount; i++)
            {
                filmsDataGridView.Rows[i - 2].Height = sheet.Rows[i - 1].Height / 12;
                FillRow(ref sheet, i);
                string[] actors = sheet[$"E{i}"].StringValue.Split(';', ',').Select(email => email.Trim()).ToArray();
                Film film = new Film
                {
                    Id = sheet[$"A{i}"].IntValue,
                    Title = sheet[$"B{i}"].StringValue,
                    Director = sheet[$"C{i}"].StringValue,
                    Genre = sheet[$"D{i}"].StringValue,
                    ActorList = actors.ToList(),
                    RunningTimeInMinutes = sheet[$"F{i}"].IntValue,
                    ProductionCompany = sheet[$"G{i}"].StringValue,
                    ReleaseYear = sheet[$"H{i}"].IntValue,
                    Language = sheet[$"I{i}"].StringValue,
                    Budget = sheet[$"J{i}"].DecimalValue
                };
                availableFilms.Add(film);
            }
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
            }

            if (e.ColumnIndex == 0 || e.ColumnIndex == 5 || e.ColumnIndex == 7 || e.ColumnIndex == 9)
            {
                Match positiveNumberMatch = Regex.Match(e.FormattedValue.ToString(), @"^[1-9]\d*$");
                if (!positiveNumberMatch.Success)
                {
                    filmsDataGridView.Rows[e.RowIndex].ErrorText = "Cell should be a positive number!";
                    e.Cancel = true;
                }
            }
        }
    }
}
