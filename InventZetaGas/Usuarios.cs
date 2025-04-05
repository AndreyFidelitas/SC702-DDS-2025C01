using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Windows.Forms.VisualStyles;
using CapaDatos;
using CapaEntidades;
using CapaNegocios;
using static System.Windows.Forms.Design.AxImporter;


namespace InventZetaGas
{
    public partial class Usuarios : Form
    {
        UsuariosD userD = new UsuariosD();
        UsuariosE userE = new UsuariosE();
        UsuariosN userN = new UsuariosN();
        RolesN RolesN = new RolesN();
        Generales g = new Generales();
        private DataView dataView;


        public Usuarios()
        {
            InitializeComponent();
        }

        private void Usuarios_Load(object sender, EventArgs e)
        {
            CargarDatos();
            CargarListaRoles();
            cbRol.SelectedIndex = -1;
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void lblCode_Click(object sender, EventArgs e)
        {

        }

        private void lblPlaca_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Limpiar();
            rbtnActive.Checked = true;
        }

        private void gvUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            SeleecionarDatos(e);
        }

        //boton para buscar informacion
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //_ = BuscarAsync(2);
            BusquedaUser();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            MantenimientosBotones(1);
        }

        private void rbtnActive_CheckedChanged(object sender, EventArgs e)
        {
            Estados();
        }

        private void rbtnInactive_CheckedChanged(object sender, EventArgs e)
        {
            Estados();
        }

        //Metodo para cargar los datos en data grid view.
        private void CargarDatos()
        {
            gvUsuarios.ReadOnly = true;
            gvUsuarios.DataSource = userN.ListaUsuario();
        }

        //Boton para buscar la cedula del usuario.
        private void btnSearchID_Click(object sender, EventArgs e)
        {
            _ = BuscarAsync(1);
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            MantenimientosBotones(2);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            MantenimientosBotones(3);
        }

        #region Mantenimientos Generales
        //metodo para limpiar los campos
        private void Limpiar()
        {
            txtCedula.Text = "";
            txtCodeUser.Text = "";
            txtNombre.Text = "";
            txtApellidos.Text = "";
            txtContraseña.Text = "";
            txtUsuario.Text = "";
            cbRol.SelectedIndex = -1;
            CargarDatos();
        }

        // metodo para seleccionar los radio button sea activo o inactivo
        public void Estados()
        {
            if (rbtnActive.Checked)
            {
                rbtnInactive.Checked = false;
                userE.UsuarioEstado = rbtnActive.Checked;
            }
            else if (rbtnInactive.Checked)
            {
                rbtnActive.Checked = false;
                userE.UsuarioEstado = rbtnInactive.Checked;
            }
        }

        public void EstadosModificacion()
        {
            if (rbtnActive.Checked)
            {
                rbtnInactive.Checked = false;
                userE.UsuarioEstado = rbtnActive.Checked;
            }
            else if (rbtnInactive.Checked)
            {
                rbtnActive.Checked = false;
                userE.UsuarioEstado = rbtnActive.Checked;
            }
        }

        //metodo para cargar las provincias
        public void CargarListaRoles()
        {

            cbRol.DataSource = RolesN.CargarRoles();
            cbRol.DisplayMember = "Rol";
            cbRol.ValueMember = "Codigo Rol";
        }

        //************************************************************************************************
        private void Mantenimiento(string accion)
        {
            userE.UsuarioCode = txtCodeUser.Text;
            userE.Cedula = Int32.Parse(txtCedula.Text);
            userE.UsuarioName = txtNombre.Text;
            userE.UsuarioApellidos = txtApellidos.Text;
            userE.UsuarioUserName = txtUsuario.Text;
            userE.RoleID = Convert.ToInt32(cbRol.SelectedIndex + 2);
            userE.Password = txtContraseña.Text;
            g.accion = accion;
            g.msj = userN.MantenimientoUsuarios(userE, g.accion);
            MessageBox.Show(g.msj, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        //************************************************************************************************
        //metodo general de mantenimientos  
        public void MantenimientosBotones(int opcion)
        {
            string resultado = null;
            // Evaluamos la opción con un switch
            switch (opcion)
            {
                case 1:
                    if (!string.IsNullOrEmpty(txtCodeUser.Text))
                        MessageBox.Show("Campos sin completar, por favor llenar los datos", "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (ValidarCampos() == true)
                    {
                        if (MessageBox.Show($"¿Deseas registrar a {txtNombre.Text}?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
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
                    if (MessageBox.Show($"¿Deseas modificar {txtNombre.Text}?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        //metodo para validar los campos
                        if (ValidarCampos() == false)
                            MessageBox.Show("Campos sin completar, por favor llenar los datos", "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                        {
                            EstadosModificacion();
                            Mantenimiento("2");
                            Limpiar();
                        }
                    }
                    break;
                case 3:
                    // Pregunta si desea eliminar el dato.
                    if (MessageBox.Show($"¿Deseas eliminar {txtNombre.Text}?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        //metodo para validar los campos
                        if (ValidarCampos() == true)
                            MessageBox.Show("Campos sin completar, por favor llenar los datos", "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                        {
                            Mantenimiento("3");
                            Limpiar();
                        }
                    }
                    break;
            }
        }

        //************************************************************************************************
        //validacion de campos 
        // Método para verificar si los campos están vacíos
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
            if (string.IsNullOrEmpty(txtUsuario.Text))
            {
                return valid;
            }

            // Verifica si algún campo está vacío devuelve  un false
            if (cbRol.SelectedIndex == -1)
            {
                return valid;
            }

            // Verifica si algún campo está vacío devuelve  un false
            if (string.IsNullOrEmpty(txtContraseña.Text))
            {
                return valid;
            }

            valid = true;
            return valid;
        }
        //*************************************************************************************************
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
            // Evaluamos la opción con un switch
            switch (opcion)
            {
                case 1:
                    if (string.IsNullOrEmpty(txtCedula.Text))
                        Limpiar();
                    else
                    {
                        ApiResponse apiResponse = await userN.ObtenerDatosCedulaAsync(int.Parse(txtCedula.Text));
                        if (apiResponse != null)
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

                                txtNombre.Text = nombres;
                                txtApellidos.Text = apellidos;
                                txtUsuario.Text = GenerarNombreUsuario(nombres, apellidos);
                                txtContraseña.Text = GenerarContraseña(nombres, apellidos, txtCedula.Text);
                                rbtnActive.Checked = true;
                            }
                        }
                        else
                        {
                            MessageBox.Show("No se encontraron datos para la cédula ingresada", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Limpiar();
                        }
                    }
                    break;
                case 2:
                    // Obtén el DataTable de la lista de camiones
                    DataTable dt = userN.ListaUsuario();
                    dataView = dt.DefaultView;

                    string filtro = txtBuscar.Text.Trim();  // Obtén el texto del cuadro de búsqueda

                    // Si el filtro está vacío, muestra todos los registros
                    if (string.IsNullOrEmpty(filtro))
                    {
                        dataView.RowFilter = string.Empty;
                    }
                    else
                    {
                        // Aplica el filtro, ajusta según la columna y el valor
                        string filtroAplicado = "Cedula LIKE '%" + filtro + "%'";  // Filtra según la columna 'Marca'
                        dataView.RowFilter = filtroAplicado;


                        // Asigna el DataView al DataGridView para que se muestre el resultado filtrado
                        gvUsuarios.DataSource = dataView;

                        // Verifica si hay resultados después de aplicar el filtro
                        if (dataView.Count == 0)  // Si no hay registros que coincidan con el filtro
                        {
                            MessageBox.Show("No se encontraron resultados.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            // Muestra todos los registros si no se encuentran resultados
                            dataView.RowFilter = string.Empty;
                            gvUsuarios.DataSource = dataView;  // Asigna de nuevo los datos completos
                            txtBuscar.Text = "";
                        }
                    }
                break;
            }
        }

        public void SeleecionarDatos(DataGridViewCellEventArgs e)
        {
            // Verifica que el índice de fila sea válido
            if (e.RowIndex >= 0)
            {
                // Obtén la fila seleccionada
                DataGridViewRow row = gvUsuarios.Rows[e.RowIndex];
                // Asigna los valores de las celdas a los TextBox
                txtCodeUser.Text = row.Cells["Usuario ID"].Value?.ToString();
                txtCedula.Text = row.Cells["Cedula"].Value?.ToString();
                txtNombre.Text = row.Cells["Nombre"].Value?.ToString();
                txtApellidos.Text = row.Cells["Apellidos"].Value?.ToString();
                txtUsuario.Text = row.Cells["Nombre de Usuario"].Value?.ToString();
                cbRol.Text = row.Cells["ID Rol"].Value?.ToString();
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

        private void BusquedaUser()
        {
            // Obtén el DataTable de la lista de camiones
            DataTable dt = userN.ListaUsuario();
            dataView = dt.DefaultView;

            string filtro = txtBuscar.Text.Trim();  // Obtén el texto del cuadro de búsqueda

            // Si el filtro está vacío, muestra todos los registros
            if (string.IsNullOrEmpty(filtro))
            {
                dataView.RowFilter = string.Empty;
            }
            else
            {
                // Check if the 'Cedula' column is of type Int32
                if (dt.Columns["Cedula"].DataType == typeof(int))
                {
                    // If 'Cedula' is an integer, apply a numeric filter
                    int filtroInt;
                    if (int.TryParse(filtro, out filtroInt))
                    {
                        // Apply the filter for an integer column
                        string filtroAplicado = "Cedula = " + filtroInt.ToString();
                        dataView.RowFilter = filtroAplicado;
                    }
                    else
                    {
                        // If the filter text is not a valid integer, clear the filter
                        dataView.RowFilter = string.Empty;
                    }
                }
                else if (dt.Columns["Cedula"].DataType == typeof(string))
                {
                    // If 'Cedula' is a string, apply the LIKE filter
                    string filtroAplicado = "Cedula LIKE '%" + filtro + "%'";
                    dataView.RowFilter = filtroAplicado;
                }
            }

            // Assign the DataView to the DataGridView to show the filtered result
            gvUsuarios.DataSource = dataView;

            // Check if there are no results after applying the filter
            if (dataView.Count == 0)  // If no records match the filter
            {
                MessageBox.Show("No se encontraron resultados.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                // Show all records if no results found
                dataView.RowFilter = string.Empty;
                gvUsuarios.DataSource = dataView;  // Reassign the full data
                txtBuscar.Text = "";
            }
        }

        #endregion

        private void gbUsuarios_Enter(object sender, EventArgs e)
        {

        }
    }
}
