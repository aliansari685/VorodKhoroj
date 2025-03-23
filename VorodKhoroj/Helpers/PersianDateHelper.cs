namespace VorodKhoroj.Classes
{
    public class PersianDateHelper
    {
        private static DateTime _dateTime = ConfigDateTime();
        private static readonly PersianCalendar _persianCalendar = new();
        public static string PersianCalenderDateNow()
        {
            int year = _persianCalendar.GetYear(_dateTime);
            int month = _persianCalendar.GetMonth(_dateTime);
            int day = _persianCalendar.GetDayOfMonth(_dateTime);
            return $"{year}/{month:D2}/{day:D2}";
        }

        public static DateTime ConvertToShamsi(string inputDateTime)
        {
            var dateTime = ConfigDateTime(inputDateTime);
            // تبدیل تاریخ میلادی به شمسی
            int year = _persianCalendar.GetYear(dateTime);
            int month = _persianCalendar.GetMonth(dateTime);
            int day = _persianCalendar.GetDayOfMonth(dateTime);

            return new DateTime(year, month, day, dateTime.Hour, dateTime.Minute, dateTime.Second, _persianCalendar);
            //return: 11:11:11 19/02/1398

        }

        public static string ConvertToShamsiString(DateTime dateTime) => $"{_persianCalendar.GetYear(dateTime)}/{_persianCalendar.GetMonth(dateTime):D2}/{_persianCalendar.GetDayOfMonth(dateTime):D2} {dateTime:HH:mm:ss}";

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
}
