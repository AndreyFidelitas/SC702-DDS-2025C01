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
    public partial class Roles : Form
    {

        RolesN rolesN = new RolesN();
        RolesE RolesE = new RolesE();
        Generales g = new Generales();
        private DataView dataView;


        public Roles()
        {
            InitializeComponent();
        }

        private void gvRoles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica que el índice de fila sea válido
            if (e.RowIndex >= 0)
            {
                // Obtén la fila seleccionada
                DataGridViewRow row = gvRoles.Rows[e.RowIndex];
                // Asigna los valores de las celdas a los TextBox
                txtCodeRol.Text = row.Cells["Codigo Rol"].Value?.ToString();
                txtRol.Text = row.Cells["Rol"].Value?.ToString();
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

        //*****************************************************************
        #region Metodos Generales 
        //metodo para limpiar los datos 
        public void Limpiar()
        {
            txtCodeRol.Text = "";
            txtRol.Text = "";
            CargarDatos();
        }


        // metodo para seleccionar los radio button sea activo o inactivo
        public void Estados()
        {
            if (rbtnActive.Checked)
            {
                rbtnInactive.Checked = false;
                RolesE.RoleStatus = rbtnActive.Checked;
            }
            else if (rbtnInactive.Checked)
            {
                rbtnActive.Checked = false;
                RolesE.RoleStatus = rbtnInactive.Checked;
            }
        }

        public void EstadosModificacion()
        {
            if (rbtnActive.Checked)
            {
                rbtnInactive.Checked = false;
                RolesE.RoleStatus = rbtnActive.Checked;
            }
            else if (rbtnInactive.Checked)
            {
                rbtnActive.Checked = false;
                RolesE.RoleStatus = rbtnActive.Checked;
            }
        }


        //metodo para cargar los datos de SQL
        public void CargarDatos()
        {

            gvRoles.ReadOnly = true;
            gvRoles.DataSource = rolesN.ListaRoles();
        }

        private void Mantenimiento(string accion)
        {
            RolesE.RoleCode = txtCodeRol.Text;
            RolesE.RoleName = txtRol.Text;
            g.accion = accion;
            g.msj = rolesN.MantenimientoRoles(RolesE, g.accion);
            MessageBox.Show(g.msj, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion

        private void btnNew_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtRol.Text))
            {
                MessageBox.Show("Campos sin completar, por favor llenar los datos", "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (string.IsNullOrEmpty(txtCodeRol.Text))
            {
                // Pregunta si desea registrar el siguiente dato.
                if (MessageBox.Show($"¿Deseas registrar a {txtRol.Text}?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
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
            if (MessageBox.Show($"¿Deseas modificar {txtRol.Text}?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                EstadosModificacion();
                Mantenimiento("2");
                Limpiar();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Pregunta si desea eliminar el dato.
            if (MessageBox.Show($"¿Deseas eliminar {txtRol.Text}?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                Mantenimiento("3");
                Limpiar();
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

        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Roles_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }
    }
}
