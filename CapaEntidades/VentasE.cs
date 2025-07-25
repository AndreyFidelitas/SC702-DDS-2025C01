using System;

namespace CapaEntidades
{
    public class VentasE
    {
        public string Planta { get; set; }
        public int Planta_ID { get; set; }
        public string Vendedor { get; set; }
        public string Ruta { get; set; }
        public DateTime Fecha { get; set; }
        public string Mes { get; set; }
        public int Codigo_Cliente { get; set; }
        public string Cliente { get; set; }
        public string Tipo_Cliente { get; set; }
        public string Categoria_Cliente { get; set; }
        public int Codigo_Subcliente { get; set; }
        public string Subcliente { get; set; }
        public string Producto { get; set; }
        public string Categoria { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Litros { get; set; }
        public decimal Otros_Impuestos { get; set; }
        public decimal Total { get; set; }
    }
} 