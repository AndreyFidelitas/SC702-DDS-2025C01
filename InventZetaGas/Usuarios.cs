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
using static System.Windows.Forms.Design.AxImporter;

namespace InventZetaGas
{
    public partial class Usuarios : Form
    {
        UsuariosD userD = new UsuariosD();
        UsuariosE userE = new UsuariosE();
        UsuariosN userN = new UsuariosN();
        RolesN RolesN = new RolesN();
        Generales g = new Generales();


        public Usuarios()
        {
            InitializeComponent();
        }

        private void Usuarios_Load(object sender, EventArgs e)
        {
            CargarDatos();
            CargarListaRoles();
            cbRol.SelectedIndex = -1;
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
            Limpiar();
        }

        private void gvUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CargarDatos();
        }

        //boton para buscar informacion
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //BuscarDatos(1);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            MantenimientosBotones(1);
        }

        private void rbtnActive_CheckedChanged(object sender, EventArgs e)
        {
            Estados();
        }

        private void rbtnInactive_CheckedChanged(object sender, EventArgs e)
        {
            Estados();
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
        private void Limpiar()
        {
            txtCodeUser.Text = "";
            txtNombre.Text = "";
            txtApellidos.Text = "";
            txtContraseña.Text = "";
            txtUsuario.Text = "";
            cbRol.SelectedIndex = -1;
        }


        // metodo para seleccionar los radio button sea activo o inactivo
        public void Estados()
        {
            if (rbtnActive.Checked)
            {
                rbtnInactive.Checked = false;
                userE.UsuarioEstado = rbtnActive.Checked;
            }
            else if (rbtnInactive.Checked)
            {
                rbtnActive.Checked = false;
                userE.UsuarioEstado = rbtnInactive.Checked;
            }
        }

        public void EstadosModificacion()
        {
            if (rbtnActive.Checked)
            {
                rbtnInactive.Checked = false;
                userE.UsuarioEstado = rbtnActive.Checked;
            }
            else if (rbtnInactive.Checked)
            {
                rbtnActive.Checked = false;
                userE.UsuarioEstado = rbtnActive.Checked;
            }
        }

        //metodo para cargar las provincias
        public void CargarListaRoles()
        {

            cbRol.DataSource = RolesN.CargarRoles();
            cbRol.DisplayMember = "Rol";
            cbRol.ValueMember = "Codigo Rol";
        }

        //************************************************************************************************
        private void Mantenimiento(string accion)
        {
            userE.UsuarioCode = txtCodeUser.Text;
            userE.UsuarioName = txtNombre.Text;
            userE.UsuarioApellidos = txtApellidos.Text;
            userE.UsuarioUserName = txtUsuario.Text;
            userE.RoleID = Convert.ToInt32(cbRol.SelectedIndex + 1);
            userE.Password = txtContraseña.Text;
            g.accion = accion;
            //g.msj = camionN.MantenimientoCamiones(camionE, g.accion);
            MessageBox.Show(g.msj, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //************************************************************************************************
        //metodo general de mantenimientos  
        public void MantenimientosBotones(int opcion)
        {
            string resultado = null;
            // Evaluamos la opción con un switch
            switch (opcion)
            {
                case 1:
                    if (!string.IsNullOrEmpty(txtCodeUser.Text))
                        MessageBox.Show("Campos sin completar, por favor llenar los datos", "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (ValidarCampos() == true)
                    {
                        if (MessageBox.Show($"¿Deseas registrar a {txtNombre.Text}?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            // Método para realizar el insert en SQL con la acción "1".
                            Mantenimiento("1");
                            Limpiar();
                        }
                    }
                    else
                        MessageBox.Show("Campos sin completar, por favor llenar los datos", "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case 2:
                    // Pregunta si desea modificar el dato.
                    if (MessageBox.Show($"¿Deseas modificar {txtNombre.Text}?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        //metodo para validar los campos
                        if (ValidarCampos() == false)
                            MessageBox.Show("Campos sin completar, por favor llenar los datos", "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                        {
                            EstadosModificacion();
                            Mantenimiento("2");
                            Limpiar();
                        }
                    }
                    break;
                case 3:
                    // Pregunta si desea eliminar el dato.
                    if (MessageBox.Show($"¿Deseas eliminar {txtNombre.Text}?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        //metodo para validar los campos
                        if (ValidarCampos() == true)
                            MessageBox.Show("Campos sin completar, por favor llenar los datos", "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                        {
                            Mantenimiento("3");
                            Limpiar();
                        }
                    }
                    break;
            }
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
            if (string.IsNullOrEmpty(txtApellidos.Text))
            {
                return valid;
            }

            // Verifica si algún campo está vacío devuelve  un false
            if (string.IsNullOrEmpty(txtUsuario.Text))
            {
                return valid;
            }

            // Verifica si algún campo está vacío devuelve  un false
            if (cbRol.SelectedIndex == -1)
            {
                return valid;
            }

            // Verifica si algún campo está vacío devuelve  un false
            if (string.IsNullOrEmpty(txtContraseña.Text))
            {
                return valid;
            }

            valid = true;
            return valid;
        }
        //************************************************************************************************
        #endregion

        private void btnModify_Click(object sender, EventArgs e)
        {
            MantenimientosBotones(2);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            MantenimientosBotones(3);
        }
    }
}
