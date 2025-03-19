using System.Data;
using VorodKhoroj.Model;

namespace VorodKhoroj.Classes
{
    public class DataManager
    {
        public static DataView ApplyFilter(string fromDate, string toDate, string userid)
        {
            var _dataview = new DataView(DataConfiguration.table);
            try
            {
                var filter = "1=1"; // برای اینکه بشه شرط‌ها رو بهش اضافه کرد

                filter +=
                    $" AND DateTime >= '{DateTime.Parse(fromDate):yyyy/MM/dd HH:mm:ss}' AND DateTime <= '{DateTime.Parse(toDate):yyyy/MM/dd HH:mm:ss}'";

                if (!string.IsNullOrWhiteSpace(userid)) filter += $" AND User = '{userid}'";

                _dataview.RowFilter = filter;
                return _dataview;
            }
            catch (Exception ex)
            {
                throw new ArgumentException($@"خطا در فیلتر کردن داده‌ها: {'\n'} {ex.Message}");
            }

        }
    }
}
