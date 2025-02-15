using System;
using System.Data;
using System.Data.SqlClient;
using CapaDatos.SQL;
using CapaEntidades;

namespace CapaDatos
{
    public class UsuariosD
    {
        private readonly ConexionDB _conexion = new ConexionDB();

        #region "MostrarListaUsuarios"
        public DataTable ListarUsuarios()
        {
            using (var cmd = new SqlCommand("SPListaUsuarios", _conexion.AbrirConexion()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                var dataTable = new DataTable();
                using (var dataAdapter = new SqlDataAdapter(cmd))
                {
                    dataAdapter.Fill(dataTable);
                }
                _conexion.CerrarConexion();
                return dataTable;
            }
        }
        #endregion

        #region "Mantenimiento de Usuarios"
        public string MantenimientoUsuarios(UsuariosE Usuarios, string accion)
        {
            try
            {
                Generales g = new Generales();
                g.accion = accion;
                using (var cmd = new SqlCommand("SPMantenimientoUsuarios", _conexion.AbrirConexion()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UsuarioCode", Usuarios.UsuarioCode);
                    cmd.Parameters.AddWithValue("@UsuarioName", Usuarios.UsuarioName);
                    // Agrega aquí los demás parámetros que tu SP requiera
                    cmd.Parameters.Add("@accion", SqlDbType.VarChar, 50).Value = g.accion;
                    cmd.Parameters["@accion"].Direction = ParameterDirection.InputOutput;
                    cmd.ExecuteNonQuery();
                    _conexion.CerrarConexion();
                    return cmd.Parameters["@accion"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                return ex.GetType().ToString();
            }
        }
        #endregion

        #region "Login de Usuario"
        public UsuariosE LoginUsuario(string usuarioUserName, string password, out string msj)
        {
            msj = "";
            UsuariosE usuario = null;
            try
            {
                using (var cmd = new SqlCommand("SPLogin", _conexion.AbrirConexion()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UsuarioUserName", usuarioUserName);
                    cmd.Parameters.AddWithValue("@Password", password);

                    // Parámetro de salida para el mensaje
                    SqlParameter mensajeParam = new SqlParameter("@Mensaje", SqlDbType.NVarChar, 255)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(mensajeParam);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            usuario = new UsuariosE
                            {
                                // Asegúrate de mapear correctamente los nombres de columna que retorna el SP.
                                UsuarioCode = dr["Usuario ID"].ToString(),
                                UsuarioName = dr["Nombre"].ToString(),
                                UsuarioApellidos = dr["Apellidos"].ToString(),
                                UsuarioUserName = dr["Nombre de Usuario"].ToString(),
                                // Si manejas la contraseña en el login, asegúrate de asignarla (o dejarla vacía por seguridad)
                                Password = password,
                                // Puedes asignar otros datos, por ejemplo, RoleID, etc.
                            };
                        }
                    }
                    _conexion.CerrarConexion();
                    msj = mensajeParam.Value.ToString();
                }
            }
            catch (Exception ex)
            {
                msj = ex.Message;
            }
            return usuario;
        }
        #endregion

        #region "Actualizar Token de Usuario"
        public string ActualizarTokenUsuario(UsuariosE usuario)
        {
            try
            {
                using (var cmd = new SqlCommand("SPMantenimientoUsuarios", _conexion.AbrirConexion()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    // Se deben enviar todos los parámetros requeridos para la acción de actualización.
                    cmd.Parameters.AddWithValue("@UsuarioCode", usuario.UsuarioCode);
                    cmd.Parameters.AddWithValue("@UsuarioName", usuario.UsuarioName);
                    cmd.Parameters.AddWithValue("@UsuarioApellidos", usuario.UsuarioApellidos);
                    cmd.Parameters.AddWithValue("@UsuarioUserName", usuario.UsuarioUserName);
                    cmd.Parameters.AddWithValue("@Password", usuario.Password);
                    cmd.Parameters.AddWithValue("@token", usuario.token);
                    // Asegúrate de enviar el RoleID y el estado actual del usuario
                    cmd.Parameters.AddWithValue("@RoleID", usuario.RoleID);
                    cmd.Parameters.AddWithValue("@UsuarioEstado", usuario.UsuarioEstado);

                    // La acción "2" representa la actualización.
                    cmd.Parameters.Add("@accion", SqlDbType.VarChar, 50).Value = "2";
                    cmd.Parameters["@accion"].Direction = ParameterDirection.InputOutput;
                    cmd.ExecuteNonQuery();
                    _conexion.CerrarConexion();
                    return cmd.Parameters["@accion"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        #endregion
    }
}
