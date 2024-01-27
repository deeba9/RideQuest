using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Hassam
{
    public partial class Driver : Form
    {
        static string username;
        static string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\PMLS\\source\\repos\\RideQuest\\Hassam\\Database.mdf;Integrated Security=True;Connect Timeout=30";
        static int driverId;
        public Driver(string user)
        {
            InitializeComponent();
            username = user;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 login = new Form1();
            DialogResult dialogResult = login.ShowDialog();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            
        }

        private void prodBT_Click(object sender, EventArgs e)
        {
            string selectQuery = "Select driver_id from driversInfo where Username = @Username";
            using (SqlConnection connection2 = new SqlConnection(connectionString))

            using (SqlCommand cmd = new SqlCommand(selectQuery, connection2))
            {
                connection2.Open();
                cmd.Parameters.AddWithValue("@Username", username);
                driverId = (int)cmd.ExecuteScalar();
                if (driverId != 0)
                {
                    driverRides driverRides = new driverRides(driverId);
                    DialogResult result = driverRides.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Driver ID bC");
                }

            }
          
         }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            DialogResult result = form1.ShowDialog();
        }

        private void Driver_Load(object sender, EventArgs e)
        {

        }
    }
}

