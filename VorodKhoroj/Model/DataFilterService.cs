namespace VorodKhoroj.Model
{
    public class DataFilterService
    {
        public static List<Structure> ApplyFilter(IList<Structure>_records ,string fromDate, string toDate, int userid)
        {
            try
            {
                return _records.Where(x => x.DateTime >= DateTime.Parse(fromDate) && x.DateTime <= DateTime.Parse(toDate) && x.UserId == userid).ToList();
            }
            catch (Exception ex)
            {
                throw new ArgumentException($@"خطا در فیلتر کردن داده‌ها: {'\n'} {ex.Message}");
            }
        }
    }
}