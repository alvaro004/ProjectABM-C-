using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectABM
{
    public partial class WelcomeForm : Form
    {
        public WelcomeForm()
        {
            InitializeComponent();
        }

        private void manageClientsButton_Click_Click(object sender, EventArgs e)
        {
            var clientForm = new Form1(); 
            clientForm.Show();
            this.Hide();  //hide the welcome form
        }

        private void manageArticulosButton_Click_Click_Click(object sender, EventArgs e)
        {
            var articuloForm = new ArticuloForm();
            articuloForm.Show();
            this.Hide();
        }
    }
}
