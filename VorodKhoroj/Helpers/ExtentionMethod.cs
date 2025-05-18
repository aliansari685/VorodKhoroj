namespace VorodKhoroj.Helpers
{
    public static class ExtentionMethod
    {
        //with attribute DisplayName:
        public static DataTable ToDataTableWithDisplayedName<T>(this List<T> list)
        {
            DataTable table = new();
            var properties = typeof(T).GetProperties();

            // نگه‌داشتن نگاشت: نام ستون → پراپرتی مرتبط
            Dictionary<string, PropertyInfo> columnMappings = new();

            // ایجاد ستون‌ها
            foreach (var prop in properties)
            {
                var displayNameAttr = prop.GetCustomAttribute<DisplayNameAttribute>();
                string columnName = displayNameAttr?.DisplayName ?? prop.Name;

                table.Columns.Add(columnName, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
                columnMappings[columnName] = prop;
            }

            // اضافه کردن داده‌ها
            foreach (var item in list)
            {
                var row = table.NewRow();
                foreach (var column in columnMappings)
                {
                    var prop = column.Value;
                    var columnName = column.Key;
                    row[columnName] = prop.GetValue(item) ?? DBNull.Value;
                }
                table.Rows.Add(row);
            }

            return table;
        }

        //without attribute DisplayName:
        public static DataTable ToDataTable<T>(this List<T> list)
        {
            DataTable table = new();
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

        public static void ApplyDisplayNames<T>(this DataGridView grid)
        {
            var props = typeof(T).GetProperties();

            foreach (DataGridViewColumn column in grid.Columns)
            {
                var prop = props.FirstOrDefault(p => p.Name == column.Name);
                if (prop != null)
                {
                    var displayNameAttr = prop.GetCustomAttribute<DisplayNameAttribute>();
                    if (displayNameAttr != null)
                    {
                        column.HeaderText = displayNameAttr.DisplayName;
                    }
                }
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
                .Select(attr => attr?.DisplayName ?? string.Empty)
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
            else if (expression.Body is UnaryExpression { Operand: MemberExpression unaryMember })
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
