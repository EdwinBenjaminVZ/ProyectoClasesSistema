using apiServicio.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace apiServicio.Services.Contracts
{
    public interface IMovimientoAlmacenService
    {
        Task<List<MovimientoAlmacen>> GetList();
        Task<MovimientoAlmacen> AgregaActualiza(MovimientoAlmacen l, string t);
    }
}
