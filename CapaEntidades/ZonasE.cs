using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class ZonasE
    {
        public int ZonasID { get; set; }
        public int ProvinciaID { get; set; }
        public string ZonasCode { get; set; }
        public string ZonasName { get; set; }
        public DateTime ZonasCreacion { get; set; }
        public DateTime ZonasUpdate { get; set; }
        public DateTime ZonasDelete { get; set; }
        public bool ZonasEstado { get; set; }
    }
}
