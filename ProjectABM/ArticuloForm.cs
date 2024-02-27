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

        ////GO BACK TO WELCOME FORM WHEN THE WINDOW IS CLOSED

        private void ArticuloForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            ShowWelcomeForm();
        }

        //GO BACK TO WELCOME FORM

        private void returnToWelcomeButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            ShowWelcomeForm();
        }

        // Method to refresh the DataGridView after delete.
        private void RefreshClientesDataGridView(OracleConnection connection)
        {
            var articulos = _articuloRepository.ListArticulos(connection);
            dataGridViewArticulos.DataSource = articulos.ToList();
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

                        // Optionally, refresh the DataGridView.
                        RefreshClientesDataGridView(connection); // Assuming you have such a method.
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
            if(dataGridViewArticulos.SelectedRows.Count > 0)
            {
                Articulo articuloToUpdate = GetArticuloFromForm();

                using (OracleConnection connection = new OracleConnection(connectionString))
                {
                    try
                    {
                        connection.Open();
                        _articuloRepository.UpdateArticulo(connection, articuloToUpdate);
                        RefreshClientesDataGridView(connection); // Refresh if needed
                        MessageBox.Show("Article updated!");
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

        //METHOD TO AVOID THE ID FIELD MANIPULATION IN THE DATA GRID

        private void dataGridViewArticulos_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            // Check for ID column
            if (e.ColumnIndex == dataGridViewArticulos.Columns["articulo_id"].Index)
            {
                // Prevent editing by making the cell read-only
                dataGridViewArticulos.CurrentCell.ReadOnly = true;
            }
            else
            {
                // Allow editing for other cells
                dataGridViewArticulos.CurrentCell.ReadOnly = false;
            }
        }


        //Helper Method to Extract Data
        private Articulo GetArticuloFromForm()
        {
            Articulo articulo = new Articulo();
            articulo.articulo_id = Convert.ToInt32(dataGridViewArticulos.SelectedRows[0].Cells["articulo_id"].Value);

            // Extract DateTime (assuming a column named 'Fecha' of DateTime type)
            articulo.articulo_fecha = Convert.ToDateTime(dataGridViewArticulos.SelectedRows[0].Cells["articulo_fecha"].Value);
            //articulo.articulo_fecha = dateTimePickerArticulo.Value;

            return articulo;
        }

    }
}
