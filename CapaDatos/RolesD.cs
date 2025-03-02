using CapaDatos.SQL;
using CapaEntidades;
using System.Data.SqlClient;
using System.Data;


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


        #region "MostrarListaRoles"
        public DataTable CargaRoles()
        {
            using (var cmd = new SqlCommand("SPCargaRoles", _conexion.AbrirConexion()))
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

        #region "Mantenimiento de RolesE"
        public string MantenimientoRoles(RolesE RolesE, string accion)
        {
            try
            {

                Generales g = new Generales();
                g.accion = accion;
                using (var cmd = new SqlCommand("SPMantenimientoRoles", _conexion.AbrirConexion()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@RoleCode", RolesE.RoleCode);
                    cmd.Parameters.AddWithValue("@RoleName", RolesE.RoleName);
                    cmd.Parameters.AddWithValue("@RoleStatus", RolesE.RoleStatus);
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
    }
}
