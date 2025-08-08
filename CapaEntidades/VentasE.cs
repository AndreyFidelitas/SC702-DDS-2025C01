using System;

namespace CapaEntidades
{
    public class VentasE
    {
        // No incluir VentaID porque es IDENTITY
        public int PlantaID { get; set; }
        public string Planta { get; set; }
        public int RutaID { get; set; }
        public string Ruta { get; set; }
        public DateTime Fecha { get; set; }
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
        public int VendedorID { get; set; }
        public string Vendedor { get; set; }
        
        // Propiedades adicionales para mantener compatibilidad con el código existente
        [Obsolete("Use PlantaID instead")]
        public int Planta_ID 
        { 
            get => PlantaID; 
            set => PlantaID = value; 
        }
        
        [Obsolete("Removed from new table structure")]
        public string Mes { get; set; } // Mantenemos para compatibilidad pero no se guarda
    }
} 