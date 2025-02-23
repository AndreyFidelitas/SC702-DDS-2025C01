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
                    cmd.Parameters.AddWithValue("@TipoCilindroCode", TipoCilindro.TipoCilindroCode);
                    cmd.Parameters.AddWithValue("@LoteLitraje", TipoCilindro.LoteLitraje);
                    cmd.Parameters.AddWithValue("@TipoCilindroStatus", TipoCilindro.TipoCilindroStatus);
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
