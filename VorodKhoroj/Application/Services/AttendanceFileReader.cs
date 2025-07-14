namespace VorodKhoroj.Application.Services
{
    /// <summary>
    /// کلاس خواندن داده ها از فایل
    /// </summary>
    public class AttendanceFileReader
    {

        /// <summary>
        /// خواندن رکوردهای حضور و غیاب از فایل متنی با فرمت تب جدا شده
        /// </summary>
        /// <param name="fileAddress">آدرس فایل</param>
        /// <returns>لیستی از رکوردهای Attendance</returns>
        public List<Attendance> GetRecordsFromFile(string fileAddress)
        {
            List<Attendance> records = [];
            foreach (var line in File.ReadAllLines(fileAddress))
            {
                var values = line.Split('\t');
                if (values.Length == 6)
                {
                    records.Add(new Attendance
                    {
                        UserId = int.Parse(values[0]),
                        DateTime = PersianDateHelper.ConvertToShamsi(values[1]),
                        LoginType = GetLoginType(values[4])
                    });
                }
            }
            return records;
        }

        /// <summary>
        /// تبدیل کد عددی ورود به نوع ورود به صورت رشته‌ای
        /// </summary>
        /// <param name="number">کد عددی ورود</param>
        /// <returns>نوع ورود به صورت رشته</returns>
        public string GetLoginType(string number)
        {
            var num = int.Parse(number);
            return num switch
            {
                15 => "Face",
                1 => "Finger",
                _ => "",
            };
        }

    }
}
