namespace VorodKhoroj.View;

public partial class FrmCalc
{

    //TabPage 2 Qeybatha:

    private void Part2_Load()
    {
        radioButton_CheckedChanged(null, null);
    }

    private void DataGridViewConfig1()
    {
        dataView_late.Columns[0].HeaderText = "روز در هفته";
        dataView_late.Columns[1].HeaderText = "تاریخ";
        _ = dataView_late.Columns.Count == 3 ? dataView_late.Columns[2].HeaderText = "عنوان" : "";

    }
    private void dataView_late_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
    {
        if (_calcServices.OvertimeinHoliday.Contains(DateTime.Parse(dataView_late?.Rows[e.RowIndex].Cells[nameof(WorkRecord.Date)]?.Value?.ToString()!)))
            dataView_late!.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.CadetBlue;
    }
    private void BtnExportExcelClick(object sender, EventArgs e)
    {
        DataExporter.ExportDataGrid(dataView_late);
    }
    private void radioButton_CheckedChanged(object? sender, EventArgs? e)
    {
        try
        {
            RadioButtonChecker();

            DataGridViewConfig1();
        }
        catch (Exception ex)
        {
            CommonHelper.ShowMessage(ex);
        }

    }

    private void RadioButtonChecker()
    {
        var fromDt = DateTime.Parse(_fromDateTime);
        var toDt = DateTime.Parse(_toDateTime);

        if (radioButton_qeybat.Checked)
            dataView_late.DataSource = _calcServices.QeybathaDaysList.Select(g => new
            {
                DayOfWeek = g.Date.ToString("dddd"),
                Date = g.Date.ToString("yyyy/MM/dd")
            }).ToList().ToDataTable();


        else if (radioButton_holidays.Checked)
            dataView_late.DataSource = _calcServices.HolidaysDaysList.Select(g => new
            {
                DayOfWeek = g.Date.ToString("dddd"),
                Date = g.Date.ToString("yyyy/MM/dd"),
            }).ToList().ToDataTable();


        else if (radioButton_ramadan.Checked)
            dataView_late.DataSource = _calcServices.RamadanDaysList.Where(x => x.Date.Date >= fromDt && x.Date.Date <= toDt).Select(g =>
                new
                {
                    DayOfWeek = g.Date.ToString("dddd"),
                    Date = g.Date.ToString("yyyy/MM/dd"),
                    g.Title,
                }).ToList().ToDataTable();
    }
}