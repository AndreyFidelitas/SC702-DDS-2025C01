using CapaDatos;
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
        UsuariosE usuariosE = new UsuariosE();
        Generales g = new Generales();


        public frmInicioSesion()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            InicioSesion();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RecuperarContrasena();
        }

        private void txtPaswword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                InicioSesion();
        }

        private void lkUnirse_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            UsuariosNuevo();
        }

        //***************************************************************************************************
        #region Metodos Generales
        //Metodo para iniciar sesion
        private void InicioSesion()
        {
            usuariosE.UsuarioName = txtUser.Text.Trim();
            usuariosE.Password = txtPaswword.Text.Trim();
            string msj;

            // Llamar al método de login (ya implementado)
            UsuariosE usuario = usuariosN.LoginUsuario(usuariosE.UsuarioName, usuariosE.Password, out msj);

            //verifica el usuario
            if (usuario != null)
            {

                if (usuario.UsuarioEstado == false)
                {
                    g.msj = msj;
                    MessageBox.Show(g.msj, "Error en el inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {

                    // Generar un token único usando Guid
                    string tokenNuevo = Guid.NewGuid().ToString();

                    // Actualizar el token en la base de datos mediante el nuevo SP
                    string updateMsj = usuariosN.ActualizarToken(usuario.UsuarioCode, tokenNuevo);

                    // Asignar el token actualizado al objeto usuario (si lo necesitas en la aplicación)
                    usuario.token = tokenNuevo;

                    // Inicializar la sesión del usuario
                    SesionUsuario.IniciarSesion(usuario);

                    // Abrir el formulario de inicio y redirigir al usuario
                    Inicio frmInicio = new Inicio(usuario);
                    frmInicio.Show();
                    this.Hide();
                }
            }
            else
            {
                g.msj = msj;
                MessageBox.Show(g.msj, "Error en el inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //***************************************************************************************************
        private void RecuperarContrasena()
        {
            // Abrir el formulario de inicio y redirigir al usuario
            RecuperacionContraseña rContrasena = new RecuperacionContraseña();
            rContrasena.Show();
            this.Hide();
        }
        //***************************************************************************************************
        private void UsuariosNuevo()
        {
            // Abrir el formulario de inicio y redirigir al usuario
            UsuarioNuevos usuarionuevo = new UsuarioNuevos();
            usuarionuevo.Show();
            this.Hide();
        }
        #endregion
    }
}
