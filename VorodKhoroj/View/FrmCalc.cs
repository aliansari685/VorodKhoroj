namespace VorodKhoroj.View
{
    public partial class FrmCalc : Form
    {
        private List<Structure> dataList = new();
        public string FromDateTime, toDateTime, userid;
        public TimeSpan tm;
        public FrmCalc()
        {
            InitializeComponent();
        }

        private void FrmCalc_Load(object sender, EventArgs e)
        {
            lbl_FromTo.Text = @$"{FromDateTime} تا {toDateTime}";
            FillDataGrid();
        }

        private void FillDataGrid()
        {
            try
            {
                LoadData();
                DataGridConfig();
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                MessageBox.Show(ex.Message);
            }
        }

        void LoadData()
        {
            dataList = DataManager.ApplyFilter(FromDateTime, toDateTime, int.Parse(userid));

            var groupedData = dataList
                .GroupBy(x => new { x.UserId, x.DateTime.Date })
                .Select(g => new
                {
                    DayOfWeek = g.Key.Date.ToString("ddddd"),
                    Date = g.Key.Date.ToString("yyyy/MM/dd"),
                    EntryTime = g.Min(x => x.DateTime).ToString("HH:mm:ss"),
                    ExitTime = g.Max(x => x.DateTime).ToString("HH:mm:ss"),
                    DurationMin = (g.Max(x => x.DateTime) - g.Min(x => x.DateTime)).TotalMinutes,
                    DurationHour = $"{(int)(g.Max(x => x.DateTime) - g.Min(x => x.DateTime)).TotalHours}h " + $"{(g.Max(x => x.DateTime) - g.Min(x => x.DateTime)).Minutes}m",
                    IsLate = TimeSpan.Parse(g.Min(x => x.DateTime).ToString("HH:mm:ss")) > tm
                })
                .ToList();


            var entryTimes = groupedData
                .Select(x => TimeSpan.Parse(x.EntryTime))
                .ToList();


            var exitTimes = groupedData
                .Select(x => TimeSpan.Parse(x.ExitTime))
                .ToList();

            // محاسبه میانگین ساعت ورود
            TimeSpan avgEntryTime = TimeSpan.FromTicks((long)entryTimes.Average(t => t.Ticks));
            lbl_avgentry.Text = avgEntryTime.ToString(@"hh\:mm\:ss");

            // محاسبه میانگین ساعت خروج
            TimeSpan avgExitTime = TimeSpan.FromTicks((long)exitTimes.Average(t => t.Ticks));
            lbl_avgexit.Text = avgExitTime.ToString(@"hh\:mm\:ss");


            // محاسبه مجموع روزهای کاری
            lbl_sumdayworker.Text = groupedData.Count.ToString();


            // محاسبه مجموع دقایق کاری
            double totalMinutes = groupedData.Sum(x => x.DurationMin);
            lbl_summinute.Text = totalMinutes.ToString("0") + "m";

            // محاسبه مجموع ساعت کاری
            TimeSpan totalHours = TimeSpan.FromMinutes(totalMinutes);
            lbl_sumhour.Text = @$"{(int)totalHours.TotalHours:D2}:{totalHours.Minutes:D2}:{totalHours.Seconds:D2}";

            // محاسبه تعداد روزهایی که ورود با تأخیر داشته‌اند)
            int lateDays = groupedData.Count(x => DateTime.Parse(x.EntryTime).TimeOfDay > tm);
            lbl_sumentryDelay.Text = lateDays.ToString();

            //مجموع غیبت
            lbl_sumOff.Text = CalculateAbsenceDays(DateTime.Parse(FromDateTime), DateTime.Parse(toDateTime), groupedData.Count).ToString();

            //زودترین ورود
            TimeSpan minEntryTime = TimeSpan.FromTicks((long)entryTimes.Min(t => t.Ticks));
            lbl_minEntry.Text = minEntryTime.ToString(@"hh\:mm\:ss");

            //میانگین ساعت کاری
            var avgMinutes = totalMinutes / groupedData.Count;
            TimeSpan avgTimeSpan = TimeSpan.FromMinutes(avgMinutes);
            lbl_avgtimework.Text = @$"{(int)avgTimeSpan.TotalHours:D2}:{avgTimeSpan.Minutes:D2}:{avgTimeSpan.Seconds:D2}";

            lbl_user.Text = userid;
            dataView_calender.DataSource = groupedData;

        }

        public int CalculateAbsenceDays(DateTime startDate, DateTime endDate, int workDays)
        {
            // تعداد کل روزهای بین دو تاریخ
            int totalDays = (endDate - startDate).Days + 1;

            // شمارش تعداد جمعه‌ها در بازه
            int fridaysCount = Enumerable.Range(0, totalDays)
                .Select(i => startDate.AddDays(i))
                .Count(date => date.DayOfWeek == DayOfWeek.Friday);

            // تعداد روزهایی که حضور داشتی + جمعه‌ها
            int totalCountedDays = workDays + fridaysCount;

            // محاسبه تعداد روزهای غیبت
            int absenceDays = totalDays - totalCountedDays;

            return absenceDays;
        }

        private void DataGridConfig()
        {
            dataView_calender.Columns[0].HeaderText = "روز در هفته";
            dataView_calender.Columns[1].HeaderText = "تاریخ";
            dataView_calender.Columns[2].HeaderText = "ساعت ورود";
            dataView_calender.Columns[3].HeaderText = "ساعت خروج";
            dataView_calender.Columns[4].HeaderText = "اختلاف به دقیقه";
            dataView_calender.Columns[5].HeaderText = "اختلاف به ساعت";
            dataView_calender.Columns[6].HeaderText = "ورود با تاخیر";
        }

        private void dataView_calender_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dataView_calender.Rows[e.RowIndex].HeaderCell.Value = (e.RowIndex + 1).ToString();
        }

        private void btn_Submit_Click(object sender, EventArgs e)
        {
            tm = TimeSpan.Parse(txtbox_lade.Text);
            LoadData();
        }

        private void dataView_calender_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (dataView_calender.Rows[e.RowIndex].Cells["IsLate"].Value is true)
            {
                dataView_calender.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Red;
            }
            //else
            //{
            //    dataView_calender.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
            //}
        }
    }
}
