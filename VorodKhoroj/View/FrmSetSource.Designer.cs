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
            components = new Container();
            btn_submit = new Button();
            radiobtn_database = new RadioButton();
            radiobtn_textfile = new RadioButton();
            label1 = new Label();
            contextMenuStrip1 = new ContextMenuStrip(components);
            AdditemToolStripMenuItem = new ToolStripMenuItem();
            groupBox1 = new GroupBox();
            txt_ServerName = new ComboBox();
            contextMenuStrip1.SuspendLayout();
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
            radiobtn_database.CheckedChanged += radioBtn_database_CheckedChanged;
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
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { AdditemToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(153, 26);
            // 
            // AdditemToolStripMenuItem
            // 
            AdditemToolStripMenuItem.Name = "AdditemToolStripMenuItem";
            AdditemToolStripMenuItem.Size = new Size(152, 22);
            AdditemToolStripMenuItem.Text = "افزودن به لیست";
            AdditemToolStripMenuItem.Click += AddItemsToolStripMenuItem_Click;
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
            txt_ServerName.AutoCompleteMode = AutoCompleteMode.Suggest;
            txt_ServerName.AutoCompleteSource = AutoCompleteSource.ListItems;
            txt_ServerName.ContextMenuStrip = contextMenuStrip1;
            txt_ServerName.FormattingEnabled = true;
            txt_ServerName.Location = new Point(6, 58);
            txt_ServerName.Name = "txt_ServerName";
            txt_ServerName.RightToLeft = RightToLeft.No;
            txt_ServerName.Size = new Size(112, 28);
            txt_ServerName.TabIndex = 7;
            txt_ServerName.MouseClick += txt_ServerName_MouseClick;
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
            Load += FrmSetSource_Load;
            contextMenuStrip1.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btn_submit;
        private RadioButton radiobtn_database;
        private RadioButton radiobtn_textfile;
        private Label label1;
        private GroupBox groupBox1;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem AdditemToolStripMenuItem;
        private ComboBox txt_ServerName;
    }
}