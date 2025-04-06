using System;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Collections.Generic;
using CapaEntidades;

namespace CapaDatos.SQLite
{
    public class SQLiteDB
    {
        private readonly string _dbPath;
        private readonly string _connectionString;

        public SQLiteDB()
        {
            try
            {
                // Definir la ruta de la base de datos SQLite
                string appDataPath = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                    "ZetaGas"
                );

                // Crear el directorio si no existe
                if (!Directory.Exists(appDataPath))
                {
                    Directory.CreateDirectory(appDataPath);
                }

                _dbPath = Path.Combine(appDataPath, "ZetaGas.db");
                _connectionString = $"Data Source={_dbPath};Version=3;";
                
                // Crear la base de datos si no existe
                if (!File.Exists(_dbPath))
                {
                    SQLiteConnection.CreateFile(_dbPath);
                    CrearTablas();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al inicializar la base de datos SQLite: " + ex.Message);
            }
        }

        private void CrearTablas()
        {
            try
            {
                using (var connection = new SQLiteConnection(_connectionString))
                {
                    connection.Open();
                    
                    // Crear tabla de provincias
                    string createProvinciasTable = @"
                        CREATE TABLE IF NOT EXISTS Provincias (
                            ProvinciaID INTEGER PRIMARY KEY AUTOINCREMENT,
                            ProvinciaCode VARCHAR(50) NOT NULL,
                            ProvinciaName VARCHAR(100) NOT NULL,
                            ProvinciaEstado BIT NOT NULL
                        )";
                    
                    using (var command = new SQLiteCommand(createProvinciasTable, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear las tablas: " + ex.Message);
            }
        }

        public void ImportarProvinciasDesdeSQL(List<ProvinciaE> provincias)
        {
            try
            {
                using (var connection = new SQLiteConnection(_connectionString))
                {
                    connection.Open();
                    
                    // Crear tabla temporal para la importación
                    string createTempTable = @"
                        CREATE TABLE IF NOT EXISTS TempProvincias (
                            ProvinciaCode VARCHAR(50) NOT NULL,
                            ProvinciaName VARCHAR(100) NOT NULL,
                            ProvinciaEstado BIT NOT NULL
                        )";
                    
                    using (var command = new SQLiteCommand(createTempTable, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    // Insertar datos en la tabla temporal
                    foreach (var provincia in provincias)
                    {
                        string insertSql = @"
                            INSERT INTO TempProvincias (ProvinciaCode, ProvinciaName, ProvinciaEstado)
                            VALUES (@ProvinciaCode, @ProvinciaName, @ProvinciaEstado)";
                        
                        using (var command = new SQLiteCommand(insertSql, connection))
                        {
                            command.Parameters.AddWithValue("@ProvinciaCode", provincia.ProvinciaCode);
                            command.Parameters.AddWithValue("@ProvinciaName", provincia.ProvinciaName);
                            command.Parameters.AddWithValue("@ProvinciaEstado", provincia.ProvinciaEstado);
                            command.ExecuteNonQuery();
                        }
                    }

                    // Insertar datos en la tabla principal
                    string insertMainTable = @"
                        INSERT INTO Provincias (ProvinciaCode, ProvinciaName, ProvinciaEstado)
                        SELECT ProvinciaCode, ProvinciaName, ProvinciaEstado
                        FROM TempProvincias
                        WHERE NOT EXISTS (
                            SELECT 1 FROM Provincias p
                            WHERE p.ProvinciaCode = TempProvincias.ProvinciaCode
                        )";
                    
                    using (var command = new SQLiteCommand(insertMainTable, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    // Eliminar tabla temporal
                    string dropTempTable = "DROP TABLE IF EXISTS TempProvincias";
                    using (var command = new SQLiteCommand(dropTempTable, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al importar provincias: " + ex.Message);
            }
        }

        public List<ProvinciaE> ObtenerProvincias()
        {
            var provincias = new List<ProvinciaE>();
            
            try
            {
                using (var connection = new SQLiteConnection(_connectionString))
                {
                    connection.Open();
                    
                    string selectSql = "SELECT ProvinciaID, ProvinciaCode, ProvinciaName, ProvinciaEstado FROM Provincias";
                    
                    using (var command = new SQLiteCommand(selectSql, connection))
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            provincias.Add(new ProvinciaE
                            {
                                ProvinciaID = Convert.ToInt32(reader["ProvinciaID"]),
                                ProvinciaCode = reader["ProvinciaCode"].ToString(),
                                ProvinciaName = reader["ProvinciaName"].ToString(),
                                ProvinciaEstado = Convert.ToBoolean(reader["ProvinciaEstado"])
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener provincias: " + ex.Message);
            }
            
            return provincias;
        }
    }
} 