using CapaDatos;
using CapaEntidades;
using System.Data;

namespace CapaNegocios
{
    public class ClientesN
    {
        ClientesD ClientesD = new ClientesD();

        public string MantenimientoClientes(ClientesE Clientes, string accion)
        {
            //return Clientes. (Clientes, accion);
            return ClientesD.MantenimientoClientes(Clientes, accion);
        }

        public DataTable ListaClientes()
        {
            return ClientesD.ListarClientes();
        }
    }
}
