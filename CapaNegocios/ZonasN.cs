using CapaDatos;
using CapaEntidades;
using System.Data;

namespace CapaNegocios
{
    public class ZonasN
    {

        ZonasD ZonasD=new ZonasD();

        public string MantenimientoZona(ZonasE zonas)
        {
            return ZonasD.MantenimientoZonas(zonas);
        }

        public DataTable ListaZona ()
        {
            return ZonasD.ListarZonas();
        }
    }
}
