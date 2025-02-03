using CapaDatos;
using CapaEntidades;
using System.Data;

namespace CapaNegocios
{
    public  class UsuariosN
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
    }
}
