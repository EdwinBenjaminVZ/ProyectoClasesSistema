using apiServicio.Business.Contracts;
using apiServicio.Models;
using apiServicio.Services.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace apiServicio.Services.Clases
{
    public class MovimientoAlmacenDetalleService : IMovimientoAlmacenDetalleService
    {
        private readonly IMovimientoAlmacenDetalleRepository _IMovimientoAlmacenDetalleRepository;

        public MovimientoAlmacenDetalleService(IMovimientoAlmacenDetalleRepository temp)
        {
            _IMovimientoAlmacenDetalleRepository = temp;
        }
        public Task<List<MovimientoAlmacenDetalle>> GetList()
        {
            return _IMovimientoAlmacenDetalleRepository.GetList();
        }
        public Task<MovimientoAlmacenDetalle> AgregaActualiza(MovimientoAlmacenDetalle l, string t)
        {
            return _IMovimientoAlmacenDetalleRepository.AgregaActualiza(l, t);
        }
    }
}
