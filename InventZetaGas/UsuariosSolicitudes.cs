using CapaEntidades;
using CapaNegocios;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.Design.AxImporter;

namespace InventZetaGas
{
    public partial class UsuariosSolicitudes : Form
    {
        RolesN RolesN = new RolesN();
        UsuariosN userN = new UsuariosN();
        UsuariosE userE = new UsuariosE();
        UsuariosSolicitud SuserE = new UsuariosSolicitud();
        Generales g = new Generales();
        private DataView dataView;


        public UsuariosSolicitudes()
        {
            InitializeComponent();
        }

        private void UsuariosSolicitudes_Load(object sender, EventArgs e)
        {
            CargarListaRoles();
            CargarDatos();
            cbRol.SelectedIndex = -1;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private async void btnAccept_Click(object sender, EventArgs e)
        {
            await BuscarAsync(1);
        }

        private void btnRechazar_Click(object sender, EventArgs e)
        {

        }

        private void gvSolicitudU_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            SeleecionarDatos(e);
        }

        #region Metodos Generales
        //metodo para cargar las provincias

        public void Limpiar()
        {
            txtcode.Text = "";
            txtCedula.Text = "";
            txtNombre.Text = "";
            txtApellidos.Text = "";
            CargarDatos();
        }

        public void SeleecionarDatos(DataGridViewCellEventArgs e)
        {
            // Verifica que el índice de fila sea válido
            if (e.RowIndex >= 0)
            {
                // Obtén la fila seleccionada
                DataGridViewRow row = gvSolicitudU.Rows[e.RowIndex];
                // Asigna los valores de las celdas a los TextBox
                txtcode.Text = row.Cells["Solicitud Code"].Value?.ToString();
                txtCedula.Text = row.Cells["Cedula"].Value?.ToString();
                txtNombre.Text = row.Cells["Nombre"].Value?.ToString();
                txtApellidos.Text = row.Cells["Apellidos"].Value?.ToString();
            }
        }

        public void CargarListaRoles()
        {
            cbRol.DataSource = RolesN.CargarRoles();
            cbRol.DisplayMember = "Rol";
            cbRol.ValueMember = "Codigo Rol";
        }

        public void CargarDatos()
        {
            gvSolicitudU.ReadOnly = true;
            gvSolicitudU.DataSource = userN.ListaSolicitudUsuario();
        }

        private string GenerarNombreUsuario(string nombre, string apellidos)
        {
            string nombreUsuario = "";

            // Obtener las partes del nombre y apellidos
            string[] partesNombre = nombre.Split(' ');
            string[] partesApellidos = apellidos.Split(' ');

            // Tomar la primera letra del primer nombre
            if (partesNombre.Length > 0 && partesNombre[0].Length > 0)
                nombreUsuario += partesNombre[0].Substring(0, 1).ToUpper();

            // Tomar la primera letra del segundo nombre si existe
            if (partesNombre.Length > 1 && partesNombre[1].Length > 0)
                nombreUsuario += partesNombre[1].Substring(0, 1).ToUpper();

            // Agregar el primer apellido completo
            if (partesApellidos.Length > 0)
                nombreUsuario += partesApellidos[0].ToUpper();

            // Agregar la primera letra del segundo apellido
            if (partesApellidos.Length > 1 && partesApellidos[1].Length > 0)
                nombreUsuario += partesApellidos[1].Substring(0, 1).ToUpper();

            return nombreUsuario;
        }

        private string GenerarContraseña(string nombre, string apellidos, string cedula)
        {
            string contraseña = "";

            try
            {
                // Obtener partes del nombre y apellidos
                string[] partesNombre = nombre.Split(' ');
                string[] partesApellidos = apellidos.Split(' ');

                // Primera letra del primer nombre en mayúscula
                if (partesNombre.Length > 0 && partesNombre[0].Length > 0)
                    contraseña += partesNombre[0].Substring(0, 1).ToUpper();

                // Primeras dos letras del primer apellido en minúscula
                if (partesApellidos.Length > 0 && partesApellidos[0].Length >= 2)
                    contraseña += partesApellidos[0].Substring(0, 2).ToLower();

                // Últimos 4 dígitos de la cédula
                if (cedula.Length >= 4)
                    contraseña += cedula.Substring(cedula.Length - 4);

                // Primera letra del segundo apellido en mayúscula
                if (partesApellidos.Length > 1 && partesApellidos[1].Length > 0)
                    contraseña += partesApellidos[1].Substring(0, 1).ToUpper();

                // Agregar un carácter especial
                contraseña += "@";
            }
            catch
            {
                // Si hay algún error, crear una contraseña básica
                contraseña = "Pass" + cedula.Substring(cedula.Length - 4) + "@";
            }

            return contraseña;
        }

