using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class InventarioDetalle
    {
        public int InventarioDetalleID { get; set; }
        public string InventarioDetalleCode { get; set; }
        public int TipoCilindroID { get; set; }
        public int Cantidad { get; set; }
        public DateTime InventariosDCreacion { get; set; }
        public DateTime InventariosUpdate { get; set; }
        public DateTime InventarioDelete { get; set; }
    }
}
