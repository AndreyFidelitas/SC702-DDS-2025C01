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
using static System.Windows.Forms.Design.AxImporter;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace InventZetaGas
{
    public partial class Zonas : Form
    {
        ZonasN ZonasN = new ZonasN();
        ZonasE ZonasE = new ZonasE();
        Generales g = new Generales();
        private DataView dataView;


        public Zonas()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Zonas_Load(object sender, EventArgs e)
        {
            CargarDatos();
            CargarListaProvincias();
            cbProvincias.SelectedIndex = -1;
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

        private void rbtnActive_CheckedChanged(object sender, EventArgs e)
        {
            Estados();
        }

        private void tbtnInactive_CheckedChanged(object sender, EventArgs e)
        {
            Estados();
        }

        private void gvZonas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            SeleecionarDatos(e);
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            Buscar();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //*****************************************************************
        #region Metodos Generales 
        //metodo para limpiar los datos 
        public void Limpiar()
        {
            txtCodeZona.Text = "";
            txtZona.Text = "";
            cbProvincias.SelectedIndex = -1;
            CargarDatos();
        }


        // metodo para seleccionar los radio button sea activo o inactivo
        public void Estados()
        {
            if (rbtnActive.Checked)
            {
                rbtnInactive.Checked = false;
                ZonasE.ZonasEstado = rbtnActive.Checked;
            }
            else if (rbtnInactive.Checked)
            {
                rbtnActive.Checked = false;
                ZonasE.ZonasEstado = rbtnInactive.Checked;
            }
        }

        public void EstadosModificacion()
        {
            if (rbtnActive.Checked)
            {
                rbtnInactive.Checked = false;
                ZonasE.ZonasEstado = rbtnActive.Checked;
            }
            else if (rbtnInactive.Checked)
            {
                rbtnActive.Checked = false;
                ZonasE.ZonasEstado = rbtnActive.Checked;
            }
        }


        //metodo para cargar las provincias
        public void CargarListaProvincias()
        {

            cbProvincias.DataSource = ZonasN.ListaProvincias();
            cbProvincias.DisplayMember = "Provincia";
            cbProvincias.ValueMember = "Provincia ID";
        }

        //metodo para cargar los datos de SQL
        public void CargarDatos()
        {

            gvZonas.ReadOnly = true;
            gvZonas.DataSource = ZonasN.ListaZona();
        }

        private void Mantenimiento(string accion)
        {
            ZonasE.ZonasCode = txtCodeZona.Text;
            ZonasE.ZonasName = txtZona.Text;
            ZonasE.ProvinciaID = (cbProvincias.SelectedIndex + 1);
            g.accion = accion;
            g.msj = ZonasN.MantenimientoZona(ZonasE, g.accion);
            MessageBox.Show(g.msj, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //metodo general de mantenimientos  
        public void MantenimientosBotones(int opcion)
        {
            string resultado = null;

            // Evaluamos la opción con un switch
            switch (opcion)
            {
                case 1:
                    if (string.IsNullOrEmpty(txtZona.Text))
                        MessageBox.Show("Campos sin completar, por favor llenar los datos", "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else if (string.IsNullOrEmpty(txtCodeZona.Text))
                    {
                        if (rbtnActive.Checked == false && rbtnActive.Checked == false)
                            MessageBox.Show("Campos sin completar, por favor llenar los datos", "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else if (MessageBox.Show($"¿Deseas registrar a {txtZona.Text}?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            // Método para realizar el insert en SQL con la acción "1".
                            Mantenimiento("1");
                            Limpiar();
                        }
                    }
                    break;
                case 2:
                    // Pregunta si desea modificar el dato.
                    if (MessageBox.Show($"¿Deseas modificar {txtZona.Text}?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        EstadosModificacion();
                        Mantenimiento("2");
                        Limpiar();
                    }
                    break;

                case 3:
                    // Pregunta si desea eliminar el dato.
                    if (MessageBox.Show($"¿Deseas eliminar {txtZona.Text}?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        Mantenimiento("3");
                        Limpiar();
                    }
                    break;
            }
        }

        public void SeleecionarDatos(DataGridViewCellEventArgs e)
        {
            // Verifica que el índice de fila sea válido
            if (e.RowIndex >= 0)
            {
                // Obtén la fila seleccionada
                DataGridViewRow row = gvZonas.Rows[e.RowIndex];
                // Asigna los valores de las celdas a los TextBox
                txtCodeZona.Text = row.Cells["Zona ID"].Value?.ToString();
                txtZona.Text = row.Cells["Nombre Zona"].Value?.ToString();
                cbProvincias.Text = row.Cells["Provincia"].Value?.ToString();
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

        private void Buscar()
        {
            // Obtén el DataTable de la lista de camiones
            DataTable dt = ZonasN.ListaZona();
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
                string filtroAplicado = "Provincia LIKE '%" + filtro + "%'";  // Filtra según la columna 'Marca'
                dataView.RowFilter = filtroAplicado;
            }

            // Asigna el DataView al DataGridView para que se muestre el resultado filtrado
            gvZonas.DataSource = dataView;

            // Verifica si hay resultados después de aplicar el filtro
            if (dataView.Count == 0)  // Si no hay registros que coincidan con el filtro
            {
                MessageBox.Show("No se encontraron resultados.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                // Muestra todos los registros si no se encuentran resultados
                dataView.RowFilter = string.Empty;
                gvZonas.DataSource = dataView;  // Asigna de nuevo los datos completos
            }
        }
        #endregion

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            //Buscar();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Buscar();
        }
    }
}
