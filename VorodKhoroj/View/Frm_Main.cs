
namespace VorodKhoroj;

public partial class Frm_Main : Form
{
    private readonly AppServices _services;
    private readonly AttendanceCalculationService _calcServices;

    public Frm_Main(AppServices services, AttendanceCalculationService calculationService)
    {
        InitializeComponent();
        _services = services;
        _calcServices = calculationService;
    }

    private void Frm_Main_Load(object sender, EventArgs e)
    {
        TextBoxClear();
    }

    public void DataGridConfig()
    {
        if (_services?.Records == null) return;

        dataView.DataSource = _services.TempDataTable;
        DataGridViewConfig();
        Userid_txtbox.DataSource = _services?.GetUsers();

    }

    private void DataGridViewConfig()
    {
        dataView.Columns[1].DefaultCellStyle.Format = "yyyy/MM/dd HH:mm:ss";

        dataView.Columns[0].HeaderText = "کاربر";
        dataView.Columns[1].HeaderText = "تاریخ و زمان ورود و خروج";
        dataView.Columns[2].HeaderText = " نوع ورود";
    }

    private void Btn_ApplyFilter_Click(object sender, EventArgs e)
    {
        if (_services?.Records == null) return;

        try
        {
            dataView.DataSource = DataFilterService.ApplyFilter(_services.Records, FromDateTime_txtbox.Text,
                toDateTime_txtbox.Text, int.Parse(Userid_txtbox.Text)).ToList().ToDataTable();
            DataGridViewConfig();
        }
        catch (Exception ex)
        {
            CommonHelper.ShowMessage(ex);
        }
    }

    private void btn_clear_Click(object sender, EventArgs e)
    {
        TextBoxClear();
        DataGridConfig();
    }

    private void TextBoxClear()
    {
        FromDateTime_txtbox.Text = Userid_txtbox.Text = "";
        toDateTime_txtbox.Text = PersianDateHelper.PersianCalenderDateNow();
    }

    private void MajmoEkhtelafToolStripMenuItem_Click(object sender, EventArgs e) //Go To FrmFilter:
    {
        try
        {
            if (_services?.Records?.Count == 0) throw new ArgumentNullException("داده ای وجود ندارد");

            using (FrmFilter frm = new(_services, _calcServices, FromDateTime_txtbox.Text, toDateTime_txtbox.Text, Userid_txtbox.Text))
            {
                frm.ShowDialog();
            }
        }
        catch (Exception ex)
        {
            CommonHelper.ShowMessage(ex);
        }
    }

    public void dataView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
    {
        dataView.Rows[e.RowIndex].HeaderCell.Value = (e.RowIndex + 1).ToString();
    }


    private void DBConfigToolStripMenuItem_Click(object sender, EventArgs e)
    {
        try
        {
            if (dataView.Rows.Count == 0) throw new ArgumentNullException("داده ای وجود ندارد");

            using (FrmSetting frm = new(_services))
            {
                frm.ShowDialog();
            }
        }
        catch (Exception ex)
        {
            CommonHelper.ShowMessage(ex);
        }
    }

    private void SwitchDataSourceToolStripMenuItem_Click(object sender, EventArgs e)
    {
        try
        {
            using (FrmSetSource frm = new(_services))
            {
                frm.ShowDialog();
            }

            DataGridConfig();
        }
        catch (Exception ex)
        {
            CommonHelper.ShowMessage(ex);
        }
    }

    private void AppRestartToolStripMenuItem_Click(object sender, EventArgs e)
    {
        Application.Restart();
    }

    private void MonthlyReportToolStripMenuItem_Click(object sender, EventArgs e)
    {
        using (FrmFilter_Monthly frm = new(_services, _calcServices, Userid_txtbox.Text))
        {
            frm.ShowDialog();
        }
    }
    private void Frm_Main_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (MessageBox.Show(@"آیا می‌خواهید از برنامه خارج شوید؟", "خروج", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
        {
            e.Cancel = true;
        }
        else
        {
            _services?.Dispose();
        }
    }

}