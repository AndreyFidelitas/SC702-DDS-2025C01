using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.SQL
{
    public class ConexionDB
    {
        static private string CadenaConexion = "Data Source=DESKTOP-IUEFO21\\MSSQLSERVER01;Initial Catalog=¨RutasAviacion;User ID=Andreyszcr;Password=Andre3093sa99";

        public SqlConnection Conexion = new(CadenaConexion);

        public SqlConnection AbrirConexion()
        {
            if (Conexion.State == ConnectionState.Closed)
                Conexion.Open();
            return Conexion;
        }

        public SqlConnection CerrarConexion()
        {
            if (Conexion.State == ConnectionState.Open)
                Conexion.Close();
            return Conexion;
        }
    }
}
