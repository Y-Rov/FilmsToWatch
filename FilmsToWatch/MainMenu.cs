using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using CsvHelper;
using FilmsToWatch.Weather;
using Newtonsoft.Json;
using OfficeOpenXml;
using Timer = System.Timers.Timer;

namespace FilmsToWatch
{
    public partial class MainMenuForm : Form
    {
        public static LinkedList<Film> NewFilms = new LinkedList<Film>();

        public static int CurrentQuantityOfFilms;

        private readonly string _tabWhenFilmsAreSaved;

        public static bool IsDataSaved = true;

        public static AuthorizedUser AuthorizedUser;

        public static readonly DataTable FilmsDataTable = new DataTable("Films");

        private static int _oldQuantityOfFilms;

        private readonly DataTable _usersDataTable = new DataTable("Users");

        private readonly LinkedList<TabPage> _tabPages = new LinkedList<TabPage>();

        private readonly Timer _weatherTimer = new Timer(5000);

        private int _previousHour = DateTime.Now.Hour;

        private static readonly Type[] ColumnTypes =
        {
            typeof(int), typeof(string), typeof(string), typeof(string), typeof(string),
            typeof(string), typeof(string), typeof(int), typeof(int), typeof(decimal)
        };

        private static readonly Stack<KeyValuePair<object, DataGridViewCellValidatingEventArgs>> CellBuffer =
            new Stack<KeyValuePair<object, DataGridViewCellValidatingEventArgs>>(50);

        private static readonly Stack<int> DeletedRowsIndexes = new Stack<int>(50);

        public MainMenuForm()
        {
            InitializeComponent();
            _tabWhenFilmsAreSaved = filmsListTabPage.Text;
            logOutToolStripMenuItem.Visible = false;
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            FillFilmsDataGridView();
            FillUsersDataGridView();
            FillTabPagesLinkedList();
            CheckIfUserIsAuthorized();
            UpdateWeatherAsync();
            _weatherTimer.Elapsed += OnTimedEvent;
            _weatherTimer.Start();
        }

        private async Task<string> SetGetAsync(string uri)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            using (HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                return await reader.ReadToEndAsync();
            }
        }

