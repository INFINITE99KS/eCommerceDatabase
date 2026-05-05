using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DBP2Concept
{
    public partial class FormRegister : Form
    {
        string conString = @"Data Source=.;Initial Catalog=MarketPlace;Integrated Security=True";

        public FormRegister()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(maskedTextBox1.Text) ||
                string.IsNullOrWhiteSpace(maskedTextBox2.Text) ||
                string.IsNullOrWhiteSpace(maskedTextBox3.Text))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            string role = radioButton1.Checked ? "Customer" : (radioButton2.Checked ? "Seller" : "");

            if (role == "")
            {
                MessageBox.Show("Please select a role.");
                return;
            }

            SqlConnection con = new SqlConnection(conString);
            try
            {
                con.Open();

                string accountQuery = "INSERT INTO Accounts (UserName, Email, Password, Role, Account_Status) VALUES (@user, @email, @pass, @role, 'Active')";
                SqlCommand cmdAcc = new SqlCommand(accountQuery, con);
                cmdAcc.Parameters.AddWithValue("@user", maskedTextBox1.Text);
                cmdAcc.Parameters.AddWithValue("@email", maskedTextBox2.Text);
                cmdAcc.Parameters.AddWithValue("@pass", maskedTextBox3.Text);
                cmdAcc.Parameters.AddWithValue("@role", role);
                cmdAcc.ExecuteNonQuery();

                if (role == "Customer")
                {
                    string getCustId = "SELECT ISNULL(MAX(CustomerID), 100) + 1 FROM Customers";
                    SqlCommand cmdId = new SqlCommand(getCustId, con);
                    int newId = (int)cmdId.ExecuteScalar();

                    string custQuery = "INSERT INTO Customers (CustomerID, UserName, CustomerName) VALUES (@id, @user, @name)";
                    SqlCommand cmdCust = new SqlCommand(custQuery, con);
                    cmdCust.Parameters.AddWithValue("@id", newId);
                    cmdCust.Parameters.AddWithValue("@user", maskedTextBox1.Text);
                    cmdCust.Parameters.AddWithValue("@name", maskedTextBox1.Text);
                    cmdCust.ExecuteNonQuery();
                }
                else
                {
                    string getSellId = "SELECT ISNULL(MAX(SellerID), 200) + 1 FROM Sellers";
                    SqlCommand cmdId = new SqlCommand(getSellId, con);
                    int newId = (int)cmdId.ExecuteScalar();

                    string sellQuery = "INSERT INTO Sellers (SellerID, UserName, StoreName) VALUES (@id, @user, @name)";
                    SqlCommand cmdSell = new SqlCommand(sellQuery, con);
                    cmdSell.Parameters.AddWithValue("@id", newId);
                    cmdSell.Parameters.AddWithValue("@user", maskedTextBox1.Text);
                    cmdSell.Parameters.AddWithValue("@name", maskedTextBox1.Text + " Store");
                    cmdSell.ExecuteNonQuery();
                }

                MessageBox.Show("Registration Successful!");

                maskedTextBox1.Clear();
                maskedTextBox2.Clear();
                maskedTextBox3.Clear();
                radioButton1.Checked = false;
                radioButton2.Checked = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void label1_Click(object sender, EventArgs e) { }
        private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e) { }
        private void maskedTextBox3_MaskInputRejected(object sender, MaskInputRejectedEventArgs e) { }
        private void groupBox1_Enter(object sender, EventArgs e) { }

        private void button4_Click(object sender, EventArgs e)
        {
            FormLogin loginForm = new FormLogin();
            loginForm.Show();
            this.Hide();
        }
    }
}