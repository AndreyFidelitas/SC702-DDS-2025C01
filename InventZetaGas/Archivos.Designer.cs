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
            gvCamiones = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)gvCamiones).BeginInit();
            SuspendLayout();
            // 
            // gvCamiones
            // 
            gvCamiones.AllowUserToAddRows = false;
            gvCamiones.AllowUserToDeleteRows = false;
            gvCamiones.AllowUserToOrderColumns = true;
            gvCamiones.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            gvCamiones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gvCamiones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gvCamiones.Location = new Point(21, 475);
            gvCamiones.Name = "gvCamiones";
            gvCamiones.Size = new Size(887, 211);
            gvCamiones.TabIndex = 6;
            // 
            // Archivos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1103, 729);
            Controls.Add(gvCamiones);
            Name = "Archivos";
            Text = "Archivos";
            ((System.ComponentModel.ISupportInitialize)gvCamiones).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView gvCamiones;
    }
}