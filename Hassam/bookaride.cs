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
    public partial class bookaride : Form
    {
        //private SqlConnection connection;
        // yahan change krdena copy jahan se kia mein ne
        static string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\PMLS\\source\\repos\\RideQuest\\Hassam\\Database.mdf;Integrated Security=True;Connect Timeout=30";
        static int clientID;
        //har form mein max 7 hain shayad un mein bs iss jagah pr connection string change krdena
        //jo mein ne abhi jahan se copy kia!!!
        public bookaride(int ID)
        {
            InitializeComponent();
            clientID = ID;
        }

        private void bookaride_Load(object sender, EventArgs e)
        {

        }

        private void loginbt_Click(object sender, EventArgs e)
        {
            //string clientID = numTB.Text;  // Assuming numTB contains the client's ID
            string startLocationID = currTB.Text;  // Assuming currTB contains the start location ID
            string endLocationID = dropTB.Text;  // Assuming dropTB contains the drop location ID
            string price = priceTB.Text;
            int isDriverAvailable = CheckDriverAvailability(startLocationID, endLocationID);

            if (isDriverAvailable != 0)
            {
                // Insert the ride information into the Ride table
                InsertRideAsync(clientID, startLocationID, endLocationID, price, isDriverAvailable);

            }
            else
            {
                MessageBox.Show("No available driver at the drop location.");
            }

    }

        private int CheckDriverAvailability(string startLocationID, string endLocationID)
        {
            string selectQuery = "SELECT driver_id FROM driversInfo WHERE location = @startLocationID AND availability_status = 'Yes'";

            // Create a SqlConnection and a SqlCommand
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(selectQuery, connection))
            {
                // Add parameters to the SqlCommand
                command.Parameters.AddWithValue("@startLocationID", startLocationID);
                try
                {
  
                    connection.Open();

                    // Execute the SELECT query
                    int id = (int)command.ExecuteScalar();

                    // Return true if at least one driver is available, false otherwise
                    return id;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error checking driver availability: " + ex.Message);
                    return 0;
                }
            }
        }

        private async Task InsertRideAsync(int clientID, string startLocationID, string endLocationID, string price, int driverID)
        {
           
            string insertQuery = "INSERT INTO Ride (ClientID, DriverID, StartLocationID, EndLocationID, Price, RideStatus) " +
                                 "VALUES (@clientID, @driverID, @startLocationID, @endLocationID, @price, 'Booked')";

            
            string updateDriverQuery = "UPDATE driversInfo SET availability_status = 'No' WHERE driver_id = @driverID";

            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                
                using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection))
                {
                    
                    insertCommand.Parameters.AddWithValue("@clientID", clientID);
                    insertCommand.Parameters.AddWithValue("@driverID", driverID);
                    insertCommand.Parameters.AddWithValue("@startLocationID", startLocationID);
                    insertCommand.Parameters.AddWithValue("@endLocationID", endLocationID);
                    insertCommand.Parameters.AddWithValue("@price", price);
                    try
                    {
                       
                        connection.Open();

                        using (SqlTransaction transaction = connection.BeginTransaction())
                        {
                            try
                            {
                                // Assign the transaction to the commands
                                insertCommand.Transaction = transaction;

                                // Execute the INSERT query
                                int rowsAffected = insertCommand.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    // If the ride is successfully booked, update the driver's availability status
                                    using (SqlCommand updateDriverCommand = new SqlCommand(updateDriverQuery, connection, transaction))
                                    {
                                        // Add parameters to the update command
                                        updateDriverCommand.Parameters.AddWithValue("@driverID", driverID);

                                        // Execute the UPDATE query
                                        updateDriverCommand.ExecuteNonQuery();
                                    }

                                    // Commit the transaction
                                    transaction.Commit();

                                    MessageBox.Show("Ride booked successfully!");
                                    // Schedule a delayed update after 0 minute
                                    await Task.Delay(TimeSpan.FromMinutes(0));
                                    MessageBox.Show("Ride has started!");
                                    // Update the driver's availability status to 'Yes' after 0 minute
                                    UpdateDriverAvailability(driverID, endLocationID);

                                    // Update the ride status to 'Finished' after 5 minute
                                    UpdateRideStatus(clientID, startLocationID, endLocationID);
                                    MessageBox.Show("Ride has finished!");
                                    Client client = new Client(clientID);
                                    DialogResult result = client.ShowDialog();


                                }
                                else
                                {
                                    MessageBox.Show("Failed to book the ride.");
                                }
                            }
                            catch (Exception ex)
                            {
                                // Rollback the transaction in case of an error
                                transaction.Rollback();
                                MessageBox.Show("Error: " + ex.Message);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }
        private void UpdateDriverAvailability(int driverID, string endLocationID)
        {
            string updateDriverQuery = "UPDATE driversInfo SET availability_status = 'Yes', location = @endLocationID WHERE driver_id = @driverID";
            SqlConnection connection = new SqlConnection(connectionString);
            using (SqlCommand updateDriverCommand = new SqlCommand(updateDriverQuery, connection))
            {
                updateDriverCommand.Parameters.AddWithValue("@driverID", driverID);
                updateDriverCommand.Parameters.AddWithValue("@endLocationID", endLocationID);
                try
                {
                    connection.Open();
                    updateDriverCommand.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating driver availability: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        private void UpdateRideStatus(int clientID, string startLocationID, string endLocationID)
        {
            string updateRideQuery = "UPDATE Ride SET RideStatus = 'Finished' WHERE ClientID = @clientID AND StartLocationID = @startLocationID AND EndLocationID = @endLocationID";
            SqlConnection connection = new SqlConnection(connectionString);
            using (SqlCommand updateRideCommand = new SqlCommand(updateRideQuery, connection))
            {
                updateRideCommand.Parameters.AddWithValue("@clientID", clientID);
                updateRideCommand.Parameters.AddWithValue("@startLocationID", startLocationID);
                updateRideCommand.Parameters.AddWithValue("@endLocationID", endLocationID);

                try
                {
                    connection.Open();
                    updateRideCommand.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating ride status: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Client client = new Client(clientID);
            DialogResult dialogResult = client.ShowDialog();
        }

        private void priceTB_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
