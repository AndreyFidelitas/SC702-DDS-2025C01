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
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtZona.Text))
            {
                MessageBox.Show("Campos sin completar, por favor llenar los datos", "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (string.IsNullOrEmpty(txtCodeZona.Text))
            {
                // Pregunta si desea registrar el siguiente dato.
                if (MessageBox.Show($"¿Deseas registrar a {txtZona.Text}?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    // Método para realizar el insert en SQL con la acción "1".
                    Mantenimiento("1");
                    Limpiar();
                }
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            // Pregunta si desea modificar el dato.
            if (MessageBox.Show($"¿Deseas modificar {txtZona.Text}?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                Mantenimiento("2");
                Limpiar();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Pregunta si desea eliminar el dato.
            if (MessageBox.Show($"¿Deseas eliminar {txtZona.Text}?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                Mantenimiento("3");
                Limpiar();
            }
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

        private void label4_Click(object sender, EventArgs e)
        {

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
        #endregion


        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)50)
            {
                DataTable dt = ZonasN.ListaZona(); // Asegúrate de que ListaZona() devuelve un DataTable
                dataView = dt.DefaultView; // Obtiene el DataView del DataTable
                gvZonas.DataSource = dataView;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
