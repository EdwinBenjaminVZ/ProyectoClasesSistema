using apiServicio.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace apiServicio.Business.Contracts
{
    public interface IMovimientoAlmacenRepository
    {
        Task<List<MovimientoAlmacen>> GetList();
        Task<MovimientoAlmacen> AgregaActualiza(MovimientoAlmacen l, string t);

















    }
}
