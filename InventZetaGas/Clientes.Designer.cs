namespace InventZetaGas
{
    partial class Clientes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Clientes));
            gbUsuarios = new GroupBox();
            btnSearchID = new Button();
            txtCedula = new TextBox();
            label7 = new Label();
            txtRazonSocial = new TextBox();
            label6 = new Label();
            btnBuscar = new Button();
            txtBuscar = new TextBox();
            label4 = new Label();
            groupBox2 = new GroupBox();
            rbtnInactive = new RadioButton();
            rbtnActive = new RadioButton();
            groupBox1 = new GroupBox();
            btnDelete = new Button();
            btnAdd = new Button();
            btnModify = new Button();
            btnNew = new Button();
            txtEmpresa = new TextBox();
            lblZona = new Label();
            txtCodeUser = new TextBox();
            lblCode = new Label();
            gvClientes = new DataGridView();
            label3 = new Label();
            label5 = new Label();
            gbUsuarios.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gvClientes).BeginInit();
            SuspendLayout();
            // 
            // gbUsuarios
            // 
            gbUsuarios.BackColor = Color.White;
            gbUsuarios.Controls.Add(btnSearchID);
            gbUsuarios.Controls.Add(txtCedula);
            gbUsuarios.Controls.Add(label7);
            gbUsuarios.Controls.Add(txtRazonSocial);
            gbUsuarios.Controls.Add(label6);
            gbUsuarios.Controls.Add(btnBuscar);
            gbUsuarios.Controls.Add(txtBuscar);
            gbUsuarios.Controls.Add(label4);
            gbUsuarios.Controls.Add(groupBox2);
            gbUsuarios.Controls.Add(groupBox1);
            gbUsuarios.Controls.Add(txtEmpresa);
            gbUsuarios.Controls.Add(lblZona);
            gbUsuarios.Controls.Add(txtCodeUser);
            gbUsuarios.Controls.Add(lblCode);
            gbUsuarios.Font = new Font("Microsoft Sans Serif", 9.75F);
            gbUsuarios.Location = new Point(12, 30);
            gbUsuarios.Name = "gbUsuarios";
            gbUsuarios.Size = new Size(910, 442);
            gbUsuarios.TabIndex = 6;
            gbUsuarios.TabStop = false;
            gbUsuarios.Text = "Datos de Usuarios";
            // 
            // btnSearchID
            // 
            btnSearchID.Image = (Image)resources.GetObject("btnSearchID.Image");
            btnSearchID.ImageAlign = ContentAlignment.MiddleLeft;
            btnSearchID.Location = new Point(339, 114);
            btnSearchID.Name = "btnSearchID";
            btnSearchID.Size = new Size(37, 24);
            btnSearchID.TabIndex = 23;
            btnSearchID.UseVisualStyleBackColor = true;
            btnSearchID.Click += btnSearchID_Click;
            // 
            // txtCedula
            // 
            txtCedula.Enabled = false;
            txtCedula.Font = new Font("Microsoft Sans Serif", 9.75F);
            txtCedula.Location = new Point(41, 116);
            txtCedula.Name = "txtCedula";
            txtCedula.Size = new Size(292, 22);
            txtCedula.TabIndex = 22;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft Sans Serif", 10F);
            label7.Location = new Point(41, 96);
            label7.Name = "label7";
            label7.Size = new Size(52, 17);
            label7.TabIndex = 21;
            label7.Text = "Cedula";
            // 
            // txtRazonSocial
            // 
            txtRazonSocial.Font = new Font("Microsoft Sans Serif", 9.75F);
            txtRazonSocial.Location = new Point(41, 174);
            txtRazonSocial.Name = "txtRazonSocial";
            txtRazonSocial.Size = new Size(292, 22);
            txtRazonSocial.TabIndex = 20;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 10F);
            label6.Location = new Point(41, 154);
            label6.Name = "label6";
            label6.Size = new Size(91, 17);
            label6.TabIndex = 19;
            label6.Text = "Razon Social";
            // 
            // btnBuscar
            // 
            btnBuscar.Image = (Image)resources.GetObject("btnBuscar.Image");
            btnBuscar.ImageAlign = ContentAlignment.MiddleLeft;
            btnBuscar.Location = new Point(748, 407);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(139, 26);
            btnBuscar.TabIndex = 4;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // txtBuscar
            // 
            txtBuscar.Font = new Font("Microsoft Sans Serif", 9.75F);
            txtBuscar.Location = new Point(99, 409);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(643, 22);
            txtBuscar.TabIndex = 14;
            txtBuscar.KeyPress += txtBuscar_KeyPress;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 10F);
            label4.Location = new Point(41, 412);
            label4.Name = "label4";
            label4.Size = new Size(52, 17);
            label4.TabIndex = 13;
            label4.Text = "Buscar";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(rbtnInactive);
            groupBox2.Controls.Add(rbtnActive);
            groupBox2.Location = new Point(391, 56);
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
            rbtnInactive.CheckedChanged += rbtnInactive_CheckedChanged;
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
            rbtnActive.CheckedChanged += rbtnActive_CheckedChanged;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnDelete);
            groupBox1.Controls.Add(btnAdd);
            groupBox1.Controls.Add(btnModify);
            groupBox1.Controls.Add(btnNew);
            groupBox1.Location = new Point(41, 317);
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
            btnDelete.Click += btnDelete_Click;
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
            btnAdd.Click += btnAdd_Click;
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
            btnModify.Click += btnModify_Click;
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
            // txtEmpresa
            // 
            txtEmpresa.Font = new Font("Microsoft Sans Serif", 9.75F);
            txtEmpresa.Location = new Point(41, 235);
            txtEmpresa.Name = "txtEmpresa";
            txtEmpresa.Size = new Size(292, 22);
            txtEmpresa.TabIndex = 3;
            // 
            // lblZona
            // 
            lblZona.AutoSize = true;
            lblZona.Font = new Font("Microsoft Sans Serif", 10F);
            lblZona.Location = new Point(44, 211);
            lblZona.Name = "lblZona";
            lblZona.Size = new Size(64, 17);
            lblZona.TabIndex = 2;
            lblZona.Text = "Empresa";
            // 
            // txtCodeUser
            // 
            txtCodeUser.Enabled = false;
            txtCodeUser.Font = new Font("Microsoft Sans Serif", 9.75F);
            txtCodeUser.Location = new Point(41, 56);
            txtCodeUser.Name = "txtCodeUser";
            txtCodeUser.Size = new Size(292, 22);
            txtCodeUser.TabIndex = 1;
            // 
            // lblCode
            // 
            lblCode.AutoSize = true;
            lblCode.Font = new Font("Microsoft Sans Serif", 10F);
            lblCode.Location = new Point(41, 36);
            lblCode.Name = "lblCode";
            lblCode.Size = new Size(105, 17);
            lblCode.TabIndex = 0;
            lblCode.Text = "Codigo Usuario";
            // 
            // gvClientes
            // 
            gvClientes.AllowUserToOrderColumns = true;
            gvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gvClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gvClientes.Location = new Point(12, 478);
            gvClientes.Name = "gvClientes";
            gvClientes.RowHeadersWidth = 51;
            gvClientes.Size = new Size(910, 159);
            gvClientes.TabIndex = 7;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Cursor = Cursors.Hand;
            label3.Font = new Font("Microsoft Sans Serif", 12F);
            label3.ForeColor = Color.DimGray;
            label3.Location = new Point(12, 7);
            label3.Name = "label3";
            label3.Padding = new Padding(3, 0, 3, 0);
            label3.Size = new Size(26, 20);
            label3.TabIndex = 13;
            label3.Text = "X";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 15F);
            label5.ForeColor = SystemColors.GrayText;
            label5.Location = new Point(338, 2);
            label5.Name = "label5";
            label5.Size = new Size(153, 25);
            label5.TabIndex = 14;
            label5.Text = "Modulo Clientes";
            // 
            // Clientes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(930, 674);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(gvClientes);
            Controls.Add(gbUsuarios);
            Name = "Clientes";
            Text = "Clientes";
            Load += Clientes_Load;
            gbUsuarios.ResumeLayout(false);
            gbUsuarios.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gvClientes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox gbUsuarios;
        private Button btnSearchID;
        private TextBox txtCedula;
        private Label label7;
        private TextBox txtRazonSocial;
        private Label label6;
        private Label label1;
        private ComboBox cbRol;
        private Button btnBuscar;
        private TextBox txtBuscar;
        private Label label4;
        private GroupBox groupBox2;
        private RadioButton rbtnInactive;
        private RadioButton rbtnActive;
        private GroupBox groupBox1;
        private Button btnDelete;
        private Button btnAdd;
        private Button btnModify;
        private Button btnNew;
        private TextBox txtEmpresa;
        private Label lblZona;
        private TextBox txtCodeUser;
        private Label lblCode;
        private DataGridView gvClientes;
        internal Label label3;
        private Label label5;
    }
}