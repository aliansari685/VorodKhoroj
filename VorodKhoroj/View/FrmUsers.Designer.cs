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
            dataView_User = new DataGridView();
            userIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            userBindingSource = new BindingSource(components);
            Userid_txtbox = new ComboBox();
            label3 = new Label();
            btn_submit = new Button();
            UserName_txtbox = new TextBox();
            label1 = new Label();
            ((ISupportInitialize)dataView_User).BeginInit();
            ((ISupportInitialize)userBindingSource).BeginInit();
            SuspendLayout();
            // 
            // dataView_User
            // 
            dataView_User.AllowUserToAddRows = false;
            dataView_User.AllowUserToDeleteRows = false;
            dataView_User.AllowUserToOrderColumns = true;
            dataView_User.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataView_User.AutoGenerateColumns = false;
            dataView_User.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataView_User.Columns.AddRange(new DataGridViewColumn[] { userIdDataGridViewTextBoxColumn, nameDataGridViewTextBoxColumn });
            dataView_User.DataSource = userBindingSource;
            dataView_User.Location = new Point(-2, 178);
            dataView_User.Name = "dataView_User";
            dataView_User.ReadOnly = true;
            dataView_User.Size = new Size(334, 251);
            dataView_User.TabIndex = 3;
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
            // userBindingSource
            // 
            userBindingSource.DataSource = typeof(User);
            // 
            // Userid_txtbox
            // 
            Userid_txtbox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            Userid_txtbox.AutoCompleteSource = AutoCompleteSource.ListItems;
            Userid_txtbox.DisplayMember = "userid";
            Userid_txtbox.FormattingEnabled = true;
            Userid_txtbox.Location = new Point(108, 26);
            Userid_txtbox.Name = "Userid_txtbox";
            Userid_txtbox.Size = new Size(109, 28);
            Userid_txtbox.TabIndex = 0;
            Userid_txtbox.SelectedValueChanged += Userid_txtbox_SelectedValueChanged;
            Userid_txtbox.Leave += Userid_txtbox_SelectedValueChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(224, 30);
            label3.Name = "label3";
            label3.RightToLeft = RightToLeft.Yes;
            label3.Size = new Size(47, 20);
            label3.TabIndex = 14;
            label3.Text = "کد کاربر:";
            // 
            // btn_submit
            // 
            btn_submit.Location = new Point(101, 117);
            btn_submit.Name = "btn_submit";
            btn_submit.Size = new Size(111, 46);
            btn_submit.TabIndex = 2;
            btn_submit.Text = "ثبت تغییرات";
            btn_submit.UseVisualStyleBackColor = true;
            btn_submit.Click += btn_submit_Click;
            // 
            // UserName_txtbox
            // 
            UserName_txtbox.Location = new Point(52, 73);
            UserName_txtbox.Name = "UserName_txtbox";
            UserName_txtbox.Size = new Size(165, 28);
            UserName_txtbox.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(223, 77);
            label1.Name = "label1";
            label1.RightToLeft = RightToLeft.Yes;
            label1.Size = new Size(88, 20);
            label1.TabIndex = 18;
            label1.Text = "نام نمایشی کاربر:";
            // 
            // FrmUsers
            // 
            AutoScaleDimensions = new SizeF(7F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(334, 429);
            Controls.Add(label1);
            Controls.Add(UserName_txtbox);
            Controls.Add(btn_submit);
            Controls.Add(Userid_txtbox);
            Controls.Add(label3);
            Controls.Add(dataView_User);
            Font = new Font("IRANSans", 9F);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Margin = new Padding(3, 4, 3, 4);
            Name = "FrmUsers";
            Text = "FrmUsers";
            Load += FrmUsers_Load;
            ((ISupportInitialize)dataView_User).EndInit();
            ((ISupportInitialize)userBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataView_User;
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