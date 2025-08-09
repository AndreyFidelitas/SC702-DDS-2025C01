namespace InventZetaGas
{
    partial class UsuariosSolicitudes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UsuariosSolicitudes));
            label3 = new Label();
            label5 = new Label();
            gbUsuarios = new GroupBox();
            txtcode = new TextBox();
            label2 = new Label();
            txtCedula = new TextBox();
            label7 = new Label();
            txtNombre = new TextBox();
            label6 = new Label();
            label1 = new Label();
            cbRol = new ComboBox();
            groupBox1 = new GroupBox();
            btnAccept = new Button();
            txtApellidos = new TextBox();
            lblZona = new Label();
            gvSolicitudU = new DataGridView();
            gbUsuarios.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gvSolicitudU).BeginInit();
            SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Cursor = Cursors.Hand;
            label3.Font = new Font("Microsoft Sans Serif", 12F);
            label3.ForeColor = Color.DimGray;
            label3.Location = new Point(12, 9);
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
            label5.Location = new Point(318, 9);
            label5.Name = "label5";
            label5.Size = new Size(168, 25);
            label5.TabIndex = 14;
            label5.Text = "Solicitud Usuarios";
            // 
            // gbUsuarios
            // 
            gbUsuarios.BackColor = Color.White;
            gbUsuarios.Controls.Add(txtcode);
            gbUsuarios.Controls.Add(label2);
            gbUsuarios.Controls.Add(txtCedula);
            gbUsuarios.Controls.Add(label7);
            gbUsuarios.Controls.Add(txtNombre);
            gbUsuarios.Controls.Add(label6);
            gbUsuarios.Controls.Add(label1);
            gbUsuarios.Controls.Add(cbRol);
            gbUsuarios.Controls.Add(groupBox1);
            gbUsuarios.Controls.Add(txtApellidos);
            gbUsuarios.Controls.Add(lblZona);
            gbUsuarios.Font = new Font("Microsoft Sans Serif", 9.75F);
            gbUsuarios.Location = new Point(12, 37);
            gbUsuarios.Name = "gbUsuarios";
            gbUsuarios.Size = new Size(887, 367);
            gbUsuarios.TabIndex = 15;
            gbUsuarios.TabStop = false;
            gbUsuarios.Text = "Datos de Usuarios";
            // 
            // txtcode
            // 
            txtcode.Enabled = false;
            txtcode.Font = new Font("Microsoft Sans Serif", 9.75F);
            txtcode.Location = new Point(38, 48);
            txtcode.Name = "txtcode";
            txtcode.Size = new Size(292, 22);
            txtcode.TabIndex = 24;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 10F);
            label2.Location = new Point(38, 28);
            label2.Name = "label2";
            label2.Size = new Size(109, 17);
            label2.TabIndex = 23;
            label2.Text = "Código Solicitud";
            // 
            // txtCedula
            // 
            txtCedula.Enabled = false;
            txtCedula.Font = new Font("Microsoft Sans Serif", 9.75F);
            txtCedula.Location = new Point(38, 96);
            txtCedula.Name = "txtCedula";
            txtCedula.Size = new Size(292, 22);
            txtCedula.TabIndex = 22;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft Sans Serif", 10F);
            label7.Location = new Point(38, 76);
            label7.Name = "label7";
            label7.Size = new Size(52, 17);
            label7.TabIndex = 21;
            label7.Text = "Cédula";
            // 
            // txtNombre
            // 
            txtNombre.Enabled = false;
            txtNombre.Font = new Font("Microsoft Sans Serif", 9.75F);
            txtNombre.Location = new Point(38, 144);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(292, 22);
            txtNombre.TabIndex = 20;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 10F);
            label6.Location = new Point(38, 124);
            label6.Name = "label6";
            label6.Size = new Size(58, 17);
            label6.TabIndex = 19;
            label6.Text = "Nombre";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 10F);
            label1.Location = new Point(383, 28);
            label1.Name = "label1";
            label1.Size = new Size(29, 17);
            label1.TabIndex = 16;
            label1.Text = "Rol";
            // 
            // cbRol
            // 
            cbRol.DropDownStyle = ComboBoxStyle.DropDownList;
            cbRol.FormattingEnabled = true;
            cbRol.Location = new Point(383, 48);
            cbRol.Name = "cbRol";
            cbRol.Size = new Size(292, 24);
            cbRol.TabIndex = 15;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnAccept);
            groupBox1.Location = new Point(38, 263);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(843, 77);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            groupBox1.Enter += groupBox1_Enter;
            // 
            // btnAccept
            // 
            btnAccept.Image = (Image)resources.GetObject("btnAccept.Image");
            btnAccept.ImageAlign = ContentAlignment.MiddleLeft;
            btnAccept.Location = new Point(640, 21);
            btnAccept.Name = "btnAccept";
            btnAccept.Size = new Size(158, 43);
            btnAccept.TabIndex = 0;
            btnAccept.Text = "Verificar";
            btnAccept.UseVisualStyleBackColor = true;
            btnAccept.Click += btnAccept_Click;
            // 
            // txtApellidos
            // 
            txtApellidos.Enabled = false;
            txtApellidos.Font = new Font("Microsoft Sans Serif", 9.75F);
            txtApellidos.Location = new Point(38, 205);
            txtApellidos.Name = "txtApellidos";
            txtApellidos.Size = new Size(292, 22);
            txtApellidos.TabIndex = 3;
            // 
            // lblZona
            // 
            lblZona.AutoSize = true;
            lblZona.Font = new Font("Microsoft Sans Serif", 10F);
            lblZona.Location = new Point(41, 181);
            lblZona.Name = "lblZona";
            lblZona.Size = new Size(65, 17);
            lblZona.TabIndex = 2;
            lblZona.Text = "Apellidos";
            // 
            // gvSolicitudU
            // 
            gvSolicitudU.AllowUserToOrderColumns = true;
            gvSolicitudU.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            gvSolicitudU.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gvSolicitudU.Location = new Point(12, 410);
            gvSolicitudU.Name = "gvSolicitudU";
            gvSolicitudU.RowHeadersVisible = false;
            gvSolicitudU.RowHeadersWidth = 51;
            gvSolicitudU.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gvSolicitudU.MultiSelect = false;
            gvSolicitudU.Size = new Size(887, 238);
            gvSolicitudU.TabIndex = 16;
            gvSolicitudU.CellContentClick += gvSolicitudU_CellContentClick;
            gvSolicitudU.CellClick += gvSolicitudU_CellClick;
            gvSolicitudU.DataBindingComplete += gvSolicitudU_DataBindingComplete;
            // 
            // UsuariosSolicitudes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(930, 674);
            Controls.Add(gvSolicitudU);
            Controls.Add(gbUsuarios);
            Controls.Add(label5);
            Controls.Add(label3);
            Name = "UsuariosSolicitudes";
            Text = "UsuariosSolicitudes";
            Load += UsuariosSolicitudes_Load;
            gbUsuarios.ResumeLayout(false);
            gbUsuarios.PerformLayout();
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gvSolicitudU).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        internal Label label3;
        private Label label5;
        private GroupBox gbUsuarios;
        private TextBox txtCedula;
        private Label label7;
        private TextBox txtNombre;
        private Label label6;
        private Label label1;
        private ComboBox cbRol;
        private GroupBox groupBox1;
        private Button btnAccept;
        private TextBox txtApellidos;
        private Label lblZona;
        private DataGridView gvSolicitudU;
        private TextBox txtcode;
        private Label label2;
    }
}