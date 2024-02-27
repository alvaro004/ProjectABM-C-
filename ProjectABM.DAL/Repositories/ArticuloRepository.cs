using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration; // For accessing the connection string
using Oracle.ManagedDataAccess.Client;
using ProjectABM.DAL.Models;
using System.Data;

namespace ProjectABM.DAL.Repositories
{
    public class ArticuloRepository : IArticuloRepository // Implement the interface
    {
        //CREATE A NEW ARTICULO

        public void CreateArticulo(OracleConnection connection, Articulo articulo) 
        {
            using (OracleCommand command = new OracleCommand("pkg_abm_assigment.sp_create_articulo", connection))
            {
                
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("p_articulo_id", OracleDbType.Int32, ParameterDirection.Output);
                command.Parameters.Add("p_articulo_fecha", OracleDbType.Date).Value = articulo.articulo_fecha;

                command.ExecuteNonQuery();    

                // Retrieve the generated ID 
                //articulo.articulo_id = (int)command.Parameters["p_articulo_id"].Value;  
            }
        }

        //GET ALL THE ARTICULOS
        public IEnumerable<Articulo> ListArticulos(OracleConnection connection)
        {
            var articulos = new List<Articulo>();

            using (var command = new OracleCommand("pkg_abm_assigment.sp_list_articulos", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                var output = command.Parameters.Add("po_articulos", OracleDbType.RefCursor);
                output.Direction = ParameterDirection.Output;

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var articulo = new Articulo
                        {
                            articulo_id = Convert.ToInt32(reader["articulo_id"]),
                            articulo_fecha = Convert.ToDateTime(reader["articulo_fecha"])
                        };
                       articulos.Add(articulo);
                    }
                }
            }

            return articulos;
        }

        //DELETE AN ARTICULO
        public void DeleteArticulo(OracleConnection connection, int articulo_id)
        {
            using (var command = new OracleCommand("pkg_abm_assigment.sp_delete_articulo", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("p_articulo_id", OracleDbType.Int32).Value = articulo_id;

                command.ExecuteNonQuery(); // Executes the delete stored procedure.
            }
        }

        //UPDATE AN ARTICULO
        public void UpdateArticulo(OracleConnection connection, Articulo articulo)
        {
            using (var command = new OracleCommand("pkg_abm_assigment.sp_update_articulo", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("p_articulo_id", OracleDbType.Int32).Value = articulo.articulo_id;
                command.Parameters.Add("p_articulo_fecha", OracleDbType.Date).Value = articulo.articulo_fecha;

                command.ExecuteNonQuery();
            }
        }

    }
}
