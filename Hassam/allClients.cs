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
    public partial class allClients : Form
    {
        static string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\PMLS\\source\\repos\\RideQuest\\Hassam\\Database.mdf;Integrated Security=True;Connect Timeout=30";

        public allClients()
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
                int driverID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["UserID"].Value);

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
                        string deleteUserQuery = "DELETE FROM [User] WHERE UserID = @UserID";
                        using (SqlCommand deleteUserCommand = new SqlCommand(deleteUserQuery, connection, transaction))
                        {
                            deleteUserCommand.Parameters.AddWithValue("@UserID", driverID);
                            deleteUserCommand.ExecuteNonQuery();
                        }

                        // 2. Delete from rides table
                        string deleteDriverInfoQuery = "DELETE FROM Ride WHERE ClientID = @CLientID";
                        using (SqlCommand deleteDriverInfoCommand = new SqlCommand(deleteDriverInfoQuery, connection, transaction))
                        {
                            deleteDriverInfoCommand.Parameters.AddWithValue("@CLientID", driverID);
                            deleteDriverInfoCommand.ExecuteNonQuery();
                        }

                        // Commit the transaction
                        transaction.Commit();

                        // Reload the DataGridView
                        LoadRidesForDriver();
                    }
                    catch (Exception ex)
                    {
                        // Rollback the transaction in case of an error
                        transaction.Rollback();
                        MessageBox.Show("Error deleting client: " + ex.Message);
                    }
                }
            }
        }


        private void LoadRidesForDriver()
        {
            string selectQuery = "SELECT * FROM [User] WHERE UserType = @UserType";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(selectQuery, connection))
            {
                command.Parameters.AddWithValue("@UserType", "Client");

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
                    MessageBox.Show("Error loading clients: " + ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
