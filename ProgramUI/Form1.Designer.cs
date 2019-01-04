namespace ProgramUI
{
    partial class Form1
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
            this.btnConvert = new System.Windows.Forms.Button();
            this.cbFormat = new System.Windows.Forms.ComboBox();
            this.tbUrl = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gbProperties = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbAlbum = new System.Windows.Forms.TextBox();
            this.cbUseAlbumCover = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSaveNoTags = new System.Windows.Forms.Button();
            this.btnSaveTags = new System.Windows.Forms.Button();
            this.cbUseBrowser = new System.Windows.Forms.CheckBox();
            this.linkPlay = new System.Windows.Forms.LinkLabel();
            this.tbArtist = new System.Windows.Forms.ComboBox();
            this.tbName = new System.Windows.Forms.ComboBox();
            this.gbProperties.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnConvert
            // 
            this.btnConvert.Location = new System.Drawing.Point(466, 12);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(89, 23);
            this.btnConvert.TabIndex = 0;
            this.btnConvert.Text = "Convert";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // cbFormat
            // 
            this.cbFormat.FormattingEnabled = true;
            this.cbFormat.Items.AddRange(new object[] {
            "mp3",
            "todo",
            "todo",
            "todo"});
            this.cbFormat.Location = new System.Drawing.Point(389, 14);
            this.cbFormat.Name = "cbFormat";
            this.cbFormat.Size = new System.Drawing.Size(71, 21);
            this.cbFormat.TabIndex = 2;
            this.cbFormat.Text = "mp3";
            // 
            // tbUrl
            // 
            this.tbUrl.Location = new System.Drawing.Point(50, 14);
            this.tbUrl.Name = "tbUrl";
            this.tbUrl.Size = new System.Drawing.Size(333, 20);
            this.tbUrl.TabIndex = 3;
            this.tbUrl.Text = "https://www.youtube.com/watch?v=Vhh_GeBPOhs";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "URL:";
            // 
            // gbProperties
            // 
            this.gbProperties.Controls.Add(this.tbName);
            this.gbProperties.Controls.Add(this.tbArtist);
            this.gbProperties.Controls.Add(this.label5);
            this.gbProperties.Controls.Add(this.cbUseAlbumCover);
            this.gbProperties.Controls.Add(this.label4);
            this.gbProperties.Controls.Add(this.tbAlbum);
            this.gbProperties.Controls.Add(this.label3);
            this.gbProperties.Controls.Add(this.label2);
            this.gbProperties.Location = new System.Drawing.Point(15, 40);
            this.gbProperties.Name = "gbProperties";
            this.gbProperties.Size = new System.Drawing.Size(540, 122);
            this.gbProperties.TabIndex = 5;
            this.gbProperties.TabStop = false;
            this.gbProperties.Text = "File Properties";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Artist";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Album";
            // 
            // tbAlbum
            // 
            this.tbAlbum.Location = new System.Drawing.Point(65, 71);
            this.tbAlbum.Name = "tbAlbum";
            this.tbAlbum.Size = new System.Drawing.Size(469, 20);
            this.tbAlbum.TabIndex = 10;
            this.tbAlbum.Text = "Album";
            // 
            // cbUseAlbumCover
            // 
            this.cbUseAlbumCover.AutoSize = true;
            this.cbUseAlbumCover.Location = new System.Drawing.Point(65, 97);
            this.cbUseAlbumCover.Name = "cbUseAlbumCover";
            this.cbUseAlbumCover.Size = new System.Drawing.Size(186, 17);
            this.cbUseAlbumCover.TabIndex = 11;
            this.cbUseAlbumCover.Text = "set video thumbnail as MP3 cover";
            this.cbUseAlbumCover.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Cover";
            // 
            // btnSaveNoTags
            // 
            this.btnSaveNoTags.Location = new System.Drawing.Point(123, 198);
            this.btnSaveNoTags.Name = "btnSaveNoTags";
            this.btnSaveNoTags.Size = new System.Drawing.Size(110, 23);
            this.btnSaveNoTags.TabIndex = 13;
            this.btnSaveNoTags.Text = "Save (ignore tags)";
            this.btnSaveNoTags.UseVisualStyleBackColor = true;
            this.btnSaveNoTags.Visible = false;
            this.btnSaveNoTags.Click += new System.EventHandler(this.btnSaveNoTags_Click);
            // 
            // btnSaveTags
            // 
            this.btnSaveTags.Location = new System.Drawing.Point(480, 171);
            this.btnSaveTags.Name = "btnSaveTags";
            this.btnSaveTags.Size = new System.Drawing.Size(75, 23);
            this.btnSaveTags.TabIndex = 14;
            this.btnSaveTags.Text = "Save File";
            this.btnSaveTags.UseVisualStyleBackColor = true;
            this.btnSaveTags.Click += new System.EventHandler(this.btnSaveTags_Click);
            // 
            // cbUseBrowser
            // 
            this.cbUseBrowser.AutoSize = true;
            this.cbUseBrowser.Location = new System.Drawing.Point(355, 175);
            this.cbUseBrowser.Name = "cbUseBrowser";
            this.cbUseBrowser.Size = new System.Drawing.Size(119, 17);
            this.cbUseBrowser.TabIndex = 15;
            this.cbUseBrowser.Text = "Save using browser";
            this.cbUseBrowser.UseVisualStyleBackColor = true;
            // 
            // linkPlay
            // 
            this.linkPlay.AutoSize = true;
            this.linkPlay.Location = new System.Drawing.Point(12, 176);
            this.linkPlay.Name = "linkPlay";
            this.linkPlay.Size = new System.Drawing.Size(113, 13);
            this.linkPlay.TabIndex = 17;
            this.linkPlay.TabStop = true;
            this.linkPlay.Text = "Play (external browser)";
            this.linkPlay.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkPlay_LinkClicked);
            // 
            // tbArtist
            // 
            this.tbArtist.FormattingEnabled = true;
            this.tbArtist.Location = new System.Drawing.Point(65, 14);
            this.tbArtist.Name = "tbArtist";
            this.tbArtist.Size = new System.Drawing.Size(469, 21);
            this.tbArtist.TabIndex = 13;
            // 
            // tbName
            // 
            this.tbName.FormattingEnabled = true;
            this.tbName.Location = new System.Drawing.Point(65, 44);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(469, 21);
            this.tbName.TabIndex = 14;
            // 
            // Form1
            // 
            this.AcceptButton = this.btnConvert;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 206);
            this.Controls.Add(this.linkPlay);
            this.Controls.Add(this.cbUseBrowser);
            this.Controls.Add(this.gbProperties);
            this.Controls.Add(this.btnSaveTags);
            this.Controls.Add(this.btnSaveNoTags);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbUrl);
            this.Controls.Add(this.cbFormat);
            this.Controls.Add(this.btnConvert);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Convert2mp3";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.gbProperties.ResumeLayout(false);
            this.gbProperties.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.ComboBox cbFormat;
        private System.Windows.Forms.TextBox tbUrl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbProperties;
        private System.Windows.Forms.Button btnSaveTags;
        private System.Windows.Forms.Button btnSaveNoTags;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox cbUseAlbumCover;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbAlbum;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cbUseBrowser;
        private System.Windows.Forms.LinkLabel linkPlay;
        private System.Windows.Forms.ComboBox tbName;
        private System.Windows.Forms.ComboBox tbArtist;
    }
}

