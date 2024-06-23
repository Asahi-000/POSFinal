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
    public partial class Dashboard : Form
    {
        private MySqlConnection connection;
        public Dashboard()
        {
            InitializeComponent();
            connection = new MySqlConnection("server=localhost;database=groupdb;username=root;password=;");
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            SignIn signin = new SignIn();
            signin.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            SignIn signin = new SignIn();
            signin.Show();
            this.Hide();
        }

        private void labelProduct_Click(object sender, EventArgs e)
        {
            AddProducts product = new AddProducts();
            product.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            AddProducts product = new AddProducts();
            product.Show();
            this.Hide();
        }

        private void labelSupplier_Click(object sender, EventArgs e)
        {
            AddSuppliers suppliers = new AddSuppliers();
            suppliers.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            AddSuppliers suppliers = new AddSuppliers();
            suppliers.Show();
            this.Hide();
        }

        private void labelCustomer_Click(object sender, EventArgs e)
        {
            AddCustomers customers = new AddCustomers();
            customers.Show();
            this.Hide();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            AddCustomers customers = new AddCustomers();
            customers.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Users users = new Users();
            users.Show();
            this.Hide();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Users users = new Users();
            users.Show();
            this.Hide();
        }

        private void labelProducts_Click(object sender, EventArgs e)
        {

        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            loaddata();
        }

        private void loaddata()
        {
            try
            {
                connection.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT COUNT(*) FROM customers", connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                labelCustom.Text = dt.Rows[0][0].ToString();

               MySqlDataAdapter adapter2 = new MySqlDataAdapter("SELECT COUNT(*) FROM products", connection);
                DataTable dt2 = new DataTable();
                adapter2.Fill(dt2);

                labelProd.Text = dt2.Rows[0][0].ToString();

                MySqlDataAdapter adapter3 = new MySqlDataAdapter("SELECT COUNT(*) FROM suppliers", connection);
                DataTable dt3 = new DataTable();
                adapter3.Fill(dt3);

                labelSupp.Text = dt3.Rows[0][0].ToString();

                MySqlDataAdapter adapter4 = new MySqlDataAdapter("SELECT COUNT(*) FROM users", connection);
                DataTable dt4 = new DataTable();
                adapter4.Fill(dt4);

                labelUser.Text = dt4.Rows[0][0].ToString();

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
    }
}
