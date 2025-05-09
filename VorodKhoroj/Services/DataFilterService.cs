namespace VorodKhoroj.Services
{
    public class DataFilterService
    {
        public static IEnumerable<Attendance> ApplyFilter(IList<Attendance> records, string fromDate, string toDate, int userid)
        {
            try
            {
                var from = DateTime.Parse(fromDate);
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