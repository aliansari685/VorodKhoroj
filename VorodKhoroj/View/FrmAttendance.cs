using System.Data;

namespace VorodKhoroj.View
{
    public partial class FrmAttendance : Form
    {
        private readonly AppCoordinator _service;

        public FrmAttendance(AppCoordinator service)
        {
            InitializeComponent();
            _service = service;
        }

        private void FrmAttendance_Load(object sender, EventArgs e)
        {
            DataGridConfig();
        }

        private void DataGridConfig()
        {
            dataView_Attendance.DataSource = _service.DbContext?.Attendances.Local.ToBindingList().OrderBy(x => x.DateTime);

            Userid_txtbox.DataSource = _service.UsersList;

            CommonItems.SetDisplayAndValueMemberComboBox(ref Userid_txtbox);

            //Todo: فردا درستش کن 
            //  dataView_Attendance.Columns[nameof(Attendance.DateTime)]!.DefaultCellStyle.Format = "yyyy/MM/dd HH:mm:ss";

            if (dataView_Attendance.Columns[nameof(Attendance.User)] is not null and var dV) dV.Visible = false;

        }

        private void btn_applyFilter_Click(object sender, EventArgs e)
        {
            try
            {
                if (CommonHelper.IsValid(_service.Records.Count) == false)
                    throw new NullReferenceException("داده ای وجود ندارد");

                if (int.TryParse(Userid_txtbox.SelectedValue?.ToString(), out var res))
                {
                    dataView_Attendance.DataSource = DataFilterService.ApplyFilter(_service.Records, FromDateTime_txtbox.Text, toDateTime_txtbox.Text, res).ToList();
                }
            }
            catch (Exception ex)
            {
                CommonHelper.ShowMessage(ex);
            }
        }
    }
}
