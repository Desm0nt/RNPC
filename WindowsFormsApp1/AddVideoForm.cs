using ComponentFactory.Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.DataClasses;

namespace WindowsFormsApp1
{
    
    public partial class AddVideoForm : KryptonForm
    {
        List<PatsTable> pats = new List<PatsTable>();
        string target_path, filename, subPath;
        BackgroundWorker worker = new BackgroundWorker();
        public AddVideoForm()
        {
            InitializeComponent();
            pats = DBOPS.GetPatsList();
            var items = new[] { new { Text = "Топливо", Value = "1" }, new { Text = "Тепловые ресурсы", Value = "2" }, new { Text = "Электрические ресурсы", Value = "3" } };
            var it2 = items.ToList();
            it2.Clear();
            foreach (var a in pats)
                it2.Add(new { Text = a.FIO, Value = a.Id.ToString() });
            kryptonComboBox1.DisplayMember = "Text";
            kryptonComboBox1.ValueMember = "Value";
            kryptonComboBox1.DataSource = it2;
            kryptonComboBox1.SelectedIndex = 0;
            worker.WorkerSupportsCancellation = true;
            worker.WorkerReportsProgress = true;

            worker.ProgressChanged += Worker_ProgressChanged;
            worker.DoWork += Worker_DoWork;
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            CopyFile(pathTextBox.Text, target_path + subPath + "//" + filename);           
        }

        private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            label2.Text = "загружено " + progressBar1.Value.ToString() + "%";
            if (progressBar1.Value == 100)
            {
                DBOPS.AddNewVideo(Int32.Parse(kryptonComboBox1.SelectedValue.ToString()), DateTime.Now, diagtextbox.Text, subPath + "\\" + filename);
                MessageBox.Show("Загрузка завершена!");
                this.Close();
            }
        }

        void CopyFile(string source, string des)
        {
            FileStream fsOut = new FileStream(des, FileMode.Create);
            FileStream fsIn = new FileStream(source, FileMode.Open);
            byte[] bt = new byte[1048756];
            int readByte;
            while ((readByte = fsIn.Read(bt, 0, bt.Length)) > 0)
            {
                fsOut.Write(bt, 0, readByte);
                worker.ReportProgress((int)(fsIn.Position * 100 / fsIn.Length)); 
            }
            fsIn.Close();
            fsOut.Close();         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            target_path = System.IO.Directory.GetCurrentDirectory();
            button1.Enabled = false;
            kryptonButton1.Enabled = false;
            subPath = "\\" + kryptonComboBox1.SelectedValue; // your code goes here
            System.IO.Directory.CreateDirectory(target_path + subPath);
            worker.RunWorkerAsync();

        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                CheckFileExists = true,
                Filter = "Video Files (*.wmv;*.dvr-ms;*.mpeg;*.mpg;*.avi;*.mkv;*.mp4)|*.wmv;*.dvr-ms;*.mpeg;*.mpg;*.avi;*.mkv;*.mp4|All Files (*)|*"
            };
            if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                pathTextBox.Text = openFileDialog1.InitialDirectory + openFileDialog1.FileName;
                filename = Path.GetFileName(openFileDialog1.FileName);
            }
        }
    }
}
