using Serilog.Context;

namespace VorodKhoroj.Classes
{
    public static class CommonHelper
    {
        private static string GetCallerMethod([CallerMemberName] string methodName = "")
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

        public static void DataGridToExcel(DataGridView dataGridView)
        {
            try
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                using (SaveFileDialog sfd = new() { Filter = "Excel Files|*.xlsx", Title = "ذخیره فایل اکسل" })
                {
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        using (ExcelPackage package = new())
                        {
                            using (ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Data"))
                            {
                                // افزودن عنوان ستون‌ها
                                for (int i = 0; i < dataGridView.Columns.Count; i++)
                                {
                                    worksheet.Cells[1, i + 1].Value = dataGridView.Columns[i].HeaderText;
                                }

                                // افزودن داده‌های DataGridView
                                for (int i = 0; i < dataGridView.Rows.Count; i++)
                                {
                                    for (int j = 0; j < dataGridView.Columns.Count; j++)
                                    {
                                        worksheet.Cells[i + 2, j + 1].Value =
                                            dataGridView.Rows[i].Cells[j].Value?.ToString();
                                    }
                                }

                                // ذخیره فایل
                                File.WriteAllBytes(sfd.FileName, package.GetAsByteArray());
                                CommonHelper.ShowMessage("فایل اکسل با موفقیت ذخیره شد!");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                CommonHelper.ShowMessage(ex);
            }
        }

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
            catch (Exception ex)
            {
                throw ex ;
            }
        }
    }
}
