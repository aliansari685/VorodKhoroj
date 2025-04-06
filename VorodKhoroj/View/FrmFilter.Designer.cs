namespace VorodKhoroj.View
{
    partial class FrmFilter
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
            btn_clear = new Button();
            label3 = new Label();
            btn_applyfilter = new Button();
            label2 = new Label();
            toDateTime_txtbox = new MaskedTextBox();
            label1 = new Label();
            FromDateTime_txtbox = new MaskedTextBox();
            Userid_txtbox = new ComboBox();
            SuspendLayout();
            // 
            // btn_clear
            // 
            btn_clear.BackColor = Color.Lavender;
            btn_clear.BackgroundImage = Properties.Resources.clear_icon_9213;
            btn_clear.BackgroundImageLayout = ImageLayout.Stretch;
            btn_clear.Location = new Point(12, 151);
            btn_clear.Margin = new Padding(3, 4, 3, 4);
            btn_clear.Name = "btn_clear";
            btn_clear.Size = new Size(45, 39);
            btn_clear.TabIndex = 4;
            btn_clear.UseVisualStyleBackColor = false;
            btn_clear.Click += btn_clear_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(169, 104);
            label3.Name = "label3";
            label3.RightToLeft = RightToLeft.Yes;
            label3.Size = new Size(45, 19);
            label3.TabIndex = 18;
            label3.Text = "کد کاربر:";
            // 
            // btn_applyfilter
            // 
            btn_applyfilter.Location = new Point(63, 151);
            btn_applyfilter.Margin = new Padding(3, 4, 3, 4);
            btn_applyfilter.Name = "btn_applyfilter";
            btn_applyfilter.Size = new Size(151, 39);
            btn_applyfilter.TabIndex = 3;
            btn_applyfilter.Text = "اعمال فیلتر";
            btn_applyfilter.UseVisualStyleBackColor = true;
            btn_applyfilter.Click += btn_applyfilter_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(169, 70);
            label2.Name = "label2";
            label2.RightToLeft = RightToLeft.Yes;
            label2.Size = new Size(45, 19);
            label2.TabIndex = 16;
            label2.Text = "تاریخ تا:";
            // 
            // toDateTime_txtbox
            // 
            toDateTime_txtbox.Location = new Point(36, 66);
            toDateTime_txtbox.Margin = new Padding(3, 4, 3, 4);
            toDateTime_txtbox.Mask = "1000/00/00";
            toDateTime_txtbox.Name = "toDateTime_txtbox";
            toDateTime_txtbox.Size = new Size(127, 26);
            toDateTime_txtbox.TabIndex = 1;
            toDateTime_txtbox.ValidatingType = typeof(DateTime);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(169, 27);
            label1.Name = "label1";
            label1.RightToLeft = RightToLeft.Yes;
            label1.Size = new Size(45, 19);
            label1.TabIndex = 14;
            label1.Text = "تاریخ از:";
            // 
            // FromDateTime_txtbox
            // 
            FromDateTime_txtbox.Location = new Point(36, 23);
            FromDateTime_txtbox.Margin = new Padding(3, 4, 3, 4);
            FromDateTime_txtbox.Mask = "1000/00/00";
            FromDateTime_txtbox.Name = "FromDateTime_txtbox";
            FromDateTime_txtbox.Size = new Size(127, 26);
            FromDateTime_txtbox.TabIndex = 0;
            FromDateTime_txtbox.ValidatingType = typeof(DateTime);
            // 
            // Userid_txtbox
            // 
            Userid_txtbox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            Userid_txtbox.AutoCompleteSource = AutoCompleteSource.ListItems;
            Userid_txtbox.DisplayMember = "userid";
            Userid_txtbox.FormattingEnabled = true;
            Userid_txtbox.Location = new Point(106, 101);
            Userid_txtbox.Name = "Userid_txtbox";
            Userid_txtbox.Size = new Size(57, 27);
            Userid_txtbox.TabIndex = 2;
            // 
            // FrmFilter
            // 
            AcceptButton = btn_applyfilter;
            AutoScaleDimensions = new SizeF(7F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(244, 207);
            Controls.Add(Userid_txtbox);
            Controls.Add(btn_clear);
            Controls.Add(label3);
            Controls.Add(btn_applyfilter);
            Controls.Add(label2);
            Controls.Add(toDateTime_txtbox);
            Controls.Add(label1);
            Controls.Add(FromDateTime_txtbox);
            Font = new Font("IRANSans", 8.249999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Margin = new Padding(3, 4, 3, 4);
            Name = "FrmFilter";
            Text = "FrmFilter";
            Load += FrmFilter_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_clear;
        private Label label3;
        private Button btn_applyfilter;
        private Label label2;
        private Label label1;
        public MaskedTextBox toDateTime_txtbox;
        public MaskedTextBox FromDateTime_txtbox;
        public ComboBox Userid_txtbox;
    }
}