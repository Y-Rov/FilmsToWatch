
namespace FilmsToWatch
{
    partial class MainMenuForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenuForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea16 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend16 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series16 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea17 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend17 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series17 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea18 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend18 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series18 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.trayMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.actionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewFilmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAllUsersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logInToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.welcomeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filmsDataGridView = new System.Windows.Forms.DataGridView();
            this.mainMenuTabControl = new System.Windows.Forms.TabControl();
            this.filmsListTabPage = new System.Windows.Forms.TabPage();
            this.genreGraphTabPage = new System.Windows.Forms.TabPage();
            this.filmGenresChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.releaseYearGraphTabPage = new System.Windows.Forms.TabPage();
            this.releaseYearChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.filmBudgetGraphTabPage = new System.Windows.Forms.TabPage();
            this.budgetChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.registeredUsersTabPage = new System.Windows.Forms.TabPage();
            this.usersDataGridView = new System.Windows.Forms.DataGridView();
            this.searchLabel = new System.Windows.Forms.Label();
            this.columnsComboBox = new System.Windows.Forms.ComboBox();
            this.columnLabel = new System.Windows.Forms.Label();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.currentUserLabel = new System.Windows.Forms.Label();
            this.weatherPictureBox = new System.Windows.Forms.PictureBox();
            this.weatherDescriptionLabel = new System.Windows.Forms.Label();
            this.trayMenuStrip.SuspendLayout();
            this.mainMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.filmsDataGridView)).BeginInit();
            this.mainMenuTabControl.SuspendLayout();
            this.filmsListTabPage.SuspendLayout();
            this.genreGraphTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.filmGenresChart)).BeginInit();
            this.releaseYearGraphTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.releaseYearChart)).BeginInit();
            this.filmBudgetGraphTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.budgetChart)).BeginInit();
            this.registeredUsersTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.usersDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.weatherPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // trayIcon
            // 
            this.trayIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.trayIcon.BalloonTipText = "FilmsToWatch is running in the background. To close - RMB click on the tray icon," +
    " exit.";
            this.trayIcon.BalloonTipTitle = "System Tray";
            this.trayIcon.ContextMenuStrip = this.trayMenuStrip;
            this.trayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("trayIcon.Icon")));
            this.trayIcon.Text = "FilmsToWatch";
            this.trayIcon.Visible = true;
            this.trayIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TrayIcon_MouseClick);
            this.trayIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.TrayIcon_MouseDoubleClick);
            // 
            // trayMenuStrip
            // 
            this.trayMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.trayMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openMenuItem,
            this.settingsMenuItem,
            this.closeMenuItem});
            this.trayMenuStrip.Name = "TrayMenuStrip";
            this.trayMenuStrip.Size = new System.Drawing.Size(132, 76);
            // 
            // openMenuItem
            // 
            this.openMenuItem.Name = "openMenuItem";
            this.openMenuItem.Size = new System.Drawing.Size(131, 24);
            this.openMenuItem.Text = "Open";
            this.openMenuItem.Click += new System.EventHandler(this.OpenMenuItem_Click);
            // 
            // settingsMenuItem
            // 
            this.settingsMenuItem.Name = "settingsMenuItem";
            this.settingsMenuItem.Size = new System.Drawing.Size(131, 24);
            this.settingsMenuItem.Text = "Settings";
            this.settingsMenuItem.Click += new System.EventHandler(this.SettingsMenuItem_Click);
            // 
            // closeMenuItem
            // 
            this.closeMenuItem.Name = "closeMenuItem";
            this.closeMenuItem.Size = new System.Drawing.Size(131, 24);
            this.closeMenuItem.Text = "Exit";
            this.closeMenuItem.Click += new System.EventHandler(this.CloseMenuItem_Click);
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.mainMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.actionToolStripMenuItem,
            this.editToolStripMenuItem,
            this.accountToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(1348, 28);
            this.mainMenuStrip.TabIndex = 1;
            this.mainMenuStrip.Text = "menuStrip1";
            // 
            // actionToolStripMenuItem
            // 
            this.actionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewFilmToolStripMenuItem,
            this.saveDataToolStripMenuItem,
            this.saveAllUsersToolStripMenuItem});
            this.actionToolStripMenuItem.Name = "actionToolStripMenuItem";
            this.actionToolStripMenuItem.Size = new System.Drawing.Size(66, 24);
            this.actionToolStripMenuItem.Text = "Action";
            // 
            // addNewFilmToolStripMenuItem
            // 
            this.addNewFilmToolStripMenuItem.Name = "addNewFilmToolStripMenuItem";
            this.addNewFilmToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.addNewFilmToolStripMenuItem.Size = new System.Drawing.Size(274, 26);
            this.addNewFilmToolStripMenuItem.Text = "New Film";
            this.addNewFilmToolStripMenuItem.Click += new System.EventHandler(this.AddNewFilmToolStripMenuItem_Click);
            // 
            // saveDataToolStripMenuItem
            // 
            this.saveDataToolStripMenuItem.Name = "saveDataToolStripMenuItem";
            this.saveDataToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveDataToolStripMenuItem.Size = new System.Drawing.Size(274, 26);
            this.saveDataToolStripMenuItem.Text = "Save All Films";
            this.saveDataToolStripMenuItem.Click += new System.EventHandler(this.SaveDataToolStripMenuItem_Click);
            // 
            // saveAllUsersToolStripMenuItem
            // 
            this.saveAllUsersToolStripMenuItem.Name = "saveAllUsersToolStripMenuItem";
            this.saveAllUsersToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.saveAllUsersToolStripMenuItem.Size = new System.Drawing.Size(274, 26);
            this.saveAllUsersToolStripMenuItem.Text = "Save All Users";
            this.saveAllUsersToolStripMenuItem.Visible = false;
            this.saveAllUsersToolStripMenuItem.Click += new System.EventHandler(this.SaveAllUsersToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(49, 24);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.undoToolStripMenuItem.Text = "Undo";
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.UndoToolStripMenuItem_Click);
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.redoToolStripMenuItem.Text = "Redo";
            this.redoToolStripMenuItem.Click += new System.EventHandler(this.RedoToolStripMenuItem_Click);
            // 
            // accountToolStripMenuItem
            // 
            this.accountToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.registerToolStripMenuItem,
            this.logInToolStripMenuItem,
            this.welcomeToolStripMenuItem,
            this.logOutToolStripMenuItem});
            this.accountToolStripMenuItem.Name = "accountToolStripMenuItem";
            this.accountToolStripMenuItem.Size = new System.Drawing.Size(77, 24);
            this.accountToolStripMenuItem.Text = "Account";
            // 
            // registerToolStripMenuItem
            // 
            this.registerToolStripMenuItem.Name = "registerToolStripMenuItem";
            this.registerToolStripMenuItem.Size = new System.Drawing.Size(146, 26);
            this.registerToolStripMenuItem.Text = "Register";
            this.registerToolStripMenuItem.Click += new System.EventHandler(this.RegisterToolStripMenuItem_Click);
            // 
            // logInToolStripMenuItem
            // 
            this.logInToolStripMenuItem.Name = "logInToolStripMenuItem";
            this.logInToolStripMenuItem.Size = new System.Drawing.Size(146, 26);
            this.logInToolStripMenuItem.Text = "Login";
            this.logInToolStripMenuItem.Click += new System.EventHandler(this.LogInToolStripMenuItem_Click);
            // 
            // welcomeToolStripMenuItem
            // 
            this.welcomeToolStripMenuItem.Enabled = false;
            this.welcomeToolStripMenuItem.Name = "welcomeToolStripMenuItem";
            this.welcomeToolStripMenuItem.Size = new System.Drawing.Size(146, 26);
            // 
            // logOutToolStripMenuItem
            // 
            this.logOutToolStripMenuItem.Name = "logOutToolStripMenuItem";
            this.logOutToolStripMenuItem.Size = new System.Drawing.Size(146, 26);
            this.logOutToolStripMenuItem.Text = "Log out";
            this.logOutToolStripMenuItem.Click += new System.EventHandler(this.LogOutToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(76, 24);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.SettingsToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(64, 24);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // filmsDataGridView
            // 
            this.filmsDataGridView.AllowUserToAddRows = false;
            this.filmsDataGridView.AllowUserToResizeColumns = false;
            this.filmsDataGridView.AllowUserToResizeRows = false;
            this.filmsDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filmsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.filmsDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.filmsDataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle21.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle21.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle21.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle21.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle21.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.filmsDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle21;
            this.filmsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle22.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle22.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle22.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle22.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle22.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.filmsDataGridView.DefaultCellStyle = dataGridViewCellStyle22;
            this.filmsDataGridView.Location = new System.Drawing.Point(6, 6);
            this.filmsDataGridView.Name = "filmsDataGridView";
            this.filmsDataGridView.RowHeadersWidth = 51;
            this.filmsDataGridView.RowTemplate.Height = 24;
            this.filmsDataGridView.Size = new System.Drawing.Size(1304, 545);
            this.filmsDataGridView.TabIndex = 2;
            this.filmsDataGridView.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.FilmsDataGridView_CellBeginEdit);
            this.filmsDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.FilmsDataGridView_CellDoubleClick);
            this.filmsDataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.FilmsDataGridView_CellEndEdit);
            this.filmsDataGridView.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.FilmsDataGridView_CellValidating);
            this.filmsDataGridView.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.FilmsDataGridView_UserDeletedRow);
            this.filmsDataGridView.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.FilmsDataGridView_UserDeletingRow);
            // 
            // mainMenuTabControl
            // 
            this.mainMenuTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainMenuTabControl.Controls.Add(this.filmsListTabPage);
            this.mainMenuTabControl.Controls.Add(this.genreGraphTabPage);
            this.mainMenuTabControl.Controls.Add(this.releaseYearGraphTabPage);
            this.mainMenuTabControl.Controls.Add(this.filmBudgetGraphTabPage);
            this.mainMenuTabControl.Controls.Add(this.registeredUsersTabPage);
            this.mainMenuTabControl.Location = new System.Drawing.Point(12, 74);
            this.mainMenuTabControl.Name = "mainMenuTabControl";
            this.mainMenuTabControl.SelectedIndex = 0;
            this.mainMenuTabControl.Size = new System.Drawing.Size(1324, 586);
            this.mainMenuTabControl.TabIndex = 3;
            this.mainMenuTabControl.SelectedIndexChanged += new System.EventHandler(this.MainMenuTabControl_SelectedIndexChanged);
            // 
            // filmsListTabPage
            // 
            this.filmsListTabPage.Controls.Add(this.filmsDataGridView);
            this.filmsListTabPage.Location = new System.Drawing.Point(4, 25);
            this.filmsListTabPage.Name = "filmsListTabPage";
            this.filmsListTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.filmsListTabPage.Size = new System.Drawing.Size(1316, 557);
            this.filmsListTabPage.TabIndex = 0;
            this.filmsListTabPage.Text = "List of films";
            this.filmsListTabPage.UseVisualStyleBackColor = true;
            // 
            // genreGraphTabPage
            // 
            this.genreGraphTabPage.Controls.Add(this.filmGenresChart);
            this.genreGraphTabPage.Location = new System.Drawing.Point(4, 25);
            this.genreGraphTabPage.Name = "genreGraphTabPage";
            this.genreGraphTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.genreGraphTabPage.Size = new System.Drawing.Size(1316, 557);
            this.genreGraphTabPage.TabIndex = 1;
            this.genreGraphTabPage.Text = "Genre Graph";
            this.genreGraphTabPage.UseVisualStyleBackColor = true;
            // 
            // filmGenresChart
            // 
            this.filmGenresChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea16.AxisX.IsLabelAutoFit = false;
            chartArea16.AxisX.LabelStyle.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea16.AxisX.Title = "Genres";
            chartArea16.AxisX.TitleFont = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea16.AxisY.IsLabelAutoFit = false;
            chartArea16.AxisY.LabelStyle.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea16.AxisY.Title = "Quantity of films";
            chartArea16.AxisY.TitleFont = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea16.Name = "ChartArea1";
            this.filmGenresChart.ChartAreas.Add(chartArea16);
            legend16.Name = "Legend1";
            this.filmGenresChart.Legends.Add(legend16);
            this.filmGenresChart.Location = new System.Drawing.Point(6, 6);
            this.filmGenresChart.Name = "filmGenresChart";
            series16.ChartArea = "ChartArea1";
            series16.IsVisibleInLegend = false;
            series16.Legend = "Legend1";
            series16.Name = "Series1";
            this.filmGenresChart.Series.Add(series16);
            this.filmGenresChart.Size = new System.Drawing.Size(1304, 564);
            this.filmGenresChart.TabIndex = 0;
            this.filmGenresChart.Text = "chart1";
            // 
            // releaseYearGraphTabPage
            // 
            this.releaseYearGraphTabPage.Controls.Add(this.releaseYearChart);
            this.releaseYearGraphTabPage.Location = new System.Drawing.Point(4, 25);
            this.releaseYearGraphTabPage.Name = "releaseYearGraphTabPage";
            this.releaseYearGraphTabPage.Size = new System.Drawing.Size(1316, 557);
            this.releaseYearGraphTabPage.TabIndex = 2;
            this.releaseYearGraphTabPage.Text = "Release Year Graph";
            this.releaseYearGraphTabPage.UseVisualStyleBackColor = true;
            // 
            // releaseYearChart
            // 
            this.releaseYearChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea17.AxisX.IsLabelAutoFit = false;
            chartArea17.AxisX.LabelStyle.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea17.AxisX.Title = "Release year";
            chartArea17.AxisX.TitleFont = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea17.AxisY.IsLabelAutoFit = false;
            chartArea17.AxisY.LabelStyle.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea17.AxisY.Title = "Quantity of films";
            chartArea17.AxisY.TitleFont = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea17.Name = "ChartArea1";
            this.releaseYearChart.ChartAreas.Add(chartArea17);
            legend17.Name = "Legend1";
            this.releaseYearChart.Legends.Add(legend17);
            this.releaseYearChart.Location = new System.Drawing.Point(4, 3);
            this.releaseYearChart.Name = "releaseYearChart";
            series17.ChartArea = "ChartArea1";
            series17.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series17.IsVisibleInLegend = false;
            series17.Legend = "Legend1";
            series17.Name = "Series1";
            this.releaseYearChart.Series.Add(series17);
            this.releaseYearChart.Size = new System.Drawing.Size(1309, 549);
            this.releaseYearChart.TabIndex = 0;
            this.releaseYearChart.Text = "chart1";
            // 
            // filmBudgetGraphTabPage
            // 
            this.filmBudgetGraphTabPage.Controls.Add(this.budgetChart);
            this.filmBudgetGraphTabPage.Location = new System.Drawing.Point(4, 25);
            this.filmBudgetGraphTabPage.Name = "filmBudgetGraphTabPage";
            this.filmBudgetGraphTabPage.Size = new System.Drawing.Size(1316, 557);
            this.filmBudgetGraphTabPage.TabIndex = 3;
            this.filmBudgetGraphTabPage.Text = "Film Budget Graph";
            this.filmBudgetGraphTabPage.UseVisualStyleBackColor = true;
            // 
            // budgetChart
            // 
            this.budgetChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea18.AxisX.IsLabelAutoFit = false;
            chartArea18.AxisX.LabelStyle.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea18.AxisX.Title = "Budget";
            chartArea18.AxisX.TitleFont = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea18.AxisY.IsLabelAutoFit = false;
            chartArea18.AxisY.LabelStyle.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea18.AxisY.Title = "Quantity of films";
            chartArea18.AxisY.TitleFont = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea18.Name = "ChartArea1";
            this.budgetChart.ChartAreas.Add(chartArea18);
            legend18.Name = "Legend1";
            this.budgetChart.Legends.Add(legend18);
            this.budgetChart.Location = new System.Drawing.Point(4, 3);
            this.budgetChart.Name = "budgetChart";
            series18.ChartArea = "ChartArea1";
            series18.IsVisibleInLegend = false;
            series18.Legend = "Legend1";
            series18.Name = "Series1";
            this.budgetChart.Series.Add(series18);
            this.budgetChart.Size = new System.Drawing.Size(1309, 551);
            this.budgetChart.TabIndex = 0;
            this.budgetChart.Text = "chart1";
            // 
            // registeredUsersTabPage
            // 
            this.registeredUsersTabPage.Controls.Add(this.usersDataGridView);
            this.registeredUsersTabPage.Location = new System.Drawing.Point(4, 25);
            this.registeredUsersTabPage.Name = "registeredUsersTabPage";
            this.registeredUsersTabPage.Size = new System.Drawing.Size(1316, 557);
            this.registeredUsersTabPage.TabIndex = 4;
            this.registeredUsersTabPage.Text = "Users";
            this.registeredUsersTabPage.UseVisualStyleBackColor = true;
            // 
            // usersDataGridView
            // 
            this.usersDataGridView.AllowUserToAddRows = false;
            this.usersDataGridView.AllowUserToResizeColumns = false;
            this.usersDataGridView.AllowUserToResizeRows = false;
            this.usersDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.usersDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.usersDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.usersDataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle23.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle23.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle23.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle23.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle23.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.usersDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle23;
            this.usersDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle24.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle24.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle24.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle24.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle24.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.usersDataGridView.DefaultCellStyle = dataGridViewCellStyle24;
            this.usersDataGridView.Location = new System.Drawing.Point(3, 3);
            this.usersDataGridView.Name = "usersDataGridView";
            this.usersDataGridView.RowHeadersWidth = 51;
            this.usersDataGridView.RowTemplate.Height = 24;
            this.usersDataGridView.Size = new System.Drawing.Size(1310, 590);
            this.usersDataGridView.TabIndex = 0;
            // 
            // searchLabel
            // 
            this.searchLabel.AutoSize = true;
            this.searchLabel.Location = new System.Drawing.Point(278, 40);
            this.searchLabel.Name = "searchLabel";
            this.searchLabel.Size = new System.Drawing.Size(57, 17);
            this.searchLabel.TabIndex = 4;
            this.searchLabel.Text = "Search:";
            // 
            // columnsComboBox
            // 
            this.columnsComboBox.FormattingEnabled = true;
            this.columnsComboBox.Location = new System.Drawing.Point(79, 37);
            this.columnsComboBox.Name = "columnsComboBox";
            this.columnsComboBox.Size = new System.Drawing.Size(181, 24);
            this.columnsComboBox.TabIndex = 5;
            // 
            // columnLabel
            // 
            this.columnLabel.AutoSize = true;
            this.columnLabel.Location = new System.Drawing.Point(14, 40);
            this.columnLabel.Name = "columnLabel";
            this.columnLabel.Size = new System.Drawing.Size(59, 17);
            this.columnLabel.TabIndex = 6;
            this.columnLabel.Text = "Column:";
            // 
            // searchTextBox
            // 
            this.searchTextBox.Location = new System.Drawing.Point(341, 37);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(263, 22);
            this.searchTextBox.TabIndex = 7;
            this.searchTextBox.TextChanged += new System.EventHandler(this.SearchTextBox_TextChanged);
            // 
            // currentUserLabel
            // 
            this.currentUserLabel.AutoSize = true;
            this.currentUserLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentUserLabel.Location = new System.Drawing.Point(621, 40);
            this.currentUserLabel.Name = "currentUserLabel";
            this.currentUserLabel.Size = new System.Drawing.Size(73, 17);
            this.currentUserLabel.TabIndex = 8;
            this.currentUserLabel.Text = "Username";
            // 
            // weatherPictureBox
            // 
            this.weatherPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.weatherPictureBox.Location = new System.Drawing.Point(668, 668);
            this.weatherPictureBox.Name = "weatherPictureBox";
            this.weatherPictureBox.Size = new System.Drawing.Size(50, 50);
            this.weatherPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.weatherPictureBox.TabIndex = 9;
            this.weatherPictureBox.TabStop = false;
            // 
            // weatherDescriptionLabel
            // 
            this.weatherDescriptionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.weatherDescriptionLabel.AutoSize = true;
            this.weatherDescriptionLabel.Location = new System.Drawing.Point(724, 685);
            this.weatherDescriptionLabel.Name = "weatherDescriptionLabel";
            this.weatherDescriptionLabel.Size = new System.Drawing.Size(264, 17);
            this.weatherDescriptionLabel.TabIndex = 11;
            this.weatherDescriptionLabel.Text = "Sorry, the weather is not available now :(";
            // 
            // MainMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(1348, 721);
            this.Controls.Add(this.weatherDescriptionLabel);
            this.Controls.Add(this.weatherPictureBox);
            this.Controls.Add(this.currentUserLabel);
            this.Controls.Add(this.searchTextBox);
            this.Controls.Add(this.columnLabel);
            this.Controls.Add(this.columnsComboBox);
            this.Controls.Add(this.searchLabel);
            this.Controls.Add(this.mainMenuTabControl);
            this.Controls.Add(this.mainMenuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mainMenuStrip;
            this.MinimumSize = new System.Drawing.Size(1366, 768);
            this.Name = "MainMenuForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FilmsToWatch";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainMenuForm_FormClosing);
            this.trayMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.filmsDataGridView)).EndInit();
            this.mainMenuTabControl.ResumeLayout(false);
            this.filmsListTabPage.ResumeLayout(false);
            this.genreGraphTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.filmGenresChart)).EndInit();
            this.releaseYearGraphTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.releaseYearChart)).EndInit();
            this.filmBudgetGraphTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.budgetChart)).EndInit();
            this.registeredUsersTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.usersDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.weatherPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon trayIcon;
        private System.Windows.Forms.ContextMenuStrip trayMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem openMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeMenuItem;
        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem accountToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logInToolStripMenuItem;
        private System.Windows.Forms.DataGridView filmsDataGridView;
        private System.Windows.Forms.TabControl mainMenuTabControl;
        private System.Windows.Forms.TabPage filmsListTabPage;
        private System.Windows.Forms.TabPage genreGraphTabPage;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem actionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewFilmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.Label searchLabel;
        private System.Windows.Forms.ComboBox columnsComboBox;
        private System.Windows.Forms.Label columnLabel;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.DataVisualization.Charting.Chart filmGenresChart;
        private System.Windows.Forms.TabPage releaseYearGraphTabPage;
        private System.Windows.Forms.TabPage filmBudgetGraphTabPage;
        private System.Windows.Forms.DataVisualization.Charting.Chart releaseYearChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart budgetChart;
        private System.Windows.Forms.ToolStripMenuItem logOutToolStripMenuItem;
        private System.Windows.Forms.TabPage registeredUsersTabPage;
        private System.Windows.Forms.DataGridView usersDataGridView;
        private System.Windows.Forms.ToolStripMenuItem welcomeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAllUsersToolStripMenuItem;
        private System.Windows.Forms.Label currentUserLabel;
        private System.Windows.Forms.PictureBox weatherPictureBox;
        private System.Windows.Forms.Label weatherDescriptionLabel;
    }
}

