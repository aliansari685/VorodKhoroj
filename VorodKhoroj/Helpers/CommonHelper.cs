using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection;
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

        public static void SetDisplayNameInDataGrid<T>(this T obj, DataGridView dataGrid)
        {
            var temp = obj.GetDisplayNames();
            for (var i = 0; i < temp.Count; i++)
            {
                dataGrid.Columns[i].HeaderText = temp[i];
            }
        }

        public static List<string> GetDisplayNames<T>(this T obj)
        {
            return typeof(T)
                .GetProperties()
                .Select(prop => prop.GetCustomAttribute<DisplayNameAttribute>())
                .Where(attr => attr != null)
                .Select(attr => attr.DisplayName)
                .ToList();
        }

        public static string GetDisplayName<T, TProperty>(this T obj, Expression<Func<T, TProperty>> expression)
        {
            if (expression.Body is MemberExpression member)
            {
                var prop = typeof(T).GetProperty(member.Member.Name);
                if (prop != null)
                {
                    var attr = prop.GetCustomAttribute<DisplayNameAttribute>();
                    return attr?.DisplayName ?? prop.Name;
                }
            }
            else if (expression.Body is UnaryExpression unary && unary.Operand is MemberExpression unaryMember)
            {
                var prop = typeof(T).GetProperty(unaryMember.Member.Name);
                if (prop != null)
                {
                    var attr = prop.GetCustomAttribute<DisplayNameAttribute>();
                    return attr?.DisplayName ?? prop.Name;
                }
            }

            return string.Empty;
        }
    }
}