namespace VorodKhoroj.View;

public partial class FrmSetting : Form
{
    private bool _flag;
    private readonly AppServices _service;

    public FrmSetting(AppServices services)
    {
        InitializeComponent();
        _service = services;
    }

    private void Btn_testdb_Click(object sender, EventArgs e)
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


    private void btn_CreateDatabase_Click(object sender, EventArgs e)
    {
        try
        {
            if (_flag == false) throw new Exception("نام سرور پایگاه داده معتبر نیس");

            using SaveFileDialog _saveFile = new() { Filter = "DB Files|*.mdf", Title = "ذخیره دیتابیس" };
            if (_saveFile.ShowDialog() == DialogResult.OK)
            {
                var dbname = Path.GetFileNameWithoutExtension(_saveFile.FileName);

                _service.InitializeDbContext(txt_ServerName.Text, dbname, AppDbContext.DataBaseLocation.InternalDataBase);

                _service.HandleCreateDatabase(_saveFile.FileName);

                _service.HandleCreateTables();

                _service.AddAttendancesRecord(_service.Records);

                _service.HandleDetachDatabase(_saveFile.FileName);

                CommonHelper.ShowMessage("دیتابیس با موفقیت ایجاد و داده‌ها منتقل شدند!");
            }
        }
        catch (Exception ex)
        {
            CommonHelper.ShowMessage(ex);
        }
    }
}