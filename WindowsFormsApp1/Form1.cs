using ComponentFactory.Krypton.Toolkit;
using FFMpegCore;
using FFMpegCore.FFMPEG;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.DataClasses;

namespace WindowsFormsApp1
{
    public partial class Form1 : KryptonForm
    {
        string inputFile, vidDiag;
        TimeSpan globalTimeSpan = new TimeSpan(0, 0, 0, 0);
        List<PatsTable> pats = new List<PatsTable>();
        List<VidTable> vids = new List<VidTable>();
        List<ImageListTable> pics = new List<ImageListTable>();
        int min, sec, count, maxframe, step, patId, vidId, imgnum;
        VideoInfo video;

        private Thread workerThread = null;

        public Form1()
        {
            InitializeComponent();
            patTreeRefresh();
            this.updateStatusDelegate = new UpdateStatusDelegate(this.UpdateStatus);
            kryptonButton1.Enabled = false;
        }

        private void patTreeRefresh()
        {
            pats = DBOPS.GetPatsList();
            treeView1.Nodes.Clear();
            TreeNode parent = new TreeNode();
            parent.Text = "Пациенты";
            parent.Tag = -1;
            treeView1.Nodes.Add(parent);

            foreach (var a in pats)
            {
                TreeNode child = new TreeNode();
                child.Text = a.FIO;
                child.Tag = a.Id;
                parent.Nodes.Add(child);
            }
            treeView1.ExpandAll();
        }

        private void vidTreeRefresh(int id_pat, string fio)
        {
            vids = DBOPS.GetVidsList(id_pat);
            treeView2.Nodes.Clear();
            TreeNode parent = new TreeNode();
            parent.Text = fio;
            parent.Tag = -1;
            treeView2.Nodes.Add(parent);

            foreach (var a in vids)
            {
                TreeNode child = new TreeNode();
                child.Text = a.Name;
                child.Tag = a.Id;
                parent.Nodes.Add(child);
            }
            treeView2.ExpandAll();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DBOPS.CreatVideoTable();
            DBOPS.CreatePictureTable();
        }

        private void добавитьПациентаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var myForm = new AddPatForm();
            myForm.FormClosed += new FormClosedEventHandler(myForm_FormClosed);
            myForm.Show();
        }

