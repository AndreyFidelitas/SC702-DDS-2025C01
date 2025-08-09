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
            
            // No incluir VentaID porque es IDENTITY (auto-incremental)
            dt.Columns.Add("PlantaID", typeof(int));
            dt.Columns.Add("Planta", typeof(string));
            dt.Columns.Add("RutaID", typeof(int));
            dt.Columns.Add("Ruta", typeof(string));
            dt.Columns.Add("Fecha", typeof(DateTime));
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
            dt.Columns.Add("VendedorID", typeof(int));
            dt.Columns.Add("Vendedor", typeof(string));

            foreach (var venta in ventas)
            {
                DataRow dr = dt.NewRow();
                dr["PlantaID"] = venta.PlantaID;
                dr["Planta"] = venta.Planta ?? (object)DBNull.Value;
                dr["RutaID"] = venta.RutaID;
                dr["Ruta"] = venta.Ruta ?? (object)DBNull.Value;
                dr["Fecha"] = venta.Fecha;
                dr["Codigo_Cliente"] = venta.Codigo_Cliente;
                dr["Cliente"] = venta.Cliente ?? (object)DBNull.Value;
                dr["Tipo_Cliente"] = venta.Tipo_Cliente ?? (object)DBNull.Value;
                dr["Categoria_Cliente"] = venta.Categoria_Cliente ?? (object)DBNull.Value;
                dr["Codigo_Subcliente"] = venta.Codigo_Subcliente == 0 ? (object)DBNull.Value : venta.Codigo_Subcliente;
                dr["Subcliente"] = venta.Subcliente ?? (object)DBNull.Value;
                dr["Producto"] = venta.Producto ?? (object)DBNull.Value;
                dr["Categoria"] = venta.Categoria ?? (object)DBNull.Value;
                dr["Cantidad"] = venta.Cantidad == 0 ? (object)DBNull.Value : venta.Cantidad;
                dr["Litros"] = venta.Litros == 0 ? (object)DBNull.Value : venta.Litros;
                dr["Otros_Impuestos"] = venta.Otros_Impuestos == 0 ? (object)DBNull.Value : venta.Otros_Impuestos;
                dr["Total"] = venta.Total == 0 ? (object)DBNull.Value : venta.Total;
                dr["VendedorID"] = venta.VendedorID;
                dr["Vendedor"] = venta.Vendedor ?? (object)DBNull.Value;
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

                    // Mapeo explícito de columnas según la nueva estructura de la tabla
                    bulkCopy.ColumnMappings.Add("PlantaID", "PlantaID");
                    bulkCopy.ColumnMappings.Add("Planta", "Planta");
                    bulkCopy.ColumnMappings.Add("RutaID", "RutaID");
                    bulkCopy.ColumnMappings.Add("Ruta", "Ruta");
                    bulkCopy.ColumnMappings.Add("Fecha", "Fecha");
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
                    bulkCopy.ColumnMappings.Add("VendedorID", "VendedorID");
                    bulkCopy.ColumnMappings.Add("Vendedor", "Vendedor");

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
                INSERT INTO Ventas (PlantaID, Planta, RutaID, Ruta, Fecha, Codigo_Cliente, Cliente, 
                                  Tipo_Cliente, Categoria_Cliente, Codigo_Subcliente, Subcliente, Producto, 
                                  Categoria, Cantidad, Litros, Otros_Impuestos, Total, VendedorID, Vendedor)
                VALUES (@PlantaID, @Planta, @RutaID, @Ruta, @Fecha, @Codigo_Cliente, @Cliente, 
                        @Tipo_Cliente, @Categoria_Cliente, @Codigo_Subcliente, @Subcliente, @Producto, 
                        @Categoria, @Cantidad, @Litros, @Otros_Impuestos, @Total, @VendedorID, @Vendedor)";

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
                                cmd.Parameters.AddWithValue("@PlantaID", venta.PlantaID);
                                cmd.Parameters.AddWithValue("@Planta", venta.Planta ?? (object)DBNull.Value);
                                cmd.Parameters.AddWithValue("@RutaID", venta.RutaID);
                                cmd.Parameters.AddWithValue("@Ruta", venta.Ruta ?? (object)DBNull.Value);
                                cmd.Parameters.AddWithValue("@Fecha", venta.Fecha);
                                cmd.Parameters.AddWithValue("@Codigo_Cliente", venta.Codigo_Cliente);
                                cmd.Parameters.AddWithValue("@Cliente", venta.Cliente ?? (object)DBNull.Value);
                                cmd.Parameters.AddWithValue("@Tipo_Cliente", venta.Tipo_Cliente ?? (object)DBNull.Value);
                                cmd.Parameters.AddWithValue("@Categoria_Cliente", venta.Categoria_Cliente ?? (object)DBNull.Value);
                                cmd.Parameters.AddWithValue("@Codigo_Subcliente", venta.Codigo_Subcliente == 0 ? (object)DBNull.Value : venta.Codigo_Subcliente);
                                cmd.Parameters.AddWithValue("@Subcliente", venta.Subcliente ?? (object)DBNull.Value);
                                cmd.Parameters.AddWithValue("@Producto", venta.Producto ?? (object)DBNull.Value);
                                cmd.Parameters.AddWithValue("@Categoria", venta.Categoria ?? (object)DBNull.Value);
                                cmd.Parameters.AddWithValue("@Cantidad", venta.Cantidad == 0 ? (object)DBNull.Value : venta.Cantidad);
                                cmd.Parameters.AddWithValue("@Litros", venta.Litros == 0 ? (object)DBNull.Value : venta.Litros);
                                cmd.Parameters.AddWithValue("@Otros_Impuestos", venta.Otros_Impuestos == 0 ? (object)DBNull.Value : venta.Otros_Impuestos);
                                cmd.Parameters.AddWithValue("@Total", venta.Total == 0 ? (object)DBNull.Value : venta.Total);
                                cmd.Parameters.AddWithValue("@VendedorID", venta.VendedorID);
                                cmd.Parameters.AddWithValue("@Vendedor", venta.Vendedor ?? (object)DBNull.Value);

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

        #region "MostrarListaRoles"
        public DataTable CargaLista()
        {
            using (var cmd = new SqlCommand("ListaVentas", _conexion.AbrirConexion()))
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

    }
} 