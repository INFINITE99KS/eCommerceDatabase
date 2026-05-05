using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DBP2Concept
{
    public partial class customerdashboard : Form
    {
        string conString = @"Data Source=.;Initial Catalog=MarketPlace;Integrated Security=True";
        int CustomerID;

        public customerdashboard(int CustomerID)
        {
            this.CustomerID = CustomerID;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int selectedProductID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ProductID"].Value);
                SqlConnection con = new SqlConnection(conString);
                try
                {
                    con.Open();

                    string getNextIdQuery = "SELECT ISNULL(MAX(OrderID), 0) + 1 FROM Orders";
                    SqlCommand getIdCmd = new SqlCommand(getNextIdQuery, con);
                    int newOrderID = Convert.ToInt32(getIdCmd.ExecuteScalar());

                    string insertOrderQuery = @"
                        INSERT INTO Orders (OrderID, OrderDate, CustomerID, ShipperID, ProductID) 
                        VALUES (@orderID, @date, @custID, (SELECT TOP 1 ShipperID FROM Shippers ORDER BY NEWID()), @prodID)";

                    SqlCommand insertCmd = new SqlCommand(insertOrderQuery, con);
                    insertCmd.Parameters.AddWithValue("@orderID", newOrderID);
                    insertCmd.Parameters.AddWithValue("@date", DateTime.Now.Date);
                    insertCmd.Parameters.AddWithValue("@custID", this.CustomerID);
                    insertCmd.Parameters.AddWithValue("@prodID", selectedProductID);

                    insertCmd.ExecuteNonQuery();
                    MessageBox.Show("Order placed successfully! Your Order ID is: " + newOrderID);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database error: " + ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
            else
            {
                MessageBox.Show("Please select a product from the list first!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ordersdashboard orderDash = new ordersdashboard(this.CustomerID);
            orderDash.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(conString);
            try
            {
                con.Open();
                string query = "SELECT ProductID, ProductName, Price, Category, SellerID FROM Products";
                SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(conString);
            try
            {
                con.Open();
                string query = "SELECT ProductID, ProductName, Price, Category, SellerID FROM Products WHERE ProductName LIKE @search";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@search", "%" + searchBox.Text + "%");

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
    }
}