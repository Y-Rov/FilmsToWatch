using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using OfficeOpenXml;

namespace FilmsToWatch
{
    public partial class MainMenuForm : Form
    {
        public static List<Film> AvailableFilms = new List<Film>();

        private static string _tabWhenFilmsAreSaved = string.Empty;

        public static bool IsDataSaved = true;

        private static readonly Type[] ColumnTypes = {typeof(int), typeof(string), typeof(string), typeof(string), typeof(string),
            typeof(string), typeof(string), typeof(int), typeof(int), typeof(decimal) };

        private LinkedList<string> a = new LinkedList<string>();
        
        private static readonly Stack<KeyValuePair<object, DataGridViewCellValidatingEventArgs>> CellBuffer =
            new Stack<KeyValuePair<object, DataGridViewCellValidatingEventArgs>>(50);

        private static readonly Stack<DataGridViewRowCancelEventArgs> DeletedRows = new Stack<DataGridViewRowCancelEventArgs>(50);

        public MainMenuForm()
        {
            InitializeComponent();
            _tabWhenFilmsAreSaved = filmsListTabPage.Text;
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            FillFilmsDataGridView();
        }

        private void FillFilmsDataGridViewColumnHeaders(ref ExcelWorksheet sheet)
        {
            int columnNumber = 0;
            foreach (var headerCell in sheet.Cells["A1:J1"])
            {
                filmsDataGridView.Columns.Add(headerCell.Value.ToString(), headerCell.Value.ToString());
                filmsDataGridView.Columns[columnNumber].HeaderCell.Style.Font = new Font(headerCell.Style.Font.Name, headerCell.Style.Font.Size);
                filmsDataGridView.Columns[columnNumber].HeaderCell.Style.Alignment = (DataGridViewContentAlignment)headerCell.Style.HorizontalAlignment;
                if (columnNumber == sheet.Dimension.End.Column - 1)
                {
                    filmsDataGridView.Columns[columnNumber].DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("en-US");
                    filmsDataGridView.Columns[columnNumber].DefaultCellStyle.Format = "C0";
                }

                filmsDataGridView.Columns[columnNumber].ValueType = ColumnTypes[columnNumber];
                ++columnNumber;
            }
            filmsDataGridView.Columns[0].ReadOnly = true;
        }

        private void FillFilmsDataGridViewRows(ref ExcelWorksheet sheet)
        {
            for (int i = 2; i <= sheet.Dimension.End.Row; i++)
            {
                filmsDataGridView.Rows[i - 2].DefaultCellStyle = new DataGridViewCellStyle
                {
                    Font = new Font(sheet.Cells[i, 1].Style.Font.Name, sheet.Cells[i, 1].Style.Font.Size)
                };

                for (int col = 1; col <= sheet.Dimension.End.Column; col++)
                {
                    filmsDataGridView.Rows[i - 2].Cells[col - 1].Value = sheet.Cells[i, col].Value;
                }

                Film film = new Film
                {
                    Id = Convert.ToInt32(sheet.Cells[i, 1].Value),
                    Title = sheet.Cells[i, 2].Value.ToString(),
                    Director = sheet.Cells[i, 3].Value.ToString(),
                    Genre = sheet.Cells[i, 4].Value.ToString(),
                    Actors = sheet.Cells[i, 5].Value.ToString(),
                    ProductionCompany = sheet.Cells[i, 6].Value.ToString(),
                    Language = sheet.Cells[i, 7].Value.ToString(),
                    ReleaseYear = Convert.ToInt32(sheet.Cells[i, 8].Value),
                    RunningTimeInMinutes = Convert.ToInt32(sheet.Cells[i, 9].Value),
                    Budget = Convert.ToDecimal(sheet.Cells[i, 10].Value)
                };
                AvailableFilms.Add(film);
            }
        }

        private void FillFilmsDataGridView()
        {
            using (var package = new ExcelPackage(Path.GetDirectoryName(Application.ExecutablePath) + @"\Films2.xlsx"))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                filmsDataGridView.AllowUserToAddRows = true;
                FillFilmsDataGridViewColumnHeaders(ref worksheet);
                filmsDataGridView.Rows.Add(worksheet.Dimension.End.Row - 1);
                FillFilmsDataGridViewRows(ref worksheet);
            }
            filmsDataGridView.AllowUserToAddRows = false;
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
            
