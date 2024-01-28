using apiServicio.Models;
using apiServicio.Services.Clases;
using apiServicio.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace apiServicio.Controllers
{
    [ApiController]
    [Route("tuki/[Controller]")]
    public class MovimientoAlmacenDetalleController
    {
        private readonly IMovimientoAlmacenDetalleService _IMovimientoAlmacenDetalleService;


        public MovimientoAlmacenDetalleController(IMovimientoAlmacenDetalleService temp)
        {
            this._IMovimientoAlmacenDetalleService = temp;

        }
        [HttpGet]
        public async Task<List<MovimientoAlmacenDetalle>> GetList()
        {
            return await _IMovimientoAlmacenDetalleService.GetList();
        }
        [HttpPost("AgregaActualiza")]
        public async Task<MovimientoAlmacenDetalle> AgregaActualiza(
            int IdMovimientoAlmacenDetalle, int IdMovimientoAlmacen, int IdIngresoDetalle, int IdInsumo,
            int IdIngreso, int Cantidad, int PrecioUnitario, int SubTotal, string Lote, 
            DateTime FechaVencimiento, DateTime FechaRegistro, string EstadoRegistro, string t)
        {
            MovimientoAlmacenDetalle l = new MovimientoAlmacenDetalle();
            l.IdMovimientoAlmacenDetalle = IdMovimientoAlmacenDetalle;
            l.IdMovimientoAlmacen = IdMovimientoAlmacen;
            l.IdIngresoDetalle = IdIngresoDetalle;
            l.IdInsumo = IdInsumo;
            l.IdIngreso = IdIngreso;
            l.Cantidad = Cantidad;
            l.PrecioUnitario = PrecioUnitario;
            l.SubTotal = SubTotal;
            l.Lote = Lote;
            l.FechaVencimiento = FechaVencimiento;
            l.FechaRegistro = FechaRegistro;
            l.EstadoRegistro = EstadoRegistro;
           

            return await _IMovimientoAlmacenDetalleService.AgregaActualiza(l, t);
        }
    }
}
