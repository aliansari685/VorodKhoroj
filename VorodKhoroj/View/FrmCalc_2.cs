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
    private void BtnExportExcelClick(object sender, EventArgs e)
    {
        CommonHelper.DataGridToExcel(dataView_late);
    }
    private void radioButton_CheckedChanged(object? sender, EventArgs? e)
    {
        try
        {
            if (radioButton_qeybat.Checked)
                dataView_late.DataSource = _qeybathaDaysList.Select(g => new
                {
                    DayOfWeek = g.Date.ToString("dddd"),
                    Date = g.Date.ToString("yyyy/MM/dd")
                }).ToList().ToDataTable();


            if (radioButton_holidays.Checked)
                dataView_late.DataSource = _holidaysDaysList.Select(g => new
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