using CapaDatos.SQL;
using CapaEntidades;
using System.Data.SqlClient;
using System.Data;


namespace CapaDatos
{
    public class LogsD
    {
        private readonly ConexionDB _conexion = new ConexionDB();

        #region "Mantenimiento de RolesE"
        [Obsolete]
        public string MantenimientoLogs(LogsE LogsE, string accion)
        {
            try
            {
                Generales g = new Generales();
                g.accion = accion;
                using (var cmd = new SqlCommand("SPMantenimientoRoles", _conexion.AbrirConexion()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UsuarioID", LogsE.UsuarioID);
                    cmd.Parameters.AddWithValue("@TablaAfectada", LogsE.TablaAfectada);
                    cmd.Parameters.AddWithValue("@Modulo", LogsE.Modulo);
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
