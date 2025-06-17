using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class LogsE
    {
       public int LogID { get; set; }
       public DateTime FechaEvento { get; set; }
       public int UsuarioID { get; set; }
       public string TablaAfectada { get; set; }
       public string Modulo { get; set; }
       public string Detalles { get; set; }
    }
}
