namespace WindowsFormsApp1
{
    partial class AddPatForm
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
            this.closeButton = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.label1 = new System.Windows.Forms.Label();
            this.nametextbox = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.surtextbox = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.otchtextbox = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.bdatepicker = new System.Windows.Forms.DateTimePicker();
            this.pdatepicker = new System.Windows.Forms.DateTimePicker();
            this.diagtextbox = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.delButton = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.editButton = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.SuspendLayout();
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.Location = new System.Drawing.Point(286, 296);
            this.closeButton.Name = "closeButton";
            this.closeButton.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.closeButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.closeButton.Size = new System.Drawing.Size(125, 26);
            this.closeButton.TabIndex = 24;
            this.closeButton.Values.Text = "Отмена";
            this.closeButton.Click += new System.EventHandler(this.kryptonButton1_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(203)))), ((int)(((byte)(239)))));
            this.panel1.Location = new System.Drawing.Point(0, 281);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(423, 3);
            this.panel1.TabIndex = 23;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(147, 296);
            this.button1.Name = "button1";
            this.button1.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.button1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button1.Size = new System.Drawing.Size(125, 26);
            this.button1.TabIndex = 22;
            this.button1.Values.Text = "Добавить";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 26;
            this.label1.Text = "Имя";
            // 
            // nametextbox
            // 
            this.nametextbox.Location = new System.Drawing.Point(15, 25);
            this.nametextbox.Name = "nametextbox";
            this.nametextbox.Size = new System.Drawing.Size(188, 23);
            this.nametextbox.TabIndex = 25;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "Фамилия";
            // 
            // surtextbox
            // 
            this.surtextbox.Location = new System.Drawing.Point(15, 78);
            this.surtextbox.Name = "surtextbox";
            this.surtextbox.Size = new System.Drawing.Size(188, 23);
            this.surtextbox.TabIndex = 27;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 30;
            this.label3.Text = "Отчество";
            // 
            // otchtextbox
            // 
            this.otchtextbox.Location = new System.Drawing.Point(15, 131);
            this.otchtextbox.Name = "otchtextbox";
            this.otchtextbox.Size = new System.Drawing.Size(188, 23);
            this.otchtextbox.TabIndex = 29;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 172);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 36;
            this.label4.Text = "Диагноз";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(220, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 13);
            this.label5.TabIndex = 34;
            this.label5.Text = "Дата поступления";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(220, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 13);
            this.label6.TabIndex = 32;
            this.label6.Text = "Дата рождения";
            // 
            // bdatepicker
            // 
            this.bdatepicker.Location = new System.Drawing.Point(223, 26);
            this.bdatepicker.Name = "bdatepicker";
            this.bdatepicker.Size = new System.Drawing.Size(188, 20);
            this.bdatepicker.TabIndex = 37;
            // 
            // pdatepicker
            // 
            this.pdatepicker.Location = new System.Drawing.Point(223, 78);
            this.pdatepicker.Name = "pdatepicker";
            this.pdatepicker.Size = new System.Drawing.Size(188, 20);
            this.pdatepicker.TabIndex = 38;
            // 
            // diagtextbox
            // 
            this.diagtextbox.Location = new System.Drawing.Point(12, 188);
            this.diagtextbox.Multiline = true;
            this.diagtextbox.Name = "diagtextbox";
            this.diagtextbox.Size = new System.Drawing.Size(399, 75);
            this.diagtextbox.TabIndex = 35;
            // 
            // delButton
            // 
            this.delButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.delButton.Location = new System.Drawing.Point(7, 296);
            this.delButton.Name = "delButton";
            this.delButton.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.delButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.delButton.Size = new System.Drawing.Size(125, 26);
            this.delButton.TabIndex = 39;
            this.delButton.Values.Text = "Удалить";
            this.delButton.Visible = false;
            this.delButton.Click += new System.EventHandler(this.delButton_Click);
            // 
            // editButton
            // 
            this.editButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.editButton.Location = new System.Drawing.Point(147, 296);
            this.editButton.Name = "editButton";
            this.editButton.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.editButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.editButton.Size = new System.Drawing.Size(125, 26);
            this.editButton.TabIndex = 40;
            this.editButton.Values.Text = "Изменить";
            this.editButton.Visible = false;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // AddPatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(246)))), ((int)(((byte)(254)))));
            this.ClientSize = new System.Drawing.Size(423, 331);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.delButton);
            this.Controls.Add(this.pdatepicker);
            this.Controls.Add(this.bdatepicker);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.diagtextbox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.otchtextbox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.surtextbox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nametextbox);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(439, 370);
            this.MinimumSize = new System.Drawing.Size(439, 370);
            this.Name = "AddPatForm";
            this.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.Text = "Добавление пациента";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonButton closeButton;
        private System.Windows.Forms.Panel panel1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton button1;
        private System.Windows.Forms.Label label1;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox nametextbox;
        private System.Windows.Forms.Label label2;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox surtextbox;
        private System.Windows.Forms.Label label3;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox otchtextbox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker bdatepicker;
        private System.Windows.Forms.DateTimePicker pdatepicker;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox diagtextbox;
        private ComponentFactory.Krypton.Toolkit.KryptonButton delButton;
        private ComponentFactory.Krypton.Toolkit.KryptonButton editButton;
    }
}