        private async void UpdateWeatherAsync()
        {
            string uri = "https://api.openweathermap.org/data/2.5/weather?q=Ivano-Frankivsk&units=metric&appid=a97a0c62ad17f8d59e77931f5af8aeba";
            string responseJson = await SetGetAsync(uri);
            
            if (responseJson == null) return;
            Root weatherRoot = JsonConvert.DeserializeObject<Root>(responseJson);
            if (weatherRoot == null) return;
            weatherPictureBox.LoadAsync("http://openweathermap.org/img/wn/" + weatherRoot.weather[0].icon + "@2x.png");
            weatherDescriptionLabel.Text = string.Format(@"{0}, wind speed: {1} meter/sec, temperature: {2}°C, humidity: {3}%",
                weatherRoot.weather[0].main, weatherRoot.wind.speed, weatherRoot.main.temp, weatherRoot.main.humidity);
        }

        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            if (_previousHour < DateTime.Now.Hour || (_previousHour == 23 && DateTime.Now.Hour == 0))
            {
                _previousHour = DateTime.Now.Hour;
                UpdateWeatherAsync();
            }
        }

        private void FillFilmsDataGridView()
        {
            using (var excelPackage = new ExcelPackage(Path.GetDirectoryName(Application.ExecutablePath) + @"\Films2.xlsx"))
            {
                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets[0];
                FillFilmsDataTableColumns(ref worksheet);
                FillFilmsDataTableRows(ref worksheet);
            }
        }

        private void FillFilmsDataTableColumns(ref ExcelWorksheet sheet)
        {
            int columnNumber = 0;
            foreach (var headerCell in sheet.Cells["A1:J1"])
            {
                FilmsDataTable.Columns.Add(headerCell.Value.ToString(), ColumnTypes[columnNumber]);
                columnsComboBox.Items.Add(headerCell.Value);
                ++columnNumber;
            }

            columnsComboBox.SelectedIndex = 0;
        }

        private void FillFilmsDataTableRows(ref ExcelWorksheet sheet)
        {
            for (int i = 2; i <= sheet.Dimension.End.Row; i++)
            {
                DataRow newDataRow = FilmsDataTable.NewRow();
                newDataRow.ItemArray = sheet.Cells[i, 1, i, sheet.Dimension.End.Column].Select(cell => cell.Value).ToArray();
                FilmsDataTable.Rows.Add(newDataRow);
                CurrentQuantityOfFilms++;
            }

            filmsDataGridView.DataSource = FilmsDataTable;
            UpdateGenreGraph();
            UpdateReleaseYearGraph();
            UpdateFilmBudgetGraph();
            filmsDataGridView.Columns[0].ReadOnly = true;
            filmsDataGridView.Columns[9].DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("en-US");
            filmsDataGridView.Columns[9].DefaultCellStyle.Format = "C0";
        }

        private void UpdateGenreGraph()
        {
            filmGenresChart.Series[0].Points.Clear();
            var columnGroup = from row in FilmsDataTable.AsEnumerable()
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
                    FilmsDataTable.AsEnumerable().Count(col => col.Field<int>(7) >= yearBegin && col.Field<int>(7) < yearBegin + 10));
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
                    FilmsDataTable.AsEnumerable().Count(col => col.Field<decimal>(9) > budgetBegin && col.Field<decimal>(9) <= budgetBegin + 50000000));
                budgetBegin += 50000000;
            }
        }

        private void FillUsersDataGridView()
        {
            using (var reader = new StreamReader(Path.GetDirectoryName(Application.ExecutablePath) + @"\Users.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            using (var dr = new CsvDataReader(csv))
            {
                _usersDataTable.Load(dr);
            }

            _usersDataTable.Columns.Cast<DataColumn>().ToList().ForEach(column => column.ReadOnly = false);
            usersDataGridView.DataSource = _usersDataTable;
        }

        private void FillTabPagesLinkedList()
        {
            for (int i = 1; i < mainMenuTabControl.TabCount; i++)
            {
                _tabPages.AddLast(mainMenuTabControl.TabPages[i]);
            }
        }

        private void CheckIfUserIsAuthorized()
        {
            using (var reader = new StreamReader(Path.GetDirectoryName(Application.ExecutablePath) + @"\AuthorizedUser.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                while (csv.Read())
                {
                    AuthorizedUser = csv.GetRecord<AuthorizedUser>();
                    break;
                }
            }

            if (AuthorizedUser == null)
            {
                LogOutUserAction();
                return;
            }

            foreach (var tab in _tabPages)
            {
                mainMenuTabControl.TabPages.Remove(tab);
            }

            LogInUserAction();
        }

        private void LogOutUserAction()
        {
            registerToolStripMenuItem.Visible = true;
            logInToolStripMenuItem.Visible = true;
            welcomeToolStripMenuItem.Visible = false;
            logOutToolStripMenuItem.Visible = false;
            currentUserLabel.Text = @"Current user is not logged in!";
            filmsDataGridView.ReadOnly = true;
            foreach (var tab in _tabPages)
            {
                mainMenuTabControl.TabPages.Remove(tab);
            }
        }

        private void LogInUserAction()
        {
            registerToolStripMenuItem.Visible = false;
            logInToolStripMenuItem.Visible = false;
            welcomeToolStripMenuItem.Visible = true;
            currentUserLabel.Text = @"Current user: " + AuthorizedUser.Name;
            welcomeToolStripMenuItem.Text = @"Welcome, " + AuthorizedUser.Name + '!';
            logOutToolStripMenuItem.Visible = true;
            filmsDataGridView.ReadOnly = false;
            int tabPagesSize = AuthorizedUser.IsAdmin ? _tabPages.Count : _tabPages.Count - 1;
            saveAllUsersToolStripMenuItem.Visible = AuthorizedUser.IsAdmin;
            var tabToAdd = _tabPages.First;
            for (int i = 0; i < tabPagesSize; i++)
            {
                mainMenuTabControl.TabPages.Add(tabToAdd.Value);
                tabToAdd = tabToAdd.Next;
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
        
        private void AddNewFilmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _oldQuantityOfFilms = FilmsDataTable.Rows.Count;
            Form addFilmForm = new NewFilmForm();
            addFilmForm.ShowDialog();
            addFilmForm.Dispose();
            AddNewRows(_oldQuantityOfFilms);
        }

        private void AddNewRows(int oldRowCount)
        {
            for (int i = oldRowCount; i < FilmsDataTable.Rows.Count; i++)
            {
                filmsDataGridView.Rows[oldRowCount].DefaultCellStyle = filmsDataGridView.Rows[0].DefaultCellStyle;
            }

            if (!IsDataSaved || oldRowCount == FilmsDataTable.Rows.Count) return;
            IsDataSaved = false;
            filmsListTabPage.Text += '*';
        }

        private void SaveDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (IsDataSaved) return;

            using (var package = new ExcelPackage(Path.GetDirectoryName(Application.ExecutablePath) + @"\Films2.xlsx"))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                DeleteSheetRows(ref worksheet);
                UpdateSheetCells(ref worksheet);
                if (worksheet.Dimension.End.Row - 1 < FilmsDataTable.Rows.Count)
                {
                    int oldRowQuantity = worksheet.Dimension.End.Row - 1;
                    worksheet.Cells[$"A{oldRowQuantity + 1}:A{FilmsDataTable.Rows.Count}"].CopyStyles(worksheet.Cells[$"A{oldRowQuantity + 2}:A{FilmsDataTable.Rows.Count + 1}"]);
                    worksheet.Cells[$"A{oldRowQuantity + 2}:A{FilmsDataTable.Rows.Count + 1}"].Formula = "ROW()-1";
                    worksheet.Cells[$"B{oldRowQuantity + 1}:{worksheet.Dimension.End.Address}"].CopyStyles(
                        worksheet.Cells[$"B{oldRowQuantity + 2}"].LoadFromCollection(NewFilms));
                }
                package.Save();
            }
            filmsListTabPage.Text = _tabWhenFilmsAreSaved;
            IsDataSaved = true;
        }

        private void DeleteSheetRows(ref ExcelWorksheet sheet)
        {
            while (DeletedRowsIndexes.Count != 0)
            {
                var deletedRowIndex = DeletedRowsIndexes.Pop();
                sheet.DeleteRow(deletedRowIndex + 1);
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
            
            if (FilmExists(NewFilms, film => film.Id == oldId))
            {
                RemoveFirstFilm(NewFilms, film => film.Id == oldId);
            }

            for (int i = oldId; i < FilmsDataTable.Rows.Count; i++)
            {
                FilmsDataTable.Rows[i].SetField(0, i);
            }

            DeletedRowsIndexes.Push(oldId);
            CurrentQuantityOfFilms--;
            
            if (IsDataSaved)
            {
                IsDataSaved = false;
                filmsListTabPage.Text += '*';
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

        private void SearchTextBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(searchTextBox.Text))
            {
                FilmsDataTable.DefaultView.RowFilter = string.Empty;
                return;
            }

            FilmsDataTable.DefaultView.RowFilter = $"CONVERT({"[" + columnsComboBox.Text + "]"}, System.String) like '{searchTextBox.Text.Trim()}%'";
        }

        private void MainMenuTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (mainMenuTabControl.SelectedIndex)
            {
                case 0:
                    searchLabel.Visible = true;
                    searchTextBox.Visible = true;
                    columnsComboBox.Visible = true;
                    columnLabel.Visible = true;
                    break;
                default:
                    searchLabel.Visible = false;
                    searchTextBox.Visible = false;
                    columnsComboBox.Visible = false;
                    columnLabel.Visible = false;
                    break;
            }
        }

        private void RegisterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            registerForm.ShowDialog();
            registerForm.Dispose();
        }

        private void LogInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.ShowDialog();
            loginForm.Dispose();
            LogInUserAction();
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void FilmsDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (AuthorizedUser == null)
            {
                MessageBox.Show(
                    @"In order to edit cells or view detailed information, please register or log in to your account!",
                    @"Authorize", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void LogOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
                    @"Are you sure you want to log out from FilmsToWatch?",
                    @"Log out", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                LogOutUserAction();
                using (var writer = new StreamWriter(Path.GetDirectoryName(Application.ExecutablePath) + @"\AuthorizedUser.csv"))
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    
                }
            }
        }

        private void UsersDataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            
        }

        private void SettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsForm settingsForm = new SettingsForm();
            settingsForm.ShowDialog(this);
            settingsForm.Dispose();
        }
    }
}
