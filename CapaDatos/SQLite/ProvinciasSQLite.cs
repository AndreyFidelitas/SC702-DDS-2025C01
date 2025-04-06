using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CapaDatos.SQL;
using CapaEntidades;

namespace CapaDatos.SQLite
{
    public class ProvinciasSQLite
    {
        private readonly ConexionDB _conexionSQL = new ConexionDB();
        private readonly SQLiteDB _sqliteDB = new SQLiteDB();

        public void ImportarProvinciasDesdeSQL()
        {
            try
            {
                // Obtener provincias desde SQL Server
                var provincias = ObtenerProvinciasDesdeSQL();
                
                // Importar a SQLite
                _sqliteDB.ImportarProvinciasDesdeSQL(provincias);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al importar provincias: " + ex.Message);
            }
        }

        private List<ProvinciaE> ObtenerProvinciasDesdeSQL()
        {
            var provincias = new List<ProvinciaE>();
            
            using (var cmd = new SqlCommand("SPListaProvincias", _conexionSQL.AbrirConexion()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        provincias.Add(new ProvinciaE
                        {
                            ProvinciaID = Convert.ToInt32(reader["Provincia ID"]),
                            ProvinciaCode = reader["Provincia Code"].ToString(),
                            ProvinciaName = reader["Provincia Name"].ToString()
                        });
                    }
                }
                
                _conexionSQL.CerrarConexion();
            }
            
            return provincias;
        }

        public List<ProvinciaE> ObtenerProvinciasDesdeSQLite()
        {
            return _sqliteDB.ObtenerProvincias();
        }
    }
}
