using apiServicio.Business.Contracts;
using apiServicio.Models;
using apiServicio.Services.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace apiServicio.Services.Clases
{
    public class MovimientoAlmacenService : IMovimientoAlmacenService
    {
        private readonly IMovimientoAlmacenRepository _IMovimientoAlmacenRepository;

        public MovimientoAlmacenService(IMovimientoAlmacenRepository temp)
        {
            _IMovimientoAlmacenRepository = temp;
        }
        public Task<List<MovimientoAlmacen>> GetList()
        {
            return _IMovimientoAlmacenRepository.GetList();
        }
        public Task<MovimientoAlmacen> AgregaActualiza(MovimientoAlmacen l, string t)
        {
            return _IMovimientoAlmacenRepository.AgregaActualiza(l, t);
        }
    }
}
