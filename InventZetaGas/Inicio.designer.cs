namespace PlayerUI
{
    partial class Inicio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inicio));
            panelSideMenu = new Panel();
            btnExit = new Button();
            btnHelp = new Button();
            panelToolsSubMenu = new Panel();
            button10 = new Button();
            button12 = new Button();
            button13 = new Button();
            btnTools = new Button();
            panelPlaylistSubMenu = new Panel();
            button1 = new Button();
            button6 = new Button();
            btncamiones = new Button();
            button8 = new Button();
            btnPlaylist = new Button();
            panelMediaSubMenu = new Panel();
            button4 = new Button();
            button3 = new Button();
            button2 = new Button();
            btnMedia = new Button();
            panelLogo = new Panel();
            pictureBox1 = new PictureBox();
            panelPlayer = new Panel();
            panelChildForm = new Panel();
            pictureBox9 = new PictureBox();
            panelSideMenu.SuspendLayout();
            panelToolsSubMenu.SuspendLayout();
            panelPlaylistSubMenu.SuspendLayout();
            panelMediaSubMenu.SuspendLayout();
            panelLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panelChildForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox9).BeginInit();
            SuspendLayout();
            // 
            // panelSideMenu
            // 
            panelSideMenu.AutoScroll = true;
            panelSideMenu.BackColor = Color.FromArgb(11, 7, 17);
            panelSideMenu.Controls.Add(btnExit);
            panelSideMenu.Controls.Add(btnHelp);
            panelSideMenu.Controls.Add(panelToolsSubMenu);
            panelSideMenu.Controls.Add(btnTools);
            panelSideMenu.Controls.Add(panelPlaylistSubMenu);
            panelSideMenu.Controls.Add(btnPlaylist);
            panelSideMenu.Controls.Add(panelMediaSubMenu);
            panelSideMenu.Controls.Add(btnMedia);
            panelSideMenu.Controls.Add(panelLogo);
            panelSideMenu.Dock = DockStyle.Left;
            panelSideMenu.Location = new Point(0, 0);
            panelSideMenu.Name = "panelSideMenu";
            panelSideMenu.Size = new Size(250, 701);
            panelSideMenu.TabIndex = 0;
            // 
            // btnExit
            // 
            btnExit.BackColor = Color.FromArgb(26, 26, 26);
            btnExit.Dock = DockStyle.Bottom;
            btnExit.FlatAppearance.BorderSize = 0;
            btnExit.FlatAppearance.MouseDownBackColor = Color.FromArgb(23, 21, 32);
            btnExit.FlatAppearance.MouseOverBackColor = Color.FromArgb(24, 22, 34);
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.ForeColor = Color.White;
            btnExit.Image = (Image)resources.GetObject("btnExit.Image");
            btnExit.ImageAlign = ContentAlignment.MiddleLeft;
            btnExit.Location = new Point(0, 670);
            btnExit.Name = "btnExit";
            btnExit.Padding = new Padding(5, 0, 0, 0);
            btnExit.Size = new Size(233, 45);
            btnExit.TabIndex = 9;
            btnExit.Text = "  Exit";
            btnExit.TextAlign = ContentAlignment.MiddleLeft;
            btnExit.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += btnExit_Click;
            // 
            // btnHelp
            // 
            btnHelp.BackColor = Color.FromArgb(1, 38, 90);
            btnHelp.Dock = DockStyle.Top;
            btnHelp.FlatAppearance.BorderSize = 0;
            btnHelp.FlatAppearance.MouseDownBackColor = Color.FromArgb(23, 21, 32);
            btnHelp.FlatAppearance.MouseOverBackColor = Color.FromArgb(24, 22, 34);
            btnHelp.FlatStyle = FlatStyle.Flat;
            btnHelp.ForeColor = Color.White;
            btnHelp.Image = (Image)resources.GetObject("btnHelp.Image");
            btnHelp.ImageAlign = ContentAlignment.MiddleLeft;
            btnHelp.Location = new Point(0, 637);
            btnHelp.Name = "btnHelp";
            btnHelp.Padding = new Padding(5, 0, 0, 0);
            btnHelp.Size = new Size(233, 33);
            btnHelp.TabIndex = 8;
            btnHelp.Text = "  Help";
            btnHelp.TextAlign = ContentAlignment.MiddleLeft;
            btnHelp.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnHelp.UseVisualStyleBackColor = false;
            btnHelp.Click += btnHelp_Click;
            // 
            // panelToolsSubMenu
            // 
            panelToolsSubMenu.BackColor = Color.FromArgb(35, 32, 39);
            panelToolsSubMenu.Controls.Add(button10);
            panelToolsSubMenu.Controls.Add(button12);
            panelToolsSubMenu.Controls.Add(button13);
            panelToolsSubMenu.Dock = DockStyle.Top;
            panelToolsSubMenu.Location = new Point(0, 507);
            panelToolsSubMenu.Name = "panelToolsSubMenu";
            panelToolsSubMenu.Size = new Size(233, 130);
            panelToolsSubMenu.TabIndex = 7;
            // 
            // button10
            // 
            button10.BackColor = Color.FromArgb(26, 26, 26);
            button10.Dock = DockStyle.Top;
            button10.FlatAppearance.BorderSize = 0;
            button10.FlatAppearance.MouseDownBackColor = Color.FromArgb(42, 38, 46);
            button10.FlatAppearance.MouseOverBackColor = Color.FromArgb(42, 38, 46);
            button10.FlatStyle = FlatStyle.Flat;
            button10.ForeColor = Color.White;
            button10.Location = new Point(0, 80);
            button10.Name = "button10";
            button10.Padding = new Padding(35, 0, 0, 0);
            button10.Size = new Size(233, 47);
            button10.TabIndex = 2;
            button10.Text = "Preferences";
            button10.TextAlign = ContentAlignment.MiddleLeft;
            button10.UseVisualStyleBackColor = false;
            button10.Visible = false;
            button10.Click += button10_Click;
            // 
            // button12
            // 
            button12.BackColor = Color.FromArgb(26, 26, 26);
            button12.Dock = DockStyle.Top;
            button12.FlatAppearance.BorderSize = 0;
            button12.FlatAppearance.MouseDownBackColor = Color.FromArgb(42, 38, 46);
            button12.FlatAppearance.MouseOverBackColor = Color.FromArgb(42, 38, 46);
            button12.FlatStyle = FlatStyle.Flat;
            button12.ForeColor = Color.White;
            button12.Location = new Point(0, 40);
            button12.Name = "button12";
            button12.Padding = new Padding(35, 0, 0, 0);
            button12.Size = new Size(233, 40);
            button12.TabIndex = 1;
            button12.Text = "Clientes";
            button12.TextAlign = ContentAlignment.MiddleLeft;
            button12.UseVisualStyleBackColor = false;
            button12.Click += button12_Click;
            // 
            // button13
            // 
            button13.BackColor = Color.FromArgb(26, 26, 26);
            button13.Dock = DockStyle.Top;
            button13.FlatAppearance.BorderSize = 0;
            button13.FlatAppearance.MouseDownBackColor = Color.FromArgb(42, 38, 46);
            button13.FlatAppearance.MouseOverBackColor = Color.FromArgb(42, 38, 46);
            button13.FlatStyle = FlatStyle.Flat;
            button13.ForeColor = Color.White;
            button13.Location = new Point(0, 0);
            button13.Name = "button13";
            button13.Padding = new Padding(35, 0, 0, 0);
            button13.Size = new Size(233, 40);
            button13.TabIndex = 0;
            button13.Text = " Reporte Inventarios";
            button13.TextAlign = ContentAlignment.MiddleLeft;
            button13.UseVisualStyleBackColor = false;
            button13.Click += button13_Click;
            // 
            // btnTools
            // 
            btnTools.BackColor = Color.FromArgb(1, 38, 90);
            btnTools.Dock = DockStyle.Top;
            btnTools.FlatAppearance.BorderSize = 0;
            btnTools.FlatAppearance.MouseDownBackColor = Color.FromArgb(23, 21, 32);
            btnTools.FlatAppearance.MouseOverBackColor = Color.FromArgb(24, 22, 34);
            btnTools.FlatStyle = FlatStyle.Flat;
            btnTools.ForeColor = Color.White;
            btnTools.Image = (Image)resources.GetObject("btnTools.Image");
            btnTools.ImageAlign = ContentAlignment.MiddleLeft;
            btnTools.Location = new Point(0, 468);
            btnTools.Name = "btnTools";
            btnTools.Padding = new Padding(5, 0, 0, 0);
            btnTools.Size = new Size(233, 39);
            btnTools.TabIndex = 6;
            btnTools.Text = "  Inventarios";
            btnTools.TextAlign = ContentAlignment.MiddleLeft;
            btnTools.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnTools.UseVisualStyleBackColor = false;
            btnTools.Click += btnTools_Click;
            // 
            // panelPlaylistSubMenu
            // 
            panelPlaylistSubMenu.BackColor = Color.FromArgb(35, 32, 39);
            panelPlaylistSubMenu.Controls.Add(button1);
            panelPlaylistSubMenu.Controls.Add(button6);
            panelPlaylistSubMenu.Controls.Add(btncamiones);
            panelPlaylistSubMenu.Controls.Add(button8);
            panelPlaylistSubMenu.Dock = DockStyle.Top;
            panelPlaylistSubMenu.Location = new Point(0, 303);
            panelPlaylistSubMenu.Name = "panelPlaylistSubMenu";
            panelPlaylistSubMenu.Size = new Size(233, 165);
            panelPlaylistSubMenu.TabIndex = 4;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(26, 26, 26);
            button1.Dock = DockStyle.Top;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatAppearance.MouseDownBackColor = Color.FromArgb(42, 38, 46);
            button1.FlatAppearance.MouseOverBackColor = Color.FromArgb(42, 38, 46);
            button1.FlatStyle = FlatStyle.Flat;
            button1.ForeColor = Color.White;
            button1.Location = new Point(0, 120);
            button1.Name = "button1";
            button1.Padding = new Padding(35, 0, 0, 0);
            button1.Size = new Size(233, 40);
            button1.TabIndex = 3;
            button1.Text = "Rutas";
            button1.TextAlign = ContentAlignment.MiddleLeft;
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button6
            // 
            button6.BackColor = Color.FromArgb(26, 26, 26);
            button6.Dock = DockStyle.Top;
            button6.FlatAppearance.BorderSize = 0;
            button6.FlatAppearance.MouseDownBackColor = Color.FromArgb(42, 38, 46);
            button6.FlatAppearance.MouseOverBackColor = Color.FromArgb(42, 38, 46);
            button6.FlatStyle = FlatStyle.Flat;
            button6.ForeColor = Color.White;
            button6.Location = new Point(0, 80);
            button6.Name = "button6";
            button6.Padding = new Padding(35, 0, 0, 0);
            button6.Size = new Size(233, 40);
            button6.TabIndex = 2;
            button6.Text = "Cilindros";
            button6.TextAlign = ContentAlignment.MiddleLeft;
            button6.UseVisualStyleBackColor = false;
            button6.Click += button6_Click;
            // 
            // btncamiones
            // 
            btncamiones.BackColor = Color.FromArgb(26, 26, 26);
            btncamiones.Dock = DockStyle.Top;
            btncamiones.FlatAppearance.BorderSize = 0;
            btncamiones.FlatAppearance.MouseDownBackColor = Color.FromArgb(42, 38, 46);
            btncamiones.FlatAppearance.MouseOverBackColor = Color.FromArgb(42, 38, 46);
            btncamiones.FlatStyle = FlatStyle.Flat;
            btncamiones.ForeColor = Color.White;
            btncamiones.Location = new Point(0, 40);
            btncamiones.Name = "btncamiones";
            btncamiones.Padding = new Padding(35, 0, 0, 0);
            btncamiones.Size = new Size(233, 40);
            btncamiones.TabIndex = 1;
            btncamiones.Text = "Camiones";
            btncamiones.TextAlign = ContentAlignment.MiddleLeft;
            btncamiones.UseVisualStyleBackColor = false;
            btncamiones.Click += button7_Click;
            // 
            // button8
            // 
            button8.BackColor = Color.FromArgb(26, 26, 26);
            button8.Dock = DockStyle.Top;
            button8.FlatAppearance.BorderSize = 0;
            button8.FlatAppearance.MouseDownBackColor = Color.FromArgb(42, 38, 46);
            button8.FlatAppearance.MouseOverBackColor = Color.FromArgb(42, 38, 46);
            button8.FlatStyle = FlatStyle.Flat;
            button8.ForeColor = Color.White;
            button8.Location = new Point(0, 0);
            button8.Name = "button8";
            button8.Padding = new Padding(35, 0, 0, 0);
            button8.Size = new Size(233, 40);
            button8.TabIndex = 0;
            button8.Text = "Zonas";
            button8.TextAlign = ContentAlignment.MiddleLeft;
            button8.UseVisualStyleBackColor = false;
            button8.Click += button8_Click;
            // 
            // btnPlaylist
            // 
            btnPlaylist.BackColor = Color.FromArgb(1, 38, 90);
            btnPlaylist.Dock = DockStyle.Top;
            btnPlaylist.FlatAppearance.BorderSize = 0;
            btnPlaylist.FlatAppearance.MouseDownBackColor = Color.FromArgb(23, 21, 32);
            btnPlaylist.FlatAppearance.MouseOverBackColor = Color.FromArgb(24, 22, 34);
            btnPlaylist.FlatStyle = FlatStyle.Flat;
            btnPlaylist.ForeColor = Color.White;
            btnPlaylist.Image = (Image)resources.GetObject("btnPlaylist.Image");
            btnPlaylist.ImageAlign = ContentAlignment.MiddleLeft;
            btnPlaylist.Location = new Point(0, 258);
            btnPlaylist.Name = "btnPlaylist";
            btnPlaylist.Padding = new Padding(5, 0, 0, 0);
            btnPlaylist.Size = new Size(233, 45);
            btnPlaylist.TabIndex = 3;
            btnPlaylist.Text = "  Gestion de Cilindros";
            btnPlaylist.TextAlign = ContentAlignment.MiddleLeft;
            btnPlaylist.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnPlaylist.UseVisualStyleBackColor = false;
            btnPlaylist.Click += btnPlaylist_Click;
            // 
            // panelMediaSubMenu
            // 
            panelMediaSubMenu.BackColor = Color.FromArgb(35, 32, 39);
            panelMediaSubMenu.Controls.Add(button4);
            panelMediaSubMenu.Controls.Add(button3);
            panelMediaSubMenu.Controls.Add(button2);
            panelMediaSubMenu.Dock = DockStyle.Top;
            panelMediaSubMenu.Location = new Point(0, 137);
            panelMediaSubMenu.Name = "panelMediaSubMenu";
            panelMediaSubMenu.Size = new Size(233, 121);
            panelMediaSubMenu.TabIndex = 2;
            // 
            // button4
            // 
            button4.BackColor = Color.FromArgb(26, 26, 26);
            button4.Dock = DockStyle.Top;
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatAppearance.MouseDownBackColor = Color.FromArgb(42, 38, 46);
            button4.FlatAppearance.MouseOverBackColor = Color.FromArgb(42, 38, 46);
            button4.FlatStyle = FlatStyle.Flat;
            button4.ForeColor = Color.White;
            button4.Location = new Point(0, 80);
            button4.Name = "button4";
            button4.Padding = new Padding(35, 0, 0, 0);
            button4.Size = new Size(233, 40);
            button4.TabIndex = 2;
            button4.Text = "Permisos";
            button4.TextAlign = ContentAlignment.MiddleLeft;
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(26, 26, 26);
            button3.Dock = DockStyle.Top;
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatAppearance.MouseDownBackColor = Color.FromArgb(42, 38, 46);
            button3.FlatAppearance.MouseOverBackColor = Color.FromArgb(42, 38, 46);
            button3.FlatStyle = FlatStyle.Flat;
            button3.ForeColor = Color.White;
            button3.Location = new Point(0, 40);
            button3.Name = "button3";
            button3.Padding = new Padding(35, 0, 0, 0);
            button3.Size = new Size(233, 40);
            button3.TabIndex = 1;
            button3.Text = "Usuarios";
            button3.TextAlign = ContentAlignment.MiddleLeft;
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(26, 26, 26);
            button2.Dock = DockStyle.Top;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatAppearance.MouseDownBackColor = Color.FromArgb(42, 38, 46);
            button2.FlatAppearance.MouseOverBackColor = Color.FromArgb(42, 38, 46);
            button2.FlatStyle = FlatStyle.Flat;
            button2.ForeColor = Color.White;
            button2.Location = new Point(0, 0);
            button2.Name = "button2";
            button2.Padding = new Padding(35, 0, 0, 0);
            button2.Size = new Size(233, 40);
            button2.TabIndex = 0;
            button2.Text = "Roles";
            button2.TextAlign = ContentAlignment.MiddleLeft;
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // btnMedia
            // 
            btnMedia.BackColor = Color.FromArgb(1, 38, 90);
            btnMedia.Dock = DockStyle.Top;
            btnMedia.FlatAppearance.BorderSize = 0;
            btnMedia.FlatAppearance.MouseDownBackColor = Color.FromArgb(23, 21, 32);
            btnMedia.FlatAppearance.MouseOverBackColor = Color.FromArgb(24, 22, 34);
            btnMedia.FlatStyle = FlatStyle.Flat;
            btnMedia.ForeColor = Color.White;
            btnMedia.Image = (Image)resources.GetObject("btnMedia.Image");
            btnMedia.ImageAlign = ContentAlignment.MiddleLeft;
            btnMedia.Location = new Point(0, 92);
            btnMedia.Name = "btnMedia";
            btnMedia.Padding = new Padding(5, 0, 0, 0);
            btnMedia.Size = new Size(233, 45);
            btnMedia.TabIndex = 1;
            btnMedia.Text = "  Administración";
            btnMedia.TextAlign = ContentAlignment.MiddleLeft;
            btnMedia.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnMedia.UseVisualStyleBackColor = false;
            btnMedia.Click += btnMedia_Click;
            // 
            // panelLogo
            // 
            panelLogo.BackColor = Color.FromArgb(1, 38, 90);
            panelLogo.Controls.Add(pictureBox1);
            panelLogo.Dock = DockStyle.Top;
            panelLogo.Location = new Point(0, 0);
            panelLogo.Name = "panelLogo";
            panelLogo.Size = new Size(233, 92);
            panelLogo.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(34, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(178, 74);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // panelPlayer
            // 
            panelPlayer.BackColor = Color.FromArgb(1, 38, 90);
            panelPlayer.Dock = DockStyle.Bottom;
            panelPlayer.Location = new Point(250, 622);
            panelPlayer.Name = "panelPlayer";
            panelPlayer.Size = new Size(923, 79);
            panelPlayer.TabIndex = 1;
            panelPlayer.Paint += panelPlayer_Paint;
            // 
            // panelChildForm
            // 
            panelChildForm.BackColor = Color.White;
            panelChildForm.Controls.Add(pictureBox9);
            panelChildForm.Dock = DockStyle.Fill;
            panelChildForm.Location = new Point(250, 0);
            panelChildForm.Name = "panelChildForm";
            panelChildForm.Size = new Size(923, 622);
            panelChildForm.TabIndex = 2;
            // 
            // pictureBox9
            // 
            pictureBox9.Anchor = AnchorStyles.None;
            pictureBox9.Image = (Image)resources.GetObject("pictureBox9.Image");
            pictureBox9.Location = new Point(340, 198);
            pictureBox9.Name = "pictureBox9";
            pictureBox9.Size = new Size(224, 224);
            pictureBox9.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox9.TabIndex = 2;
            pictureBox9.TabStop = false;
            // 
            // Inicio
            // 
            AutoScaleDimensions = new SizeF(8F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1173, 701);
            Controls.Add(panelChildForm);
            Controls.Add(panelPlayer);
            Controls.Add(panelSideMenu);
            Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            MinimumSize = new Size(950, 600);
            Name = "Inicio";
            StartPosition = FormStartPosition.CenterScreen;
            FormClosed += Inicio_FormClosed;
            panelSideMenu.ResumeLayout(false);
            panelToolsSubMenu.ResumeLayout(false);
            panelPlaylistSubMenu.ResumeLayout(false);
            panelMediaSubMenu.ResumeLayout(false);
            panelLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panelChildForm.ResumeLayout(false);
            panelChildForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox9).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelSideMenu;
        private System.Windows.Forms.Panel panelMediaSubMenu;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnMedia;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Panel panelToolsSubMenu;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button btnTools;
        private System.Windows.Forms.Panel panelPlaylistSubMenu;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button btncamiones;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button btnPlaylist;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Panel panelPlayer;
        private System.Windows.Forms.Panel panelChildForm;
        private PictureBox pictureBox9;
        private PictureBox pictureBox1;
    }
}

