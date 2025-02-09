using CapaEntidades;
using CapaNegocios;
using PlayerUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventZetaGas
{
    public partial class frmInicioSesion : Form
    {
        // Instanciamos la capa de negocios
        UsuariosN usuariosN = new UsuariosN();

        // Add the missing TextBox controls
        private TextBox txtUsuario;
        private TextBox txtPassword;

        public frmInicioSesion()
        {
            InitializeComponent();

            // Initialize the TextBox controls
            txtUsuario = new TextBox();
            txtPassword = new TextBox();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            string usuarioUserName = txtUser.Text;
            string password = txtPaswword.Text;
            string msj;

            // Invocamos el método LoginUsuario de la capa de negocios.
            UsuariosE usuario = usuariosN.LoginUsuario(usuarioUserName, password, out msj);

            if (usuario != null)
            {
                MessageBox.Show(msj, "Inicio de sesión exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Aquí puedes abrir el formulario principal y pasar el objeto usuario si es necesario
                // Ejemplo:
                // FrmMain frm = new FrmMain(usuario);
                // frm.Show();
                // this.Hide();
                Inicio frmInicio = new Inicio(usuario);
                frmInicio.Show();
            }
            else
            {
                MessageBox.Show(msj, "Error en el inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
