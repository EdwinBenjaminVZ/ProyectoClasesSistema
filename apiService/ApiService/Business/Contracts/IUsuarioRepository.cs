using ApiService.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiService.Business.Contracts
{
    public interface IUsuarioRepository
    {
        Task<Usuario> GetNombreUsuario(string nombreusuario);
    }
}
