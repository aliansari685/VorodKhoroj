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
            FromDateTime_txtbox = new MaskedTextBox();
            maskedTextBox1 = new MaskedTextBox();
            label2 = new Label();
            label3 = new Label();
            maskedTextBox2 = new MaskedTextBox();
            label4 = new Label();
            maskedTextBox3 = new MaskedTextBox();
            label5 = new Label();
            maskedTextBox4 = new MaskedTextBox();
            btn_submit = new Button();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            Userid_txtbox = new ComboBox();
            btn_clear = new Button();
            label6 = new Label();
            btn_applyfilter = new Button();
            label7 = new Label();
            toDateTime_txtbox = new MaskedTextBox();
            label8 = new Label();
            maskedTextBox5 = new MaskedTextBox();
            ((ISupportInitialize)dataView_Attendance).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // dataView_Attendance
            // 
            dataView_Attendance.AllowUserToAddRows = false;
            dataView_Attendance.AllowUserToDeleteRows = false;
            dataView_Attendance.AllowUserToOrderColumns = true;
            dataView_Attendance.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataView_Attendance.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataView_Attendance.Location = new Point(0, 331);
            dataView_Attendance.Margin = new Padding(3, 4, 3, 4);
            dataView_Attendance.Name = "dataView_Attendance";
            dataView_Attendance.ReadOnly = true;
            dataView_Attendance.Size = new Size(483, 315);
            dataView_Attendance.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(136, 21);
            label1.Name = "label1";
            label1.RightToLeft = RightToLeft.Yes;
            label1.Size = new Size(47, 20);
            label1.TabIndex = 6;
            label1.Text = "تاریخ از:";
            // 
            // FromDateTime_txtbox
            // 
            FromDateTime_txtbox.Location = new Point(18, 18);
            FromDateTime_txtbox.Margin = new Padding(3, 4, 3, 4);
            FromDateTime_txtbox.Mask = "1000/00/00";
            FromDateTime_txtbox.Name = "FromDateTime_txtbox";
            FromDateTime_txtbox.RightToLeft = RightToLeft.No;
            FromDateTime_txtbox.Size = new Size(107, 28);
            FromDateTime_txtbox.TabIndex = 0;
            FromDateTime_txtbox.ValidatingType = typeof(DateTime);
            // 
            // maskedTextBox1
            // 
            maskedTextBox1.Location = new Point(18, 65);
            maskedTextBox1.Margin = new Padding(3, 4, 3, 4);
            maskedTextBox1.Mask = "00:00:00";
            maskedTextBox1.Name = "maskedTextBox1";
            maskedTextBox1.RightToLeft = RightToLeft.No;
            maskedTextBox1.Size = new Size(107, 28);
            maskedTextBox1.TabIndex = 1;
            maskedTextBox1.ValidatingType = typeof(DateTime);
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
            // maskedTextBox2
            // 
            maskedTextBox2.Location = new Point(18, 116);
            maskedTextBox2.Margin = new Padding(3, 4, 3, 4);
            maskedTextBox2.Mask = "00:00:00";
            maskedTextBox2.Name = "maskedTextBox2";
            maskedTextBox2.RightToLeft = RightToLeft.No;
            maskedTextBox2.Size = new Size(107, 28);
            maskedTextBox2.TabIndex = 2;
            maskedTextBox2.ValidatingType = typeof(DateTime);
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
            // maskedTextBox3
            // 
            maskedTextBox3.Location = new Point(18, 168);
            maskedTextBox3.Margin = new Padding(3, 4, 3, 4);
            maskedTextBox3.Mask = "00:00:00";
            maskedTextBox3.Name = "maskedTextBox3";
            maskedTextBox3.RightToLeft = RightToLeft.No;
            maskedTextBox3.Size = new Size(107, 28);
            maskedTextBox3.TabIndex = 3;
            maskedTextBox3.ValidatingType = typeof(DateTime);
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
            // maskedTextBox4
            // 
            maskedTextBox4.Location = new Point(18, 217);
            maskedTextBox4.Margin = new Padding(3, 4, 3, 4);
            maskedTextBox4.Mask = "00:00:00";
            maskedTextBox4.Name = "maskedTextBox4";
            maskedTextBox4.RightToLeft = RightToLeft.No;
            maskedTextBox4.Size = new Size(107, 28);
            maskedTextBox4.TabIndex = 4;
            maskedTextBox4.ValidatingType = typeof(DateTime);
            // 
            // btn_submit
            // 
            btn_submit.Location = new Point(18, 263);
            btn_submit.Name = "btn_submit";
            btn_submit.Size = new Size(206, 46);
            btn_submit.TabIndex = 5;
            btn_submit.Text = "ثبت تغییرات";
            btn_submit.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(FromDateTime_txtbox);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(btn_submit);
            groupBox1.Controls.Add(maskedTextBox1);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(maskedTextBox4);
            groupBox1.Controls.Add(maskedTextBox2);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(maskedTextBox3);
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
            groupBox2.Controls.Add(maskedTextBox5);
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(btn_applyfilter);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(toDateTime_txtbox);
            groupBox2.Controls.Add(label7);
            groupBox2.Location = new Point(12, 7);
            groupBox2.Name = "groupBox2";
            groupBox2.RightToLeft = RightToLeft.Yes;
            groupBox2.Size = new Size(193, 205);
            groupBox2.TabIndex = 16;
            groupBox2.TabStop = false;
            groupBox2.Text = "جستجو";
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
            // maskedTextBox5
            // 
            maskedTextBox5.Location = new Point(10, 18);
            maskedTextBox5.Mask = "1000/00/00";
            maskedTextBox5.Name = "maskedTextBox5";
            maskedTextBox5.RightToLeft = RightToLeft.No;
            maskedTextBox5.Size = new Size(117, 28);
            maskedTextBox5.TabIndex = 14;
            maskedTextBox5.ValidatingType = typeof(DateTime);
            // 
            // FrmAttendance
            // 
            AcceptButton = btn_applyfilter;
            AutoScaleDimensions = new SizeF(7F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(483, 646);
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
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataView_Attendance;
        private Label label1;
        private MaskedTextBox FromDateTime_txtbox;
        private MaskedTextBox maskedTextBox1;
        private Label label2;
        private Label label3;
        private MaskedTextBox maskedTextBox2;
        private Label label4;
        private MaskedTextBox maskedTextBox3;
        private Label label5;
        private MaskedTextBox maskedTextBox4;
        private Button btn_submit;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private ComboBox Userid_txtbox;
        private MaskedTextBox maskedTextBox5;
        private Label label8;
        private Button btn_applyfilter;
        private Label label6;
        private MaskedTextBox toDateTime_txtbox;
        private Label label7;
        private Button btn_clear;
    }
}