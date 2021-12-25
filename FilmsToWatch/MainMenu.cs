using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
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
        public static LinkedList<Film> NewFilms = new LinkedList<Film>();

        public static int CurrentQuantityOfFilms;

        private readonly string _tabWhenFilmsAreSaved;

        public static bool IsDataSaved = true;

        private readonly DataTable _filmsDataTable = new DataTable("Films");

        private static readonly Type[] ColumnTypes = {typeof(int), typeof(string), typeof(string), typeof(string), typeof(string),
            typeof(string), typeof(string), typeof(int), typeof(int), typeof(decimal) };

        private LinkedList<string> a = new LinkedList<string>();
        
        private static readonly Stack<KeyValuePair<object, DataGridViewCellValidatingEventArgs>> CellBuffer =
            new Stack<KeyValuePair<object, DataGridViewCellValidatingEventArgs>>(50);

        private static readonly Stack<int> DeletedRowsIndexes = new Stack<int>(50);

        public MainMenuForm()
        {
            InitializeComponent();
            _tabWhenFilmsAreSaved = filmsListTabPage.Text;
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            FillFilmsDataGridView();
        }

        private void FillFilmsDataTableColumns(ExcelWorksheet sheet)
        {
            int columnNumber = 0;
            foreach (var headerCell in sheet.Cells["A1:J1"])
            {
                _filmsDataTable.Columns.Add(headerCell.Value.ToString(), ColumnTypes[columnNumber]);
                columnsComboBox.Items.Add(headerCell.Value);
                ++columnNumber;
            }

            columnsComboBox.SelectedIndex = 0;
        }

        private void UpdateGenreGraph()
        {
            filmGenresChart.Series[0].Points.Clear();
            var columnGroup = from row in _filmsDataTable.AsEnumerable()
                group row by row[3]
                into genre
                select new { Name = genre.Key, Count = genre.Count() };
            foreach (var group in columnGroup)
            {
                filmGenresChart.Series[0].Points.AddXY(group.Name, group.Count);
            }
        }

        private void UpdateReleaseYearGraph()
        {
            releaseYearChart.Series[0].Points.Clear();
            
            int yearBegin = 1970;
            for (int i = 0; i < 6; i++)
            {
                releaseYearChart.Series[0].Points.AddXY($"{yearBegin}-{yearBegin + 10}",
                    _filmsDataTable.AsEnumerable().Count(col => col.Field<int>(7) >= yearBegin && col.Field<int>(7) < yearBegin + 10));
                yearBegin += 10;
            }
        }

        private void UpdateFilmBudgetGraph()
        {
            budgetChart.Series[0].Points.Clear();

            decimal budgetBegin = 0;
            for (int i = 0; i < 8; i++)
            {
                FormattableString money = $"{budgetBegin:C0}-{budgetBegin + 50000000:C0}";
                budgetChart.Series[0].Points.AddXY(money.ToString(CultureInfo.GetCultureInfo("en-US")),
                    _filmsDataTable.AsEnumerable().Count(col => col.Field<decimal>(9) > budgetBegin && col.Field<decimal>(9) <= budgetBegin + 50000000));
                budgetBegin += 50000000;
            }
        }

        private void FillFilmsDataTableRows(ref ExcelWorksheet sheet)
        {
            for (int i = 2; i <= sheet.Dimension.End.Row; i++)
            {
                DataRow newDataRow = _filmsDataTable.NewRow();
                newDataRow.ItemArray = sheet.Cells[i, 1, i, sheet.Dimension.End.Column].Select(cell => cell.Value).ToArray();
                _filmsDataTable.Rows.Add(newDataRow);
                CurrentQuantityOfFilms++;
            }

            filmsDataGridView.DataSource = _filmsDataTable;
            UpdateGenreGraph();
            UpdateReleaseYearGraph();
            UpdateFilmBudgetGraph();
            filmsDataGridView.Columns[0].ReadOnly = true;
            filmsDataGridView.Columns[9].DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("en-US");
            filmsDataGridView.Columns[9].DefaultCellStyle.Format = "C0";
        }

        private void FillFilmsDataGridView()
        {
            using (var package = new ExcelPackage(Path.GetDirectoryName(Application.ExecutablePath) + @"\Films2.xlsx"))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                FillFilmsDataTableColumns(worksheet);
                FillFilmsDataTableRows(ref worksheet);
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

        private void AddNewRows()
        {
            foreach (var film in NewFilms)
            {
                filmsDataGridView.Rows.Add(film.Id, film.Title, film.Director, film.Genre, film.Actors, film.ProductionCompany, film.Language,
                    film.ReleaseYear, film.RunningTimeInMinutes, film.Budget);
                filmsDataGridView.Rows[CurrentQuantityOfFilms - NewFilms.Count].DefaultCellStyle = filmsDataGridView.Rows[0].DefaultCellStyle;
            }

            if (IsDataSaved)
            {
                IsDataSaved = false;
                filmsListTabPage.Text += '*';
            }
        }

        private void AddNewFilmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form addFilmForm = new NewFilmForm();
            addFilmForm.ShowDialog();
            addFilmForm.Dispose();
            AddNewRows();
        }

        private void DeleteSheetRows(ref ExcelWorksheet sheet)
        {
            while (DeletedRowsIndexes.Count != 0)
            {
                var deletedRowIndex = DeletedRowsIndexes.Pop();
                sheet.DeleteRow(deletedRowIndex + 2);
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
                if (worksheet.Dimension.End.Row - 1 < filmsDataGridView.Rows.Count)
                {
                    int oldRowQuantity = worksheet.Dimension.End.Row - 1;
                    worksheet.Cells[$"A{oldRowQuantity + 1}:A{filmsDataGridView.Rows.Count}"].CopyStyles(worksheet.Cells[$"A{oldRowQuantity + 2}:A{filmsDataGridView.Rows.Count + 1}"]);
                    worksheet.Cells[$"A{oldRowQuantity + 2}:A{filmsDataGridView.Rows.Count + 1}"].Formula = "ROW()-1";
                    worksheet.Cells[$"B{oldRowQuantity + 1}:{worksheet.Dimension.End.Address}"].CopyStyles(
                        worksheet.Cells[$"B{oldRowQuantity + 2}"].LoadFromCollection(NewFilms));
                    NewFilms.Clear();
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
        public static bool FilmExists<T>(LinkedList<T> list, Predicate<T> predicate)
        {
            var node = list.First;
            while (node != null)
            {
                if (predicate(node.Value))
                {
                    return true;
                }
                node = node.Next;
            }

            return false;
        }

        private static void RemoveFirstFilm<T>(LinkedList<T> list, Predicate<T> predicate)
        {
            var node = list.First;
            while (node != null)
            {
                if (predicate(node.Value))
                {
                    list.Remove(node);
                    return;
                }
                node = node.Next;
            }
        }

        private void FilmsDataGridView_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (MessageBox.Show(@"Are you sure you want to delete selected rows? You can't undo this operation!",
                    @"Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            int oldId = Convert.ToInt32(e.Row.Cells[0].Value);
            if (FilmExists(NewFilms, film => film.Id == oldId))
            {
                RemoveFirstFilm(NewFilms, film => film.Id == oldId);
            }
            
            for (int i = e.Row.Index + 1; i < filmsDataGridView.Rows.Count; i++)
            {
                filmsDataGridView.Rows[i].Cells[0].Value = oldId++;
            }
            DeletedRowsIndexes.Push(e.Row.Index);
            CurrentQuantityOfFilms--;
            if (IsDataSaved)
            {
                IsDataSaved = false;
                filmsListTabPage.Text += '*';
            }
        }

        private void SearchTextBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(searchTextBox.Text))
            {
                _filmsDataTable.DefaultView.RowFilter = string.Empty;
                return;
            }
                
            _filmsDataTable.DefaultView.RowFilter = $"CONVERT({"[" + columnsComboBox.Text + "]"}, System.String) like '{searchTextBox.Text.Trim()}%'";

        }
    }
}
