using Serilog;
using System.Data;
using System.Globalization;

namespace VorodKhoroj
{
    public partial class Frm_Main : Form
    {
        public OpenFileDialog OpenFile { get; set; }
        public DataTable table = new DataTable();
        public string FileAddress;

        enum LoginType
        {
            Face = 15, Finger = 1
        }
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void بازکردنفایلToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFile = new OpenFileDialog
            {
                Filter = @"Output Files|*.txt;*.dat;*"
            };
            try
            {
                if (OpenFile.ShowDialog() == DialogResult.OK)
                {
                    FileAddress = OpenFile.FileName;
                    LoadDataSource();
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadDataSource()
        {
            try
            {
                // تعریف ستون‌ها
                table.Columns.Add("User", typeof(int));
                table.Columns.Add("DateTime", typeof(string));
                table.Columns.Add("Col3", typeof(int));
                table.Columns.Add("Col4", typeof(int));
                table.Columns.Add("LoginType", typeof(string));
                table.Columns.Add("Col6", typeof(int));

                // خواندن و پردازش فایل
                foreach (var line in File.ReadAllLines(FileAddress))
                {
                    var values = line.Split('\t'); // جدا کردن با TAB
                    if (values.Length == 6)
                    {
                        table.Rows.Add(
                            int.Parse(values[0]),
                            ConvertToShamsi(values[1]),
                            int.Parse(values[2]),
                            int.Parse(values[3]),
                            ConvertToLoginType(values[4]),
                            int.Parse(values[5])
                        );
                    }
                }

                dataGridView1.DataSource = table;
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                MessageBox.Show(ex.Message);
            }
        }

        public string ConvertToShamsi(string inputDateTime)
        {
            var persianCulture = new CultureInfo("fa-IR")
            {
                DateTimeFormat =
                {
                    Calendar = new PersianCalendar()
                }
            };
            Thread.CurrentThread.CurrentCulture = persianCulture;
            Thread.CurrentThread.CurrentUICulture = persianCulture;
            var dateTime = DateTime.Parse(inputDateTime, CultureInfo.InvariantCulture);
            var persianCalendar = new PersianCalendar();

            // تبدیل تاریخ میلادی به شمسی
            int year = persianCalendar.GetYear(dateTime);
            int month = persianCalendar.GetMonth(dateTime);
            int day = persianCalendar.GetDayOfMonth(dateTime);

            // فرمت نهایی
            string formattedDate = $"{year}/{month:D2}/{day:D2}"; // D2 برای دو رقمی شدن ماه و روز
            string time = dateTime.ToString("HH:mm:ss"); // ساعت بدون تغییر

            return $"{formattedDate} {time}";
        }

        string ConvertToLoginType(string number)
        {
            int num = int.Parse(number);
            return ((LoginType)num).ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void btn_applyfilter_Click(object sender, EventArgs e)
        {
            ApplyFromDateFilter();
        }
        private void ApplyFromDateFilter()
        {
            if (string.IsNullOrEmpty(FromDateTime_txtbox.Text)) return; // اگر مقدار وارد نشده، هیچی انجام نده

            var fromDate = FromDateTime_txtbox.Text; // مقدار فیلد ورودی
            using (var dv = new DataView(table))
            {
                try
                {
                    dv.RowFilter = $"DateTime >= '{fromDate}'"; // اعمال فیلتر
                    dataGridView1.DataSource = dv; // نمایش داده‌های فیلتر `شده
                }
                catch (Exception ex)
                {
                    MessageBox.Show("خطا در فیلتر کردن داده‌ها: " + ex.Message);
                }
            }
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = table;
        }
    }
}
