namespace VorodKhoroj.View;

/// <summary>
///     فرم فیلتر داده‌ها جهت نمایش گزارش ورود و خروج.
/// </summary>
public partial class FrmFilter : Form
{
    #region Fields

    /// <summary>
    ///     هماهنگ‌کننده اصلی برای دسترسی به داده‌ها و کاربران.
    /// </summary>
    private readonly AppServices _appCoordinator;

    /// <summary>
    ///     سرویس محاسبه کامل حضور و غیاب.
    /// </summary>
    private readonly AttendanceAnalyzer _calcServices;

    /// <summary>
    ///     مشخص می‌کند که فقط خروجی اکسل مورد نیاز
    /// </summary>
    private readonly FrmReport.XGridExport _exportType;

    #endregion

    #region Form Events

    /// <summary>
    ///     سازنده فرم فیلتر.
    /// </summary>
    public FrmFilter(AppServices service, AttendanceAnalyzer calculationService, string fromDateTime,
        string toDateTime, string userid, FrmReport.XGridExport exportType = FrmReport.XGridExport.None)
    {
        InitializeComponent();

        _appCoordinator = service;
        _calcServices = calculationService;

        FromDateTime_txtbox.Text = fromDateTime;
        toDateTime_txtbox.Text = toDateTime;
        Userid_txtbox.Text = userid;
        _exportType = exportType;
    }

    /// <summary>
    ///     رویداد کلیک دکمه اعمال فیلتر.
    /// </summary>
    private void btn_applyFilter_Click(object sender, EventArgs e)
    {
        try
        {
            if (Userid_txtbox.Text == "0")
                throw new NullReferenceException(" کاربری معتبر نمیباشد");

            ReportFrmConfig();
        }

        catch (Exception ex)
        {
            CommonHelper.ShowMessage(ex);
        }
    }


    /// <summary>
    ///     رویداد کلیک دکمه پاک‌سازی فیلدها.
    /// </summary>
    private void btn_clear_Click(object sender, EventArgs e)
    {
        FromDateTime_txtbox.Text = "";
        Userid_txtbox.Text = "";
        toDateTime_txtbox.Text = PersianDateHelper.PersianCalenderDateNow();
    }

    /// <summary>
    ///     رویداد لود فرم.
    /// </summary>
    private void FrmFilter_Load(object sender, EventArgs e)
    {
        Userid_txtbox.DataSource = _appCoordinator.DataLoaderCoordinator.UserList;

        if (_appCoordinator.DataLoaderCoordinator.ListProvider is DbProvider)
            CommonItems.SetDisplayAndValueMemberComboBox(ref Userid_txtbox);
    }

    #endregion

    /// <summary>
    ///     پیکربندی فرم گزارش
    /// </summary>
    private void ReportFrmConfig()
    {
        using FrmReport frm = new(
            _appCoordinator,
            _calcServices,
            FromDateTime_txtbox.Text,
            toDateTime_txtbox.Text,
            CommonItems.GetUserIdValueToString(Userid_txtbox));
        if (_exportType != FrmReport.XGridExport.None)
        {
            frm.Configure();
            frm.ExportToExcel(_exportType);
        }
        else
        {
            frm.ShowDialog();
        }
    }
}