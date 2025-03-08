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
            this.txtCantidadTotal = new TextBox();
            label6 = new Label();
            txtCodeInventario = new TextBox();
            lblCode = new Label();
            cbZonas = new ComboBox();
            label3 = new Label();
            gbUsuarios.SuspendLayout();
            SuspendLayout();
            // 
            // gbUsuarios
            // 
            gbUsuarios.BackColor = Color.White;
            gbUsuarios.Controls.Add(cbZonas);
            gbUsuarios.Controls.Add(label3);
            gbUsuarios.Controls.Add(this.txtCantidadTotal);
            gbUsuarios.Controls.Add(label6);
            gbUsuarios.Controls.Add(txtCodeInventario);
            gbUsuarios.Controls.Add(lblCode);
            gbUsuarios.Font = new Font("Microsoft Sans Serif", 9.75F);
            gbUsuarios.Location = new Point(12, 12);
            gbUsuarios.Name = "gbUsuarios";
            gbUsuarios.Size = new Size(910, 227);
            gbUsuarios.TabIndex = 6;
            gbUsuarios.TabStop = false;
            gbUsuarios.Text = "Datos de Usuarios";
            // 
            // txtCantidadTotal
            // 
            this.txtCantidadTotal.Font = new Font("Microsoft Sans Serif", 9.75F);
            this.txtCantidadTotal.Location = new Point(38, 108);
            this.txtCantidadTotal.Name = "txtCantidadTotal";
            this.txtCantidadTotal.Size = new Size(292, 22);
            this.txtCantidadTotal.TabIndex = 20;
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
            // Inventarios
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(930, 674);
            Controls.Add(gbUsuarios);
            Name = "Inventarios";
            Text = "Inventarios";
            gbUsuarios.ResumeLayout(false);
            gbUsuarios.PerformLayout();
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
    }
}