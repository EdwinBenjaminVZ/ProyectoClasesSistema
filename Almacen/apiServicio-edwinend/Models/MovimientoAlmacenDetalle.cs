using System;

namespace apiServicio.Models
{
    public class MovimientoAlmacenDetalle
    {
        public int IdMovimientoAlmacenDetalle { get; set; }
        public int IdMovimientoAlmacen { get; set; }
        public int IdIngresoDetalle { get; set; }
        public int IdInsumo { get; set; }
        public int IdIngreso { get; set; }
        public int Cantidad { get; set; }
        public int PrecioUnitario { get; set; }
        public int SubTotal { get; set; }
        public string Lote {  get; set; }
        public DateTime  FechaVencimiento { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string EstadoRegistro { get; set; }
        
    }
}
