using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class ApiResponse
    {
        public string Query { get; set; }
        public string Cedula { get; set; }
        public string User { get; set; }
        public List<Result> Results { get; set; }
        public string DatabaseDate { get; set; }
        public string TipoIdentificacion { get; set; }
        public string License { get; set; }
        public int Resultcount { get; set; }
        public string Nombre { get; set; }
    }
}
