namespace VorodKhoroj.Classes
{
    public class DataManager
    {
        public static List<Structure> ApplyFilter(string fromDate, string toDate, int userid)
        {
            try
            {
                return DataConfiguration.Records.Where(x => x.DateTime >= DateTime.Parse(fromDate) && x.DateTime <= DateTime.Parse(toDate) && x.UserId == userid).ToList();
            }
            catch (Exception ex)
            {
                throw new ArgumentException($@"خطا در فیلتر کردن داده‌ها: {'\n'} {ex.Message}");
            }
        }
    }
}
