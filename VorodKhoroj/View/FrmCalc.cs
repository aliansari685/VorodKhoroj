namespace VorodKhoroj.View;

public partial class FrmCalc : Form
{
    //TabPage 0_VorodKhoroj:

    public Dictionary<string, string> Labels;

    private List<DateTime> _qeybathaDaysList = [];
    private List<DateTime> _holidaysDaysList;

    private readonly string _fromDateTime, _toDateTime, _userid;
    private TimeSpan _tm = new(08, 30, 00);
    private readonly AppServices _service;

    public FrmCalc(AppServices services, string fromDateTime, string toDateTime, string userid)
    {
        InitializeComponent();
        _service = services;
        _fromDateTime = fromDateTime;
        _toDateTime = toDateTime;
        _userid = userid;
    }

    private void FrmCalc_Load(object sender, EventArgs e)
    {
        lbl_FromTo.Text = @$"{_fromDateTime} تا {_toDateTime}";
        lbl_user.Text = _userid;
        DataGridConfig();
    }

    private void DataGridConfig()
    {
        try
        {
            Labels = new() {
        { "مجموع روز های کاری", lbl_sumdayworker.Text },
        { "مجموع روز کاری کامل طبق 8 ساعت 30 دقیقه کار", lbl_fullwork.Text },
        { "مجموع ساعات کاری", lbl_sumhour.Text },
        { "مجموع دقایق کاری", lbl_summinute.Text },
        { "مجموع روز های ورود باتاخیر", lbl_sumentryDelay.Text },
        { "مجموع روز های ناقص", lbl_nofull.Text },
        { "مجموع غیبت (غیر تعطیلات)", lbl_sumOff.Text },
        { "مجموع اضافه کاری", lbl_sumaddwork.Text },
        { "زودترین زمان ورود", lbl_minEntry.Text },
        { "دیرترین زمان خروج", lbl_MaxExitTime.Text },
        { "میانگین ساعت های ورود", lbl_avgentry.Text },
        { "میانگین ساعت های خروج", lbl_avgexit.Text },
        { "میانگین ساعت کاری روزانه", lbl_avgtimework.Text },

        };
            CalculatorData();
            DataGridViewConfig();

            Part2_Load();
        }
        catch (Exception ex)
        {
            CommonHelper.ShowMessage(ex);
            Close();
        }
    }

