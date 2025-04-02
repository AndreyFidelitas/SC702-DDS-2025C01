using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class UsuariosSolicitud
    {
        public int SolicitudID { get; set; }
        public string SolicitudCode { get; set; }
        public int Cedula { get; set; }
        public string Name { get; set; }
        public string Apellidos { get; set; }
        public DateTime SolcitudAceptada { get; set; }
        public DateTime SolcitudRechaza { get; set; }
        public bool SolcitudEstado { get; set; }
        public int UsuarioID { get; set; }
    }
}
