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
            gbUsuarios = new GroupBox();
            cbZonas = new ComboBox();
            label3 = new Label();
            label6 = new Label();
            txtCodeInventario = new TextBox();
            lblCode = new Label();
            txtCantidad = new TextBox();
            groupBox3 = new GroupBox();
            textBox1 = new TextBox();
            comboBox1 = new ComboBox();
            label5 = new Label();
            label8 = new Label();
            textBox2 = new TextBox();
            label9 = new Label();
            gbUsuarios.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // gbUsuarios
            // 
            gbUsuarios.BackColor = Color.White;
            gbUsuarios.Controls.Add(txtCantidad);
            gbUsuarios.Controls.Add(cbZonas);
            gbUsuarios.Controls.Add(label3);
            gbUsuarios.Controls.Add(label6);
            gbUsuarios.Controls.Add(txtCodeInventario);
            gbUsuarios.Controls.Add(lblCode);
            gbUsuarios.Font = new Font("Microsoft Sans Serif", 9.75F);
            gbUsuarios.Location = new Point(12, 12);
            gbUsuarios.Name = "gbUsuarios";
            gbUsuarios.Size = new Size(906, 217);
            gbUsuarios.TabIndex = 6;
            gbUsuarios.TabStop = false;
            gbUsuarios.Text = "Datos de Usuarios";
            // 
            // cbZonas
            // 
            cbZonas.DropDownStyle = ComboBoxStyle.DropDownList;
            cbZonas.Font = new Font("Microsoft Sans Serif", 9.75F);
            cbZonas.FormattingEnabled = true;
            cbZonas.Location = new Point(38, 181);
            cbZonas.Name = "cbZonas";
            cbZonas.Size = new Size(289, 24);
            cbZonas.TabIndex = 22;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 10F);
            label3.Location = new Point(38, 152);
            label3.Name = "label3";
            label3.Size = new Size(48, 17);
            label3.TabIndex = 21;
            label3.Text = "Zonas";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 10F);
            label6.Location = new Point(38, 88);
            label6.Name = "label6";
            label6.Size = new Size(100, 17);
            label6.TabIndex = 19;
            label6.Text = "Cantidad Total";
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
            // txtCantidad
            // 
            txtCantidad.Enabled = false;
            txtCantidad.Font = new Font("Microsoft Sans Serif", 9.75F);
            txtCantidad.Location = new Point(38, 108);
            txtCantidad.Name = "txtCantidad";
            txtCantidad.Size = new Size(292, 22);
            txtCantidad.TabIndex = 23;
            // 
            // groupBox3
            // 
            groupBox3.BackColor = Color.White;
            groupBox3.Controls.Add(textBox1);
            groupBox3.Controls.Add(comboBox1);
            groupBox3.Controls.Add(label5);
            groupBox3.Controls.Add(label8);
            groupBox3.Controls.Add(textBox2);
            groupBox3.Controls.Add(label9);
            groupBox3.Font = new Font("Microsoft Sans Serif", 9.75F);
            groupBox3.Location = new Point(12, 235);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(906, 174);
            groupBox3.TabIndex = 24;
            groupBox3.TabStop = false;
            groupBox3.Text = "Datos de Usuarios";
            // 
            // textBox1
            // 
            textBox1.Enabled = false;
            textBox1.Font = new Font("Microsoft Sans Serif", 9.75F);
            textBox1.Location = new Point(328, 54);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(292, 22);
            textBox1.TabIndex = 23;
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.Font = new Font("Microsoft Sans Serif", 9.75F);
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(630, 47);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(289, 24);
            comboBox1.TabIndex = 22;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 10F);
            label5.Location = new Point(630, 18);
            label5.Name = "label5";
            label5.Size = new Size(48, 17);
            label5.TabIndex = 21;
            label5.Text = "Zonas";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Microsoft Sans Serif", 10F);
            label8.Location = new Point(328, 34);
            label8.Name = "label8";
            label8.Size = new Size(100, 17);
            label8.TabIndex = 19;
            label8.Text = "Cantidad Total";
            // 
            // textBox2
            // 
            textBox2.Enabled = false;
            textBox2.Font = new Font("Microsoft Sans Serif", 9.75F);
            textBox2.Location = new Point(20, 54);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(292, 22);
            textBox2.TabIndex = 1;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Microsoft Sans Serif", 10F);
            label9.Location = new Point(20, 34);
            label9.Name = "label9";
            label9.Size = new Size(118, 17);
            label9.TabIndex = 0;
            label9.Text = "Codigo Inventario";
            // 
            // Inventarios
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(930, 674);
            Controls.Add(groupBox3);
            Controls.Add(gbUsuarios);
            Name = "Inventarios";
            Text = "Inventarios";
            gbUsuarios.ResumeLayout(false);
            gbUsuarios.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox gbUsuarios;
        private Button btnSearchID;
        private TextBox txtCedula;
        private Label label7;
        private TextBox txtNombre;
        private Label label6;
        private Label label2;
        private TextBox txtContraseña;
        private Label label1;
        private ComboBox cbRol;
        private Button btnBuscar;
        private TextBox txtBuscar;
        private Label label4;
        private TextBox txtUsuario;
        private Label lblPlaca;
        private GroupBox groupBox2;
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
        private GroupBox groupBox3;
        private TextBox textBox1;
        private ComboBox comboBox1;
        private Label label5;
        private Label label8;
        private TextBox textBox2;
        private Label label9;
    }
}