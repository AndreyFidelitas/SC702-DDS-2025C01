namespace InventZetaGas
{
    partial class UsuarioNuevos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UsuarioNuevos));
            panel2 = new Panel();
            pictureBox1 = new PictureBox();
            btnNew = new Button();
            lblNombre = new Label();
            lblCode = new Label();
            txtNombre = new TextBox();
            txtCedula = new TextBox();
            label1 = new Label();
            textBox1 = new TextBox();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(1, 38, 90);
            panel2.Controls.Add(pictureBox1);
            panel2.Location = new Point(1, -13);
            panel2.Margin = new Padding(4, 3, 4, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(331, 434);
            panel2.TabIndex = 3;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(54, 44);
            pictureBox1.Margin = new Padding(4, 3, 4, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(231, 335);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // btnNew
            // 
            btnNew.ImageAlign = ContentAlignment.MiddleLeft;
            btnNew.Location = new Point(647, 340);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(202, 47);
            btnNew.TabIndex = 11;
            btnNew.Text = "Registrarse";
            btnNew.UseVisualStyleBackColor = true;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Microsoft Sans Serif", 10F);
            lblNombre.Location = new Point(363, 122);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(58, 17);
            lblNombre.TabIndex = 10;
            lblNombre.Text = "Nombre";
            // 
            // lblCode
            // 
            lblCode.AutoSize = true;
            lblCode.Font = new Font("Microsoft Sans Serif", 10F);
            lblCode.Location = new Point(363, 40);
            lblCode.Name = "lblCode";
            lblCode.Size = new Size(52, 17);
            lblCode.TabIndex = 9;
            lblCode.Text = "Cedula";
            // 
            // txtNombre
            // 
            txtNombre.Font = new Font("Microsoft Sans Serif", 9.75F);
            txtNombre.Location = new Point(388, 173);
            txtNombre.Name = "txtNombre";
            txtNombre.PasswordChar = '*';
            txtNombre.Size = new Size(364, 22);
            txtNombre.TabIndex = 8;
            // 
            // txtCedula
            // 
            txtCedula.Font = new Font("Microsoft Sans Serif", 9.75F);
            txtCedula.Location = new Point(388, 70);
            txtCedula.Name = "txtCedula";
            txtCedula.Size = new Size(364, 22);
            txtCedula.TabIndex = 7;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 10F);
            label1.Location = new Point(363, 216);
            label1.Name = "label1";
            label1.Size = new Size(65, 17);
            label1.TabIndex = 13;
            label1.Text = "Apellidos";
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Microsoft Sans Serif", 9.75F);
            textBox1.Location = new Point(388, 267);
            textBox1.Name = "textBox1";
            textBox1.PasswordChar = '*';
            textBox1.Size = new Size(364, 22);
            textBox1.TabIndex = 12;
            // 
            // UsuarioNuevos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(874, 417);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(btnNew);
            Controls.Add(lblNombre);
            Controls.Add(lblCode);
            Controls.Add(txtNombre);
            Controls.Add(txtCedula);
            Controls.Add(panel2);
            Name = "UsuarioNuevos";
            Text = "UsuarioNuevos";
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel2;
        private PictureBox pictureBox1;
        private Button btnNew;
        private Label lblNombre;
        private Label lblCode;
        private TextBox txtNombre;
        private TextBox txtCedula;
        private Label label1;
        private TextBox textBox1;
    }
}