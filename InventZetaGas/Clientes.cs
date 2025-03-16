using CapaEntidades;
using CapaNegocios;
using Microsoft.VisualBasic.ApplicationServices;
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
using static System.Windows.Forms.Design.AxImporter;


namespace InventZetaGas
{
    public partial class Clientes : Form
    {
        ClientesE userE = new ClientesE();
        ClientesN userN = new ClientesN();
        Generales g = new Generales();
        private DataView dataView;

        public Clientes()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            MantenimientosBotones(1);
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            MantenimientosBotones(2);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            MantenimientosBotones(3);
        }

        private void btnSearchID_Click(object sender, EventArgs e)
        {
           
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {

        }


        private void Clientes_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }


        #region Mantenimientos Generales
        //metodo para limpiar los campos
        private void Limpiar()
        {
            txtCodeUser.Text = "";
            txtCedula.Text = "";
            txtEmpresa.Text = "";
            CargarDatos();
        }

        // metodo para seleccionar los radio button sea activo o inactivo
        public void Estados()
        {
            if (rbtnActive.Checked)
            {
                rbtnInactive.Checked = false;
                userE.ClientesStatus = rbtnActive.Checked;
            }
            else if (rbtnInactive.Checked)
            {
                rbtnActive.Checked = false;
                userE.ClientesStatus = rbtnInactive.Checked;
            }
        }

        public void EstadosModificacion()
        {
            if (rbtnActive.Checked)
            {
                rbtnInactive.Checked = false;
                userE.ClientesStatus = rbtnActive.Checked;
            }
            else if (rbtnInactive.Checked)
            {
                rbtnActive.Checked = false;
                userE.ClientesStatus = rbtnActive.Checked;
            }
        }


        //************************************************************************************************
        private void Mantenimiento(string accion)
        {
            userE.ClientesCode = txtCodeUser.Text;
            userE.Cedula = Int32.Parse(txtCedula.Text);
            userE.Empresa = txtEmpresa.Text;
            userE.RazonSocial = txtRazonSocial.Text;
            g.accion = accion;
            g.msj = userN.MantenimientoClientes(userE, g.accion);
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
                        if (MessageBox.Show($"¿Deseas registrar a {txtEmpresa.Text}?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
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
                    if (MessageBox.Show($"¿Deseas modificar {txtCodeUser.Text}?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
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
                    if (MessageBox.Show($"¿Deseas eliminar {txtCodeUser.Text}?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
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
        private void CargarDatos() 
        {
            gvClientes.DataSource=userN.ListaClientes();
        
        }
        
        //validacion de campos 
        // Método para verificar si los campos están vacíos
        public bool ValidarCampos()
        {
            bool valid = false;

            // Verifica si algún campo está vacío devuelve  un false
            if (string.IsNullOrEmpty(txtEmpresa.Text))
            {
                return valid;
            }

            // Verifica si algún campo está vacío devuelve  un false
            if (string.IsNullOrEmpty(txtRazonSocial.Text))
            {
                return valid;
            }

            valid = true;
            return valid;
        }
        //*************************************************************************************************
        public async Task BuscarAsync(int opcion)
        {
            string resultado = null;
            // Evaluamos la opción con un switch
            switch (opcion)
            {
                case 1:
                    if (string.IsNullOrEmpty(txtCedula.Text))
                        Limpiar();
                    else
                    {
                        //ApiResponse apiResponse = await userN.ObtenerDatosCedulaAsync(int.Parse(txtCedula.Text));
                    }

                    break;
                case 2:
                    // Obtén el DataTable de la lista de camiones
                    DataTable dt = userN.ListaClientes();
                    dataView = dt.DefaultView;

                    string filtro = txtBuscar.Text.Trim();  // Obtén el texto del cuadro de búsqueda

                    // Si el filtro está vacío, muestra todos los registros
                    if (string.IsNullOrEmpty(filtro))
                        dataView.RowFilter = string.Empty;
                    else
                    {
                        // Aplica el filtro, ajusta según la columna y el valor
                        string filtroAplicado = "Nombre de Usuario LIKE '%" + filtro + "%'";  // Filtra según la columna 'Marca'
                        dataView.RowFilter = filtroAplicado;
                    }

                    // Asigna el DataView al DataGridView para que se muestre el resultado filtrado
                    gvClientes.DataSource = dataView;

                    // Verifica si hay resultados después de aplicar el filtro
                    if (dataView.Count == 0)  // Si no hay registros que coincidan con el filtro
                    {
                        MessageBox.Show("No se encontraron resultados.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        // Muestra todos los registros si no se encuentran resultados
                        dataView.RowFilter = string.Empty;
                        gvClientes.DataSource = dataView;  // Asigna de nuevo los datos completos
                        txtBuscar.Text = "";
                    }
                    break;
            }
        }
        #endregion
    }
}
