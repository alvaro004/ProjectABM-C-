using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using ProjectABM.DAL.Models;

namespace ProjectABM.DAL.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        // This method no longer needs a connection string since the connection is managed by Form1.cs
        public IEnumerable<Cliente> ListClientes(OracleConnection connection)
        {
            var clientes = new List<Cliente>();

            using (var command = new OracleCommand("pkg_abm_assigment.sp_list_clientes", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                var output = command.Parameters.Add("po_clientes", OracleDbType.RefCursor);
                output.Direction = ParameterDirection.Output;

                // Assuming connection is already open, we don't open it here
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var cliente = new Cliente
                        {
                            cliente_id = Convert.ToInt32(reader["cliente_id"]),
                            cliente_nom = reader["cliente_nom"].ToString(),
                            cliente_apellido = reader["cliente_apellido"].ToString()
                        };
                        clientes.Add(cliente);
                    }
                }
            }

            return clientes;
        }
    }
}

