using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DBP2Concept
{

    
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormWelcome welcomeForm = new FormWelcome();
            welcomeForm.Show();
            this.Hide();
        }
        private void login_Click(object sender, EventArgs e)
        {
            // 1. Initialize connection manually
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-9G0LSBE;Initial Catalog=marketplace;Integrated Security = SSPI");

            try
            {
                con.Open();
                string email = maskedTextBox2.Text;
                string password = maskedTextBox3.Text;

                // FIXED: Use 'AND' instead of a comma
                SqlCommand cmd = new SqlCommand("SELECT * FROM Accounts WHERE Email = @email AND Password = @password", con);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@password", password);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    // Get the role from the database
                    string role = reader["Role"].ToString();

                    // 2. MANUAL CLOSE: Close reader and connection before moving to the next form
                    reader.Close();
                    con.Close();

                    if (role == "Customer")
                    {
                        customerdashboard customerForm = new customerdashboard();
                        customerForm.Show();
                    }
                    else if (role == "Seller")
                    {
                        SellerDashboard sellerForm = new SellerDashboard();
                        sellerForm.Show();
                    }

                    this.Hide();
                }
                else
                {
                    // 3. MANUAL CLOSE: Close reader and connection on failed attempt
                    reader.Close();
                    con.Close();
                    MessageBox.Show("Wrong email or password. Please try again.");
                }
            }
            catch (Exception ex)
            {
                // 4. MANUAL CLOSE: Safety check—ensure connection closes if the code crashes
                if (con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void maskedTextBox3_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
