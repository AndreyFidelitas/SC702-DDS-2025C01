using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class CamionesE
    {
        public int CamionID { get; set; }
        public string CamionCode { get; set; }
        public string CamionName { get; set; }
        public string CamionPlaca { get; set; }
        public string CamionPesaje { get; set; }
        public DateTime CamionCreacion { get; set; }
        public DateTime CamionUpdate { get; set; }
        public DateTime CamionDelete { get; set; }
        public bool CamionStatus { get; set; }
    }
}
