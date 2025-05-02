namespace VorodKhoroj.View
{
    public class CommonItems
    {
        public static readonly string Path = Application.StartupPath + @"\tmpFile\serverList.txt";

        public string Text { get; set; } = "";

        public ContextMenuStrip MenuStrip { get; } = new();

        // رویداد کلیک شدن آیتم
        public event EventHandler? ItemClicked;

        public CommonItems()
        {
            var addItem = new ToolStripMenuItem
            {
                Name = "AddItemMenuItem",
                Size = new Size(180, 22),
                Text = "افزودن به لیست"
            };

            addItem.Click += (_, _) =>
            {
                File.AppendAllLines(Path, [Text]);
                ItemClicked?.Invoke(this, EventArgs.Empty); // رویداد را فراخوانی می‌کنیم
            };

            MenuStrip.Items.Add(addItem);
        }
        public void LoadServerListFromFile(ref ComboBox txt)
        {
            if (File.Exists(Path))
            {
                var serverList = File.ReadAllLines(Path);
                txt.DataSource = serverList;
            }
        }
    }

}
