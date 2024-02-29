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
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO; // For FileStream 

namespace ProjectABM
{
    public partial class VentaForm : Form
    {
        //creating the DB connection. The config for the DB conecction is in the APP.config file in this folder
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["MyDatabaseConnection"].ConnectionString;

        private readonly IVentaRepository _ventaRepository; //bring all the methonds from the interface

        //Initialize components
        public VentaForm()
        {
            InitializeComponent();

            dataGridViewVenta.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; //AutoSizeColumns
            dataGridViewArticulos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; //AutoSizeColumns

            this.Load += new EventHandler(VentaForm_Load); //show the Venta List when the view is loaded

            _ventaRepository = new VentaRepository();

            dataGridViewVenta.CellEnter += dataGridViewVenta_CellEnter;  //call event handler to prevent edit IDs in the Data Grid 

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

        //////////////////////////////////////////////////////////////////////////////////////
        //CRUD OPERATIONS

        //CREATE A NEW VENTA
        private void buttonCreateVenta_Click(object sender, EventArgs e)
        {
            var venta = new Venta();
            venta.venta_fecha = dateTimePickerVenta.Value.Date;

            // Retrieve selected client
            var selectedClient = (Cliente)comboBoxClient.SelectedItem;
            venta.cliente_cliente_id = selectedClient.cliente_id;

            // Get selected article IDs
            var selectedArticuloIds = dataGridViewArticulos.SelectedRows.Cast<DataGridViewRow>()
                                                           .Select(row => Convert.ToInt32(row.Cells["articulo_id"].Value))
                                                           .ToList();

            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    _ventaRepository.CreateVenta(connection, venta, selectedArticuloIds);
                    MessageBox.Show("Venta created successfully!");

                    //Refresh the data Grid
                    RefreshVentaDataGridView(connection);
                }
                catch (OracleException ex)
                {
                    MessageBox.Show("Error creating venta: " + ex.Message);
                }
            }
        }

