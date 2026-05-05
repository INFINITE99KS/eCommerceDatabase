using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DBP2Concept
{
    public partial class ordersdashboard : Form
    {
        string conString = @"Data Source=.;Initial Catalog=MarketPlace;Integrated Security=True";
        int CustomerID;

        public ordersdashboard(int CustomerID)
        {
            this.CustomerID = CustomerID;
            InitializeComponent();
        }

        private void ordersdashboard_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(conString);
            try
            {
                con.Open();
                string query = @"SELECT O.OrderID, O.OrderDate, O.CustomerID, O.ShipperID, O.ProductID, P.ProductName, 
                         CASE WHEN R.ReturnDate IS NULL THEN 'Not Returned' ELSE 'Returned' END AS Status 
                         FROM Orders O 
                         INNER JOIN Products P ON O.ProductID = P.ProductID 
                         LEFT JOIN Returns R ON O.OrderID = R.OrderID";
                SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
            finally { con.Close(); }
        }



        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }



        private void returnProduct(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                
                int selectedOrderID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["OrderID"].Value);

                SqlConnection con = new SqlConnection(conString);
                try
                {
                    con.Open();

                   
                    string query = "INSERT INTO Returns (OrderID, ReturnDate) VALUES (@orderID, @date)";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@orderID", selectedOrderID);
                    cmd.Parameters.AddWithValue("@date", DateTime.Now.Date);

                    
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Order #" + selectedOrderID + " returned successfully!");
                    }
                }
                catch (Exception ex)
                {
                    
                    MessageBox.Show("Error: This order might already be returned. Details: " + ex.Message);
                }
                finally
                {
                    con.Close();
                   
                    ordersdashboard_Load(sender, e);
                }
            }
            else
            {
                MessageBox.Show("Please select an order from the list first!");
            }
        }

        private void goBack(object sender, EventArgs e)
        {
            customerdashboard back = new customerdashboard(this.CustomerID);
            back.Show();
            this.Hide();
        }

        private void searchReturns(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(conString);
            try
            {
                con.Open();
                string query = @"SELECT O.OrderID, O.OrderDate, C.CustomerName, O.ShipperID, O.ProductID, P.ProductName, 
                         CASE WHEN R.ReturnDate IS NULL THEN 'Not Returned' ELSE 'Returned' END AS Status 
                         FROM Orders O 
                         JOIN Customers C ON O.CustomerID = C.CustomerID 
                         JOIN Products P ON O.ProductID = P.ProductID 
                         LEFT JOIN Returns R ON O.OrderID = R.OrderID 
                         WHERE CAST(O.OrderID AS VARCHAR) LIKE @search 
                            OR C.CustomerName LIKE @search 
                            OR P.ProductName LIKE @search";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@search", "%" + textBox1.Text + "%");

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
            finally { con.Close(); }
        }
    }
}