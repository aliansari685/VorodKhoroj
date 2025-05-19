namespace VorodKhoroj.View
{
    public partial class FrmAttendance : Form
    {
        private string _user = "";
        private string _datetime = "";
        private readonly AppCoordinator _service;
        private readonly AttendanceFullCalculationService _calcService;

        public FrmAttendance(AppCoordinator service, AttendanceFullCalculationService calcServices)
        {
            InitializeComponent();
            _service = service;
            _calcService = calcServices;
        }

        private void FrmAttendance_Load(object sender, EventArgs e)
        {
            DataGridConfig(PersianDateHelper.PersianCalenderDateNow());
        }

        private void DataGridConfig(string toDataTime, string fromDataTime = "1403/01/01", string userId = "0")
        {
            dataView_Attendance.DataSource = _calcService.Calculate(userId, fromDataTime, toDataTime, false).ToDataTable();

            dataView_Attendance.ApplyDisplayNames<WorkRecord>();

            dataView_Attendance.Sort(dataView_Attendance.Columns[nameof(WorkRecord.Date)]!, ListSortDirection.Ascending);

            Userid_txtbox.DataSource = _service.UsersList;

            CommonItems.SetDisplayAndValueMemberComboBox(ref Userid_txtbox);
        }

        private void btn_applyFilter_Click(object sender, EventArgs e)
        {
            try
            {
                if (int.TryParse(Userid_txtbox.SelectedValue?.ToString(), out var res) || int.TryParse(Userid_txtbox.Text, out res))
                {
                    dataView_Attendance.DataSource = _calcService.Calculate(res.ToString(), FromDateTime_txtbox.Text, toDateTime_txtbox.Text, false).ToDataTable();
                    dataView_Attendance.ApplyDisplayNames<WorkRecord>();
                }
                else
                {
                    throw new FormatException("خطا در فیلتر کردن داده ها");
                }
            }
            catch (Exception ex)
            {
                CommonHelper.ShowMessage(ex);
            }
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            FromDateTime_txtbox.Text = Userid_txtbox.Text = "";
            toDateTime_txtbox.Text = PersianDateHelper.PersianCalenderDateNow();
            DataGridConfig();
        }

        private void btn_submit_Click(object sender, EventArgs e)
        {
            try
            {
                var firstAttendance = _service.DbContext?.Attendances.First(x =>
                    x.DateTime == DateTime.Parse(_datetime) && x.UserId == int.Parse(_user));

                firstAttendance!.DateTime = DateTime.Parse(DateTime_txtbox.Text);


                // var attendance = new Attendance() { };
                _service.UpdateAttendanceRecord(new Attendance());
            }
            catch (Exception ex)
            {
                CommonHelper.ShowMessage(ex);
            }

        }

        private void dataView_Attendance_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0 || e.ColumnIndex < 0)
                    return;

                _user = dataView_Attendance.Rows[e.RowIndex].Cells[nameof(WorkRecord.UserId)].Value.ToString()!;
                _datetime = dataView_Attendance.Rows[e.RowIndex].Cells[nameof(WorkRecord.Date)].Value.ToString()!;

                var workRecords = _calcService.Calculate(_user, _datetime, _datetime, false);

                var result = workRecords.First();

                DateTime_txtbox.Text = result.Date;
                Entry1_txtbox.Text = result.EntryTime;
                Exit1_txtbox.Text = result.ExitTime;
                Entry2_txtbox.Text = result.EntryTime2;
                Exit2_txtbox.Text = result.ExitTime2;
            }
            catch (Exception ex)
            {
                CommonHelper.ShowMessage(ex);
            }
        }
    }
}
