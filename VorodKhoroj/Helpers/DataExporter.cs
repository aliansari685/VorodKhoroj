using VorodKhoroj.Application.Services;

namespace VorodKhoroj.Helpers;

public static class DataExporter
{
    /// <summary>
    /// اکسپورت داده‌های DataGridView به فایل اکسل با امکان سفارشی‌سازی عنوان ستون‌ها و عنوان کلی
    /// </summary>
    public static void ExportDataGrid(DataGridView grid, Dictionary<string, string>? labels = null, string title = "")
    {
        try
        {
            using var saveFile = CommonItems.CreateSaveFileDialog(@"Excel Files|*.xlsx");
            if (saveFile.ShowDialog() != DialogResult.OK)
                return;

            using var package = new ExcelPackage();
            var worksheet = package.Workbook.Worksheets.Add("Data");

            // عنوان ستون‌ها
            for (var col = 0; col < grid.Columns.Count; col++)
                worksheet.Cells[1, col + 1].Value = grid.Columns[col].HeaderText;

            // داده‌ها
            for (var row = 0; row < grid.Rows.Count; row++)
                for (var col = 0; col < grid.Columns.Count; col++)
                    worksheet.Cells[row + 2, col + 1].Value = grid.Rows[row].Cells[col].Value?.ToString();

            // عنوان کلی گزارش
            worksheet.Cells[grid.Rows.Count + 3, 1].Value = title;

            // خلاصه محاسبات (لیبل‌ها)
            if (labels is { Count: > 0 })
            {
                int labelRow = grid.Rows.Count + 5;
                int labelCol = 1;

                foreach (var (key, value) in labels)
                {
                    worksheet.Cells[labelRow, labelCol].Value = key;
                    worksheet.Cells[labelRow + 1, labelCol].Value = value;
                    labelCol++;
                }
            }
            //فیت کردن بین سلول ها
            worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();
            File.WriteAllBytes(saveFile.FileName, package.GetAsByteArray());

            CommonHelper.ShowMessage("فایل اکسل با موفقیت ذخیره شد!");
        }
        catch (Exception ex)
        {
            CommonHelper.ShowMessage(ex);
        }
    }


    /// <summary>
    /// اکسپورت داده‌های حضور و غیاب برای ماه‌های انتخاب شده به فایل اکسل
    /// </summary>
    public static void ExportAttendanceData(
        string userId,
        int year,
        List<int> selectedMonths,
        bool includeLabels,
        string filePath,
        AttendanceFullCalculationService calcService)
    {
        using var package = new ExcelPackage();
        bool flag = false;
        foreach (var month in selectedMonths)
        {
            string startDate = $"{year}/{month:D2}/01";
            string endDate = $"{year}/{month:D2}/{PersianDateHelper.PersianCalendar.GetDaysInMonth(year, month):D2}";
            var records = calcService.Calculate(userId, startDate, endDate);

            // فقط در صورتی که رکورد داشت ادامه می‌دهیم
            if (records.Count == 0) continue;

            var worksheet = package.Workbook.Worksheets.Add($"ماه {month:D2}");

            worksheet.Cells["A1"].LoadFromCollection(records, true);

            worksheet.Cells[records.Count + 3, 1].Value = calcService.TitleReport;
            flag = true;
            if (includeLabels)
            {
                int labelRow = records.Count + 5;
                int labelCol = 1;
                var labels = calcService.GetDataWithTitle();

                foreach (var (key, value) in labels)
                {
                    worksheet.Cells[labelRow, labelCol].Value = key;
                    worksheet.Cells[labelRow + 1, labelCol].Value = value;
                    labelCol++;
                }
            }

            worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();
        }

        if (flag)
        {
            File.WriteAllBytes(filePath, package.GetAsByteArray());
        }

    }
}