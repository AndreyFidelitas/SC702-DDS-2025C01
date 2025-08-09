using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidades;
using DocumentFormat.OpenXml.Vml.Office;

namespace CapaNegocios
{
    public class VentasN
    {
        private VentasD _ventasD = new VentasD();

        public async Task InsertarVentasBulk(List<VentasE> ventas)
        {
            // Aquí podrías agregar lógica de negocio adicional antes de guardar, por ejemplo, validaciones
            await _ventasD.InsertarVentasBulk(ventas);
        }


        public DataTable CargarRoles()
        {
            return _ventasD.CargaLista();
        }
    }
} 