using System.Linq.Expressions;
using System.Reflection;

namespace VorodKhoroj.Classes
{
    public class CommonHelpers
    {
        public static string PersianCalenderDateNow()
        {
            PersianCalendar persianCalendar = new();

            int year = persianCalendar.GetYear(DateTime.Now);
            int month = persianCalendar.GetMonth(DateTime.Now);
            int day = persianCalendar.GetDayOfMonth(DateTime.Now);

            return $"{year}/{month:D2}/{day:D2}";
        }

        public static DateTime ConvertToShamsi(string inputDateTime)
        {
            //Set config for all region pc
            var persianCulture = new CultureInfo("fa-IR");
            persianCulture.DateTimeFormat.Calendar = new PersianCalendar();
            Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture = persianCulture;

            var dateTime = DateTime.Parse(inputDateTime, CultureInfo.InvariantCulture);
            var persianCalendar = new PersianCalendar();

            // تبدیل تاریخ میلادی به شمسی
            int year = persianCalendar.GetYear(dateTime);
            int month = persianCalendar.GetMonth(dateTime);
            int day = persianCalendar.GetDayOfMonth(dateTime);

            return new DateTime(year, month, day, dateTime.Hour, dateTime.Minute, dateTime.Second, persianCalendar);
            //return: 11:11:11 19/02/1398

        }

        public static string ConvertToShamsiString(DateTime dateTime)
        {
            var persianCalendar = new PersianCalendar();
            return $"{persianCalendar.GetYear(dateTime)}/{persianCalendar.GetMonth(dateTime):D2}/{persianCalendar.GetDayOfMonth(dateTime):D2} {dateTime:HH:mm:ss}";
        }

        public static string ConvertToLoginType(string number)
        {
            int num = int.Parse(number);
            return ((DataConfiguration.LoginType)num).ToString();
        }


    }
}
