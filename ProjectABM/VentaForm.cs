using Oracle.ManagedDataAccess.Client;
using ProjectABM.DAL.Models;
using ProjectABM.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectABM
{
    public partial class VentaForm : Form
    {
        //creating the DB connection
        //the config for the DB conecction is in the APP.config file in this folder
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["MyDatabaseConnection"].ConnectionString;

        private readonly IVentaRepository _ventaRepository;

        public VentaForm()
        {
            InitializeComponent();
            this.Load += new EventHandler(VentaForm_Load);
            _ventaRepository = new VentaRepository();
        }

        //We are going to focus on retrieve all the clients and its IDs
        // In your VentaForm
        private void VentaForm_Load(object sender, EventArgs e)
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                connection.Open();
                var clienteRepository = new ClienteRepository();
                var clients = clienteRepository.ListClientes(connection);

                // Pass clients to the next step (populate the combobox)
                PopulateClientComboBox(clients);
            }
        }

        //helper method to populate the combobox
        private void PopulateClientComboBox(IEnumerable<Cliente> clients)
        {
            comboBoxClient.DisplayMember = "cliente_nom";
            comboBoxClient.ValueMember = "cliente_id";
            comboBoxClient.DataSource = clients.ToList();
        }

        private void buttonCreateVenta_Click(object sender, EventArgs e)
        {
            var venta = new Venta();
            venta.venta_fecha = dateTimePickerVenta.Value;

            // Retrieve selected client
            var selectedClient = (Cliente)comboBoxClient.SelectedItem;
            venta.cliente_cliente_id = selectedClient.cliente_id;

            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    _ventaRepository.CreateVenta(connection, venta);
                    MessageBox.Show("Venta created successfully!");
                    // Optionally, clear the form or refresh data
                }
                catch (OracleException ex)
                {
                    MessageBox.Show("Error creating venta: " + ex.Message);
                }
            }
        }
    }

}
