namespace VorodKhoroj.View
{
    partial class FrmProgressDialog
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
            lbl_percent = new Label();
            progressBar1 = new ProgressBar();
            SuspendLayout();
            // 
            // lbl_percent
            // 
            lbl_percent.AutoSize = true;
            lbl_percent.Location = new Point(141, 54);
            lbl_percent.Name = "lbl_percent";
            lbl_percent.Size = new Size(13, 15);
            lbl_percent.TabIndex = 0;
            lbl_percent.Text = "0";
            lbl_percent.UseWaitCursor = true;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(16, 14);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(263, 28);
            progressBar1.TabIndex = 1;
            progressBar1.UseWaitCursor = true;
            // 
            // FrmProgressDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(300, 74);
            Controls.Add(progressBar1);
            Controls.Add(lbl_percent);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmProgressDialog";
            StartPosition = FormStartPosition.CenterParent;
            Text = "FrmProgressDialog";
            TopMost = true;
            UseWaitCursor = true;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_percent;
        private ProgressBar progressBar1;
    }
}