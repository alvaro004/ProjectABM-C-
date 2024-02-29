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
        public void CreateVenta(OracleConnection connection, Venta venta, IEnumerable<int> selectedArticuloIds)
        {
            
            using (OracleCommand command = new OracleCommand("pkg_abm_assigment.sp_create_venta", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("p_venta_id", OracleDbType.Int32, ParameterDirection.Output); // ID is auto-generated
                command.Parameters.Add("p_venta_fecha", OracleDbType.Date).Value = venta.venta_fecha;
                command.Parameters.Add("p_cliente_cliente_id", OracleDbType.Int32).Value = venta.cliente_cliente_id;

                //Strig approach
                command.Parameters.Add("p_articulo_ids", OracleDbType.Varchar2).Value = string.Join(",", selectedArticuloIds);

                command.ExecuteNonQuery();

            }
        }

        //DELETE A VENTA
        public void DeleteVenta(OracleConnection connection, int ventaId)
        {
            using (var command = new OracleCommand("pkg_abm_assigment.sp_delete_venta", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("p_venta_id", OracleDbType.Int32).Value = ventaId;

                command.ExecuteNonQuery(); // Executes the delete stored procedure.
            }
        }

        //UPDATE VENTA
        public void UpdateVenta(OracleConnection connection, Venta venta)
        {
            using (var command = new OracleCommand("pkg_abm_assigment.sp_update_venta", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("p_venta_id", OracleDbType.Int32).Value = venta.venta_id;
                command.Parameters.Add("p_venta_fecha", OracleDbType.Date).Value = venta.venta_fecha;

                command.ExecuteNonQuery();
            }
        }

    }
}
