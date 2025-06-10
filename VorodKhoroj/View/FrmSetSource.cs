namespace VorodKhoroj.View
{
    /// <summary>
    /// فرم انتخاب منبع داده ها
    /// </summary>
    public partial class FrmSetSource : Form
    {
        private readonly MainCoordinator _appCoordinator;
        private readonly CommonItems _cm = new();

        public FrmSetSource(MainCoordinator mainCoordinator)
        {
            InitializeComponent();
            _appCoordinator = mainCoordinator;
        }

        #region Events
        private void FrmSetSource_Load(object sender, EventArgs e) => SetupServerNameTextBox();

        private void btn_submit_Click(object sender, EventArgs e)
        {
            try
            {
                if (radiobtn_textfile.Checked)
                    HandleTextFileSource();

                if (radiobtn_database.Checked)
                    HandleDatabaseSource();
            }
            catch (Exception ex)
            {
                CommonHelper.ShowMessage(ex);
            }
        }

        private void radioBtn_database_CheckedChanged(object sender, EventArgs e) => txt_ServerName.Enabled = radiobtn_database.Checked;

        private void txt_ServerName_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                _cm.Text = txt_ServerName.Text;
                _cm.MenuStrip.Show(Cursor.Position);
            }
        }
        #endregion

        #region Core Logic

        /// <summary>
        /// تنظیمات اولیه TextBox سرور برای context menu و فعال بودن
        /// </summary>
        private void SetupServerNameTextBox()
        {
            txt_ServerName.Enabled = radiobtn_database.Checked;
            _cm.LoadServerListFromFile(ref txt_ServerName);
            _cm.ItemClicked += (_, _) => _cm.LoadServerListFromFile(ref txt_ServerName);
            txt_ServerName.ContextMenuStrip = _cm.MenuStrip;
        }

        /// <summary>
        /// پردازش فایل متنی به عنوان منبع داده
        /// </summary>
        private void HandleTextFileSource()
        {
            using var openFile = CommonItems.CreateOpenFileDialog("Output Files|*.txt;*.dat;");
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                _appCoordinator.LoadRecordsFromFile(openFile.FileName);

                CommonHelper.ShowMessage("با موفقیت بارگذاری شد");
                Close();
            }
        }

        /// <summary>
        /// پردازش پایگاه داده به عنوان منبع داده
        /// </summary>
        private void HandleDatabaseSource()
        {
            if (_appCoordinator is { UsersListProvider: DbProvider })
                throw new InvalidOperationException("لطفا ارتباط قبلی را قطع کنید (با استفاده از راه‌اندازی مجدد)");

            if (!CommonHelper.IsValid(txt_ServerName.Text))
                throw new ArgumentNullException($"خطا در نام سرور پایگاه داده");

            _appCoordinator.InitializeDbContextMaster(txt_ServerName.Text);

            if (!_appCoordinator.TestServerName(txt_ServerName.Text))
                throw new ArgumentNullException($"خطا در نام سرور پایگاه داده");

            using var openFile = CommonItems.CreateOpenFileDialog("DB Files|*.mdf");
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                string dbPath = openFile.FileName;

                _appCoordinator.SetDbPath(dbPath);
                _appCoordinator.SetDbName(dbPath);
                _appCoordinator.InitializeDbContext(txt_ServerName.Text, AppDbContext.DataBaseLocation.AttachDbFilename);
                _appCoordinator.MigrationsEnsureDatabaseUpToDate();
                _appCoordinator.LoadRecordsFromDb();

                CommonHelper.ShowMessage("با موفقیت بارگذاری شد");
                Close();
            }
        }
        #endregion
    }
}