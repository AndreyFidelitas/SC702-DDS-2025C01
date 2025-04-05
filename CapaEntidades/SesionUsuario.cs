using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    /// <summary>
    /// Clase para manejar las variables de sesión del usuario
    /// </summary>
    public static class SesionUsuario
    {
        // Propiedades estáticas para almacenar la información del usuario en sesión
        public static string UsuarioID { get; set; }
        public static string UsuarioCode { get; set; }
        public static string Nombre { get; set; }
        public static string Apellidos { get; set; }
        public static string UsuarioUserName { get; set; }
        public static int RoleID { get; set; }
        public static string RoleName { get; set; }
        public static string Token { get; set; }
        public static bool UsuarioEstado { get; set; }
        public static DateTime FechaInicioSesion { get; set; }

        /// <summary>
        /// Inicializa la sesión con los datos del usuario
        /// </summary>
        /// <param name="usuario">Objeto UsuariosE con los datos del usuario</param>
        public static void IniciarSesion(UsuariosE usuario)
        {
            UsuarioID = usuario.UsuarioID.ToString();
            UsuarioCode = usuario.UsuarioCode;
            Nombre = usuario.UsuarioName;
            Apellidos = usuario.UsuarioApellidos;
            UsuarioUserName = usuario.UsuarioUserName;
            RoleID = usuario.RoleID;
            Token = usuario.token;
            UsuarioEstado = usuario.UsuarioEstado;
            FechaInicioSesion = DateTime.Now;
        }

        /// <summary>
        /// Cierra la sesión del usuario
        /// </summary>
        public static void CerrarSesion()
        {
            UsuarioID = null;
            UsuarioCode = null;
            Nombre = null;
            Apellidos = null;
            UsuarioUserName = null;
            RoleID = 0;
            RoleName = null;
            Token = null;
            UsuarioEstado = false;
            FechaInicioSesion = DateTime.MinValue;
        }

        /// <summary>
        /// Verifica si hay una sesión activa
        /// </summary>
        /// <returns>True si hay una sesión activa, False en caso contrario</returns>
        public static bool SesionActiva()
        {
            return !string.IsNullOrEmpty(UsuarioCode) && UsuarioEstado;
        }

        /// <summary>
        /// Obtiene el nombre completo del usuario
        /// </summary>
        /// <returns>Nombre completo del usuario</returns>
        public static string ObtenerNombreCompleto()
        {
            return $"{Nombre} {Apellidos}";
        }
    }
} 