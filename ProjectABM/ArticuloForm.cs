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
            articulo.articulo_fecha = dateTimePickerArticulo.Value;

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

        }
    }
}
