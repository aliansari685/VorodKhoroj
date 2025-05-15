namespace VorodKhoroj.View
{
    public partial class FrmAttendance : Form
    {
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
            var user = dataView_Attendance.Rows[e.RowIndex].Cells[nameof(Attendance.UserId)].Value.ToString();
            var time = dataView_Attendance.Rows[e.RowIndex].Cells[nameof(Attendance.DateTime)].Value.ToString();

            var workRecords = _calcService.Calculate(user, time, time, false);

            //ToDo:tomorrow add combobox for set data from workRecords :
        }
    }
}
