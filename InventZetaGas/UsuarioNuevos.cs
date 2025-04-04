using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidades;
using CapaNegocios;
using Microsoft.VisualBasic.ApplicationServices;

namespace InventZetaGas
{
    public partial class UsuarioNuevos : Form
    {
        UsuariosSolicitud userE =new UsuariosSolicitud();
        UsuariosN userN =new UsuariosN();
        public UsuarioNuevos()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            UsuariosNuevo();
        }

        #region metodos generales
        private void UsuariosNuevo()
        {
            Mantenimiento("1");
            Limpiar();
        }

        //modulo de mantenimiento.
        private void Mantenimiento(string accion)
        {
            userE.Cedula = Int32.Parse(txtCedula.Text);
            userE.Name = txtNombre.Text;
            userE.Apellidos = txtApellido.Text;
            g.accion = accion;
            g.msj = userN.MantenimientoSolicitudUsuarios(userE, g.accion);
            MessageBox.Show(g.msj, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Limpiar()
        {
            txtApellido.Text = "";
            txtCedula.Text = "";
            txtNombre.Text = "";
        }
        #endregion

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Abrir el formulario de inicio y redirigir al usuario
            frmInicioSesion usuarionuevo = new frmInicioSesion();
            usuarionuevo.Show();
            this.Hide();
        }

    }
}
