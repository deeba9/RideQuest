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
    public partial class alldrivers : Form
    {
        static string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\PMLS\\source\\repos\\RideQuest\\Hassam\\Database.mdf;Integrated Security=True;Connect Timeout=30";

        public alldrivers()
        {
            InitializeComponent();
            SetupDataGridView();
            LoadRidesForDriver();
        }

        private void SetupDataGridView()
        {
            // Create a Delete button column
            DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn();
            deleteButtonColumn.Name = "DeleteButton";
            deleteButtonColumn.Text = "Delete";
            deleteButtonColumn.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(deleteButtonColumn);

            // Set up the event handler for cell content click
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["DeleteButton"].Index && e.RowIndex >= 0)
            {
                // Get the DriverID or any unique identifier from the selected row
                int driverID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["driver_id"].Value);

                // Perform cascading deletion
                DeleteDriver(driverID);
            }
        }

        private void DeleteDriver(int driverID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // 1. Delete from User table
                        string userQuery = "Select Username from driversInfo WHERE driver_id = @DriverID";
                        using (SqlCommand deleteUserCommand = new SqlCommand(userQuery, connection, transaction))
                        {
                            deleteUserCommand.Parameters.AddWithValue("@DriverID", driverID);
                            object result = deleteUserCommand.ExecuteScalar();
                            if (result != null)
                            {
                                result = result.ToString();
                                string deleteuserQuery = "Delete from [User] WHERE Username = @Username";
                                using (SqlCommand UserCommand = new SqlCommand(deleteuserQuery, connection, transaction))
                                {
                                    UserCommand.Parameters.AddWithValue("@Username", result);
                                }

                            }

                            // 2. Delete from driversInfo table
                            string deleteDriverInfoQuery = "DELETE FROM driversInfo WHERE driver_id = @DriverID";
                            using (SqlCommand deleteDriverInfoCommand = new SqlCommand(deleteDriverInfoQuery, connection, transaction))
                            {
                                deleteDriverInfoCommand.Parameters.AddWithValue("@DriverID", driverID);
                                deleteDriverInfoCommand.ExecuteNonQuery();
                            }

                            // 3. Delete from rides table
                            string deleteQ = "DELETE FROM Ride WHERE DriverID = @DriverID";
                            using (SqlCommand deleteDriverInfoCommand = new SqlCommand(deleteQ, connection, transaction))
                            {
                                deleteDriverInfoCommand.Parameters.AddWithValue("@DriverID", driverID);
                                deleteDriverInfoCommand.ExecuteNonQuery();
                            }
                            // Commit the transaction
                            transaction.Commit();

                            // Reload the DataGridView
                            LoadRidesForDriver();
                        }
                    }
                    catch (Exception ex)
                    {
                        // Rollback the transaction in case of an error
                        transaction.Rollback();
                        MessageBox.Show("Error deleting driver: " + ex.Message);
                    }
                }
            }
        }

        private void LoadRidesForDriver()
        {
            string selectQuery = "SELECT * FROM driversInfo";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(selectQuery, connection))
            {
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
                    MessageBox.Show("Error loading drivers: " + ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }

}
