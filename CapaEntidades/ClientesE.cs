using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class ClientesE
    {
        public int ClientesID { get; set; }
        public string ClientesCode { get; set; }
        public string RazonSocial { get; set; }
        public string Empresa { get; set; }
        public string ClientesRol { get; set; }
        public DateTime ClientesCreacion { get; set; }
        public DateTime ClientesUpdate { get; set; }
        public DateTime ClientesDelete { get; set; }
        public bool ClientesStatus { get; set; }
    }
}
