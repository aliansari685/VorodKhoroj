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

            Userid_txtbox.DataSource = _service.UsersList;
            CommonItems.SetDisplayAndValueMemberComboBox(ref Userid_txtbox);
        }

        private void DataGridConfig(string toDataTime, string fromDataTime = "1403/01/01", string userId = "0")
        {
            dataView_Attendance.DataSource = _calcService.Calculate(userId, fromDataTime, toDataTime, false).ToDataTable();

            dataView_Attendance.ApplyDisplayNames<WorkRecord>();

            dataView_Attendance.Sort(dataView_Attendance.Columns[nameof(WorkRecord.Date)]!, ListSortDirection.Ascending);
        }

        private void btn_applyFilter_Click(object sender, EventArgs e)
        {
            try
            {
                if (int.TryParse(Userid_txtbox.SelectedValue?.ToString(), out var res) || int.TryParse(Userid_txtbox.Text, out res))
                {
                    DataGridConfig(toDateTime_txtbox.Text, FromDateTime_txtbox.Text, res.ToString());
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
            DataGridConfig(toDateTime_txtbox.Text = PersianDateHelper.PersianCalenderDateNow());
        }

        private void btn_submit_Click(object sender, EventArgs e)
        {
            try
            {
                if (CommonHelper.IsValid(Entry1_txtbox, Exit1_txtbox) == false)
                {
                    throw new NullReferenceException("خطا در بروزرسانی تردد اول");
                }

                var attendances = _service.DbContext?.Attendances.Where(x =>
                    x.DateTime.Date == DateTime.Parse(_datetime) && x.UserId == int.Parse(_user)).ToList();

                if (attendances == null) throw new NullReferenceException("رکوردی یافت نشد");

                //Entry1:
                UpdateAttendance(attendances, 0, TimeSpan.Parse(Entry1_txtbox.Text));

                //Exit1:
                if (attendances.Count > 1)
                {
                    UpdateAttendance(attendances, 1, TimeSpan.Parse(Exit1_txtbox.Text));
                }
                else
                {
                    AddAttendance(attendances, 0, TimeSpan.Parse(Exit1_txtbox.Text));
                }

                //Entry2:
                if (CommonHelper.IsValid(Entry2_txtbox, Exit2_txtbox))
                {
                    if (attendances.Count > 2)
                    {
                        UpdateAttendance(attendances, 2, TimeSpan.Parse(Entry2_txtbox.Text));
                    }
                    else
                    {
                        AddAttendance(attendances, 1, TimeSpan.Parse(Entry2_txtbox.Text));
                    }


                    //Exit2:
                    if (attendances.Count > 3)
                    {
                        UpdateAttendance(attendances, 3, TimeSpan.Parse(Exit2_txtbox.Text));
                    }
                    else
                    {
                        AddAttendance(attendances, 2, TimeSpan.Parse(Exit2_txtbox.Text));
                    }
                }
                _service.DbContext?.SaveChanges();

                CommonHelper.ShowMessage("تغییرات با موفقیت انجام شد ");

            }
            catch (Exception ex)
            {
                CommonHelper.ShowMessage(ex);
            }

        }

        private void AddAttendance(List<Attendance> attendances, int index, TimeSpan tm)
        {
            var at = new Attendance
            {
                DateTime = attendances[index].DateTime.Date + tm,
                LoginType = attendances[index].LoginType,
                UserId = attendances[index].UserId
            };
            _service.AddAttendanceRecord(at);
        }

        private void UpdateAttendance(List<Attendance> attendances, int index, TimeSpan tm)
        {
            var newDateTime = attendances[index].DateTime.Date + tm;
            attendances[index].DateTime = newDateTime;
            _service.UpdateAttendanceRecord(attendances[index]);
        }

        private void dataView_Attendance_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0 || e.ColumnIndex < 0)
                    return;

                var thisRow = dataView_Attendance.Rows[e.RowIndex];
                _user = thisRow.Cells[nameof(WorkRecord.UserId)].Value.ToString()!;
                _datetime = thisRow.Cells[nameof(WorkRecord.Date)].Value.ToString()!;

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
