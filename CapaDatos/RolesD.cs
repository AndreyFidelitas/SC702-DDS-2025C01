using CapaDatos.SQL;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class RolesD
    {
        private readonly ConexionDB _conexion = new ConexionDB();

        #region "MostrarListaRoles"
        public DataTable ListarRoles()
        {
            using (var cmd = new SqlCommand("SPListaRoles", _conexion.AbrirConexion()))
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


    }
}
