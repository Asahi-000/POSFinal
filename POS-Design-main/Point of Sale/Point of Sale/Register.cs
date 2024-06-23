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
    public partial class Register : Form
    {
        private MySqlConnection connection;
        public Register()
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
            SignIn signin = new SignIn();
            signin.Show();
            this.Hide();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            //Declare Variable for inputs
            string name = txtName.Text;
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            //Check if username and password are not empty
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Please enter both name, username and password.");
            }

            try
            {
                //Register account code
                connection.Open();
                string registerquery = "INSERT INTO users (name, username, password) VALUES (@name, @username, @password)";
                MySqlCommand command = new MySqlCommand(registerquery, connection);
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", password);

                //Get row affected
                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Registered Successfully!");
                }
                else
                {
                    MessageBox.Show("Failed to Register Account!");
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
            txtPassword.Clear();
            txtUsername.Clear();
            txtName.Clear();
        }
    }
}
