namespace InventZetaGas
{
    partial class Zonas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Zonas));
            gbRaza = new GroupBox();
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
            cbProvincias = new ComboBox();
            label3 = new Label();
            txtZona = new TextBox();
            lblZona = new Label();
            txtCodeZona = new TextBox();
            lblCode = new Label();
            gvZonas = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            gbRaza.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gvZonas).BeginInit();
            SuspendLayout();
            // 
            // gbRaza
            // 
            gbRaza.BackColor = Color.White;
            gbRaza.Controls.Add(txtBuscar);
            gbRaza.Controls.Add(label4);
            gbRaza.Controls.Add(groupBox2);
            gbRaza.Controls.Add(groupBox1);
            gbRaza.Controls.Add(cbProvincias);
            gbRaza.Controls.Add(label3);
            gbRaza.Controls.Add(txtZona);
            gbRaza.Controls.Add(lblZona);
            gbRaza.Controls.Add(txtCodeZona);
            gbRaza.Controls.Add(lblCode);
            gbRaza.Font = new Font("Microsoft Sans Serif", 9.75F);
            gbRaza.Location = new Point(12, 40);
            gbRaza.Name = "gbRaza";
            gbRaza.Size = new Size(905, 414);
            gbRaza.TabIndex = 0;
            gbRaza.TabStop = false;
            gbRaza.Text = "Datos de Zonas";
            // 
            // txtBuscar
            // 
            txtBuscar.Enabled = false;
            txtBuscar.Font = new Font("Microsoft Sans Serif", 9.75F);
            txtBuscar.Location = new Point(148, 374);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(643, 22);
            txtBuscar.TabIndex = 11;
            txtBuscar.KeyPress += txtBuscar_KeyPress;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 10F);
            label4.Location = new Point(41, 377);
            label4.Name = "label4";
            label4.Size = new Size(52, 17);
            label4.TabIndex = 10;
            label4.Text = "Buscar";
            label4.Click += label4_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(rbtnInactive);
            groupBox2.Controls.Add(rbtnActive);
            groupBox2.Location = new Point(422, 76);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(332, 114);
            groupBox2.TabIndex = 8;
            groupBox2.TabStop = false;
            groupBox2.Text = "Estado";
            // 
            // rbtnInactive
            // 
            rbtnInactive.AutoSize = true;
            rbtnInactive.Location = new Point(25, 69);
            rbtnInactive.Name = "rbtnInactive";
            rbtnInactive.Size = new Size(71, 20);
            rbtnInactive.TabIndex = 1;
            rbtnInactive.TabStop = true;
            rbtnInactive.Text = "Inactivo";
            rbtnInactive.UseVisualStyleBackColor = true;
            rbtnInactive.CheckedChanged += tbtnInactive_CheckedChanged;
            // 
            // rbtnActive
            // 
            rbtnActive.AutoSize = true;
            rbtnActive.Location = new Point(25, 21);
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
            // cbProvincias
            // 
            cbProvincias.DropDownStyle = ComboBoxStyle.DropDownList;
            cbProvincias.Font = new Font("Microsoft Sans Serif", 9.75F);
            cbProvincias.FormattingEnabled = true;
            cbProvincias.Location = new Point(41, 213);
            cbProvincias.Name = "cbProvincias";
            cbProvincias.Size = new Size(289, 24);
            cbProvincias.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 10F);
            label3.Location = new Point(41, 184);
            label3.Name = "label3";
            label3.Size = new Size(66, 17);
            label3.TabIndex = 4;
            label3.Text = "Provincia";
            // 
            // txtZona
            // 
            txtZona.Font = new Font("Microsoft Sans Serif", 9.75F);
            txtZona.Location = new Point(41, 145);
            txtZona.Name = "txtZona";
            txtZona.Size = new Size(289, 22);
            txtZona.TabIndex = 3;
            // 
            // lblZona
            // 
            lblZona.AutoSize = true;
            lblZona.Font = new Font("Microsoft Sans Serif", 10F);
            lblZona.Location = new Point(41, 117);
            lblZona.Name = "lblZona";
            lblZona.Size = new Size(41, 17);
            lblZona.TabIndex = 2;
            lblZona.Text = "Zona";
            // 
            // txtCodeZona
            // 
            txtCodeZona.Enabled = false;
            txtCodeZona.Font = new Font("Microsoft Sans Serif", 9.75F);
            txtCodeZona.Location = new Point(41, 76);
            txtCodeZona.Name = "txtCodeZona";
            txtCodeZona.Size = new Size(292, 22);
            txtCodeZona.TabIndex = 1;
            // 
            // lblCode
            // 
            lblCode.AutoSize = true;
            lblCode.Font = new Font("Microsoft Sans Serif", 10F);
            lblCode.Location = new Point(41, 38);
            lblCode.Name = "lblCode";
            lblCode.Size = new Size(89, 17);
            lblCode.TabIndex = 0;
            lblCode.Text = "Código Zona";
            // 
            // gvZonas
            // 
            gvZonas.AllowUserToAddRows = false;
            gvZonas.AllowUserToDeleteRows = false;
            gvZonas.AllowUserToOrderColumns = true;
            gvZonas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gvZonas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gvZonas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gvZonas.Location = new Point(12, 475);
            gvZonas.Name = "gvZonas";
            gvZonas.Size = new Size(974, 211);
            gvZonas.TabIndex = 1;
            gvZonas.CellContentClick += gvZonas_CellContentClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 15F);
            label1.ForeColor = SystemColors.GrayText;
            label1.Location = new Point(416, 9);
            label1.Name = "label1";
            label1.Size = new Size(137, 25);
            label1.TabIndex = 2;
            label1.Text = "Modulo Zonas";
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
            label2.TabIndex = 1;
            label2.Text = "X";
            label2.Click += label2_Click;
            // 
            // Zonas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1103, 729);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(gvZonas);
            Controls.Add(gbRaza);
            Name = "Zonas";
            Text = "Zonas";
            Load += Zonas_Load;
            gbRaza.ResumeLayout(false);
            gbRaza.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gvZonas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox gbRaza;
        private ComboBox cbProvincias;
        private Label label3;
        private TextBox txtZona;
        private Label lblZona;
        private TextBox txtCodeZona;
        private Label lblCode;
        private GroupBox groupBox1;
        private Button btnNew;
        private DataGridView gvZonas;
        private Button btnDelete;
        private Button btnAdd;
        private Button btnModify;
        private GroupBox groupBox2;
        private RadioButton rbtnInactive;
        private RadioButton rbtnActive;
        private Label label1;
        internal Label label2;
        private Button button1;
        private TextBox txtBuscar;
        private Label label4;
    }
}