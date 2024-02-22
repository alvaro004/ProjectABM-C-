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

namespace ProjectABM
{
    public partial class Form1 : Form
    {
        //creating the DB connection
        private string connectionString = "Data Source=10.6.2.148:1521/dbitades;User Id=ADN;Password=1234567;";
        public Form1()
        {
            InitializeComponent();
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
    }
}
