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

            // Primero intentar con SqlBulkCopy, si falla usar INSERT tradicional
            try
            {
                await InsertarConBulkCopy(ventas);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"SqlBulkCopy falló: {ex.Message}. Intentando con INSERT tradicional...");
                await InsertarConInsertTradicional(ventas);
            }
        }

        private async Task InsertarConBulkCopy(List<VentasE> ventas)
        {

            // Crear un DataTable que coincida con la estructura de la tabla de la base de datos
            DataTable dt = new DataTable();
            
            // No incluir la columna ID si es IDENTITY (auto-incremental)
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

            using (SqlConnection connection = new SqlConnection(ConexionDB.CadenaConexion))
            {
                await connection.OpenAsync();

                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connection))
                {
                    bulkCopy.DestinationTableName = "Ventas"; // Nombre de la tabla de destino
                    bulkCopy.BatchSize = 1000; // Procesar en lotes de 1000 filas
                    bulkCopy.BulkCopyTimeout = 300; // Timeout de 5 minutos
                    
                    // Configurar para que mantenga las columnas IDENTITY (no las sobrescriba)
                    bulkCopy.SqlRowsCopied += (sender, e) => {
                        Console.WriteLine($"Filas copiadas hasta ahora: {e.RowsCopied}");
                    };

                    // Mapeo explícito de columnas (solo las que existen en nuestro DataTable)
                    bulkCopy.ColumnMappings.Add("Planta", "Planta");
                    bulkCopy.ColumnMappings.Add("Planta_ID", "Planta_ID");
                    bulkCopy.ColumnMappings.Add("Vendedor", "Vendedor");
                    bulkCopy.ColumnMappings.Add("Ruta", "Ruta");
                    bulkCopy.ColumnMappings.Add("Fecha", "Fecha");
                    bulkCopy.ColumnMappings.Add("Mes", "Mes");
                    bulkCopy.ColumnMappings.Add("Codigo_Cliente", "Codigo_Cliente");
                    bulkCopy.ColumnMappings.Add("Cliente", "Cliente");
                    bulkCopy.ColumnMappings.Add("Tipo_Cliente", "Tipo_Cliente");
                    bulkCopy.ColumnMappings.Add("Categoria_Cliente", "Categoria_Cliente");
                    bulkCopy.ColumnMappings.Add("Codigo_Subcliente", "Codigo_Subcliente");
                    bulkCopy.ColumnMappings.Add("Subcliente", "Subcliente");
                    bulkCopy.ColumnMappings.Add("Producto", "Producto");
                    bulkCopy.ColumnMappings.Add("Categoria", "Categoria");
                    bulkCopy.ColumnMappings.Add("Cantidad", "Cantidad");
                    bulkCopy.ColumnMappings.Add("Litros", "Litros");
                    bulkCopy.ColumnMappings.Add("Otros_Impuestos", "Otros_Impuestos");
                    bulkCopy.ColumnMappings.Add("Total", "Total");

                    try
                    {
                        await bulkCopy.WriteToServerAsync(dt);
                        Console.WriteLine($"SqlBulkCopy completado exitosamente. {dt.Rows.Count} filas insertadas.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error en SqlBulkCopy: {ex.Message}");
                        throw;
                    }
                }
            }
        }

        private async Task InsertarConInsertTradicional(List<VentasE> ventas)
        {
            const string insertQuery = @"
                INSERT INTO Ventas (Planta, Planta_ID, Vendedor, Ruta, Fecha, Mes, Codigo_Cliente, Cliente, 
                                  Tipo_Cliente, Categoria_Cliente, Codigo_Subcliente, Subcliente, Producto, 
                                  Categoria, Cantidad, Litros, Otros_Impuestos, Total)
                VALUES (@Planta, @Planta_ID, @Vendedor, @Ruta, @Fecha, @Mes, @Codigo_Cliente, @Cliente, 
                        @Tipo_Cliente, @Categoria_Cliente, @Codigo_Subcliente, @Subcliente, @Producto, 
                        @Categoria, @Cantidad, @Litros, @Otros_Impuestos, @Total)";

            using (SqlConnection connection = new SqlConnection(ConexionDB.CadenaConexion))
            {
                await connection.OpenAsync();
                
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        foreach (var venta in ventas)
                        {
                            using (SqlCommand cmd = new SqlCommand(insertQuery, connection, transaction))
                            {
                                cmd.Parameters.AddWithValue("@Planta", venta.Planta ?? (object)DBNull.Value);
                                cmd.Parameters.AddWithValue("@Planta_ID", venta.Planta_ID);
                                cmd.Parameters.AddWithValue("@Vendedor", venta.Vendedor ?? (object)DBNull.Value);
                                cmd.Parameters.AddWithValue("@Ruta", venta.Ruta ?? (object)DBNull.Value);
                                cmd.Parameters.AddWithValue("@Fecha", venta.Fecha);
                                cmd.Parameters.AddWithValue("@Mes", venta.Mes ?? (object)DBNull.Value);
                                cmd.Parameters.AddWithValue("@Codigo_Cliente", venta.Codigo_Cliente);
                                cmd.Parameters.AddWithValue("@Cliente", venta.Cliente ?? (object)DBNull.Value);
                                cmd.Parameters.AddWithValue("@Tipo_Cliente", venta.Tipo_Cliente ?? (object)DBNull.Value);
                                cmd.Parameters.AddWithValue("@Categoria_Cliente", venta.Categoria_Cliente ?? (object)DBNull.Value);
                                cmd.Parameters.AddWithValue("@Codigo_Subcliente", venta.Codigo_Subcliente);
                                cmd.Parameters.AddWithValue("@Subcliente", venta.Subcliente ?? (object)DBNull.Value);
                                cmd.Parameters.AddWithValue("@Producto", venta.Producto ?? (object)DBNull.Value);
                                cmd.Parameters.AddWithValue("@Categoria", venta.Categoria ?? (object)DBNull.Value);
                                cmd.Parameters.AddWithValue("@Cantidad", venta.Cantidad);
                                cmd.Parameters.AddWithValue("@Litros", venta.Litros);
                                cmd.Parameters.AddWithValue("@Otros_Impuestos", venta.Otros_Impuestos);
                                cmd.Parameters.AddWithValue("@Total", venta.Total);

                                await cmd.ExecuteNonQueryAsync();
                            }
                        }

                        await transaction.CommitAsync();
                        Console.WriteLine($"INSERT tradicional completado exitosamente. {ventas.Count} filas insertadas.");
                    }
                    catch (Exception ex)
                    {
                        await transaction.RollbackAsync();
                        Console.WriteLine($"Error en INSERT tradicional: {ex.Message}");
                        throw;
                    }
                }
            }
        }
    }
} 