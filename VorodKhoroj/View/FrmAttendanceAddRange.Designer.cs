namespace VorodKhoroj.View
{
    partial class FrmAttendanceAddRange
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
            btn_addRange = new Button();
            label2 = new Label();
            toDateTime_txtbox = new MaskedTextBox();
            label1 = new Label();
            FromDateTime_txtbox = new MaskedTextBox();
            SuspendLayout();
            // 
            // btn_addRange
            // 
            btn_addRange.Location = new Point(12, 88);
            btn_addRange.Margin = new Padding(3, 5, 3, 5);
            btn_addRange.Name = "btn_addRange";
            btn_addRange.Size = new Size(178, 49);
            btn_addRange.TabIndex = 2;
            btn_addRange.Text = "ثبت";
            btn_addRange.UseVisualStyleBackColor = true;
            btn_addRange.Click += btn_addRange_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(145, 57);
            label2.Name = "label2";
            label2.RightToLeft = RightToLeft.Yes;
            label2.Size = new Size(45, 19);
            label2.TabIndex = 25;
            label2.Text = "تاریخ تا:";
            // 
            // toDateTime_txtbox
            // 
            toDateTime_txtbox.Location = new Point(12, 52);
            toDateTime_txtbox.Margin = new Padding(3, 5, 3, 5);
            toDateTime_txtbox.Mask = "1000/00/00";
            toDateTime_txtbox.Name = "toDateTime_txtbox";
            toDateTime_txtbox.Size = new Size(127, 26);
            toDateTime_txtbox.TabIndex = 1;
            toDateTime_txtbox.ValidatingType = typeof(DateTime);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(145, 19);
            label1.Name = "label1";
            label1.RightToLeft = RightToLeft.Yes;
            label1.Size = new Size(45, 19);
            label1.TabIndex = 24;
            label1.Text = "تاریخ از:";
            // 
            // FromDateTime_txtbox
            // 
            FromDateTime_txtbox.Location = new Point(12, 14);
            FromDateTime_txtbox.Margin = new Padding(3, 5, 3, 5);
            FromDateTime_txtbox.Mask = "1000/00/00";
            FromDateTime_txtbox.Name = "FromDateTime_txtbox";
            FromDateTime_txtbox.Size = new Size(127, 26);
            FromDateTime_txtbox.TabIndex = 0;
            FromDateTime_txtbox.ValidatingType = typeof(DateTime);
            // 
            // FrmAttendanceAddRange
            // 
            AcceptButton = btn_addRange;
            AutoScaleDimensions = new SizeF(7F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(206, 148);
            Controls.Add(btn_addRange);
            Controls.Add(label2);
            Controls.Add(toDateTime_txtbox);
            Controls.Add(label1);
            Controls.Add(FromDateTime_txtbox);
            Font = new Font("IRANSans", 8.249999F);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Margin = new Padding(3, 4, 3, 4);
            Name = "FrmAttendanceAddRange";
            Text = "FrmAttendanceAddRange";
            Load += FrmAttendanceAddRange_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btn_addRange;
        private Label label2;
        public MaskedTextBox toDateTime_txtbox;
        private Label label1;
        public MaskedTextBox FromDateTime_txtbox;
    }
}