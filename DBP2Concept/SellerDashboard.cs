using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DBP2Concept
{
    public partial class SellerDashboard : Form
    {
        string conString = @"Data Source=.;Initial Catalog=MarketPlace;Integrated Security=True";
        int sellerID;

        public SellerDashboard(int sellerID)
        {
            this.sellerID = sellerID;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void RefreshData()
        {
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            string query = "SELECT ProductID, ProductName, Price, Category FROM Products WHERE SellerID = @sid";
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            adapter.SelectCommand.Parameters.AddWithValue("@sid", sellerID);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(maskedTextBox4.Text) || string.IsNullOrWhiteSpace(maskedTextBox1.Text)) return;

            SqlConnection con = new SqlConnection(conString);
            con.Open();
            string query = "INSERT INTO Products (ProductID, ProductName, Price, Category, SellerID) VALUES (@id, @name, @price, @cat, @sid)";
            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@id", int.Parse(maskedTextBox4.Text));
            cmd.Parameters.AddWithValue("@name", maskedTextBox1.Text);
            cmd.Parameters.AddWithValue("@price", Convert.ToDecimal(maskedTextBox2.Text));
            cmd.Parameters.AddWithValue("@cat", maskedTextBox3.Text);
            cmd.Parameters.AddWithValue("@sid", this.sellerID);

            cmd.ExecuteNonQuery();
            con.Close();
            RefreshData();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text)) return;

            SqlConnection con = new SqlConnection(conString);
            con.Open();
            string query = "DELETE FROM Products WHERE ProductID = @id AND SellerID = @sid";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", textBox1.Text);
            cmd.Parameters.AddWithValue("@sid", sellerID);

            cmd.ExecuteNonQuery();
            con.Close();
            RefreshData();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormLogin login = new FormLogin();
            login.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text)) { RefreshData(); return; }

            SqlConnection con = new SqlConnection(conString);
            con.Open();
            string query = "SELECT ProductID, ProductName, Price, Category FROM Products WHERE SellerID = @sid AND (ProductID LIKE @search OR ProductName LIKE @search)";
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            adapter.SelectCommand.Parameters.AddWithValue("@sid", sellerID);
            adapter.SelectCommand.Parameters.AddWithValue("@search", "%" + textBox1.Text + "%");
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text)) return;

            SqlConnection con = new SqlConnection(conString);
            con.Open();
            string query = "UPDATE Products SET ProductName = @name, Price = @price, Category = @cat WHERE ProductID = @id AND SellerID = @sid";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", textBox1.Text);
            cmd.Parameters.AddWithValue("@name", maskedTextBox1.Text);
            cmd.Parameters.AddWithValue("@price", Convert.ToDecimal(maskedTextBox2.Text));
            cmd.Parameters.AddWithValue("@cat", maskedTextBox3.Text);
            cmd.Parameters.AddWithValue("@sid", sellerID);

            cmd.ExecuteNonQuery();
            con.Close();
            RefreshData();
        }

        private void maskedTextBox4_MaskInputRejected(object sender, MaskInputRejectedEventArgs e) { }
        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e) { }
        private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e) { }
        private void maskedTextBox3_MaskInputRejected(object sender, MaskInputRejectedEventArgs e) { }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
        private void label5_Click(object sender, EventArgs e) { }
    }
}