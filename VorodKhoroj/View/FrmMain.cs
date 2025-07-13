using VorodKhoroj.Application.Coordinators;
using VorodKhoroj.Application.Services;
using VorodKhoroj.Domain.Interfaces;

namespace VorodKhoroj
{
    public partial class FrmMain : Form
    {
        #region Fields

        /// <summary>
        /// وضعیت ریستارت شدن برنامه
        /// </summary>
        private bool _isRestarting;

        /// <summary>
        /// هماهنگ‌کننده‌ی اصلی برنامه برای مدیریت داده‌ها
        /// </summary>
        private readonly MainCoordinator _appCoordinator;

        /// <summary>
        /// سرویس محاسبه‌ی کامل حضور و غیاب
        /// </summary>
        private readonly AttendanceFullCalculationService _calcServices;

        #endregion

        public FrmMain(MainCoordinator mainCoordinator, AttendanceFullCalculationService calculationService)
        {
            InitializeComponent();
            _appCoordinator = mainCoordinator;
            _calcServices = calculationService;
        }
        private void Frm_Main_Load(object sender, EventArgs e) => TextBoxClear();

        #region Grid Operations
        /// <summary>
        /// بارگذاری دیتا در دیتاگرید و تنظیمات اولیه
        /// </summary>
        public void DataGridConfig()
        {
            if (!CommonHelper.IsValid(_appCoordinator.AttendancesList.Count)) return;

            dataView.DataSource = _appCoordinator.AttendancesList.ToDataTableWithDisplayedName();
            Userid_txtbox.DataSource = _appCoordinator.UsersList;

            if (_appCoordinator is { UsersListProvider: DbProvider })
                CommonItems.SetDisplayAndValueMemberComboBox(ref Userid_txtbox);

            DataGridViewConfig();
        }

        /// <summary>
        /// تنظیم فرمت ستون‌ها در دیتاگرید
        /// </summary>
        private void DataGridViewConfig()
        {
            dataView.Columns[2].DefaultCellStyle.Format = "yyyy/MM/dd HH:mm:ss";

            if (dataView.Columns[nameof(Attendance.Id)] is not null and var dV)
                dV.Visible = false;
        }

        /// <summary>
        /// رفرش و بارگذاری مجدد اطلاعات
        /// </summary>
        private void ReloadGrid()
        {
            TextBoxClear();
            DataGridConfig();
        }
        /// <summary>
        /// نمایش شماره ردیف در DataGridView
        /// </summary>
        public void dataView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e) => dataView.Rows[e.RowIndex].HeaderCell.Value = (e.RowIndex + 1).ToString();

        #endregion

        #region Filter Operations

