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
        Generales g=new Generales();
        public UsuarioNuevos()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            UsuariosNuevo();
        }

        #region metodos generales

        //*******************************************************************************************************************
        private void UsuariosNuevo()
        {
            if(ValidarCampos()==true)
            {
                if (userN.ValidacionSolicitudUsuarios(userE) == true) 
                {
                    MessageBox.Show("Ya el usuario existe","Usuario Existente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    Mantenimiento("1");
                    Limpiar();
                }
            }
            else
            {
                MessageBox.Show("Campos sin completar, por favor llenar los datos", "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpiar();
            }

        }
        //*******************************************************************************************************************
        //modulo de mantenimiento.
        private void Mantenimiento(string accion)
        {
            userE.Cedula = Int32.Parse(txtCedula.Text);
            userE.Name = txtNombre.Text;
            userE.Apellidos = txtApellido.Text;
            g.accion = accion;
            g.msj = userN.MantenimientoSolicitudUsuarios(userE, g.accion);
        }

        private void Limpiar()
        {
            txtApellido.Text = "";
            txtCedula.Text = "";
            txtNombre.Text = "";
        }
        //************************************************************************************************
        //validacion de campos 
        // Método para verificar si los campos están vacíos
        public bool ValidarCampos()
        {
            bool valid = false;

            // Verifica si algún campo está vacío devuelve  un false
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                return valid;
            }

            // Verifica si algún campo está vacío devuelve  un false
            if (string.IsNullOrEmpty(txtApellido.Text))
            {
                return valid;
            }

            // Verifica si algún campo está vacío devuelve  un false
            if (string.IsNullOrEmpty(txtCedula.Text))
            {
                return valid;
            }

            valid = true;
            return valid;
        }
        #endregion
        //************************************************************************************************
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Abrir el formulario de inicio y redirigir al usuario
            frmInicioSesion usuarionuevo = new frmInicioSesion();
            usuarionuevo.Show();
            this.Hide();
        }
        //************************************************************************************************
    }
}
