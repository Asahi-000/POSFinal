using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Point_of_Sale
{
    public partial class Users : Form
    {
        private MySqlConnection connection;
        public Users()
        {
            InitializeComponent();
            connection = new MySqlConnection("server=localhost;database=groupdb;username=root;password=;");
        }

        private void pbExit_Click(object sender, EventArgs e)
        {
            Form1 admin = new Form1();
            admin.Show();
            this.Hide();
        }

        private void Users_Load(object sender, EventArgs e)
        {
            loaddata();
        }

        private void loaddata()
        {
            try
            {
                connection.Open();
                string showallrecordquery = "SELECT ID, username, name, role FROM users ORDER BY ID ASC";
                MySqlCommand command = new MySqlCommand(showallrecordquery, connection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;

                labelRowCount.Text = dt.Rows.Count.ToString();
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                txtID.Text = row.Cells["ID"].Value.ToString();
                txtName.Text = row.Cells["name"].Value.ToString();
                txtUsername.Text = row.Cells["username"].Value.ToString();
                cbRole.Text = row.Cells["role"].Value.ToString();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                string search = txtSearch.Text;
                connection.Open();
                string showallrecordquery = "SELECT ID, username, name, role FROM users WHERE username LIKE CONCAT('%', @search, '%') OR name LIKE CONCAT('%', @search, '%') OR role LIKE CONCAT('%', @search, '%') OR ID LIKE CONCAT('%', @search, '%')";

                MySqlCommand command = new MySqlCommand(showallrecordquery, connection);
                command.Parameters.AddWithValue("@search", search);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;

                labelRowCount.Text = dt.Rows.Count.ToString();
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

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string search = txtSearch.Text;
                connection.Open();
                string showallrecordquery = "SELECT ID, username, name, role FROM users WHERE username LIKE CONCAT('%', @search, '%') OR name LIKE CONCAT('%', @search, '%') OR role LIKE CONCAT('%', @search, '%') OR ID LIKE CONCAT('%', @search, '%')";

                MySqlCommand command = new MySqlCommand(showallrecordquery, connection);
                command.Parameters.AddWithValue("@search", search);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;

                labelRowCount.Text = dt.Rows.Count.ToString();
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //Declare Variable for inputs
            string name = txtName.Text;
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string role = cbRole.Text;

            //Check if username and password are not empty
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(role))
            {
                MessageBox.Show("Please enter both role, name, username and password.");
            }

            try
            {
                //Register account code
                connection.Open();
                string registerquery = "INSERT INTO users (name, username, password, role) VALUES (@name, @username, @password, @role)";
                MySqlCommand command = new MySqlCommand(registerquery, connection);
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", password);
                command.Parameters.AddWithValue("@role", role);


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
            loaddata();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //Declare Variable for inputs
            string name = txtName.Text;
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string role = cbRole.Text;
            string ID = txtID.Text;

            //Check if username and password are not empty
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(role))
            {
                MessageBox.Show("Please enter both role, name, username and password.");
            }

            try
            {
                //UPDATE account code
                connection.Open();
                string updatequery = "UPDATE users SET name = @name, username = @username, password = @password, role = @role WHERE ID = @ID";
                MySqlCommand command = new MySqlCommand(updatequery, connection);
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", password);
                command.Parameters.AddWithValue("@role", role);
                command.Parameters.AddWithValue("@ID", ID);


                //Get row affected
                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Updated Successfully!");
                }
                else
                {
                    MessageBox.Show("Failed to Update Account!");
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
            txtID.Clear();
            loaddata();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you really want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);


            if (result == DialogResult.Yes)
            {
                string ID = txtID.Text;
                if (string.IsNullOrWhiteSpace(ID))
                {
                    MessageBox.Show("No record found!");
                    return;
                }


                try
                {
                    connection.Open();
                    string deletequery = "DELETE FROM users WHERE ID = @ID";
                    MySqlCommand command = new MySqlCommand(deletequery, connection);
                    command.Parameters.AddWithValue("@ID", ID);


                    //Get row affected
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Record Successfully Deleted!");
                    }
                    else
                    {
                        MessageBox.Show("Failed to Delete Record! Please try again.");
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
                txtID.Clear();
                loaddata();

            }

            else
            {
                MessageBox.Show("Deletion Cancelled!");
            }

        }
    }
}
