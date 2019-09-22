using ComponentFactory.Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.DataClasses;

namespace WindowsFormsApp1
{
    public partial class Top10Form : KryptonForm
    {
        List<SearchImageListTable> pics = new List<SearchImageListTable>();
        public Top10Form(List<SearchImageListTable> top10img)
        {
            InitializeComponent();
            pics = top10img;
            treeView1.Nodes.Clear();
            TreeNode parent = new TreeNode();
            parent.Text = "Топ 10 похожих";
            parent.Tag = -1;
            treeView1.Nodes.Add(parent);

            for (int i =0; i< top10img.Count; i++)
            {
                TreeNode child = new TreeNode();
                child.Text = top10img[i].Id_pat + " " + top10img[i].Id_vid + " (" + top10img[i].timestamp + ")";
                child.Tag = i;
                parent.Nodes.Add(child);
            }
            treeView1.ExpandAll();
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (Int32.Parse(e.Node.Tag.ToString()) != -1)
            {
                pictureBox1.Image = Image.FromFile(System.IO.Directory.GetCurrentDirectory() + pics[Int32.Parse(e.Node.Tag.ToString())].path);
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }
    }
}
