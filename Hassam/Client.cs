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
    public partial class Client : Form
    {
       static int id;
        public Client(int ID)
        {
            InitializeComponent();
            id = ID;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            this.Hide();
            Form1 login = new Form1();
            DialogResult dialogResult = login.ShowDialog();
        }

        private void prodBT_Click(object sender, EventArgs e)
        {
            
            this.Hide();
            bookaride bookaride = new bookaride(id);
            DialogResult dialogResult = bookaride.ShowDialog();
          

        }

        private void Client_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1     = new Form1();
            DialogResult dialogResult = form1.ShowDialog(); 
        }
    }
}