        //DELETE A VENTA
        private void DeleteButtonVenta_Click(object sender, EventArgs e)
        {
            // Get the selected row.
            if (dataGridViewVenta.SelectedRows.Count > 0)
            {
                int selectedVentaId = Convert.ToInt32(dataGridViewVenta.SelectedRows[0].Cells["venta_id"].Value);

                using (OracleConnection connection = new OracleConnection(connectionString))
                {
                    try
                    {
                        connection.Open();
                        _ventaRepository.DeleteVenta(connection, selectedVentaId);
                        MessageBox.Show("Client Deleted successfully!"); 
                        RefreshVentaDataGridView(connection); // Refresh the DataGridView
                    }
                    catch (OracleException ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a row or a venta to delete.");
            }
        }

        //UPDATE VENTA
        private void buttonUpdateVenta_Click(object sender, EventArgs e)
        {
            if (dataGridViewVenta.SelectedRows.Count > 0)
            {
                Venta ventaToUpdate = GetVentaFromForm();

                using (OracleConnection connection = new OracleConnection(connectionString))
                {
                    try
                    {
                        connection.Open();
                        _ventaRepository.UpdateVenta(connection, ventaToUpdate);
                        RefreshVentaDataGridView(connection); // Refresh
                        MessageBox.Show("Venta updated!");
                    }
                    catch (OracleException ex)
                    {
                        MessageBox.Show("Error updating venta: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a row or a venta to update.");
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////
        ///COMPLEMENT METHODS
        //Retrieve all the clients, articulso and their IDs
        private void VentaForm_Load(object sender, EventArgs e)
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                connection.Open();
                var clienteRepository = new ClienteRepository();
                var clients = clienteRepository.ListClientes(connection);

                // Pass clients to the next step (populate the combobox)
                PopulateClientComboBox(clients);
                var articuloRepository = new ArticuloRepository();
                var articles = articuloRepository.ListArticulos(connection);

                // Bind to DataGridView
                dataGridViewArticulos.DataSource = articles.ToList();
            }
        }

        //Helper method to populate the combobox
        private void PopulateClientComboBox(IEnumerable<Cliente> clients)
        {
            comboBoxClient.DisplayMember = "cliente_nom";
            comboBoxClient.ValueMember = "cliente_id";
            comboBoxClient.DataSource = clients.ToList();
        }

        //Go back to Welcome Form
        private void returnToWelcomeButton_Click_Click(object sender, EventArgs e)
        {
            this.Hide();
            ShowWelcomeForm();
        }

        // Logic for the showWelcomeForm method
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
        private void RefreshVentaDataGridView(OracleConnection connection)
        {
            var articulos = _ventaRepository.ListVentas(connection);
            dataGridViewVenta.DataSource = articulos.ToList();
        }

        //Show the welcome form when the Venta Form is closed
        private void VentaForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            ShowWelcomeForm();
        }

        //Generate a new venta object from  the Venta Form, this time having the client data
        private Venta GetVentaFromForm()
        {
            Venta venta = new Venta();
            venta.venta_id = Convert.ToInt32(dataGridViewVenta.SelectedRows[0].Cells["venta_id"].Value);
            venta.venta_fecha = Convert.ToDateTime(dataGridViewVenta.SelectedRows[0].Cells["venta_fecha"].Value);

            // Retrieve the client Id
            var selectedClient = (Cliente)comboBoxClient.SelectedItem;
            venta.cliente_cliente_id = selectedClient.cliente_id;

            return venta;
        }

        private void dataGridViewVenta_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            // Column names for convenience
            string ventaIDColumn = "venta_id";
            string clientIDColumn = "cliente_cliente_id";

            if (e.ColumnIndex == dataGridViewVenta.Columns[ventaIDColumn].Index ||
                e.ColumnIndex == dataGridViewVenta.Columns[clientIDColumn].Index)
            {
                dataGridViewVenta.CurrentCell.ReadOnly = true;
            }
            else
            {
                dataGridViewVenta.CurrentCell.ReadOnly = false;
            }
        }

        //Generate PDF
        private void buttonGeneratePDF_Click(object sender, EventArgs e)
        {
            GenerateVentaPDF();
        }

        //Logic for Generate PDF
        private void GenerateVentaPDF()
        {
            string pdfFilePath = @"C:\Temp\ventas.pdf"; // Customize output path

            // Basic PDF Setup
            Document document = new Document();
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(pdfFilePath, FileMode.Create));
            document.Open();

            // Header (Illustrative)
            Paragraph title = new Paragraph("Venta Report");
            title.Alignment = Element.ALIGN_CENTER;
            document.Add(title);
            document.Add(new Paragraph(" ")); // Add a space

            // Extract Data
            var gridData = ExtractDataFromDataGridView(dataGridViewVenta);

            // Create Table
            PdfPTable table = CreatePdfTable(gridData);
            document.Add(table);

            // Close
            document.Close();

            MessageBox.Show("PDF Generated Successfully!");
            // Optionally open the PDF:
            System.Diagnostics.Process.Start(pdfFilePath);
        }

        // Helper method
        private List<List<string>> ExtractDataFromDataGridView(DataGridView dataGridView)
        {
            var data = new List<List<string>>();

            // Add column headers
            var headers = new List<string>();
            foreach (DataGridViewColumn col in dataGridView.Columns)
            {
                headers.Add(col.HeaderText);
            }
            data.Add(headers);

            // Add rows
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                var rowData = new List<string>();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    rowData.Add(cell.Value?.ToString() ?? ""); // Handle null cell values
                }
                data.Add(rowData);
            }

            return data;
        }

        private PdfPTable CreatePdfTable(List<List<string>> data)
        {
            // Column Count (based on the data)
            PdfPTable table = new PdfPTable(dataGridViewVenta.Columns.Count);

            // Headers
            foreach (DataGridViewColumn col in dataGridViewVenta.Columns)
            {
                PdfPCell headerCell = new PdfPCell(new Phrase(col.HeaderText));
                headerCell.BackgroundColor = BaseColor.LIGHT_GRAY;
                table.AddCell(headerCell);
            }

            // Rows
            foreach (var row in data.Skip(1)) // Skip the header row
            {
                foreach (var cellValue in row)
                {
                    table.AddCell(cellValue);
                }
            }

            return table;
        }

        // Fetch Sales (in VentaForm_Load or similar)
        private void FetchSales(DateTime? filterDate = null)
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    var ventas = _ventaRepository.ListVentas(connection, filterDate);
                    dataGridViewVenta.DataSource = ventas.ToList();
                }
                catch (OracleException ex)
                {
                    MessageBox.Show("Error fetching sales data: " + ex.Message);
                }
            }
        }

        // Event Handler for Date Filter 
        private void ButtonSortByDay_Click(object sender, EventArgs e)
        {
            DateTime selectedDate = datePickerFilterByDay.Value;
            FetchSales(selectedDate); // Fetch filtered data
        }

        private void buttonFetchAllVentasList_Click(object sender, EventArgs e)
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    RefreshVentaDataGridView(connection); //Refresh the data Grid
                }
                catch (OracleException ex)
                {
                    MessageBox.Show("Connection error: " + ex.Message);
                }
            }
        }
        //////////////////////////////////////////////////////////////////////////////////////
    }

}
