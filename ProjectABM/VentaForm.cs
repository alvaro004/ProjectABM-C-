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

        private readonly IVentaRepository _ventaRepository; //bring all the methonds from the interface

        public VentaForm()
        {
            InitializeComponent();

            this.Load += new EventHandler(VentaForm_Load);

            _ventaRepository = new VentaRepository(); 

            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    var ventas = _ventaRepository.ListVentas(connection);
                    MethodUtils.RefreshDataGridView(dataGridViewVenta, ventas, connection);
                }
                catch (OracleException ex)
                {
                    MessageBox.Show("Error fetching sales data: " + ex.Message);
                }
            }


        }

        //We are going to focus on retrieve all the clients and its IDs
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

        //Helper method to populate the combobox
        private void PopulateClientComboBox(IEnumerable<Cliente> clients)
        {
            comboBoxClient.DisplayMember = "cliente_nom";
            comboBoxClient.ValueMember = "cliente_id";
            comboBoxClient.DataSource = clients.ToList();
        }

        //CREATE A NEW VENTA
        private void buttonCreateVenta_Click(object sender, EventArgs e)
        {
            var venta = new Venta();
            venta.venta_fecha = dateTimePickerVenta.Value.Date;

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

                    //Refresh the data Grid
                    RefreshClientesDataGridView(connection);
                }
                catch (OracleException ex)
                {
                    MessageBox.Show("Error creating venta: " + ex.Message);
                }
            }
        }

        private void returnToWelcomeButton_Click_Click(object sender, EventArgs e)
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

        // Method to refresh the DataGridView. 
        private void RefreshClientesDataGridView(OracleConnection connection)
        {
            var articulos = _ventaRepository.ListVentas(connection);
            dataGridViewVenta.DataSource = articulos.ToList();
        }
    }

}
