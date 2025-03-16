using System;
using System.Data;
using System.Data.SqlClient;
using CapaDatos.SQL;
using CapaEntidades;
using Newtonsoft.Json.Linq;
using System;
using System.Security.Cryptography;

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
                    cmd.Parameters.AddWithValue("@Cedula", Usuarios.Cedula);
                    cmd.Parameters.AddWithValue("@UsuarioName", Usuarios.UsuarioName);
                    cmd.Parameters.AddWithValue("@UsuarioApellidos", Usuarios.UsuarioApellidos);
                    cmd.Parameters.AddWithValue("@UsuarioUserName", Usuarios.UsuarioUserName);
                    cmd.Parameters.AddWithValue("@Password", Usuarios.Password);
                    cmd.Parameters.AddWithValue("@token", Usuarios.token= GenerateToken());
                    cmd.Parameters.AddWithValue("@RoleID", Usuarios.RoleID);
                    cmd.Parameters.AddWithValue("@UsuarioEstado", Usuarios.UsuarioEstado);
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
                                UsuarioCode = dr["Usuario ID"].ToString(),
                                UsuarioName = dr["Nombre"].ToString(),
                                UsuarioApellidos = dr["Apellidos"].ToString(),
                                UsuarioUserName = dr["Nombre de Usuario"].ToString(),
                                RoleID = Convert.ToInt32(dr["RoleID"])
                                // Puedes mapear RoleCode y RoleName si los necesitas
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
        public string ActualizarToken(string usuarioCode, string token)
        {
            string mensaje = "";
            try
            {
                using (var cmd = new SqlCommand("SPActualizarToken", _conexion.AbrirConexion()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UsuarioCode", usuarioCode);
                    cmd.Parameters.AddWithValue("@token", token);

                    SqlParameter mensajeParam = new SqlParameter("@Mensaje", SqlDbType.NVarChar, 255)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(mensajeParam);

                    cmd.ExecuteNonQuery();
                    mensaje = mensajeParam.Value.ToString();
                    _conexion.CerrarConexion();
                }
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
            }
            return mensaje;
        }
        #endregion

        //**********************************************************************
        //Metodos para traer la informacion o la cuenta a recuperar.
        [Obsolete]
        public string RecuperarContrasena(UsuariosE users)
        {
            string msj = "";
            UsuariosE usuario = null;
            try
            {
                using (var cmd = new SqlCommand("ValidarUsuario", _conexion.AbrirConexion()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Cedula", users.Cedula);
                    cmd.Parameters.AddWithValue("@UsuarioUserName", users.UsuarioUserName);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            usuario = new UsuariosE
                            {
                                UsuarioCode = dr["Usuario ID"].ToString(),
                                Cedula = int.Parse(dr["Cedula"].ToString()),
                                UsuarioName = dr["Nombre"].ToString(),
                                UsuarioApellidos = dr["Apellidos"].ToString(),
                                UsuarioUserName = dr["Nombre de Usuario"].ToString(),
                                Password = dr["Contraseña"].ToString()
                            };
                        }
                    }
                    _conexion.CerrarConexion();
                    msj = usuario.Password;
                }
            }
            catch (Exception ex)
            {
                msj = "";
            }
            return msj;
        }

        private  string GenerateToken(int length = 32)
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                byte[] tokenData = new byte[length];
                rng.GetBytes(tokenData);
                return Convert.ToBase64String(tokenData);
            }
        }
    }
}