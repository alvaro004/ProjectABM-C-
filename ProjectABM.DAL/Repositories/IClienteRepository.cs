using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectABM.DAL.Models;
using Oracle.ManagedDataAccess.Client;

namespace ProjectABM.DAL.Repositories
{
    public interface IClienteRepository
    {
        IEnumerable<Cliente> ListClientes(OracleConnection connection);
        //void CreateCliente(Cliente cliente);
        //void UpdateCliente(Cliente cliente);
        //void DeleteCliente(int clienteId);
    }
}
