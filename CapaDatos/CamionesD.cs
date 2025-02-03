using System;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using CapaDatos.SQL;
using CapaEntidades;

namespace CapaDatos
{
    public class CamionesD
    {
        private readonly ConexionDB _conexion = new ConexionDB();
        #region "MostrarListaCamiones"
        public DataTable ListarCamiones()
        {
            using (var cmd = new SqlCommand("SPListaCamiones", _conexion.AbrirConexion()))
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

        #region "Mantenimiento de Camiones"
        public string MantenimientoCamiones(CamionesE camiones, string accion)
        {
            try
            {

                Generales g = new Generales();
                g.accion = accion;
                using (var cmd = new SqlCommand("SPMantenimientoCamiones", _conexion.AbrirConexion()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CamionCode", camiones.CamionCode);
                    cmd.Parameters.AddWithValue("@CamionName", camiones.CamionName);
                    cmd.Parameters.AddWithValue("@CamionPlaca", camiones.CamionPlaca);
                    cmd.Parameters.AddWithValue("@CamionPesaje", camiones.CamionPesaje);
                    cmd.Parameters.AddWithValue("@CamionStatus", camiones.CamionStatus);
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
