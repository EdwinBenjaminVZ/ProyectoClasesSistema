using ApiService.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiService.Services.Contracts
{
    public interface IRolService
    {
        Task<List<Rol>> GetList();
    }
}
