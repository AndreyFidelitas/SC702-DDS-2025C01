namespace InventZetaGas
{
    partial class RecuperacionContraseña
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RecuperacionContraseña));
            pictureBox1 = new PictureBox();
            panel2 = new Panel();
            panel1 = new Panel();
            pictureBox2 = new PictureBox();
            btnRecuperar = new Button();
            label1 = new Label();
            txtCedula = new TextBox();
            linkLabel1 = new LinkLabel();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(72, 73);
            pictureBox1.Margin = new Padding(4, 3, 4, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(221, 319);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(1, 38, 90);
            panel2.Controls.Add(panel1);
            panel2.Controls.Add(pictureBox1);
            panel2.Location = new Point(-26, 0);
            panel2.Margin = new Padding(4, 3, 4, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(344, 451);
            panel2.TabIndex = 3;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(1, 38, 90);
            panel1.Controls.Add(pictureBox2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(344, 451);
            panel1.TabIndex = 4;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(72, 51);
            pictureBox2.Margin = new Padding(4, 3, 4, 3);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(221, 220);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 0;
            pictureBox2.TabStop = false;
            // 
            // btnRecuperar
            // 
            btnRecuperar.BackColor = Color.FromArgb(1, 38, 90);
            btnRecuperar.ForeColor = SystemColors.ButtonHighlight;
            btnRecuperar.ImageAlign = ContentAlignment.MiddleLeft;
            btnRecuperar.Location = new Point(546, 133);
            btnRecuperar.Name = "btnRecuperar";
            btnRecuperar.Size = new Size(202, 47);
            btnRecuperar.TabIndex = 11;
            btnRecuperar.Text = "Recuperar Contraseña";
            btnRecuperar.UseVisualStyleBackColor = false;
            btnRecuperar.Click += btnRecuperar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 10F);
            label1.Location = new Point(359, 73);
            label1.Name = "label1";
            label1.Size = new Size(52, 17);
            label1.TabIndex = 10;
            label1.Text = "Cédula";
            // 
            // txtCedula
            // 
            txtCedula.Font = new Font("Microsoft Sans Serif", 9.75F);
            txtCedula.Location = new Point(384, 93);
            txtCedula.Name = "txtCedula";
            txtCedula.Size = new Size(364, 22);
            txtCedula.TabIndex = 8;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Font = new Font("Microsoft Sans Serif", 10F);
            linkLabel1.LinkColor = SystemColors.ControlText;
            linkLabel1.Location = new Point(647, 185);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(101, 17);
            linkLabel1.TabIndex = 13;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Menu Principal";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ButtonHighlight;
            label2.Location = new Point(447, 9);
            label2.Name = "label2";
            label2.Size = new Size(229, 25);
            label2.TabIndex = 14;
            label2.Text = "Recuperar Contraseña";
            // 
            // RecuperacionContraseña
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(783, 341);
            Controls.Add(label2);
            Controls.Add(linkLabel1);
            Controls.Add(btnRecuperar);
            Controls.Add(label1);
            Controls.Add(txtCedula);
            Controls.Add(panel2);
            FormBorderStyle = FormBorderStyle.None;
            Name = "RecuperacionContraseña";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "RecuperacionContraseña";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Panel panel2;
        private Panel panel1;
        private PictureBox pictureBox2;
        private Button btnRecuperar;
        private Label label1;
        private TextBox txtCedula;
        private LinkLabel linkLabel1;
        private Label label2;
    }
}