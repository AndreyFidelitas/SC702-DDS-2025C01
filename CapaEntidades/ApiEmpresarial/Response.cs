using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades.ApiEmpresarial
{
    public class Response
    {
        public string Nombre { get; set; }
        public string TipoIdentificacion { get; set; }
        public Regimen Regimen { get; set; }
        public Situacion Situacion { get; set; }
        public List<Actividad> Actividades { get; set; }  // Lista de actividades (vacía en este caso)
    }
}
