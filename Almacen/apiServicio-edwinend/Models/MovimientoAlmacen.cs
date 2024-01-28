using System;
using System.Runtime.InteropServices;

namespace apiServicio.Models
{
    public class MovimientoAlmacen
    {

        public int IdMovimientoAlmacen { get; set; }
        public int IdMovimientoAlmacenPadre { get; set; }
        public string NombreMovimientoAlmacen { get; set; }
        public DateTime FechaSaldoInicial { get; set; }
        public DateTime FechaInicial { get; set; }
        public DateTime FechaFinal { get; set; }
        public int NumeroDeIngreso { get; set; }
        public DateTime FechaReal { get; set; }
        public string Observacion { get; set; }
        public int Subtotal { get; set; }
        public int Total { get; set; }
        public int IdGestion { get; set; }
        public int IdEntidad { get; set; }
        public int IdUsuario { get; set; }
        public int IdAlmacen { get; set; }
        public int IdEstadoIngreso { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string EstadoRegistro { get; set; }
    }
}
