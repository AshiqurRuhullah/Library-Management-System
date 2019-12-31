using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace LibraryManagementSystem
{
    public partial class AdminHome : Form
    {

        SqlMethod sm = new SqlMethod();
        ConnDB connDB = new ConnDB();
        string textBox = "";
        string grid = "";
        string studentID = "";
        string sellCopy = "";
        string book_status = "";
        string bID = "";

        public AdminHome()
        {
            InitializeComponent();
            textBox = searchBox.Text;
            grid = comboBox.Text;
            grid = "Title";
            //SqlCommand cmd = new SqlCommand("select * from Books where " + grid + " like '" + textBox + "%'", conn);
            gridView();
        }
        public void gridView()
        {
            SqlCommand cmd1 = new SqlCommand();
            cmd1 = sm.selectData("select * from Books_extend where book_status = 'active'");
            SqlDataReader dr = cmd1.ExecuteReader();

            if (dr.Read())
            {
                book_status = dr["book_status"].ToString();
            }
            if (1==1)
            {
                SqlCommand cmd = new SqlCommand();
                cmd = sm.selectData("select * from Books_extend where book_status = 'active'");
                SqlDataAdapter sdr = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sdr.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            
        }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddingBookForm addbook = new AddingBookForm();
            addbook.Show();

        }

        private void AdminHome_Load(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox = searchBox.Text;
            grid = comboBox.Text;
            SqlCommand cmd = new SqlCommand();
            cmd = sm.selectData("select * from Books_extend where book_status = 'active' and " + grid + " = '" + textBox + "%'");
            SqlDataAdapter sdr = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dataGridView1.DataSource = dt;
            //conn.Close();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            string textBox = searchBox.Text;
            string grid = comboBox.Text;
            //conn.ConnectionString = @"Data Source=LAPTOP-UDPCMQEF;Initial Catalog=LibraryManagementSystem;Integrated Security=True";
            // conn.Open();

            if (string.IsNullOrEmpty(grid))
            {
                grid = "Title";
                //SqlCommand cmd = new SqlCommand("select * from Books where " + grid + " like '" + textBox + "%'", conn);
                SqlCommand cmd = new SqlCommand();
                cmd = sm.selectData("select * from Books_extend where book_status = 'active' and " + grid + " like '" + textBox + "%'");
                SqlDataAdapter sdr = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sdr.Fill(dt);
                dataGridView1.DataSource = dt;
                //conn.Close();
            }
            else if (grid == "All")
            {
                // SqlCommand cmd = new SqlCommand("select * from Books where Title like '" + textBox + "%' or SubTitle like '" + textBox + "%' or Author like '" + textBox + "%'or Subject like '" + textBox + "%'or ISBN like '" + textBox + "%'", conn);
                SqlCommand cmd = new SqlCommand();
                cmd = sm.selectData("select * from Books_extend where book_status = 'active' and Title like '" + textBox + "%' or SubTitle like '" + textBox + "%' or Author like '" + textBox + "%'or Subject like '" + textBox + "%'or ISBN like '" + textBox + "%'");
                SqlDataAdapter sdr = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sdr.Fill(dt);
                dataGridView1.DataSource = dt;
                //conn.Close();
            }
            else
            {
                // SqlCommand cmd = new SqlCommand("select * from Books where " + grid + " like '" + textBox + "%'", conn);
                SqlCommand cmd = new SqlCommand();
                cmd = sm.selectData("select * from Books_extend where book_status = 'active' and " + grid + " like '" + textBox + "%'");
                SqlDataAdapter sdr = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sdr.Fill(dt);
                dataGridView1.DataSource = dt;
                // conn.Close();
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {

                dataGridView1.CurrentRow.Selected = true;
                string idFromDataGrid = dataGridView1.Rows[e.RowIndex].Cells["book_id"].FormattedValue.ToString();
                bID = idFromDataGrid;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if(bID != "")
            {

                this.Hide();
                updateOperation update = new updateOperation(bID);
                update.Show();
            }
            else
            {
                MessageBox.Show("Please select Book first !!");
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("DO You Want to Delete?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if(result == DialogResult.Yes)
            {
                int bid = Convert.ToInt32(bID);
                SqlCommand cmd = new SqlCommand();
                sm.deleteData("update Books_extend set book_status = 'deactivate' where book_id = '"+bID+"'");
                gridView();

            }
            else
            {
                AdminHome admin = new AdminHome();
                this.Show();
            }
            
           

        }

        private void Search_Click(object sender, EventArgs e)
        {

        }

        private void BookInformation_Enter(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            this.Hide();
            home.Show();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminHistory ah = new AdminHistory();
            ah.Show();
        }

        private void Financial_Click(object sender, EventArgs e)
        {
            this.Hide();
            Financial fin = new Financial();
            fin.Show(); 
        }
    }
}
