using CapaDatos;
using CapaEntidades;
using System.Data;

namespace CapaNegocios
{
    public class UsuariosN
    {
        UsuariosD UsuariosD = new UsuariosD();

        public string MantenimientoUsuarios(UsuariosE Usuario, string accion)
        {
            return UsuariosD.MantenimientoUsuarios(Usuario, accion);
        }

        public DataTable ListaUsuario()
        {
            return UsuariosD.ListarUsuarios();
        }

        // Método para el login
        public UsuariosE LoginUsuario(string usuarioUserName, string password, out string msj)
        {
            return UsuariosD.LoginUsuario(usuarioUserName, password, out msj);
        }

        // Método para actualizar el token del usuario
        public string ActualizarTokenUsuario(UsuariosE usuario)
        {
            return UsuariosD.ActualizarTokenUsuario(usuario);
        }
    }
}
