
using ApiService.Business.Contracts;
using ApiService.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace ApiService.Business.Clases
{
    public class RolRepository : IRolRepository
    {
        private readonly string conect;
        public RolRepository(IConfiguration _con)
        {
            conect = _con.GetConnectionString("conBase");
        }
        public async Task<List<Rol>> GetList() {
        List<Rol> list = new List<Rol>();
            Rol l;
            using (SqlConnection con = new SqlConnection(conect))
            {
                await con.OpenAsync();
                SqlCommand cmd = new SqlCommand("select * from Rol;",con);
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        l= new Rol();
                        l.Id = Convert.ToInt32(reader["Id"]);
                        l.NombreRol = Convert.ToString(reader["NombreRol"]);
                        list.Add(l);
                    }
                }
            }
            return list;
        }
        
    }
}
