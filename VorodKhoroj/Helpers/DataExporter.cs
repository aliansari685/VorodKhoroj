namespace VorodKhoroj.Helpers;

public static class DataExporter
{
    public static void ExportDataGrid(DataGridView grid, Dictionary<string, string>? labels = null, string title = "")
    {
        try
        {
            using SaveFileDialog saveDialog = new() { Filter = "Excel Files|*.xlsx", Title = "ذخیره فایل اکسل" };

            if (saveDialog.ShowDialog() != DialogResult.OK)
                return;

            using var package = new ExcelPackage();
            var worksheet = package.Workbook.Worksheets.Add("Data");

        
            // عنوان ستون‌ها
            for (var col = 0; col < grid.Columns.Count; col++)
                worksheet.Cells[1, col + 1].Value = grid.Columns[col].HeaderText;

            // داده‌ها
            for (var row = 0; row < grid.Rows.Count; row++)
                for (var col = 0; col < grid.Columns.Count; col++)
                {
                    worksheet.Cells[row + 2, col + 1].Value = grid.Rows[row].Cells[col].Value?.ToString();
                }

            worksheet.Cells[grid.Rows.Count + 3, 1].Value = title;

            if (labels is not null && labels.Any())
            {
                var labelRow = grid.Rows.Count + 5;
                var labelCol = 1;

                foreach (var (key, value) in labels)
                {
                    worksheet.Cells[labelRow, labelCol].Value = key;
                    worksheet.Cells[labelRow + 1, labelCol].Value = value;
                    labelCol++;
                }
            }

            worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();
            File.WriteAllBytes(saveDialog.FileName, package.GetAsByteArray());

            CommonHelper.ShowMessage("فایل اکسل با موفقیت ذخیره شد!");
        }
        catch (Exception ex)
        {
            CommonHelper.ShowMessage(ex);
        }
    }

    public static void ExportAttendanceData(
        string userId,
        int year,
        List<int> selectedMonths,
        bool includeLabels,
        string filePath,
        AttendanceCalculationService calcService)
    {
        using var package = new ExcelPackage();

        foreach (var month in selectedMonths)
        {
            var worksheet = package.Workbook.Worksheets.Add($"ماه {month:D2}");

            var startDate = $"{year}/{month:D2}/01";
            var endDate = $"{year}/{month:D2}/{PersianDateHelper.PersianCalendar.GetDaysInMonth(year, month):D2}";

            var headers = calcService.PersianColumnHeader;
            var records = calcService.Calculate(userId, startDate, endDate);
            if (records.Count == 0)
                return;

            var properties = typeof(AttendanceCalculationService.WorkRecord).GetProperties();

            // عنوان ستون‌ها
            for (var col = 0; col < headers.Count; col++) worksheet.Cells[1, col + 1].Value = headers[col];

            // داده‌ها
            for (var row = 0; row < records.Count; row++)
                for (var col = 0; col < headers.Count; col++)
                {
                    var value = properties[col].GetValue(records[row]);
                    worksheet.Cells[row + 2, col + 1].Value = value?.ToString() ?? "";
                }

            // لیبل‌ها
            if (includeLabels)
            {
                var labelRow = records.Count + 4;
                var labelCol = 1;
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

        File.WriteAllBytes(filePath, package.GetAsByteArray());
    }
}