using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class UsuariosE
    {
        public int UsuarioID { get; set; }
        public int Cedula { get; set; }
        public string UsuarioCode { get; set; }
        public string UsuarioName { get; set; }
        public string UsuarioApellidos { get; set; }
        public string UsuarioUserName { get; set; }
        public string Password { get; set; }
        public string token { get; set; }
        public int RoleID { get; set; }
        public DateTime UsuarioCreacion { get; set; }
        public DateTime UsuarioUpdate { get; set; }
        public DateTime UsuarioDelete { get; set; }
        public bool UsuarioEstado { get; set; }
    }
}
