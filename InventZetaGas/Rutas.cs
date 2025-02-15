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

namespace InventZetaGas
{
    public partial class Rutas : Form
    {

        Rutas r =new Rutas();
        RutasE rE=new RutasE();

        #region Funciones del formulario
        public Rutas()
        {
            InitializeComponent();
        }

        private void gvRutas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnNew_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void btnModify_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void rbtnActive_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rbtnInactive_CheckedChanged(object sender, EventArgs e)
        {

        }
        #endregion
        //**********************************************************************
        #region Metodo generales

        public void Limpiar()
        {
            txtCodeRuta.Text = "";
            txtRuta.Text = "";
        }

        public void CargarDatos() 
        {
            
        }
        #endregion
        //**********************************************************************
    }
}
