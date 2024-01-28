using ApiService.Business.Contracts;
using ApiService.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace ApiService.Business.Clases
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly string connec;
        public UsuarioRepository(IConfiguration _IConfiguration)
        {
            connec = _IConfiguration.GetConnectionString("conBase");
        }
        public async Task<Usuario> GetNombreUsuario(string nombreusuario)
        {
            List<string> list = new List<string>();
            Usuario oUsuario = new Usuario();
            using (SqlConnection conn = new SqlConnection(connec))
            {
                await conn.OpenAsync();
                SqlCommand cmd = new SqlCommand("select * from trnUsuario where NombreUsuario='"
                    + nombreusuario + "';", conn);
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        oUsuario.IdUsuario = Convert.ToInt32(reader["IdUsuario"].ToString());
                        oUsuario.NombreUsuario = reader["NombreUsuario"].ToString();
                        oUsuario.Clave = reader["Clave"].ToString();
                        oUsuario.Salt = reader["Salt"].ToString();
                    }
                }
            }
            return oUsuario;
        }
    }
}
