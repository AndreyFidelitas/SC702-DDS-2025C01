namespace InventZetaGas
{
    partial class TipoCilindro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TipoCilindro));
            label2 = new Label();
            gvCilindros = new DataGridView();
            gbRaza = new GroupBox();
            groupBox2 = new GroupBox();
            rbtnInactive = new RadioButton();
            rbtnActive = new RadioButton();
            groupBox1 = new GroupBox();
            btnDelete = new Button();
            btnAdd = new Button();
            btnModify = new Button();
            btnNew = new Button();
            txtCilindro = new TextBox();
            lblLoteLitraje = new Label();
            txtCodeCilindro = new TextBox();
            lblTipoCilindroCode = new Label();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)gvCilindros).BeginInit();
            gbRaza.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
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
            label2.TabIndex = 11;
            label2.Text = "X";
            label2.Click += label2_Click;
            // 
            // gvCilindros
            // 
            gvCilindros.AllowUserToAddRows = false;
            gvCilindros.AllowUserToDeleteRows = false;
            gvCilindros.AllowUserToOrderColumns = true;
            gvCilindros.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gvCilindros.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gvCilindros.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gvCilindros.Location = new Point(24, 593);
            gvCilindros.Margin = new Padding(3, 4, 3, 4);
            gvCilindros.MultiSelect = false;
            gvCilindros.Name = "gvCilindros";
            gvCilindros.RowHeadersVisible = false;
            gvCilindros.RowHeadersWidth = 51;
            gvCilindros.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gvCilindros.Size = new Size(999, 325);
            gvCilindros.TabIndex = 10;
            gvCilindros.CellClick += gvCilindros_CellClick;
            gvCilindros.CellContentClick += gvCilindros_CellContentClick;
            gvCilindros.DataBindingComplete += gvCilindros_DataBindingComplete;
            // 
            // gbRaza
            // 
            gbRaza.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            gbRaza.BackColor = Color.White;
            gbRaza.Controls.Add(groupBox2);
            gbRaza.Controls.Add(groupBox1);
            gbRaza.Controls.Add(txtCilindro);
            gbRaza.Controls.Add(lblLoteLitraje);
            gbRaza.Controls.Add(txtCodeCilindro);
            gbRaza.Controls.Add(lblTipoCilindroCode);
            gbRaza.Font = new Font("Microsoft Sans Serif", 9.75F);
            gbRaza.Location = new Point(24, 63);
            gbRaza.Margin = new Padding(3, 4, 3, 4);
            gbRaza.Name = "gbRaza";
            gbRaza.Padding = new Padding(3, 4, 3, 4);
            gbRaza.Size = new Size(999, 523);
            gbRaza.TabIndex = 9;
            gbRaza.TabStop = false;
            gbRaza.Text = "Datos de Cilindros";
            gbRaza.Enter += gbRaza_Enter;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(rbtnInactive);
            groupBox2.Controls.Add(rbtnActive);
            groupBox2.Location = new Point(449, 51);
            groupBox2.Margin = new Padding(3, 4, 3, 4);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(3, 4, 3, 4);
            groupBox2.Size = new Size(280, 172);
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
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(btnDelete);
            groupBox1.Controls.Add(btnAdd);
            groupBox1.Controls.Add(btnModify);
            groupBox1.Controls.Add(btnNew);
            groupBox1.Location = new Point(17, 397);
            groupBox1.Margin = new Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 4, 3, 4);
            groupBox1.Size = new Size(962, 103);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            // 
            // btnDelete
            // 
            btnDelete.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            btnDelete.Image = (Image)resources.GetObject("btnDelete.Image");
            btnDelete.ImageAlign = ContentAlignment.MiddleLeft;
            btnDelete.Location = new Point(549, 28);
            btnDelete.Margin = new Padding(3, 4, 3, 4);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(163, 67);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "Eliminar";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnAdd
            // 
            btnAdd.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            btnAdd.Image = (Image)resources.GetObject("btnAdd.Image");
            btnAdd.ImageAlign = ContentAlignment.MiddleLeft;
            btnAdd.Location = new Point(187, 28);
            btnAdd.Margin = new Padding(3, 4, 3, 4);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(157, 67);
            btnAdd.TabIndex = 2;
            btnAdd.Text = "Agregar";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnModify
            // 
            btnModify.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            btnModify.Image = (Image)resources.GetObject("btnModify.Image");
            btnModify.ImageAlign = ContentAlignment.MiddleLeft;
            btnModify.Location = new Point(351, 28);
            btnModify.Margin = new Padding(3, 4, 3, 4);
            btnModify.Name = "btnModify";
            btnModify.Size = new Size(181, 67);
            btnModify.TabIndex = 1;
            btnModify.Text = "Modificar";
            btnModify.UseVisualStyleBackColor = true;
            btnModify.Click += btnModify_Click;
            // 
            // btnNew
            // 
            btnNew.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            btnNew.Image = (Image)resources.GetObject("btnNew.Image");
            btnNew.ImageAlign = ContentAlignment.MiddleLeft;
            btnNew.Location = new Point(18, 28);
            btnNew.Margin = new Padding(3, 4, 3, 4);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(142, 67);
            btnNew.TabIndex = 0;
            btnNew.Text = "Nuevo";
            btnNew.UseVisualStyleBackColor = true;
            btnNew.Click += btnNew_Click;
            // 
            // txtCilindro
            // 
            txtCilindro.Font = new Font("Microsoft Sans Serif", 9.75F);
            txtCilindro.Location = new Point(47, 193);
            txtCilindro.Margin = new Padding(3, 4, 3, 4);
            txtCilindro.Name = "txtCilindro";
            txtCilindro.Size = new Size(330, 26);
            txtCilindro.TabIndex = 3;
            // 
            // lblLoteLitraje
            // 
            lblLoteLitraje.AutoSize = true;
            lblLoteLitraje.Font = new Font("Microsoft Sans Serif", 10F);
            lblLoteLitraje.Location = new Point(47, 156);
            lblLoteLitraje.Name = "lblLoteLitraje";
            lblLoteLitraje.Size = new Size(93, 20);
            lblLoteLitraje.TabIndex = 2;
            lblLoteLitraje.Text = "Tipo Litraje";
            // 
            // txtCodeCilindro
            // 
            txtCodeCilindro.Enabled = false;
            txtCodeCilindro.Font = new Font("Microsoft Sans Serif", 9.75F);
            txtCodeCilindro.Location = new Point(47, 101);
            txtCodeCilindro.Margin = new Padding(3, 4, 3, 4);
            txtCodeCilindro.Name = "txtCodeCilindro";
            txtCodeCilindro.Size = new Size(333, 26);
            txtCodeCilindro.TabIndex = 1;
            // 
            // lblTipoCilindroCode
            // 
            lblTipoCilindroCode.AutoSize = true;
            lblTipoCilindroCode.Font = new Font("Microsoft Sans Serif", 10F);
            lblTipoCilindroCode.Location = new Point(47, 51);
            lblTipoCilindroCode.Name = "lblTipoCilindroCode";
            lblTipoCilindroCode.Size = new Size(123, 20);
            lblTipoCilindroCode.TabIndex = 0;
            lblTipoCilindroCode.Text = "Código Cilindro";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 15F);
            label1.ForeColor = SystemColors.GrayText;
            label1.Location = new Point(491, 12);
            label1.Name = "label1";
            label1.Size = new Size(293, 29);
            label1.TabIndex = 8;
            label1.Text = "Módulo Tipos de Cilindro";
            label1.Click += label1_Click;
            // 
            // TipoCilindro
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1261, 972);
            Controls.Add(label2);
            Controls.Add(gvCilindros);
            Controls.Add(gbRaza);
            Controls.Add(label1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "TipoCilindro";
            Text = "TipoCilindro";
            Load += TipoCilindro_Load;
            ((System.ComponentModel.ISupportInitialize)gvCilindros).EndInit();
            gbRaza.ResumeLayout(false);
            gbRaza.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        internal Label label2;
        private DataGridView gvCilindros;
        private GroupBox gbRaza;
        private GroupBox groupBox2;
        private RadioButton rbtnInactive;
        private RadioButton rbtnActive;
        private TextBox txtCilindro;
        private Label lblLoteLitraje;
        private TextBox txtCodeCilindro;
        private Label lblTipoCilindroCode;
        private Label label1;
        private GroupBox groupBox1;
        private Button btnDelete;
        private Button btnAdd;
        private Button btnModify;
        private Button btnNew;
    }
}