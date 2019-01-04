namespace ProgramUI
{
    partial class FileDownloading
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbFile = new System.Windows.Forms.CheckBox();
            this.cbFolder = new System.Windows.Forms.CheckBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.cbCloseThen = new System.Windows.Forms.CheckBox();
            this.btnFolder = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(491, 126);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // cbFile
            // 
            this.cbFile.AutoSize = true;
            this.cbFile.Location = new System.Drawing.Point(12, 107);
            this.cbFile.Name = "cbFile";
            this.cbFile.Size = new System.Drawing.Size(71, 17);
            this.cbFile.TabIndex = 2;
            this.cbFile.Text = "Open File";
            this.cbFile.UseVisualStyleBackColor = true;
            // 
            // cbFolder
            // 
            this.cbFolder.AutoSize = true;
            this.cbFolder.Location = new System.Drawing.Point(12, 130);
            this.cbFolder.Name = "cbFolder";
            this.cbFolder.Size = new System.Drawing.Size(84, 17);
            this.cbFolder.TabIndex = 3;
            this.cbFolder.Text = "Open Folder";
            this.cbFolder.UseVisualStyleBackColor = true;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 69);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(554, 18);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 4;
            // 
            // cbCloseThen
            // 
            this.cbCloseThen.AutoSize = true;
            this.cbCloseThen.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbCloseThen.Checked = true;
            this.cbCloseThen.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbCloseThen.Location = new System.Drawing.Point(456, 103);
            this.cbCloseThen.Name = "cbCloseThen";
            this.cbCloseThen.Size = new System.Drawing.Size(110, 17);
            this.cbCloseThen.TabIndex = 5;
            this.cbCloseThen.Text = "Close this window";
            this.cbCloseThen.UseVisualStyleBackColor = true;
            // 
            // btnFolder
            // 
            this.btnFolder.Location = new System.Drawing.Point(406, 126);
            this.btnFolder.Name = "btnFolder";
            this.btnFolder.Size = new System.Drawing.Size(79, 23);
            this.btnFolder.TabIndex = 6;
            this.btnFolder.Text = "Open Folder";
            this.btnFolder.UseVisualStyleBackColor = true;
            this.btnFolder.Click += new System.EventHandler(this.btnFolder_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(321, 126);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(79, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Open";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FileDownloading
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(581, 159);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnFolder);
            this.Controls.Add(this.cbCloseThen);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.cbFolder);
            this.Controls.Add(this.cbFile);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FileDownloading";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FileDownloading";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FileDownloading_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cbFile;
        private System.Windows.Forms.CheckBox cbFolder;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.CheckBox cbCloseThen;
        private System.Windows.Forms.Button btnFolder;
        private System.Windows.Forms.Button button1;
    }
}