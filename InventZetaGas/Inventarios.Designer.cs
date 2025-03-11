namespace InventZetaGas
{
    partial class Inventarios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inventarios));
            gbUsuarios = new GroupBox();
            button1 = new Button();
            btnAdd = new Button();
            groupBox1 = new GroupBox();
            txtCantidadCilindro = new TextBox();
            label2 = new Label();
            comboBox3 = new ComboBox();
            label1 = new Label();
            comboBox2 = new ComboBox();
            label10 = new Label();
            txtCantidad = new TextBox();
            cbZonas = new ComboBox();
            label3 = new Label();
            label6 = new Label();
            txtCodeInventario = new TextBox();
            lblCode = new Label();
            gvCamiones = new DataGridView();
            groupBox2 = new GroupBox();
            groupBox3 = new GroupBox();
            textBox1 = new TextBox();
            label4 = new Label();
            comboBox1 = new ComboBox();
            label5 = new Label();
            comboBox4 = new ComboBox();
            label7 = new Label();
            textBox2 = new TextBox();
            comboBox5 = new ComboBox();
            label8 = new Label();
            label9 = new Label();
            textBox3 = new TextBox();
            label11 = new Label();
            gbUsuarios.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gvCamiones).BeginInit();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // gbUsuarios
            // 
            gbUsuarios.BackColor = Color.White;
            gbUsuarios.Controls.Add(button1);
            gbUsuarios.Controls.Add(btnAdd);
            gbUsuarios.Controls.Add(groupBox1);
            gbUsuarios.Controls.Add(comboBox2);
            gbUsuarios.Controls.Add(label10);
            gbUsuarios.Controls.Add(txtCantidad);
            gbUsuarios.Controls.Add(cbZonas);
            gbUsuarios.Controls.Add(label3);
            gbUsuarios.Controls.Add(label6);
            gbUsuarios.Controls.Add(txtCodeInventario);
            gbUsuarios.Controls.Add(lblCode);
            gbUsuarios.Font = new Font("Microsoft Sans Serif", 9.75F);
            gbUsuarios.Location = new Point(12, 12);
            gbUsuarios.Name = "gbUsuarios";
            gbUsuarios.Size = new Size(906, 301);
            gbUsuarios.TabIndex = 6;
            gbUsuarios.TabStop = false;
            gbUsuarios.Text = "Datos de Inventario";
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            button1.Image = (Image)resources.GetObject("button1.Image");
            button1.ImageAlign = ContentAlignment.MiddleLeft;
            button1.Location = new Point(472, 237);
            button1.Name = "button1";
            button1.Size = new Size(187, 43);
            button1.TabIndex = 27;
            button1.Text = "Procesar Inventario";
            button1.TextAlign = ContentAlignment.MiddleRight;
            button1.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            btnAdd.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            btnAdd.Image = (Image)resources.GetObject("btnAdd.Image");
            btnAdd.ImageAlign = ContentAlignment.MiddleLeft;
            btnAdd.Location = new Point(364, 237);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(102, 43);
            btnAdd.TabIndex = 26;
            btnAdd.Text = "Agregar";
            btnAdd.TextAlign = ContentAlignment.MiddleRight;
            btnAdd.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.White;
            groupBox1.Controls.Add(txtCantidadCilindro);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(comboBox3);
            groupBox1.Controls.Add(label1);
            groupBox1.Font = new Font("Microsoft Sans Serif", 9.75F);
            groupBox1.Location = new Point(354, 88);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(305, 129);
            groupBox1.TabIndex = 25;
            groupBox1.TabStop = false;
            groupBox1.Text = "Detalles del Inventario";
            // 
            // txtCantidadCilindro
            // 
            txtCantidadCilindro.Enabled = false;
            txtCantidadCilindro.Font = new Font("Microsoft Sans Serif", 9.75F);
            txtCantidadCilindro.Location = new Point(10, 95);
            txtCantidadCilindro.Name = "txtCantidadCilindro";
            txtCantidadCilindro.Size = new Size(289, 22);
            txtCantidadCilindro.TabIndex = 26;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 10F);
            label2.Location = new Point(10, 73);
            label2.Name = "label2";
            label2.Size = new Size(115, 17);
            label2.TabIndex = 28;
            label2.Text = "Cantidad Cilindro";
            // 
            // comboBox3
            // 
            comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox3.Font = new Font("Microsoft Sans Serif", 9.75F);
            comboBox3.FormattingEnabled = true;
            comboBox3.Location = new Point(10, 46);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(289, 24);
            comboBox3.TabIndex = 27;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 10F);
            label1.Location = new Point(6, 26);
            label1.Name = "label1";
            label1.Size = new Size(77, 17);
            label1.TabIndex = 26;
            label1.Text = "TipoCindro";
            // 
            // comboBox2
            // 
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.Font = new Font("Microsoft Sans Serif", 9.75F);
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(354, 45);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(299, 24);
            comboBox2.TabIndex = 25;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Microsoft Sans Serif", 10F);
            label10.Location = new Point(354, 25);
            label10.Name = "label10";
            label10.Size = new Size(59, 17);
            label10.TabIndex = 24;
            label10.Text = "Estados";
            // 
            // txtCantidad
            // 
            txtCantidad.Enabled = false;
            txtCantidad.Font = new Font("Microsoft Sans Serif", 9.75F);
            txtCantidad.Location = new Point(38, 117);
            txtCantidad.Name = "txtCantidad";
            txtCantidad.Size = new Size(292, 22);
            txtCantidad.TabIndex = 23;
            // 
            // cbZonas
            // 
            cbZonas.DropDownStyle = ComboBoxStyle.DropDownList;
            cbZonas.Font = new Font("Microsoft Sans Serif", 9.75F);
            cbZonas.FormattingEnabled = true;
            cbZonas.Location = new Point(41, 181);
            cbZonas.Name = "cbZonas";
            cbZonas.Size = new Size(289, 24);
            cbZonas.TabIndex = 22;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 10F);
            label3.Location = new Point(38, 161);
            label3.Name = "label3";
            label3.Size = new Size(48, 17);
            label3.TabIndex = 21;
            label3.Text = "Zonas";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 10F);
            label6.Location = new Point(38, 97);
            label6.Name = "label6";
            label6.Size = new Size(126, 17);
            label6.TabIndex = 19;
            label6.Text = "Total de Inventario";
            // 
            // txtCodeInventario
            // 
            txtCodeInventario.Enabled = false;
            txtCodeInventario.Font = new Font("Microsoft Sans Serif", 9.75F);
            txtCodeInventario.Location = new Point(38, 47);
            txtCodeInventario.Name = "txtCodeInventario";
            txtCodeInventario.Size = new Size(292, 22);
            txtCodeInventario.TabIndex = 1;
            // 
            // lblCode
            // 
            lblCode.AutoSize = true;
            lblCode.Font = new Font("Microsoft Sans Serif", 10F);
            lblCode.Location = new Point(38, 27);
            lblCode.Name = "lblCode";
            lblCode.Size = new Size(118, 17);
            lblCode.TabIndex = 0;
            lblCode.Text = "Codigo Inventario";
            // 
            // gvCamiones
            // 
            gvCamiones.AllowUserToAddRows = false;
            gvCamiones.AllowUserToDeleteRows = false;
            gvCamiones.AllowUserToOrderColumns = true;
            gvCamiones.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            gvCamiones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gvCamiones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gvCamiones.Location = new Point(12, 527);
            gvCamiones.Name = "gvCamiones";
            gvCamiones.Size = new Size(906, 177);
            gvCamiones.TabIndex = 7;
            // 
            // groupBox2
            // 
            groupBox2.BackColor = Color.White;
            groupBox2.Controls.Add(groupBox3);
            groupBox2.Controls.Add(comboBox4);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(textBox2);
            groupBox2.Controls.Add(comboBox5);
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(label9);
            groupBox2.Controls.Add(textBox3);
            groupBox2.Controls.Add(label11);
            groupBox2.Font = new Font("Microsoft Sans Serif", 9.75F);
            groupBox2.Location = new Point(12, 319);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(906, 236);
            groupBox2.TabIndex = 8;
            groupBox2.TabStop = false;
            groupBox2.Text = "Asignación ";
            // 
            // groupBox3
            // 
            groupBox3.BackColor = Color.White;
            groupBox3.Controls.Add(textBox1);
            groupBox3.Controls.Add(label4);
            groupBox3.Controls.Add(comboBox1);
            groupBox3.Controls.Add(label5);
            groupBox3.Font = new Font("Microsoft Sans Serif", 9.75F);
            groupBox3.Location = new Point(354, 88);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(305, 129);
            groupBox3.TabIndex = 25;
            groupBox3.TabStop = false;
            groupBox3.Text = "Datos de Usuarios";
            // 
            // textBox1
            // 
            textBox1.Enabled = false;
            textBox1.Font = new Font("Microsoft Sans Serif", 9.75F);
            textBox1.Location = new Point(10, 95);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(289, 22);
            textBox1.TabIndex = 26;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 10F);
            label4.Location = new Point(10, 73);
            label4.Name = "label4";
            label4.Size = new Size(115, 17);
            label4.TabIndex = 28;
            label4.Text = "Cantidad Cilindro";
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.Font = new Font("Microsoft Sans Serif", 9.75F);
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(10, 46);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(289, 24);
            comboBox1.TabIndex = 27;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 10F);
            label5.Location = new Point(6, 26);
            label5.Name = "label5";
            label5.Size = new Size(77, 17);
            label5.TabIndex = 26;
            label5.Text = "TipoCindro";
            // 
            // comboBox4
            // 
            comboBox4.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox4.Font = new Font("Microsoft Sans Serif", 9.75F);
            comboBox4.FormattingEnabled = true;
            comboBox4.Location = new Point(354, 45);
            comboBox4.Name = "comboBox4";
            comboBox4.Size = new Size(299, 24);
            comboBox4.TabIndex = 25;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft Sans Serif", 10F);
            label7.Location = new Point(354, 25);
            label7.Name = "label7";
            label7.Size = new Size(59, 17);
            label7.TabIndex = 24;
            label7.Text = "Estados";
            // 
            // textBox2
            // 
            textBox2.Enabled = false;
            textBox2.Font = new Font("Microsoft Sans Serif", 9.75F);
            textBox2.Location = new Point(38, 117);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(292, 22);
            textBox2.TabIndex = 23;
            // 
            // comboBox5
            // 
            comboBox5.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox5.Font = new Font("Microsoft Sans Serif", 9.75F);
            comboBox5.FormattingEnabled = true;
            comboBox5.Location = new Point(41, 181);
            comboBox5.Name = "comboBox5";
            comboBox5.Size = new Size(289, 24);
            comboBox5.TabIndex = 22;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Microsoft Sans Serif", 10F);
            label8.Location = new Point(38, 161);
            label8.Name = "label8";
            label8.Size = new Size(48, 17);
            label8.TabIndex = 21;
            label8.Text = "Zonas";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Microsoft Sans Serif", 10F);
            label9.Location = new Point(38, 97);
            label9.Name = "label9";
            label9.Size = new Size(126, 17);
            label9.TabIndex = 19;
            label9.Text = "Total de Inventario";
            // 
            // textBox3
            // 
            textBox3.Enabled = false;
            textBox3.Font = new Font("Microsoft Sans Serif", 9.75F);
            textBox3.Location = new Point(38, 47);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(292, 22);
            textBox3.TabIndex = 1;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Microsoft Sans Serif", 10F);
            label11.Location = new Point(38, 27);
            label11.Name = "label11";
            label11.Size = new Size(118, 17);
            label11.TabIndex = 0;
            label11.Text = "Codigo Inventario";
            // 
            // Inventarios
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(933, 729);
            Controls.Add(groupBox2);
            Controls.Add(gvCamiones);
            Controls.Add(gbUsuarios);
            Name = "Inventarios";
            Text = "Inventarios";
            Load += Inventarios_Load;
            gbUsuarios.ResumeLayout(false);
            gbUsuarios.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gvCamiones).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox gbUsuarios;
        private Button btnSearchID;
        private TextBox txtCedula;
        private TextBox txtNombre;
        private Label label6;
        private TextBox txtContraseña;
        private ComboBox cbRol;
        private Button btnBuscar;
        private TextBox txtBuscar;
        private TextBox txtUsuario;
        private Label lblPlaca;
        private RadioButton rbtnInactive;
        private RadioButton rbtnActive;
        private GroupBox groupBox1;
        private Button btnDelete;
        private Button btnAdd;
        private Button btnModify;
        private Button btnNew;
        private TextBox txtApellidos;
        private Label lblZona;
        private TextBox txtCodeInventario;
        private Label lblCode;
        private ComboBox cbZonas;
        private Label label3;
        private TextBox txtCantidad;
        private ComboBox comboBox2;
        private Label label10;
        private ComboBox comboBox3;
        private Label label1;
        private Label label2;
        private TextBox txtCantidadCilindro;
        private DataGridView gvCamiones;
        private Button button1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private TextBox textBox1;
        private Label label4;
        private ComboBox comboBox1;
        private Label label5;
        private ComboBox comboBox4;
        private Label label7;
        private TextBox textBox2;
        private ComboBox comboBox5;
        private Label label8;
        private Label label9;
        private TextBox textBox3;
        private Label label11;
    }
}