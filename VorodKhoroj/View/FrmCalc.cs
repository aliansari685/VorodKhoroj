using VorodKhoroj.Data;

namespace VorodKhoroj.View;

public partial class FrmCalc : Form
{
    public string FromDateTime, toDateTime, userid;
    TimeSpan tm;
    private readonly AppServices _service;

    public FrmCalc(AppServices services)
    {
        _service = services;
        InitializeComponent();
    }

    private void FrmCalc_Load(object sender, EventArgs e)
    {
        lbl_FromTo.Text = @$"{FromDateTime} تا {toDateTime}";
        lbl_user.Text = userid;
        DataGridConfig();
    }

    private void DataGridConfig()
    {
        try
        {
            CalculatorData();
            DataGridViewConfig();
        }
        catch (Exception ex)
        {
            CommonHelper.ShowMessage(ex);
        }
    }

    private void CalculatorData()
    {
        var dataFiltered
            = DataFilterService.ApplyFilter(_service.Records, FromDateTime, toDateTime, int.Parse(userid));

        var groupedData = dataFiltered
            .GroupBy(x => (x.UserId, x.DateTime.Date))
            .Select(g =>
            {
                var minDateTime = g.Min(x => x.DateTime);
                var maxDateTime = g.Max(x => x.DateTime);
                var duration = maxDateTime - minDateTime;

                return new
                {
                    DayOfWeek = g.Key.Date.ToString("dddd"),
                    Date = g.Key.Date.ToString("yyyy/MM/dd"),
                    EntryTime = minDateTime.ToString("HH:mm:ss"),
                    ExitTime = maxDateTime.ToString("HH:mm:ss"),
                    DurationMin = duration.TotalMinutes,
                    DurationHour = $"{(int)duration.TotalHours}h {duration.Minutes}m",
                    IsLate = minDateTime.TimeOfDay > tm
                };
            })
            .ToList();

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


        // محاسبه مجموع دقایق کاری
        var totalMinutes = groupedData.Sum(x => x.DurationMin);
        lbl_summinute.Text = totalMinutes.ToString("0") + "m";

        // محاسبه مجموع ساعت کاری
        var totalHours = TimeSpan.FromMinutes(totalMinutes);
        lbl_sumhour.Text = @$"{(int)totalHours.TotalHours:D2}:{totalHours.Minutes:D2}:{totalHours.Seconds:D2}";

        // محاسبه تعداد روزهایی که ورود با تأخیر داشته‌اند)
        var lateDays = groupedData.Count(x => DateTime.Parse(x.EntryTime).TimeOfDay > tm);
        lbl_sumentryDelay.Text = lateDays.ToString();

        //مجموع غیبت
        lbl_sumOff.Text =
            CalculateAbsenceDays(DateTime.Parse(FromDateTime), DateTime.Parse(toDateTime), groupedData.Count)
                .ToString();

        //زودترین ورود
        var minEntryTime = TimeSpan.FromTicks(entryTimes.Min(t => t.Ticks));
        lbl_minEntry.Text = minEntryTime.ToString(@"hh\:mm\:ss");

        //میانگین ساعت کاری
        var avgMinutes = totalMinutes / groupedData.Count;
        var avgTimeSpan = TimeSpan.FromMinutes(avgMinutes);
        lbl_avgtimework.Text = @$"{(int)avgTimeSpan.TotalHours:D2}:{avgTimeSpan.Minutes:D2}:{avgTimeSpan.Seconds:D2}";

        dataView_calender.DataSource = groupedData.ToDataTable();
    }

    int CalculateAbsenceDays(DateTime startDate, DateTime endDate, int workDays)
    {
        var totalDays = (endDate - startDate).Days + 1;

        // شمارش تعداد جمعه‌ها در بازه
        var fridaysCount = Enumerable.Range(0, totalDays)
            .Select(i => startDate.AddDays(i))
            .Count(date => date.DayOfWeek == DayOfWeek.Friday);

        var totalCountedDays = workDays + fridaysCount;
        return (totalDays - totalCountedDays);

    }

    private void DataGridViewConfig()
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
        DataGridConfig();
    }

    private void dataView_calender_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
    {
        if (dataView_calender.Rows[e.RowIndex].Cells["IsLate"].Value is true)
            dataView_calender.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Red;

    }

    private void btn_exportExcel_Click(object sender, EventArgs e)
    {
        try
        {
            CommonHelper.DataGridToExcel(dataView_calender);
        }
        catch (Exception ex)
        {
            CommonHelper.ShowMessage(ex);
        }
    }
}