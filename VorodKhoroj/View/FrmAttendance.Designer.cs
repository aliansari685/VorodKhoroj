namespace VorodKhoroj.View
{
    partial class FrmAttendance
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
            dataView_User = new DataGridView();
            ((ISupportInitialize)dataView_User).BeginInit();
            SuspendLayout();
            // 
            // dataView_User
            // 
            dataView_User.AllowUserToAddRows = false;
            dataView_User.AllowUserToDeleteRows = false;
            dataView_User.AllowUserToOrderColumns = true;
            dataView_User.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataView_User.Dock = DockStyle.Bottom;
            dataView_User.Location = new Point(0, 207);
            dataView_User.Name = "dataView_User";
            dataView_User.ReadOnly = true;
            dataView_User.Size = new Size(800, 243);
            dataView_User.TabIndex = 4;
            // 
            // FrmAttendance
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dataView_User);
            Name = "FrmAttendance";
            Text = "FrmAttendance";
            ((ISupportInitialize)dataView_User).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataView_User;
    }
}