namespace VorodKhoroj.View
{
    public partial class FrmFilterMonthly : Form
    {
        private readonly MainCoordinator _appCoordinator;
        private readonly AttendanceFullCalculationService _calcServices;
        private string _userId;

        public FrmFilterMonthly(MainCoordinator mainCoordinator, AttendanceFullCalculationService calcServices, string userId)
        {
            InitializeComponent();
            _appCoordinator = mainCoordinator;
            _calcServices = calcServices;
            _userId = userId;
        }

        private void FrmFilter_Monthly_Load(object sender, EventArgs e)
        {
            userid_txtbox.DataSource = _appCoordinator.UsersList;
            if (_appCoordinator is { UsersListProvider: DbProvider })
            {
                CommonItems.SetDisplayAndValueMemberComboBox(ref userid_txtbox);
            }
        }
        private void btn_clear_Click(object sender, EventArgs e)
        {
            checkBox_esfand.Checked = checkBox_bahman.Checked = checkBox_dey.Checked = checkBox_azar.Checked = checkBox_aban.Checked = checkBox_mehr.Checked = checkBox_shahrivar.Checked = checkBox_mordad.Checked = checkBox_tir.Checked = checkBox_khordad.Checked = checkBox_ordibehesht.Checked = checkBox_farvardin.Checked = false;
        }

        private void Btn_CheckAll_Click(object sender, EventArgs e)
        {
            checkBox_esfand.Checked = checkBox_bahman.Checked = checkBox_dey.Checked = checkBox_azar.Checked = checkBox_aban.Checked = checkBox_mehr.Checked = checkBox_shahrivar.Checked = checkBox_mordad.Checked = checkBox_tir.Checked = checkBox_khordad.Checked = checkBox_ordibehesht.Checked = checkBox_farvardin.Checked = true;
        }

        private async void Btn_submit_Click(object sender, EventArgs e)
        {
            try
            {
                var monthList = GetMonthlyCheckedList().Where(m => m.Value).Select(m => m.Key).ToList();

                _userId = CommonItems.GetUserIdValueToString(userid_txtbox);

                using SaveFileDialog sfd = new() { Filter = "Excel Files|*.xlsx", Title = "ذخیره فایل اکسل" };

                if (sfd.ShowDialog() == DialogResult.OK)
                {

                    if (_userId == "0" || checkBox_allusers.Checked)
                    {
                        await AllUsers(sfd, monthList);
                    }
                    else
                    {
                        DataExporter.ExportAttendanceData(_userId, int.Parse(txtbox_year.Text), monthList, checkBox_withlabels.Checked, sfd.FileName, _calcServices);
                    }

                    CommonHelper.ShowMessage("فایل اکسل شامل تمام ماه‌ها با موفقیت ذخیره شد!");
                }
            }
            catch (Exception ex)
            {
                CommonHelper.ShowMessage(ex);
            }
        }

        private async Task AllUsers(SaveFileDialog sfd, List<int> monthList)
        {
            var userid = _appCoordinator.UsersList ?? throw new NullReferenceException("شی خالی است");

            //For Save Path Files
            var directory = Path.GetDirectoryName(sfd.FileName);
            var fileNameWithoutExt = Path.GetFileNameWithoutExtension(sfd.FileName);
            var extension = Path.GetExtension(sfd.FileName);
            var fullPath = sfd.FileName;

            // ===== Main Process =====
            using var frmProgress = new FrmProgressDialog(userid.Count);
            frmProgress.Show();

            this.Enabled = false;//قفل شدن تمام عملیات این فرم

            await Task.Run(() =>
            {
                for (var index = 0; index < userid.Count; index++)
                {
                    var coll = userid[index];
                    if (directory != null)
                        fullPath = Path.Combine(directory, $"{fileNameWithoutExt}_{coll}{extension}");

                    DataExporter.ExportAttendanceData(coll?.ToString() ?? string.Empty, int.Parse(txtbox_year.Text), monthList, checkBox_withlabels.Checked, fullPath, _calcServices);

                    frmProgress.SetValue(index + 1);
                }
            });

            this.Enabled = true;
            frmProgress.Close();
        }

        private Dictionary<int, bool> GetMonthlyCheckedList()
        {
            return new()
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
        }

        private void checkBox_allUsers_CheckedChanged(object sender, EventArgs e)
        {
            userid_txtbox.Enabled = !checkBox_allusers.Checked;
        }
    }
}
