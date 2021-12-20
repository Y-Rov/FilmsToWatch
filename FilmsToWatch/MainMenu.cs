using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using IronXL;

namespace FilmsToWatch
{
    public partial class MainMenuForm : Form
    {
        public static List<Film> AvailableFilms = new List<Film>();
        private static readonly List<string> ColumnFormatList = new List<string>();
        public static bool IsDataSaved = true;
        public MainMenuForm()
        {
            InitializeComponent();
            FillFilmsDataGridView();
        }

        private void FillRow(ref WorkSheet sheet, int row)
        {
            for (int col = 0; col < sheet.ColumnCount - 1; col++)
            {
                if (col == 0 || col == 7 || col == 8)
                    filmsDataGridView.Rows[row].Cells[col].Value = sheet.GetCellAt(row + 1, col).IntValue;

                else
                    filmsDataGridView.Rows[row].Cells[col].Value = sheet.GetCellAt(row + 1, col).StringValue;

            }

            filmsDataGridView.Rows[row].Cells[9].Value = sheet.GetCellAt(row + 1, 9).DecimalValue;
        }

        private void FillFilmsDataGridView()
        {
            filmsDataGridView.AllowUserToAddRows = true;
            WorkBook workbook = WorkBook.Load(Path.GetDirectoryName(Application.ExecutablePath) + @"\Films2.xlsx");
            WorkSheet sheet = workbook.WorkSheets.First();
            int columnNumber = 0;

            foreach (var headerCell in sheet["A1:J1"])
            {
                filmsDataGridView.Columns.Add(headerCell.ToString(), headerCell.ToString());
                filmsDataGridView.Columns[columnNumber].HeaderCell.Style.Font = new Font(headerCell.Style.Font.Name, headerCell.Style.Font.Height);
                filmsDataGridView.Columns[columnNumber].HeaderCell.Style.Alignment = (DataGridViewContentAlignment)headerCell.Style.HorizontalAlignment;
                if (columnNumber == sheet.ColumnCount - 1)
                {
                    filmsDataGridView.Columns[columnNumber].DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("en-US");
                    filmsDataGridView.Columns[columnNumber].DefaultCellStyle.Format = "C0";
                    filmsDataGridView.Columns[columnNumber].ValueType = typeof(decimal);
                }
                ColumnFormatList.Add(sheet.GetCellAt(1, columnNumber).FormatString);
                ++columnNumber;
            }
            
            filmsDataGridView.Columns[0].ReadOnly = true;
            filmsDataGridView.Rows.Add(sheet.RowCount - 1);
            for (int i = 1; i < sheet.RowCount; i++)
            {
                filmsDataGridView.Rows[i - 1].Height = sheet.Rows[i].Height / 12;
                filmsDataGridView.Rows[i - 1].DefaultCellStyle = new DataGridViewCellStyle
                {
                    Font = new Font(sheet.GetCellAt(i, 0).Style.Font.Name,
                        sheet.GetCellAt(i, 0).Style.Font.Height)
                };
                FillRow(ref sheet, i - 1);
                Film film = new Film
                {
                    Id = sheet.GetCellAt(i, 0).IntValue,
                    Title = sheet.GetCellAt(i, 1).StringValue,
                    Director = sheet.GetCellAt(i, 2).StringValue,
                    Genre = sheet.GetCellAt(i, 3).StringValue,
                    ActorList = sheet.GetCellAt(i, 4).StringValue.Split(';', ',').Select(actor => actor.Trim()).ToList(),
                    ProductionCompany = sheet.GetCellAt(i, 5).StringValue,
                    Language = sheet.GetCellAt(i, 6).StringValue,
                    ReleaseYear = sheet.GetCellAt(i, 7).IntValue,
                    RunningTimeInMinutes = sheet.GetCellAt(i, 8).IntValue,
                    Budget = sheet.GetCellAt(i, 9).DecimalValue
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
                default:
                    ShowProgram();
                    break;
            }
        }

        private void MainMenuForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            trayIcon.ShowBalloonTip(4000);
            e.Cancel = true;
        }

        private void CloseMenuItem_Click(object sender, EventArgs e)
        {
            if (!IsDataSaved && MessageBox.Show(
                @"Are you sure you want to exit FilmsToWatch? All your unsaved changes will be permanently lost!",
                @"Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            
            trayIcon.Dispose();
            Dispose(true);
            Application.ExitThread();
        }

        private void TrayIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ShowProgram();
        }


        private void FilmsDataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            filmsDataGridView.Rows[e.RowIndex].ErrorText = string.Empty;
            var formattedValue = filmsDataGridView[e.ColumnIndex, e.RowIndex].FormattedValue;
            if (formattedValue != null && formattedValue.Equals(e.FormattedValue))
            {
                return;
            }

            if (string.IsNullOrWhiteSpace(e.FormattedValue.ToString()))
            {
                filmsDataGridView.Rows[e.RowIndex].ErrorText = "Cell can not be empty!";
                e.Cancel = true;
                return;
            }

            if (e.ColumnIndex == filmsDataGridView.ColumnCount - 3 || e.ColumnIndex == filmsDataGridView.ColumnCount - 2 || e.ColumnIndex == filmsDataGridView.ColumnCount - 1)
            {
                Match positiveNumberMatch = Regex.Match(e.FormattedValue.ToString(), @"^[1-9]\d*$");
                if (!positiveNumberMatch.Success)
                {
                    filmsDataGridView.Rows[e.RowIndex].ErrorText = "Cell should be a positive number!";
                    e.Cancel = true;
                }
            }
        }

