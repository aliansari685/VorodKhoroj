namespace VorodKhoroj.View
{
    public partial class FrmAttendance : Form
    {
        #region Fields:

        private readonly TimeSpan _lastArrivalTime = TimeSpan.Parse("12:00:00");
        private string _user = "";
        private string _datetime = "";
        private readonly MainCoordinator _appCoordinator;
        private readonly AttendanceFullCalculationService _calcService;

        // لیست موقت رکوردهای کاری پس از محاسبه (برای نمایش در دیتاگرید)
        private List<WorkRecord> _tempRecords = [];

        // لیست موقت حضور و غیاب که از Coordinator گرفته می‌شود
        private List<Attendance> TempRecordsAttendances => _appCoordinator.AttendancesList;

        // لیست موقت رکوردهای حضور و غیاب (استفاده در پردازش و ویرایش)
        private List<Attendance> _tempAttendances = [];
        #endregion

        public FrmAttendance(MainCoordinator service, AttendanceFullCalculationService calcServices)
        {
            InitializeComponent();
            _appCoordinator = service;
            _calcService = calcServices;
        }

        #region Form Events
        private void FrmAttendance_Load(object sender, EventArgs e)
        {
            DataGridConfig(PersianDateHelper.PersianCalenderDateNow());

            Userid_txtbox.DataSource = _appCoordinator.UsersList;
            CommonItems.SetDisplayAndValueMemberComboBox(ref Userid_txtbox);
        }

        //فیلترکردن بر اساس تاریخ و یوزر
        private void btn_applyFilter_Click(object sender, EventArgs e)
        {
            try
            {
                if (int.TryParse(Userid_txtbox.SelectedValue?.ToString(), out var res) ||
                    int.TryParse(Userid_txtbox.Text, out res))
                {
                    DataGridConfig(toDateTime_txtbox.Text, FromDateTime_txtbox.Text, res.ToString());
                    radioBtn_All.Checked = true;
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

        //پاک کردن فیلترها
        private void btn_clear_Click(object sender, EventArgs e)
        {
            FromDateTime_txtbox.Text = Userid_txtbox.Text = "";
            DataGridConfig(toDateTime_txtbox.Text = PersianDateHelper.PersianCalenderDateNow());
            radioBtn_All.Checked = true;
        }

        //ثبت مقادیر ورود و خروج
        private void btn_submit_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show(@"ایا از کار خود اطمینان دارید؟", @"تاییدیه", MessageBoxButtons.YesNo) == DialogResult.No) return;

                if (Validation.IsValid(Entry1_txtbox, Exit1_txtbox) == false || Entry1_txtbox.Text == Exit1_txtbox.Text)
                {
                    throw new NullReferenceException("خطا در مقادیر ورودی تردد اول");
                }

                _tempAttendances = FilterAttendances(_datetime, _user).OrderBy(x => x.DateTime).ToList();

                if (_tempAttendances == null) throw new NullReferenceException("رکوردی یافت نشد");

                //Entry 1 And Exit 1:
                ProcessFirstAttendance();

                //Entry 2 And Exit 2:
                ProcessSecondAttendance();

                CommonHelper.ShowMessage("تغییرات با موفقیت انجام شد ");

                DataGridConfig(PersianDateHelper.PersianCalenderDateNow());
            }
            catch (Exception ex)
            {
                CommonHelper.ShowMessage(ex);
            }

        }

        //انتخاب یک رکورد برای نمایش در TextBoxها
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

                Entry1_txtbox.Enabled = TimeSpan.Parse(Entry1_txtbox.Text) > _lastArrivalTime;
            }
            catch (Exception ex)
            {
                CommonHelper.ShowMessage(ex);
            }
        }

        // اعمال دوباره رنگ‌ها
        private void checkBox_ApplyStyles_CheckedChanged(object sender, EventArgs e)
        {
            dataView_Attendance.Invalidate();
        }

        //اعمال رنگ ها
        private void DataViewAttendanceRowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            try
            {
                if (dataView_Attendance.Rows.Count <= e.RowIndex) return;

                var row = dataView_Attendance.Rows[e.RowIndex];

                if (row.Cells[nameof(WorkRecord.IsLate)]?.Value is true && checkBox_Islate.Checked)
                    row.DefaultCellStyle.BackColor = Color.Red;

                else if (row.Cells[nameof(WorkRecord.IsNaghes)]?.Value is true && checkBox_Isincomplete.Checked)
                    row.DefaultCellStyle.BackColor = Color.Orange;

                else if (checkBox_workinholiday.Checked && DateTime.TryParse(
                                                            row.Cells[nameof(WorkRecord.Date)]?.Value?.ToString(),
                                                            out var date)
                                                        && _calcService.OverTimeHolidayList.Contains(date))
                    row.DefaultCellStyle.BackColor = Color.CadetBlue;
                else
                {
                    row.DefaultCellStyle.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                CommonHelper.ShowMessage(ex);
            }

        }

        //تغییر نمایش بر اساس وضعیت رکوردها.
        private void radioBtn_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (radioBtn_All.Checked)
                {
                    dataView_Attendance.DataSource = _tempRecords.ToDataTable();
                }
                else if (radioBtn_IsLate.Checked)
                {
                    dataView_Attendance.DataSource = _tempRecords.Where(x => x.IsLate).ToList().ToDataTable();
                }
                else if (radioBtn_Isincomplete.Checked)
                {
                    dataView_Attendance.DataSource = _tempRecords.Where(x => x.IsNaghes).ToList().ToDataTable();
                }
                else if (radioBtn_Attendance2.Checked)
                {
                    dataView_Attendance.DataSource = _tempRecords.Where(x => Validation.IsValid(x.EntryTime2!)).ToList().ToDataTable();
                }

            }
            catch (Exception ex)
            {
                CommonHelper.ShowMessage(ex);
            }

        }

        //شماره‌گذاری سطرها.
        private void dataView_Attendance_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var data = (DataGridView)sender;
            data.Rows[e.RowIndex].HeaderCell.Value = (e.RowIndex + 1).ToString();
        }
        #endregion

        #region Core Logic:
        // تنظیم گرید بر اساس فیلترها.
        private void DataGridConfig(string toDataTime, string fromDataTime = "1403/01/01", string userId = "0")
        {
            _tempRecords = _calcService.Calculate(userId, fromDataTime, toDataTime, false);

            dataView_Attendance.DataSource = _tempRecords.ToDataTable();

            dataView_Attendance.ApplyDisplayNames<WorkRecord>();

            dataView_Attendance.Sort(dataView_Attendance.Columns[nameof(WorkRecord.Date)]!, ListSortDirection.Ascending);
        }

        //ثبت یا به‌روزرسانی ورود و خروج دوم.
        private void ProcessSecondAttendance()
        {
            //Entry2:
            if (Validation.IsValid(Entry2_txtbox, Exit2_txtbox) && Entry2_txtbox.Text != Exit2_txtbox.Text)
            {
                if (_tempAttendances.Count > 2)
                    UpdateAttendance(_tempAttendances, 2, TimeSpan.Parse(Entry2_txtbox.Text));
                else
                    AddAttendance(_tempAttendances, 1, TimeSpan.Parse(Entry2_txtbox.Text));

                //Exit2:
                if (_tempAttendances.Count > 3)
                    UpdateAttendance(_tempAttendances, 3, TimeSpan.Parse(Exit2_txtbox.Text));
                else
                    AddAttendance(_tempAttendances, 2, TimeSpan.Parse(Exit2_txtbox.Text));
            }
            else if (Validation.IsValid(Entry2_txtbox, Exit2_txtbox) == false && _tempAttendances.Count > 2)
            {
                DeleteAttendance(_tempAttendances[2]);
            }

            if (Validation.IsValid(Entry2_txtbox, Exit2_txtbox) == false && _tempAttendances.Count > 3)
                DeleteAttendance(_tempAttendances[3]);
        }

        //ثبت یا به‌روزرسانی ورود و خروج اول.
        private void ProcessFirstAttendance()
        {
            //Entry1:
            if (_tempAttendances[0].DateTime.TimeOfDay > _lastArrivalTime)
            {
                UpdateAttendance(_tempAttendances, 0, TimeSpan.Parse(Exit1_txtbox.Text));
                AddAttendance(_tempAttendances, 0, TimeSpan.Parse(Entry1_txtbox.Text));
            }

            //Exit1:
            if (_tempAttendances.Count > 1)
                UpdateAttendance(_tempAttendances, 1, TimeSpan.Parse(Exit1_txtbox.Text));
            else
                AddAttendance(_tempAttendances, 0, TimeSpan.Parse(Exit1_txtbox.Text));
        }

        //اضافه کردن رکورد
        private void AddAttendance(List<Attendance> attendances, int index, TimeSpan tm)
        {
            var at = new Attendance
            {
                DateTime = attendances[index].DateTime.Date + tm,
                LoginType = attendances[index].LoginType,
                UserId = attendances[index].UserId
            };
            _appCoordinator.AddAttendanceRecord([at]);
            DataReloadOperation();
        }

        //اپدیت رکورد
        private void UpdateAttendance(List<Attendance> attendances, int index, TimeSpan tm)
        {
            var newDateTime = attendances[index].DateTime.Date + tm;
            attendances[index].DateTime = newDateTime;
            _appCoordinator.UpdateAttendanceRecord(attendances[index]);
            DataReloadOperation();
        }

        //حذف رکورد
        private void DeleteAttendance(Attendance attendance)
        {
            _appCoordinator.DeleteAttendanceRecord(attendance);
            DataReloadOperation();
        }

        //فیلترکردن لیست کلی بر اساس تاریخ و یوزر
        private List<Attendance> FilterAttendances(string datetime, string user) => DataFilterService.ApplyFilter(TempRecordsAttendances, datetime, datetime, int.Parse(user)).ToList();

        //بارگذاری مجدد داده‌ها بعد از تغییر
        private void DataReloadOperation() => _tempAttendances = FilterAttendances(_datetime, _user).OrderBy(x => x.DateTime).ToList();

        #endregion
    }
}
