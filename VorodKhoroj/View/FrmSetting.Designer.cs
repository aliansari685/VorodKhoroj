namespace VorodKhoroj.View
{
    partial class FrmSetting
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
            btn_testdb = new Button();
            btn_CreateDatabase = new Button();
            label1 = new Label();
            txt_ServerName = new ComboBox();
            SuspendLayout();
            // 
            // btn_testdb
            // 
            btn_testdb.Location = new Point(23, 13);
            btn_testdb.Margin = new Padding(3, 4, 3, 4);
            btn_testdb.Name = "btn_testdb";
            btn_testdb.Size = new Size(75, 28);
            btn_testdb.TabIndex = 1;
            btn_testdb.Text = "تست اتصال";
            btn_testdb.UseVisualStyleBackColor = true;
            btn_testdb.Click += Btn_testdb_Click;
            // 
            // btn_CreateDatabase
            // 
            btn_CreateDatabase.Location = new Point(23, 49);
            btn_CreateDatabase.Margin = new Padding(3, 4, 3, 4);
            btn_CreateDatabase.Name = "btn_CreateDatabase";
            btn_CreateDatabase.Size = new Size(319, 44);
            btn_CreateDatabase.TabIndex = 2;
            btn_CreateDatabase.Text = "ایجاد پایگاه داده و انتقال داده ها";
            btn_CreateDatabase.UseVisualStyleBackColor = true;
            btn_CreateDatabase.Click += btn_CreateDatabase_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(235, 17);
            label1.Name = "label1";
            label1.RightToLeft = RightToLeft.Yes;
            label1.Size = new Size(107, 20);
            label1.TabIndex = 3;
            label1.Text = "نام سرور پایگاه داده :";
            // 
            // txt_ServerName
            // 
            txt_ServerName.AutoCompleteMode = AutoCompleteMode.Suggest;
            txt_ServerName.AutoCompleteSource = AutoCompleteSource.ListItems;
            txt_ServerName.FormattingEnabled = true;
            txt_ServerName.Location = new Point(104, 14);
            txt_ServerName.Name = "txt_ServerName";
            txt_ServerName.RightToLeft = RightToLeft.No;
            txt_ServerName.Size = new Size(131, 28);
            txt_ServerName.TabIndex = 0;
            // 
            // FrmSetting
            // 
            AcceptButton = btn_testdb;
            AutoScaleDimensions = new SizeF(7F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(360, 114);
            Controls.Add(txt_ServerName);
            Controls.Add(label1);
            Controls.Add(btn_CreateDatabase);
            Controls.Add(btn_testdb);
            Font = new Font("IRANSans", 9F);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Margin = new Padding(3, 4, 3, 4);
            Name = "FrmSetting";
            Text = "FrmSetting";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_testdb;
        private Button btn_CreateDatabase;
        private Label label1;
        private ComboBox txt_ServerName;
    }
}