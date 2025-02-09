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
        //Cadena de conexion a la base de datos
        public static string CadenaConexion = @"Data Source=Localhost;Initial Catalog=InventZetaGas;Integrated Security=True";

        //Variable para la conexion
        public SqlConnection Conexion = new(CadenaConexion);

        //Metodo para abrir la conexion
        public SqlConnection AbrirConexion()
        {
            if (Conexion.State == ConnectionState.Closed)
                Conexion.Open();
            return Conexion;
        }

        //Metodo para cerrar la conexion
        public SqlConnection CerrarConexion()
        {
            if (Conexion.State == ConnectionState.Open)
                Conexion.Close();
            return Conexion;
        }
    }
}
