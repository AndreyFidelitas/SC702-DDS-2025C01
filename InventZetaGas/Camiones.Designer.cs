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
            txtPesaje = new TextBox();
            lblPesaje = new Label();
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
            label2.Location = new Point(14, 12);
            label2.Name = "label2";
            label2.Padding = new Padding(3, 0, 3, 0);
            label2.Size = new Size(32, 25);
            label2.TabIndex = 2;
            label2.Text = "X";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 15F);
            label1.ForeColor = SystemColors.GrayText;
            label1.Location = new Point(505, 12);
            label1.Name = "label1";
            label1.Size = new Size(218, 29);
            label1.TabIndex = 3;
            label1.Text = "Modulo Camiones";
            // 
            // gbRaza
            // 
            gbRaza.BackColor = Color.White;
            gbRaza.Controls.Add(txtPesaje);
            gbRaza.Controls.Add(lblPesaje);
            gbRaza.Controls.Add(txtPlaca);
            gbRaza.Controls.Add(lblPlaca);
            gbRaza.Controls.Add(groupBox2);
            gbRaza.Controls.Add(groupBox1);
            gbRaza.Controls.Add(txtCamion);
            gbRaza.Controls.Add(lblZona);
            gbRaza.Controls.Add(txtCodeCamion);
            gbRaza.Controls.Add(lblCode);
            gbRaza.Font = new Font("Microsoft Sans Serif", 9.75F);
            gbRaza.Location = new Point(14, 49);
            gbRaza.Margin = new Padding(3, 4, 3, 4);
            gbRaza.Name = "gbRaza";
            gbRaza.Padding = new Padding(3, 4, 3, 4);
            gbRaza.Size = new Size(1034, 533);
            gbRaza.TabIndex = 4;
            gbRaza.TabStop = false;
            gbRaza.Text = "Datos de Zonas";
            // 
            // txtPesaje
            // 
            txtPesaje.Font = new Font("Microsoft Sans Serif", 9.75F);
            txtPesaje.Location = new Point(47, 369);
            txtPesaje.Margin = new Padding(3, 4, 3, 4);
            txtPesaje.Name = "txtPesaje";
            txtPesaje.Size = new Size(330, 26);
            txtPesaje.TabIndex = 12;
            // 
            // lblPesaje
            // 
            lblPesaje.AutoSize = true;
            lblPesaje.Font = new Font("Microsoft Sans Serif", 10F);
            lblPesaje.Location = new Point(47, 331);
            lblPesaje.Name = "lblPesaje";
            lblPesaje.Size = new Size(60, 20);
            lblPesaje.TabIndex = 11;
            lblPesaje.Text = "Pesaje";
            // 
            // txtPlaca
            // 
            txtPlaca.Font = new Font("Microsoft Sans Serif", 9.75F);
            txtPlaca.Location = new Point(47, 280);
            txtPlaca.Margin = new Padding(3, 4, 3, 4);
            txtPlaca.Name = "txtPlaca";
            txtPlaca.Size = new Size(330, 26);
            txtPlaca.TabIndex = 10;
            // 
            // lblPlaca
            // 
            lblPlaca.AutoSize = true;
            lblPlaca.Font = new Font("Microsoft Sans Serif", 10F);
            lblPlaca.Location = new Point(47, 239);
            lblPlaca.Name = "lblPlaca";
            lblPlaca.Size = new Size(51, 20);
            lblPlaca.TabIndex = 9;
            lblPlaca.Text = "Placa";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(rbtnInactive);
            groupBox2.Controls.Add(rbtnActive);
            groupBox2.Location = new Point(449, 51);
            groupBox2.Margin = new Padding(3, 4, 3, 4);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(3, 4, 3, 4);
            groupBox2.Size = new Size(383, 172);
            groupBox2.TabIndex = 8;
            groupBox2.TabStop = false;
            groupBox2.Text = "Estado";
            // 
            // rbtnInactive
            // 
            rbtnInactive.AutoSize = true;
            rbtnInactive.Location = new Point(29, 105);
            rbtnInactive.Margin = new Padding(3, 4, 3, 4);
            rbtnInactive.Name = "rbtnInactive";
            rbtnInactive.Size = new Size(87, 24);
            rbtnInactive.TabIndex = 1;
            rbtnInactive.TabStop = true;
            rbtnInactive.Text = "Inactivo";
            rbtnInactive.UseVisualStyleBackColor = true;
            rbtnInactive.CheckedChanged += rbtnInactive_CheckedChanged;
            // 
            // rbtnActive
            // 
            rbtnActive.AutoSize = true;
            rbtnActive.Location = new Point(29, 51);
            rbtnActive.Margin = new Padding(3, 4, 3, 4);
            rbtnActive.Name = "rbtnActive";
            rbtnActive.Size = new Size(76, 24);
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
            groupBox1.Location = new Point(47, 407);
            groupBox1.Margin = new Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 4, 3, 4);
            groupBox1.Size = new Size(967, 103);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            // 
            // btnDelete
            // 
            btnDelete.Image = (Image)resources.GetObject("btnDelete.Image");
            btnDelete.ImageAlign = ContentAlignment.MiddleLeft;
            btnDelete.Location = new Point(665, 28);
            btnDelete.Margin = new Padding(3, 4, 3, 4);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(181, 57);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "Eliminar";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnAdd
            // 
            btnAdd.Image = (Image)resources.GetObject("btnAdd.Image");
            btnAdd.ImageAlign = ContentAlignment.MiddleLeft;
            btnAdd.Location = new Point(239, 28);
            btnAdd.Margin = new Padding(3, 4, 3, 4);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(181, 57);
            btnAdd.TabIndex = 2;
            btnAdd.Text = "Agregar";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnModify
            // 
            btnModify.Image = (Image)resources.GetObject("btnModify.Image");
            btnModify.ImageAlign = ContentAlignment.MiddleLeft;
            btnModify.Location = new Point(447, 28);
            btnModify.Margin = new Padding(3, 4, 3, 4);
            btnModify.Name = "btnModify";
            btnModify.Size = new Size(181, 57);
            btnModify.TabIndex = 1;
            btnModify.Text = "Modificar";
            btnModify.UseVisualStyleBackColor = true;
            btnModify.Click += btnModify_Click;
            // 
            // btnNew
            // 
            btnNew.Image = (Image)resources.GetObject("btnNew.Image");
            btnNew.ImageAlign = ContentAlignment.MiddleLeft;
            btnNew.Location = new Point(21, 28);
            btnNew.Margin = new Padding(3, 4, 3, 4);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(181, 57);
            btnNew.TabIndex = 0;
            btnNew.Text = "Nuevo";
            btnNew.UseVisualStyleBackColor = true;
            btnNew.Click += btnNew_Click;
            // 
            // txtCamion
            // 
            txtCamion.Font = new Font("Microsoft Sans Serif", 9.75F);
            txtCamion.Location = new Point(47, 193);
            txtCamion.Margin = new Padding(3, 4, 3, 4);
            txtCamion.Name = "txtCamion";
            txtCamion.Size = new Size(330, 26);
            txtCamion.TabIndex = 3;
            // 
            // lblZona
            // 
            lblZona.AutoSize = true;
            lblZona.Font = new Font("Microsoft Sans Serif", 10F);
            lblZona.Location = new Point(47, 156);
            lblZona.Name = "lblZona";
            lblZona.Size = new Size(56, 20);
            lblZona.TabIndex = 2;
            lblZona.Text = "Marca";
            // 
            // txtCodeCamion
            // 
            txtCodeCamion.Enabled = false;
            txtCodeCamion.Font = new Font("Microsoft Sans Serif", 9.75F);
            txtCodeCamion.Location = new Point(47, 101);
            txtCodeCamion.Margin = new Padding(3, 4, 3, 4);
            txtCodeCamion.Name = "txtCodeCamion";
            txtCodeCamion.Size = new Size(333, 26);
            txtCodeCamion.TabIndex = 1;
            // 
            // lblCode
            // 
            lblCode.AutoSize = true;
            lblCode.Font = new Font("Microsoft Sans Serif", 10F);
            lblCode.Location = new Point(47, 51);
            lblCode.Name = "lblCode";
            lblCode.Size = new Size(141, 20);
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
            gvCamiones.Location = new Point(14, 631);
            gvCamiones.Margin = new Padding(3, 4, 3, 4);
            gvCamiones.Name = "gvCamiones";
            gvCamiones.RowHeadersWidth = 51;
            gvCamiones.Size = new Size(1034, 229);
            gvCamiones.TabIndex = 5;
            gvCamiones.CellContentClick += gvCamiones_CellContentClick;
            // 
            // Camiones
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1261, 972);
            Controls.Add(gvCamiones);
            Controls.Add(gbRaza);
            Controls.Add(label1);
            Controls.Add(label2);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
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
        private TextBox txtPesaje;
        private Label lblPesaje;
    }
}