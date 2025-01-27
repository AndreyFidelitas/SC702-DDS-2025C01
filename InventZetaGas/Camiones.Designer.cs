namespace InventZetaGas
{
    partial class Camiones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Camiones));
            label2 = new Label();
            label1 = new Label();
            gbRaza = new GroupBox();
            groupBox2 = new GroupBox();
            rbtnInactive = new RadioButton();
            rbtnActive = new RadioButton();
            groupBox1 = new GroupBox();
            btnDelete = new Button();
            btnAdd = new Button();
            btnModify = new Button();
            btnNew = new Button();
            txtCamion = new TextBox();
            lblZona = new Label();
            txtCodeCamion = new TextBox();
            lblCode = new Label();
            gvCamiones = new DataGridView();
            lblPlaca = new Label();
            txtPlaca = new TextBox();
            gbRaza.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gvCamiones).BeginInit();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Cursor = Cursors.Hand;
            label2.Font = new Font("Microsoft Sans Serif", 12F);
            label2.ForeColor = Color.DimGray;
            label2.Location = new Point(12, 9);
            label2.Name = "label2";
            label2.Padding = new Padding(3, 0, 3, 0);
            label2.Size = new Size(26, 20);
            label2.TabIndex = 2;
            label2.Text = "X";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 15F);
            label1.ForeColor = SystemColors.GrayText;
            label1.Location = new Point(442, 9);
            label1.Name = "label1";
            label1.Size = new Size(171, 25);
            label1.TabIndex = 3;
            label1.Text = "Modulo Camiones";
            // 
            // gbRaza
            // 
            gbRaza.BackColor = Color.White;
            gbRaza.Controls.Add(txtPlaca);
            gbRaza.Controls.Add(lblPlaca);
            gbRaza.Controls.Add(groupBox2);
            gbRaza.Controls.Add(groupBox1);
            gbRaza.Controls.Add(txtCamion);
            gbRaza.Controls.Add(lblZona);
            gbRaza.Controls.Add(txtCodeCamion);
            gbRaza.Controls.Add(lblCode);
            gbRaza.Font = new Font("Microsoft Sans Serif", 9.75F);
            gbRaza.Location = new Point(12, 37);
            gbRaza.Name = "gbRaza";
            gbRaza.Size = new Size(905, 389);
            gbRaza.TabIndex = 4;
            gbRaza.TabStop = false;
            gbRaza.Text = "Datos de Zonas";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(rbtnInactive);
            groupBox2.Controls.Add(rbtnActive);
            groupBox2.Location = new Point(413, 38);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(335, 129);
            groupBox2.TabIndex = 8;
            groupBox2.TabStop = false;
            groupBox2.Text = "Estado";
            // 
            // rbtnInactive
            // 
            rbtnInactive.AutoSize = true;
            rbtnInactive.Location = new Point(25, 79);
            rbtnInactive.Name = "rbtnInactive";
            rbtnInactive.Size = new Size(71, 20);
            rbtnInactive.TabIndex = 1;
            rbtnInactive.TabStop = true;
            rbtnInactive.Text = "Inactivo";
            rbtnInactive.UseVisualStyleBackColor = true;
            // 
            // rbtnActive
            // 
            rbtnActive.AutoSize = true;
            rbtnActive.Location = new Point(25, 38);
            rbtnActive.Name = "rbtnActive";
            rbtnActive.Size = new Size(62, 20);
            rbtnActive.TabIndex = 0;
            rbtnActive.TabStop = true;
            rbtnActive.Text = "Activo";
            rbtnActive.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnDelete);
            groupBox1.Controls.Add(btnAdd);
            groupBox1.Controls.Add(btnModify);
            groupBox1.Controls.Add(btnNew);
            groupBox1.Location = new Point(41, 257);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(846, 91);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            // 
            // btnDelete
            // 
            btnDelete.Image = (Image)resources.GetObject("btnDelete.Image");
            btnDelete.ImageAlign = ContentAlignment.MiddleLeft;
            btnDelete.Location = new Point(582, 21);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(158, 43);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "Eliminar";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            btnAdd.Image = (Image)resources.GetObject("btnAdd.Image");
            btnAdd.ImageAlign = ContentAlignment.MiddleLeft;
            btnAdd.Location = new Point(209, 21);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(158, 43);
            btnAdd.TabIndex = 2;
            btnAdd.Text = "Agregar";
            btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnModify
            // 
            btnModify.Image = (Image)resources.GetObject("btnModify.Image");
            btnModify.ImageAlign = ContentAlignment.MiddleLeft;
            btnModify.Location = new Point(391, 21);
            btnModify.Name = "btnModify";
            btnModify.Size = new Size(158, 43);
            btnModify.TabIndex = 1;
            btnModify.Text = "Modificar";
            btnModify.UseVisualStyleBackColor = true;
            // 
            // btnNew
            // 
            btnNew.Image = (Image)resources.GetObject("btnNew.Image");
            btnNew.ImageAlign = ContentAlignment.MiddleLeft;
            btnNew.Location = new Point(18, 21);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(158, 43);
            btnNew.TabIndex = 0;
            btnNew.Text = "Nuevo";
            btnNew.UseVisualStyleBackColor = true;
            // 
            // txtCamion
            // 
            txtCamion.Font = new Font("Microsoft Sans Serif", 9.75F);
            txtCamion.Location = new Point(41, 145);
            txtCamion.Name = "txtCamion";
            txtCamion.Size = new Size(289, 22);
            txtCamion.TabIndex = 3;
            // 
            // lblZona
            // 
            lblZona.AutoSize = true;
            lblZona.Font = new Font("Microsoft Sans Serif", 10F);
            lblZona.Location = new Point(41, 117);
            lblZona.Name = "lblZona";
            lblZona.Size = new Size(47, 17);
            lblZona.TabIndex = 2;
            lblZona.Text = "Marca";
            // 
            // txtCodeCamion
            // 
            txtCodeCamion.Enabled = false;
            txtCodeCamion.Font = new Font("Microsoft Sans Serif", 9.75F);
            txtCodeCamion.Location = new Point(41, 76);
            txtCodeCamion.Name = "txtCodeCamion";
            txtCodeCamion.Size = new Size(292, 22);
            txtCodeCamion.TabIndex = 1;
            // 
            // lblCode
            // 
            lblCode.AutoSize = true;
            lblCode.Font = new Font("Microsoft Sans Serif", 10F);
            lblCode.Location = new Point(41, 38);
            lblCode.Name = "lblCode";
            lblCode.Size = new Size(118, 17);
            lblCode.TabIndex = 0;
            lblCode.Text = "Código Camiones";
            // 
            // gvCamiones
            // 
            gvCamiones.AllowUserToAddRows = false;
            gvCamiones.AllowUserToDeleteRows = false;
            gvCamiones.AllowUserToOrderColumns = true;
            gvCamiones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gvCamiones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gvCamiones.Location = new Point(12, 473);
            gvCamiones.Name = "gvCamiones";
            gvCamiones.Size = new Size(905, 172);
            gvCamiones.TabIndex = 5;
            // 
            // lblPlaca
            // 
            lblPlaca.AutoSize = true;
            lblPlaca.Font = new Font("Microsoft Sans Serif", 10F);
            lblPlaca.Location = new Point(41, 179);
            lblPlaca.Name = "lblPlaca";
            lblPlaca.Size = new Size(43, 17);
            lblPlaca.TabIndex = 9;
            lblPlaca.Text = "Placa";
            // 
            // txtPlaca
            // 
            txtPlaca.Font = new Font("Microsoft Sans Serif", 9.75F);
            txtPlaca.Location = new Point(41, 210);
            txtPlaca.Name = "txtPlaca";
            txtPlaca.Size = new Size(289, 22);
            txtPlaca.TabIndex = 10;
            // 
            // Camiones
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1103, 729);
            Controls.Add(gvCamiones);
            Controls.Add(gbRaza);
            Controls.Add(label1);
            Controls.Add(label2);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Camiones";
            Text = "Camiones";
            Load += Camiones_Load;
            gbRaza.ResumeLayout(false);
            gbRaza.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gvCamiones).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        internal Label label2;
        private Label label1;
        private GroupBox gbRaza;
        private GroupBox groupBox2;
        private RadioButton rbtnInactive;
        private RadioButton rbtnActive;
        private GroupBox groupBox1;
        private Button btnDelete;
        private Button btnAdd;
        private Button btnModify;
        private Button btnNew;
        private TextBox txtCamion;
        private Label lblZona;
        private TextBox txtCodeCamion;
        private Label lblCode;
        private DataGridView gvCamiones;
        private TextBox txtPlaca;
        private Label lblPlaca;
    }
}