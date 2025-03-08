using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class InventariosEncabezado
    {
        public int InventarioID { get; set; }
        public int ZonasID { get; set; }
        public string InventariosCode { get; set; }
        public int CantidadTotal { get; set; }
        public DateTime InventariosCreacion { get; set; }
        public DateTime InventariosUpdate { get; set; }
        public DateTime InventariosDelete { get; set; }
        public bool InventariosStatus { get; set; }
    }
}