        private void AddNewRows(int lastRowCount)
        {
            filmsDataGridView.AllowUserToAddRows = true;
            filmsDataGridView.Rows.Add(AvailableFilms.Count - lastRowCount);
            for (int i = lastRowCount; i < AvailableFilms.Count; i++)
            {
                filmsDataGridView.Rows[i].DefaultCellStyle = filmsDataGridView.Rows[lastRowCount - 1].DefaultCellStyle;
                filmsDataGridView.Rows[i].Cells[0].Value = AvailableFilms[i].Id;
                filmsDataGridView.Rows[i].Cells[1].Value = AvailableFilms[i].Title;
                filmsDataGridView.Rows[i].Cells[2].Value = AvailableFilms[i].Director;
                filmsDataGridView.Rows[i].Cells[3].Value = AvailableFilms[i].Genre;
                filmsDataGridView.Rows[i].Cells[4].Value = string.Join(", ", AvailableFilms[i].ActorList);
                filmsDataGridView.Rows[i].Cells[5].Value = AvailableFilms[i].ProductionCompany;
                filmsDataGridView.Rows[i].Cells[6].Value = AvailableFilms[i].Language;
                filmsDataGridView.Rows[i].Cells[7].Value = AvailableFilms[i].ReleaseYear;
                filmsDataGridView.Rows[i].Cells[8].Value = AvailableFilms[i].RunningTimeInMinutes;
                filmsDataGridView.Rows[i].Cells[9].Value = AvailableFilms[i].Budget;
            }

            filmsDataGridView.AllowUserToAddRows = false;
        }

        private void AddNewFilmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int lastFilmCount = AvailableFilms.Count;
            Form addFilmForm = new NewFilmForm();
            addFilmForm.ShowDialog();
            addFilmForm.Dispose();
            AddNewRows(lastFilmCount);
        }

        private void SaveDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (IsDataSaved) return;
            WorkBook workbook = WorkBook.Load(Path.GetDirectoryName(Application.ExecutablePath) + @"\Films2.xlsx");
            WorkSheet sheet = workbook.WorkSheets.First();
            int oldRowQuantity = sheet.RowCount - 1;
            for (int i = oldRowQuantity; i < AvailableFilms.Count; i++)
            {
                sheet[$"A{oldRowQuantity + 2}"].Int32Value = AvailableFilms[i].Id;
                sheet[$"B{oldRowQuantity + 2}"].StringValue = AvailableFilms[i].Title;
                sheet[$"C{oldRowQuantity + 2}"].StringValue = AvailableFilms[i].Director;
                sheet[$"D{oldRowQuantity + 2}"].StringValue = AvailableFilms[i].Genre;
                sheet[$"E{oldRowQuantity + 2}"].StringValue = string.Join(", ", AvailableFilms[i].ActorList);
                sheet[$"F{oldRowQuantity + 2}"].StringValue = AvailableFilms[i].ProductionCompany;
                sheet[$"G{oldRowQuantity + 2}"].StringValue = AvailableFilms[i].Language;
                sheet[$"H{oldRowQuantity + 2}"].Int32Value = AvailableFilms[i].ReleaseYear;
                sheet[$"I{oldRowQuantity + 2}"].Int32Value = AvailableFilms[i].RunningTimeInMinutes;
                sheet[$"J{oldRowQuantity + 2}"].DecimalValue = AvailableFilms[i].Budget;
            }

            for (int i = oldRowQuantity + 2; i < sheet.RowCount + 1; i++)
            {
                char letter = 'A';
                for (int j = 1; j <= sheet.ColumnCount; j++, ++letter)
                {
                    sheet[$"{letter}{i}"].Style.Font.Name = sheet[$"{letter}{oldRowQuantity + 1}"].Style.Font.Name;
                    sheet[$"{letter}{i}"].Style.Font.Height = sheet[$"{letter}{oldRowQuantity + 1}"].Style.Font.Height;
                    sheet[$"{letter}{i}"].Style.HorizontalAlignment = sheet[$"{letter}{oldRowQuantity + 1}"].Style.HorizontalAlignment;
                    sheet[$"{letter}{i}"].Style.VerticalAlignment = sheet[$"{letter}{oldRowQuantity + 1}"].Style.VerticalAlignment;
                    sheet[$"{letter}{i}"].Style.Font.Italic = sheet[$"{letter}{oldRowQuantity + 1}"].Style.Font.Italic;
                    sheet[$"{letter}{i}"].Style.Font.Bold = sheet[$"{letter}{oldRowQuantity + 1}"].Style.Font.Bold;
                    sheet[$"{letter}{i}"].Style.WrapText = sheet[$"{letter}{oldRowQuantity + 1}"].Style.WrapText;
                    sheet[$"{letter}{i}"].FormatString = ColumnFormatList[j - 1];
                }
                sheet.Rows[i - 1].Height = sheet.Rows[1].Height;
            }
            workbook.Save();
            workbook.Close();
            IsDataSaved = true;
        }

        private void FilmsDataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex == filmsDataGridView.ColumnCount - 1)
            {
                filmsDataGridView.Columns[e.ColumnIndex].DefaultCellStyle.Format = string.Empty;
            }
        }

        private void FilmsDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            filmsDataGridView.Rows[e.RowIndex].ErrorText = string.Empty;
            if (e.ColumnIndex == filmsDataGridView.ColumnCount - 1)
            {
                filmsDataGridView.Columns[e.ColumnIndex].DefaultCellStyle.FormatProvider =
                    CultureInfo.GetCultureInfo("en-US");
                filmsDataGridView.Columns[e.ColumnIndex].DefaultCellStyle.Format = "C0";
            }
        }
        
    }
}
