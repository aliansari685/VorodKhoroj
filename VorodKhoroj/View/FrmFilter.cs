﻿namespace VorodKhoroj.View;

/// <summary>
/// فرم فیلتر داده‌ها جهت نمایش گزارش ورود و خروج.
/// </summary>
public partial class FrmFilter : Form
{
    #region Fields

    /// <summary>
    /// هماهنگ‌کننده اصلی برای دسترسی به داده‌ها و کاربران.
    /// </summary>
    private readonly MainCoordinator _appCoordinator;

    /// <summary>
    /// سرویس محاسبه کامل حضور و غیاب.
    /// </summary>
    private readonly AttendanceFullCalculationService _calcServices;

    /// <summary>
    /// مشخص می‌کند که فقط خروجی اکسل مورد نیاز است یا خیر.
    /// </summary>
    private readonly bool _justExcel;

    #endregion

    #region Form Events

    /// <summary>
    /// سازنده فرم فیلتر.
    /// </summary>
    public FrmFilter(MainCoordinator service, AttendanceFullCalculationService calculationService, string fromDateTime, string toDateTime, string userid, bool justExcel = false)
    {
        InitializeComponent();

        _appCoordinator = service;
        _calcServices = calculationService;

        FromDateTime_txtbox.Text = fromDateTime;
        toDateTime_txtbox.Text = toDateTime;
        Userid_txtbox.Text = userid;
        _justExcel = justExcel;
    }

    /// <summary>
    /// رویداد کلیک دکمه اعمال فیلتر.
    /// </summary>
    private void btn_applyFilter_Click(object sender, EventArgs e)
    {
        try
        {
            if (Userid_txtbox.Text == "0")
                throw new NullReferenceException("نام کاربری معتبر نمیباشد");

            using FrmCalc frm = new(
                _appCoordinator,
                _calcServices,
                FromDateTime_txtbox.Text,
                toDateTime_txtbox.Text,
                CommonItems.GetUserIdValueToString(Userid_txtbox),
                _justExcel
            );
            frm.ShowDialog();
        }
        catch (Exception ex)
        {
            CommonHelper.ShowMessage(ex);
        }
    }

    /// <summary>
    /// رویداد کلیک دکمه پاک‌سازی فیلدها.
    /// </summary>
    private void btn_clear_Click(object sender, EventArgs e)
    {
        FromDateTime_txtbox.Text = "";
        Userid_txtbox.Text = "";
        toDateTime_txtbox.Text = PersianDateHelper.PersianCalenderDateNow();
    }

    /// <summary>
    /// رویداد لود فرم.
    /// </summary>
    private void FrmFilter_Load(object sender, EventArgs e)
    {
        Userid_txtbox.DataSource = _appCoordinator.UsersList;

        if (_appCoordinator is { UsersListProvider: DbProvider })
        {
            CommonItems.SetDisplayAndValueMemberComboBox(ref Userid_txtbox);
        }
    }

    #endregion
}
