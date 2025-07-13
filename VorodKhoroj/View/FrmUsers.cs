using VorodKhoroj.Application.Coordinators;

namespace VorodKhoroj.View;

/// <summary>
/// فرم مدیریت کاربران (ویرایش نام کاربران ثبت‌شده).
/// </summary>
public partial class FrmUsers : Form
{
    /// <summary>
    /// هماهنگ‌کننده اصلی برنامه برای دسترسی به دیتابیس و لیست کاربران.
    /// </summary>
    private readonly MainCoordinator _appCoordinator;

    /// <summary>
    /// سازنده فرم مدیریت کاربران.
    /// </summary>
    /// <param name="mainCoordinator">هماهنگ‌کننده اصلی برنامه</param>
    public FrmUsers(MainCoordinator mainCoordinator)
    {
        InitializeComponent();
        _appCoordinator = mainCoordinator;
    }

    #region Events

    /// <summary>
    /// هنگام لود شدن فرم، دیتاگرید مقداردهی می‌شود.
    /// </summary>
    private void FrmUsers_Load(object sender, EventArgs e)
    {
        RefreshUserGrid();
    }

    /// <summary>
    /// رویداد کلیک روی دکمه "ثبت" جهت ویرایش نام کاربر انتخاب‌شده.
    /// </summary>
    private void btn_submit_Click(object sender, EventArgs e)
    {
        try
        {
            if (MessageBox.Show(
                    $@"آیا کاربر {Userid_txtbox.Text} با نام {UserName_txtbox.Text} ویرایش شود؟",
                    @"تایید",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            var userId = int.Parse(Userid_txtbox.Text);
            var user = ((List<User>)_appCoordinator.UsersList!).First(x => x.UserId == userId);
            user.Name = UserName_txtbox.Text;

            _appCoordinator.UpdateUserRecord(user);

            RefreshUserGrid();
            CommonHelper.ShowMessage("انجام شد");
        }
        catch (Exception ex)
        {
            CommonHelper.ShowMessage(ex);
        }
    }

    /// <summary>
    /// رویداد انتخاب آیتم از لیست کاربران جهت نمایش نام کاربر.
    /// </summary>
    private void Userid_txtbox_SelectedValueChanged(object sender, EventArgs e)
    {
        if (!CommonHelper.IsValid(Userid_txtbox.Text)) return;

        try
        {
            var userId = int.Parse(Userid_txtbox.Text);
            var user = ((List<User>)_appCoordinator.UsersList!).First(x => x.UserId == userId);
            UserName_txtbox.Text = user.Name;
        }
        catch (Exception ex)
        {
            CommonHelper.ShowMessage("پیدا نشد \n" + ex);
        }
    }

    #endregion

    #region Helpers
    /// <summary>
    /// بازنشانی دیتاگرید و لیست کاربران و پاک‌سازی آنها
    /// </summary>
    private void RefreshUserGrid()
    {
        UserName_txtbox.Text = null;
        var userList = _appCoordinator.UsersList;
        dataView_User.DataSource = userList;
        Userid_txtbox.DataSource = userList;
    }

    #endregion
}