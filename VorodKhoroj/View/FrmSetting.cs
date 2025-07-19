namespace VorodKhoroj.View;

/// <summary>
/// فرم تنظیمات دیتابیس برای تست اتصال و ایجاد دیتابیس جدید.
/// </summary>
public partial class FrmSetting : Form
{
    /// <summary>
    /// آیا اتصال به سرور پایگاه داده با موفقیت تست شده است؟
    /// </summary>
    private bool _isDbConnectionTested;

    /// <summary>
    /// هماهنگ‌کننده اصلی برنامه 
    /// </summary>
    private readonly AppServices _appCoordinator;

    /// <summary>
    /// آیتم‌های مشترک فرم
    /// </summary>
    private readonly CommonItems _cm = new();

    /// <summary>
    /// سازنده فرم تنظیمات.
    /// </summary>
    /// <param name="appServices">هماهنگ‌کننده برنامه</param>
    public FrmSetting(AppServices appServices)
    {
        InitializeComponent();
        _appCoordinator = appServices;
    }

    #region Events

    /// <summary>
    /// رویداد لود فرم؛ بارگذاری لیست سرورها و تنظیمات منوی راست کلیک.
    /// </summary>
    private void FrmSetting_Load(object sender, EventArgs e)
    {
        _cm.LoadServerListFromFile(ref txt_ServerName);
        _cm.ItemClicked += (_, _) => _cm.LoadServerListFromFile(ref txt_ServerName);
        txt_ServerName.ContextMenuStrip = _cm.MenuStrip;
    }

    /// <summary>
    /// رویداد کلیک روی دکمه تست اتصال به پایگاه داده.
    /// </summary>
    private void Btn_testDb_Click(object sender, EventArgs e)
    {
        try
        {
            _appCoordinator.DbContextConfiguration.InitializeDbContextMaster(txt_ServerName.Text);

            if (_appCoordinator.DataBaseInitializerCoordinator.TestServerName(txt_ServerName.Text) == false)
            {
                throw new NullReferenceException("ارتباط برقرار نشد");
            }

            _isDbConnectionTested = true;
            CommonHelper.ShowMessage("اتصال با موفقیت انجام شد");
        }
        catch (Exception ex)
        {
            CommonHelper.ShowMessage(ex);
        }
    }

    /// <summary>
    /// نمایش منوی راست‌کلیک لیست سرورها هنگام کلیک راست روی TextBox.
    /// </summary>
    private void txt_ServerName_MouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Right)
        {
            _cm.Text = txt_ServerName.Text;
            _cm.MenuStrip.Show(Cursor.Position);
        }
    }

    /// <summary>
    /// رویداد کلیک روی دکمه ایجاد دیتابیس جدید و انتقال داده‌ها.
    /// </summary>
    private async void btn_CreateDatabase_Click(object sender, EventArgs e)
    {
        try
        {
            if (!_isDbConnectionTested)
                throw new Exception("نام سرور پایگاه داده معتبر نیست، لطفا ابتدا تست اتصال را انجام دهید.");

            using var saveFile = CommonItems.CreateSaveFileDialog("DB Files|*.mdf");
            if (saveFile.ShowDialog() != DialogResult.OK)
                return;

            using var frmProgress = new FrmProgressDialog();
            frmProgress.Show(this);
            Enabled = false;

            await CreateDatabaseAsync(saveFile.FileName, txt_ServerName.Text);

            CommonHelper.ShowMessage("دیتابیس با موفقیت ایجاد و داده‌ها منتقل شدند!");

            frmProgress.Close();
        }
        catch (Exception ex)
        {
            CommonHelper.ShowMessage(ex);
        }
        finally
        {
            Enabled = true;
        }
    }
    #endregion

    #region Core Logic

    /// <summary>
    /// عملیات ایجاد دیتابیس جدید، جدول‌ها و انتقال داده‌ها.
    /// </summary>
    /// <param name="dbFilePath">مسیر فایل دیتابیس</param>
    /// <param name="serverName">نام سرور</param>
    private Task CreateDatabaseAsync(string dbFilePath, string serverName)
    {
        return Task.Run(() =>
        {
            _appCoordinator.DataBaseInitializerCoordinator.SetDbName(dbFilePath);
            _appCoordinator.DataBaseInitializerCoordinator.SetDbPath(dbFilePath);
            _appCoordinator.DataBaseInitializerCoordinator.CreateDatabase();
            _appCoordinator.DbContextConfiguration.InitializeDbContext(serverName, _appCoordinator.DataBaseInitializerCoordinator.DbPathName, _appCoordinator.DataBaseInitializerCoordinator.DbName, Enums.DataBaseLocation.InternalDataBase);
            _appCoordinator.DataBaseInitializerCoordinator.CreateTables();
            _appCoordinator.AttendanceDataService.CopyRecords(_appCoordinator.DataLoaderCoordinator.AttendancesRecords);
            _appCoordinator.DataBaseInitializerCoordinator.DetachDatabase();
        });
    }

    #endregion
}