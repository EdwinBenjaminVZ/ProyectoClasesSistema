using apiServicio.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace apiServicio.Services.Contracts
{
    public interface IMovimientoAlmacenDetalleService
    {
        Task<List<MovimientoAlmacenDetalle>> GetList();
        Task<MovimientoAlmacenDetalle> AgregaActualiza(MovimientoAlmacenDetalle l, string t);
    }
}
