namespace VorodKhoroj.View
{
    partial class FrmCalc
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
            tabpage_detailvorodkhoroj = new TabPage();
            btn_perv = new Button();
            btn_next = new Button();
            userid_txtbox = new ComboBox();
            label19 = new Label();
            panel1 = new Panel();
            checkBox_AutoEdit = new CheckBox();
            lbl_tadil = new Label();
            label22 = new Label();
            lbl_sumkasri = new Label();
            label16 = new Label();
            lbl_sumlate = new Label();
            label17 = new Label();
            label18 = new Label();
            lbl_sumaddworkhour = new Label();
            label15 = new Label();
            lbl_nofull = new Label();
            label12 = new Label();
            lbl_fullwork = new Label();
            lbl_MaxExitTime = new Label();
            label14 = new Label();
            label10 = new Label();
            lbl_sumaddwork = new Label();
            label6 = new Label();
            lbl_avgtimework = new Label();
            lbl_minEntry = new Label();
            label8 = new Label();
            label4 = new Label();
            lbl_sumOff = new Label();
            label13 = new Label();
            label2 = new Label();
            lbl_sumdayworker = new Label();
            label5 = new Label();
            lbl_sumhour = new Label();
            lbl_sumentryDelay = new Label();
            label7 = new Label();
            lbl_summinute = new Label();
            lbl_avgexit = new Label();
            label9 = new Label();
            label11 = new Label();
            lbl_avgentry = new Label();
            lbl_FromTo = new Label();
            dataView_Calculate = new DataGridView();
            menuStrip2 = new MenuStrip();
            OutputExcelToolStripMenuItem = new ToolStripMenuItem();
            tabControl1 = new TabControl();
            tabPage_durationdays = new TabPage();
            button1 = new Button();
            groupBox1 = new GroupBox();
            radioButton_holidays = new RadioButton();
            radioButton_qeybat = new RadioButton();
            dataView_late = new DataGridView();
            tabPage_ = new TabPage();
            groupBox2 = new GroupBox();
            txtbox_late = new MaskedTextBox();
            txtbox_fullwork_farvardin = new MaskedTextBox();
            btn_submit = new Button();
            label23 = new Label();
            label3 = new Label();
            txtbox_fullwork_thursday = new MaskedTextBox();
            label20 = new Label();
            label21 = new Label();
            txtbox_fullwork = new MaskedTextBox();
            tabpage_detailvorodkhoroj.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataView_Calculate).BeginInit();
            menuStrip2.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage_durationdays.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataView_late).BeginInit();
            tabPage_.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // tabpage_detailvorodkhoroj
            // 
            tabpage_detailvorodkhoroj.BackColor = Color.Transparent;
            tabpage_detailvorodkhoroj.Controls.Add(btn_perv);
            tabpage_detailvorodkhoroj.Controls.Add(btn_next);
            tabpage_detailvorodkhoroj.Controls.Add(userid_txtbox);
            tabpage_detailvorodkhoroj.Controls.Add(label19);
            tabpage_detailvorodkhoroj.Controls.Add(panel1);
            tabpage_detailvorodkhoroj.Controls.Add(lbl_FromTo);
            tabpage_detailvorodkhoroj.Controls.Add(dataView_Calculate);
            tabpage_detailvorodkhoroj.Controls.Add(menuStrip2);
            tabpage_detailvorodkhoroj.Location = new Point(4, 29);
            tabpage_detailvorodkhoroj.Margin = new Padding(3, 4, 3, 4);
            tabpage_detailvorodkhoroj.Name = "tabpage_detailvorodkhoroj";
            tabpage_detailvorodkhoroj.Padding = new Padding(3, 4, 3, 4);
            tabpage_detailvorodkhoroj.Size = new Size(1072, 501);
            tabpage_detailvorodkhoroj.TabIndex = 0;
            tabpage_detailvorodkhoroj.Text = "جزییات ورود خروج";
            // 
            // btn_perv
            // 
            btn_perv.Location = new Point(307, 35);
            btn_perv.Name = "btn_perv";
            btn_perv.Size = new Size(44, 27);
            btn_perv.TabIndex = 26;
            btn_perv.Text = "قبلی";
            btn_perv.UseVisualStyleBackColor = true;
            btn_perv.Click += btn_perv_Click;
            // 
            // btn_next
            // 
            btn_next.Location = new Point(446, 35);
            btn_next.Name = "btn_next";
            btn_next.Size = new Size(44, 27);
            btn_next.TabIndex = 25;
            btn_next.Text = "بعدی";
            btn_next.UseVisualStyleBackColor = true;
            btn_next.Click += btn_next_Click;
            // 
            // userid_txtbox
            // 
            userid_txtbox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            userid_txtbox.AutoCompleteSource = AutoCompleteSource.ListItems;
            userid_txtbox.DisplayMember = "userid";
            userid_txtbox.Font = new Font("IRANSans", 8.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            userid_txtbox.FormattingEnabled = true;
            userid_txtbox.Location = new Point(358, 36);
            userid_txtbox.Name = "userid_txtbox";
            userid_txtbox.Size = new Size(82, 27);
            userid_txtbox.TabIndex = 24;
            userid_txtbox.KeyDown += userid_txtbox_KeyDown;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Font = new Font("IRANSans", 8.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label19.Location = new Point(496, 39);
            label19.Name = "label19";
            label19.RightToLeft = RightToLeft.Yes;
            label19.Size = new Size(47, 20);
            label19.TabIndex = 23;
            label19.Text = "کد کاربر:";
            // 
            // panel1
            // 
            panel1.Controls.Add(checkBox_AutoEdit);
            panel1.Controls.Add(lbl_tadil);
            panel1.Controls.Add(label22);
            panel1.Controls.Add(lbl_sumkasri);
            panel1.Controls.Add(label16);
            panel1.Controls.Add(lbl_sumlate);
            panel1.Controls.Add(label17);
            panel1.Controls.Add(label18);
            panel1.Controls.Add(lbl_sumaddworkhour);
            panel1.Controls.Add(label15);
            panel1.Controls.Add(lbl_nofull);
            panel1.Controls.Add(label12);
            panel1.Controls.Add(lbl_fullwork);
            panel1.Controls.Add(lbl_MaxExitTime);
            panel1.Controls.Add(label14);
            panel1.Controls.Add(label10);
            panel1.Controls.Add(lbl_sumaddwork);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(lbl_avgtimework);
            panel1.Controls.Add(lbl_minEntry);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(lbl_sumOff);
            panel1.Controls.Add(label13);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(lbl_sumdayworker);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(lbl_sumhour);
            panel1.Controls.Add(lbl_sumentryDelay);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(lbl_summinute);
            panel1.Controls.Add(lbl_avgexit);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(label11);
            panel1.Controls.Add(lbl_avgentry);
            panel1.Location = new Point(6, 67);
            panel1.Name = "panel1";
            panel1.Size = new Size(1061, 113);
            panel1.TabIndex = 21;
            // 
            // checkBox_AutoEdit
            // 
            checkBox_AutoEdit.AutoSize = true;
            checkBox_AutoEdit.Checked = true;
            checkBox_AutoEdit.CheckState = CheckState.Checked;
            checkBox_AutoEdit.Font = new Font("IRANSans", 8F, FontStyle.Bold);
            checkBox_AutoEdit.Location = new Point(9, 78);
            checkBox_AutoEdit.Name = "checkBox_AutoEdit";
            checkBox_AutoEdit.Size = new Size(139, 23);
            checkBox_AutoEdit.TabIndex = 42;
            checkBox_AutoEdit.Text = "اصلاح خودکار ردیف ناقص";
            checkBox_AutoEdit.UseVisualStyleBackColor = true;
            // 
            // lbl_tadil
            // 
            lbl_tadil.AutoSize = true;
            lbl_tadil.Font = new Font("IRANSans", 8F, FontStyle.Bold);
            lbl_tadil.Location = new Point(15, 46);
            lbl_tadil.Name = "lbl_tadil";
            lbl_tadil.RightToLeft = RightToLeft.No;
            lbl_tadil.Size = new Size(57, 19);
            lbl_tadil.TabIndex = 41;
            lbl_tadil.Text = "16:59:59";
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Font = new Font("IRANSans", 8F, FontStyle.Bold);
            label22.Location = new Point(89, 46);
            label22.Name = "label22";
            label22.Size = new Size(104, 19);
            label22.TabIndex = 40;
            label22.Text = "تعدیل(اضافه-کسری):";
            // 
            // lbl_sumkasri
            // 
            lbl_sumkasri.AutoSize = true;
            lbl_sumkasri.Font = new Font("IRANSans", 8F, FontStyle.Bold);
            lbl_sumkasri.Location = new Point(40, 11);
            lbl_sumkasri.Name = "lbl_sumkasri";
            lbl_sumkasri.Size = new Size(57, 19);
            lbl_sumkasri.TabIndex = 39;
            lbl_sumkasri.Text = "16:59:59";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("IRANSans", 8F, FontStyle.Bold);
            label16.Location = new Point(104, 11);
            label16.Name = "label16";
            label16.Size = new Size(73, 19);
            label16.TabIndex = 38;
            label16.Text = "مجموع کسری:";
            // 
            // lbl_sumlate
            // 
            lbl_sumlate.AutoSize = true;
            lbl_sumlate.Font = new Font("IRANSans", 8F, FontStyle.Bold);
            lbl_sumlate.Location = new Point(408, 46);
            lbl_sumlate.Name = "lbl_sumlate";
            lbl_sumlate.Size = new Size(57, 19);
            lbl_sumlate.TabIndex = 37;
            lbl_sumlate.Text = "59:59:59";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("IRANSans", 8F, FontStyle.Bold);
            label17.Location = new Point(475, 46);
            label17.Name = "label17";
            label17.Size = new Size(109, 19);
            label17.TabIndex = 36;
            label17.Text = "مجموع تاخیر به ساعت:";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("IRANSans", 8F, FontStyle.Bold);
            label18.Location = new Point(277, 46);
            label18.Name = "label18";
            label18.Size = new Size(123, 19);
            label18.TabIndex = 34;
            label18.Text = "مجموع اضافه ساعت کاری:";
            // 
            // lbl_sumaddworkhour
            // 
            lbl_sumaddworkhour.AutoSize = true;
            lbl_sumaddworkhour.Font = new Font("IRANSans", 8F, FontStyle.Bold);
            lbl_sumaddworkhour.Location = new Point(204, 46);
            lbl_sumaddworkhour.Name = "lbl_sumaddworkhour";
            lbl_sumaddworkhour.Size = new Size(64, 19);
            lbl_sumaddworkhour.TabIndex = 35;
            lbl_sumaddworkhour.Text = "168:59:59";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("IRANSans", 8F, FontStyle.Bold);
            label15.Location = new Point(773, 46);
            label15.Name = "label15";
            label15.Size = new Size(96, 19);
            label15.TabIndex = 32;
            label15.Text = "مجموع ردیف ناقص:";
            // 
            // lbl_nofull
            // 
            lbl_nofull.AutoSize = true;
            lbl_nofull.Font = new Font("IRANSans", 8F, FontStyle.Bold);
            lbl_nofull.Location = new Point(752, 46);
            lbl_nofull.Name = "lbl_nofull";
            lbl_nofull.Size = new Size(16, 19);
            lbl_nofull.TabIndex = 33;
            lbl_nofull.Text = "0";
            lbl_nofull.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("IRANSans", 8F, FontStyle.Bold);
            label12.Location = new Point(634, 46);
            label12.Name = "label12";
            label12.Size = new Size(101, 19);
            label12.TabIndex = 30;
            label12.Text = "مجموع روز های کامل:";
            // 
            // lbl_fullwork
            // 
            lbl_fullwork.AutoSize = true;
            lbl_fullwork.Font = new Font("IRANSans", 8F, FontStyle.Bold);
            lbl_fullwork.Location = new Point(591, 46);
            lbl_fullwork.Name = "lbl_fullwork";
            lbl_fullwork.Size = new Size(37, 19);
            lbl_fullwork.TabIndex = 31;
            lbl_fullwork.Text = "1000";
            lbl_fullwork.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_MaxExitTime
            // 
            lbl_MaxExitTime.AutoSize = true;
            lbl_MaxExitTime.Font = new Font("IRANSans", 8F, FontStyle.Bold);
            lbl_MaxExitTime.Location = new Point(352, 81);
            lbl_MaxExitTime.Name = "lbl_MaxExitTime";
            lbl_MaxExitTime.Size = new Size(57, 19);
            lbl_MaxExitTime.TabIndex = 29;
            lbl_MaxExitTime.Text = "59:59:59";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("IRANSans", 8F, FontStyle.Bold);
            label14.Location = new Point(415, 81);
            label14.Name = "label14";
            label14.Size = new Size(94, 19);
            label14.TabIndex = 28;
            label14.Text = "دیرترین زمان خروج:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("IRANSans", 8F, FontStyle.Bold);
            label10.Location = new Point(894, 46);
            label10.Name = "label10";
            label10.Size = new Size(159, 19);
            label10.TabIndex = 26;
            label10.Text = "مجموع اضافه روز کاری در تعطیلات:";
            // 
            // lbl_sumaddwork
            // 
            lbl_sumaddwork.AutoSize = true;
            lbl_sumaddwork.Font = new Font("IRANSans", 8F, FontStyle.Bold);
            lbl_sumaddwork.Location = new Point(872, 46);
            lbl_sumaddwork.Name = "lbl_sumaddwork";
            lbl_sumaddwork.Size = new Size(16, 19);
            lbl_sumaddwork.TabIndex = 27;
            lbl_sumaddwork.Text = "0";
            lbl_sumaddwork.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("IRANSans", 8F, FontStyle.Bold);
            label6.Location = new Point(734, 81);
            label6.Name = "label6";
            label6.Size = new Size(125, 19);
            label6.TabIndex = 24;
            label6.Text = "میانگین ساعات کاری روزانه:";
            // 
            // lbl_avgtimework
            // 
            lbl_avgtimework.AutoSize = true;
            lbl_avgtimework.Font = new Font("IRANSans", 8F, FontStyle.Bold);
            lbl_avgtimework.Location = new Point(671, 81);
            lbl_avgtimework.Name = "lbl_avgtimework";
            lbl_avgtimework.Size = new Size(57, 19);
            lbl_avgtimework.TabIndex = 25;
            lbl_avgtimework.Text = "09:32:59";
            // 
            // lbl_minEntry
            // 
            lbl_minEntry.AutoSize = true;
            lbl_minEntry.Font = new Font("IRANSans", 8F, FontStyle.Bold);
            lbl_minEntry.Location = new Point(516, 81);
            lbl_minEntry.Name = "lbl_minEntry";
            lbl_minEntry.Size = new Size(57, 19);
            lbl_minEntry.TabIndex = 23;
            lbl_minEntry.Text = "59:59:59";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("IRANSans", 8F, FontStyle.Bold);
            label8.Location = new Point(579, 81);
            label8.Name = "label8";
            label8.Size = new Size(88, 19);
            label8.TabIndex = 22;
            label8.Text = "زودترین زمان ورود:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("IRANSans", 8F, FontStyle.Bold);
            label4.Location = new Point(239, 11);
            label4.Name = "label4";
            label4.Size = new Size(132, 19);
            label4.TabIndex = 20;
            label4.Text = "مجموع غیبت(غیر تعطیلات):";
            // 
            // lbl_sumOff
            // 
            lbl_sumOff.AutoSize = true;
            lbl_sumOff.Font = new Font("IRANSans", 8F, FontStyle.Bold);
            lbl_sumOff.Location = new Point(205, 11);
            lbl_sumOff.Name = "lbl_sumOff";
            lbl_sumOff.Size = new Size(30, 19);
            lbl_sumOff.TabIndex = 21;
            lbl_sumOff.Text = "100";
            lbl_sumOff.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("IRANSans", 8F, FontStyle.Bold);
            label13.Location = new Point(433, 11);
            label13.Name = "label13";
            label13.Size = new Size(133, 19);
            label13.TabIndex = 14;
            label13.Text = "مجموع روز های ورود با تاخیر:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("IRANSans", 8F, FontStyle.Bold);
            label2.Location = new Point(948, 11);
            label2.Name = "label2";
            label2.Size = new Size(108, 19);
            label2.TabIndex = 4;
            label2.Text = "مجموع روز های حضور :";
            // 
            // lbl_sumdayworker
            // 
            lbl_sumdayworker.AutoSize = true;
            lbl_sumdayworker.Font = new Font("IRANSans", 8F, FontStyle.Bold);
            lbl_sumdayworker.Location = new Point(891, 11);
            lbl_sumdayworker.Name = "lbl_sumdayworker";
            lbl_sumdayworker.Size = new Size(37, 19);
            lbl_sumdayworker.TabIndex = 5;
            lbl_sumdayworker.Text = "1000";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("IRANSans", 8F, FontStyle.Bold);
            label5.Location = new Point(801, 11);
            label5.Name = "label5";
            label5.Size = new Size(79, 19);
            label5.TabIndex = 6;
            label5.Text = "مجموع ساعت  :";
            // 
            // lbl_sumhour
            // 
            lbl_sumhour.AutoSize = true;
            lbl_sumhour.Font = new Font("IRANSans", 8F, FontStyle.Bold);
            lbl_sumhour.Location = new Point(742, 11);
            lbl_sumhour.Name = "lbl_sumhour";
            lbl_sumhour.Size = new Size(47, 19);
            lbl_sumhour.TabIndex = 7;
            lbl_sumhour.Text = "107:60";
            // 
            // lbl_sumentryDelay
            // 
            lbl_sumentryDelay.AutoSize = true;
            lbl_sumentryDelay.Font = new Font("IRANSans", 8F, FontStyle.Bold);
            lbl_sumentryDelay.Location = new Point(383, 11);
            lbl_sumentryDelay.Name = "lbl_sumentryDelay";
            lbl_sumentryDelay.Size = new Size(30, 19);
            lbl_sumentryDelay.TabIndex = 15;
            lbl_sumentryDelay.Text = "100";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("IRANSans", 8F, FontStyle.Bold);
            label7.Location = new Point(656, 11);
            label7.Name = "label7";
            label7.Size = new Size(73, 19);
            label7.TabIndex = 8;
            label7.Text = "مجموع دقایق :";
            // 
            // lbl_summinute
            // 
            lbl_summinute.AutoSize = true;
            lbl_summinute.Font = new Font("IRANSans", 8F, FontStyle.Bold);
            lbl_summinute.Location = new Point(587, 11);
            lbl_summinute.Name = "lbl_summinute";
            lbl_summinute.Size = new Size(61, 19);
            lbl_summinute.TabIndex = 9;
            lbl_summinute.Text = "500000m";
            lbl_summinute.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_avgexit
            // 
            lbl_avgexit.AutoSize = true;
            lbl_avgexit.Font = new Font("IRANSans", 8F, FontStyle.Bold);
            lbl_avgexit.Location = new Point(867, 81);
            lbl_avgexit.Name = "lbl_avgexit";
            lbl_avgexit.Size = new Size(57, 19);
            lbl_avgexit.TabIndex = 13;
            lbl_avgexit.Text = "59:59:59";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("IRANSans", 8F, FontStyle.Bold);
            label9.Location = new Point(225, 81);
            label9.Name = "label9";
            label9.Size = new Size(120, 19);
            label9.TabIndex = 10;
            label9.Text = "میانگین ساعت های ورود :";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("IRANSans", 8F, FontStyle.Bold);
            label11.Location = new Point(930, 81);
            label11.Name = "label11";
            label11.Size = new Size(126, 19);
            label11.TabIndex = 12;
            label11.Text = "میانگین ساعت های خروج :";
            // 
            // lbl_avgentry
            // 
            lbl_avgentry.AutoSize = true;
            lbl_avgentry.Font = new Font("IRANSans", 8F, FontStyle.Bold);
            lbl_avgentry.Location = new Point(162, 81);
            lbl_avgentry.Name = "lbl_avgentry";
            lbl_avgentry.Size = new Size(57, 19);
            lbl_avgentry.TabIndex = 11;
            lbl_avgentry.Text = "16:59:59";
            // 
            // lbl_FromTo
            // 
            lbl_FromTo.AutoSize = true;
            lbl_FromTo.Location = new Point(100, 38);
            lbl_FromTo.Name = "lbl_FromTo";
            lbl_FromTo.Size = new Size(16, 20);
            lbl_FromTo.TabIndex = 20;
            lbl_FromTo.Text = "0";
            // 
            // dataView_Calculate
            // 
            dataView_Calculate.AllowUserToAddRows = false;
            dataView_Calculate.AllowUserToDeleteRows = false;
            dataView_Calculate.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataView_Calculate.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataView_Calculate.Location = new Point(3, 184);
            dataView_Calculate.Name = "dataView_Calculate";
            dataView_Calculate.ReadOnly = true;
            dataView_Calculate.RightToLeft = RightToLeft.No;
            dataView_Calculate.RowHeadersWidth = 70;
            dataView_Calculate.Size = new Size(1066, 318);
            dataView_Calculate.TabIndex = 0;
            dataView_Calculate.VirtualMode = true;
            dataView_Calculate.RowPostPaint += DataViewCalculateRowPostPaint;
            dataView_Calculate.RowPrePaint += DataViewCalculateRowPrePaint;
            // 
            // menuStrip2
            // 
            menuStrip2.Font = new Font("IRANSans", 8.249999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            menuStrip2.Items.AddRange(new ToolStripItem[] { OutputExcelToolStripMenuItem });
            menuStrip2.Location = new Point(3, 4);
            menuStrip2.Name = "menuStrip2";
            menuStrip2.Size = new Size(1066, 27);
            menuStrip2.TabIndex = 22;
            menuStrip2.Text = "menuStrip2";
            // 
            // OutputExcelToolStripMenuItem
            // 
            OutputExcelToolStripMenuItem.Name = "OutputExcelToolStripMenuItem";
            OutputExcelToolStripMenuItem.Size = new Size(80, 23);
            OutputExcelToolStripMenuItem.Text = "خروجی اکسل";
            OutputExcelToolStripMenuItem.Click += OutputExcelToolStripMenuItem_Click;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabpage_detailvorodkhoroj);
            tabControl1.Controls.Add(tabPage_durationdays);
            tabControl1.Controls.Add(tabPage_);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Margin = new Padding(3, 4, 3, 4);
            tabControl1.Name = "tabControl1";
            tabControl1.RightToLeft = RightToLeft.Yes;
            tabControl1.RightToLeftLayout = true;
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1080, 534);
            tabControl1.TabIndex = 0;
            // 
            // tabPage_durationdays
            // 
            tabPage_durationdays.Controls.Add(button1);
            tabPage_durationdays.Controls.Add(groupBox1);
            tabPage_durationdays.Controls.Add(dataView_late);
            tabPage_durationdays.Location = new Point(4, 29);
            tabPage_durationdays.Name = "tabPage_durationdays";
            tabPage_durationdays.Padding = new Padding(3);
            tabPage_durationdays.Size = new Size(1072, 501);
            tabPage_durationdays.TabIndex = 1;
            tabPage_durationdays.Text = "روز های غیبت";
            tabPage_durationdays.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(8, 8);
            button1.Name = "button1";
            button1.Size = new Size(71, 67);
            button1.TabIndex = 23;
            button1.Text = "اکسل";
            button1.UseVisualStyleBackColor = true;
            button1.Click += BtnExportExcelClick;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(radioButton_holidays);
            groupBox1.Controls.Add(radioButton_qeybat);
            groupBox1.Location = new Point(451, 6);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(251, 75);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "انتخاب لیست:";
            // 
            // radioButton_holidays
            // 
            radioButton_holidays.AutoSize = true;
            radioButton_holidays.Location = new Point(96, 45);
            radioButton_holidays.Name = "radioButton_holidays";
            radioButton_holidays.Size = new Size(98, 24);
            radioButton_holidays.TabIndex = 27;
            radioButton_holidays.TabStop = true;
            radioButton_holidays.Text = "لیست تعطیلات";
            radioButton_holidays.UseVisualStyleBackColor = true;
            radioButton_holidays.CheckedChanged += radioButton_CheckedChanged;
            // 
            // radioButton_qeybat
            // 
            radioButton_qeybat.AutoSize = true;
            radioButton_qeybat.Checked = true;
            radioButton_qeybat.Location = new Point(39, 17);
            radioButton_qeybat.Name = "radioButton_qeybat";
            radioButton_qeybat.Size = new Size(155, 24);
            radioButton_qeybat.TabIndex = 26;
            radioButton_qeybat.TabStop = true;
            radioButton_qeybat.Text = "لیست غیبت بدون تعطیلات";
            radioButton_qeybat.UseVisualStyleBackColor = true;
            radioButton_qeybat.CheckedChanged += radioButton_CheckedChanged;
            // 
            // dataView_late
            // 
            dataView_late.AllowUserToAddRows = false;
            dataView_late.AllowUserToDeleteRows = false;
            dataView_late.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataView_late.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataView_late.Location = new Point(3, 87);
            dataView_late.Name = "dataView_late";
            dataView_late.ReadOnly = true;
            dataView_late.RightToLeft = RightToLeft.No;
            dataView_late.RowHeadersWidth = 70;
            dataView_late.Size = new Size(1055, 364);
            dataView_late.TabIndex = 22;
            dataView_late.VirtualMode = true;
            dataView_late.RowPostPaint += DataViewCalculateRowPostPaint;
            dataView_late.RowPrePaint += dataView_late_RowPrePaint;
            // 
            // tabPage_
            // 
            tabPage_.Controls.Add(groupBox2);
            tabPage_.Location = new Point(4, 29);
            tabPage_.Name = "tabPage_";
            tabPage_.Padding = new Padding(3);
            tabPage_.Size = new Size(1072, 501);
            tabPage_.TabIndex = 2;
            tabPage_.Text = "تنظیمات شرط ها";
            tabPage_.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(txtbox_late);
            groupBox2.Controls.Add(txtbox_fullwork_farvardin);
            groupBox2.Controls.Add(btn_submit);
            groupBox2.Controls.Add(label23);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(txtbox_fullwork_thursday);
            groupBox2.Controls.Add(label20);
            groupBox2.Controls.Add(label21);
            groupBox2.Controls.Add(txtbox_fullwork);
            groupBox2.Dock = DockStyle.Left;
            groupBox2.Location = new Point(3, 3);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(435, 495);
            groupBox2.TabIndex = 35;
            groupBox2.TabStop = false;
            groupBox2.Text = "شرط ها";
            // 
            // txtbox_late
            // 
            txtbox_late.Location = new Point(6, 27);
            txtbox_late.Mask = "00:00:00";
            txtbox_late.Name = "txtbox_late";
            txtbox_late.RightToLeft = RightToLeft.No;
            txtbox_late.Size = new Size(59, 28);
            txtbox_late.TabIndex = 22;
            txtbox_late.Text = "083000";
            txtbox_late.TextAlign = HorizontalAlignment.Center;
            txtbox_late.ValidatingType = typeof(DateTime);
            // 
            // txtbox_fullwork_farvardin
            // 
            txtbox_fullwork_farvardin.Location = new Point(198, 65);
            txtbox_fullwork_farvardin.Mask = "00:00:00";
            txtbox_fullwork_farvardin.Name = "txtbox_fullwork_farvardin";
            txtbox_fullwork_farvardin.RightToLeft = RightToLeft.No;
            txtbox_fullwork_farvardin.Size = new Size(59, 28);
            txtbox_fullwork_farvardin.TabIndex = 34;
            txtbox_fullwork_farvardin.Text = "074500";
            txtbox_fullwork_farvardin.TextAlign = HorizontalAlignment.Center;
            txtbox_fullwork_farvardin.ValidatingType = typeof(DateTime);
            // 
            // btn_submit
            // 
            btn_submit.Location = new Point(5, 99);
            btn_submit.Name = "btn_submit";
            btn_submit.Size = new Size(421, 63);
            btn_submit.TabIndex = 20;
            btn_submit.Text = "اعمال";
            btn_submit.UseVisualStyleBackColor = true;
            btn_submit.Click += btn_Submit_Click;
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Location = new Point(262, 65);
            label23.Name = "label23";
            label23.Size = new Size(159, 20);
            label23.TabIndex = 33;
            label23.Text = "شرط ساعت کاری کامل فروردین:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(70, 31);
            label3.Name = "label3";
            label3.Size = new Size(109, 20);
            label3.TabIndex = 21;
            label3.Text = "شرط زمان تاخیر ورود:";
            // 
            // txtbox_fullwork_thursday
            // 
            txtbox_fullwork_thursday.Location = new Point(198, 31);
            txtbox_fullwork_thursday.Mask = "00:00:00";
            txtbox_fullwork_thursday.Name = "txtbox_fullwork_thursday";
            txtbox_fullwork_thursday.RightToLeft = RightToLeft.No;
            txtbox_fullwork_thursday.Size = new Size(59, 28);
            txtbox_fullwork_thursday.TabIndex = 30;
            txtbox_fullwork_thursday.Text = "053000";
            txtbox_fullwork_thursday.TextAlign = HorizontalAlignment.Center;
            txtbox_fullwork_thursday.ValidatingType = typeof(DateTime);
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Location = new Point(70, 65);
            label20.Name = "label20";
            label20.Size = new Size(117, 20);
            label20.TabIndex = 27;
            label20.Text = "شرط ساعت کاری کامل:";
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Location = new Point(262, 35);
            label21.Name = "label21";
            label21.Size = new Size(164, 20);
            label21.TabIndex = 29;
            label21.Text = "شرط ساعت کاری کامل پنج شنبه:";
            // 
            // txtbox_fullwork
            // 
            txtbox_fullwork.Location = new Point(6, 65);
            txtbox_fullwork.Mask = "00:00:00";
            txtbox_fullwork.Name = "txtbox_fullwork";
            txtbox_fullwork.RightToLeft = RightToLeft.No;
            txtbox_fullwork.Size = new Size(59, 28);
            txtbox_fullwork.TabIndex = 28;
            txtbox_fullwork.Text = "083000";
            txtbox_fullwork.TextAlign = HorizontalAlignment.Center;
            txtbox_fullwork.ValidatingType = typeof(DateTime);
            // 
            // FrmCalc
            // 
            AutoScaleDimensions = new SizeF(7F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1080, 534);
            Controls.Add(tabControl1);
            Font = new Font("IRANSans", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 4, 3, 4);
            Name = "FrmCalc";
            Text = "FrmCalc";
            Load += FrmCalc_Load;
            tabpage_detailvorodkhoroj.ResumeLayout(false);
            tabpage_detailvorodkhoroj.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataView_Calculate).EndInit();
            menuStrip2.ResumeLayout(false);
            menuStrip2.PerformLayout();
            tabControl1.ResumeLayout(false);
            tabPage_durationdays.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataView_late).EndInit();
            tabPage_.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabPage tabpage_detailvorodkhoroj;
        private Panel panel1;
        public Label label6;
        public Label lbl_avgtimework;
        public Label lbl_minEntry;
        public Label label8;
        public Label label4;
        public Label lbl_sumOff;
        public Label label13;
        public Label label2;
        public Label lbl_sumdayworker;
        public Label label5;
        public Label lbl_sumhour;
        public Label lbl_sumentryDelay;
        public Label label7;
        public Label lbl_summinute;
        public Label lbl_avgexit;
        public Label label9;
        public Label label11;
        public Label lbl_avgentry;
        public Label lbl_FromTo;
        private DataGridView dataView_Calculate;
        private TabControl tabControl1;
        public Label label10;
        public Label lbl_us;
        public Label lbl_sumaddwork;
        public Label lbl_MaxExitTime;
        public Label label14;
        private MenuStrip menuStrip2;
        private ToolStripMenuItem OutputExcelToolStripMenuItem;
        private TabPage tabPage_durationdays;
        private DataGridView dataView_late;
        private GroupBox groupBox1;
        private RadioButton radioButton_qeybat;
        private RadioButton radioButton_holidays;
        private Button button1;
        public Label label12;
        public Label lbl_fullwork;
        public Label label15;
        public Label lbl_nofull;
        public Label lbl_sumlate;
        public Label label17;
        public Label label18;
        public Label lbl_sumaddworkhour;
        private TabPage tabPage_;
        private MaskedTextBox txtbox_late;
        public Label label3;
        private Button btn_submit;
        private MaskedTextBox txtbox_fullwork_thursday;
        public Label label21;
        private MaskedTextBox txtbox_fullwork;
        public Label label20;
        private MaskedTextBox txtbox_fullwork_farvardin;
        public Label label23;
        public Label label16;
        public Label lbl_sumkasri;
        public Label lbl_tadil;
        public Label label22;
        private GroupBox groupBox2;
        private Label label19;
        private Button btn_next;
        private Button btn_perv;
        public ComboBox userid_txtbox;
        private CheckBox checkBox_AutoEdit;
    }
}