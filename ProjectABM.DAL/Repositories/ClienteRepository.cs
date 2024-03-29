﻿using System;
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
        //Get Clients
        public IEnumerable<Cliente> ListClientes(OracleConnection connection)
        {
            var clientes = new List<Cliente>();

            using (var command = new OracleCommand("pkg_abm_assigment.sp_list_clientes", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                var output = command.Parameters.Add("po_clientes", OracleDbType.RefCursor);
                output.Direction = ParameterDirection.Output;

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

        //Delete a Client by Cliente_Id
        public void DeleteCliente(OracleConnection connection, int cliente_id)
        {
            using (var command = new OracleCommand("pkg_abm_assigment.sp_delete_cliente", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("p_cliente_id", OracleDbType.Int32).Value = cliente_id;

                command.ExecuteNonQuery(); // Executes the delete stored procedure.
            }
        }

        //Update a Client by Client_Id
        public void UpdateCliente(OracleConnection connection, Cliente cliente)
        {
            using (var command = new OracleCommand("pkg_abm_assigment.sp_update_cliente", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("p_cliente_id", OracleDbType.Int32).Value = cliente.cliente_id;
                command.Parameters.Add("p_cliente_nom", OracleDbType.Varchar2).Value = cliente.cliente_nom;
                command.Parameters.Add("p_cliente_apellido", OracleDbType.Varchar2).Value = cliente.cliente_apellido;

                command.ExecuteNonQuery();
            }
        }

        //create a client

        public void CreateCliente(OracleConnection connection, Cliente cliente)
        {
            using (OracleCommand command = new OracleCommand("pkg_abm_assigment.sp_create_cliente", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("p_cliente_id", OracleDbType.Int32, ParameterDirection.Output); // Output parameter
                command.Parameters.Add("p_cliente_nom", OracleDbType.Varchar2).Value = cliente.cliente_nom;
                command.Parameters.Add("p_cliente_apellido", OracleDbType.Varchar2).Value = cliente.cliente_apellido;

                command.ExecuteNonQuery();

               // cliente.cliente_id = (int)command.Parameters["p_cliente_id"].Value;  // Get the generated ID
            }
        }

        
    }

    //aa
}

