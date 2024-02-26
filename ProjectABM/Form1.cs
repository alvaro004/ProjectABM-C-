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
using ProjectABM.DAL.Models;
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

            // Fetch and list clients when the windows form is open:
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    var clientes = _clienteRepository.ListClientes(connection);
                    dataGridViewClientes.DataSource = clientes.ToList();
                }
                catch (OracleException ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }


        //DELETE CLIENT

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

        //UPDATE CLIENT

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

        //INSERT NEW CLIENTS

        private void createNewClientButton_Click_Click(object sender, EventArgs e)
        {
            // Input Validation
            if (string.IsNullOrWhiteSpace(clientNameTextBox.Text) ||
                string.IsNullOrWhiteSpace(clientLastNameTextBox.Text))
            {
                MessageBox.Show("Please enter client name and last name.");
                return;  // Stop execution if input is missing
            }

            var newCliente = new Cliente
            {
                cliente_nom = clientNameTextBox.Text.Trim(),
                cliente_apellido = clientLastNameTextBox.Text.Trim()
            };

            using (var connection = new OracleConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    _clienteRepository.CreateCliente(connection, newCliente);

                    // Clear input fields
                    clientNameTextBox.Clear();
                    clientLastNameTextBox.Clear();

                    // Optionally, refresh the DataGridView
                    RefreshClientesDataGridView(connection);
                }
                catch (OracleException ex)
                {
                    MessageBox.Show("Error creating client: " + ex.Message);
                }
            }
        }

        // Method to refresh the DataGridView after delete.
        private void RefreshClientesDataGridView(OracleConnection connection)
        {
            var clientes = _clienteRepository.ListClientes(connection);
            dataGridViewClientes.DataSource = clientes.ToList();
        }

        private void label1_Click(object sender, EventArgs e){}
        private void name_Click(object sender, EventArgs e) {}

        //EVENT HANDLER TO HANDLE WHENEVER THE FORM1 IS OPEN OR NOT

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide(); // Hide Form1 may not be desired in this scenario
            ShowWelcomeForm();
        }

        //GO BACK TO WELCOME FORM

        private void returnToWelcomeButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            ShowWelcomeForm();
        }

        // METHOD TO SHOW AND HIDE WELCOME FORM

        private void ShowWelcomeForm()
        {
            var welcomeForm = Application.OpenForms.OfType<WelcomeForm>().FirstOrDefault();
            if (welcomeForm != null)
            {
                welcomeForm.Show();
            }
            else
            {
                welcomeForm = new WelcomeForm();
                welcomeForm.Show();
            }
        }

    }
}
