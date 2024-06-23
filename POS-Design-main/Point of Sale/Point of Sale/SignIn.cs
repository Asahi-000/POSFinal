using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Point_of_Sale
{
    public partial class SignIn : Form
    {
        private MySqlConnection connection;
        public SignIn()
        {
            InitializeComponent();
            connection = new MySqlConnection("server=localhost;database=groupdb;username=root;password=;");
        }

        private void pbExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            //Sanitize data to remove white-space
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            //Check if username and password are not empty
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter both username and password.");
            }

            //Try-Catch-Finally

            try
            {
                //Open the connection string
                connection.Open();

                //Create a string that will handle query
                string loginquery = "SELECT COUNT(*) FROM users WHERE username = @username AND password = @password";

                //Execute the command loginquery
                MySqlCommand command = new MySqlCommand(loginquery, connection);

                //Sanitize query for sql injection
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", password);

                //Get row count
                int count = Convert.ToInt32(command.ExecuteScalar());
                if (count > 0)
                {
                    //MessageBox.Show("Correct username and password");
                    Form1 adminpage = new Form1();
                    adminpage.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid username or password");

                }
            }

            catch (Exception ex)
            {
                //Display any Error if occured
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                //Close the connection whether there is an error or not for prevention of hacking
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        private void linkSignUp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Register register = new Register();
            register.Show();
            this.Hide();
        }
    }
}
