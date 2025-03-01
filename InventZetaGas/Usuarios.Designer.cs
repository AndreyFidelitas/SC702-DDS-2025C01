namespace InventZetaGas
{
    partial class Usuarios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Usuarios));
            gbUsuarios = new GroupBox();
            label2 = new Label();
            textBox1 = new TextBox();
            label1 = new Label();
            cbRol = new ComboBox();
            btnBuscar = new Button();
            txtBuscar = new TextBox();
            label4 = new Label();
            txtPlaca = new TextBox();
            lblPlaca = new Label();
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
            gbUsuarios.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gvCamiones).BeginInit();
            SuspendLayout();
            // 
            // gbUsuarios
            // 
            gbUsuarios.BackColor = Color.White;
            gbUsuarios.Controls.Add(label2);
            gbUsuarios.Controls.Add(textBox1);
            gbUsuarios.Controls.Add(label1);
            gbUsuarios.Controls.Add(cbRol);
            gbUsuarios.Controls.Add(btnBuscar);
            gbUsuarios.Controls.Add(txtBuscar);
            gbUsuarios.Controls.Add(label4);
            gbUsuarios.Controls.Add(txtPlaca);
            gbUsuarios.Controls.Add(lblPlaca);
            gbUsuarios.Controls.Add(groupBox2);
            gbUsuarios.Controls.Add(groupBox1);
            gbUsuarios.Controls.Add(txtCamion);
            gbUsuarios.Controls.Add(lblZona);
            gbUsuarios.Controls.Add(txtCodeCamion);
            gbUsuarios.Controls.Add(lblCode);
            gbUsuarios.Font = new Font("Microsoft Sans Serif", 9.75F);
            gbUsuarios.Location = new Point(12, 39);
            gbUsuarios.Name = "gbUsuarios";
            gbUsuarios.Size = new Size(910, 433);
            gbUsuarios.TabIndex = 5;
            gbUsuarios.TabStop = false;
            gbUsuarios.Text = "Datos de Usuarios";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 10F);
            label2.Location = new Point(47, 251);
            label2.Name = "label2";
            label2.Size = new Size(69, 17);
            label2.TabIndex = 18;
            label2.Text = "Password";
            label2.Click += label2_Click;
            // 
            // textBox1
            // 
            textBox1.Enabled = false;
            textBox1.Font = new Font("Microsoft Sans Serif", 9.75F);
            textBox1.Location = new Point(41, 277);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(292, 22);
            textBox1.TabIndex = 17;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 10F);
            label1.Location = new Point(393, 179);
            label1.Name = "label1";
            label1.Size = new Size(102, 17);
            label1.TabIndex = 16;
            label1.Text = "Rol de Usuario";
            // 
            // cbRol
            // 
            cbRol.FormattingEnabled = true;
            cbRol.Location = new Point(393, 208);
            cbRol.Name = "cbRol";
            cbRol.Size = new Size(292, 24);
            cbRol.TabIndex = 15;
            // 
            // btnBuscar
            // 
            btnBuscar.Image = (Image)resources.GetObject("btnBuscar.Image");
            btnBuscar.ImageAlign = ContentAlignment.MiddleLeft;
            btnBuscar.Location = new Point(748, 395);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(139, 26);
            btnBuscar.TabIndex = 4;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            // 
            // txtBuscar
            // 
            txtBuscar.Font = new Font("Microsoft Sans Serif", 9.75F);
            txtBuscar.Location = new Point(99, 397);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(643, 22);
            txtBuscar.TabIndex = 14;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 10F);
            label4.Location = new Point(41, 400);
            label4.Name = "label4";
            label4.Size = new Size(52, 17);
            label4.TabIndex = 13;
            label4.Text = "Buscar";
            // 
            // txtPlaca
            // 
            txtPlaca.Font = new Font("Microsoft Sans Serif", 9.75F);
            txtPlaca.Location = new Point(41, 210);
            txtPlaca.Name = "txtPlaca";
            txtPlaca.Size = new Size(289, 22);
            txtPlaca.TabIndex = 10;
            // 
            // lblPlaca
            // 
            lblPlaca.AutoSize = true;
            lblPlaca.Font = new Font("Microsoft Sans Serif", 10F);
            lblPlaca.Location = new Point(41, 179);
            lblPlaca.Name = "lblPlaca";
            lblPlaca.Size = new Size(75, 17);
            lblPlaca.TabIndex = 9;
            lblPlaca.Text = "UserName";
            lblPlaca.Click += lblPlaca_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(rbtnInactive);
            groupBox2.Controls.Add(rbtnActive);
            groupBox2.Location = new Point(393, 38);
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
            groupBox1.Location = new Point(41, 305);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(846, 77);
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
            btnNew.Click += btnNew_Click;
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
            lblZona.Size = new Size(65, 17);
            lblZona.TabIndex = 2;
            lblZona.Text = "Apellidos";
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
            lblCode.Size = new Size(131, 17);
            lblCode.TabIndex = 0;
            lblCode.Text = "Nombre de Usuario";
            lblCode.Click += lblCode_Click;
            // 
            // gvCamiones
            // 
            gvCamiones.AllowUserToAddRows = false;
            gvCamiones.AllowUserToDeleteRows = false;
            gvCamiones.AllowUserToOrderColumns = true;
            gvCamiones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gvCamiones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gvCamiones.Location = new Point(12, 478);
            gvCamiones.Name = "gvCamiones";
            gvCamiones.RowHeadersWidth = 51;
            gvCamiones.Size = new Size(905, 172);
            gvCamiones.TabIndex = 6;
            // 
            // Usuarios
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(930, 674);
            Controls.Add(gvCamiones);
            Controls.Add(gbUsuarios);
            Name = "Usuarios";
            Text = "Usuarios";
            Load += Usuarios_Load;
            gbUsuarios.ResumeLayout(false);
            gbUsuarios.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gvCamiones).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox gbUsuarios;
        private Button btnBuscar;
        private TextBox txtBuscar;
        private Label label4;
        private TextBox txtPlaca;
        private Label lblPlaca;
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
        private TextBox textBox1;
        private Label label1;
        private ComboBox cbRol;
        private Label label2;
    }
}