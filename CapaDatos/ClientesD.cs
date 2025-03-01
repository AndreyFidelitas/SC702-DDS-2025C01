using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos.SQL;
using CapaEntidades;

namespace CapaDatos
{
    public class ClientesD
    {
        private readonly ConexionDB _conexion = new ConexionDB();
        #region "MostrarListaClientes"
        public DataTable ListarClientes()
        {
            using (var cmd = new SqlCommand("SPListaClientes", _conexion.AbrirConexion()))
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

        #region "Mantenimiento de Clientes"
        public string MantenimientoClientes(ClientesE clientesE, string accion)
        {
            try
            {
                Generales g = new Generales();
                g.accion = accion;
                using (var cmd = new SqlCommand("SPMantenimientoClientes", _conexion.AbrirConexion()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ClientesCode", clientesE.ClientesCode);
                    cmd.Parameters.AddWithValue("@RazonSocial", clientesE.RazonSocial);
                    cmd.Parameters.AddWithValue("@Empresa", clientesE.Empresa);
                    cmd.Parameters.AddWithValue("@ClientesRol", clientesE.ClientesRol);
                    cmd.Parameters.AddWithValue("@ClientesStatus", clientesE.ClientesStatus);
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


    }
}
