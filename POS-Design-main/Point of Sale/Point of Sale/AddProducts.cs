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
    public partial class AddProducts : Form
    {
        private MySqlConnection connection;
        public AddProducts()
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

        private void AddProducts_Load(object sender, EventArgs e)
        {
            loaddata();
        }

        private void loaddata()
        {
            try
            {
                connection.Open();
                string showallrecordquery = "SELECT ID, SN, name, category, price, quantity, description FROM products ORDER BY ID ASC";
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
                txtSN.Text = row.Cells["SN"].Value.ToString();
                txtName.Text = row.Cells["name"].Value.ToString();
                txtCategory.Text = row.Cells["category"].Value.ToString();
                txtPrice.Text = row.Cells["price"].Value.ToString();
                txtQuantity.Text = row.Cells["quantity"].Value.ToString();
                txtDescription.Text = row.Cells["description"].Value.ToString();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                string search = txtSearch.Text;
                connection.Open();
                string showallrecordquery = "SELECT ID, name, category, price, quantity, description, SN FROM products WHERE name LIKE CONCAT('%', @search, '%') OR category LIKE CONCAT('%', @search, '%') OR price LIKE CONCAT('%', @search, '%') OR ID LIKE CONCAT('%', @search, '%') OR quantity LIKE CONCAT('%', @search, '%')  OR description LIKE CONCAT('%', @search, '%') OR SN LIKE CONCAT('%', @search, '%')";

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
                string showallrecordquery = "SELECT ID, name, category, price, quantity, description, SN FROM products WHERE name LIKE CONCAT('%', @search, '%') OR category LIKE CONCAT('%', @search, '%') OR price LIKE CONCAT('%', @search, '%') OR ID LIKE CONCAT('%', @search, '%') OR quantity LIKE CONCAT('%', @search, '%')  OR description LIKE CONCAT('%', @search, '%') OR SN LIKE CONCAT('%', @search, '%')";

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
            string category = txtCategory.Text;
            string price = txtPrice.Text;
            string quantity = txtQuantity.Text;
            string description = txtDescription.Text;
            string SN = txtSN.Text;


            //Check if username and password are not empty
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(category) || string.IsNullOrWhiteSpace(price) || string.IsNullOrWhiteSpace(quantity) || string.IsNullOrWhiteSpace(description) || string.IsNullOrWhiteSpace(SN))
            {
                MessageBox.Show("Please enter all details.");
            }

            try
            {
                //Register account code
                connection.Open();
                string registerquery = "INSERT INTO products (name, category, price, quantity, description, SN) VALUES (@name, @category, @price, @quantity, @description, @SN)";
                MySqlCommand command = new MySqlCommand(registerquery, connection);
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@category", category);
                command.Parameters.AddWithValue("@price", price);
                command.Parameters.AddWithValue("@quantity", quantity);
                command.Parameters.AddWithValue("@description", description);
                command.Parameters.AddWithValue("@SN", SN);

                //Get row affected
                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Registered Successfully!");
                }
                else
                {
                    MessageBox.Show("Failed to Register Item!");
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
            txtCategory.Clear();
            txtPrice.Clear();
            txtQuantity.Clear();
            txtDescription.Clear();
            txtSN.Clear();
            loaddata();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //Declare Variable for inputs
            string name = txtName.Text;
            string category = txtCategory.Text;
            string price = txtPrice.Text;
            string quantity = txtQuantity.Text;
            string description = txtDescription.Text;
            string SN = txtSN.Text;
            string ID = txtID.Text;

            //Check if username and password are not empty
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(category) || string.IsNullOrWhiteSpace(price) || string.IsNullOrWhiteSpace(quantity) || string.IsNullOrWhiteSpace(description) || string.IsNullOrEmpty(SN))
            {
                MessageBox.Show("Please enter all details.");
            }

            try
            {
                //UPDATE account code
                connection.Open();
                string updatequery = "UPDATE products SET name = @name, category = @category, price = @price, quantity = @quantity, description = @description, SN = @SN WHERE ID = @ID";
                MySqlCommand command = new MySqlCommand(updatequery, connection);
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@category", category);
                command.Parameters.AddWithValue("@price", price);
                command.Parameters.AddWithValue("@quantity", quantity);
                command.Parameters.AddWithValue("@description", description);
                command.Parameters.AddWithValue("@SN", SN);
                command.Parameters.AddWithValue("@ID", ID);


                //Get row affected
                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Updated Successfully!");
                }
                else
                {
                    MessageBox.Show("Failed to Update Item!");
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
            txtCategory.Clear();
            txtPrice.Clear();
            txtQuantity.Clear();
            txtDescription.Clear();
            txtSN.Clear();
            txtID.Clear();
            loaddata();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you really want to delete this item?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);


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
                    string deletequery = "DELETE FROM products WHERE ID = @ID";
                    MySqlCommand command = new MySqlCommand(deletequery, connection);
                    command.Parameters.AddWithValue("@ID", ID);


                    //Get row affected
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Item Successfully Deleted!");
                    }
                    else
                    {
                        MessageBox.Show("Failed to Delete Item! Please try again.");
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
                txtCategory.Clear();
                txtPrice.Clear();
                txtQuantity.Clear();
                txtDescription.Clear();
                txtSN.Clear();
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
