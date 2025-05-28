namespace VorodKhoroj.View
{
    partial class FrmAttendance
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataView_Attendance = new DataGridView();
            label1 = new Label();
            DateTime_txtbox = new MaskedTextBox();
            Entry1_txtbox = new MaskedTextBox();
            label2 = new Label();
            label3 = new Label();
            Exit1_txtbox = new MaskedTextBox();
            label4 = new Label();
            Entry2_txtbox = new MaskedTextBox();
            label5 = new Label();
            Exit2_txtbox = new MaskedTextBox();
            btn_submit = new Button();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            btn_clear = new Button();
            Userid_txtbox = new ComboBox();
            FromDateTime_txtbox = new MaskedTextBox();
            label8 = new Label();
            btn_applyfilter = new Button();
            label6 = new Label();
            toDateTime_txtbox = new MaskedTextBox();
            label7 = new Label();
            groupBox3 = new GroupBox();
            checkBox_workinholiday = new CheckBox();
            checkBox_Isincomplete = new CheckBox();
            checkBox_Islate = new CheckBox();
            groupBox4 = new GroupBox();
            radioBtn_Isincomplete = new RadioButton();
            radioBtn_IsLate = new RadioButton();
            radioBtn_All = new RadioButton();
            radioBtn_Attendance2 = new RadioButton();
            ((ISupportInitialize)dataView_Attendance).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            SuspendLayout();
            // 
            // dataView_Attendance
            // 
            dataView_Attendance.AllowUserToAddRows = false;
            dataView_Attendance.AllowUserToDeleteRows = false;
            dataView_Attendance.AllowUserToOrderColumns = true;
            dataView_Attendance.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataView_Attendance.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataView_Attendance.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataView_Attendance.Location = new Point(0, 331);
            dataView_Attendance.Margin = new Padding(3, 4, 3, 4);
            dataView_Attendance.Name = "dataView_Attendance";
            dataView_Attendance.ReadOnly = true;
            dataView_Attendance.Size = new Size(680, 315);
            dataView_Attendance.TabIndex = 6;
            dataView_Attendance.CellClick += dataView_Attendance_CellClick;
            dataView_Attendance.RowPrePaint += DataViewAttendanceRowPrePaint;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(136, 21);
            label1.Name = "label1";
            label1.RightToLeft = RightToLeft.Yes;
            label1.Size = new Size(37, 20);
            label1.TabIndex = 6;
            label1.Text = "تاریخ:";
            // 
            // DateTime_txtbox
            // 
            DateTime_txtbox.Location = new Point(18, 18);
            DateTime_txtbox.Margin = new Padding(3, 4, 3, 4);
            DateTime_txtbox.Mask = "1000/00/00";
            DateTime_txtbox.Name = "DateTime_txtbox";
            DateTime_txtbox.RightToLeft = RightToLeft.No;
            DateTime_txtbox.Size = new Size(107, 28);
            DateTime_txtbox.TabIndex = 0;
            DateTime_txtbox.ValidatingType = typeof(DateTime);
            // 
            // Entry1_txtbox
            // 
            Entry1_txtbox.Location = new Point(18, 65);
            Entry1_txtbox.Margin = new Padding(3, 4, 3, 4);
            Entry1_txtbox.Mask = "00:00:00";
            Entry1_txtbox.Name = "Entry1_txtbox";
            Entry1_txtbox.RightToLeft = RightToLeft.No;
            Entry1_txtbox.Size = new Size(107, 28);
            Entry1_txtbox.TabIndex = 1;
            Entry1_txtbox.ValidatingType = typeof(DateTime);
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(136, 68);
            label2.Name = "label2";
            label2.RightToLeft = RightToLeft.Yes;
            label2.Size = new Size(67, 20);
            label2.TabIndex = 8;
            label2.Text = "ساعت ورود:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(136, 119);
            label3.Name = "label3";
            label3.RightToLeft = RightToLeft.Yes;
            label3.Size = new Size(72, 20);
            label3.TabIndex = 10;
            label3.Text = "ساعت خروج:";
            // 
            // Exit1_txtbox
            // 
            Exit1_txtbox.Location = new Point(18, 116);
            Exit1_txtbox.Margin = new Padding(3, 4, 3, 4);
            Exit1_txtbox.Mask = "00:00:00";
            Exit1_txtbox.Name = "Exit1_txtbox";
            Exit1_txtbox.RightToLeft = RightToLeft.No;
            Exit1_txtbox.Size = new Size(107, 28);
            Exit1_txtbox.TabIndex = 2;
            Exit1_txtbox.ValidatingType = typeof(DateTime);
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(136, 171);
            label4.Name = "label4";
            label4.RightToLeft = RightToLeft.Yes;
            label4.Size = new Size(88, 20);
            label4.TabIndex = 12;
            label4.Text = "ساعت ورود دوم:";
            // 
            // Entry2_txtbox
            // 
            Entry2_txtbox.Location = new Point(18, 168);
            Entry2_txtbox.Margin = new Padding(3, 4, 3, 4);
            Entry2_txtbox.Mask = "00:00:00";
            Entry2_txtbox.Name = "Entry2_txtbox";
            Entry2_txtbox.RightToLeft = RightToLeft.No;
            Entry2_txtbox.Size = new Size(107, 28);
            Entry2_txtbox.TabIndex = 3;
            Entry2_txtbox.ValidatingType = typeof(DateTime);
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(136, 220);
            label5.Name = "label5";
            label5.RightToLeft = RightToLeft.Yes;
            label5.Size = new Size(93, 20);
            label5.TabIndex = 14;
            label5.Text = "ساعت خروج دوم:";
            // 
            // Exit2_txtbox
            // 
            Exit2_txtbox.Location = new Point(18, 217);
            Exit2_txtbox.Margin = new Padding(3, 4, 3, 4);
            Exit2_txtbox.Mask = "00:00:00";
            Exit2_txtbox.Name = "Exit2_txtbox";
            Exit2_txtbox.RightToLeft = RightToLeft.No;
            Exit2_txtbox.Size = new Size(107, 28);
            Exit2_txtbox.TabIndex = 4;
            Exit2_txtbox.ValidatingType = typeof(DateTime);
            // 
            // btn_submit
            // 
            btn_submit.Location = new Point(18, 263);
            btn_submit.Name = "btn_submit";
            btn_submit.Size = new Size(206, 46);
            btn_submit.TabIndex = 5;
            btn_submit.Text = "ثبت تغییرات";
            btn_submit.UseVisualStyleBackColor = true;
            btn_submit.Click += btn_submit_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(DateTime_txtbox);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(btn_submit);
            groupBox1.Controls.Add(Entry1_txtbox);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(Exit2_txtbox);
            groupBox1.Controls.Add(Exit1_txtbox);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(Entry2_txtbox);
            groupBox1.Location = new Point(228, 8);
            groupBox1.Name = "groupBox1";
            groupBox1.RightToLeft = RightToLeft.Yes;
            groupBox1.Size = new Size(239, 318);
            groupBox1.TabIndex = 15;
            groupBox1.TabStop = false;
            groupBox1.Text = "ویرایش اطلاعات:";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btn_clear);
            groupBox2.Controls.Add(Userid_txtbox);
            groupBox2.Controls.Add(FromDateTime_txtbox);
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(btn_applyfilter);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(toDateTime_txtbox);
            groupBox2.Controls.Add(label7);
            groupBox2.Location = new Point(13, 8);
            groupBox2.Name = "groupBox2";
            groupBox2.RightToLeft = RightToLeft.Yes;
            groupBox2.Size = new Size(195, 205);
            groupBox2.TabIndex = 16;
            groupBox2.TabStop = false;
            groupBox2.Text = "جستجو";
            // 
            // btn_clear
            // 
            btn_clear.BackColor = Color.Lavender;
            btn_clear.BackgroundImage = Properties.Resources.clear_icon_9213;
            btn_clear.BackgroundImageLayout = ImageLayout.Stretch;
            btn_clear.Location = new Point(10, 156);
            btn_clear.Name = "btn_clear";
            btn_clear.Size = new Size(39, 38);
            btn_clear.TabIndex = 20;
            btn_clear.UseVisualStyleBackColor = false;
            btn_clear.Click += btn_clear_Click;
            // 
            // Userid_txtbox
            // 
            Userid_txtbox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            Userid_txtbox.AutoCompleteSource = AutoCompleteSource.ListItems;
            Userid_txtbox.FormattingEnabled = true;
            Userid_txtbox.Location = new Point(10, 111);
            Userid_txtbox.Name = "Userid_txtbox";
            Userid_txtbox.RightToLeft = RightToLeft.No;
            Userid_txtbox.Size = new Size(117, 28);
            Userid_txtbox.TabIndex = 21;
            // 
            // FromDateTime_txtbox
            // 
            FromDateTime_txtbox.Location = new Point(10, 18);
            FromDateTime_txtbox.Mask = "1000/00/00";
            FromDateTime_txtbox.Name = "FromDateTime_txtbox";
            FromDateTime_txtbox.RightToLeft = RightToLeft.No;
            FromDateTime_txtbox.Size = new Size(117, 28);
            FromDateTime_txtbox.TabIndex = 14;
            FromDateTime_txtbox.ValidatingType = typeof(DateTime);
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(133, 23);
            label8.Name = "label8";
            label8.RightToLeft = RightToLeft.Yes;
            label8.Size = new Size(47, 20);
            label8.TabIndex = 15;
            label8.Text = "تاریخ از:";
            // 
            // btn_applyfilter
            // 
            btn_applyfilter.Location = new Point(55, 156);
            btn_applyfilter.Name = "btn_applyfilter";
            btn_applyfilter.Size = new Size(125, 38);
            btn_applyfilter.TabIndex = 18;
            btn_applyfilter.Text = "جستجو";
            btn_applyfilter.UseVisualStyleBackColor = true;
            btn_applyfilter.Click += btn_applyFilter_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(134, 114);
            label6.Name = "label6";
            label6.RightToLeft = RightToLeft.Yes;
            label6.Size = new Size(35, 20);
            label6.TabIndex = 19;
            label6.Text = " کاربر:";
            // 
            // toDateTime_txtbox
            // 
            toDateTime_txtbox.Location = new Point(10, 65);
            toDateTime_txtbox.Mask = "1000/00/00";
            toDateTime_txtbox.Name = "toDateTime_txtbox";
            toDateTime_txtbox.RightToLeft = RightToLeft.No;
            toDateTime_txtbox.Size = new Size(117, 28);
            toDateTime_txtbox.TabIndex = 16;
            toDateTime_txtbox.ValidatingType = typeof(DateTime);
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(133, 68);
            label7.Name = "label7";
            label7.RightToLeft = RightToLeft.Yes;
            label7.Size = new Size(19, 20);
            label7.TabIndex = 17;
            label7.Text = "تا:";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(checkBox_workinholiday);
            groupBox3.Controls.Add(checkBox_Isincomplete);
            groupBox3.Controls.Add(checkBox_Islate);
            groupBox3.Location = new Point(487, 7);
            groupBox3.Name = "groupBox3";
            groupBox3.RightToLeft = RightToLeft.Yes;
            groupBox3.Size = new Size(181, 134);
            groupBox3.TabIndex = 28;
            groupBox3.TabStop = false;
            groupBox3.Text = "اعمال استایل";
            // 
            // checkBox_workinholiday
            // 
            checkBox_workinholiday.AutoSize = true;
            checkBox_workinholiday.Location = new Point(47, 91);
            checkBox_workinholiday.Name = "checkBox_workinholiday";
            checkBox_workinholiday.Size = new Size(103, 24);
            checkBox_workinholiday.TabIndex = 30;
            checkBox_workinholiday.Text = "کار در روز تعطیل";
            checkBox_workinholiday.UseVisualStyleBackColor = true;
            checkBox_workinholiday.CheckedChanged += checkBox_ApplyStyles_CheckedChanged;
            // 
            // checkBox_Isincomplete
            // 
            checkBox_Isincomplete.AutoSize = true;
            checkBox_Isincomplete.Location = new Point(32, 61);
            checkBox_Isincomplete.Name = "checkBox_Isincomplete";
            checkBox_Isincomplete.Size = new Size(118, 24);
            checkBox_Isincomplete.TabIndex = 29;
            checkBox_Isincomplete.Text = "ورود ناقص و خراب";
            checkBox_Isincomplete.UseVisualStyleBackColor = true;
            checkBox_Isincomplete.CheckedChanged += checkBox_ApplyStyles_CheckedChanged;
            // 
            // checkBox_Islate
            // 
            checkBox_Islate.AutoSize = true;
            checkBox_Islate.Location = new Point(60, 31);
            checkBox_Islate.Name = "checkBox_Islate";
            checkBox_Islate.Size = new Size(90, 24);
            checkBox_Islate.TabIndex = 28;
            checkBox_Islate.Text = "ورود ب تاخیر";
            checkBox_Islate.UseVisualStyleBackColor = true;
            checkBox_Islate.CheckedChanged += checkBox_ApplyStyles_CheckedChanged;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(radioBtn_Attendance2);
            groupBox4.Controls.Add(radioBtn_Isincomplete);
            groupBox4.Controls.Add(radioBtn_IsLate);
            groupBox4.Controls.Add(radioBtn_All);
            groupBox4.Location = new Point(487, 147);
            groupBox4.Name = "groupBox4";
            groupBox4.RightToLeft = RightToLeft.Yes;
            groupBox4.Size = new Size(181, 174);
            groupBox4.TabIndex = 29;
            groupBox4.TabStop = false;
            groupBox4.Text = "نمایش ردیف ها";
            // 
            // radioBtn_Isincomplete
            // 
            radioBtn_Isincomplete.AutoSize = true;
            radioBtn_Isincomplete.Location = new Point(6, 101);
            radioBtn_Isincomplete.Name = "radioBtn_Isincomplete";
            radioBtn_Isincomplete.Size = new Size(157, 24);
            radioBtn_Isincomplete.TabIndex = 32;
            radioBtn_Isincomplete.Text = "روز های ورود ناقص و خراب";
            radioBtn_Isincomplete.UseVisualStyleBackColor = true;
            radioBtn_Isincomplete.CheckedChanged += radioBtn_CheckedChanged;
            // 
            // radioBtn_IsLate
            // 
            radioBtn_IsLate.AutoSize = true;
            radioBtn_IsLate.Location = new Point(38, 67);
            radioBtn_IsLate.Name = "radioBtn_IsLate";
            radioBtn_IsLate.Size = new Size(125, 24);
            radioBtn_IsLate.TabIndex = 31;
            radioBtn_IsLate.Text = "روز های ورود با تاخیر";
            radioBtn_IsLate.UseVisualStyleBackColor = true;
            radioBtn_IsLate.CheckedChanged += radioBtn_CheckedChanged;
            // 
            // radioBtn_All
            // 
            radioBtn_All.AutoSize = true;
            radioBtn_All.Checked = true;
            radioBtn_All.Location = new Point(116, 33);
            radioBtn_All.Name = "radioBtn_All";
            radioBtn_All.Size = new Size(47, 24);
            radioBtn_All.TabIndex = 30;
            radioBtn_All.TabStop = true;
            radioBtn_All.Text = "همه";
            radioBtn_All.UseVisualStyleBackColor = true;
            radioBtn_All.CheckedChanged += radioBtn_CheckedChanged;
            // 
            // radioBtn_Attendance2
            // 
            radioBtn_Attendance2.AutoSize = true;
            radioBtn_Attendance2.Location = new Point(55, 135);
            radioBtn_Attendance2.Name = "radioBtn_Attendance2";
            radioBtn_Attendance2.Size = new Size(108, 24);
            radioBtn_Attendance2.TabIndex = 33;
            radioBtn_Attendance2.Text = "روز های تردد دوم";
            radioBtn_Attendance2.UseVisualStyleBackColor = true;
            radioBtn_Attendance2.CheckedChanged += radioBtn_CheckedChanged;
            // 
            // FrmAttendance
            // 
            AcceptButton = btn_applyfilter;
            AutoScaleDimensions = new SizeF(7F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(680, 646);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(dataView_Attendance);
            Font = new Font("IRANSans", 9F);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FrmAttendance";
            Text = "FrmAttendance";
            Load += FrmAttendance_Load;
            ((ISupportInitialize)dataView_Attendance).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataView_Attendance;
        private Label label1;
        private MaskedTextBox DateTime_txtbox;
        private MaskedTextBox Entry1_txtbox;
        private Label label2;
        private Label label3;
        private MaskedTextBox Exit1_txtbox;
        private Label label4;
        private MaskedTextBox Entry2_txtbox;
        private Label label5;
        private MaskedTextBox Exit2_txtbox;
        private Button btn_submit;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private ComboBox Userid_txtbox;
        private MaskedTextBox FromDateTime_txtbox;
        private Label label8;
        private Button btn_applyfilter;
        private Label label6;
        private MaskedTextBox toDateTime_txtbox;
        private Label label7;
        private Button btn_clear;
        private GroupBox groupBox3;
        private CheckBox checkBox_workinholiday;
        private CheckBox checkBox_Isincomplete;
        private CheckBox checkBox_Islate;
        private GroupBox groupBox4;
        private RadioButton radioBtn_All;
        private RadioButton radioBtn_Isincomplete;
        private RadioButton radioBtn_IsLate;
        private RadioButton radioBtn_Attendance2;
    }
}