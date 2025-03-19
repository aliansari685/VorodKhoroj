namespace VorodKhoroj
{
    partial class Frm_Main
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
            button1 = new Button();
            menuStrip1 = new MenuStrip();
            بازکردنفایلToolStripMenuItem = new ToolStripMenuItem();
            گزارشToolStripMenuItem = new ToolStripMenuItem();
            مجموعToolStripMenuItem = new ToolStripMenuItem();
            dataGridView1 = new DataGridView();
            FromDateTime_txtbox = new MaskedTextBox();
            label1 = new Label();
            label2 = new Label();
            toDateTime_txtbox = new MaskedTextBox();
            btn_applyfilter = new Button();
            label3 = new Label();
            userid_txtbox = new MaskedTextBox();
            button2 = new Button();
            btn_clear = new Button();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Font = new Font("IRANSans", 8.249999F);
            button1.Location = new Point(11, 45);
            button1.Margin = new Padding(4);
            button1.Name = "button1";
            button1.Size = new Size(41, 26);
            button1.TabIndex = 0;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            menuStrip1.Font = new Font("IRANSans", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            menuStrip1.Items.AddRange(new ToolStripItem[] { بازکردنفایلToolStripMenuItem, گزارشToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(6, 3, 0, 3);
            menuStrip1.RightToLeft = RightToLeft.Yes;
            menuStrip1.Size = new Size(1051, 30);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // بازکردنفایلToolStripMenuItem
            // 
            بازکردنفایلToolStripMenuItem.Font = new Font("IRANSans", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            بازکردنفایلToolStripMenuItem.Name = "بازکردنفایلToolStripMenuItem";
            بازکردنفایلToolStripMenuItem.Size = new Size(82, 24);
            بازکردنفایلToolStripMenuItem.Text = "باز کردن فایل";
            بازکردنفایلToolStripMenuItem.Click += بازکردنفایلToolStripMenuItem_Click;
            // 
            // گزارشToolStripMenuItem
            // 
            گزارشToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { مجموعToolStripMenuItem });
            گزارشToolStripMenuItem.Font = new Font("IRANSans", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            گزارشToolStripMenuItem.Name = "گزارشToolStripMenuItem";
            گزارشToolStripMenuItem.Size = new Size(59, 24);
            گزارشToolStripMenuItem.Text = "گزارشات";
            // 
            // مجموعToolStripMenuItem
            // 
            مجموعToolStripMenuItem.Name = "مجموعToolStripMenuItem";
            مجموعToolStripMenuItem.Size = new Size(180, 24);
            مجموعToolStripMenuItem.Text = "مجموع و اختلاف ";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToOrderColumns = true;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Bottom;
            dataGridView1.Location = new Point(0, 83);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(1051, 517);
            dataGridView1.TabIndex = 2;
            // 
            // FromDateTime_txtbox
            // 
            FromDateTime_txtbox.Location = new Point(878, 40);
            FromDateTime_txtbox.Mask = "1000/00/00";
            FromDateTime_txtbox.Name = "FromDateTime_txtbox";
            FromDateTime_txtbox.Size = new Size(112, 28);
            FromDateTime_txtbox.TabIndex = 3;
            FromDateTime_txtbox.ValidatingType = typeof(DateTime);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(995, 43);
            label1.Name = "label1";
            label1.RightToLeft = RightToLeft.Yes;
            label1.Size = new Size(47, 20);
            label1.TabIndex = 4;
            label1.Text = "تاریخ از:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(824, 43);
            label2.Name = "label2";
            label2.RightToLeft = RightToLeft.Yes;
            label2.Size = new Size(47, 20);
            label2.TabIndex = 6;
            label2.Text = "تاریخ تا:";
            // 
            // toDateTime_txtbox
            // 
            toDateTime_txtbox.Location = new Point(708, 40);
            toDateTime_txtbox.Mask = "1000/00/00";
            toDateTime_txtbox.Name = "toDateTime_txtbox";
            toDateTime_txtbox.Size = new Size(112, 28);
            toDateTime_txtbox.TabIndex = 5;
            toDateTime_txtbox.ValidatingType = typeof(DateTime);
            // 
            // btn_applyfilter
            // 
            btn_applyfilter.Location = new Point(450, 39);
            btn_applyfilter.Name = "btn_applyfilter";
            btn_applyfilter.Size = new Size(125, 33);
            btn_applyfilter.TabIndex = 7;
            btn_applyfilter.Text = "اعمال فیلتر";
            btn_applyfilter.UseVisualStyleBackColor = true;
            btn_applyfilter.Click += btn_applyfilter_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(653, 43);
            label3.Name = "label3";
            label3.RightToLeft = RightToLeft.Yes;
            label3.Size = new Size(47, 20);
            label3.TabIndex = 9;
            label3.Text = "کد کاربر:";
            // 
            // userid_txtbox
            // 
            userid_txtbox.Location = new Point(587, 40);
            userid_txtbox.Mask = "00000";
            userid_txtbox.Name = "userid_txtbox";
            userid_txtbox.Size = new Size(61, 28);
            userid_txtbox.TabIndex = 10;
            userid_txtbox.ValidatingType = typeof(int);
            // 
            // button2
            // 
            button2.Location = new Point(281, 39);
            button2.Name = "button2";
            button2.Size = new Size(94, 28);
            button2.TabIndex = 11;
            button2.Text = "محاسبه";
            button2.UseVisualStyleBackColor = true;
            // 
            // btn_clear
            // 
            btn_clear.BackColor = Color.Lavender;
            btn_clear.BackgroundImage = Properties.Resources.clear_icon_9213;
            btn_clear.BackgroundImageLayout = ImageLayout.Stretch;
            btn_clear.Location = new Point(405, 39);
            btn_clear.Name = "btn_clear";
            btn_clear.Size = new Size(39, 33);
            btn_clear.TabIndex = 12;
            btn_clear.UseVisualStyleBackColor = false;
            btn_clear.Click += btn_clear_Click;
            // 
            // Frm_Main
            // 
            AcceptButton = btn_applyfilter;
            AutoScaleDimensions = new SizeF(7F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1051, 600);
            Controls.Add(btn_clear);
            Controls.Add(button2);
            Controls.Add(userid_txtbox);
            Controls.Add(label3);
            Controls.Add(btn_applyfilter);
            Controls.Add(label2);
            Controls.Add(toDateTime_txtbox);
            Controls.Add(label1);
            Controls.Add(FromDateTime_txtbox);
            Controls.Add(dataGridView1);
            Controls.Add(button1);
            Controls.Add(menuStrip1);
            Font = new Font("IRANSans", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MainMenuStrip = menuStrip1;
            Margin = new Padding(4);
            Name = "Frm_Main";
            Text = "Main";
            Load += Frm_Main_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem بازکردنفایلToolStripMenuItem;
        private DataGridView dataGridView1;
        private MaskedTextBox FromDateTime_txtbox;
        private Label label1;
        private Label label2;
        private MaskedTextBox toDateTime_txtbox;
        private Button btn_applyfilter;
        private Label label3;
        private MaskedTextBox userid_txtbox;
        private Button button2;
        private Button btn_clear;
        private ToolStripMenuItem گزارشToolStripMenuItem;
        private ToolStripMenuItem مجموعToolStripMenuItem;
    }
}
