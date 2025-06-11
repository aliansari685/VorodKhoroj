namespace VorodKhoroj.View
{
    partial class FrmFilterMonthly
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
            txtbox_year = new MaskedTextBox();
            checkBox_farvardin = new CheckBox();
            groupBox1 = new GroupBox();
            checkBox_esfand = new CheckBox();
            checkBox_bahman = new CheckBox();
            checkBox_dey = new CheckBox();
            checkBox_azar = new CheckBox();
            checkBox_aban = new CheckBox();
            checkBox_mehr = new CheckBox();
            checkBox_shahrivar = new CheckBox();
            checkBox_mordad = new CheckBox();
            checkBox_tir = new CheckBox();
            checkBox_khordad = new CheckBox();
            checkBox_ordibehesht = new CheckBox();
            Btn_CheckAll = new Button();
            btn_clear = new Button();
            label1 = new Label();
            Btn_submit = new Button();
            userid_txtbox = new ComboBox();
            label3 = new Label();
            checkBox_withlabels = new CheckBox();
            checkBox_allusers = new CheckBox();
            groupBox2 = new GroupBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // txtbox_year
            // 
            txtbox_year.Location = new Point(180, 49);
            txtbox_year.Margin = new Padding(3, 4, 3, 4);
            txtbox_year.Mask = "0000";
            txtbox_year.Name = "txtbox_year";
            txtbox_year.RightToLeft = RightToLeft.No;
            txtbox_year.Size = new Size(54, 28);
            txtbox_year.TabIndex = 0;
            txtbox_year.Text = "1404";
            txtbox_year.TextAlign = HorizontalAlignment.Center;
            // 
            // checkBox_farvardin
            // 
            checkBox_farvardin.AutoSize = true;
            checkBox_farvardin.Location = new Point(42, 29);
            checkBox_farvardin.Margin = new Padding(3, 4, 3, 4);
            checkBox_farvardin.Name = "checkBox_farvardin";
            checkBox_farvardin.Size = new Size(67, 24);
            checkBox_farvardin.TabIndex = 0;
            checkBox_farvardin.Text = "فروردین";
            checkBox_farvardin.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(checkBox_esfand);
            groupBox1.Controls.Add(checkBox_bahman);
            groupBox1.Controls.Add(checkBox_dey);
            groupBox1.Controls.Add(checkBox_azar);
            groupBox1.Controls.Add(checkBox_aban);
            groupBox1.Controls.Add(checkBox_mehr);
            groupBox1.Controls.Add(checkBox_shahrivar);
            groupBox1.Controls.Add(checkBox_mordad);
            groupBox1.Controls.Add(checkBox_tir);
            groupBox1.Controls.Add(checkBox_khordad);
            groupBox1.Controls.Add(checkBox_ordibehesht);
            groupBox1.Controls.Add(checkBox_farvardin);
            groupBox1.Location = new Point(17, 91);
            groupBox1.Margin = new Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 4, 3, 4);
            groupBox1.Size = new Size(159, 408);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "انتخاب ماه ها";
            // 
            // checkBox_esfand
            // 
            checkBox_esfand.AutoSize = true;
            checkBox_esfand.Location = new Point(52, 382);
            checkBox_esfand.Margin = new Padding(3, 4, 3, 4);
            checkBox_esfand.Name = "checkBox_esfand";
            checkBox_esfand.Size = new Size(57, 24);
            checkBox_esfand.TabIndex = 11;
            checkBox_esfand.Text = "اسفند";
            checkBox_esfand.UseVisualStyleBackColor = true;
            // 
            // checkBox_bahman
            // 
            checkBox_bahman.AutoSize = true;
            checkBox_bahman.Location = new Point(57, 350);
            checkBox_bahman.Margin = new Padding(3, 4, 3, 4);
            checkBox_bahman.Name = "checkBox_bahman";
            checkBox_bahman.Size = new Size(52, 24);
            checkBox_bahman.TabIndex = 10;
            checkBox_bahman.Text = "بهمن";
            checkBox_bahman.UseVisualStyleBackColor = true;
            // 
            // checkBox_dey
            // 
            checkBox_dey.AutoSize = true;
            checkBox_dey.Location = new Point(66, 318);
            checkBox_dey.Margin = new Padding(3, 4, 3, 4);
            checkBox_dey.Name = "checkBox_dey";
            checkBox_dey.Size = new Size(43, 24);
            checkBox_dey.TabIndex = 9;
            checkBox_dey.Text = "دی";
            checkBox_dey.UseVisualStyleBackColor = true;
            // 
            // checkBox_azar
            // 
            checkBox_azar.AutoSize = true;
            checkBox_azar.Location = new Point(67, 286);
            checkBox_azar.Margin = new Padding(3, 4, 3, 4);
            checkBox_azar.Name = "checkBox_azar";
            checkBox_azar.Size = new Size(42, 24);
            checkBox_azar.TabIndex = 8;
            checkBox_azar.Text = "آذر";
            checkBox_azar.UseVisualStyleBackColor = true;
            // 
            // checkBox_aban
            // 
            checkBox_aban.AutoSize = true;
            checkBox_aban.Location = new Point(62, 254);
            checkBox_aban.Margin = new Padding(3, 4, 3, 4);
            checkBox_aban.Name = "checkBox_aban";
            checkBox_aban.Size = new Size(47, 24);
            checkBox_aban.TabIndex = 7;
            checkBox_aban.Text = "آبان";
            checkBox_aban.UseVisualStyleBackColor = true;
            // 
            // checkBox_mehr
            // 
            checkBox_mehr.AutoSize = true;
            checkBox_mehr.Location = new Point(66, 221);
            checkBox_mehr.Margin = new Padding(3, 4, 3, 4);
            checkBox_mehr.Name = "checkBox_mehr";
            checkBox_mehr.Size = new Size(43, 24);
            checkBox_mehr.TabIndex = 6;
            checkBox_mehr.Text = "مهر";
            checkBox_mehr.UseVisualStyleBackColor = true;
            // 
            // checkBox_shahrivar
            // 
            checkBox_shahrivar.AutoSize = true;
            checkBox_shahrivar.Location = new Point(49, 189);
            checkBox_shahrivar.Margin = new Padding(3, 4, 3, 4);
            checkBox_shahrivar.Name = "checkBox_shahrivar";
            checkBox_shahrivar.Size = new Size(60, 24);
            checkBox_shahrivar.TabIndex = 5;
            checkBox_shahrivar.Text = "شهریور";
            checkBox_shahrivar.UseVisualStyleBackColor = true;
            // 
            // checkBox_mordad
            // 
            checkBox_mordad.AutoSize = true;
            checkBox_mordad.Location = new Point(56, 157);
            checkBox_mordad.Margin = new Padding(3, 4, 3, 4);
            checkBox_mordad.Name = "checkBox_mordad";
            checkBox_mordad.Size = new Size(53, 24);
            checkBox_mordad.TabIndex = 4;
            checkBox_mordad.Text = "مرداد";
            checkBox_mordad.UseVisualStyleBackColor = true;
            // 
            // checkBox_tir
            // 
            checkBox_tir.AutoSize = true;
            checkBox_tir.Location = new Point(69, 125);
            checkBox_tir.Margin = new Padding(3, 4, 3, 4);
            checkBox_tir.Name = "checkBox_tir";
            checkBox_tir.Size = new Size(40, 24);
            checkBox_tir.TabIndex = 3;
            checkBox_tir.Text = "تیر";
            checkBox_tir.UseVisualStyleBackColor = true;
            // 
            // checkBox_khordad
            // 
            checkBox_khordad.AutoSize = true;
            checkBox_khordad.Location = new Point(54, 93);
            checkBox_khordad.Margin = new Padding(3, 4, 3, 4);
            checkBox_khordad.Name = "checkBox_khordad";
            checkBox_khordad.Size = new Size(55, 24);
            checkBox_khordad.TabIndex = 2;
            checkBox_khordad.Text = "خرداد";
            checkBox_khordad.UseVisualStyleBackColor = true;
            // 
            // checkBox_ordibehesht
            // 
            checkBox_ordibehesht.AutoSize = true;
            checkBox_ordibehesht.Location = new Point(32, 61);
            checkBox_ordibehesht.Margin = new Padding(3, 4, 3, 4);
            checkBox_ordibehesht.Name = "checkBox_ordibehesht";
            checkBox_ordibehesht.Size = new Size(77, 24);
            checkBox_ordibehesht.TabIndex = 1;
            checkBox_ordibehesht.Text = "اردیبهشت";
            checkBox_ordibehesht.UseVisualStyleBackColor = true;
            // 
            // Btn_CheckAll
            // 
            Btn_CheckAll.Location = new Point(186, 173);
            Btn_CheckAll.Margin = new Padding(3, 4, 3, 4);
            Btn_CheckAll.Name = "Btn_CheckAll";
            Btn_CheckAll.Size = new Size(38, 84);
            Btn_CheckAll.TabIndex = 3;
            Btn_CheckAll.Text = "همه";
            Btn_CheckAll.UseVisualStyleBackColor = true;
            Btn_CheckAll.Click += Btn_CheckAll_Click;
            // 
            // btn_clear
            // 
            btn_clear.BackColor = Color.Lavender;
            btn_clear.BackgroundImage = Properties.Resources.clear_icon_9213;
            btn_clear.BackgroundImageLayout = ImageLayout.Stretch;
            btn_clear.Location = new Point(186, 270);
            btn_clear.Name = "btn_clear";
            btn_clear.Size = new Size(38, 35);
            btn_clear.TabIndex = 4;
            btn_clear.UseVisualStyleBackColor = false;
            btn_clear.Click += btn_clear_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(192, 23);
            label1.Name = "label1";
            label1.Size = new Size(32, 20);
            label1.TabIndex = 14;
            label1.Text = "سال:";
            // 
            // Btn_submit
            // 
            Btn_submit.Location = new Point(49, 528);
            Btn_submit.Margin = new Padding(3, 4, 3, 4);
            Btn_submit.Name = "Btn_submit";
            Btn_submit.Size = new Size(94, 31);
            Btn_submit.TabIndex = 5;
            Btn_submit.Text = "تایید";
            Btn_submit.UseVisualStyleBackColor = true;
            Btn_submit.Click += Btn_submit_Click;
            // 
            // userid_txtbox
            // 
            userid_txtbox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            userid_txtbox.AutoCompleteSource = AutoCompleteSource.ListItems;
            userid_txtbox.DisplayMember = "userid";
            userid_txtbox.FormattingEnabled = true;
            userid_txtbox.Location = new Point(22, 18);
            userid_txtbox.Name = "userid_txtbox";
            userid_txtbox.Size = new Size(57, 28);
            userid_txtbox.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(84, 21);
            label3.Name = "label3";
            label3.RightToLeft = RightToLeft.Yes;
            label3.Size = new Size(47, 20);
            label3.TabIndex = 20;
            label3.Text = "کد کاربر:";
            // 
            // checkBox_withlabels
            // 
            checkBox_withlabels.AutoSize = true;
            checkBox_withlabels.Checked = true;
            checkBox_withlabels.CheckState = CheckState.Checked;
            checkBox_withlabels.Location = new Point(37, 502);
            checkBox_withlabels.Margin = new Padding(3, 4, 3, 4);
            checkBox_withlabels.Name = "checkBox_withlabels";
            checkBox_withlabels.Size = new Size(137, 24);
            checkBox_withlabels.TabIndex = 21;
            checkBox_withlabels.Text = "خلاصه محاسبات باشد؟";
            checkBox_withlabels.UseVisualStyleBackColor = true;
            // 
            // checkBox_allusers
            // 
            checkBox_allusers.AutoSize = true;
            checkBox_allusers.Location = new Point(37, 55);
            checkBox_allusers.Margin = new Padding(3, 4, 3, 4);
            checkBox_allusers.Name = "checkBox_allusers";
            checkBox_allusers.Size = new Size(82, 24);
            checkBox_allusers.TabIndex = 22;
            checkBox_allusers.Text = "همه کاربران";
            checkBox_allusers.UseVisualStyleBackColor = true;
            checkBox_allusers.CheckedChanged += checkBox_allUsers_CheckedChanged;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(checkBox_allusers);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(userid_txtbox);
            groupBox2.Location = new Point(17, 2);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(157, 82);
            groupBox2.TabIndex = 23;
            groupBox2.TabStop = false;
            groupBox2.Tag = "";
            // 
            // FrmFilterMonthly
            // 
            AcceptButton = Btn_submit;
            AutoScaleDimensions = new SizeF(7F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(241, 565);
            Controls.Add(groupBox2);
            Controls.Add(checkBox_withlabels);
            Controls.Add(Btn_submit);
            Controls.Add(label1);
            Controls.Add(btn_clear);
            Controls.Add(Btn_CheckAll);
            Controls.Add(groupBox1);
            Controls.Add(txtbox_year);
            Font = new Font("IRANSans", 9F);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "FrmFilterMonthly";
            RightToLeft = RightToLeft.Yes;
            Text = "FrmFilter_Monthly";
            Load += FrmFilter_Monthly_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaskedTextBox txtbox_year;
        private CheckBox checkBox_farvardin;
        private GroupBox groupBox1;
        private Button Btn_CheckAll;
        private CheckBox checkBox_mordad;
        private CheckBox checkBox_tir;
        private CheckBox checkBox_khordad;
        private CheckBox checkBox_ordibehesht;
        private CheckBox checkBox_shahrivar;
        private CheckBox checkBox_esfand;
        private CheckBox checkBox_bahman;
        private CheckBox checkBox_dey;
        private CheckBox checkBox_azar;
        private CheckBox checkBox_aban;
        private CheckBox checkBox_mehr;
        private Button btn_clear;
        private Label label1;
        private Button Btn_submit;
        public ComboBox userid_txtbox;
        private Label label3;
        private CheckBox checkBox_withlabels;
        private CheckBox checkBox_allusers;
        private GroupBox groupBox2;
    }
}