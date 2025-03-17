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
using CapaNegocios;
using CapaEntidades;
using System.Text.RegularExpressions;
using CapaDatos;

namespace InventZetaGas
{
    public partial class RecuperacionContraseña : Form
    {
        UsuariosE userE = new UsuariosE();
        UsuariosD userD= new UsuariosD();
        Generales g=new Generales();


        public RecuperacionContraseña()
        {
            InitializeComponent();
        }

        private void btnRecuperar_Click(object sender, EventArgs e)
        {
            RecuperarContrasena();
        }
        //*****************************************************************************
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MenuPrincipal();
        }
        //*****************************************************************************
        #region Metodo Generales
        private void MenuPrincipal()
        {
            // Abrir el formulario de inicio y redirigir al usuario
            frmInicioSesion frmInicio = new frmInicioSesion();
            frmInicio.Show();
            this.Hide();
        }

        //********************************
        [Obsolete]
        private void RecuperarContrasena() 
        {
            //validacion de datos 
            try
            {
                // verifica que si digita en el usuario
                if (!string.IsNullOrEmpty(txtUsuario.Text))
                {
                    userE.UsuarioUserName = txtUsuario.Text;
                    var  value=userD.RecuperarContrasena(userE);
                    MessageBox.Show("Este seria la nueva contrasena,"+value+"", "Error en el inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    //verificar la cedula.
                    if(!string.IsNullOrEmpty(txtCedula.Text))
                    {
                        //metodo para validar la cedula
                        if(ValidarCedula(txtCedula.Text)==true)
                        {
                            userE.Cedula = int.Parse(txtCedula.Text);
                            var value = userD.RecuperarContrasena(userE);
                            MessageBox.Show("Este seria la nueva contrasena," + value + "", "Error en el inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                           MessageBox.Show("No puede contener caracteres la cedula", "Error de cédula", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else 
                    {
                        g.msj = "No pueden quedar campos vacion, recupere su perfil con el usuario o la cédula";
                        MessageBox.Show(g.msj, "Error en el inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex) 
            {
                g.msj = ex.Message.ToString();
                MessageBox.Show(g.msj, "Error en el inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
        //*****************************************************************************
        public static bool ValidarCedula(string cedula)
        {
            // Expresión regular para verificar que la cédula contenga solo números
            string patron = @"^\d+$";

            // Verificar si la cédula coincide con el patrón
            if (Regex.IsMatch(cedula, patron))
            {
                return true; // La cédula es válida
            }
            else
            {
                return false; // La cédula no es válida
            }
        }
    }
}
