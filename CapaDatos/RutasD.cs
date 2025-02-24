﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using CapaDatos.SQL;
using CapaEntidades;


namespace CapaDatos
{
    public class RutasD
    {

        private readonly ConexionDB _conexion = new ConexionDB();

        #region "MostrarListaZonas"
        public DataTable ListarZonas()
        {
            using (var cmd = new SqlCommand("SPListaRutas", _conexion.AbrirConexion()))
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

        // metodo de mantenimiento de Zonas
        #region "Mantenimiento de Zonas"
        public string MantenimientoRutas(RutasE rutas, string accion)
        {
            try
            {

                Generales g = new Generales();
                g.accion = accion;
                using (var cmd = new SqlCommand("SPMantenimientoRutas", _conexion.AbrirConexion()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@RutaCode", rutas.RutaCode);
                    cmd.Parameters.AddWithValue("@Ruta", rutas.Ruta);
                    cmd.Parameters.AddWithValue("@RutaStatus", rutas.RutaStatus);
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
