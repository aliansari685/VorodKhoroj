namespace VorodKhoroj.View
{
    public partial class FrmUsers : Form
    {
        private readonly AppCoordinator _services;
        public FrmUsers(AppCoordinator services)
        {
            InitializeComponent();
            _services = services;
        }
        private void FrmUsers_Load(object sender, EventArgs e)
        {
            DataGridConfig();
        }
        private void btn_submit_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show($@"آیا کاربر {Userid_txtbox.Text} با نام {UserName_txtbox.Text} ویرایش شود؟", @"تایید", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    var user = _services.DataLoaderCoordinator.DbContext!.Users.First(x => x.UserId == int.Parse(Userid_txtbox.Text));

                    user.Name = UserName_txtbox.Text;

                    _services.UpdateUserRecord(user);

                    DataGridConfig();

                    CommonHelper.ShowMessage("انجام شد");
                }
            }
            catch (Exception ex)
            {
                CommonHelper.ShowMessage(ex);
            }

        }
        private void DataGridConfig()
        {
            UserName_txtbox.Text = null;
            dataView_User.DataSource = Userid_txtbox.DataSource = _services.DataLoaderCoordinator.UsersList;
        }

        private void Userid_txtbox_SelectedValueChanged(object sender, EventArgs e)
        {
            if (CommonHelper.IsValid(Userid_txtbox.Text) == false) return;

            try
            {
                var user = _services.DataLoaderCoordinator.DbContext!.Users.First(x => x.UserId == int.Parse(Userid_txtbox.Text));
                UserName_txtbox.Text = user.Name;
            }
            catch (Exception ex)
            {
                CommonHelper.ShowMessage("پیدا نشد \n" + ex);
            }
        }
    }
}
