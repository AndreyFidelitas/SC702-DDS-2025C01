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

namespace InventZetaGas
{
    public partial class Rutas : Form
    {

        RutasN rN = new RutasN();
        RutasE rE = new RutasE();
        Generales g = new Generales();
        private DataView dataView;

        #region Funciones del formulario
        public Rutas()
        {
            InitializeComponent();
        }

        private void gvRutas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //SeleecionarDatos(e);
            // Verifica que el índice de fila sea válido
            if (e.RowIndex >= 0)
            {
                // Obtén la fila seleccionada
                DataGridViewRow row = gvRutas.Rows[e.RowIndex];
                // Asigna los valores de las celdas a los TextBox
                txtCodeRuta.Text = row.Cells["Codigo Ruta"].Value?.ToString();
                txtRuta.Text = row.Cells["Ruta"].Value?.ToString();
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
            MessageBox.Show("No se pueden actualizar las rutas por el momento.", "En mantenimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //MantenimientosBotones(2);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            MessageBox.Show("No se puede Eliminar las rutas por el momento.", "En mantenimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // MantenimientosBotones(3);
        }

        private void rbtnActive_CheckedChanged(object sender, EventArgs e)
        {
            Estados();
        }

        private void rbtnInactive_CheckedChanged(object sender, EventArgs e)
        {
            Estados();
        }

        private void Rutas_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }
        #endregion
        //**********************************************************************
        #region Metodo generales

        //metodo para limpiar los campos.
        public void Limpiar()
        {
            txtCodeRuta.Text = "";
            txtRuta.Text = "";
            CargarDatos();
        }

        //metodo para CargarDatos de las Rutas.
        public void CargarDatos()
        {
            gvRutas.ReadOnly = true;    
            gvRutas.DataSource = rN.ListaRutas();
        }

        // metodo para seleccionar los radio button sea activo o inactivo
        public void Estados()
        {
            if (rbtnActive.Checked)
            {
                rbtnInactive.Checked = false;
                rE.RutaStatus = rbtnActive.Checked;
            }
            else if (rbtnInactive.Checked)
            {
                rbtnActive.Checked = false;
                rE.RutaStatus = rbtnInactive.Checked;
            }
        }


        public void EstadosModificacion()
        {
            if (rbtnActive.Checked)
            {
                rbtnInactive.Checked = false;
                rE.RutaStatus = rbtnActive.Checked;
            }
            else if (rbtnInactive.Checked)
            {
                rbtnActive.Checked = false;
                rE.RutaStatus = rbtnActive.Checked;
            }
        }

        //metodo general de mantenimientos  
        public void MantenimientosBotones(int opcion)
        {
            // Evaluamos la opción con un switch
            switch (opcion)
            {
                case 1:
                    if (string.IsNullOrEmpty(txtRuta.Text))
                        MessageBox.Show("Campos sin completar, por favor llenar los datos", "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (ValidarCampos() == true)
                    {
                        if (MessageBox.Show($"¿Deseas registrar a {txtRuta.Text}?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
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
                    if (MessageBox.Show($"¿Deseas modificar {txtRuta.Text}?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        EstadosModificacion();
                        Mantenimiento("2");
                        Limpiar();
                    }
                    break;

                case 3:
                    // Pregunta si desea eliminar el dato.
                    if (MessageBox.Show($"¿Deseas eliminar {txtRuta.Text}?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        Mantenimiento("3");
                        Limpiar();
                    }
                    break;
            }
        }

        //**********************************************************************
        public bool ValidarCampos()
        {
            bool valid = false;

            // Verifica si algún campo está vacío devuelve  un false
            if (string.IsNullOrEmpty(txtRuta.Text))
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

        //**********************************************************************
        private void Mantenimiento(string accion)
        {
            rE.RutaCode = txtCodeRuta.Text;
            rE.Ruta = txtRuta.Text;

            g.accion = accion;
            g.msj = rN.MantenimientoRutas(rE, g.accion);
            MessageBox.Show(g.msj, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void SeleecionarDatos(DataGridViewCellEventArgs e)
        {
            // Verifica que el índice de fila sea válido
            if (e.RowIndex >= 0)
            {
                // Obtén la fila seleccionada
                DataGridViewRow row = gvRutas.Rows[e.RowIndex];
                // Asigna los valores de las celdas a los TextBox
                txtCodeRuta.Text = row.Cells["Codigo Ruta"].Value?.ToString();
                txtRuta.Text = row.Cells["Ruta"].Value?.ToString();
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
    }
}
