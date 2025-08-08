namespace InventZetaGas
{
    partial class Archivos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Archivos));
            dgvExcel = new DataGridView();
            fdArchivo = new OpenFileDialog();
            gbRaza = new GroupBox();
            groupBox1 = new GroupBox();
            btnGuardarLotes = new Button();
            btnModify = new Button();
            txtarchivo = new TextBox();
            lblCode = new Label();
            txtCantidad = new TextBox();
            label1 = new Label();
            progressBar1 = new ProgressBar();
            ((System.ComponentModel.ISupportInitialize)dgvExcel).BeginInit();
            gbRaza.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvExcel
            // 
            dgvExcel.AllowUserToAddRows = false;
            dgvExcel.AllowUserToDeleteRows = false;
            dgvExcel.AllowUserToOrderColumns = true;
            dgvExcel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            dgvExcel.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvExcel.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvExcel.Location = new Point(28, 365);
            dgvExcel.Name = "dgvExcel";
            dgvExcel.Size = new Size(887, 213);
            dgvExcel.TabIndex = 6;
            // 
            // fdArchivo
            // 
            fdArchivo.FileName = "openFileDialog1";
            // 
            // gbRaza
            // 
            gbRaza.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            gbRaza.BackColor = Color.White;
            gbRaza.Controls.Add(groupBox1);
            gbRaza.Controls.Add(btnModify);
            gbRaza.Controls.Add(txtarchivo);
            gbRaza.Controls.Add(lblCode);
            gbRaza.Font = new Font("Microsoft Sans Serif", 9.75F);
            gbRaza.Location = new Point(28, 23);
            gbRaza.Name = "gbRaza";
            gbRaza.Size = new Size(887, 303);
            gbRaza.TabIndex = 7;
            gbRaza.TabStop = false;
            gbRaza.Text = "Datos de Archivos";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnGuardarLotes);
            groupBox1.Location = new Point(19, 202);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(493, 77);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            // 
            // btnGuardarLotes
            // 
            btnGuardarLotes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            btnGuardarLotes.ImageAlign = ContentAlignment.MiddleLeft;
            btnGuardarLotes.Location = new Point(22, 17);
            btnGuardarLotes.Name = "btnGuardarLotes";
            btnGuardarLotes.Size = new Size(143, 41);
            btnGuardarLotes.TabIndex = 10;
            btnGuardarLotes.Text = "Guardar Lotes";
            btnGuardarLotes.UseVisualStyleBackColor = true;
            btnGuardarLotes.Click += btnGuardarLotes_Click;
            // 
            // btnModify
            // 
            btnModify.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            btnModify.Image = (Image)resources.GetObject("btnModify.Image");
            btnModify.ImageAlign = ContentAlignment.MiddleLeft;
            btnModify.Location = new Point(369, 66);
            btnModify.Name = "btnModify";
            btnModify.Size = new Size(143, 41);
            btnModify.TabIndex = 1;
            btnModify.Text = "Abrir";
            btnModify.UseVisualStyleBackColor = true;
            btnModify.Click += btnModify_Click;
            // 
            // txtarchivo
            // 
            txtarchivo.Enabled = false;
            txtarchivo.Font = new Font("Microsoft Sans Serif", 9.75F);
            txtarchivo.Location = new Point(41, 76);
            txtarchivo.Name = "txtarchivo";
            txtarchivo.Size = new Size(303, 22);
            txtarchivo.TabIndex = 1;
            // 
            // lblCode
            // 
            lblCode.AutoSize = true;
            lblCode.Font = new Font("Microsoft Sans Serif", 10F);
            lblCode.Location = new Point(41, 38);
            lblCode.Name = "lblCode";
            lblCode.Size = new Size(80, 17);
            lblCode.TabIndex = 0;
            lblCode.Text = "Documento";
            // 
            // txtCantidad
            // 
            txtCantidad.Enabled = false;
            txtCantidad.Font = new Font("Microsoft Sans Serif", 9.75F);
            txtCantidad.Location = new Point(28, 656);
            txtCantidad.Name = "txtCantidad";
            txtCantidad.Size = new Size(303, 22);
            txtCantidad.TabIndex = 8;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 10F);
            label1.Location = new Point(28, 610);
            label1.Name = "label1";
            label1.Size = new Size(104, 17);
            label1.TabIndex = 9;
            label1.Text = "Total Registros";
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(348, 655);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(567, 23);
            progressBar1.TabIndex = 10;
            // 
            // Archivos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1103, 729);
            Controls.Add(progressBar1);
            Controls.Add(label1);
            Controls.Add(txtCantidad);
            Controls.Add(gbRaza);
            Controls.Add(dgvExcel);
            Name = "Archivos";
            Text = "Archivos";
            Load += Archivos_Load;
            ((System.ComponentModel.ISupportInitialize)dgvExcel).EndInit();
            gbRaza.ResumeLayout(false);
            gbRaza.PerformLayout();
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvExcel;
        private OpenFileDialog fdArchivo;
        private GroupBox gbRaza;
        private GroupBox groupBox1;
        private Button btnModify;
        private TextBox txtarchivo;
        private Label lblCode;
        private TextBox txtCantidad;
        private Label label1;
        private Button btnGuardarLotes;
        private ProgressBar progressBar1;
    }
}