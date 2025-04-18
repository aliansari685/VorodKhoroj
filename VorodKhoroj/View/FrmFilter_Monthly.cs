using VorodKhoroj.Helpers;

namespace VorodKhoroj.View
{
    public partial class FrmFilter_Monthly : Form
    {
        private readonly AppServices _services;
        private readonly AttendanceCalculationService _calcServices;
        private string _userId;

        public FrmFilter_Monthly(AppServices services, AttendanceCalculationService calcServices, string userId)
        {
            InitializeComponent();
            _services = services;
            _calcServices = calcServices;
            _userId = userId;
        }

        private void FrmFilter_Monthly_Load(object sender, EventArgs e)
        {
            userid_txtbox.DataSource = _services?.GetUsers();

        }
        private void btn_clear_Click(object sender, EventArgs e)
        {
            checkBox_esfand.Checked = checkBox_bahman.Checked = checkBox_dey.Checked = checkBox_azar.Checked = checkBox_aban.Checked = checkBox_mehr.Checked = checkBox_shahrivar.Checked = checkBox_mordad.Checked = checkBox_tir.Checked = checkBox_khordad.Checked = checkBox_ordibehesht.Checked = checkBox_farvardin.Checked = false;
        }

        private void Btn_CheckAll_Click(object sender, EventArgs e)
        {
            checkBox_esfand.Checked = checkBox_bahman.Checked = checkBox_dey.Checked = checkBox_azar.Checked = checkBox_aban.Checked = checkBox_mehr.Checked = checkBox_shahrivar.Checked = checkBox_mordad.Checked = checkBox_tir.Checked = checkBox_khordad.Checked = checkBox_ordibehesht.Checked = checkBox_farvardin.Checked = true;
        }

        private void Btn_submit_Click(object sender, EventArgs e)
        {
         //   try
            {
                _userId = userid_txtbox.Text;
                using (SaveFileDialog sfd = new() { Filter = @"Excel Files|*.xlsx", Title = @"ذخیره فایل اکسل" })
                {
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        var monthList = GetMonthlyCheckedList().Where(m => m.Value).Select(m => m.Key).ToList();
                        DataExporter.ExportAttendanceData(_userId, int.Parse(txtbox_year.Text), monthList,
                        checkBox_withlabels.Checked, sfd.FileName, _calcServices);
                        CommonHelper.ShowMessage("فایل اکسل شامل تمام ماه‌ها با موفقیت ذخیره شد!");
                    }
                }
            }
            //catch (Exception ex)
            //{
            //    CommonHelper.ShowMessage(ex);
            //}
        }

        private Dictionary<int, bool> GetMonthlyCheckedList()
        {
            return new()
            {
                { 1, checkBox_farvardin.Checked },
                { 2, checkBox_ordibehesht.Checked },
                { 3, checkBox_khordad.Checked },
                { 4, checkBox_tir.Checked },
                { 5, checkBox_mordad.Checked },
                { 6, checkBox_shahrivar.Checked },
                { 7, checkBox_mehr.Checked },
                { 8, checkBox_aban.Checked },
                { 9, checkBox_azar.Checked },
                { 10, checkBox_dey.Checked },
                { 11, checkBox_bahman.Checked },
                { 12, checkBox_esfand.Checked }
            };
        }
    }
}
