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
                    // Se puede agregar el resto de los parámetros según el SP
                    cmd.Parameters.Add("@accion", SqlDbType.VarChar, 50).Value = g.accion;
                    cmd.Parameters["@accion"].Direction = ParameterDirection.InputOutput;
                    cmd.ExecuteNonQuery();
                    _conexion.CerrarConexion();
                    return cmd.Parameters["@accion"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                var value = ex.GetType().ToString();
                return value;
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
                                // Se mapean los campos devueltos por SPLogin a la entidad UsuariosE.
                                // Asegúrate de que los nombres de columna coincidan con los retornados por el SP.
                                UsuarioCode = dr["Usuario ID"].ToString(),
                                UsuarioName = dr["Nombre"].ToString(),
                                UsuarioApellidos = dr["Apellidos"].ToString(),
                                UsuarioUserName = dr["Nombre de Usuario"].ToString()
                                // Si el SP retorna datos de rol (ej. "Código Rol" o "Nombre Rol")
                                // se podrían agregar propiedades en UsuariosE o mapearlos en otra entidad.
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
    }
}
