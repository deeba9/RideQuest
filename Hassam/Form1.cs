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
    public partial class Form1 : Form
    {
        //private SqlConnection connection;
        static string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\PMLS\\source\\repos\\RideQuest\\Hassam\\Database.mdf;Integrated Security=True;Connect Timeout=30";
        static int userID = -1;
        //static int driverId;
        public Form1()
        {
            InitializeComponent();
            //driverId = driverID;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void closebt_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            signup signup = new signup();
            DialogResult result = signup.ShowDialog();
        }

        private void loginbt_Click(object sender, EventArgs e)
        {
            string username = userTB.Text;
            string password = pswdTB.Text;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Use parameterized query to prevent SQL injection
                string selectQuery = "SELECT UserType FROM [dbo].[User] WHERE Username = @Username AND Password = @Password";

                using (SqlCommand cmd = new SqlCommand(selectQuery, connection))
                {
                    // Add parameters
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                string userType = reader["UserType"].ToString();
                                if (userType == "Admin")
                                {
                                    // Valid login for an Admin user. Show the landing form.
                                    this.Hide();
                                    Admin land = new Admin();
                                    DialogResult result = land.ShowDialog();
                                }
                                if (userType == "Driver")
                                {
                                    this.Hide();
                                    Driver driver = new Driver(username);
                                    DialogResult result2 = driver.ShowDialog();
                                }
                                if (userType == "Client")
                                {
                                    string selectQuery2 = "SELECT UserID FROM [dbo].[User] WHERE Username = @Username AND Password = @Password";

                                    using (SqlConnection connection2 = new SqlConnection(connectionString))
                                    {
                                        connection2.Open();
                                        using (SqlCommand cmd2 = new SqlCommand(selectQuery2, connection2))
                                        {
                                            // Add parameters to the SqlCommand
                                            cmd2.Parameters.AddWithValue("@Username", username);
                                            cmd2.Parameters.AddWithValue("@Password", password);
                                            object result1 = cmd2.ExecuteScalar();
                                            if (result1 != null)
                                            {
                                                userID = Convert.ToInt32(result1);
                                            }
                                        }
                                    }
                                    this.Hide();
                                    Client land2 = new Client(userID);
                                    DialogResult result = land2.ShowDialog();
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
