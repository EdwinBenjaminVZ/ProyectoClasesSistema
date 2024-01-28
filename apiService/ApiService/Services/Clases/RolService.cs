using ApiService.Business.Contracts;
using ApiService.Models;
using ApiService.Services.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiService.Services.Clases
{
    public class RolService : IRolService
    {
        private readonly IRolRepository _IRolRepository;
        public RolService(IRolRepository temp)
        {
            _IRolRepository = temp;
        }
        public Task<List<Rol>> GetList()
        {
            return _IRolRepository.GetList();
        }
    }
}
