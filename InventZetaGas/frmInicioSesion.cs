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
        UsuariosN usuariosN = new UsuariosN();

        private string updateMsj;


        public frmInicioSesion()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            string usuarioUserName = txtUser.Text.Trim();
            string password = txtPaswword.Text.Trim();
            string msj;

            // Llamar al método de login (ya implementado)
            UsuariosE usuario = usuariosN.LoginUsuario(usuarioUserName, password, out msj);

            if (usuario != null)
            {
                // Generar un token único usando Guid
                string tokenNuevo = Guid.NewGuid().ToString();

                // Actualizar el token en la base de datos mediante el nuevo SP
                string updateMsj = usuariosN.ActualizarToken(usuario.UsuarioCode, tokenNuevo);

                // Asignar el token actualizado al objeto usuario (si lo necesitas en la aplicación)
                usuario.token = tokenNuevo;

                MessageBox.Show(msj + "\n" +
                                "Token actualizado: " + tokenNuevo + "\n" +
                                updateMsj,
                                "Inicio de sesión exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Abrir el formulario de inicio y redirigir al usuario
                Inicio frmInicio = new Inicio(usuario);
                frmInicio.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show(msj, "Error en el inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
