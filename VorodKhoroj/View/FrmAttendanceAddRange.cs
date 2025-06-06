namespace VorodKhoroj.View
{
    public partial class FrmAttendanceAddRange : Form
    {
        private readonly MainCoordinator _appCoordinator;

        public FrmAttendanceAddRange(MainCoordinator mainCoordinator)
        {
            InitializeComponent();
            _appCoordinator = mainCoordinator;
        }

        private void FrmAttendanceAddRange_Load(object sender, EventArgs e)
        {
            toDateTime_txtbox.Text = PersianDateHelper.PersianCalenderDateNow();
        }

        private async void btn_applyFilter_Click(object sender, EventArgs e)
        {
            try
            {
                if (CommonHelper.IsValid(FromDateTime_txtbox, toDateTime_txtbox) == false) throw new NullReferenceException("تاریخ معتبر نمیباشد");

                using (OpenFileDialog openFileDialog = new() { Filter = @"Output Files|*.txt;*.dat;" })
                {
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {

                        using var frmProgress = new FrmProgressDialog();
                        frmProgress.Show();
                        this.Enabled = false;//قفل شدن تمام عملیات این فرم

                        int count = 0;

                        await Task.Run(() =>
                        {
                            _appCoordinator.LoadRecordsFromFile(openFileDialog.FileName, false);

                            var attendanceList = _appCoordinator.AttendancesList;

                            var filtered = DataFilterService.ApplyFilter(attendanceList, FromDateTime_txtbox.Text, toDateTime_txtbox.Text, 0).ToList();

                            AddOtherUsers(filtered);

                            AddOtherAttendances(filtered, out count);

                            _appCoordinator.LoadRecordsFromDb();
                        });
                        this.Enabled = true;
                        frmProgress.Close();

                        CommonHelper.ShowMessage($@"تعداد {count} رکورد جدید اضافه شد ");

                        Close();
                    }
                }
            }
            catch (Exception ex)
            {
                CommonHelper.ShowMessage(ex);
            }

        }

        /// <summary>
        /// مغایرت گیری تردد ها و درصورت نبودن اضافه میگردد
        /// </summary>
        /// <param name="filtered"></param>
        /// <param name="count"></param>
        /// <exception cref="InvalidOperationException"></exception>
        private void AddOtherAttendances(List<Attendance> filtered, out int count)
        {
            // هش ست خیلی پر سرعته توی جستجو
            var existingKeys = _appCoordinator.DbContext?.Attendances
                .Select(a => new { a.UserId, a.DateTime })
                .ToList() // حالا دیگه LINQ-to-Objects میشه
                .Select(x => (x.UserId, x.DateTime))
                .ToHashSet();

            // پیدا کردن رکوردهایی که وجود ندارند
            var newRecords = filtered
                .Where(a => existingKeys != null && !existingKeys.Contains((a.UserId, a.DateTime)))
                .ToList();

            _appCoordinator.AddAttendanceRecord(newRecords);
            count = newRecords.Count;
        }

        /// <summary>
        /// مغایرت گیری کاربران و درصورت نبودن اضافه میگردد
        /// </summary>
        /// <param name="filtered"></param>
        /// <exception cref="InvalidOperationException"></exception>
        private void AddOtherUsers(List<Attendance> filtered)
        {

            // کاربران موجود در دیتابیس
            var existingUsers = ((List<User>)_appCoordinator.UsersList! ?? throw new InvalidOperationException("خطای داخلی"))
                .Select(u => u.UserId)
                .ToHashSet();

            // کاربران جدید
            var newUserIds = filtered
                .Select(a => a.UserId)
                .Where(id => !existingUsers.Contains(id))
                .Distinct()
                .ToList();

            // ایجاد کاربران جدید 
            var newUsers = newUserIds
                .Select(id => new User { UserId = id })
                .ToList();

            _appCoordinator.AddUserRecord(newUsers);
        }
    }
}
