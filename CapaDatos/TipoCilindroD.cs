using CapaDatos.SQL;
using CapaEntidades;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class TipoCilindroD
    {
        private readonly ConexionDB _conexion = new ConexionDB();

        #region "MostrarListaTipoCilindro"
        public DataTable ListaTipoCilindro()
        {
            using (var cmd = new SqlCommand("SPListaCilindro", _conexion.AbrirConexion()))
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


        #region "Mantenimiento de TipoCilindro"
        public string MantenimientoTipoCilindro(TipoCilindro TipoCilindro, string accion)
        {
            try
            {

                Generales g = new Generales();
                g.accion = accion;
                using (var cmd = new SqlCommand("SPMantenimientoTipoCilindro", _conexion.AbrirConexion()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    var pCode = cmd.Parameters.Add("@TipoCilindroCode", SqlDbType.VarChar, 5);
                    pCode.Value = (object?)TipoCilindro.TipoCilindroCode ?? DBNull.Value;

                    var pLote = cmd.Parameters.Add("@LoteLitraje", SqlDbType.VarChar, 100);
                    pLote.Value = (object?)TipoCilindro.LoteLitraje ?? string.Empty;

                    var pStatus = cmd.Parameters.Add("@TipoCilindroStatus", SqlDbType.Bit);
                    pStatus.Value = TipoCilindro.TipoCilindroStatus;
                    cmd.Parameters.Add("@accion", SqlDbType.VarChar, 50).Value = g.accion;
                    cmd.Parameters["@accion"].Direction = ParameterDirection.InputOutput;
                    cmd.ExecuteNonQuery();
                    _conexion.CerrarConexion();
                    return cmd.Parameters["@accion"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                return LogsInserted(ex.ToString());
            }
        }
        #endregion


        [Obsolete]
        private string LogsInserted(string ex)
        {
            LogsD log = new LogsD();
            LogsE logE = new LogsE();

            logE.UsuarioID = 0;
            logE.TablaAfectada = "TipoCilindro";
            logE.Modulo = "TipoCilindro";
            logE.Detalles = ex;
            var value = log.MantenimientoLogs(logE, "1");
            return value.ToString();
        }
    }
}
