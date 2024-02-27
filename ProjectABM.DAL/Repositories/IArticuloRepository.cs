using Oracle.ManagedDataAccess.Client;
using ProjectABM.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectABM.DAL.Repositories
{
    public interface IArticuloRepository
    {
        void CreateArticulo(OracleConnection connection, Articulo articulo);
        IEnumerable<Articulo> ListArticulos(OracleConnection connection);
        void DeleteArticulo(OracleConnection connection, int articuloId);
        void UpdateArticulo(OracleConnection connection, Articulo articulo);
    }
}
