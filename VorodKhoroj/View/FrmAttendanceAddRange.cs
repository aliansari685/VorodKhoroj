namespace VorodKhoroj.View
{
    public partial class FrmAttendanceAddRange : Form
    {
        private readonly AppCoordinator _services;

        public FrmAttendanceAddRange(AppCoordinator services)
        {
            InitializeComponent();
            _services = services;
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
                            _services.LoadRecordsFromFile(openFileDialog.FileName, false);

                            var attendanceList = _services.Records;

                            var filtered = DataFilterService.ApplyFilter(attendanceList, FromDateTime_txtbox.Text, toDateTime_txtbox.Text, 0).ToList();

                            AddOtherUsers(filtered);

                            AddOtherAttendances(filtered, ref count);

                            _services.LoadRecordsFromDb();
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
        private void AddOtherAttendances(List<Attendance> filtered, ref int count)
        {
            // هش ست خیلی پر سرعته توی جستجو
            var existingKeys = _services.DbContext?.Attendances
                .Select(a => new { a.UserId, a.DateTime })
                .ToHashSet();

            // پیدا کردن رکوردهایی که وجود ندارند
            var newRecords = filtered
                .Where(a => !existingKeys!.Contains(new { a.UserId, a.DateTime }))
                .ToList();
            _services.AddAttendanceRecord(newRecords);
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
            var existingUsers = ((List<User>)_services.UsersList! ?? throw new InvalidOperationException("خطای داخلی"))
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
                .Select(id => new User { UserId = id }) // اگر فقط آیدی داری
                .ToList();

            _services.AddUserRecord(newUsers);
        }
    }
}
