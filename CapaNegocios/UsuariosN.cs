using CapaDatos;
using CapaEntidades;
using System.Data;
using CapaDatos.API;

namespace CapaNegocios
{
    public class UsuariosN
    {
        UsuariosD UsuariosD = new UsuariosD();
        ApiClientes api =new ApiClientes();

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
        public string ActualizarToken(string usuarioCode, string token)
        {
            return UsuariosD.ActualizarToken(usuarioCode, token);
        }

        //metodo tipo api para obtener la informacion de los usuarios
        public async Task<ApiResponse> ObtenerDatosCedulaAsync(int ID)
        {
            var value = await api.ObtenerDatosCedulaAsync(ID);
            return value;
        }
    }
}
