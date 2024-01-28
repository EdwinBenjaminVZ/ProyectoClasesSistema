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
    public class MovimientoAlmacenDetalleRepository : IMovimientoAlmacenDetalleRepository
    {
        private readonly string conect;
        public MovimientoAlmacenDetalleRepository(IConfiguration _con)
        {
            conect = _con.GetConnectionString("conBase");
        }
        public async Task<List<MovimientoAlmacenDetalle>> GetList()
        {
            List<MovimientoAlmacenDetalle> list = new List<MovimientoAlmacenDetalle>();
            MovimientoAlmacenDetalle l;
            using (SqlConnection con = new SqlConnection(conect))
            {
                await con.OpenAsync();
                SqlCommand cmd = new SqlCommand("select * from TrnMovimientoAlmacenDetalle;", con);
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        l = new MovimientoAlmacenDetalle();
                        l.IdMovimientoAlmacenDetalle = Convert.ToInt32(reader["IdMovimientoAlmacenDetalle"]);
                        l.IdMovimientoAlmacen = Convert.ToInt32(reader["IdMovimientoAlmacen"]);
                        l.IdIngresoDetalle = Convert.ToInt32(reader["IdIngresoDetalle"]);
                        l.IdInsumo = Convert.ToInt32(reader["IdInsumo"]);
                        l.IdIngreso = Convert.ToInt32(reader["IdIngreso"]);
                        l.Cantidad = Convert.ToInt32(reader["Cantidad"]);
                        l.PrecioUnitario = Convert.ToInt32(reader["PrecioUnitario"]);
                        l.SubTotal = Convert.ToInt32(reader["SubTotal"]);
                        l.Lote = Convert.ToString(reader["Lote"]);
                        l.FechaVencimiento = Convert.ToDateTime(reader["FechaVencimiento"]);
                        l.FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"]);
                        l.EstadoRegistro = Convert.ToString(reader["EstadoRegistro"]);
                        list.Add(l);
                    }
                }
            }

            return list;
        }
        public async Task<MovimientoAlmacenDetalle> AgregaActualiza(MovimientoAlmacenDetalle l, string t)
        {

            using (SqlConnection con = new SqlConnection(conect))
            {
                string cadena = "";
                if (t == "c")
                    cadena = "set @I = (SELECT ISNULL(MAX(IdMovimientoAlmacenDetalle), 0) + 1 FROM TrnMovimientoAlmacenDetalle);" +
                             "insert into TrnMovimientoAlmacen (IdMovimientoAlmacen,  IdIngresoDetalle,  IdInsumo,  IdIngreso,  Cantidad,  PrecioUnitario,  SubTotal,  Lote,  FechaVencimiento,  FechaRegistro,  EstadoRegistro)" +
                             "values                          (@IdMovimientoAlmacen, @IdIngresoDetalle, @IdInsumo, @IdIngreso, @Cantidad, @PrecioUnitario, @SubTotal, @Lote, @FechaVencimiento, @FechaRegistro, @EstadoRegistro)";

                if (t == "u")
                    cadena = "update TrnMovimientoAlmacenDetalle set IdMovimientoAlmacen=@IdMovimientoAlmacen,  IdIngresoDetalle = @IdIngresoDetalle,   IdInsumo = @IdInsumo,  IdIngreso = @IdIngreso,   Cantidad = @Cantidad,    PrecioUnitario = @PrecioUnitario,   SubTotal = @SubTotal,  Lote = @Lote,  FechaVencimiento = @FechaVencimiento,    FechaRegistro = @FechaRegistro,   EstadoRegistro = @EstadoRegistro IdEstadoIngreso = @IdEstadoIngreso, FechaRegi   where IdMovimientoAlmacenDetalle=@IdMovimientoAlmacenDetalle";

                using (SqlCommand cmd = new SqlCommand(cadena, con))
                {
                    SqlParameter Result = new SqlParameter("@I", SqlDbType.Int) { Direction = ParameterDirection.Output };
                    cmd.Parameters.Add(Result);
                    cmd.Parameters.AddWithValue("@IdMovimientoAlmacenDetalle", l.IdMovimientoAlmacenDetalle);
                    cmd.Parameters.AddWithValue("@IdMovimientoAlmacen", l.IdMovimientoAlmacen);
                    cmd.Parameters.AddWithValue("@IdIngresoDetalle", l.IdIngresoDetalle);
                    cmd.Parameters.AddWithValue("@IdInsumo", l.IdInsumo);
                    cmd.Parameters.AddWithValue("@IdIngreso", l.IdIngreso);
                    cmd.Parameters.AddWithValue("@Cantidad", l.Cantidad);
                    cmd.Parameters.AddWithValue("@PrecioUnitario", l.PrecioUnitario);
                    cmd.Parameters.AddWithValue("@SubTotal", l.SubTotal);
                    cmd.Parameters.AddWithValue("@Lote", l.Lote);
                    cmd.Parameters.AddWithValue("@FechaVencimiento", l.FechaVencimiento);
                    cmd.Parameters.AddWithValue("@FechaRegistro", l.FechaRegistro);
                    cmd.Parameters.AddWithValue("@EstadoRegistro", l.EstadoRegistro);
                    await con.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    if (t == "c")
                        l.IdMovimientoAlmacenDetalle = int.Parse(Result.Value.ToString());


                }

            }
            return l;
        }

    }
}