            if (filmsDataGridView[e.ColumnIndex, e.RowIndex].FormattedValue.Equals(e.FormattedValue))
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

            CellBuffer.Push(new KeyValuePair<object, DataGridViewCellValidatingEventArgs>(
                filmsDataGridView[e.ColumnIndex, e.RowIndex].FormattedValue, e));
            
            if (IsDataSaved)
            {
                IsDataSaved = false;
                filmsListTabPage.Text += '*';
            }
        }

        private void AddNewRows(int lastRowCount)
        {
            filmsDataGridView.AllowUserToAddRows = true;
            for (int i = lastRowCount; i < AvailableFilms.Count; i++)
            {
                filmsDataGridView.Rows.Add(AvailableFilms[i].Id, AvailableFilms[i].Title, AvailableFilms[i].Director, AvailableFilms[i].Genre,
                    string.Join(", ", AvailableFilms[i].Actors), AvailableFilms[i].ProductionCompany, AvailableFilms[i].Language, AvailableFilms[i].ReleaseYear,
                    AvailableFilms[i].RunningTimeInMinutes, AvailableFilms[i].Budget);
                filmsDataGridView.Rows[i].DefaultCellStyle = filmsDataGridView.Rows[lastRowCount - 1].DefaultCellStyle;
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

        private void DeleteSheetRows(ref ExcelWorksheet sheet)
        {
            while (DeletedRows.Count != 0)
            {
                var deletedRow = DeletedRows.Pop();
                sheet.DeleteRow(deletedRow.Row.Index + 2);
            }
        }

        private void UpdateSheetCells(ref ExcelWorksheet sheet)
        {
            while (CellBuffer.Count != 0)
            {
                var changedCell = CellBuffer.Pop();
                sheet.Cells[changedCell.Value.RowIndex + 2, changedCell.Value.ColumnIndex + 1].Value = Convert.ChangeType(changedCell.Value.FormattedValue, ColumnTypes[changedCell.Value.ColumnIndex]);
            }
        }

        private void SaveDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (IsDataSaved) return;

            using (var package = new ExcelPackage(Path.GetDirectoryName(Application.ExecutablePath) + @"\Films2.xlsx"))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                DeleteSheetRows(ref worksheet);
                UpdateSheetCells(ref worksheet);
                if (worksheet.Dimension.End.Row - 1 < AvailableFilms.Count)
                {
                    int oldRowQuantity = worksheet.Dimension.End.Row - 1;
                    worksheet.Cells[$"A{oldRowQuantity + 1}:A{AvailableFilms.Count}"].CopyStyles(worksheet.Cells[$"A{oldRowQuantity + 2}:A{AvailableFilms.Count + 1}"]);
                    worksheet.Cells[$"A{oldRowQuantity + 2}:A{AvailableFilms.Count + 1}"].Formula = "ROW()-1";
                    worksheet.Cells[$"B{oldRowQuantity + 1}:{worksheet.Dimension.End.Address}"].CopyStyles(
                        worksheet.Cells[$"B{oldRowQuantity + 2}"].LoadFromCollection(AvailableFilms.Skip(oldRowQuantity)));
                }
                package.Save();
            }
            filmsListTabPage.Text = _tabWhenFilmsAreSaved;
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

        private void FilmsDataGridView_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            int oldId = Convert.ToInt32(e.Row.Cells[0].Value);
            for (int i = e.Row.Index + 1; i < AvailableFilms.Count; i++)
            {
                AvailableFilms[i].Id = oldId;
                filmsDataGridView.Rows[i].Cells[0].Value = oldId++;
            }
            DeletedRows.Push(e);
            e.Row.Visible = false;
            AvailableFilms.RemoveAt(e.Row.Index);
            if (IsDataSaved)
            {
                IsDataSaved = false;
                filmsListTabPage.Text += '*';
            }
            e.Cancel = true;
        }
    }
}
