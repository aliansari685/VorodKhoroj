namespace VorodKhoroj.View
{
    partial class FrmUsers
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
            dataGridView1 = new DataGridView();
            userBindingSource = new BindingSource(components);
            userIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            Userid_txtbox = new ComboBox();
            label3 = new Label();
            btn_submit = new Button();
            UserName_txtbox = new TextBox();
            label1 = new Label();
            ((ISupportInitialize)dataGridView1).BeginInit();
            ((ISupportInitialize)userBindingSource).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToOrderColumns = true;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { userIdDataGridViewTextBoxColumn, nameDataGridViewTextBoxColumn });
            dataGridView1.DataSource = userBindingSource;
            dataGridView1.Dock = DockStyle.Bottom;
            dataGridView1.Location = new Point(0, 128);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.Size = new Size(477, 335);
            dataGridView1.TabIndex = 0;
            // 
            // userBindingSource
            // 
            userBindingSource.DataSource = typeof(User);
            // 
            // userIdDataGridViewTextBoxColumn
            // 
            userIdDataGridViewTextBoxColumn.DataPropertyName = "UserId";
            userIdDataGridViewTextBoxColumn.HeaderText = "شناسه کاربر";
            userIdDataGridViewTextBoxColumn.Name = "userIdDataGridViewTextBoxColumn";
            userIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            nameDataGridViewTextBoxColumn.HeaderText = "نام کاربر";
            nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // Userid_txtbox
            // 
            Userid_txtbox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            Userid_txtbox.AutoCompleteSource = AutoCompleteSource.ListItems;
            Userid_txtbox.DisplayMember = "userid";
            Userid_txtbox.FormattingEnabled = true;
            Userid_txtbox.Location = new Point(295, 20);
            Userid_txtbox.Name = "Userid_txtbox";
            Userid_txtbox.Size = new Size(109, 28);
            Userid_txtbox.TabIndex = 15;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(411, 23);
            label3.Name = "label3";
            label3.RightToLeft = RightToLeft.Yes;
            label3.Size = new Size(47, 20);
            label3.TabIndex = 14;
            label3.Text = "کد کاربر:";
            // 
            // btn_submit
            // 
            btn_submit.Location = new Point(195, 62);
            btn_submit.Name = "btn_submit";
            btn_submit.Size = new Size(98, 46);
            btn_submit.TabIndex = 16;
            btn_submit.Text = "ثبت تغییرات";
            btn_submit.UseVisualStyleBackColor = true;
            // 
            // UserName_txtbox
            // 
            UserName_txtbox.Location = new Point(12, 20);
            UserName_txtbox.Name = "UserName_txtbox";
            UserName_txtbox.Size = new Size(165, 28);
            UserName_txtbox.TabIndex = 17;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(183, 23);
            label1.Name = "label1";
            label1.RightToLeft = RightToLeft.Yes;
            label1.Size = new Size(88, 20);
            label1.TabIndex = 18;
            label1.Text = "نام نمایشی کاربر:";
            // 
            // FrmUsers
            // 
            AcceptButton = btn_submit;
            AutoScaleDimensions = new SizeF(7F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(477, 463);
            Controls.Add(label1);
            Controls.Add(UserName_txtbox);
            Controls.Add(btn_submit);
            Controls.Add(Userid_txtbox);
            Controls.Add(label3);
            Controls.Add(dataGridView1);
            Font = new Font("IRANSans", 9F);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FrmUsers";
            Text = "FrmUsers";
            ((ISupportInitialize)dataGridView1).EndInit();
            ((ISupportInitialize)userBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn userIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private BindingSource userBindingSource;
        private ComboBox Userid_txtbox;
        private Label label3;
        private Button btn_submit;
        private TextBox UserName_txtbox;
        private Label label1;
    }
}