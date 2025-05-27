namespace VorodKhoroj.View;

public partial class FrmFilter : Form
{
    private readonly AppCoordinator _services;
    private readonly AttendanceFullCalculationService _calcServices;
    private readonly bool _justExcel;

    public FrmFilter(AppCoordinator service, AttendanceFullCalculationService calculationService, string fromDateTime, string toDateTime, string userid, bool justExcel = false)
    {
        InitializeComponent();

        _services = service;
        _calcServices = calculationService;

        FromDateTime_txtbox.Text = fromDateTime;
        toDateTime_txtbox.Text = toDateTime;
        Userid_txtbox.Text = userid;
        _justExcel = justExcel;
    }

    private void btn_applyFilter_Click(object sender, EventArgs e)
    {
        try
        {
            if (Userid_txtbox.Text == "0") throw new NullReferenceException("نام کاربری معتبر نمیباشد");

            using FrmCalc frm = new(_services, _calcServices, FromDateTime_txtbox.Text, toDateTime_txtbox.Text, CommonItems.GetUserIdValueToString(Userid_txtbox), _justExcel);
            frm.ShowDialog();
        }
        catch (Exception ex)
        {
            CommonHelper.ShowMessage(ex);
        }
    }

    private void btn_clear_Click(object sender, EventArgs e)
    {
        FromDateTime_txtbox.Text = Userid_txtbox.Text = "";
        toDateTime_txtbox.Text = PersianDateHelper.PersianCalenderDateNow();
    }

    private void FrmFilter_Load(object sender, EventArgs e)
    {
        Userid_txtbox.DataSource = _services.DataLoaderCoordinator.UsersList;

        if (_services is { DataLoaderCoordinator.UserListProvider: DbProvider })
        {
            CommonItems.SetDisplayAndValueMemberComboBox(ref Userid_txtbox);
        }
    }
}