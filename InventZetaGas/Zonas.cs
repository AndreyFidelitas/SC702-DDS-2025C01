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
    public partial class Zonas : Form
    {
        ZonasN ZonasN=new ZonasN();
        ZonasE ZonasE=new ZonasE();

        public Zonas()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {

        }

        private void Zonas_Load(object sender, EventArgs e)
        {
            gvZonas.DataSource = ZonasN.ListaZona();
        }
    }
}
