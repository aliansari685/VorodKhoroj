namespace VorodKhoroj.Helpers
{
    public static class ExtensionMethod
    {
        /// <summary>
        /// تبدیل لیست به DataTable با نام ستون‌ها از DisplayNameAttribute
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static DataTable ToDataTableWithDisplayedName<T>(this List<T> list)
        {
            DataTable table = new();
            var properties = typeof(T).GetProperties();

            Dictionary<string, PropertyInfo> columnMappings = new();

            foreach (var prop in properties)
            {
                var displayNameAttr = prop.GetCustomAttribute<DisplayNameAttribute>();
                string columnName = displayNameAttr?.DisplayName ?? prop.Name;

                table.Columns.Add(columnName, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
                columnMappings[columnName] = prop;
            }

            foreach (var item in list)
            {
                var row = table.NewRow();
                foreach (var (columnName, prop) in columnMappings)
                {
                    row[columnName] = prop.GetValue(item) ?? DBNull.Value;
                }
                table.Rows.Add(row);
            }

            return table;
        }

        /// <summary>
        ///تبدیل لیست به DataTable بدون استفاده از DisplayNameAttribute 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static DataTable ToDataTable<T>(this List<T> list)
        {
            DataTable table = new();
            var properties = typeof(T).GetProperties();

            foreach (var prop in properties)
            {
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            }

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

        /// <summary>
        /// تنظیم نام ستون‌های DataGridView بر اساس DisplayNameAttribute نوع داده
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="grid"></param>
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
                        column.HeaderText = displayNameAttr.DisplayName;
                }
            }
        }

        /// <summary>
        /// جایگزین کردن نام ستون‌های DataGridView با DisplayNameها از آبجکت
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="dataGrid"></param>
        public static void SetDisplayNameInDataGrid<T>(this T obj, DataGridView dataGrid)
        {
            var displayNames = obj.GetDisplayNames();
            for (var i = 0; i < displayNames.Count && i < dataGrid.Columns.Count; i++)
            {
                dataGrid.Columns[i].HeaderText = displayNames[i];
            }
        }
        /// <summary>
        /// دریافت لیست DisplayNameها از نوع T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static List<string> GetDisplayNames<T>(this T obj)
        {
            return typeof(T)
                .GetProperties()
                .Select(prop => prop.GetCustomAttribute<DisplayNameAttribute>())
                .Where(attr => attr != null)
                .Select(attr => attr!.DisplayName)
                .ToList();
        }

        /// <summary>
        /// دریافت DisplayName یک پراپرتی خاص از طریق Expression
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="obj"></param>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static string GetDisplayName<T, TProperty>(this T obj, Expression<Func<T, TProperty>> expression)
        {
            MemberExpression? member = expression.Body switch
            {
                MemberExpression m => m,
                UnaryExpression { Operand: MemberExpression unaryMember } => unaryMember,
                _ => null
            };

            if (member != null)
            {
                var prop = typeof(T).GetProperty(member.Member.Name);
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