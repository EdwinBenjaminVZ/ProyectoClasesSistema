using apiServicio.Models;
using apiServicio.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace apiServicio.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class MovimientoAlmacenController
    {     
        private readonly IMovimientoAlmacenService _IMovimientoAlmacenService;
      
      
        public MovimientoAlmacenController(IMovimientoAlmacenService temp) 
        {
            this._IMovimientoAlmacenService = temp;
        
        }
        [HttpGet]
        public async Task<List<MovimientoAlmacen>> GetList()
        {
            return await _IMovimientoAlmacenService.GetList();
        }
        [HttpPost("AgregaActualiza")]
        public async Task<MovimientoAlmacen> AgregaActualiza(
            int IdMovimientoAlmacen, int IdMovimientoAlmacenPadre, string NombreMovimientoAlmacen,DateTime FechaSaldoInicial,DateTime FechaInicial, DateTime FechaFinal, int NumeroIngreso, DateTime FechaReal, string Observacion,int Subtotal, int Total, int IdGestion,
           int IdEntidad, int IdUsuario, int IdAlmacen, int IdEstadoIngreso, DateTime FechaRegistro, string EstadoRegistro, string t)
        {
            MovimientoAlmacen l = new MovimientoAlmacen();
            l.IdMovimientoAlmacen = IdMovimientoAlmacen;
            l.IdMovimientoAlmacenPadre = IdMovimientoAlmacenPadre;
            l.NombreMovimientoAlmacen = NombreMovimientoAlmacen;
            l.FechaSaldoInicial = FechaSaldoInicial;
            l.FechaInicial = FechaInicial;
            l.FechaFinal = FechaFinal;
            l.NumeroDeIngreso = NumeroIngreso;
            l.FechaReal = FechaReal;
            l.Observacion = Observacion;
            l.Subtotal = Subtotal;
            l.Total = Total;
            l.IdGestion = IdGestion;
            l.IdEntidad = IdEntidad;
            l.IdUsuario = IdUsuario;
            l.IdAlmacen = IdAlmacen;
            l.IdEstadoIngreso = IdEstadoIngreso;
            l.FechaRegistro = FechaRegistro;
            l.EstadoRegistro = EstadoRegistro;

            return await _IMovimientoAlmacenService.AgregaActualiza(l, t);
        }
    }
}
