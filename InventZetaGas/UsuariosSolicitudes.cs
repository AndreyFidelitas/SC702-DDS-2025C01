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
    public partial class UsuariosSolicitudes : Form
    {
        RolesN RolesN = new RolesN();
        Generales g = new Generales();
        private DataView dataView;
        public UsuariosSolicitudes()
        {
            InitializeComponent();
        }

        private void UsuariosSolicitudes_Load(object sender, EventArgs e)
        {
            CargarListaRoles();
            cbRol.SelectedIndex = -1;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnAccept_Click(object sender, EventArgs e)
        {

        }

        private void btnRechazar_Click(object sender, EventArgs e)
        {

        }


        #region Metodos Generales
        //metodo para cargar las provincias
        public void CargarListaRoles()
        {
            cbRol.DataSource = RolesN.CargarRoles();
            cbRol.DisplayMember = "Rol";
            cbRol.ValueMember = "Codigo Rol";
        }
        #endregion
    }
}
