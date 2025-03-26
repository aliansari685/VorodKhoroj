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
            panel1 = new Panel();
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
            txtbox_lade = new MaskedTextBox();
            lbl_sumdayworker = new Label();
            label3 = new Label();
            label5 = new Label();
            btn_submit = new Button();
            lbl_sumhour = new Label();
            lbl_sumentryDelay = new Label();
            label7 = new Label();
            lbl_summinute = new Label();
            lbl_avgexit = new Label();
            label9 = new Label();
            label11 = new Label();
            lbl_avgentry = new Label();
            lbl_FromTo = new Label();
            lbl_user = new Label();
            label1 = new Label();
            dataView_calender = new DataGridView();
            menuStrip2 = new MenuStrip();
            OutputExcelToolStripMenuItem = new ToolStripMenuItem();
            tabControl1 = new TabControl();
            tabPage_durationdays = new TabPage();
            button1 = new Button();
            groupBox1 = new GroupBox();
            radioButton_holidays = new RadioButton();
            radioButton_qeybat = new RadioButton();
            dataView_lade = new DataGridView();
            tabpage_detailvorodkhoroj.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataView_calender).BeginInit();
            menuStrip2.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage_durationdays.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataView_lade).BeginInit();
            SuspendLayout();
            // 
            // tabpage_detailvorodkhoroj
            // 
            tabpage_detailvorodkhoroj.BackColor = Color.Transparent;
            tabpage_detailvorodkhoroj.Controls.Add(panel1);
            tabpage_detailvorodkhoroj.Controls.Add(lbl_FromTo);
            tabpage_detailvorodkhoroj.Controls.Add(lbl_user);
            tabpage_detailvorodkhoroj.Controls.Add(label1);
            tabpage_detailvorodkhoroj.Controls.Add(dataView_calender);
            tabpage_detailvorodkhoroj.Controls.Add(menuStrip2);
            tabpage_detailvorodkhoroj.Location = new Point(4, 29);
            tabpage_detailvorodkhoroj.Margin = new Padding(3, 4, 3, 4);
            tabpage_detailvorodkhoroj.Name = "tabpage_detailvorodkhoroj";
            tabpage_detailvorodkhoroj.Padding = new Padding(3, 4, 3, 4);
            tabpage_detailvorodkhoroj.Size = new Size(1307, 683);
            tabpage_detailvorodkhoroj.TabIndex = 0;
            tabpage_detailvorodkhoroj.Text = "جزییات ورود خروج";
            // 
            // panel1
            // 
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
            panel1.Controls.Add(txtbox_lade);
            panel1.Controls.Add(lbl_sumdayworker);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(btn_submit);
            panel1.Controls.Add(lbl_sumhour);
            panel1.Controls.Add(lbl_sumentryDelay);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(lbl_summinute);
            panel1.Controls.Add(lbl_avgexit);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(label11);
            panel1.Controls.Add(lbl_avgentry);
            panel1.Location = new Point(-68, 36);
            panel1.Name = "panel1";
            panel1.Size = new Size(1371, 73);
            panel1.TabIndex = 21;
            // 
            // lbl_MaxExitTime
            // 
            lbl_MaxExitTime.AutoSize = true;
            lbl_MaxExitTime.Location = new Point(1024, 43);
            lbl_MaxExitTime.Name = "lbl_MaxExitTime";
            lbl_MaxExitTime.Size = new Size(57, 20);
            lbl_MaxExitTime.TabIndex = 29;
            lbl_MaxExitTime.Text = "59:59:59";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(1090, 43);
            label14.Name = "label14";
            label14.Size = new Size(103, 20);
            label14.TabIndex = 28;
            label14.Text = "دیرترین زمان خروج:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(304, 8);
            label10.Name = "label10";
            label10.Size = new Size(101, 20);
            label10.TabIndex = 26;
            label10.Text = "مجموع اضافه کاری:";
            // 
            // lbl_sumaddwork
            // 
            lbl_sumaddwork.AutoSize = true;
            lbl_sumaddwork.Location = new Point(278, 8);
            lbl_sumaddwork.Name = "lbl_sumaddwork";
            lbl_sumaddwork.Size = new Size(16, 20);
            lbl_sumaddwork.TabIndex = 27;
            lbl_sumaddwork.Text = "0";
            lbl_sumaddwork.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(474, 43);
            label6.Name = "label6";
            label6.Size = new Size(137, 20);
            label6.TabIndex = 24;
            label6.Text = "میانگین ساعات کاری روزانه:";
            // 
            // lbl_avgtimework
            // 
            lbl_avgtimework.AutoSize = true;
            lbl_avgtimework.Location = new Point(393, 43);
            lbl_avgtimework.Name = "lbl_avgtimework";
            lbl_avgtimework.Size = new Size(77, 20);
            lbl_avgtimework.TabIndex = 25;
            lbl_avgtimework.Text = "107h , 32.95";
            // 
            // lbl_minEntry
            // 
            lbl_minEntry.AutoSize = true;
            lbl_minEntry.Location = new Point(1203, 43);
            lbl_minEntry.Name = "lbl_minEntry";
            lbl_minEntry.Size = new Size(57, 20);
            lbl_minEntry.TabIndex = 23;
            lbl_minEntry.Text = "59:59:59";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(1267, 43);
            label8.Name = "label8";
            label8.Size = new Size(99, 20);
            label8.TabIndex = 22;
            label8.Text = "زودترین زمان ورود:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(444, 8);
            label4.Name = "label4";
            label4.Size = new Size(139, 20);
            label4.TabIndex = 20;
            label4.Text = "مجموع غیبت(غیر تعطیلات):";
            // 
            // lbl_sumOff
            // 
            lbl_sumOff.AutoSize = true;
            lbl_sumOff.Location = new Point(421, 8);
            lbl_sumOff.Name = "lbl_sumOff";
            lbl_sumOff.Size = new Size(16, 20);
            lbl_sumOff.TabIndex = 21;
            lbl_sumOff.Text = "0";
            lbl_sumOff.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(627, 8);
            label13.Name = "label13";
            label13.Size = new Size(147, 20);
            label13.TabIndex = 14;
            label13.Text = "مجموع روز های ورود با تاخیر:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(1256, 8);
            label2.Name = "label2";
            label2.Size = new Size(114, 20);
            label2.TabIndex = 4;
            label2.Text = "مجموع روز های کاری :";
            // 
            // txtbox_lade
            // 
            txtbox_lade.Location = new Point(91, 4);
            txtbox_lade.Mask = "00:00:00";
            txtbox_lade.Name = "txtbox_lade";
            txtbox_lade.Size = new Size(69, 28);
            txtbox_lade.TabIndex = 19;
            txtbox_lade.Text = "083000";
            txtbox_lade.TextAlign = HorizontalAlignment.Center;
            txtbox_lade.ValidatingType = typeof(DateTime);
            // 
            // lbl_sumdayworker
            // 
            lbl_sumdayworker.AutoSize = true;
            lbl_sumdayworker.Location = new Point(1213, 8);
            lbl_sumdayworker.Name = "lbl_sumdayworker";
            lbl_sumdayworker.Size = new Size(37, 20);
            lbl_sumdayworker.TabIndex = 5;
            lbl_sumdayworker.Text = "1000";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(166, 7);
            label3.Name = "label3";
            label3.Size = new Size(84, 20);
            label3.TabIndex = 18;
            label3.Text = "شرط زمان تاخیر:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(1093, 8);
            label5.Name = "label5";
            label5.Size = new Size(85, 20);
            label5.TabIndex = 6;
            label5.Text = "مجموع ساعت  :";
            // 
            // btn_submit
            // 
            btn_submit.Location = new Point(91, 36);
            btn_submit.Name = "btn_submit";
            btn_submit.Size = new Size(159, 30);
            btn_submit.TabIndex = 16;
            btn_submit.Text = "اعمال";
            btn_submit.UseVisualStyleBackColor = true;
            btn_submit.Click += btn_Submit_Click;
            // 
            // lbl_sumhour
            // 
            lbl_sumhour.AutoSize = true;
            lbl_sumhour.Location = new Point(997, 8);
            lbl_sumhour.Name = "lbl_sumhour";
            lbl_sumhour.Size = new Size(77, 20);
            lbl_sumhour.TabIndex = 7;
            lbl_sumhour.Text = "107h , 32.95";
            // 
            // lbl_sumentryDelay
            // 
            lbl_sumentryDelay.AutoSize = true;
            lbl_sumentryDelay.Location = new Point(590, 8);
            lbl_sumentryDelay.Name = "lbl_sumentryDelay";
            lbl_sumentryDelay.Size = new Size(30, 20);
            lbl_sumentryDelay.TabIndex = 15;
            lbl_sumentryDelay.Text = "100";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(888, 8);
            label7.Name = "label7";
            label7.Size = new Size(79, 20);
            label7.TabIndex = 8;
            label7.Text = "مجموع دقایق :";
            // 
            // lbl_summinute
            // 
            lbl_summinute.AutoSize = true;
            lbl_summinute.Location = new Point(832, 8);
            lbl_summinute.Name = "lbl_summinute";
            lbl_summinute.Size = new Size(16, 20);
            lbl_summinute.TabIndex = 9;
            lbl_summinute.Text = "0";
            lbl_summinute.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_avgexit
            // 
            lbl_avgexit.AutoSize = true;
            lbl_avgexit.Location = new Point(617, 43);
            lbl_avgexit.Name = "lbl_avgexit";
            lbl_avgexit.Size = new Size(57, 20);
            lbl_avgexit.TabIndex = 13;
            lbl_avgexit.Text = "59:59:59";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(881, 43);
            label9.Name = "label9";
            label9.Size = new Size(132, 20);
            label9.TabIndex = 10;
            label9.Text = "میانگین ساعت های ورود :";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(674, 43);
            label11.Name = "label11";
            label11.Size = new Size(137, 20);
            label11.TabIndex = 12;
            label11.Text = "میانگین ساعت های خروج :";
            // 
            // lbl_avgentry
            // 
            lbl_avgentry.AutoSize = true;
            lbl_avgentry.Location = new Point(821, 43);
            lbl_avgentry.Name = "lbl_avgentry";
            lbl_avgentry.Size = new Size(57, 20);
            lbl_avgentry.TabIndex = 11;
            lbl_avgentry.Text = "16:59:59";
            // 
            // lbl_FromTo
            // 
            lbl_FromTo.AutoSize = true;
            lbl_FromTo.Location = new Point(117, 7);
            lbl_FromTo.Name = "lbl_FromTo";
            lbl_FromTo.Size = new Size(16, 20);
            lbl_FromTo.TabIndex = 20;
            lbl_FromTo.Text = "0";
            // 
            // lbl_user
            // 
            lbl_user.AutoSize = true;
            lbl_user.Location = new Point(298, 4);
            lbl_user.Name = "lbl_user";
            lbl_user.Size = new Size(0, 20);
            lbl_user.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(346, 7);
            label1.Name = "label1";
            label1.Size = new Size(35, 20);
            label1.TabIndex = 2;
            label1.Text = "کاربر :";
            // 
            // dataView_calender
            // 
            dataView_calender.AllowUserToAddRows = false;
            dataView_calender.AllowUserToDeleteRows = false;
            dataView_calender.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataView_calender.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataView_calender.Location = new Point(3, 115);
            dataView_calender.Name = "dataView_calender";
            dataView_calender.ReadOnly = true;
            dataView_calender.RightToLeft = RightToLeft.No;
            dataView_calender.RowHeadersWidth = 70;
            dataView_calender.Size = new Size(1301, 567);
            dataView_calender.TabIndex = 0;
            dataView_calender.VirtualMode = true;
            dataView_calender.RowPostPaint += dataView_calender_RowPostPaint;
            dataView_calender.RowPrePaint += dataView_calender_RowPrePaint;
            // 
            // menuStrip2
            // 
            menuStrip2.Font = new Font("IRANSans", 8.249999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            menuStrip2.Items.AddRange(new ToolStripItem[] { OutputExcelToolStripMenuItem });
            menuStrip2.Location = new Point(3, 4);
            menuStrip2.Name = "menuStrip2";
            menuStrip2.Size = new Size(1301, 27);
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
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Margin = new Padding(3, 4, 3, 4);
            tabControl1.Name = "tabControl1";
            tabControl1.RightToLeft = RightToLeft.Yes;
            tabControl1.RightToLeftLayout = true;
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1315, 716);
            tabControl1.TabIndex = 0;
            // 
            // tabPage_durationdays
            // 
            tabPage_durationdays.Controls.Add(button1);
            tabPage_durationdays.Controls.Add(groupBox1);
            tabPage_durationdays.Controls.Add(dataView_lade);
            tabPage_durationdays.Location = new Point(4, 29);
            tabPage_durationdays.Name = "tabPage_durationdays";
            tabPage_durationdays.Padding = new Padding(3);
            tabPage_durationdays.Size = new Size(1307, 683);
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
            button1.Click += button1_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(radioButton_holidays);
            groupBox1.Controls.Add(radioButton_qeybat);
            groupBox1.Location = new Point(876, 6);
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
            // dataView_lade
            // 
            dataView_lade.AllowUserToAddRows = false;
            dataView_lade.AllowUserToDeleteRows = false;
            dataView_lade.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataView_lade.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataView_lade.Location = new Point(0, 87);
            dataView_lade.Name = "dataView_lade";
            dataView_lade.ReadOnly = true;
            dataView_lade.RightToLeft = RightToLeft.No;
            dataView_lade.RowHeadersWidth = 70;
            dataView_lade.Size = new Size(1307, 568);
            dataView_lade.TabIndex = 22;
            dataView_lade.VirtualMode = true;
            dataView_lade.RowPostPaint += dataView_calender_RowPostPaint;
            // 
            // FrmCalc
            // 
            AcceptButton = btn_submit;
            AutoScaleDimensions = new SizeF(7F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1315, 716);
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
            ((System.ComponentModel.ISupportInitialize)dataView_calender).EndInit();
            menuStrip2.ResumeLayout(false);
            menuStrip2.PerformLayout();
            tabControl1.ResumeLayout(false);
            tabPage_durationdays.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataView_lade).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabPage tabpage_detailvorodkhoroj;
        private Panel panel1;
        private Label label6;
        private Label lbl_avgtimework;
        private Label lbl_minEntry;
        private Label label8;
        private Label label4;
        private Label lbl_sumOff;
        private Label label13;
        private Label label2;
        private MaskedTextBox txtbox_lade;
        private Label lbl_sumdayworker;
        private Label label3;
        private Label label5;
        private Button btn_submit;
        private Label lbl_sumhour;
        private Label lbl_sumentryDelay;
        private Label label7;
        private Label lbl_summinute;
        private Label lbl_avgexit;
        private Label label9;
        private Label label11;
        private Label lbl_avgentry;
        private Label lbl_FromTo;
        private Label lbl_user;
        private Label label1;
        private DataGridView dataView_calender;
        private TabControl tabControl1;
        private Label label10;
        private Label lbl_us;
        private Label lbl_sumaddwork;
        private Label lbl_MaxExitTime;
        private Label label14;
        private MenuStrip menuStrip2;
        private ToolStripMenuItem OutputExcelToolStripMenuItem;
        private TabPage tabPage_durationdays;
        private DataGridView dataView_lade;
        private GroupBox groupBox1;
        private RadioButton radioButton_qeybat;
        private RadioButton radioButton_holidays;
        private Button button1;
    }
}