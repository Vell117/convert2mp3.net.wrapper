using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace ProgramUI
{
    public partial class Form1 : Form
    {
        public convert2mp3.Converter c2mp3;
        public Form1()
        {
            InitializeComponent();
            SetSize(false);
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            if (c2mp3 != null)
                c2mp3.Dispose();

            try
            {
                c2mp3 = new convert2mp3.Converter(tbUrl.Text, cbFormat.Text);
                c2mp3.ConvertStart += C2mp3_ConvertStart;
                c2mp3.WhenConverted += C2mp3_WhenConverted;
                c2mp3.StartConverting();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                SetSize(false);
            }
        }

        private void C2mp3_ConvertStart()
        {
            SetSize(false);
            btnConvert.Enabled = false;
            btnConvert.Text = "Converting...";
        }

        private void C2mp3_WhenConverted(bool ok, string[] artist, string[] name, string album, bool cover, string playSrc)
        {
            btnConvert.Enabled = true;
            btnConvert.Text = "Convert";

            if (ok)
            {
                SetSize(true);

                tbArtist.Items.Clear();
                tbName.Items.Clear();

                foreach (var a in artist)
                    tbArtist.Items.Add(a);

                foreach (var n in name)
                    tbName.Items.Add(n);

                tbArtist.Text = artist[0];
                tbName.Text = name[0];
                tbAlbum.Text = album;
                cbUseAlbumCover.Checked = cover;

                if (playSrc == null)
                    linkPlay.Visible = false;
                else
                    linkPlay.Visible = true;

                linkPlay.Tag = playSrc;
            }
            else
            {
                SetSize(false);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        public void SetSize(bool extended)
        {
            if (!extended)
            {
                gbProperties.Enabled = false;
                gbProperties.Visible = false;
                Size = new Size(569, 70);
            }
            else
            {
                gbProperties.Enabled = true;
                gbProperties.Visible = true;
                Size = new Size(569, 231);
            }
        }

        private void DoSaveFile(string url, string filename)
        {
            if (cbUseBrowser.Checked)
            {
                Process.Start(url);
            }
            else
            {
                string ext = new FileInfo(filename).Extension;
                SaveFileDialog save = new SaveFileDialog();
                save.InitialDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
                save.FileName = filename;
                save.Filter = $"{ext} files (*{ext})|*{ext}|All Files (*.*)|*.*";
                if(save.ShowDialog() == DialogResult.OK)
                {
                    new FileDownloading(url, save.FileName).Show();
                }
            }
        }

        private void btnSaveNoTags_Click(object sender, EventArgs e)
        {
            try
            {
                var url = c2mp3.Finalize();
                DoSaveFile(url.Link, url.FileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void linkPlay_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(linkPlay.Tag.ToString());
        }

        private void btnSaveTags_Click(object sender, EventArgs e)
        { 
            try
            {
                var url = c2mp3.Finalize(tbArtist.Text, tbName.Text, tbAlbum.Text, cbUseAlbumCover.Checked);
                DoSaveFile(url.Link, url.FileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