    public void CalculatorData()
    {
        var dataFiltered
            = DataFilterService.ApplyFilter(_service.Records, _fromDateTime, _toDateTime, int.Parse(_userid));
        if (dataFiltered.Count == 0) throw new ArgumentNullException($"داده ای وجود ندارد");

        var groupedData = dataFiltered
            .GroupBy(x => (x.UserId, x.DateTime.Date))
            .Select(g =>
            {
                var minDateTime = g.Min(x => x.DateTime);
                var maxDateTime = g.Max(x => x.DateTime);
                var duration = maxDateTime - minDateTime;
                TimeSpan? durationThursday = (minDateTime.DayOfWeek == DayOfWeek.Thursday && maxDateTime.DayOfWeek == DayOfWeek.Thursday)
                    ? maxDateTime - minDateTime : new TimeSpan(0);

                return new
                {
                    DayOfWeek = g.Key.Date.ToString("dddd"),
                    Date = g.Key.Date.ToString("yyyy/MM/dd"),
                    EntryTime = minDateTime.ToString("HH:mm:ss"),
                    ExitTime = maxDateTime.ToString("HH:mm:ss"),
                    DurationMin = (int)Math.Round(duration.TotalMinutes, 0),
                    DurationHour = $"{(int)duration.TotalHours}h {duration.Minutes}m",
                    IsLate = minDateTime.TimeOfDay > _tm,
                    FullWork = duration.TotalMinutes >= 510 || durationThursday.Value.TotalMinutes >= 330
                };
            })
            .ToList();

        // محاسبه مجموع ناقص
        var totalnofull = groupedData.Count(x => x.DurationMin < 30);
        lbl_nofull.Text = totalnofull.ToString();

        // محاسبه مجموع دقایق کاری
        var totalMinutes = groupedData.Sum(x => x.DurationMin);
        lbl_summinute.Text = totalMinutes.ToString("0") + @"m";

        // محاسبه میانگین ساعت ورود
        var entryTimes = groupedData
            .Select(x => TimeSpan.Parse(x.EntryTime))
            .ToList();
        var avgEntryTime = TimeSpan.FromTicks((long)entryTimes.Average(t => t.Ticks));
        lbl_avgentry.Text = avgEntryTime.ToString(@"hh\:mm\:ss");

        // محاسبه میانگین ساعت خروج
        var exitTimes = groupedData
            .Select(x => TimeSpan.Parse(x.ExitTime))
            .ToList();
        var avgExitTime = TimeSpan.FromTicks((long)exitTimes.Average(t => t.Ticks));
        lbl_avgexit.Text = avgExitTime.ToString(@"hh\:mm\:ss");

        // محاسبه مجموع روزهای کاری
        lbl_sumdayworker.Text = groupedData.Count.ToString();

        // محاسبه مجموع ساعت کاری
        var totalHours = TimeSpan.FromMinutes(totalMinutes);
        lbl_sumhour.Text = @$"{(int)totalHours.TotalHours:D2}:{totalHours.Minutes:D2}:{totalHours.Seconds:D2}";

        // محاسبه مجموع روز کامل
        var total = groupedData.Count(x => x.FullWork);
        lbl_fullwork.Text = total.ToString();

        // محاسبه تعداد روزهایی که ورود با تأخیر داشته‌اند)
        var lateDays = groupedData.Count(x => DateTime.Parse(x.EntryTime).TimeOfDay > _tm);
        lbl_sumentryDelay.Text = lateDays.ToString();

        //مجموع غیبت
        var holidays = PersianDateHelper.GetHolidays().Select(h => h.Date.Date).ToList(); // تاریخ تعطیلات

        // تولید لیست تاریخ‌های بین دو بازه
        var workDays = Enumerable.Range(0, (DateTime.Parse(_toDateTime) - DateTime.Parse(_fromDateTime)).Days + 1)
            .Select(i => DateTime.Parse(_fromDateTime).AddDays(i))
            .ToList(); // تمامی روزها از `_fromDateTime` تا `_toDateTime`

        var presentDays = groupedData
            .Select(g => DateTime.ParseExact(g.Date, "yyyy/MM/dd", null).Date)
            .ToList(); // تاریخ‌هایی که کارمند حضور داشته است

        // محاسبه تعداد روزهای غیبت (روز کاری باشد، حضور نداشته باشد، تعطیل رسمی هم نباشد)
        var absence = workDays.Where(day => !presentDays.Contains(day) && !holidays.Contains(day));

        var absenceCount = absence.Count();
        lbl_sumOff.Text = absenceCount.ToString();

        _qeybathaDaysList = absence.ToList();

        _holidaysDaysList = workDays.Where(day => holidays.Contains(day)).ToList();

        //اضافه کاری
        var overtimeCount = presentDays.Count(day => holidays.Contains(day));
        lbl_sumaddwork.Text = overtimeCount.ToString();

        //زودترین ورود
        var minEntryTime = TimeSpan.FromTicks(entryTimes.Min(t => t.Ticks));
        lbl_minEntry.Text = minEntryTime.ToString(@"hh\:mm\:ss");

        //دیرترین خروج
        var maxExitTime = TimeSpan.FromTicks(exitTimes.Max(t => t.Ticks));
        lbl_MaxExitTime.Text = maxExitTime.ToString(@"hh\:mm\:ss");

        //میانگین ساعت کاری
        var avgMinutes = totalMinutes / groupedData.Count;
        var avgTimeSpan = TimeSpan.FromMinutes(avgMinutes);
        lbl_avgtimework.Text = @$"{(int)avgTimeSpan.TotalHours:D2}:{avgTimeSpan.Minutes:D2}:{avgTimeSpan.Seconds:D2}";

        dataView_calender.DataSource = groupedData.ToDataTable();
    }

    private void DataGridViewConfig()
    {
        dataView_calender.Columns[0].HeaderText = @"روز در هفته";
        dataView_calender.Columns[1].HeaderText = @"تاریخ";
        dataView_calender.Columns[2].HeaderText = @"ساعت ورود";
        dataView_calender.Columns[3].HeaderText = @"ساعت خروج";
        dataView_calender.Columns[4].HeaderText = @"اختلاف به دقیقه";
        dataView_calender.Columns[5].HeaderText = @"اختلاف به ساعت";
        dataView_calender.Columns[6].HeaderText = @"ورود با تاخیر";
        dataView_calender.Columns[7].HeaderText = @" روز کاری کامل طبق 8 ساعت 30 دقیقه کار";
    }

    private void dataView_calender_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
    {
        var data = (DataGridView)sender;

        data.Rows[e.RowIndex].HeaderCell.Value = (e.RowIndex + 1).ToString();
    }

    private void btn_Submit_Click(object sender, EventArgs e)
    {
        _tm = TimeSpan.Parse(txtbox_lade.Text);
        DataGridConfig();
    }

    private void dataView_calender_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
    {
        if (dataView_calender.Rows[e.RowIndex].Cells["IsLate"].Value is true)
            dataView_calender.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Red;
    }

    private void OutputExcelToolStripMenuItem_Click(object sender, EventArgs e)
    {
        try
        {
            CommonHelper.DataGridToExcel(dataView_calender, Labels);
        }
        catch (Exception ex)
        {
            CommonHelper.ShowMessage(ex);
        }
    }
}