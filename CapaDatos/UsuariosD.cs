using System;
using System.Data;
using System.Data.SqlClient;
using CapaDatos.SQL;
using CapaEntidades;
using Newtonsoft.Json.Linq;
using System;
using System.Security.Cryptography;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace CapaDatos
{
    public class UsuariosD
    {
        private readonly ConexionDB _conexion = new ConexionDB();
        Generales g=new Generales();

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
                                RoleID = Convert.ToInt32(dr["RoleID"]),
                                UsuarioEstado = bool.Parse(dr["Estado"].ToString())
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

        #region "Verificar Sesión de Usuario"
        public bool VerificarSesion(string usuarioCode, string token)
        {
            bool sesionValida = false;
            try
            {
                using (var cmd = new SqlCommand("SPVerificarSesion", _conexion.AbrirConexion()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UsuarioCode", usuarioCode);
                    cmd.Parameters.AddWithValue("@token", token);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            sesionValida = true;
                        }
                    }
                    _conexion.CerrarConexion();
                }
            }
            catch (Exception)
            {
                sesionValida = false;
            }
            return sesionValida;
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


        #region "Mantenimiento de Clientes"
        public string MantenimientoSolicitudUsuarios(UsuariosSolicitud usuarioS, string accion)
        {
            try
            {
                Generales g = new Generales();
                g.accion = accion;
                using (var cmd = new SqlCommand("sp_ManageUsuariosSolicitud", _conexion.AbrirConexion()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SolicitudCode", usuarioS.SolicitudCode);
                    cmd.Parameters.AddWithValue("@Cedula", usuarioS.Cedula);
                    cmd.Parameters.AddWithValue("@Name", usuarioS.Name);
                    cmd.Parameters.AddWithValue("@Apellidos", usuarioS.Apellidos);
                    if(accion =="2")
                    {
                        if (usuarioS.SolcitudEstado==false)
                            cmd.Parameters.AddWithValue("@SolcitudRechaza", DateTime.Now);
                        else
                            cmd.Parameters.AddWithValue("@SolcitudAceptada", DateTime.Now);
                        cmd.Parameters.AddWithValue("@SolcitudEstado ", usuarioS.SolcitudEstado);
                        //cmd.Parameters.AddWithValue("@UsuarioCedula", usuarioS.UsuarioID);
                    }
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
                g.modulo = "Mantenimiento Solicitud Usuarios" + "\n" + "Modulo de Mantenimiento Usuarios";
                g.msj = ex.Message;
                return g.msj;
            }
        }
        #endregion


        #region "MostrarListaUsuarios"
        public DataTable ListarSolicitudUsuarios()
        {
            using (var cmd = new SqlCommand("SPListaSolicitudUsuarios", _conexion.AbrirConexion()))
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
        //*********************************************************************************************
        //Metodos para traer la informacion o la cuenta a recuperar.
        [Obsolete]
        public bool ValidarSolicitudUsuario(UsuariosSolicitud users)
        {
            bool value;
            UsuariosSolicitud usuario = null;
            try
            {
                using (var cmd = new SqlCommand("ValidarUsuario", _conexion.AbrirConexion()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Cedula", users.Cedula);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            usuario = new UsuariosSolicitud
                            {
                                SolicitudCode = dr["Usuario ID"].ToString(),
                                Cedula = int.Parse(dr["Cedula"].ToString()),
                                Name = dr["Nombre"].ToString(),
                                Apellidos = dr["Apellidos"].ToString(),
                                SolcitudEstado = bool.Parse(dr["Estado"].ToString())
                            };
                        }
                    }
                    _conexion.CerrarConexion();
                    if (usuario != null)
                        value = true;
                    else
                        value = false;
                }
            }
            catch (Exception ex)
            {
                value = false;
                g.modulo = "Validar Solicitud Usuarios"+"\n"+"Modulo de Solicitud Usuarios";
                g.msj= ex.Message;  
            }
            return value;
        }
        //************************************************************************************************
    }
}