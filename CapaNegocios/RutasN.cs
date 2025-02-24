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
  
    public class RutasN
    {
        RutasD rutasD=new RutasD();
        
        public string MantenimientoRutas(RutasE rutas,string accion) 
        {
            var value = rutasD.MantenimientoRutas(rutas, accion);
            return value;
        }

        public DataTable ListaRutas()
        {
            var list = rutasD.ListarZonas();
            return list;
        }
    }
}
