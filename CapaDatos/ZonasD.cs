using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using CapaDatos.SQL;
using CapaEntidades;

namespace CapaDatos
{
    public class ZonasD
    {
            private readonly ConexionDB _conexion = new ConexionDB();

            #region "MostrarListaZonas"
            public DataTable ListarZonas()
            {
                using (var connection = _conexion.AbrirConexion())
                using (var cmd = new SqlCommand("SPListaZonas", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    var dataTable = new DataTable();
                    using (var dataAdapter = new SqlDataAdapter(cmd))
                    {
                        dataAdapter.Fill(dataTable);
                    }
                    return dataTable;
                }
            }
            #endregion

            #region "Mantenimiento de Zonas"
            public string MantenimientoZonas(ZonasE zonas)
            {
                try
                {
                    Generales g= new Generales();
                    using (var connection = _conexion.AbrirConexion())
                    using (var cmd = new SqlCommand("SPCatalogozonas", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ProvinciaID", zonas.ProvinciaID);
                        cmd.Parameters.AddWithValue("@ZonasCode", zonas.ZonasCode);
                        cmd.Parameters.AddWithValue("@ZonasName", zonas.ZonasName);
                        cmd.Parameters.AddWithValue("@ZonasStatus", zonas.ZonasEstado);
                        cmd.Parameters.Add("@accion", SqlDbType.VarChar, 50).Value = g.accion;
                        cmd.Parameters["@accion"].Direction = ParameterDirection.InputOutput;
                        cmd.ExecuteNonQuery();

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
