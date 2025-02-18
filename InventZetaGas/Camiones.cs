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
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using System.Numerics;
using static System.Windows.Forms.Design.AxImporter;
using System.Diagnostics.Eventing.Reader;

namespace InventZetaGas
{
    public partial class Camiones : Form
    {
        public Camiones()
        {
            InitializeComponent();
        }

        CamionesN camionN = new CamionesN();
        CamionesE camionE = new CamionesE();
        Generales g = new Generales();
        private DataView dataView;


        #region Metodos del formulario
        private void Camiones_Load(object sender, EventArgs e)
        {
            CargarDatos();
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

        private void gvCamiones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            SeleccionarInformacion(e);
        }


        private void rbtnActive_CheckedChanged(object sender, EventArgs e)
        {
            Estados();
        }

        private void rbtnInactive_CheckedChanged(object sender, EventArgs e)
        {
            Estados();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                Buscar();
        }

        #endregion
        //*********************************************************************
        #region MetodosGenerales
        //metodo para cargar la lista de camiones
        private void CargarDatos()
        {
            gvCamiones.ReadOnly = true;
            gvCamiones.DataSource = camionN.ListaCamion();
        }
        //************************************************
        //metodo para limpiar los campos
        public void Limpiar()
        {
            txtCodeCamion.Text = "";
            txtCamion.Text = "";
            txtPesaje.Text = "";
            txtPlaca.Text = "";
            rbtnActive.Checked = false;
            rbtnInactive.Checked = false;
            CargarDatos();
        }
        //************************************************************************************************
        // metodo para seleccionar los radio button sea activo o inactivo
        public void Estados()
        {
            if (rbtnActive.Checked)
            {
                rbtnInactive.Checked = false;
                camionE.CamionStatus = rbtnActive.Checked;
            }
            else if (rbtnInactive.Checked)
            {
                rbtnActive.Checked = false;
                camionE.CamionStatus = rbtnInactive.Checked;
            }
        }

        public void EstadosCamion()
        {
            if (rbtnVActive.Checked)
            {
                rbtnVInactive.Checked = false;
                camionE.CamionActivty = rbtnActive.Checked;
            }
            else if (rbtnVInactive.Checked)
            {
                rbtnVActive.Checked = false;
                camionE.CamionActivty = rbtnInactive.Checked;
            }
        }



        //************************************************************************************************
        public void EstadosModificacion()
        {
            if (rbtnActive.Checked)
            {
                rbtnInactive.Checked = false;
                camionE.CamionStatus = rbtnActive.Checked;
            }
            else if (rbtnInactive.Checked)
            {
                rbtnActive.Checked = false;
                camionE.CamionStatus = rbtnActive.Checked;
            }
        }
        //************************************************************************************************
        //validacion de campos 
        // Método para verificar si los campos están vacíos
        public bool ValidarCampos()
        {
            bool valid = false;

            // Verifica si algún campo está vacío devuelve  un false
            if (string.IsNullOrEmpty(txtCamion.Text))
            {
                return valid;
            }

            // Verifica si algún campo está vacío devuelve  un false
            if (string.IsNullOrEmpty(txtPesaje.Text))
            {
                return valid;
            }

            // Verifica si algún campo está vacío devuelve  un false
            if (string.IsNullOrEmpty(txtPlaca.Text))
            {
                return valid;
            }

            if (rbtnActive.Checked == false && rbtnActive.Checked == false)
            {
                return valid;
            }

            valid = true;
            return valid;
        }
        //************************************************************************************************
        private void Mantenimiento(string accion)
        {
            camionE.CamionCode = txtCodeCamion.Text;
            camionE.CamionPlaca = txtPlaca.Text;
            camionE.CamionName = txtCamion.Text;
            camionE.CamionPesaje = txtPesaje.Text;
            g.accion = accion;
            g.msj = camionN.MantenimientoCamiones(camionE, g.accion);
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
                    if (!string.IsNullOrEmpty(txtCodeCamion.Text))
                        MessageBox.Show("Campos sin completar, por favor llenar los datos", "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    if (ValidarCampos() == true)
                    {
                        if (MessageBox.Show($"¿Deseas registrar a {txtCamion.Text}?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
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
                    if (MessageBox.Show($"¿Deseas modificar {txtCamion.Text}?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        //metodo para validar los campos
                        if (ValidarCampos() == true)
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
                    if (MessageBox.Show($"¿Deseas eliminar {txtCamion.Text}?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
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
        //metodo de buscar informacion 
        private void Buscar()
        {
            // Obtén el DataTable de la lista de camiones
            DataTable dt = camionN.ListaCamion();
            dataView = dt.DefaultView;

            string filtro = txtBuscar.Text.Trim();  // Obtén el texto del cuadro de búsqueda

            // Si el filtro está vacío, muestra todos los registros
            if (string.IsNullOrEmpty(filtro))
            {
                dataView.RowFilter = string.Empty;
            }
            else
            {
                // Aplica el filtro, ajusta según la columna y el valor
                string filtroAplicado = "Marca LIKE '%" + filtro + "%'";  // Filtra según la columna 'Marca'
                dataView.RowFilter = filtroAplicado;
            }

            // Asigna el DataView al DataGridView para que se muestre el resultado filtrado
            gvCamiones.DataSource = dataView;

            // Verifica si hay resultados después de aplicar el filtro
            if (dataView.Count == 0)  // Si no hay registros que coincidan con el filtro
            {
                MessageBox.Show("No se encontraron resultados.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                // Muestra todos los registros si no se encuentran resultados
                dataView.RowFilter = string.Empty;
                gvCamiones.DataSource = dataView;  // Asigna de nuevo los datos completos
            }
        }
        //************************************************************************************************
        public void SeleccionarInformacion(DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Obtén la fila seleccionada
                DataGridViewRow row = gvCamiones.Rows[e.RowIndex];
                // Asigna los valores de las celdas a los TextBox
                txtCodeCamion.Text = row.Cells["Camión ID"].Value?.ToString();
                txtCamion.Text = row.Cells["Marca"].Value?.ToString();
                txtPesaje.Text = row.Cells["Pesaje Camion"].Value?.ToString();
                txtPlaca.Text = row.Cells["Placa"].Value?.ToString();
                var estado = row.Cells["Estado"].Value.ToString();

                if (estado == "Activo")
                {
                    rbtnActive.Checked = true;
                }
                else if (estado == "Inactivo")
                {
                    rbtnInactive.Checked = true;
                }
            }
        }
        #endregion

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
