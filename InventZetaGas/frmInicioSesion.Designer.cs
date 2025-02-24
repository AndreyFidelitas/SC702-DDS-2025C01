
using System.Diagnostics;

namespace InventZetaGas
{
    partial class frmInicioSesion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInicioSesion));
            panel1 = new Panel();
            panel2 = new Panel();
            pictureBox1 = new PictureBox();
            pictureBox3 = new PictureBox();
            txtUser = new TextBox();
            txtPaswword = new TextBox();
            lblCode = new Label();
            label1 = new Label();
            btnNew = new Button();
            label2 = new Label();
            linkLabel1 = new LinkLabel();
            label3 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(0, 100, 182);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(pictureBox3);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(292, 379);
            panel1.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(1, 38, 90);
            panel2.Controls.Add(pictureBox1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 0);
            panel2.Margin = new Padding(4, 3, 4, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(292, 379);
            panel2.TabIndex = 2;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(34, 31);
            pictureBox1.Margin = new Padding(4, 3, 4, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(221, 319);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(34, 31);
            pictureBox3.Margin = new Padding(4, 3, 4, 3);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(221, 319);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 0;
            pictureBox3.TabStop = false;
            // 
            // txtUser
            // 
            txtUser.Font = new Font("Microsoft Sans Serif", 9.75F);
            txtUser.Location = new Point(375, 120);
            txtUser.Name = "txtUser";
            txtUser.Size = new Size(364, 22);
            txtUser.TabIndex = 2;
            // 
            // txtPaswword
            // 
            txtPaswword.Font = new Font("Microsoft Sans Serif", 9.75F);
            txtPaswword.Location = new Point(375, 205);
            txtPaswword.Name = "txtPaswword";
            txtPaswword.PasswordChar = '*';
            txtPaswword.Size = new Size(364, 22);
            txtPaswword.TabIndex = 3;
            // 
            // lblCode
            // 
            lblCode.AutoSize = true;
            lblCode.Font = new Font("Microsoft Sans Serif", 10F);
            lblCode.Location = new Point(350, 90);
            lblCode.Name = "lblCode";
            lblCode.Size = new Size(57, 17);
            lblCode.TabIndex = 4;
            lblCode.Text = "Usuario";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 10F);
            label1.Location = new Point(350, 172);
            label1.Name = "label1";
            label1.Size = new Size(81, 17);
            label1.TabIndex = 5;
            label1.Text = "Contrasena";
            // 
            // btnNew
            // 
            btnNew.ImageAlign = ContentAlignment.MiddleLeft;
            btnNew.Location = new Point(537, 245);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(202, 47);
            btnNew.TabIndex = 6;
            btnNew.Text = "Iniciar Sesion";
            btnNew.UseVisualStyleBackColor = true;
            btnNew.Click += btnNew_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ButtonHighlight;
            label2.Location = new Point(483, 9);
            label2.Name = "label2";
            label2.Size = new Size(65, 25);
            label2.TabIndex = 7;
            label2.Text = "Login";
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Font = new Font("Microsoft Sans Serif", 10F);
            linkLabel1.LinkColor = SystemColors.ControlText;
            linkLabel1.Location = new Point(558, 307);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(181, 17);
            linkLabel1.TabIndex = 8;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Ha olvidado la contrasena?";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Cursor = Cursors.Hand;
            label3.Font = new Font("Microsoft Sans Serif", 12F);
            label3.ForeColor = Color.DimGray;
            label3.Location = new Point(762, 9);
            label3.Name = "label3";
            label3.Padding = new Padding(3, 0, 3, 0);
            label3.Size = new Size(26, 20);
            label3.TabIndex = 9;
            label3.Text = "X";
            label3.Click += label3_Click;
            // 
            // frmInicioSesion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(204, 204, 204);
            ClientSize = new Size(800, 379);
            Controls.Add(label3);
            Controls.Add(linkLabel1);
            Controls.Add(label2);
            Controls.Add(btnNew);
            Controls.Add(label1);
            Controls.Add(lblCode);
            Controls.Add(txtPaswword);
            Controls.Add(txtUser);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            ImeMode = ImeMode.Disable;
            Name = "frmInicioSesion";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmInicioSesion";
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private PictureBox pictureBox1;
        private PictureBox pictureBox3;
        private TextBox txtUser;
        private TextBox txtPaswword;
        private Label lblCode;
        private Label label1;
        private Button btnNew;
        private Label label2;
        private LinkLabel linkLabel1;
        internal Label label3;
    }
}