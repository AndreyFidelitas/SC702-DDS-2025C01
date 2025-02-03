using CapaDatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocios
{
    public class RolesN
    {
        RolesD rolesD = new RolesD();

        public string MantenimientoRoles(RolesE roles, string accion)
        {
            //return roles. (roles, accion);
            return rolesD.MantenimientoRoles(roles,accion);
        }

        public DataTable ListaRoles()
        {
            return rolesD.ListarRoles();
        }
    }
}
