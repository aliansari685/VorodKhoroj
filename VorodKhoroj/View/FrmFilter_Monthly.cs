namespace VorodKhoroj.View
{
    public partial class FrmFilterMonthly : Form
    {
        #region Fields

        /// <summary>
        /// هماهنگ‌کننده‌ی اصلی برنامه برای مدیریت کاربران
        /// </summary>
        private readonly MainCoordinator _appCoordinator;

        /// <summary>
        /// سرویس محاسبات کامل حضور و غیاب
        /// </summary>
        private readonly AttendanceFullCalculationService _calcServices;

        /// <summary>
        /// شناسه‌ی کاربر انتخاب شده
        /// </summary>
        private string _userId;

        #endregion


        /// <summary>
        /// سازنده فرم فیلتر ماهانه
        /// </summary>
        public FrmFilterMonthly(MainCoordinator mainCoordinator, AttendanceFullCalculationService calcServices, string userId)
        {
            InitializeComponent();
            _appCoordinator = mainCoordinator;
            _calcServices = calcServices;
            _userId = userId;
        }
        #region Form Events
        /// <summary>
        /// بارگذاری اولیه فرم و تنظیم منابع ComboBox
        /// </summary>
        private void FrmFilter_Monthly_Load(object sender, EventArgs e)
        {
            userid_txtbox.DataSource = _appCoordinator.UsersList;

            if (_appCoordinator is { UsersListProvider: DbProvider })
                CommonItems.SetDisplayAndValueMemberComboBox(ref userid_txtbox);
        }

        /// <summary>
        /// دکمه پاکسازی: از تیک درآوردن تمام چک‌باکس‌های ماه‌ها
        /// </summary>
        private void btn_clear_Click(object sender, EventArgs e)
        {
            checkBox_esfand.Checked = checkBox_bahman.Checked = checkBox_dey.Checked = checkBox_azar.Checked = checkBox_aban.Checked = checkBox_mehr.Checked = checkBox_shahrivar.Checked = checkBox_mordad.Checked = checkBox_tir.Checked = checkBox_khordad.Checked = checkBox_ordibehesht.Checked = checkBox_farvardin.Checked = false;
        }

        /// <summary>
        /// دکمه انتخاب همه: تیک زدن همه‌ی ماه‌ها
        /// </summary>
        private void Btn_CheckAll_Click(object sender, EventArgs e)
        {
            checkBox_esfand.Checked = checkBox_bahman.Checked = checkBox_dey.Checked = checkBox_azar.Checked = checkBox_aban.Checked = checkBox_mehr.Checked = checkBox_shahrivar.Checked = checkBox_mordad.Checked = checkBox_tir.Checked = checkBox_khordad.Checked = checkBox_ordibehesht.Checked = checkBox_farvardin.Checked = true;
        }

        /// <summary>
        /// ارسال اطلاعات و ساخت فایل خروجی اکسل
        /// </summary>
        private async void Btn_submit_Click(object sender, EventArgs e)
        {
            try
            {
                var monthList = GetMonthlyCheckedList().Where(m => m.Value).Select(m => m.Key).ToList();
                _userId = CommonItems.GetUserIdValueToString(userid_txtbox);

                using var saveFile = CommonItems.CreateSaveFileDialog(@"Excel Files|*.xlsx");
                if (saveFile.ShowDialog() != DialogResult.OK) return;

                if (_userId == "0" || checkBox_allusers.Checked)
                    await ExportForAllUsersAsync(saveFile.FileName, monthList);
                else
                    DataExporter.ExportAttendanceData(_userId, int.Parse(txtbox_year.Text), monthList, checkBox_withlabels.Checked, saveFile.FileName, _calcServices);

                CommonHelper.ShowMessage("فایل اکسل شامل تمام ماه‌ها با موفقیت ذخیره شد!");
            }
            catch (Exception ex)
            {
                CommonHelper.ShowMessage(ex);
            }
        }

        /// <summary>
        /// فعال یا غیرفعال کردن لیست کاربران در صورت انتخاب گزینه همه کاربران
        /// </summary>
        private void checkBox_allUsers_CheckedChanged(object sender, EventArgs e) => userid_txtbox.Enabled = !checkBox_allusers.Checked;
        #endregion

        #region Core Logic
        /// <summary>
        /// دریافت لیست ماه‌های تیک‌خورده
        /// </summary>
        private Dictionary<int, bool> GetMonthlyCheckedList() => new()
        {
            { 1, checkBox_farvardin.Checked },
            { 2, checkBox_ordibehesht.Checked },
            { 3, checkBox_khordad.Checked },
            { 4, checkBox_tir.Checked },
            { 5, checkBox_mordad.Checked },
            { 6, checkBox_shahrivar.Checked },
            { 7, checkBox_mehr.Checked },
            { 8, checkBox_aban.Checked },
            { 9, checkBox_azar.Checked },
            { 10, checkBox_dey.Checked },
            { 11, checkBox_bahman.Checked },
            { 12, checkBox_esfand.Checked }
        };

        /// <summary>
        /// خروجی گرفتن اطلاعات حضور و غیاب برای همه‌ی کاربران
        /// </summary>
        private async Task ExportForAllUsersAsync(string fileName, List<int> monthList)
        {
            var userList = _appCoordinator.UsersList ?? throw new NullReferenceException("شی خالی است");

            var directory = Path.GetDirectoryName(fileName);
            var baseName = Path.GetFileNameWithoutExtension(fileName);
            var extension = Path.GetExtension(fileName);

            using var frmProgress = new FrmProgressDialog(userList.Count);
            frmProgress.Show();
            this.Enabled = false;

            await Task.Run(() =>
            {
                for (int i = 0; i < userList.Count; i++)
                {
                    var user = userList[i];
                    var fullPath = Path.Combine(directory ?? "", $"{baseName}_{user}{extension}");

                    DataExporter.ExportAttendanceData(user?.ToString() ?? "", int.Parse(txtbox_year.Text), monthList, checkBox_withlabels.Checked, fullPath, _calcServices);
                    frmProgress.SetValue(i + 1);
                }
            });

            this.Enabled = true;
            frmProgress.Close();
        }

        #endregion
    }
}