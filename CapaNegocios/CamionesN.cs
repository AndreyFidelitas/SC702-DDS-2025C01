using CapaDatos;
using CapaEntidades;
using System.Data;

namespace CapaNegocios
{
    public  class CamionesN
    {
        CamionesD camionesD = new CamionesD();

        public string MantenimientoCamiones(CamionesE camion, string accion)
        {
            return camionesD.MantenimientoCamiones(camion, accion);
        }

        public DataTable ListaCamion()
        {
            return camionesD.ListarCamiones();
        }
    }
}
