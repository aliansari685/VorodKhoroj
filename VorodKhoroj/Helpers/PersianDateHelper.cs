
namespace VorodKhoroj.Classes
{
    public class PersianDateHelper
    {

        public static List<TemplateDays> GetRamadanDays()
        {
            var list = new List<TemplateDays>();

            var excelPath = Application.StartupPath + @"Resources\ramadan.xlsx";

            using (var package = new ExcelPackage(new FileInfo(excelPath)))
            {
                var worksheet = package.Workbook.Worksheets[0]; // اولین شیت

                var rowCount = worksheet.Dimension.Rows; // تعداد سطرها
                for (var row = 2; row <= rowCount; row++) // از ردیف 2 (بعد از هدر)
                {
                    var title = worksheet.Cells[row, 1].Text; // ستون title
                    var dateString = worksheet.Cells[row, 2].Text; // ستون date

                    if (DateTime.TryParse(dateString, out var date))
                        list.Add(new TemplateDays { Title = title, Date = date });
                    else
                        throw new Exception($"خطا در تبدیل تاریخ برای سطر {row}");
                }
            }

            return list;
        }

        public static List<TemplateDays> GetHolidays()
        {
            var farvardinHolidays = new List<int> { 1, 2, 3, 4, 12, 13 };


            var list = new List<TemplateDays>();


            var excelPath = Application.StartupPath + @"Resources\holiday.xlsx";

            using (var package = new ExcelPackage(new FileInfo(excelPath)))
            {
                var worksheet = package.Workbook.Worksheets[0]; // اولین شیت

                var rowCount = worksheet.Dimension.Rows; // تعداد سطرها
                for (var row = 2; row <= rowCount; row++) // از ردیف 2 (بعد از هدر)
                {
                    var title = worksheet.Cells[row, 1].Text; // ستون title
                    var dateString = worksheet.Cells[row, 2].Text; // ستون date

                    if (DateTime.TryParse(dateString, out var date))
                        list.Add(new TemplateDays { Title = title, Date = date });
                    else
                        throw new Exception($"خطا در تبدیل تاریخ برای سطر {row}");
                }
            }

            // اضافه کردن تعطیلات به لیست
            for (var dt = DateTime.Parse("1400/01/01"); dt <= (DateTime.Now); dt = dt.AddDays(1))
            {
                if (dt.DayOfWeek == DayOfWeek.Friday)
                {
                    list.Add(new TemplateDays { Title = "جمعه", Date = dt });
                }
                if (PersianCalendar.GetMonth(dt) == 1 && farvardinHolidays.Contains(PersianCalendar.GetDayOfMonth(dt)))
                {
                    list.Add(new TemplateDays { Title = "نوروز", Date = dt });
                }
            }

            return list;
        }

        public static List<DateTime> GetWorkDays_Farvardin()
        {
            var farvardindays = new[] { 01, 02, 03, 04, 05, 06, 07, 08, 09, 10, 11, 12, 13 };

            var list = new List<DateTime>();

            for (var dt = DateTime.Parse("1400/01/01"); dt <= (DateTime.Now); dt = dt.AddDays(1))
            {
                if (PersianCalendar.GetMonth(dt) == 1 && farvardindays.Contains(PersianCalendar.GetDayOfMonth(dt)))
                {
                    list.Add(dt.Date);
                }
            }

            return list;
        }

        public static DateTime DateTime = ConfigDateTime();
        public static readonly PersianCalendar PersianCalendar = new();
        public static string PersianCalenderDateNow()
        {
            int year = PersianCalendar.GetYear(DateTime);
            int month = PersianCalendar.GetMonth(DateTime);
            int day = PersianCalendar.GetDayOfMonth(DateTime);
            return $"{year}/{month:D2}/{day:D2}";
        }

        public static DateTime ConvertToShamsi(string inputDateTime)
        {
            var dateTime = ConfigDateTime(inputDateTime);
            // تبدیل تاریخ میلادی به شمسی
            int year = PersianCalendar.GetYear(dateTime);
            int month = PersianCalendar.GetMonth(dateTime);
            int day = PersianCalendar.GetDayOfMonth(dateTime);

            return new DateTime(year, month, day, dateTime.Hour, dateTime.Minute, dateTime.Second, PersianCalendar);
            //return: 11:11:11 19/02/1398

        }

        public static string ConvertToShamsiString(DateTime dateTime) => $"{PersianCalendar.GetYear(dateTime)}/{PersianCalendar.GetMonth(dateTime):D2}/{PersianCalendar.GetDayOfMonth(dateTime):D2} {dateTime:HH:mm:ss}";

        static DateTime ConfigDateTime(string inputDateTime)
        {
            var persianCulture = new CultureInfo("fa-IR");
            persianCulture.DateTimeFormat.Calendar = new PersianCalendar();
            Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture = persianCulture;
            return DateTime.Parse(inputDateTime, CultureInfo.InvariantCulture);
        }
        static DateTime ConfigDateTime()
        {
            var persianCulture = new CultureInfo("fa-IR");
            persianCulture.DateTimeFormat.Calendar = new PersianCalendar();
            Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture = persianCulture;
            return DateTime.Parse(DateTime.Now.ToShortDateString(), CultureInfo.DefaultThreadCurrentCulture);
        }

    }
    public class TemplateDays
    {
        public string Title { get; set; }
        public DateTime Date { get; set; }
    }
}
