namespace VorodKhoroj.Classes;

public class PersianDateHelper
{
    // تاریخ کنونی با تنظیم فرهنگ و کالندر فارسی (نام متغیر تغییر داده شود بهتر است)
    public static DateTime DateTime = ConfigDateTime();
    public static readonly PersianCalendar PersianCalendar = new();

    // خواندن روزهای رمضان از فایل اکسل و تبدیل به لیست EventDay
    public static List<EventDay> GetRamadanDays()
    {
        var list = new List<EventDay>();
        var excelPath = System.Windows.Forms.Application.StartupPath + @"Resources\ramadan.xlsx";
        using var package = new ExcelPackage(new FileInfo(excelPath));
        var worksheet = package.Workbook.Worksheets[0]; // اولین شیت
        var rowCount = worksheet.Dimension.Rows; // تعداد سطرها
        for (var row = 2; row <= rowCount; row++) // از ردیف 2 (بعد از هدر)
        {
            var title = worksheet.Cells[row, 1].Text; // ستون عنوان
            var dateString = worksheet.Cells[row, 2].Text; // ستون تاریخ
            if (DateTime.TryParse(dateString, out var date))
                list.Add(new EventDay { Title = title, Date = date });
            else
                throw new Exception($"خطا در تبدیل تاریخ برای سطر {row}");
        }
        return list;
    }

    // خواندن تعطیلات از فایل اکسل و افزودن تعطیلات جمعه و نوروز به لیست
    public static List<EventDay> GetHolidays()
    {
        var farvardinHolidays = new List<int> { 1, 2, 3, 4, 12, 13 };
        var list = new List<EventDay>();
        var excelPath = System.Windows.Forms.Application.StartupPath + @"Resources\holiday.xlsx";
        using (var package = new ExcelPackage(new FileInfo(excelPath)))
        {
            var worksheet = package.Workbook.Worksheets[0];
            var rowCount = worksheet.Dimension.Rows;
            for (var row = 2; row <= rowCount; row++)
            {
                var title = worksheet.Cells[row, 1].Text;
                var dateString = worksheet.Cells[row, 2].Text;
                if (DateTime.TryParse(dateString, out var date))
                    list.Add(new EventDay { Title = title, Date = date });
                else
                    throw new Exception($"خطا در تبدیل تاریخ برای سطر {row}");
            }
        }

        // افزودن جمعه‌ها و تعطیلات فروردین به لیست
        for (var dt = DateTime.Parse("1400/01/01"); dt <= DateTime.Now; dt = dt.AddDays(1))
        {
            if (dt.DayOfWeek == DayOfWeek.Friday)
                list.Add(new EventDay { Title = "جمعه", Date = dt });

            if (PersianCalendar.GetMonth(dt) == 1 && farvardinHolidays.Contains(PersianCalendar.GetDayOfMonth(dt)))
                list.Add(new EventDay { Title = "نوروز", Date = dt });
        }
        return list;
    }

    // گرفتن لیست روزهای مشخص فروردین 1400 تا امروز
    public static List<DateTime> GetWorkDays_Farvardin()
    {
        var farvardinDays = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };
        var list = new List<DateTime>();
        for (var dt = DateTime.Parse("1400/01/01"); dt <= DateTime.Now; dt = dt.AddDays(1))
            if (PersianCalendar.GetMonth(dt) == 1 && farvardinDays.Contains(PersianCalendar.GetDayOfMonth(dt)))
                list.Add(dt.Date);

        return list;
    }

    /// <summary>
    /// گرفتن تاریخ امروز به صورت رشته شمسی yyyy/MM/dd
    /// </summary>
    /// <returns></returns>
    public static string PersianCalenderDateNow()
    {
        var year = PersianCalendar.GetYear(DateTime);
        var month = PersianCalendar.GetMonth(DateTime);
        var day = PersianCalendar.GetDayOfMonth(DateTime);
        return $"{year}/{month:D2}/{day:D2}";
    }

    // تبدیل رشته تاریخ میلادی به DateTime شمسی با ساعت و دقیقه و ثانیه
    public static DateTime ConvertToShamsi(string inputDateTime)
    {
        var dateTime = ConfigDateTime(inputDateTime);
        var year = PersianCalendar.GetYear(dateTime);
        var month = PersianCalendar.GetMonth(dateTime);
        var day = PersianCalendar.GetDayOfMonth(dateTime);
        return new DateTime(year, month, day, dateTime.Hour, dateTime.Minute, dateTime.Second, PersianCalendar);
    }

    // تبدیل DateTime به رشته تاریخ و زمان شمسی با فرمت yyyy/MM/dd HH:mm:ss
    public static string ConvertToShamsiString(DateTime dateTime)
    {
        return $"{PersianCalendar.GetYear(dateTime)}/{PersianCalendar.GetMonth(dateTime):D2}/{PersianCalendar.GetDayOfMonth(dateTime):D2} {dateTime:HH:mm:ss}";
    }

    // تنظیم فرهنگ فارسی و کالندر شمسی و پارس کردن رشته تاریخ ورودی
    private static DateTime ConfigDateTime(string inputDateTime)
    {
        var persianCulture = new CultureInfo("fa-IR");
        persianCulture.DateTimeFormat.Calendar = new PersianCalendar();
        Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture = persianCulture;
        return DateTime.Parse(inputDateTime, CultureInfo.InvariantCulture);
    }

    // تنظیم فرهنگ فارسی و کالندر شمسی و گرفتن تاریخ امروز به صورت DateTime
    private static DateTime ConfigDateTime()
    {
        var persianCulture = new CultureInfo("fa-IR");
        persianCulture.DateTimeFormat.Calendar = new PersianCalendar();
        Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture = persianCulture;
        return DateTime.Parse(DateTime.Now.ToShortDateString(), CultureInfo.DefaultThreadCurrentCulture);
    }
}
