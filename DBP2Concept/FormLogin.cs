using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DBP2Concept
{
    public partial class FormLogin : Form
    {
        string conString = @"Data Source=.;Initial Catalog=MarketPlace;Integrated Security=True";

        public FormLogin()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormWelcome welcomeForm = new FormWelcome();
            welcomeForm.Show();
            this.Hide();
        }

        private void login_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(conString);
            try
            {
                con.Open();
                string email = maskedTextBox2.Text;
                string password = maskedTextBox3.Text;

                string query = "SELECT Role, UserName FROM Accounts WHERE Email = @email AND Password = @password";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@password", password);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    string role = reader["Role"].ToString();
                    string username = reader["UserName"].ToString();
                    reader.Close();

                    if (role == "Customer")
                    {
                        string customerQuery = "SELECT CustomerID FROM Customers WHERE UserName = @user";
                        SqlCommand cmd2 = new SqlCommand(customerQuery, con);
                        cmd2.Parameters.AddWithValue("@user", username);

                        int customerID = Convert.ToInt32(cmd2.ExecuteScalar());

                        customerdashboard customerForm = new customerdashboard(customerID);
                        customerForm.Show();
                    }
                    else if (role == "Seller")
                    {
                       
                        string sellerQuery = "SELECT SellerID FROM Sellers WHERE UserName = @user";
                        SqlCommand cmdSeller = new SqlCommand(sellerQuery, con);
                        cmdSeller.Parameters.AddWithValue("@user", username);

                        int sID = Convert.ToInt32(cmdSeller.ExecuteScalar());

                        
                        SellerDashboard sellerForm = new SellerDashboard(sID);
                        sellerForm.Show();
                    }

                    this.Hide();
                }
                else
                {
                    reader.Close();
                    MessageBox.Show("Wrong email or password. Please try again.");
                }
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

        private void label1_Click(object sender, EventArgs e) { }
        private void maskedTextBox3_MaskInputRejected(object sender, MaskInputRejectedEventArgs e) { }
    }
}