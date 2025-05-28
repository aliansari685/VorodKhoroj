namespace VorodKhoroj.View;

public partial class FrmSetSource : Form
{
    private readonly MainCoordinator _appCoordinator;

    private readonly CommonItems _cm = new();

    public FrmSetSource(MainCoordinator mainCoordinator)
    {
        InitializeComponent();
        _appCoordinator = mainCoordinator;
    }
    private void FrmSetSource_Load(object sender, EventArgs e)
    {
        txt_ServerName.Enabled = radiobtn_database.Checked;

        _cm.LoadServerListFromFile(ref txt_ServerName);

        _cm.ItemClicked += (_, _) => _cm.LoadServerListFromFile(ref txt_ServerName);

        txt_ServerName.ContextMenuStrip = _cm.MenuStrip;
    }

    private void btn_submit_Click(object sender, EventArgs e)
    {
        try
        {
            if (radiobtn_textfile.Checked)
            {
                using var openFile = new OpenFileDialog { Filter = @"Output Files|*.txt;*.dat;" };
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    _appCoordinator.LoadRecordsFromFile(openFile.FileName);

                    Close();
                }
            }

            if (radiobtn_database.Checked)
            {
                if (_appCoordinator is { UsersListProvider: DbProvider })
                    throw new InvalidOperationException(
                        "لطفا ارتباط قبلی خود را قطع کنید ، برای اینکار میتوانید در تنظیمات از دکمه راه اندازی مجدد استفاده کنید");

                if (!CommonHelper.IsValid(txt_ServerName.Text) || !_appCoordinator.TestServerName(txt_ServerName.Text))
                    throw new ArgumentNullException($"خطا در نام سرور پایگاه داده");

                using var openFile = new OpenFileDialog { Filter = @"DB Files|*.mdf" };
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    _appCoordinator.SetDbPath(openFile.FileName);

                    _appCoordinator.SetDbName(openFile.FileName);

                    _appCoordinator.InitializeDbContext(txt_ServerName.Text, AppDbContext.DataBaseLocation.AttachDbFilename);

                    _appCoordinator.MigrationsEnsureDatabaseUpToDate();

                    _appCoordinator.LoadRecordsFromDb();

                    Close();
                }
            }
        }
        catch (Exception ex)
        {
            CommonHelper.ShowMessage(ex);
        }
    }

    private void radioBtn_database_CheckedChanged(object sender, EventArgs e)
    {
        txt_ServerName.Enabled = radiobtn_database.Checked;
    }

    private void txt_ServerName_MouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Right)
        {
            _cm.Text = txt_ServerName.Text;
            _cm.MenuStrip.Show(Cursor.Position);
        }
    }
}