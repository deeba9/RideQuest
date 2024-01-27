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
    public partial class allRides : Form
    {
        static string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\PMLS\\source\\repos\\RideQuest\\Hassam\\Database.mdf;Integrated Security=True;Connect Timeout=30";


        public allRides()
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
                int rideID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["RideID"].Value);

                // Perform cascading deletion
                DeleteDriver(rideID);
            }
        }

        private void DeleteDriver(int rideID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        
                        string deleteQ = "DELETE FROM Ride WHERE RideID = @RideID";
                        using (SqlCommand deleteDriverInfoCommand = new SqlCommand(deleteQ, connection, transaction))
                        {
                            deleteDriverInfoCommand.Parameters.AddWithValue("@RideID", rideID);
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
                        MessageBox.Show("Error deleting ride: " + ex.Message);
                    }
                }
            }
        }

        private void LoadRidesForDriver()
        {
            string selectQuery = "SELECT * FROM Ride";

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
                    MessageBox.Show("Error loading rides: " + ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}

