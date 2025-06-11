namespace VorodKhoroj.Helpers
{
    /// <summary>
    /// کلاس اشیای پر استفاده در ویندوز فرم 
    /// </summary>
    public class CommonItems
    {
        /// <summary>
        /// مسیر فایل متنی لیست سرورها
        /// </summary>
        public static readonly string Path = Application.StartupPath + @"\tmpFile\serverList.txt";

        /// <summary>
        /// متنی که به لیست اضافه می‌شود
        /// </summary>
        public string Text { get; set; } = "";

        /// <summary>
        /// منوی کلیک راست برای آیتم‌ها
        /// </summary>
        public ContextMenuStrip MenuStrip { get; } = new();

        /// <summary>
        /// رویداد کلیک شدن آیتم منو
        /// </summary>
        public event EventHandler? ItemClicked;

        /// <summary>
        /// سازنده کلاس که آیتم منوی "افزودن به لیست" را اضافه می‌کند
        /// </summary>
        public CommonItems()
        {
            var addItem = new ToolStripMenuItem
            {
                Name = "AddItemMenuItem",
                Size = new Size(180, 22),
                Text = @"افزودن به لیست"
            };

            addItem.Click += (_, _) =>
            {
                File.AppendAllLines(Path, [Text]); // اضافه کردن متن به فایل
                ItemClicked?.Invoke(this, EventArgs.Empty); // فراخوانی رویداد کلیک
            };

            MenuStrip.Items.Add(addItem);
        }

        /// <summary>
        /// بارگذاری لیست سرورها از فایل و تنظیم آن به عنوان منبع داده ComboBox
        /// </summary>
        /// <param name="txt">کمبوباکسی که باید داده‌گذاری شود</param>
        public void LoadServerListFromFile(ref ComboBox txt)
        {
            if (File.Exists(Path))
            {
                var serverList = File.ReadAllLines(Path);
                txt.DataSource = serverList;
            }
        }

        /// <summary>
        /// تنظیم DisplayMember و ValueMember برای کمبوباکس با توجه به کلاس User
        /// </summary>
        /// <param name="txtComboBox">کمبوباکس مورد نظر</param>
        public static void SetDisplayAndValueMemberComboBox(ref ComboBox txtComboBox)
        {
            txtComboBox.DisplayMember = nameof(User.Name);
            txtComboBox.ValueMember = nameof(User.UserId);
        }

        /// <summary>
        /// گرفتن مقدار UserId از مقدار متنی یا SelectedValue کمبوباکس به صورت رشته
        /// </summary>
        /// <param name="txtBox">کمبوباکس مورد نظر</param>
        /// <returns>شناسه کاربر به صورت رشته</returns>
        /// <exception cref="FormatException">اگر مقدار قابل تبدیل به عدد نباشد</exception>
        public static string GetUserIdValueToString(ComboBox txtBox)
        {
            if (int.TryParse(txtBox.Text, out var res) || int.TryParse(txtBox.SelectedValue?.ToString(), out res))
                return res.ToString();

            throw new FormatException("خطای تبدیل داده");
        }

        /// <summary>
        /// ساخت یک OpenFileDialog عمومی با فیلتر مشخص
        /// </summary>
        public static OpenFileDialog CreateOpenFileDialog(string filter) => new() { Filter = filter, Title = "باز کردن فایل" };
        public static SaveFileDialog CreateSaveFileDialog(string filter) => new() { Filter = filter, Title = "ذخیره کردن فایل" };

    }
}