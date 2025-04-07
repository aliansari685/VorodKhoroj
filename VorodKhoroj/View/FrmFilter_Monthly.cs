using System.Collections;
using System.Windows.Forms;

namespace VorodKhoroj.View
{
    public partial class FrmFilter_Monthly : Form
    {
        private readonly AppServices _services;
        private readonly AttendanceCalculationService _calcServices;
        private string _userId;

        public Dictionary<int, bool> MonthlyCheckedList = [];

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
            _userId = userid_txtbox.Text;
            MonthlyCheckedList = new Dictionary<int, bool>
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

            SaveFileDialog sfd = new() { Filter = "Excel Files|*.xlsx", Title = "ذخیره فایل اکسل" };
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {

                    NewMethod();
                }
            }
        }

        private void NewMethod()
        {
            DataGridView dg = new DataGridView();
            List<int> list = [];

            foreach (var _month in MonthlyCheckedList)
                if (_month.Value == true)
                    list.Add(_month.Key);

            int year = int.Parse(txtbox_year.Text);

            foreach (var month in list)
            {   
                int last = PersianDateHelper.PersianCalendar.GetDaysInMonth(year, month);

                var start = $"{year}/{month:D2}/{01}";

                var end = $"{year}/{month:D2}/{last:D2}";

                var filtered = DataFilterService.ApplyFilter(_services.Records, start, end, int.Parse(_userId)).ToList();

                dg.DataSource = filtered;

                try
                {
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                    using (SaveFileDialog sfd = new() { Filter = "Excel Files|*.xlsx", Title = "ذخیره فایل اکسل" })
                    {
                        if (sfd.ShowDialog() == DialogResult.OK)
                        {
                            using (ExcelPackage package = new())
                            {
                                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Data");

                                int currentRow = 1;
                                int currentColumn = 1; // شروع از ستون اول

                                // 2️⃣ افزودن عنوان ستون‌های DataGridView
                                for (int i = 0; i < dataGridView.Columns.Count; i++)
                                {
                                    worksheet.Cells[currentRow, i + 1].Value = dataGridView.Columns[i].HeaderText;
                                }

                                // 3️⃣ افزودن داده‌های DataGridView
                                for (int i = 0; i < dataGridView.Rows.Count; i++)
                                {
                                    for (int j = 0; j < dataGridView.Columns.Count; j++)
                                    {
                                        worksheet.Cells[currentRow + i + 1, j + 1].Value =
                                            dataGridView.Rows[i].Cells[j].Value?.ToString();
                                    }
                                }
                                int lastDataRow = currentRow + dataGridView.Rows.Count + 2;

                                foreach (var label in labels)
                                {
                                    worksheet.Cells[lastDataRow, currentColumn].Value = label.Key;   // عنوان لیبل
                                    worksheet.Cells[lastDataRow + 1, currentColumn].Value = label.Value; // مقدار لیبل در ردیف دوم
                                    currentColumn++; // رفتن به ستون بعدی
                                }
                                // ذخیره فایل
                                File.WriteAllBytes(sfd.FileName, package.GetAsByteArray());
                                CommonHelper.ShowMessage("فایل اکسل با موفقیت ذخیره شد!");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    CommonHelper.ShowMessage(ex);
                }
            }

        }

        public void GetStartAndEndOfMonth(int month, string _year)
        {




        }

    }
}
