using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        private int columnIndexCodigoRuta = -1;
        private int columnIndexRuta = -1;
        private int columnIndexEstado = -1;

        #region Funciones del formulario
        public Rutas()
        {
            InitializeComponent();
            EnableDoubleBuffering(gvRutas);
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

        private void gvRutas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //SeleecionarDatos(e);
            // Verifica que el índice de fila sea válido
            if (e.RowIndex >= 0)
            {
                SeleccionarFila(e.RowIndex);
            }
        }

        private void gvRutas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                SeleccionarFila(e.RowIndex);
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
            //MessageBox.Show("No se pueden actualizar las rutas por el momento.", "En mantenimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
            MantenimientosBotones(2);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("No se puede Eliminar las rutas por el momento.", "En mantenimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
            MantenimientosBotones(3);
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
            CachearIndicesColumnas();
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

        private void gvRutas_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                gvRutas.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
                ConfigureColumnsFill();
            }
            catch { }
            CachearIndicesColumnas();
        }

        private void ConfigureColumnsFill()
        {
            gvRutas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            SetFillWeight("Codigo Ruta", 25);
            SetFillWeight("Ruta", 55);
            SetFillWeight("Estado", 20);
        }

        private void SetFillWeight(string key, float weight)
        {
            var colIndex = GetColumnIndexByNameOrHeaderText(key);
            if (colIndex >= 0)
            {
                var col = gvRutas.Columns[colIndex];
                col.FillWeight = weight;
                col.MinimumWidth = 60;
            }
        }

        private void CachearIndicesColumnas()
        {
            columnIndexCodigoRuta = GetColumnIndexByNameOrHeaderText("Codigo Ruta");
            columnIndexRuta = GetColumnIndexByNameOrHeaderText("Ruta");
            columnIndexEstado = GetColumnIndexByNameOrHeaderText("Estado");
        }

        private int GetColumnIndexByNameOrHeaderText(string key)
        {
            if (gvRutas.Columns == null) return -1;
            foreach (DataGridViewColumn col in gvRutas.Columns)
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
            if (rowIndex < 0 || rowIndex >= gvRutas.Rows.Count) return;
            var row = gvRutas.Rows[rowIndex];

            if (columnIndexCodigoRuta >= 0)
                txtCodeRuta.Text = row.Cells[columnIndexCodigoRuta].Value?.ToString();

            if (columnIndexRuta >= 0)
                txtRuta.Text = row.Cells[columnIndexRuta].Value?.ToString();

            string estado = null;
            if (columnIndexEstado >= 0)
                estado = row.Cells[columnIndexEstado].Value?.ToString();

            if (!string.IsNullOrWhiteSpace(estado))
            {
                if (string.Equals(estado, "Activo", StringComparison.OrdinalIgnoreCase))
                {
                    rbtnActive.Checked = true;
                }
                else if (string.Equals(estado, "Inactivo", StringComparison.OrdinalIgnoreCase))
                {
                    rbtnInactive.Checked = true;
                }
            }
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

        public bool ValidarCamposEspeciales()
        {
            // Patrón que solo permite letras, números y espacios
            string pattern = @"^[a-zA-Z0-9\s]+$";
            string texto = txtRuta.Text;

            // Verifica que el campo no esté vacío
            if (string.IsNullOrWhiteSpace(texto))
            {
                MessageBox.Show("El campo no puede estar vacío.", "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Verifica que no empiece con número
            if (char.IsDigit(texto[0]))
            {
                MessageBox.Show("El texto no puede comenzar con un número.", "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Verifica que no tenga caracteres especiales
            if (!Regex.IsMatch(texto, pattern))
            {
                MessageBox.Show("No se permiten caracteres especiales.", "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
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

                    if (ValidarCamposEspeciales() == false)
                    {
                        Limpiar();
                    }
                    else
                    {
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


                    }



                    break;
                case 2:
                    // Pregunta si desea modificar el dato.

                    if (ValidarCamposEspeciales() == false)
                    {
                        Limpiar();
                    }
                    else
                    {
                        if (ValidarCampos() == true)
                        {

                            if (MessageBox.Show($"¿Deseas modificar {txtRuta.Text}?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                            {
                                EstadosModificacion();
                                Mantenimiento("2");
                                Limpiar();
                            }
                        }
                        else
                            MessageBox.Show("Campos sin completar, por favor llenar los datos", "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

            if (rbtnActive.Checked == false && rbtnInactive.Checked == false)
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
                if (columnIndexCodigoRuta >= 0)
                    txtCodeRuta.Text = row.Cells[columnIndexCodigoRuta].Value?.ToString();
                if (columnIndexRuta >= 0)
                    txtRuta.Text = row.Cells[columnIndexRuta].Value?.ToString();
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
        }
        #endregion
    }
}
