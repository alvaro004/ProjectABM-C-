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

        public VentaForm()
        {
            InitializeComponent();
            this.Load += new EventHandler(VentaForm_Load);
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

        //helper method
        private void PopulateClientComboBox(IEnumerable<Cliente> clients)
        {
            comboBoxClient.DisplayMember = "cliente_nom";
            comboBoxClient.ValueMember = "cliente_id";
            comboBoxClient.DataSource = clients.ToList();
        }


    }

}
