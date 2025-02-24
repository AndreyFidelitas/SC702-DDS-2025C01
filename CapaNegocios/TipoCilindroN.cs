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
    public class TipoCilindroN
    {
        TipoCilindroD tipocilindroD = new TipoCilindroD();

        public string MantenimientoTipoCilindro(TipoCilindro tipoCilindro, string accion)
        {
            return tipocilindroD.MantenimientoTipoCilindro(tipoCilindro, accion);
        }

        public DataTable ListaTipoCilindro()
        {
            return tipocilindroD.ListaTipoCilindro();
        }
    }
}
