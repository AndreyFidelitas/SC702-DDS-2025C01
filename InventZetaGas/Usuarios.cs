using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDatos;
using CapaEntidades;
using CapaNegocios;

namespace InventZetaGas
{
    public partial class Usuarios : Form
    {
        UsuariosD userD = new UsuariosD();
        UsuariosE userE = new UsuariosE();
        UsuariosN userN = new UsuariosN();

        public Usuarios()
        {
            InitializeComponent();
        }

        private void Usuarios_Load(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void lblCode_Click(object sender, EventArgs e)
        {

        }

        private void lblPlaca_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void gvUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CargarDatos();
        }

        //boton para buscar informacion
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarDatos(1);
        }


        #region Mantenimientos Generales
        //Metodo para cargar los datos en data grid view.
        private void CargarDatos()
        {
            gvUsuarios.DataSource = userN.ListaUsuario();
        }

        //Boton para buscar la cedula del usuario.
        private void btnSearchID_Click(object sender, EventArgs e)
        {

        }

        //metodo para limpiar los campos
        private void limpiar()
        {
            txtCodeUser.Text = "";
            txtNombre.Text = "";
            txtApellidos.Text = "";
            txtContraseña.Text = "";
            txtUsuario.Text = "";
            cbRol.SelectedIndex = -1;
        }

        //metodo par buscar informacion segun lo que se solicite
        private void BuscarDatos(int opcion)
        {

        }
        #endregion


    }
}
