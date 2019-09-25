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
    public partial class AddPatForm : KryptonForm
    {
        bool formstatus = false;
        int patId;
        public AddPatForm()
        {
            InitializeComponent();
        }

        public AddPatForm(PatInfoTable pat)
        {
            InitializeComponent();
            changeFormStatus();
            String[] splitStr = pat.FIO.Trim().Split(' ');
            delButton.Visible = true;
            editButton.Visible = true;
            button1.Visible = false;
            nametextbox.Text = splitStr[1];
            surtextbox.Text = splitStr[0];
            otchtextbox.Text = splitStr[2];
            diagtextbox.Text = pat.Diag;
            bdatepicker.Value = pat.Bdate;
            pdatepicker.Value = pat.Pdate;
            patId = pat.Id;
        }

        void changeFormStatus()
        {
            nametextbox.Enabled = formstatus;
            surtextbox.Enabled = formstatus;
            otchtextbox.Enabled = formstatus;
            diagtextbox.Enabled = formstatus;
            bdatepicker.Enabled = formstatus;
            pdatepicker.Enabled = formstatus;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(nametextbox.Text) && !String.IsNullOrWhiteSpace(surtextbox.Text) && !String.IsNullOrWhiteSpace(otchtextbox.Text) && !String.IsNullOrWhiteSpace(diagtextbox.Text))
            {
                var result = DBOPS.AddNewPat(nametextbox.Text, surtextbox.Text, otchtextbox.Text, bdatepicker.Value, pdatepicker.Value, diagtextbox.Text);
                if (result)
                    this.Close();
            }
            else
                MessageBox.Show("Все поля должны быть заполнены!");
            
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            if (editButton.Text == "Изменить")
            {
                formstatus = !formstatus;
                editButton.Text = "Сохранить";
                
            }
            else if (formstatus)
            {
                if (!String.IsNullOrWhiteSpace(nametextbox.Text) && !String.IsNullOrWhiteSpace(surtextbox.Text) && !String.IsNullOrWhiteSpace(otchtextbox.Text) && !String.IsNullOrWhiteSpace(diagtextbox.Text))
                {
                    DBOPS.UpdPat(patId, nametextbox.Text, surtextbox.Text, otchtextbox.Text, bdatepicker.Value, pdatepicker.Value, diagtextbox.Text);
                    //var result = DBOPS.AddNewPat(nametextbox.Text, surtextbox.Text, otchtextbox.Text, bdatepicker.Value, pdatepicker.Value, diagtextbox.Text);
                    editButton.Text = "Изменить";
                    closeButton.Text = "Закрыть";
                    formstatus = !formstatus;
                }
                else
                    MessageBox.Show("Все поля должны быть заполнены!");
            }
            changeFormStatus();
        }

        private void delButton_Click(object sender, EventArgs e)
        {
            DBOPS.DeletePatCascade(patId);
            this.Close();
        }
    }
}
