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
    public partial class signup : Form
    {
        //private SqlConnection connection;
        static string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\PMLS\\source\\repos\\RideQuest\\Hassam\\Database.mdf;Integrated Security=True;Connect Timeout=30";

        public signup()
        {
            InitializeComponent();
            //InitializeDatabaseConnection();
        }

        private void signup_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void loginbt_Click(object sender, EventArgs e)
        {
            string username = userTB.Text;
            string password = pswdTB.Text;
            string userType = typeTB.Text;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Use parameterized query to prevent SQL injection
                string insertQuery = "INSERT INTO [dbo].[User] (Username, Password, UserType) VALUES (@Username, @Password, @UserType)";

                using (SqlCommand cmd = new SqlCommand(insertQuery, connection))
                {
                    // Add parameters
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);
                    cmd.Parameters.AddWithValue("@UserType", userType);

                    // Execute the query
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("User successfully created.");
                        if (userType == "Driver")
                        {
                            driverInfo driver = new driverInfo();
                            DialogResult result1 = driver.ShowDialog();
                        }
                        else
                        {
                            Form1 form1 = new Form1();
                            DialogResult result = form1.ShowDialog();
                            this.Hide();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error.");
                    }
                }
            }
        }
    }
}
