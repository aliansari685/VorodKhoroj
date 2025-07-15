namespace VorodKhoroj.Infrastructure
{
    public class AttendanceRecordFilter
    {
        /// <summary>
        /// فیتلر داده از بامداد شروع تاریخ تا 23:59 پایان تاریخ با کاربر مشخص
        /// </summary>
        /// <param name="records">دیتا تردد</param>
        /// <param name="fromDate">شروع</param>
        /// <param name="toDate">پایان</param>
        /// <param name="userid">کاربر ، اگر مشخص نیس 0 بده</param>
        /// <returns></returns>
        /// <exception cref="FormatException"></exception>
        public static IEnumerable<Attendance> ApplyFilter(IList<Attendance> records, string fromDate, string toDate, int userid)
        {
            try
            {
                DateTime.TryParse(fromDate, out var from);
                var to = DateTime.Parse(toDate).Date.AddDays(1).AddSeconds(-1);

                var result = records.Where(x => x.DateTime >= from && x.DateTime < to);

                if (userid != 0)
                {
                    result = result.Where(x => x.UserId == userid);
                }

                return result;

            }
            catch (Exception ex)
            {
                throw new FormatException($@"خطا در فیلتر کردن داده‌ها: {'\n'} {ex.Message}");
            }
        }
    }
}