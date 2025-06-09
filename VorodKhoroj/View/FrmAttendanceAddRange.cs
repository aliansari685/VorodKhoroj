namespace VorodKhoroj.View
{
    public partial class FrmAttendanceAddRange : Form
    {
        #region Fields

        /// <summary>
        /// هماهنگ‌کننده‌ی اصلی برنامه برای ارتباط بین لایه‌ها
        /// </summary>
        private readonly MainCoordinator _appCoordinator;

        #endregion

        #region Form Events

        /// <summary>
        /// سازنده‌ی فرم و مقداردهی اولیه هماهنگ‌کننده‌ی برنامه
        /// </summary>
        /// <param name="mainCoordinator">هماهنگ‌کننده‌ی برنامه</param>
        public FrmAttendanceAddRange(MainCoordinator mainCoordinator)
        {
            InitializeComponent();
            _appCoordinator = mainCoordinator;
        }

        /// <summary>
        /// رویداد لود فرم - مقداردهی اولیه تاریخ به روز جاری
        /// </summary>
        private void FrmAttendanceAddRange_Load(object sender, EventArgs e)
        {
            toDateTime_txtbox.Text = PersianDateHelper.PersianCalenderDateNow();
        }

        /// <summary>
        /// رویداد کلیک بر روی دکمه اعمال فیلتر و پردازش فایل ورودی
        /// </summary>
        private async void btn_addRange_Click(object sender, EventArgs e)
        {
            try
            {
                if (CommonHelper.IsValid(FromDateTime_txtbox, toDateTime_txtbox) == false)
                    throw new NullReferenceException("تاریخ معتبر نمیباشد");

                using (OpenFileDialog openFileDialog = new() { Filter = @"Output Files|*.txt;*.dat;" })
                {
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        using var frmProgress = new FrmProgressDialog();
                        frmProgress.Show();
                        this.Enabled = false; // قفل شدن تمام عملیات این فرم

                        int count = 0;

                        await Task.Run(() =>
                        {
                            _appCoordinator.LoadRecordsFromFile(openFileDialog.FileName, false);

                            var attendanceList = _appCoordinator.AttendancesList;

                            var filtered = DataFilterService.ApplyFilter(attendanceList, FromDateTime_txtbox.Text,
                                toDateTime_txtbox.Text, 0).ToList();

                            AddOtherUsers(filtered);

                            AddOtherAttendances(filtered, out count);

                            _appCoordinator.LoadRecordsFromDb();
                        });
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
            var existingKeys = _appCoordinator.DbContext?.Attendances
                .Select(a => new { a.UserId, a.DateTime })
                .ToList() // حالا دیگه LINQ-to-Objects میشه
                .Select(x => (x.UserId, x.DateTime))
                .ToHashSet();

            // پیدا کردن رکوردهایی که در دیتابیس نیستند
            var newRecords = filtered
                .Where(a => existingKeys != null && !existingKeys.Contains((a.UserId, a.DateTime)))
                .ToList();

            _appCoordinator.AddAttendanceRecord(newRecords);
            count = newRecords.Count;
        }

        /// <summary>
        /// بررسی مغایرت در کاربران و اضافه کردن کاربران جدید در صورت نبود
        /// </summary>
        /// <param name="filtered">لیست ترددهای فیلتر شده برای استخراج کاربران</param>
        private void AddOtherUsers(List<Attendance> filtered)
        {
            // کاربران موجود در دیتابیس
            var existingUsers = ((List<User>)_appCoordinator.UsersList! ?? throw new InvalidOperationException("خطای داخلی"))
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

            _appCoordinator.AddUserRecord(newUsers);
        }

        #endregion
    }
}