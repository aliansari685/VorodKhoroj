using VorodKhoroj.Helpers;

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

    }
    private void dataView_late_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
    {
        if (_calcServices.overtimeinHoliday.Contains(DateTime.Parse(dataView_late?.Rows[e.RowIndex]?.Cells["Date"]?.Value?.ToString())))
            dataView_late.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.CadetBlue;
    }
    private void BtnExportExcelClick(object sender, EventArgs e)
    {
        DataExporter.ExportDataGrid(dataView_late);
    }
    private void radioButton_CheckedChanged(object? sender, EventArgs? e)
    {
        try
        {
            if (radioButton_qeybat.Checked)
                dataView_late.DataSource = _calcServices.QeybathaDaysList.Select(g => new
                {
                    DayOfWeek = g.Date.ToString("dddd"),
                    Date = g.Date.ToString("yyyy/MM/dd")
                }).ToList().ToDataTable();


            if (radioButton_holidays.Checked)
                dataView_late.DataSource = _calcServices.HolidaysDaysList.Select(g => new
                {
                    DayOfWeek = g.Date.ToString("dddd"),
                    Date = g.Date.ToString("yyyy/MM/dd"),
                }).ToList().ToDataTable();

            DataGridViewConfig1();
        }
        catch (Exception ex)
        {
            CommonHelper.ShowMessage(ex);
        }

    }

}