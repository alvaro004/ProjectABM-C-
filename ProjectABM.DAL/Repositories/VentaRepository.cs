using ProjectABM.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectABM.DAL.Repositories
{
    public class VentaRepository : IVentaRepository
    {

        //FETCH AND RETRIEVE ALL THE VENTAS
        public IEnumerable<Venta> ListVentas(OracleConnection connection)
        {
            var ventas = new List<Venta>();

            using (var command = new OracleCommand("pkg_abm_assigment.sp_list_ventas", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                var output = command.Parameters.Add("po_ventas", OracleDbType.RefCursor);
                output.Direction = ParameterDirection.Output;

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var venta = new Venta
                        {
                            venta_id = Convert.ToInt32(reader["venta_id"]),
                            venta_fecha = Convert.ToDateTime(reader["venta_fecha"]),
                            cliente_cliente_id = Convert.ToInt32(reader["cliente_cliente_id"])
                        };
                        ventas.Add(venta);
                    }
                }
            }

            return ventas;
        }

        //CREATE A VENTA
        //THIS IMPLEMENTATION IS NOT GOING TO WORK!!!!!!!!!!! 27/02/24
        public void CreateVenta(OracleConnection connection, Venta venta)
        {
            using (OracleCommand command = new OracleCommand("pkg_abm_assigment.sp_create_venta", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("p_venta_id", OracleDbType.Int32, ParameterDirection.Output); // Assuming ID is auto-generated
                command.Parameters.Add("p_venta_fecha", OracleDbType.Date).Value = venta.venta_fecha;
                command.Parameters.Add("p_cliente_cliente_id", OracleDbType.Int32).Value = venta.cliente_cliente_id;

                command.ExecuteNonQuery();

                // Optionally retrieve generated ID (if needed):
                // venta.venta_id = (int)command.Parameters["p_venta_id"].Value;  
            }
        }

    }
}
