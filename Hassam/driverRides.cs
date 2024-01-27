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
    
    public partial class driverRides : Form
    {
        static string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\PMLS\\source\\repos\\RideQuest\\Hassam\\Database.mdf;Integrated Security=True;Connect Timeout=30";
        static int driverId;
        public driverRides(int driverID)
        {
            InitializeComponent();
            driverId = driverID;
            LoadRidesForDriver();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            LoadRidesForDriver();

        }
        private void LoadRidesForDriver()
        {
            string selectQuery = "SELECT RideID, StartLocationID, EndLocationID, Price, RideStatus FROM Ride WHERE DriverID = @driverID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(selectQuery, connection))
            {
                command.Parameters.AddWithValue("@driverID", driverId);

                try
                {
                    connection.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Bind the DataTable to the DataGridView
                    dataGridView1.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading rides for driver: " + ex.Message);
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
