namespace VorodKhoroj
{
    partial class FrmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            SwitchDataSourceToolStripMenuItem = new ToolStripMenuItem();
            گزارشToolStripMenuItem = new ToolStripMenuItem();
            DetailReportToolStripMenuItem = new ToolStripMenuItem();
            MonthlyReportToolStripMenuItem = new ToolStripMenuItem();
            FasrExportToolStripMenuItem = new ToolStripMenuItem();
            ویرایشردیفهایناقصToolStripMenuItem = new ToolStripMenuItem();
            ویرایشردیفناقصToolStripMenuItem = new ToolStripMenuItem();
            ویرایشکاربرانToolStripMenuItem = new ToolStripMenuItem();
            SettingToolStripMenuItem = new ToolStripMenuItem();
            DBConfigToolStripMenuItem = new ToolStripMenuItem();
            راهاندازیمجددToolStripMenuItem = new ToolStripMenuItem();
            FromDateTime_txtbox = new MaskedTextBox();
            label1 = new Label();
            label2 = new Label();
            toDateTime_txtbox = new MaskedTextBox();
            btn_applyfilter = new Button();
            label3 = new Label();
            btn_clear = new Button();
            Userid_txtbox = new ComboBox();
            dataView = new DataGridView();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataView).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Font = new Font("IRANSans", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            menuStrip1.Items.AddRange(new ToolStripItem[] { SwitchDataSourceToolStripMenuItem, گزارشToolStripMenuItem, ویرایشردیفهایناقصToolStripMenuItem, SettingToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(6, 3, 0, 3);
            menuStrip1.RightToLeft = RightToLeft.Yes;
            menuStrip1.Size = new Size(895, 30);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // SwitchDataSourceToolStripMenuItem
            // 
            SwitchDataSourceToolStripMenuItem.Font = new Font("IRANSans", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            SwitchDataSourceToolStripMenuItem.Name = "SwitchDataSourceToolStripMenuItem";
            SwitchDataSourceToolStripMenuItem.Size = new Size(103, 24);
            SwitchDataSourceToolStripMenuItem.Text = "انتخاب منبع داده";
            SwitchDataSourceToolStripMenuItem.Click += SwitchDataSourceToolStripMenuItem_Click;
            // 
            // گزارشToolStripMenuItem
            // 
            گزارشToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { DetailReportToolStripMenuItem, MonthlyReportToolStripMenuItem, FasrExportToolStripMenuItem });
            گزارشToolStripMenuItem.Font = new Font("IRANSans", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            گزارشToolStripMenuItem.Name = "گزارشToolStripMenuItem";
            گزارشToolStripMenuItem.Size = new Size(59, 24);
            گزارشToolStripMenuItem.Text = "گزارشات";
            // 
            // DetailReportToolStripMenuItem
            // 
            DetailReportToolStripMenuItem.Name = "DetailReportToolStripMenuItem";
            DetailReportToolStripMenuItem.Size = new Size(180, 24);
            DetailReportToolStripMenuItem.Text = "ریز جزییات";
            DetailReportToolStripMenuItem.Click += DetailReportToolStripMenuItem_Click;
            // 
            // MonthlyReportToolStripMenuItem
            // 
            MonthlyReportToolStripMenuItem.Name = "MonthlyReportToolStripMenuItem";
            MonthlyReportToolStripMenuItem.Size = new Size(180, 24);
            MonthlyReportToolStripMenuItem.Text = "گزارش ماهانه";
            MonthlyReportToolStripMenuItem.Click += MonthlyReportToolStripMenuItem_Click;
            // 
            // FasrExportToolStripMenuItem
            // 
            FasrExportToolStripMenuItem.Name = "FasrExportToolStripMenuItem";
            FasrExportToolStripMenuItem.Size = new Size(180, 24);
            FasrExportToolStripMenuItem.Text = "گزارش سریع";
            FasrExportToolStripMenuItem.Click += FastExportToolStripMenuItem_Click;
            // 
            // ویرایشردیفهایناقصToolStripMenuItem
            // 
            ویرایشردیفهایناقصToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { ویرایشردیفناقصToolStripMenuItem, ویرایشکاربرانToolStripMenuItem });
            ویرایشردیفهایناقصToolStripMenuItem.Font = new Font("IRANSans", 9F);
            ویرایشردیفهایناقصToolStripMenuItem.Name = "ویرایشردیفهایناقصToolStripMenuItem";
            ویرایشردیفهایناقصToolStripMenuItem.Size = new Size(92, 24);
            ویرایشردیفهایناقصToolStripMenuItem.Text = "ویرایش دیتاها";
            // 
            // ویرایشردیفناقصToolStripMenuItem
            // 
            ویرایشردیفناقصToolStripMenuItem.Name = "ویرایشردیفناقصToolStripMenuItem";
            ویرایشردیفناقصToolStripMenuItem.Size = new Size(175, 24);
            ویرایشردیفناقصToolStripMenuItem.Text = "ویرایش ردیف ناقص";
            // 
            // ویرایشکاربرانToolStripMenuItem
            // 
            ویرایشکاربرانToolStripMenuItem.Name = "ویرایشکاربرانToolStripMenuItem";
            ویرایشکاربرانToolStripMenuItem.Size = new Size(175, 24);
            ویرایشکاربرانToolStripMenuItem.Text = "ویرایش کاربران";
            // 
            // SettingToolStripMenuItem
            // 
            SettingToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { DBConfigToolStripMenuItem, راهاندازیمجددToolStripMenuItem });
            SettingToolStripMenuItem.Font = new Font("IRANSans", 9F);
            SettingToolStripMenuItem.Name = "SettingToolStripMenuItem";
            SettingToolStripMenuItem.Size = new Size(60, 24);
            SettingToolStripMenuItem.Text = "تنظیمات";
            // 
            // DBConfigToolStripMenuItem
            // 
            DBConfigToolStripMenuItem.Name = "DBConfigToolStripMenuItem";
            DBConfigToolStripMenuItem.Size = new Size(163, 24);
            DBConfigToolStripMenuItem.Text = "عملیات پایگاه داده";
            DBConfigToolStripMenuItem.Click += DBConfigToolStripMenuItem_Click;
            // 
            // راهاندازیمجددToolStripMenuItem
            // 
            راهاندازیمجددToolStripMenuItem.Name = "راهاندازیمجددToolStripMenuItem";
            راهاندازیمجددToolStripMenuItem.Size = new Size(163, 24);
            راهاندازیمجددToolStripMenuItem.Text = "راه اندازی مجدد";
            راهاندازیمجددToolStripMenuItem.Click += AppRestartToolStripMenuItem_Click;
            // 
            // FromDateTime_txtbox
            // 
            FromDateTime_txtbox.Location = new Point(616, 38);
            FromDateTime_txtbox.Mask = "1000/00/00";
            FromDateTime_txtbox.Name = "FromDateTime_txtbox";
            FromDateTime_txtbox.Size = new Size(112, 28);
            FromDateTime_txtbox.TabIndex = 3;
            FromDateTime_txtbox.ValidatingType = typeof(DateTime);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(734, 43);
            label1.Name = "label1";
            label1.RightToLeft = RightToLeft.Yes;
            label1.Size = new Size(47, 20);
            label1.TabIndex = 4;
            label1.Text = "تاریخ از:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(588, 41);
            label2.Name = "label2";
            label2.RightToLeft = RightToLeft.Yes;
            label2.Size = new Size(19, 20);
            label2.TabIndex = 6;
            label2.Text = "تا:";
            // 
            // toDateTime_txtbox
            // 
            toDateTime_txtbox.Location = new Point(470, 38);
            toDateTime_txtbox.Mask = "1000/00/00";
            toDateTime_txtbox.Name = "toDateTime_txtbox";
            toDateTime_txtbox.Size = new Size(112, 28);
            toDateTime_txtbox.TabIndex = 5;
            toDateTime_txtbox.ValidatingType = typeof(DateTime);
            // 
            // btn_applyfilter
            // 
            btn_applyfilter.Location = new Point(192, 38);
            btn_applyfilter.Name = "btn_applyfilter";
            btn_applyfilter.Size = new Size(125, 30);
            btn_applyfilter.TabIndex = 7;
            btn_applyfilter.Text = "اعمال فیلتر";
            btn_applyfilter.UseVisualStyleBackColor = true;
            btn_applyfilter.Click += Btn_ApplyFilter_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(412, 41);
            label3.Name = "label3";
            label3.RightToLeft = RightToLeft.Yes;
            label3.Size = new Size(47, 20);
            label3.TabIndex = 9;
            label3.Text = "کد کاربر:";
            // 
            // btn_clear
            // 
            btn_clear.BackColor = Color.Lavender;
            btn_clear.BackgroundImage = Properties.Resources.clear_icon_9213;
            btn_clear.BackgroundImageLayout = ImageLayout.Stretch;
            btn_clear.Location = new Point(147, 36);
            btn_clear.Name = "btn_clear";
            btn_clear.Size = new Size(39, 35);
            btn_clear.TabIndex = 12;
            btn_clear.UseVisualStyleBackColor = false;
            btn_clear.Click += btn_clear_Click;
            // 
            // Userid_txtbox
            // 
            Userid_txtbox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            Userid_txtbox.AutoCompleteSource = AutoCompleteSource.ListItems;
            Userid_txtbox.DisplayMember = "userid";
            Userid_txtbox.FormattingEnabled = true;
            Userid_txtbox.Location = new Point(323, 38);
            Userid_txtbox.Name = "Userid_txtbox";
            Userid_txtbox.Size = new Size(82, 28);
            Userid_txtbox.TabIndex = 13;
            // 
            // dataView
            // 
            dataView.AllowUserToAddRows = false;
            dataView.AllowUserToDeleteRows = false;
            dataView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataView.Location = new Point(0, 74);
            dataView.Name = "dataView";
            dataView.ReadOnly = true;
            dataView.RowHeadersWidth = 70;
            dataView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataView.Size = new Size(895, 526);
            dataView.TabIndex = 14;
            dataView.VirtualMode = true;
            dataView.RowPostPaint += dataView_RowPostPaint;
            // 
            // Frm_Main
            // 
            AcceptButton = btn_applyfilter;
            AutoScaleDimensions = new SizeF(7F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(895, 600);
            Controls.Add(dataView);
            Controls.Add(Userid_txtbox);
            Controls.Add(btn_clear);
            Controls.Add(label3);
            Controls.Add(btn_applyfilter);
            Controls.Add(label2);
            Controls.Add(toDateTime_txtbox);
            Controls.Add(label1);
            Controls.Add(FromDateTime_txtbox);
            Controls.Add(menuStrip1);
            Font = new Font("IRANSans", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MainMenuStrip = menuStrip1;
            Margin = new Padding(4);
            Name = "FrmMain";
            Text = "Main";
            FormClosing += Frm_Main_FormClosing;
            Load += Frm_Main_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private MenuStrip menuStrip1;
        private ToolStripMenuItem SwitchDataSourceToolStripMenuItem;
        private MaskedTextBox FromDateTime_txtbox;
        private Label label1;
        private Label label2;
        private MaskedTextBox toDateTime_txtbox;
        private Button btn_applyfilter;
        private Label label3;
        private Button btn_clear;
        private ToolStripMenuItem گزارشToolStripMenuItem;
        private ToolStripMenuItem DetailReportToolStripMenuItem;
        private ComboBox Userid_txtbox;
        public DataGridView dataView;
        private ToolStripMenuItem SettingToolStripMenuItem;
        private ToolStripMenuItem DBConfigToolStripMenuItem;
        private ToolStripMenuItem راهاندازیمجددToolStripMenuItem;
        private ToolStripMenuItem MonthlyReportToolStripMenuItem;
        private ToolStripMenuItem ویرایشردیفهایناقصToolStripMenuItem;
        private ToolStripMenuItem ویرایشردیفناقصToolStripMenuItem;
        private ToolStripMenuItem ویرایشکاربرانToolStripMenuItem;
        private ToolStripMenuItem FasrExportToolStripMenuItem;
    }
}
