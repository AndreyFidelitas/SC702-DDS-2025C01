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
        private string updateMsj;

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
                // Generar un token único (por ejemplo, utilizando GUID)
                usuario.token = Guid.NewGuid().ToString();

                // Actualizar el token en la base de datos
                string updateMsj = usuariosN.ActualizarTokenUsuario(usuario);

                // Actualizamos el token del usuario
                MessageBox.Show(msj + "\n" + "Token actualizado: " + usuario.token + "\n" + updateMsj, "Inicio de sesión exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                

                // Abrir el formulario de inicio y pasar la información del usuario
                Inicio frmInicio = new Inicio(usuario);
                frmInicio.Show();

                // Ocultar o cerrar el formulario de login
                this.Hide();
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
