namespace WindowsFormsApp1
{
    partial class AddVideoForm
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
            this.kryptonButton1 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.label1 = new System.Windows.Forms.Label();
            this.pathTextBox = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonButton2 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kryptonComboBox1 = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.diagtextbox = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonComboBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonButton1
            // 
            this.kryptonButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonButton1.Location = new System.Drawing.Point(283, 312);
            this.kryptonButton1.Name = "kryptonButton1";
            this.kryptonButton1.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.kryptonButton1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.kryptonButton1.Size = new System.Drawing.Size(125, 26);
            this.kryptonButton1.TabIndex = 24;
            this.kryptonButton1.Values.Text = "Отмена";
            this.kryptonButton1.Click += new System.EventHandler(this.kryptonButton1_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(203)))), ((int)(((byte)(239)))));
            this.panel1.Location = new System.Drawing.Point(0, 297);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(420, 3);
            this.panel1.TabIndex = 23;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(135, 312);
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
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 26;
            this.label1.Text = "Пациент";
            // 
            // pathTextBox
            // 
            this.pathTextBox.Enabled = false;
            this.pathTextBox.Location = new System.Drawing.Point(15, 74);
            this.pathTextBox.Name = "pathTextBox";
            this.pathTextBox.Size = new System.Drawing.Size(277, 23);
            this.pathTextBox.TabIndex = 28;
            // 
            // kryptonButton2
            // 
            this.kryptonButton2.Location = new System.Drawing.Point(298, 73);
            this.kryptonButton2.Name = "kryptonButton2";
            this.kryptonButton2.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.kryptonButton2.Size = new System.Drawing.Size(113, 22);
            this.kryptonButton2.TabIndex = 29;
            this.kryptonButton2.Values.Text = "Выбрать файл";
            this.kryptonButton2.Click += new System.EventHandler(this.kryptonButton2_Click);
            // 
            // kryptonComboBox1
            // 
            this.kryptonComboBox1.DropDownWidth = 183;
            this.kryptonComboBox1.IntegralHeight = false;
            this.kryptonComboBox1.Location = new System.Drawing.Point(15, 35);
            this.kryptonComboBox1.Name = "kryptonComboBox1";
            this.kryptonComboBox1.Size = new System.Drawing.Size(183, 21);
            this.kryptonComboBox1.StateCommon.ComboBox.Content.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.kryptonComboBox1.TabIndex = 30;
            this.kryptonComboBox1.Text = "kryptonComboBox1";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(15, 132);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(396, 23);
            this.progressBar1.TabIndex = 31;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 32;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 167);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 38;
            this.label4.Text = "Диагноз";
            // 
            // diagtextbox
            // 
            this.diagtextbox.Location = new System.Drawing.Point(15, 183);
            this.diagtextbox.Multiline = true;
            this.diagtextbox.Name = "diagtextbox";
            this.diagtextbox.Size = new System.Drawing.Size(396, 75);
            this.diagtextbox.TabIndex = 37;
            // 
            // AddVideoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(246)))), ((int)(((byte)(254)))));
            this.ClientSize = new System.Drawing.Size(420, 347);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.diagtextbox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.kryptonComboBox1);
            this.Controls.Add(this.kryptonButton2);
            this.Controls.Add(this.pathTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.kryptonButton1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.MaximumSize = new System.Drawing.Size(436, 386);
            this.MinimumSize = new System.Drawing.Size(436, 386);
            this.Name = "AddVideoForm";
            this.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.Text = "Загрузка видео";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonComboBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonButton kryptonButton1;
        private System.Windows.Forms.Panel panel1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton button1;
        private System.Windows.Forms.Label label1;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox pathTextBox;
        private ComponentFactory.Krypton.Toolkit.KryptonButton kryptonButton2;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox kryptonComboBox1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox diagtextbox;
    }
}