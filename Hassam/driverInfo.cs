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
    public partial class driverInfo : Form
    {   //private SqlConnection connection;
        static string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\PMLS\\source\\repos\\RideQuest\\Hassam\\Database.mdf;Integrated Security=True;Connect Timeout=30";
        //static int driverId;
        public driverInfo()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void driverInfo_Load(object sender, EventArgs e)
        {

        }

        private void loginbt_Click(object sender, EventArgs e)
        {
            string number = noTB.Text;
            string type = typeTB.Text;
            string plate = plateTB.Text;
            string status = ava.Text;
            string loc = locTB.Text;
            string username = userTB.Text;
            string insertQuery = "INSERT INTO driversInfo (contact_number, vehicle_type, plate_number, availability_status, location, Username) " +
                        "VALUES (@contactNumber, @vehicleType, @plateNumber, @availabilityStatus, @location, @Username)";

            // Create a SqlConnection and a SqlCommand
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(insertQuery, connection))
            {
                // Add parameters to the SqlCommand
                command.Parameters.AddWithValue("@contactNumber", number);
                command.Parameters.AddWithValue("@vehicleType", type);
                command.Parameters.AddWithValue("@plateNumber", plate);
                command.Parameters.AddWithValue("@availabilityStatus", status);
                command.Parameters.AddWithValue("@location", loc);
                command.Parameters.AddWithValue("@Username", username);
                try
                {
                    // Open the connection
                    connection.Open();

                    // Execute the INSERT query
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Driver information added successfully!");
                        
                        this.Hide();
                        Driver driver = new Driver(username);
                        DialogResult result = driver.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Failed to add driver information.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }

            }
        }
    }
}
