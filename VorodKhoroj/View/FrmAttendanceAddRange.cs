namespace VorodKhoroj.View
{
    public partial class FrmAttendanceAddRange : Form
    {
        #region Fields

        /// <summary>
        /// هماهنگ‌کننده‌ی اصلی برنامه برای ارتباط بین لایه‌ها
        /// </summary>
        private readonly AppServices _appCoordinator;

        #endregion

        #region Form Events

        /// <summary>
        /// سازنده‌ی فرم و مقداردهی اولیه هماهنگ‌کننده‌ی برنامه
        /// </summary>
        /// <param name="appServices">هماهنگ‌کننده‌ی برنامه</param>
        public FrmAttendanceAddRange(AppServices appServices)
        {
            InitializeComponent();
            _appCoordinator = appServices;
        }

        /// <summary>
        /// رویداد لود فرم - مقداردهی اولیه تاریخ به روز جاری
        /// </summary>
        private void FrmAttendanceAddRange_Load(object sender, EventArgs e) => toDateTime_txtbox.Text = PersianDateHelper.PersianCalenderDateNow();

        /// <summary>
        /// رویداد کلیک بر روی دکمه اعمال فیلتر و پردازش فایل ورودی
        /// </summary>
        private async void btn_addRange_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validation.IsValid(FromDateTime_txtbox, toDateTime_txtbox) == false)
                    throw new NullReferenceException("تاریخ معتبر نمیباشد");

                using var openFile = CommonItems.CreateOpenFileDialog(@"Output Files|*.txt;*.dat;");
                if (openFile.ShowDialog() != DialogResult.OK) return;

                using var frmProgress = new FrmProgressDialog();
                frmProgress.Show();
                this.Enabled = false; // قفل شدن تمام عملیات این فرم

                int count = 0;

                await Task.Run(() =>
                {
                    _appCoordinator.DataLoaderCoordinator.LoadFromFile(openFile.FileName, false);

                    var attendanceList = _appCoordinator.DataLoaderCoordinator.AttendancesRecords;

                    var filtered = AttendanceRecordFilter.ApplyFilter(attendanceList, FromDateTime_txtbox.Text,
                        toDateTime_txtbox.Text, 0).ToList();

                    AddOtherUsers(filtered);

                    AddOtherAttendances(filtered, out count);
                });
                frmProgress.Close();

                CommonHelper.ShowMessage($@"تعداد {count} رکورد جدید اضافه شد ");
                Close();
            }
            catch (Exception ex)
            {
                CommonHelper.ShowMessage(ex);
            }
            finally
            {
                this.Enabled = true;
            }
        }

        #endregion

        #region Core Logic

        /// <summary>
        /// بررسی مغایرت در رکوردهای تردد و اضافه کردن رکوردهای جدید در صورت نبود
        /// </summary>
        /// <param name="filtered">لیست ترددهای فیلتر شده</param>
        /// <param name="count">تعداد رکوردهای جدید اضافه شده</param>
        private void AddOtherAttendances(List<Attendance> filtered, out int count)
        {
            // هش ست خیلی پرسرعت برای جستجو
            var existingKeys = _appCoordinator.DataLoaderCoordinator.AttendancesRecords
                .Select(a => new { a.UserId, a.DateTime })
                .ToList()
                .Select(x => (x.UserId, x.DateTime))
                .ToHashSet();

            // پیدا کردن رکوردهایی که در دیتابیس نیستند
            var newRecords = filtered
                .Where(a => !existingKeys.Contains((a.UserId, a.DateTime)))
                .ToList();

            _appCoordinator.AttendanceDataService.AddAttendance(newRecords);
            count = newRecords.Count;
        }

        /// <summary>
        /// بررسی مغایرت در کاربران و اضافه کردن کاربران جدید در صورت نبود
        /// </summary>
        /// <param name="filtered">لیست ترددهای فیلتر شده برای استخراج کاربران</param>
        private void AddOtherUsers(List<Attendance> filtered)
        {
            // کاربران موجود در دیتابیس

            var existingUsers = ((List<User>)_appCoordinator.DataLoaderCoordinator.UserList ?? throw new InvalidOperationException("خطای داخلی"))
                .Select(u => u.UserId)
                .ToHashSet();

            // کاربران جدیدی که در دیتابیس نیستند
            var newUserIds = filtered
                .Select(a => a.UserId)
                .Where(id => !existingUsers.Contains(id))
                .Distinct()
                .ToList();

            // ایجاد لیست کاربران جدید
            var newUsers = newUserIds
                .Select(id => new User { UserId = id })
                .ToList();

            _appCoordinator.UserDataService.AddUser(newUsers);

        }
        #endregion
    }
}