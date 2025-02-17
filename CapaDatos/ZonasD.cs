﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using CapaDatos.SQL;
using CapaEntidades;

namespace CapaDatos
{
    public class ZonasD
    {
        //Conexion para la capa datos
        private readonly ConexionDB _conexion = new ConexionDB();

        
        #region "MostrarListaZonas"

        //Metodo para mostrar las zonas
        public DataTable ListarZonas()
            {
                using (var cmd = new SqlCommand("SPListaZonas", _conexion.AbrirConexion()))
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

        #region "MostrarListaProvincias"
        public DataTable ListarProvincias()
        {
            using (var cmd = new SqlCommand("SPListaProvincias", _conexion.AbrirConexion()))
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

        #region "Mantenimiento de Zonas"
        public string MantenimientoZonas(ZonasE zonas,string accion)
        //Metodo para insertar y actualizar zonas
        {
            try
                {
                    
                    Generales g= new Generales();
                    g.accion = accion;
                    using (var cmd = new SqlCommand("SPMantenimientoZonas", _conexion.AbrirConexion()))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ProvinciaID", zonas.ProvinciaID);
                        cmd.Parameters.AddWithValue("@ZonasCode", zonas.ZonasCode);
                        cmd.Parameters.AddWithValue("@ZonasName", zonas.ZonasName);
                        cmd.Parameters.AddWithValue("@ZonasStatus", zonas.ZonasEstado);
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
