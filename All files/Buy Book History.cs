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
    public partial class Buy_Book_History : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlMethod sm = new SqlMethod();
        ConnDB connDB = new ConnDB();
        SqlCommand cmd = new SqlCommand();
      //  dataGridView1.AutoGenerateColumns = false;
        string sID = "";
        string person_first_name = "";
        string person_last_name = "";
        string username = null; 
        public void gridViewNormal()
        {

            cmd = sm.selectData("select student_id,sold_amount, copy_sold, issue_id from Sale");
            SqlDataAdapter sdr = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        public void gridViewWithDate()
        {

            cmd = sm.selectData("select student_id,sold_amount, copy_sold, issue_id from Sale where date between '" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "' And '" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "' ");
            SqlDataAdapter sdr = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        public Buy_Book_History(string sid)
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
            sID = sid;
            cmd = sm.selectData("SELECT * FROM Person where person_id = '" + sID + "' ");
            SqlDataReader dr = cmd.ExecuteReader();
            if(dr.Read())
            {
                person_first_name = dr["first_name"].ToString();
                person_last_name = dr["last_name"].ToString();

            }
            username = person_first_name + person_last_name;

           
            gridViewNormal();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //gridViewNormal();
            gridViewWithDate();
        }

        private void Buy_Book_History_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'libraryManagementSystemDataSet1.Sale' table. You can move, or remove it, as needed.
            this.saleTableAdapter.Fill(this.libraryManagementSystemDataSet1.Sale);
            gridViewNormal();

        }

       

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            string textBox = textBox1.Text;
            string combobox = comboBox1.Text;
            //MessageBox.Show(textBox);
            // MessageBox.Show(grid);
            //conn.ConnectionString = @"Data Source=LAPTOP-UDPCMQEF;Initial Catalog=LibraryManagementSystem;Integrated Security=True";
            // conn.Open();


            //SqlCommand cmd = new SqlCommand("select * from Books where "+grid + " = '"+textBox+"%'", connDB.getConn());
            SqlCommand cmd = new SqlCommand();
            cmd = sm.selectData("select * from Sale where " + combobox + " = '" + textBox + "%'");
            SqlDataAdapter sdr = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            string textBox = textBox1.Text;
            string combobox = comboBox1.Text;
            //conn.ConnectionString = @"Data Source=LAPTOP-UDPCMQEF;Initial Catalog=LibraryManagementSystem;Integrated Security=True";
            // conn.Open();

            if (string.IsNullOrEmpty(combobox))
            {
                combobox = "issue_id";
                //SqlCommand cmd = new SqlCommand("select * from Books where " + grid + " like '" + textBox + "%'", conn);
                SqlCommand cmd = new SqlCommand();
                cmd = sm.selectData("select * from Sale where " + combobox + " like '" + textBox + "%'");
                SqlDataAdapter sdr = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sdr.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.Close();
            }
            else if (combobox == "All")
            {
                // SqlCommand cmd = new SqlCommand("select * from Books where Title like '" + textBox + "%' or SubTitle like '" + textBox + "%' or Author like '" + textBox + "%'or Subject like '" + textBox + "%'or ISBN like '" + textBox + "%'", conn);
                SqlCommand cmd = new SqlCommand();
                cmd = sm.selectData("select * from Sale where student_id like '" + textBox + "%' or issue_id like '" + textBox + "%'");
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
                cmd = sm.selectData("select * from Sale where " + combobox + " like '" + textBox + "%'");
                SqlDataAdapter sdr = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sdr.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.Close();
            }

        }
    }
}
