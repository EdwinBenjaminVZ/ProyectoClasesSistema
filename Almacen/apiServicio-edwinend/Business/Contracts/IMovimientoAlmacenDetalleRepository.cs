using apiServicio.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace apiServicio.Business.Contracts
{
    public interface IMovimientoAlmacenDetalleRepository
    {
        Task<List<MovimientoAlmacenDetalle>> GetList();
        Task<MovimientoAlmacenDetalle> AgregaActualiza(MovimientoAlmacenDetalle l, string t);
    }
}