        private void загрузитьВидеоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var myForm = new AddVideoForm();
            myForm.FormClosed += new FormClosedEventHandler(myForm_FormClosed);
            myForm.Show();
        }

        private void myForm_FormClosed(object sender, EventArgs e)
        {
            KryptonForm forrm = sender as KryptonForm;
            if (forrm.Name == "AddPatForm")
                patTreeRefresh();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (Int32.Parse(e.Node.Tag.ToString()) != -1)
            {
                vidTreeRefresh(Int32.Parse(e.Node.Tag.ToString()), e.Node.Text);
                var pat = DBOPS.GetPat(Int32.Parse(e.Node.Tag.ToString()));
                patId = Int32.Parse(e.Node.Tag.ToString());
                label3.Text = pat.FIO;
                label2.Text = pat.Bdate.ToString("dd/MM/yyyy");
                label5.Text = pat.Pdate.ToString("dd/MM/yyyy");
                textBox1.Text = pat.Diag;
                kryptonButton1.Enabled = false;
                pictureBox1.Image = null;
                panel4.Enabled = false;
                imgnum = 0;
            }
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            TimeSpan duration = globalTimeSpan;
            string outstr = video.Directory + "\\" + video.Name + " - " + duration.ToString(@"hh\_mm\_ss") + ".jpg";
            label16.Text = duration.ToString(@"hh\:mm\:ss");
            FileInfo output = new FileInfo(outstr);
            Bitmap img = new FFMpeg().Snapshot(
                    video,
                    output,
                    new Size(video.Width, video.Height),
                    duration
                );
            pictureBox1.Image = img;
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void bButton_Click(object sender, EventArgs e)
        {
            if (imgnum > 0)
            {
                imgnum--;
                pictureBox1.Image = Image.FromFile(System.IO.Directory.GetCurrentDirectory() + pics[imgnum].path);
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                nButton.Enabled = true;
                label15.Text = "Текущий снимок:";
                label16.Text = (imgnum + 1) + " из " + pics.Count + " (" + pics[imgnum].timestamp + ")";
            }
            else
                bButton.Enabled = false;
        }

        private void treeView2_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (Int32.Parse(e.Node.Tag.ToString()) != -1)
            {

                //vidTreeRefresh(Int32.Parse(e.Node.Tag.ToString()), e.Node.Text);
                var vid = DBOPS.GetVid(Int32.Parse(e.Node.Tag.ToString()));
                pics = DBOPS.GetImagesList(Int32.Parse(e.Node.Tag.ToString()));
                pics = pics.OrderBy(i => i.Id).ToList();
                vidDiag = vid.Diag;
                vidId = Int32.Parse(e.Node.Tag.ToString());
                inputFile = System.IO.Directory.GetCurrentDirectory() + vid.path;
                var ffProbe = new NReco.VideoInfo.FFProbe();
                var videoInfo = ffProbe.GetMediaInfo(inputFile);
                video = new VideoInfo(inputFile);
                count = 0;

                string output1 = videoInfo.Duration.ToString();
                //label3.Text = pat.FIO;
                //label2.Text = pat.Bdate.ToString("dd/MM/yyyy");
                //label5.Text = pat.Pdate.ToString("dd/MM/yyyy");
                label10.Text = output1;
                kryptonButton1.Enabled = true;
                panel4.Enabled = true;

                bool splitted = DBOPS.ExistPicturesCheck(vidId);
                if (splitted)
                {
                    nButton.Visible = true;
                    bButton.Visible = true;
                    pictureBox1.Image = Image.FromFile(System.IO.Directory.GetCurrentDirectory() + pics[imgnum].path);
                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                    label15.Text = "Текущий снимок:";
                    label16.Text = (imgnum + 1) + " из " + pics.Count + " (" + pics[imgnum].timestamp + ")";
                }
                else
                {
                    nButton.Visible = false;
                    bButton.Visible = false;
                    TimeSpan duration = new TimeSpan(0, 0, 0, 0);
                    string outstr = video.Directory + "\\" + video.Name + " - " + duration.ToString(@"hh\_mm\_ss") + ".jpg";
                    label15.Text = "Текущая отметка:";
                    label16.Text = duration.ToString(@"hh\:mm\:ss");
                    FileInfo output = new FileInfo(outstr);
                    Bitmap img = new FFMpeg().Snapshot(
                            video,
                            output,
                            new Size(video.Width, video.Height),
                            duration
                        );
                    pictureBox1.Image = img;
                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
        }

        private void nButton_Click(object sender, EventArgs e)
        {
            if (imgnum < (pics.Count - 1))
            {
                imgnum++;
                pictureBox1.Image = Image.FromFile(System.IO.Directory.GetCurrentDirectory() + pics[imgnum].path);
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                bButton.Enabled = true;
                label15.Text = "Текущий снимок:";
                label16.Text = (imgnum + 1) + " из " + pics.Count + " (" + pics[imgnum].timestamp + ")";
            }
            else
                nButton.Enabled = false;
        }

        private void treeView2_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (Int32.Parse(e.Node.Tag.ToString()) != -1)
            {

                //vidTreeRefresh(Int32.Parse(e.Node.Tag.ToString()), e.Node.Text);
                var vid = DBOPS.GetVid(Int32.Parse(e.Node.Tag.ToString()));
                pics = DBOPS.GetImagesList(Int32.Parse(e.Node.Tag.ToString()));
                pics = pics.OrderBy(i => i.Id).ToList();
                vidDiag = vid.Diag;
                vidId = Int32.Parse(e.Node.Tag.ToString());
                inputFile = System.IO.Directory.GetCurrentDirectory() + vid.path;
                var ffProbe = new NReco.VideoInfo.FFProbe();
                var videoInfo = ffProbe.GetMediaInfo(inputFile);
                video = new VideoInfo(inputFile);
                count = 0;

                string output1 = videoInfo.Duration.ToString();
                //label3.Text = pat.FIO;
                //label2.Text = pat.Bdate.ToString("dd/MM/yyyy");
                //label5.Text = pat.Pdate.ToString("dd/MM/yyyy");
                label10.Text = output1;
                kryptonButton1.Enabled = true;
                panel4.Enabled = true;

                bool splitted = DBOPS.ExistPicturesCheck(vidId);
                if (splitted)
                {
                    nButton.Visible = true;
                    bButton.Visible = true;
                    pictureBox1.Image = Image.FromFile(System.IO.Directory.GetCurrentDirectory() + pics[imgnum].path);
                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                    label15.Text = "Текущий снимок:";
                    label16.Text = (imgnum + 1) + " из " + pics.Count + " (" + pics[imgnum].timestamp + ")";
                }
                else
                {
                    nButton.Visible = false;
                    bButton.Visible = false;
                    TimeSpan duration = new TimeSpan(0, 0, 0, 0);
                    string outstr = video.Directory + "\\" + video.Name + " - " + duration.ToString(@"hh\_mm\_ss") + ".jpg";
                    label15.Text = "Текущая отметка:";
                    label16.Text = duration.ToString(@"hh\:mm\:ss");
                    FileInfo output = new FileInfo(outstr);
                    Bitmap img = new FFMpeg().Snapshot(
                            video,
                            output,
                            new Size(video.Width, video.Height),
                            duration
                        );
                    pictureBox1.Image = img;
                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
        }


        private void BatchCalc()
        {
            for (int i = 0; i <= min; i++)
            {
                int rsec = 60;
                if (i == min)
                    rsec = sec;
                for (int j = 0; j < rsec; j=j)
                {
                    TimeSpan duration = new TimeSpan(0, 0, i, j);
                    string outstr = video.Directory + "\\" + video.Name + " - " + duration.ToString(@"hh\_mm\_ss") + ".jpg";
                    FileInfo output = new FileInfo(outstr);

                    new FFMpeg().Snapshot(
                            video,
                            output,
                            new Size(video.Width, video.Height),
                            duration, true
                        );
                    Invoke(updateStatusDelegate);
                    j = j + step;
                }
            }
            MessageBox.Show("Разбивка завершена.");
        }
        private void BatchCalc2()
        {
            int a = 0;
            for (int i = 0; i <= min; i++)
            {
                int rsec = 60;
                if (i == min)
                    rsec = sec;
                for (int j = 0; j < rsec; j = j)
                {
                    TimeSpan duration = new TimeSpan(0, 0, i, j);
                    string outstr = video.Directory + "\\" + video.Name + "_images\\" + video.Name + "-" + duration.ToString(@"hh\_mm\_ss") + ".jpg";
                    FileInfo output = new FileInfo(outstr);
                    String s = String.Format("-i {0} -ss {1} -vframes 1 {2}", inputFile, duration.ToString(@"hh\:mm\:ss"), outstr);
                    
                    Process process = new Process();
                    process.StartInfo.FileName = "ffmpeg.exe";
                    process.StartInfo.Arguments = s;
                    process.EnableRaisingEvents = true;
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.CreateNoWindow = true;
                    //process.StartInfo.RedirectStandardOutput = false;
                    process.Start(); // запуск процесса
                    //process.WaitForExit();
                    System.Threading.Thread.Sleep(350);
                    Invoke(updateStatusDelegate);
                    j = j + step;
                    a++;
                    DBOPS.AddNewPicture(vidId, patId, DateTime.Now, vidDiag, "\\" + patId+ "\\" + video.Name + "_images\\" + video.Name + "-" + duration.ToString(@"hh\_mm\_ss") + ".jpg", duration.ToString(@"hh\:mm\:ss"));
                    if (a>0 && a % 7 == 0)
                    {
                        System.Threading.Thread.Sleep(4700);
                    }
                }
            }
            MessageBox.Show("Разбивка завершена.");
        }

        private delegate void UpdateStatusDelegate();
        private UpdateStatusDelegate updateStatusDelegate = null;
        private void UpdateStatus()
        {
            progressBar1.PerformStep();
            count++;
            label13.Text = count + "\\" + maxframe;
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            pictureBox1.Image.Dispose();
            step = (int)numericUpDown1.Value;
            var ffProbe = new NReco.VideoInfo.FFProbe();
            var videoInfo = ffProbe.GetMediaInfo(inputFile);
            var video = VideoInfo.FromPath(inputFile);
            if (Directory.Exists(video.Directory + "\\" + video.Name + "_images"))
            {
                System.GC.Collect();
                System.GC.WaitForPendingFinalizers();
                System.IO.Directory.Delete(video.Directory + "\\" + video.Name + "_images", true);
            }
            DBOPS.DeletePictures(vidId);
            System.IO.Directory.CreateDirectory(video.Directory + "\\" + video.Name + "_images");

            min = videoInfo.Duration.Minutes;
            sec = videoInfo.Duration.Seconds;
            maxframe = (min * 60 + sec)/step;
            progressBar1.Maximum = maxframe;
            progressBar1.Value = 0;
            progressBar1.Step = 1;
            kryptonButton1.Enabled = false;
            nButton.Visible = true;
            bButton.Visible = true;
            this.workerThread = new Thread(new ThreadStart(this.BatchCalc2));
            this.workerThread.Start();

        }



    }
}
