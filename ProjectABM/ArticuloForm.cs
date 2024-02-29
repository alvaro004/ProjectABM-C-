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
    public partial class ArticuloForm : Form
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["MyDatabaseConnection"].ConnectionString;

        private readonly IArticuloRepository _articuloRepository;
        public ArticuloForm()
        {
            InitializeComponent();
            _articuloRepository = new ArticuloRepository();

            dataGridViewArticulos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; //AutoSizeColumns
            //call event handler to prevent edit ID in the Data Grid 
            MethodUtils.PreventIdEditing(dataGridViewArticulos, "articulo_id");

            //FETCH AND LIST ARTICULOS WHEN THE WINDOWS FORM IS OPEN 
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    var articulos = _articuloRepository.ListArticulos(connection);
                    dataGridViewArticulos.DataSource = articulos.ToList();
                }
                catch (OracleException ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
        //////////////////////////////////////////////////////////////////////////////////////
        //CRUD OPERATIONS
        //////////////////////////////////////////////////////////////////////////////////////
        
        //CREATE A NEW ARTICULO 
        private void CreateNewArticule_Click(object sender, EventArgs e)
        {
            Articulo articulo = new Articulo();
            articulo.articulo_fecha = dateTimePickerArticulo.Value.Date;

            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    _articuloRepository.CreateArticulo(connection, articulo);
                    MessageBox.Show("Article Created Successfully!");

                    //Refresh the data Grid
                    RefreshClientesDataGridView(connection);
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Error creating article: " + ex.Message);
                }
            }
        }

        //DELETE AN ARTICULO 
        private void buttonDeleteArticulo_Click(object sender, EventArgs e)
        {
            // Get the selected row.
            if (dataGridViewArticulos.SelectedRows.Count > 0)
            {
                // Assuming an Articulo_id column
                int selectedArticuloId = Convert.ToInt32(dataGridViewArticulos.SelectedRows[0].Cells["Articulo_id"].Value);

                using (OracleConnection connection = new OracleConnection(connectionString))
                {
                    try
                    {
                        connection.Open();
                        _articuloRepository.DeleteArticulo(connection, selectedArticuloId);

                        // Refresh the DataGridView
                        CallMethodutilRefreshDataGrid(connection);
                    }
                    catch (OracleException ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a row or an article to delete.");
            }
        }

        //UPDATE ARTICULO
        private void buttonUpdateArticulo_Click(object sender, EventArgs e)
        {
            if (dataGridViewArticulos.SelectedRows.Count > 0)
            {
                Articulo articuloToUpdate = GetArticuloFromForm();

                using (OracleConnection connection = new OracleConnection(connectionString))
                {
                    try
                    {
                        connection.Open();
                        _articuloRepository.UpdateArticulo(connection, articuloToUpdate);
                        MessageBox.Show("Article updated!");

                        CallMethodutilRefreshDataGrid(connection); // Refresh the DataGridView
                    }
                    catch (OracleException ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a row or an article to update.");
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////
        //COMPLEMENT METHODS
        //////////////////////////////////////////////////////////////////////////////////////

        //Method to show and hide welcome form 
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

        ////Go back to welcome form when the window is closed 
        private void ArticuloForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            ShowWelcomeForm();
        }

        //Go back to welcome form 
        private void returnToWelcomeButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            ShowWelcomeForm();
        }

        // Method to refresh the DataGridView. 
        private void RefreshClientesDataGridView(OracleConnection connection)
        {
            var articulos = _articuloRepository.ListArticulos(connection);
            dataGridViewArticulos.DataSource = articulos.ToList();
        }

         //Helper Method to Extract Data 
        private Articulo GetArticuloFromForm()
        {
            Articulo articulo = new Articulo();
            articulo.articulo_id = Convert.ToInt32(dataGridViewArticulos.SelectedRows[0].Cells["articulo_id"].Value);

            // Extract DateTime
            articulo.articulo_fecha = Convert.ToDateTime(dataGridViewArticulos.SelectedRows[0].Cells["articulo_fecha"].Value);

            return articulo;
        }

        //Method to call the method utils to refresh the data grid 
        private void CallMethodutilRefreshDataGrid(OracleConnection connection)
        {
            var articulos = _articuloRepository.ListArticulos(connection);
            MethodUtils.RefreshDataGridView<Articulo>(dataGridViewArticulos, articulos, connection);
        }
        //////////////////////////////////////////////////////////////////////////////////////
    }

}
