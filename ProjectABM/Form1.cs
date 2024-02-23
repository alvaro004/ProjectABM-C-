using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using ProjectABM.DAL.Repositories;

namespace ProjectABM
{
    public partial class Form1 : Form
    {
        //creating the DB connection
        private string connectionString = "Data Source=10.6.2.148:1521/dbitades;User Id=ADN;Password=12345678;";

        private readonly IClienteRepository _clienteRepository;

        public Form1()
        {
            InitializeComponent();
            _clienteRepository = new ClienteRepository();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MessageBox.Show("Connection Successful!");
                }
                catch (OracleException ex)
                {
                    MessageBox.Show("Connection Failed: " + ex.Message);
                }
            }
        }

        private void buttonGetClientes(object sender, EventArgs e)
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    var clientes = _clienteRepository.ListClientes(connection);
                    // Do something with the retrieved clientes, like binding to a grid view
                    dataGridViewClientes.DataSource = clientes.ToList();


                }
                catch (OracleException ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
    }
}
