﻿using System;
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
            if (string.IsNullOrEmpty(txtCamion.Text))
            {
                MessageBox.Show("Campos sin completar, por favor llenar los datos", "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (string.IsNullOrEmpty(txtCodeCamion.Text))
            {
                // Pregunta si desea registrar el siguiente dato.
                if (MessageBox.Show($"¿Deseas registrar a {txtCamion.Text}?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
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
            if (MessageBox.Show($"¿Deseas modificar {txtCamion.Text}?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                EstadosModificacion();
                Mantenimiento("2");
                Limpiar();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"¿Deseas eliminar {txtCamion.Text}?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                Mantenimiento("3");
                Limpiar();
            }
        }

        private void gvCamiones_CellContentClick(object sender, DataGridViewCellEventArgs e)
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


        private void rbtnActive_CheckedChanged(object sender, EventArgs e)
        {
            Estados();
        }

        private void rbtnInactive_CheckedChanged(object sender, EventArgs e)
        {
            Estados();
        }
        #endregion

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
        //metodo de mantenimiento de Camiones

        #endregion


        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)50)
            {
                DataTable dt = camionN.ListaCamion(); // Asegúrate de que ListaZona() devuelve un DataTable
                dataView = dt.DefaultView; // Obtiene el DataView del DataTable
                gvCamiones.DataSource = dataView;
                string filtro = "Nombre LIKE '%Zeta%'"; // Ajusta el criterio de búsqueda
                dataView.RowFilter = filtro;
            }
        }
    }
}
