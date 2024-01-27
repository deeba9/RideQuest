using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hassam
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            DialogResult dialogResult = form1.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 login = new Form1();
            DialogResult dialogResult = login.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void prodBT_Click(object sender, EventArgs e)
        {
            alldrivers alldrivers  = new alldrivers();
            DialogResult dialogResult = alldrivers.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            allClients allClients = new allClients();
            DialogResult result = allClients.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            allRides allRides = new allRides();
            DialogResult result = allRides.ShowDialog();
        }
    }
}
