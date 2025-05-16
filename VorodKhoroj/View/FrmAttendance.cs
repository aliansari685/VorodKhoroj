namespace VorodKhoroj.View
{
    public partial class FrmAttendance : Form
    {
        private string _user;
        private string _datetime;
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
            DataGridConfig();
        }

        private void DataGridConfig()
        {
            dataView_Attendance.DataSource = _service.DbContext?.Attendances.Local.ToBindingList();

            dataView_Attendance.Sort(dataView_Attendance.Columns[nameof(Attendance.DateTime)]!, ListSortDirection.Ascending);

            dataView_Attendance.Columns[nameof(Attendance.DateTime)]!.DefaultCellStyle.Format = "yyyy/MM/dd HH:mm:ss";

            Userid_txtbox.DataSource = _service.UsersList;

            CommonItems.SetDisplayAndValueMemberComboBox(ref Userid_txtbox);
        }

        private void btn_applyFilter_Click(object sender, EventArgs e)
        {
            try
            {
                if (int.TryParse(Userid_txtbox.SelectedValue?.ToString(), out var res) || int.TryParse(Userid_txtbox.Text, out res))
                {
                    dataView_Attendance.DataSource = DataFilterService.ApplyFilter(_service.Records, FromDateTime_txtbox.Text, toDateTime_txtbox.Text, res).ToList();
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

        private void dataView_Attendance_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _user = dataView_Attendance.Rows[e.RowIndex].Cells[nameof(Attendance.UserId)].Value.ToString()!;
                _datetime = dataView_Attendance.Rows[e.RowIndex].Cells[nameof(Attendance.DateTime)].Value.ToString()!;

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
    }
}
