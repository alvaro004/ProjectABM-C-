using Oracle.ManagedDataAccess.Client;
using ProjectABM.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectABM.DAL.Repositories
{
    public interface IVentaRepository
    {
        IEnumerable<Venta> ListVentas(OracleConnection connection);
        void CreateVenta(OracleConnection connection, Venta venta);
    }
}
