using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades.ApiEmpresarial
{
    public class Situacion
    {
        public string Moroso { get; set; }
        public string Omiso { get; set; }
        public string Estado { get; set; }
        public string AdministracionTributaria { get; set; }
        public string Mensaje { get; set; }
    }
}
