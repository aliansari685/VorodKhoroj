namespace VorodKhoroj.Data
{
    public class DataFilterService
    {
        public static IEnumerable<Attendance> ApplyFilter(IList<Attendance> _records, string fromDate, string toDate, int userid)
        {
            try
            {
                return _records.Where(x =>
                    x.DateTime >= DateTime.Parse(fromDate) &&
                    x.DateTime <= DateTime.Parse(toDate).AddDays(1).AddSeconds(-1) && x.UserId == userid);

            }
            catch (Exception ex)
            {
                throw new ArgumentException($@"خطا در فیلتر کردن داده‌ها: {'\n'} {ex.Message}");
            }
        }
    }
}