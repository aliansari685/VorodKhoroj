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
            tabControl1 = new TabControl();
            tabpage_detailvorodkhoroj = new TabPage();
            panel1 = new Panel();
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
            tabPage2 = new TabPage();
            tabControl1.SuspendLayout();
            tabpage_detailvorodkhoroj.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataView_calender).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabpage_detailvorodkhoroj);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Margin = new Padding(3, 4, 3, 4);
            tabControl1.Name = "tabControl1";
            tabControl1.RightToLeft = RightToLeft.Yes;
            tabControl1.RightToLeftLayout = true;
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1053, 699);
            tabControl1.TabIndex = 0;
            // 
            // tabpage_detailvorodkhoroj
            // 
            tabpage_detailvorodkhoroj.BackColor = Color.Transparent;
            tabpage_detailvorodkhoroj.Controls.Add(panel1);
            tabpage_detailvorodkhoroj.Controls.Add(lbl_FromTo);
            tabpage_detailvorodkhoroj.Controls.Add(lbl_user);
            tabpage_detailvorodkhoroj.Controls.Add(label1);
            tabpage_detailvorodkhoroj.Controls.Add(dataView_calender);
            tabpage_detailvorodkhoroj.Location = new Point(4, 29);
            tabpage_detailvorodkhoroj.Margin = new Padding(3, 4, 3, 4);
            tabpage_detailvorodkhoroj.Name = "tabpage_detailvorodkhoroj";
            tabpage_detailvorodkhoroj.Padding = new Padding(3, 4, 3, 4);
            tabpage_detailvorodkhoroj.Size = new Size(1045, 666);
            tabpage_detailvorodkhoroj.TabIndex = 0;
            tabpage_detailvorodkhoroj.Text = "جزییات ورود خروج";
            // 
            // panel1
            // 
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
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(3, 29);
            panel1.Name = "panel1";
            panel1.Size = new Size(1039, 77);
            panel1.TabIndex = 21;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(146, 41);
            label6.Name = "label6";
            label6.Size = new Size(137, 20);
            label6.TabIndex = 24;
            label6.Text = "میانگین ساعات کاری روزانه:";
            // 
            // lbl_avgtimework
            // 
            lbl_avgtimework.AutoSize = true;
            lbl_avgtimework.Location = new Point(65, 41);
            lbl_avgtimework.Name = "lbl_avgtimework";
            lbl_avgtimework.Size = new Size(77, 20);
            lbl_avgtimework.TabIndex = 25;
            lbl_avgtimework.Text = "107h , 32.95";
            // 
            // lbl_minEntry
            // 
            lbl_minEntry.AutoSize = true;
            lbl_minEntry.Location = new Point(297, 41);
            lbl_minEntry.Name = "lbl_minEntry";
            lbl_minEntry.Size = new Size(57, 20);
            lbl_minEntry.TabIndex = 23;
            lbl_minEntry.Text = "59:59:59";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(360, 41);
            label8.Name = "label8";
            label8.Size = new Size(99, 20);
            label8.TabIndex = 22;
            label8.Text = "زودترین زمان ورود:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(503, 41);
            label4.Name = "label4";
            label4.Size = new Size(126, 20);
            label4.TabIndex = 20;
            label4.Text = "مجموع غیبت(غیر جمعه):";
            // 
            // lbl_sumOff
            // 
            lbl_sumOff.AutoSize = true;
            lbl_sumOff.Location = new Point(479, 41);
            lbl_sumOff.Name = "lbl_sumOff";
            lbl_sumOff.Size = new Size(16, 20);
            lbl_sumOff.TabIndex = 21;
            lbl_sumOff.Text = "0";
            lbl_sumOff.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(291, 9);
            label13.Name = "label13";
            label13.Size = new Size(147, 20);
            label13.TabIndex = 14;
            label13.Text = "مجموع روز های ورود با تاخیر:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(920, 9);
            label2.Name = "label2";
            label2.Size = new Size(114, 20);
            label2.TabIndex = 4;
            label2.Text = "مجموع روز های کاری :";
            // 
            // txtbox_lade
            // 
            txtbox_lade.Location = new Point(91, 6);
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
            lbl_sumdayworker.Location = new Point(877, 9);
            lbl_sumdayworker.Name = "lbl_sumdayworker";
            lbl_sumdayworker.Size = new Size(37, 20);
            lbl_sumdayworker.TabIndex = 5;
            lbl_sumdayworker.Text = "1000";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(163, 9);
            label3.Name = "label3";
            label3.Size = new Size(84, 20);
            label3.TabIndex = 18;
            label3.Text = "شرط زمان تاخیر:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(758, 9);
            label5.Name = "label5";
            label5.Size = new Size(85, 20);
            label5.TabIndex = 6;
            label5.Text = "مجموع ساعت  :";
            // 
            // btn_submit
            // 
            btn_submit.Location = new Point(7, 6);
            btn_submit.Name = "btn_submit";
            btn_submit.Size = new Size(77, 29);
            btn_submit.TabIndex = 16;
            btn_submit.Text = "اعمال";
            btn_submit.UseVisualStyleBackColor = true;
            btn_submit.Click += btn_Submit_Click;
            // 
            // lbl_sumhour
            // 
            lbl_sumhour.AutoSize = true;
            lbl_sumhour.Location = new Point(661, 9);
            lbl_sumhour.Name = "lbl_sumhour";
            lbl_sumhour.Size = new Size(77, 20);
            lbl_sumhour.TabIndex = 7;
            lbl_sumhour.Text = "107h , 32.95";
            // 
            // lbl_sumentryDelay
            // 
            lbl_sumentryDelay.AutoSize = true;
            lbl_sumentryDelay.Location = new Point(255, 9);
            lbl_sumentryDelay.Name = "lbl_sumentryDelay";
            lbl_sumentryDelay.Size = new Size(37, 20);
            lbl_sumentryDelay.TabIndex = 15;
            lbl_sumentryDelay.Text = "1000";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(552, 9);
            label7.Name = "label7";
            label7.Size = new Size(79, 20);
            label7.TabIndex = 8;
            label7.Text = "مجموع دقایق :";
            // 
            // lbl_summinute
            // 
            lbl_summinute.AutoSize = true;
            lbl_summinute.Location = new Point(499, 9);
            lbl_summinute.Name = "lbl_summinute";
            lbl_summinute.Size = new Size(16, 20);
            lbl_summinute.TabIndex = 9;
            lbl_summinute.Text = "0";
            lbl_summinute.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_avgexit
            // 
            lbl_avgexit.AutoSize = true;
            lbl_avgexit.Location = new Point(634, 41);
            lbl_avgexit.Name = "lbl_avgexit";
            lbl_avgexit.Size = new Size(57, 20);
            lbl_avgexit.TabIndex = 13;
            lbl_avgexit.Text = "59:59:59";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(904, 41);
            label9.Name = "label9";
            label9.Size = new Size(132, 20);
            label9.TabIndex = 10;
            label9.Text = "میانگین ساعت های ورود :";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(697, 41);
            label11.Name = "label11";
            label11.Size = new Size(137, 20);
            label11.TabIndex = 12;
            label11.Text = "میانگین ساعت های خروج :";
            // 
            // lbl_avgentry
            // 
            lbl_avgentry.AutoSize = true;
            lbl_avgentry.Location = new Point(841, 41);
            lbl_avgentry.Name = "lbl_avgentry";
            lbl_avgentry.Size = new Size(57, 20);
            lbl_avgentry.TabIndex = 11;
            lbl_avgentry.Text = "16:59:59";
            // 
            // lbl_FromTo
            // 
            lbl_FromTo.AutoSize = true;
            lbl_FromTo.Location = new Point(424, 4);
            lbl_FromTo.Name = "lbl_FromTo";
            lbl_FromTo.Size = new Size(16, 20);
            lbl_FromTo.TabIndex = 20;
            lbl_FromTo.Text = "0";
            // 
            // lbl_user
            // 
            lbl_user.AutoSize = true;
            lbl_user.Location = new Point(606, 4);
            lbl_user.Name = "lbl_user";
            lbl_user.Size = new Size(0, 20);
            lbl_user.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(654, 4);
            label1.Name = "label1";
            label1.Size = new Size(35, 20);
            label1.TabIndex = 2;
            label1.Text = "کاربر :";
            // 
            // dataView_calender
            // 
            dataView_calender.AllowUserToAddRows = false;
            dataView_calender.AllowUserToDeleteRows = false;
            dataView_calender.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataView_calender.Dock = DockStyle.Bottom;
            dataView_calender.Location = new Point(3, 106);
            dataView_calender.Name = "dataView_calender";
            dataView_calender.ReadOnly = true;
            dataView_calender.RightToLeft = RightToLeft.No;
            dataView_calender.RowHeadersWidth = 70;
            dataView_calender.Size = new Size(1039, 556);
            dataView_calender.TabIndex = 0;
            dataView_calender.RowPostPaint += dataView_calender_RowPostPaint;
            dataView_calender.RowPrePaint += dataView_calender_RowPrePaint;
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 24);
            tabPage2.Margin = new Padding(3, 4, 3, 4);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3, 4, 3, 4);
            tabPage2.Size = new Size(1045, 671);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "tabPage2";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // FrmCalc
            // 
            AcceptButton = btn_submit;
            AutoScaleDimensions = new SizeF(7F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1053, 699);
            Controls.Add(tabControl1);
            Font = new Font("IRANSans", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 4, 3, 4);
            Name = "FrmCalc";
            Text = "FrmCalc";
            Load += FrmCalc_Load;
            tabControl1.ResumeLayout(false);
            tabpage_detailvorodkhoroj.ResumeLayout(false);
            tabpage_detailvorodkhoroj.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataView_calender).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabpage_detailvorodkhoroj;
        private TabPage tabPage2;
        private DataGridView dataView_calender;
        private Label label1;
        private Label lbl_user;
        private Label label2;
        private Label lbl_sumdayworker;
        private Label lbl_sumhour;
        private Label label5;
        private Label lbl_summinute;
        private Label label7;
        private Label lbl_avgentry;
        private Label label9;
        private Label lbl_avgexit;
        private Label label11;
        private Label lbl_sumentryDelay;
        private Label label13;
        private Button btn_submit;
        private MaskedTextBox txtbox_lade;
        private Label label3;
        private Label lbl_FromTo;
        private Panel panel1;
        private Label label4;
        private Label lbl_sumOff;
        private Label lbl_minEntry;
        private Label label8;
        private Label label6;
        private Label lbl_avgtimework;
    }
}