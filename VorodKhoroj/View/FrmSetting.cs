namespace VorodKhoroj.View;

public partial class FrmSetting : Form
{
    private bool _flag;
    private readonly AppCoordinator _service;
    private readonly CommonItems _cm = new();

    public FrmSetting(AppCoordinator services)
    {
        InitializeComponent();
        _service = services;
    }
    private void FrmSetting_Load(object sender, EventArgs e)
    {
        _cm.LoadServerListFromFile(ref txt_ServerName);

        _cm.ItemClicked += (_, _) => _cm.LoadServerListFromFile(ref txt_ServerName);

        txt_ServerName.ContextMenuStrip = _cm.MenuStrip;
    }

    private void Btn_testDb_Click(object sender, EventArgs e)
    {
        try
        {
            if (_service.TestServerName(txt_ServerName.Text))
            {
                _flag = true;
                CommonHelper.ShowMessage(@"اتصال با موفقیت انجام شد");
            }
        }
        catch (Exception ex)
        {
            CommonHelper.ShowMessage(ex);
        }
    }

    private void txt_ServerName_MouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Right)
        {
            _cm.Text = txt_ServerName.Text;
            _cm.MenuStrip.Show(Cursor.Position);
        }
    }
    private async void btn_CreateDatabase_Click(object sender, EventArgs e)
    {
        try
        {
            if (_flag == false) throw new Exception("نام سرور پایگاه داده معتبر نیس ، لطفا اول تست کنید");

            using SaveFileDialog saveFile = new() { Filter = "DB Files|*.mdf", Title = "ذخیره دیتابیس" };
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                using var frmProgress = new FrmProgressDialog();
                frmProgress.Show();
                this.Enabled = false;//قفل شدن تمام عملیات این فرم
                var serverName = txt_ServerName.Text;

                await Task.Run(() =>
                {
                    _service.DbName = Path.GetFileNameWithoutExtension(saveFile.FileName); //exam:db
                    _service.DbPathName = saveFile.FileName; //exam: d://db.mdf

                    _service.HandleCreateDatabase();

                    _service.InitializeDbContext(serverName, AppDbContext.DataBaseLocation.InternalDataBase);

                    _service.HandleCreateTables();

                    _service.CopyAttendancesRecord(_service.Records);

                    _service.HandleDetachDatabase();
                });
                this.Enabled = true;
                frmProgress.Close();

                CommonHelper.ShowMessage("دیتابیس با موفقیت ایجاد و داده‌ها منتقل شدند!");
            }
        }
        catch (Exception ex)
        {
            CommonHelper.ShowMessage(ex);
            this.Enabled = true;
        }
    }
}