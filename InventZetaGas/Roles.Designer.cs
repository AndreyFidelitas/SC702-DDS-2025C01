namespace InventZetaGas
{
    partial class Roles
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Roles));
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
            txtRol = new TextBox();
            lblRol = new Label();
            txtCodeRol = new TextBox();
            lblCode = new Label();
            gvRoles = new DataGridView();
            label2 = new Label();
            gbRaza.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gvRoles).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 15F);
            label1.ForeColor = SystemColors.GrayText;
            label1.Location = new Point(442, 9);
            label1.Name = "label1";
            label1.Size = new Size(131, 25);
            label1.TabIndex = 4;
            label1.Text = "Modulo Roles";
            // 
            // gbRaza
            // 
            gbRaza.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            gbRaza.BackColor = Color.White;
            gbRaza.Controls.Add(groupBox2);
            gbRaza.Controls.Add(groupBox1);
            gbRaza.Controls.Add(txtRol);
            gbRaza.Controls.Add(lblRol);
            gbRaza.Controls.Add(txtCodeRol);
            gbRaza.Controls.Add(lblCode);
            gbRaza.Font = new Font("Microsoft Sans Serif", 9.75F);
            gbRaza.Location = new Point(22, 48);
            gbRaza.Name = "gbRaza";
            gbRaza.Size = new Size(874, 392);
            gbRaza.TabIndex = 5;
            gbRaza.TabStop = false;
            gbRaza.Text = "Datos de Zonas";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(rbtnInactive);
            groupBox2.Controls.Add(rbtnActive);
            groupBox2.Location = new Point(393, 38);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(245, 129);
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
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(btnDelete);
            groupBox1.Controls.Add(btnAdd);
            groupBox1.Controls.Add(btnModify);
            groupBox1.Controls.Add(btnNew);
            groupBox1.Location = new Point(15, 298);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(760, 77);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            // 
            // btnDelete
            // 
            btnDelete.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            btnDelete.Image = (Image)resources.GetObject("btnDelete.Image");
            btnDelete.ImageAlign = ContentAlignment.MiddleLeft;
            btnDelete.Location = new Point(480, 21);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(143, 43);
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
            btnAdd.Location = new Point(160, 21);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(137, 43);
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
            btnModify.Location = new Point(307, 21);
            btnModify.Name = "btnModify";
            btnModify.Size = new Size(158, 43);
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
            btnNew.Location = new Point(18, 21);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(124, 43);
            btnNew.TabIndex = 0;
            btnNew.Text = "Nuevo";
            btnNew.UseVisualStyleBackColor = true;
            btnNew.Click += btnNew_Click;
            // 
            // txtRol
            // 
            txtRol.Font = new Font("Microsoft Sans Serif", 9.75F);
            txtRol.Location = new Point(41, 145);
            txtRol.Name = "txtRol";
            txtRol.Size = new Size(289, 22);
            txtRol.TabIndex = 3;
            // 
            // lblRol
            // 
            lblRol.AutoSize = true;
            lblRol.Font = new Font("Microsoft Sans Serif", 10F);
            lblRol.Location = new Point(41, 117);
            lblRol.Name = "lblRol";
            lblRol.Size = new Size(29, 17);
            lblRol.TabIndex = 2;
            lblRol.Text = "Rol";
            // 
            // txtCodeRol
            // 
            txtCodeRol.Enabled = false;
            txtCodeRol.Font = new Font("Microsoft Sans Serif", 9.75F);
            txtCodeRol.Location = new Point(41, 76);
            txtCodeRol.Name = "txtCodeRol";
            txtCodeRol.Size = new Size(292, 22);
            txtCodeRol.TabIndex = 1;
            // 
            // lblCode
            // 
            lblCode.AutoSize = true;
            lblCode.Font = new Font("Microsoft Sans Serif", 10F);
            lblCode.Location = new Point(41, 38);
            lblCode.Name = "lblCode";
            lblCode.Size = new Size(77, 17);
            lblCode.TabIndex = 0;
            lblCode.Text = "Codigo Rol";
            // 
            // gvRoles
            // 
            gvRoles.AllowUserToAddRows = false;
            gvRoles.AllowUserToDeleteRows = false;
            gvRoles.AllowUserToOrderColumns = true;
            gvRoles.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gvRoles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gvRoles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gvRoles.Location = new Point(22, 455);
            gvRoles.Name = "gvRoles";
            gvRoles.Size = new Size(905, 244);
            gvRoles.TabIndex = 6;
            gvRoles.CellContentClick += gvRoles_CellContentClick;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Cursor = Cursors.Hand;
            label2.Font = new Font("Microsoft Sans Serif", 12F);
            label2.ForeColor = Color.DimGray;
            label2.Location = new Point(22, 9);
            label2.Name = "label2";
            label2.Padding = new Padding(3, 0, 3, 0);
            label2.Size = new Size(26, 20);
            label2.TabIndex = 7;
            label2.Text = "X";
            label2.Click += label2_Click;
            // 
            // Roles
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1103, 729);
            Controls.Add(label2);
            Controls.Add(gvRoles);
            Controls.Add(gbRaza);
            Controls.Add(label1);
            Name = "Roles";
            Text = "Roles";
            Load += Roles_Load;
            gbRaza.ResumeLayout(false);
            gbRaza.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gvRoles).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

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
        private TextBox txtRol;
        private Label lblRol;
        private TextBox txtCodeRol;
        private Label lblCode;
        private DataGridView gvRoles;
        internal Label label2;
    }
}