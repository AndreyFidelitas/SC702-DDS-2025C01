using CapaEntidades;
using CapaNegocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventZetaGas
{
    public partial class TipoCilindro : Form
    {

        TipoCilindroN cilindrosN = new TipoCilindroN();
        CapaEntidades.TipoCilindro Ce = new CapaEntidades.TipoCilindro();
        Generales g = new Generales();
        private DataView dataView;

        public TipoCilindro()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TipoCilindro_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void gbRaza_Enter(object sender, EventArgs e)
        {

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

        private void rbtnInactive_CheckedChanged(object sender, EventArgs e)
        {
            Estados();
        }
        //*****************************************************************************
        #region Metodos Generales
        public void Limpiar()
        {
            txtCilindro.Text = "";
            txtCodeCilindro.Text = "";
            CargarDatos();
        }

        private void rbtnActive_CheckedChanged(object sender, EventArgs e)
        {
            Estados();
        }

        public void Estados()
        {
            if (rbtnActive.Checked)
            {
                rbtnInactive.Checked = false;
                Ce.TipoCilindroStatus = rbtnActive.Checked;
            }
            else if (rbtnInactive.Checked)
            {
                rbtnActive.Checked = false;
                Ce.TipoCilindroStatus = rbtnInactive.Checked;
            }
        }

        public void EstadosModificacion()
        {
            if (rbtnActive.Checked)
            {
                rbtnInactive.Checked = false;
                Ce.TipoCilindroStatus = rbtnActive.Checked;
            }
            else if (rbtnInactive.Checked)
            {
                rbtnActive.Checked = false;
                Ce.TipoCilindroStatus = rbtnActive.Checked;
            }
        }


        //metodo general de mantenimientos  
        public void MantenimientosBotones(int opcion)
        {
            // Evaluamos la opción con un switch
            switch (opcion)
            {
                case 1:
                    if (!string.IsNullOrEmpty(txtCodeCilindro.Text))
                        MessageBox.Show("Campos sin completar, por favor llenar los datos", "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (ValidarCampos() == true)
                    {
                        if (MessageBox.Show($"¿Deseas registrar a {txtCilindro.Text}?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
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
                    if (MessageBox.Show($"¿Deseas modificar {txtCilindro.Text}?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        EstadosModificacion();
                        Mantenimiento("2");
                        Limpiar();
                    }
                    break;

                case 3:
                    // Pregunta si desea eliminar el dato.
                    if (MessageBox.Show($"¿Deseas eliminar {txtCilindro.Text}?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
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
            if (string.IsNullOrEmpty(txtCilindro.Text))
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
            Ce.TipoCilindroCode = txtCodeCilindro.Text;
            Ce.LoteLitraje = txtCilindro.Text;

            g.accion = accion;
            g.msj = cilindrosN.MantenimientoTipoCilindro(Ce, g.accion);
            MessageBox.Show(g.msj, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //metodo para CargarDatos de las Rutas.
        public void CargarDatos()
        {
            gvCilindros.DataSource = cilindrosN.ListaTipoCilindro();
        }
        #endregion

        private void gvCilindros_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Obtén la fila seleccionada
                DataGridViewRow row = gvCilindros.Rows[e.RowIndex];
                // Asigna los valores de las celdas a los TextBox
                txtCodeCilindro.Text = row.Cells["Codigo Cilindro"].Value?.ToString();
                txtCilindro.Text = row.Cells["Cilindro"].Value?.ToString();
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
    }
}