        /// <summary>
        /// اعمال فیلتر بر اساس تاریخ و شناسه کاربر
        /// </summary>
        private void Btn_ApplyFilter_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CommonHelper.IsValid(_appCoordinator.AttendancesList.Count))
                    throw new NullReferenceException("داده ای وجود ندارد");

                var filtered = DataFilterService.ApplyFilter(
                    _appCoordinator.AttendancesList,
                    FromDateTime_txtbox.Text,
                    toDateTime_txtbox.Text,
                    int.Parse(CommonItems.GetUserIdValueToString(Userid_txtbox))
                ).ToList().ToDataTableWithDisplayedName();

                dataView.DataSource = filtered;
                DataGridViewConfig();
            }
            catch (Exception ex)
            {
                CommonHelper.ShowMessage(ex);
            }
        }

        /// <summary>
        /// پاک‌سازی فیلدهای فیلتر
        /// </summary>
        private void btn_clear_Click(object sender, EventArgs e) => ReloadGrid();

        /// <summary>
        /// تنظیم اولیه مقادیر TextBox ها
        /// </summary>
        private void TextBoxClear()
        {
            FromDateTime_txtbox.Text = Userid_txtbox.Text = "";
            toDateTime_txtbox.Text = PersianDateHelper.PersianCalenderDateNow();
        }

        #endregion

        #region ToolStrip Menu Items

        private void DetailReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CommonHelper.IsValid(_appCoordinator.AttendancesList.Count))
                    throw new ArgumentNullException($"داده ای وجود ندارد");

                using FrmFilter frm = new(_appCoordinator, _calcServices, FromDateTime_txtbox.Text, toDateTime_txtbox.Text, Userid_txtbox.Text);
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                CommonHelper.ShowMessage(ex);
            }
        }

        private void MonthlyReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using FrmFilterMonthly frm = new(_appCoordinator, _calcServices, Userid_txtbox.Text);
            frm.ShowDialog();
        }

        private void FastExportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CommonHelper.IsValid(_appCoordinator.AttendancesList.Count))
                    throw new ArgumentNullException($"داده ای وجود ندارد");

                var date = $"{PersianDateHelper.PersianCalendar.GetYear(DateTime.Now)}/{PersianDateHelper.PersianCalendar.GetMonth(DateTime.Now):D2}/{(PersianDateHelper.PersianCalendar.GetDayOfMonth(DateTime.Now) - 1):D2}";

                using FrmFilter frm = new(_appCoordinator, _calcServices, date, date, Userid_txtbox.Text, FrmReport.XGridExport.CalculateGrid);
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                CommonHelper.ShowMessage(ex);
            }
        }

        private void DBConfigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CommonHelper.IsValid(dataView.Rows.Count))
                    throw new ArgumentNullException($"داده ای وجود ندارد");

                using FrmSetting frm = new(_appCoordinator);
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                CommonHelper.ShowMessage(ex);
            }
        }

        private void SwitchDataSourceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using (FrmSetSource frm = new(_appCoordinator))
                {
                    dataView.DataSource = null;
                    frm.ShowDialog();
                }

                DataGridConfig();
            }
            catch (Exception ex)
            {
                CommonHelper.ShowMessage(ex);
            }
        }

        private void UsersEditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_appCoordinator is { UsersListProvider: DbProvider, DbContext: not null })
            {
                using var frm = new FrmUsers(_appCoordinator);
                frm.ShowDialog();
                ReloadGrid();
            }
            else
            {
                CommonHelper.ShowMessage("پایگاه داده وجود ندارد . لطفا منبع داده ها رو پایگاه داده انتخاب کنید");
            }
        }

        private void AttendanceEditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_appCoordinator is { DbContext: not null, UsersListProvider: DbProvider, AttendancesList.Count: not 0 })
            {
                using var frm = new FrmAttendance(_appCoordinator, _calcServices);
                frm.ShowDialog();
                ReloadGrid();
            }
            else
            {
                CommonHelper.ShowMessage("پایگاه داده وجود ندارد . لطفا منبع داده ها رو پایگاه داده انتخاب کنید");
            }
        }

        private void AddAttendanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_appCoordinator is { DbContext: not null, UsersListProvider: DbProvider, AttendancesList.Count: not 0 })
            {
                using var frm = new FrmAttendanceAddRange(_appCoordinator);
                frm.ShowDialog();
                ReloadGrid();
            }
            else
            {
                CommonHelper.ShowMessage("پایگاه داده وجود ندارد . لطفا منبع داده ها رو پایگاه داده انتخاب کنید");
            }
        }

        private void AppRestartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _isRestarting = true;
            Application.Restart();
        }

        private void Frm_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_isRestarting) return;

            if (MessageBox.Show("آیا می‌خواهید از برنامه خارج شوید؟", "خروج", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                e.Cancel = true;
        }

        private void MorakhasiReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CommonHelper.IsValid(_appCoordinator.AttendancesList.Count))
                    throw new ArgumentNullException($"داده ای وجود ندارد");

                using FrmFilter frm = new(_appCoordinator, _calcServices, FromDateTime_txtbox.Text, toDateTime_txtbox.Text, Userid_txtbox.Text, FrmReport.XGridExport.LateGrid);
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                CommonHelper.ShowMessage(ex);
            }
        }
        #endregion
    }
}
