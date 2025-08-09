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
        private int columnIndexCodigoCilindro = -1;
        private int columnIndexCilindro = -1;
        private int columnIndexEstado = -1;

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
            EnableDoubleBuffering(gvCilindros);
            CachearIndicesColumnas();
        }

        private void EnableDoubleBuffering(DataGridView grid)
        {
            try
            {
                var doubleBufferedProperty = typeof(DataGridView).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
                doubleBufferedProperty?.SetValue(grid, true, null);
            }
            catch { }
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
            //g.msj = "Se encuentra en mantenimiento para sprint #3";
            //MessageBox.Show(g.msj, "mantenimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            gvCilindros.ReadOnly = true;
            gvCilindros.DataSource = cilindrosN.ListaTipoCilindro();
        }

        private void gvCilindros_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                // Ajuste inicial para medir contenidos
                gvCilindros.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
                // Rellenar el ancho del grid
                ConfigureColumnsFill();
            }
            catch { }
            CachearIndicesColumnas();
        }

        private void ConfigureColumnsFill()
        {
            gvCilindros.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            // Pesos sugeridos: Código (25%), Cilindro (50%), Estado (25%)
            SetFillWeight("Codigo Cilindro", 25);
            SetFillWeight("Cilindro", 50);
            SetFillWeight("Estado", 25);
        }

        private void SetFillWeight(string key, float weight)
        {
            var colIndex = GetColumnIndexByNameOrHeaderText(key);
            if (colIndex >= 0)
            {
                var col = gvCilindros.Columns[colIndex];
                col.FillWeight = weight;
                col.MinimumWidth = 60;
            }
        }

        private void CachearIndicesColumnas()
        {
            columnIndexCodigoCilindro = GetColumnIndexByNameOrHeaderText("Codigo Cilindro");
            columnIndexCilindro = GetColumnIndexByNameOrHeaderText("Cilindro");
            columnIndexEstado = GetColumnIndexByNameOrHeaderText("Estado");
        }

        private int GetColumnIndexByNameOrHeaderText(string key)
        {
            if (gvCilindros.Columns == null) return -1;
            foreach (DataGridViewColumn col in gvCilindros.Columns)
            {
                if (string.Equals(col.Name, key, StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(col.HeaderText, key, StringComparison.OrdinalIgnoreCase))
                {
                    return col.Index;
                }
            }
            return -1;
        }

        private void SeleccionarFila(int rowIndex)
        {
            if (rowIndex < 0 || rowIndex >= gvCilindros.Rows.Count) return;
            var row = gvCilindros.Rows[rowIndex];

            if (columnIndexCodigoCilindro >= 0)
                txtCodeCilindro.Text = row.Cells[columnIndexCodigoCilindro].Value?.ToString();
            if (columnIndexCilindro >= 0)
                txtCilindro.Text = row.Cells[columnIndexCilindro].Value?.ToString();

            var estado = columnIndexEstado >= 0 ? row.Cells[columnIndexEstado].Value?.ToString() : null;
            if (string.Equals(estado, "Activo", StringComparison.OrdinalIgnoreCase))
            {
                rbtnActive.Checked = true;
            }
            else if (string.Equals(estado, "Inactivo", StringComparison.OrdinalIgnoreCase))
            {
                rbtnInactive.Checked = true;
            }
        }
        #endregion

        private void gvCilindros_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                SeleccionarFila(e.RowIndex);
            }
        }

        private void gvCilindros_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                SeleccionarFila(e.RowIndex);
            }
        }
    }
}
