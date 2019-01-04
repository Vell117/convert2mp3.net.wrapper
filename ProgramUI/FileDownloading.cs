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
    public partial class FileDownloading : Form
    {
        public WebClient client;
        public bool Completed = false;
        public string URL;
        public string FileName;
        public bool CloseForm = false;
        public string DefaultText;

        public FileDownloading(string url, string filename)
        {
            URL = url;
            FileName = new FileInfo(filename).FullName;
            DefaultText = "URL: " + url + Environment.NewLine + "File: " + FileName;

            InitializeComponent();

            label1.Text = DefaultText + Environment.NewLine + "Starting download...";

            client = new WebClient();
            client.DownloadFileCompleted += Client_DownloadFileCompleted;
            client.DownloadProgressChanged += Client_DownloadProgressChanged;

            client.DownloadFileAsync(new Uri(URL), FileName);
        }

        private void Client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            double bytesIn = double.Parse(e.BytesReceived.ToString());
            double totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
            double percentage = bytesIn / totalBytes * 100;
            progressBar.Invoke(new Action(()=>
            {
                Text = $"({new FileInfo(FileName).Name})" + " Downloaded " + e.BytesReceived + " of " + e.TotalBytesToReceive;
                label1.Text = DefaultText + Environment.NewLine + "Downloaded " + e.BytesReceived + " of " + e.TotalBytesToReceive;
                progressBar.Value = int.Parse(Math.Truncate(percentage).ToString());
            }));
            
        }

        private void Client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            Completed = true;
            Invoke(new Action(() =>
            {
                Text = $"({new FileInfo(FileName).Name})" + " Completed";

                if (e.Cancelled)
                {
                    label1.Text = DefaultText + Environment.NewLine + "Canceled.";
                }

                if (e.Error != null)
                {
                    label1.Text = DefaultText + Environment.NewLine + "ERROR: " + e.Error.Message;
                }

                if (cbFile.Checked)
                    Process.Start(FileName);

                if (cbFolder.Checked)
                    Process.Start("explorer", new FileInfo(FileName).Directory.FullName);

                if (cbCloseThen.Checked && e.Error == null)
                    this.Close();
            }
            ));
        }
           

        private void FileDownloading_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!Completed)
            {
                e.Cancel = true;
                CloseForm = true;
                btnCancel_Click(null, null);
            }
            else
                client.Dispose();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (!Completed)
            {
                if(MessageBox.Show("Cancel downloading?", "Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    client.CancelAsync();

                    if (CloseForm)
                        this.Close();
                }

                CloseForm = false;
            }
            else
                this.Close();
        }

        private void btnFolder_Click(object sender, EventArgs e)
        {
            Process.Start("explorer", new FileInfo(FileName).Directory.FullName);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process.Start(FileName);
        }
    }
}
