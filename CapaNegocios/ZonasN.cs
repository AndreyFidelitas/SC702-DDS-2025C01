using CapaDatos;
using CapaEntidades;
using System.Data;

namespace CapaNegocios
{
    public class ZonasN
    {

        ZonasD ZonasD=new ZonasD();

        public string MantenimientoZona(ZonasE zonas,string accion)
        {
            return ZonasD.MantenimientoZonas(zonas,accion);
        }

        public DataTable ListaZona ()
        {
            return ZonasD.ListarZonas();
        }

        public DataTable ListaProvincias() 
        {
            return ZonasD.ListarProvincias();
        }
    }
}
