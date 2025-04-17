using System.ComponentModel;
using Serilog.Context;

namespace VorodKhoroj.Classes
{
    public static class CommonHelper
    {
        public static string GetCallerMethod([CallerMemberName] string methodName = "")
        {
            return methodName;
        }

        public static void ShowMessage(Exception ex)
        {
            using (LogContext.PushProperty("Method", GetCallerMethod()))
            {
                string text = $@"خطای داخلی{'\n'}{ex.Message}{'\n'}{ex.InnerException?.Message}";
                string caption = "خطا";
                Log.Error(text);
                MessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public static void ShowMessage(string message)
        {
            string caption = "پیام";
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static bool Validation(params string[] str) => !(str.Any(string.IsNullOrWhiteSpace));


        public static DataTable ToDataTable<T>(this List<T> list)
        {
            try
            {
                using (DataTable table = new())
                {
                    // ایجاد ستون‌ها بر اساس پراپرتی‌های کلاس
                    var properties = typeof(T).GetProperties();
                    foreach (var prop in properties)
                    {
                        table.Columns.Add(prop.Name,
                            Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
                    }

                    // اضافه کردن داده‌ها
                    foreach (var item in list)
                    {
                        var row = table.NewRow();
                        foreach (var prop in properties)
                        {
                            row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                        }

                        table.Rows.Add(row);
                    }

                    return table;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //public static Dictionary<string, string> GetDataWithDisplayName()
        //{
        //    var result = new Dictionary<string, string>();
        //    var props = Report.GetType().GetProperties();

        //    foreach (var prop in props)
        //    {
        //        var displayNameAttr = prop.GetCustomAttributes(typeof(DisplayNameAttribute), false)
        //            .Cast<DisplayNameAttribute>()
        //            .FirstOrDefault();

        //        var displayName = displayNameAttr?.DisplayName ?? prop.Name; // اگر اتریبیوت نبود، اسم پراپرتی

        //        var value = prop.GetValue(Report)?.ToString() ?? "";

        //        result[displayName] = value;
        //    }

        //    return result;
        //}


    }
}