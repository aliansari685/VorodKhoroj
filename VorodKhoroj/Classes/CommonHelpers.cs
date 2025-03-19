using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VorodKhoroj.Model;

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

        public static string ConvertToShamsi(string inputDateTime)
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

        public static string ConvertToLoginType(string number)
        {
            int num = int.Parse(number);
            return ((DataConfiguration.LoginType)num).ToString();
        }
    }
}
