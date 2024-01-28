using apiServicio.Business.Contracts;
using apiServicio.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.Emit;
using System.Threading.Tasks;

namespace apiServicio.Business.Clases

{
    public class MovimientoAlmacenRepository : IMovimientoAlmacenRepository
    {
        private readonly string conect;
        public MovimientoAlmacenRepository(IConfiguration _con)
        {
            conect = _con.GetConnectionString("conBase");
        }
        public async Task<List<MovimientoAlmacen>> GetList()
        {
            List<MovimientoAlmacen> list = new List<MovimientoAlmacen>();
            MovimientoAlmacen l;
            using (SqlConnection con = new SqlConnection(conect))
            {
                await con.OpenAsync();
                SqlCommand cmd = new SqlCommand("select * from TrnMovimientoAlmacen;",con);
                using(var reader = await cmd.ExecuteReaderAsync())
                        {
                    while(await reader.ReadAsync())
                    {
                        l= new MovimientoAlmacen ();
                        l.IdMovimientoAlmacen = Convert.ToInt32(reader["IdMovimientoAlmacen"]);
                        l.IdMovimientoAlmacenPadre = Convert.ToInt32(reader["IdMovimientoAlmacenPadre"]);
                        l.NombreMovimientoAlmacen = Convert.ToString(reader["NombreMovimientoAlmacen"]);
                        l.FechaSaldoInicial = Convert.ToDateTime(reader["FechaSaldoInicial"]);
                        l.FechaInicial = Convert.ToDateTime(reader["FechaInicial"]);
                        l.FechaFinal = Convert.ToDateTime(reader["FechaFinal"]);
                        l.NumeroDeIngreso = Convert.ToInt32(reader["NumeroDeIngreso"]);
                        l.FechaReal = Convert.ToDateTime(reader["FechaReal"]);
                        l.Observacion = Convert.ToString(reader["Observacion"]);
                        l.Subtotal = Convert.ToInt32(reader["Subtotal"]);
                        l.Total = Convert.ToInt32(reader["Total"]);
                        l.IdGestion = Convert.ToInt32(reader["IdGestion"]);
                        l.IdEntidad = Convert.ToInt32(reader["IdEntidad"]);
                        l.IdUsuario = Convert.ToInt32(reader["IdUsuario"]);
                        l.IdAlmacen = Convert.ToInt32(reader["IdAlmacen"]);
                        l.IdEstadoIngreso = Convert.ToInt32(reader["IdEstadoIngreso"]);
                        l.FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"]);
                        l.EstadoRegistro = Convert.ToString(reader["EstadoRegistro"]);
                        list.Add(l);
                    }
                }
            }

            return list;
        }
        public async Task<MovimientoAlmacen> AgregaActualiza ( MovimientoAlmacen l, string t)
        {
            using (SqlConnection con = new SqlConnection (conect))
            {
                string cadena = "";
                if (t == "c")
                    cadena = "set @I = (SELECT ISNULL(MAX(IdMovimientoAlmacen), 0) + 1 FROM TrnMovimientoAlmacen);" +
                             "insert into TrnMovimientoAlmacen (IdMovimientoAlmacenPadre, NombreMovimientoAlmacen, FechaSaldoInicial, FechaInicial, FechaFinal, NumeroDeIngreso, FechaReal, Observacion, Subtotal, Total, IdGestion, IdEntidad, IdUsuario, IdAlmacen, IdEstadoIngreso, FechaRegistro, EstadoRegistro)" +
                             "values                           (@IdMovimientoAlmacenPadre, @NombreMovimientoAlmacen, @FechaSaldoInicial, @FechaInicial, @FechaFinal, @NumeroDeIngreso, @FechaReal, @Observacion, @Subtotal, @Total, @IdGestion, @IdEntidad, @IdUsuario, @IdAlmacen, @IdEstadoIngreso, @FechaRegistro, @EstadoRegistro)";

                if (t == "u")
                    cadena = "update TrnMovimientoAlmacen set IdMovimientoAlmacenPadre=@IdMovimientoAlmacenPadre,  NombreMovimientoAlmacen = @NombreMovimientoAlmacen,   FechaSaldoInicial = @FechaSaldoInicial,  FechaInicial = @FechaInicial,   FechaFinal = @FechaFinal,    NumeroDeIngreso = @NumeroDeIngreso,   FechaReal = @FechaReal,  Observacion = @Observacion,   Subtotal = @Subtotal,    Total = @Total,   IdGestion = @IdGestion,  IdEntidad = @IdEntidad,    IdUsuario = @IdUsuario,    IdAlmacen = @IdAlmacen,   IdEstadoIngreso = @IdEstadoIngreso, FechaRegistro = @FechaRegistro,   EstadoRegistro = @EstadoRegistro   where IdMovimientoAlmacen=@IdMovimientoAlmacen";

                using (SqlCommand cmd = new SqlCommand(cadena, con))
                {
                    SqlParameter Result = new SqlParameter("@I", SqlDbType.Int) { Direction = ParameterDirection.Output };
                    cmd.Parameters.Add(Result);
                    cmd.Parameters.AddWithValue("@IdMovimientoAlmacen", l.IdMovimientoAlmacen);
                    cmd.Parameters.AddWithValue("@IdMovimientoAlmacenPadre", l.IdMovimientoAlmacenPadre);
                    cmd.Parameters.AddWithValue("@NombreMovimientoAlmacen", l.NombreMovimientoAlmacen);
                    cmd.Parameters.AddWithValue("@FechaSaldoInicial", l.FechaSaldoInicial);
                    cmd.Parameters.AddWithValue("@FechaInicial", l.FechaInicial);
                    cmd.Parameters.AddWithValue("@FechaFinal", l.FechaFinal);
                    cmd.Parameters.AddWithValue("@NumeroDeIngreso", l.NumeroDeIngreso);
                    cmd.Parameters.AddWithValue("@FechaReal", l.FechaReal);
                    cmd.Parameters.AddWithValue("@Observacion", l.Observacion);
                    cmd.Parameters.AddWithValue("@Subtotal", l.Subtotal);
                    cmd.Parameters.AddWithValue("@Total", l.Total);
                    cmd.Parameters.AddWithValue("@IdGestion", l.IdGestion);
                    cmd.Parameters.AddWithValue("@IdEntidad", l.IdEntidad);
                    cmd.Parameters.AddWithValue("@IdUsuario", l.IdUsuario);
                    cmd.Parameters.AddWithValue("@IdAlmacen", l.IdAlmacen);
                    cmd.Parameters.AddWithValue("@IdEstadoIngreso", l.IdEstadoIngreso);
                    cmd.Parameters.AddWithValue("@FechaRegistro", l.FechaRegistro);
                    cmd.Parameters.AddWithValue("@EstadoRegistro", l.EstadoRegistro);
                    await con.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    if (t == "c")
                        l.IdMovimientoAlmacen = int.Parse(Result.Value.ToString());

                         
                }
                
            }
            return l;
        }
                
    }
}
