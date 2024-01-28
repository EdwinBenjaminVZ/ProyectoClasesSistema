using ApiService.Models;
using ApiService.Services.Clases;
using ApiService.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiService.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    [Authorize]
    public class RolControllers
    {
        private readonly IRolService _IRolService;
        public RolControllers(IRolService temp) 
        {
            this._IRolService = temp;
        }
        [HttpGet]
        public async Task<List<Rol>> GetList()
        {
            return await _IRolService.GetList();
        }
        
    }
}