        public async Task BuscarAsync(int opcion)
        {
            // Verificar si hay una sesión activa
            if (!SesionUsuario.SesionActiva())
            {
                MessageBox.Show("No hay una sesión activa. Por favor, inicie sesión nuevamente.", "Error de sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                return;
            }

            //****************************************************************************************
            // Evaluamos la opción con un switch
            switch (opcion)
            {
                case 1:
                    if (string.IsNullOrEmpty(txtCedula.Text))
                        Limpiar();
                    else
                    {
                        ApiResponse apiResponse = await userN.ObtenerDatosCedulaAsync(int.Parse(txtCedula.Text));
                        if (apiResponse.Cedula != null)
                        {
                            if (ValidarCampos() == false)
                            {
                                MessageBox.Show("Campos sin completar, por favor llenar los datos", "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Limpiar();
                            }
                            else
                            { 
                                string[] nombreCompleto = apiResponse.Nombre.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                                if (nombreCompleto.Length > 0)
                                {
                                    string nombres = "";
                                    string apellidos = "";

                                    // Si solo hay una parte, asumimos que es nombre
                                    if (nombreCompleto.Length == 1)
                                    {
                                        nombres = nombreCompleto[0];
                                    }
                                    // Si hay dos partes, asumimos nombre y apellido
                                    else if (nombreCompleto.Length == 2)
                                    {
                                        nombres = nombreCompleto[0];
                                        apellidos = nombreCompleto[1];
                                    }
                                    // Si hay tres partes, asumimos un nombre y dos apellidos
                                    else if (nombreCompleto.Length == 3)
                                    {
                                        nombres = nombreCompleto[0];
                                        apellidos = nombreCompleto[1] + " " + nombreCompleto[2];
                                    }
                                    // Si hay cuatro o más partes
                                    else if (nombreCompleto.Length >= 4)
                                    {
                                        nombres = nombreCompleto[0] + " " + nombreCompleto[1];
                                        apellidos = nombreCompleto[2] + " " + nombreCompleto[3];
                                    }
                                    userE.UsuarioCode = "U0000";
                                    userE.Cedula= int.Parse(txtCedula.Text);
                                    userE.UsuarioName = nombres;
                                    userE.UsuarioApellidos = apellidos;
                                    userE.UsuarioUserName = GenerarNombreUsuario(nombres, apellidos);
                                    userE.Password = GenerarContraseña(nombres, apellidos, txtCedula.Text);
                                    userE.RoleID= cbRol.SelectedIndex+2;
                                    userE.UsuarioEstado = true;

                                    userN.MantenimientoUsuarios(userE, "1");

                                    SuserE.SolcitudEstado = true;
                                    Mantenimiento("2");

                                    Limpiar();
                                }
                            }
                        }
                        else
                        {
                            if (ValidarCampos() == true)
                            {
                                SuserE.SolcitudEstado = false;
                               Mantenimiento("2");
                               Limpiar(); 
                            }
                            else
                            {
                                MessageBox.Show("Campos sin completar, por favor llenar los datos", "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Limpiar();
                            }
                        }
                    }
                    break;
            }
        }

        //****************************************************************************************
        public bool ValidarCampos()
        {
            bool valid = false;

            // Verifica si algún campo está vacío devuelve  un false
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                return valid;
            }

            // Verifica si algún campo está vacío devuelve  un false
            if (string.IsNullOrEmpty(txtApellidos.Text))
            {
                return valid;
            }

            // Verifica si algún campo está vacío devuelve  un false
            if (string.IsNullOrEmpty(txtCedula.Text))
            {
                return valid;
            }

            if (cbRol.SelectedIndex==-1)
            {
                return valid;
            }

            valid = true;
            return valid;
        }
        //****************************************************************************************
        private void Mantenimiento(string accion)
        {
            SuserE.SolicitudCode = txtcode.Text; 
            SuserE.Cedula = Int32.Parse(txtCedula.Text);
            SuserE.Name = txtNombre.Text;
            SuserE.Apellidos = txtApellidos.Text;
            g.accion = accion;
            g.msj = userN.MantenimientoSolicitudUsuarios(SuserE, g.accion);
        }
        //****************************************************************************************
        #endregion
    }
}
