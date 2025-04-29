namespace VorodKhoroj.View;

public partial class FrmFilter : Form
{
    private readonly AppServices _services;
    private readonly AttendanceCalculationService _calcServices;
    private readonly bool _justExcell;

    public FrmFilter(AppServices service, AttendanceCalculationService calculationService, string fromDateTime, string toDateTime, string userid, bool justExcell = false)
    {
        InitializeComponent();

        _services = service;
        _calcServices = calculationService;

        FromDateTime_txtbox.Text = fromDateTime;
        toDateTime_txtbox.Text = toDateTime;
        Userid_txtbox.Text = userid;
        _justExcell = justExcell;
    }

    private void btn_applyfilter_Click(object sender, EventArgs e)
    {
        try
        {
            using FrmCalc frm = new(_services, _calcServices, FromDateTime_txtbox.Text, toDateTime_txtbox.Text, Userid_txtbox.Text, _justExcell);
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
        Userid_txtbox.DataSource = _services.GetUsersFromFile();
    }
}