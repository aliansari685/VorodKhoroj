namespace VorodKhoroj.View
{
    partial class FrmSetSource
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
            btn_submit = new Button();
            radiobtn_textfile = new RadioButton();
            radiobtn_database = new RadioButton();
            groupBox1 = new GroupBox();
            txt_ServerName = new TextBox();
            label1 = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // btn_submit
            // 
            btn_submit.Location = new Point(12, 118);
            btn_submit.Margin = new Padding(3, 4, 3, 4);
            btn_submit.Name = "btn_submit";
            btn_submit.Size = new Size(232, 42);
            btn_submit.TabIndex = 0;
            btn_submit.Text = "ثبت";
            btn_submit.UseVisualStyleBackColor = true;
            btn_submit.Click += btn_submit_Click;
            // 
            // radiobtn_textfile
            // 
            radiobtn_textfile.AutoSize = true;
            radiobtn_textfile.Checked = true;
            radiobtn_textfile.Location = new Point(142, 27);
            radiobtn_textfile.Name = "radiobtn_textfile";
            radiobtn_textfile.Size = new Size(75, 24);
            radiobtn_textfile.TabIndex = 2;
            radiobtn_textfile.TabStop = true;
            radiobtn_textfile.Text = "فایل متنی";
            radiobtn_textfile.UseVisualStyleBackColor = true;
            // 
            // radiobtn_database
            // 
            radiobtn_database.AutoSize = true;
            radiobtn_database.Location = new Point(41, 27);
            radiobtn_database.Name = "radiobtn_database";
            radiobtn_database.Size = new Size(77, 24);
            radiobtn_database.TabIndex = 3;
            radiobtn_database.TabStop = true;
            radiobtn_database.Text = "پایگاه داده";
            radiobtn_database.UseVisualStyleBackColor = true;
            radiobtn_database.CheckedChanged += radiobtn_database_CheckedChanged;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txt_ServerName);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(radiobtn_textfile);
            groupBox1.Controls.Add(radiobtn_database);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.RightToLeft = RightToLeft.Yes;
            groupBox1.Size = new Size(232, 99);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "انتخاب منبع داده";
            // 
            // txt_ServerName
            // 
            txt_ServerName.Enabled = false;
            txt_ServerName.Location = new Point(6, 58);
            txt_ServerName.Margin = new Padding(3, 4, 3, 4);
            txt_ServerName.Name = "txt_ServerName";
            txt_ServerName.RightToLeft = RightToLeft.No;
            txt_ServerName.Size = new Size(112, 28);
            txt_ServerName.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(119, 61);
            label1.Name = "label1";
            label1.RightToLeft = RightToLeft.Yes;
            label1.Size = new Size(107, 20);
            label1.TabIndex = 6;
            label1.Text = "نام سرور پایگاه داده :";
            // 
            // FrmSetSource
            // 
            AcceptButton = btn_submit;
            AutoScaleDimensions = new SizeF(7F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(255, 170);
            Controls.Add(groupBox1);
            Controls.Add(btn_submit);
            Font = new Font("IRANSans", 9F);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Margin = new Padding(3, 4, 3, 4);
            Name = "FrmSetSource";
            Text = "FrmSetSource";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btn_submit;
        private RadioButton radiobtn_textfile;
        private RadioButton radiobtn_database;
        private GroupBox groupBox1;
        private TextBox txt_ServerName;
        private Label label1;
    }
}