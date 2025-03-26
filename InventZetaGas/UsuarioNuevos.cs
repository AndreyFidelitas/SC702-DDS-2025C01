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
    public partial class UsuarioNuevos : Form
    {
        public UsuarioNuevos()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            UsuariosNuevo();
        }

        #region metodos generales
        private void UsuariosNuevo()
        {
            // Abrir el formulario de inicio y redirigir al usuario
            UsuarioNuevos usuarionuevo = new UsuarioNuevos();
            usuarionuevo.Show();
            this.Hide();
        }
        #endregion
    }
}
