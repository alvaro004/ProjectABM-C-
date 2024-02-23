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

        private void buttonDeleteClient_Click(object sender, EventArgs e)
        {
            // Get the selected row.
            if (dataGridViewClientes.SelectedRows.Count > 0)
            {
                // Assuming your DataGridView is bound to a List<Cliente>, and ClienteId is the primary key.
                int selectedClienteId = Convert.ToInt32(dataGridViewClientes.SelectedRows[0].Cells["Cliente_id"].Value);

                using (OracleConnection connection = new OracleConnection(connectionString))
                {
                    try
                    {
                        connection.Open();
                        _clienteRepository.DeleteCliente(connection, selectedClienteId);

                        // Optionally, refresh the DataGridView.
                        RefreshClientesDataGridView(connection);
                    }
                    catch (OracleException ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a row or a client to delete.");
            }
        }

        //update client

        // Method to refresh the DataGridView after delete.
        private void RefreshClientesDataGridView(OracleConnection connection)
         {
             var clientes = _clienteRepository.ListClientes(connection);
             dataGridViewClientes.DataSource = clientes.ToList();
         }

        private void dataGridViewClientesCellValueChanged_Click(object sender, EventArgs e)
        {
            if (dataGridViewClientes.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridViewClientes.SelectedRows[0];

                var updatedCliente = new DAL.Models.Cliente
                {
                    cliente_id = Convert.ToInt32(selectedRow.Cells["cliente_id"].Value), // Primary key
                    cliente_nom = selectedRow.Cells["cliente_nom"].Value?.ToString() ?? "",
                    cliente_apellido = selectedRow.Cells["cliente_apellido"].Value?.ToString() ?? ""
                };

                using (OracleConnection connection = new OracleConnection(connectionString))
                {
                    try
                    {
                        connection.Open();
                        _clienteRepository.UpdateCliente(connection, updatedCliente);
                        MessageBox.Show("Client updated!");
                        RefreshClientesDataGridView(connection);
                    }
                    catch (OracleException ex)
                    {
                        MessageBox.Show("Update Error: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a row or a client to update.");
            }
        }
    }
}
