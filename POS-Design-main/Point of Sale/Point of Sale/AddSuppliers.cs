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
    public partial class AddSuppliers : Form
    {
        private MySqlConnection connection;
        public AddSuppliers()
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

        private void AddSuppliers_Load(object sender, EventArgs e)
        {
            loaddata();
        }

        private void loaddata()
        {
            try
            {
                connection.Open();
                string showallrecordquery = "SELECT ID, name, address, number, remarks FROM suppliers ORDER BY ID ASC";
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
                txtAddress.Text = row.Cells["address"].Value.ToString();
                txtNumber.Text = row.Cells["number"].Value.ToString();
                txtRemarks.Text = row.Cells["remarks"].Value.ToString();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                string search = txtSearch.Text;
                connection.Open();
                string showallrecordquery = "SELECT ID, name, address, number, remarks FROM suppliers WHERE name LIKE CONCAT('%', @search, '%') OR address LIKE CONCAT('%', @search, '%') OR number LIKE CONCAT('%', @search, '%') OR ID LIKE CONCAT('%', @search, '%') OR remarks LIKE CONCAT('%', @search, '%')";

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
                string showallrecordquery = "SELECT ID, name, address, number, remarks FROM suppliers WHERE name LIKE CONCAT('%', @search, '%') OR address LIKE CONCAT('%', @search, '%') OR number LIKE CONCAT('%', @search, '%') OR ID LIKE CONCAT('%', @search, '%') OR remarks LIKE CONCAT('%', @search, '%')";

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
            string address = txtAddress.Text;
            string number = txtNumber.Text;
            string remarks = txtRemarks.Text;


            //Check if username and password are not empty
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(address) || string.IsNullOrWhiteSpace(number) || string.IsNullOrWhiteSpace(remarks))
            {
                MessageBox.Show("Please enter all details.");
            }

            try
            {
                //Register account code
                connection.Open();
                string registerquery = "INSERT INTO suppliers (name, address, number, remarks) VALUES (@name, @address, @number, @remarks)";
                MySqlCommand command = new MySqlCommand(registerquery, connection);
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@address", address);
                command.Parameters.AddWithValue("@number", number);
                command.Parameters.AddWithValue("@remarks", remarks);

                //Get row affected
                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Registered Successfully!");
                }
                else
                {
                    MessageBox.Show("Failed to Register Supplier!");
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
            txtName.Clear();
            txtAddress.Clear();
            txtNumber.Clear();
            txtRemarks.Clear();
            loaddata();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //Declare Variable for inputs
            string name = txtName.Text;
            string address = txtAddress.Text;
            string number = txtNumber.Text;
            string remarks = txtRemarks.Text;
            string ID = txtID.Text;

            //Check if username and password are not empty
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(address) || string.IsNullOrWhiteSpace(number) || string.IsNullOrWhiteSpace(remarks))
            {
                MessageBox.Show("Please enter all details.");
            }

            try
            {
                //UPDATE account code
                connection.Open();
                string updatequery = "UPDATE suppliers SET name = @name, address = @address, number = @number, remarks = @remarks WHERE ID = @ID";
                MySqlCommand command = new MySqlCommand(updatequery, connection);
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@address", address);
                command.Parameters.AddWithValue("@number", number);
                command.Parameters.AddWithValue("@remarks", remarks);
                command.Parameters.AddWithValue("@ID", ID);


                //Get row affected
                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Updated Successfully!");
                }
                else
                {
                    MessageBox.Show("Failed to Update Supplier!");
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
            txtName.Clear();
            txtAddress.Clear();
            txtNumber.Clear();
            txtRemarks.Clear();
            txtID.Clear();
            loaddata();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you really want to delete this supplier?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);


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
                    string deletequery = "DELETE FROM suppliers WHERE ID = @ID";
                    MySqlCommand command = new MySqlCommand(deletequery, connection);
                    command.Parameters.AddWithValue("@ID", ID);


                    //Get row affected
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Supplier Successfully Deleted!");
                    }
                    else
                    {
                        MessageBox.Show("Failed to Delete Supplier! Please try again.");
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
                txtName.Clear();
                txtAddress.Clear();
                txtNumber.Clear();
                txtRemarks.Clear();
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
