using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CapaDatos.SQL;
using CapaEntidades;

namespace CapaDatos
{
    public class VentasD
    {
        private readonly ConexionDB _conexion = new ConexionDB();

        public async Task InsertarVentasBulk(List<VentasE> ventas)
        {
            if (ventas == null || ventas.Count == 0)
            {
                return;
            }

            // Crear un DataTable que coincida con la estructura de la tabla de la base de datos
            DataTable dt = new DataTable();
            
            dt.Columns.Add("Planta", typeof(string));
            dt.Columns.Add("Planta_ID", typeof(int));
            dt.Columns.Add("Vendedor", typeof(string));
            dt.Columns.Add("Ruta", typeof(string));
            dt.Columns.Add("Fecha", typeof(DateTime));
            dt.Columns.Add("Mes", typeof(string));
            dt.Columns.Add("Codigo_Cliente", typeof(int));
            dt.Columns.Add("Cliente", typeof(string));
            dt.Columns.Add("Tipo_Cliente", typeof(string));
            dt.Columns.Add("Categoria_Cliente", typeof(string));
            dt.Columns.Add("Codigo_Subcliente", typeof(int));
            dt.Columns.Add("Subcliente", typeof(string));
            dt.Columns.Add("Producto", typeof(string));
            dt.Columns.Add("Categoria", typeof(string));
            dt.Columns.Add("Cantidad", typeof(decimal));
            dt.Columns.Add("Litros", typeof(decimal));
            dt.Columns.Add("Otros_Impuestos", typeof(decimal));
            dt.Columns.Add("Total", typeof(decimal));

            foreach (var venta in ventas)
            {
                DataRow dr = dt.NewRow();
                dr["Planta"] = venta.Planta;
                dr["Planta_ID"] = venta.Planta_ID;
                dr["Vendedor"] = venta.Vendedor;
                dr["Ruta"] = venta.Ruta;
                dr["Fecha"] = venta.Fecha;
                dr["Mes"] = venta.Mes;
                dr["Codigo_Cliente"] = venta.Codigo_Cliente;
                dr["Cliente"] = venta.Cliente;
                dr["Tipo_Cliente"] = venta.Tipo_Cliente;
                dr["Categoria_Cliente"] = venta.Categoria_Cliente;
                dr["Codigo_Subcliente"] = venta.Codigo_Subcliente;
                dr["Subcliente"] = venta.Subcliente;
                dr["Producto"] = venta.Producto;
                dr["Categoria"] = venta.Categoria;
                dr["Cantidad"] = venta.Cantidad;
                dr["Litros"] = venta.Litros;
                dr["Otros_Impuestos"] = venta.Otros_Impuestos;
                dr["Total"] = venta.Total;
                dt.Rows.Add(dr);
            }

            using (SqlConnection connection = _conexion.AbrirConexion() as SqlConnection)
            {
                if (connection == null)
                {
                    throw new InvalidOperationException("No se pudo abrir la conexión a la base de datos SQL Server.");
                }

                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connection))
                {
                    bulkCopy.DestinationTableName = "Ventas"; // Nombre de la tabla de destino

                    // Mapeo de columnas (Excel a base de datos)
                    foreach (DataColumn dc in dt.Columns)
                    {
                        bulkCopy.ColumnMappings.Add(dc.ColumnName, dc.ColumnName);
                    }

                    await bulkCopy.WriteToServerAsync(dt);
                }
                _conexion.CerrarConexion();
            }
        }
    }
} 