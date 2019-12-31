using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace LibraryManagementSystem
{
    public partial class StudentHome : Form
    {
        SqlMethod sm = new SqlMethod();
        ConnDB connDB = new ConnDB();
        string studentID = "";
        string sellCopy = "";
        string borrowCopy = "";
        string readCopy = "";
        string bID = "";

        SqlCommand cmd = new SqlCommand();
        SqlConnection conn = new SqlConnection();

        public StudentHome(string stID)
        {
            InitializeComponent();
            studentID = stID;
            SqlCommand cmd = new SqlCommand();
            cmd = sm.selectData("select * from Books_extend where book_status = 'active'");
            SqlDataAdapter sdr = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dataGridView1.DataSource = dt;

        }
        public StudentHome()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // comboBox1.SelectedIndex = 0; 
        }
        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            string textBox = textBox1.Text;
            string grid = comboBox1.Text;
            //MessageBox.Show(textBox);
            // MessageBox.Show(grid);
            //conn.ConnectionString = @"Data Source=LAPTOP-UDPCMQEF;Initial Catalog=LibraryManagementSystem;Integrated Security=True";
            // conn.Open();


            //SqlCommand cmd = new SqlCommand("select * from Books where "+grid + " = '"+textBox+"%'", connDB.getConn());
            SqlCommand cmd = new SqlCommand();
            cmd = sm.selectData("select * from Books_extend where book_status = 'active' and " + grid + " = '" + textBox + "%'");
            SqlDataAdapter sdr = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dataGridView1.DataSource = dt;
            //  conn.Close();


        }

        private void MainPage_Load(object sender, EventArgs e)
        {
            // comboBox1.SelectedIndex = 0;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            string textBox = textBox1.Text;
            string grid = comboBox1.Text;
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
                conn.Close();
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
                conn.Close();
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
                conn.Close();
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {

                dataGridView1.CurrentRow.Selected = true;
                string idFromDataGrid = dataGridView1.Rows[e.RowIndex].Cells["book_id"].FormattedValue.ToString();
                // MessageBox.Show(idFromDataGrid);
                //SqlCommand cmd = new SqlCommand();
                //SqlConnection conn = new SqlConnection();
                // SqlCommand cmd = new SqlCommand("select * from Books where book_id = '"+idFromDataGrid+"'");
                //SqlDataAdapter sdr = new SqlDataAdapter(cmd);
                // SqlDataReader dr = cmd.ExecuteReader();
                SqlConnection conn = new SqlConnection();
                //  conn.ConnectionString = @"Data Source=LAPTOP-UDPCMQEF;Initial Catalog=LibraryManagementSystem;Integrated Security=True";
                //  conn.Open();
                // string sqlSelectQuery = "select* from Books where book_id = '" + idFromDataGrid + "'";
                // SqlCommand cmd = new SqlCommand(sqlSelectQuery, connDB.getConn());
                SqlCommand cmd = new SqlCommand();
                cmd = sm.selectData("select* from Books_extend where book_status = 'active' and book_id = '" + idFromDataGrid + "'");
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    bID = dr["book_id"].ToString();
                    sellCopy = dr["sellable_book"].ToString();
                    borrowCopy = dr["borrowable"].ToString();
                    readCopy = dr["readableBook"].ToString();
                    bookID.Text = (dr["book_id"].ToString());
                    bookName.Text = (dr["Title"].ToString());
                    authorName.Text = (dr["Author"].ToString());
                    subject.Text = (dr["Subject"].ToString());
                    isbn.Text = (dr["ISBN"].ToString());
                    // totalCopy.Text = (dr["book_id"].ToString());
                    buyableCopy.Text = (dr["sellable_book"].ToString());
                   // readableCopy.Text = (dr["not_borrowable"].ToString());
                    string bCopy = dr["borrowable"].ToString();
                    if (string.IsNullOrEmpty(bCopy))
                    {
                        borrowableCopy.Text = "Not for borrow!";
                    }
                    else
                    {
                        borrowableCopy.Text = (dr["borrowable"].ToString());
                    }

                    string sPrice = dr["selling_price"].ToString();
                    if (string.IsNullOrEmpty(sPrice))
                    {
                        buyingPrice.Text = "Not for sale!";
                    }
                    else
                    {
                        buyingPrice.Text = (dr["selling_price"].ToString());
                    }


                }



            }
        }

        private void buy_Click(object sender, EventArgs e)
        {
            if (bID != "")
            {
                if (Int32.Parse(sellCopy) > 0)
                {
                    this.Hide();
                    Buy_Books buyBooks = new Buy_Books(bID, studentID);
                    buyBooks.Show();
                }
                else
                {
                    MessageBox.Show("No buyable copy left!");
                }
            }
            else
            {
                MessageBox.Show("Please select a book first !!");
            }

        }

        private void borrow_Click(object sender, EventArgs e)
        {
            if(bID != "")
            {
                if (Int32.Parse(borrowCopy) > 0)
                {
                    this.Hide();
                    Borrow_Books borrowBooks = new Borrow_Books(studentID, bID);
                    borrowBooks.Show();
                }
                else
                {
                    MessageBox.Show("No borrowable copy left!");
                }
            }
            else
            {
                MessageBox.Show("Please select a book first !!");
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            UserHistory uh = new UserHistory(studentID);
            uh.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home home = new Home();
            home.Show();
        }
    }
}
