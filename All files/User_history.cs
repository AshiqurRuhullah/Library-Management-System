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
    public partial class UserHistory : Form
    {

        SqlCommand cmd = new SqlCommand();
        SqlMethod sm = new SqlMethod();
        SqlConnection conn = new SqlConnection();
        string pFname = "";
        string pLname = "";
        string username = "";
        string bookName = "";
        string sID = "";
        string bID = "";
        string DateTimee = "" ;
        DateTime DateTime;
        string buyingPrice = "";
        string buyingCopy = "";
        string select = "Buying";
        string idFromDataGrid = "";
        string returnedDate = "";
        int fine = 0;
        public UserHistory(string sid)
        {
            InitializeComponent();
            sID = sid;
            cmd = sm.selectData("SELECT * FROM Person where person_id = '" + sID + "' ");
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                pFname = dr["first_name"].ToString();
                pLname = dr["last_name"].ToString();
            }
            if (true)
            {
                hide();
            }

            username = pFname + pLname;
            label2.Text = "'" + select + "' History for '" + username + "'";
            SqlCommand comm = new SqlCommand();
            comm = sm.selectData("select * from sale where student_id = '" + sID + "'");
            SqlDataAdapter sdrr = new SqlDataAdapter(comm);
            DataTable dtt = new DataTable();
            sdrr.Fill(dtt);
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = dtt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            select = "Buying";
            hide();
            label2.Text = "'" + select + "' History for '" + username + "'";
            SqlCommand comm = new SqlCommand();
            comm = sm.selectData("select * from sale where student_id = '" + sID + "'");
            SqlDataAdapter sdrr = new SqlDataAdapter(comm);
            DataTable dtt = new DataTable();
            sdrr.Fill(dtt);
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = dtt;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            hide();
           
            select = "Borrowing";
            label2.Text = "'" + select + "' History for '" + username + "'";
            SqlCommand comm = new SqlCommand();
            comm = sm.selectData("select * from Borrow_history where student_id = '" + sID + "'");
            SqlDataAdapter sdrr = new SqlDataAdapter(comm);
            DataTable dtt = new DataTable();
            sdrr.Fill(dtt);
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = dtt;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {




            if (select == "Buying")
            {
                idFromDataGrid = dataGridView1.Rows[e.RowIndex].Cells["issue_id"].FormattedValue.ToString();
                dataGridView1.CurrentRow.Selected = true;

                SqlCommand cmd = new SqlCommand();
                cmd = sm.selectData("select * from sale where issue_id = '" + idFromDataGrid + "'");
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    bID = dr["book_id"].ToString();
                    DateTimee = dr["date"].ToString();
                  buyingPrice = dr["buying_price"].ToString();
                   // buyingCopy = dr["copy_sold"].ToString();
                }
                DateTime date = Convert.ToDateTime(DateTimee);
                DateTimee = date.ToString("dd-MM-yyyy");

                SqlCommand cmdd = new SqlCommand();
                cmdd = sm.selectData("select * from Books where book_id = '" + bID + "'");
                SqlDataReader drr = cmdd.ExecuteReader();

                if (drr.Read())
                {
                    bookName = drr["Title"].ToString();
                   // MessageBox.Show(bookName);
                }
                //MessageBox.Show(bookName);
                label3.Text = "Book ID:";
                label4.Text = bID;
                label5.Text = "Book Name:";
                label8.Text = bookName;
                label6.Text = "Issue ID:";
                label9.Text = idFromDataGrid;
                label7.Text = "Date:";
                label10.Text = DateTimee;
                //label11.Text = "Buying Copy:";
                //label15.Text = buyingCopy;
                label12.Text = "Buying Price:";
                label13.Text = buyingPrice;



                label3.Visible = true;
                this.Update();
                label4.Visible = true;
                this.Update();
                label5.Visible = true;
                this.Update();
                label8.Visible = true;
                this.Update();
                label6.Visible = true;
                this.Update();
                label9.Visible = true;
                this.Update();
                label7.Visible = true;
                this.Update();
                label10.Visible = true;
                this.Update();
                //label11.Visible = true;
                //this.Update();
                //label15.Visible = true;
                //this.Update();
                label12.Visible = true;
                //this.Update();
                label13.Visible = true;
                this.Update();
                //    MessageBox.Show("Updated buying");

            }




            if (select == "Borrowing")
            {
                dataGridView1.CurrentRow.Selected = true;
                idFromDataGrid = dataGridView1.Rows[e.RowIndex].Cells["issue_id"].FormattedValue.ToString();

                SqlCommand cmdm = new SqlCommand();
                cmdm = sm.selectData("select * from Borrow_history where issue_id = '" + idFromDataGrid + "'");
                SqlDataReader dr = cmdm.ExecuteReader();

                if (dr.Read())
                {
                    bID = dr["book_id"].ToString();
                    DateTimee = dr["date"].ToString();
                    //buyingPrice = dr["sold_amount"].ToString();
                    //  buyingCopy = dr["copy_sold"].ToString();
                }
                
                DateTime date = Convert.ToDateTime(DateTimee);
                DateTimee = date.ToString("dd-MM-yyyy");
                DateTime somedate = date.AddDays(5);
                string dateString = somedate.ToString("dd-MM-yyyy");
                SqlCommand cmddd = new SqlCommand();
                cmddd = sm.selectData("select * from Books where book_id = '" + bID + "'");
                SqlDataReader drr = cmddd.ExecuteReader();
                DateTime today = DateTime.Today;
                TimeSpan t = today - somedate;
                double fineDate = t.TotalDays;
               // MessageBox.Show(Convert.ToString(fineDate));
                while (fineDate > 0)
                {
                    fine = fine + 5;
                    fineDate--;
                }


                if (drr.Read())
                {
                    bookName = drr["Title"].ToString();
                   // MessageBox.Show(bookName);
                }
               // MessageBox.Show(bookName);
                label3.Text = "Book ID:";
                label4.Text = bID;
                label5.Text = "Book Name:";
                label8.Text = bookName;
                label6.Text = "Issue ID:";
                label9.Text = idFromDataGrid;
                label7.Text = "Date of borrow:";
                label10.Text = DateTimee;
                label12.Text = "Expected returned Date:";
                label13.Text = dateString;
                label17.Text = "Fine(taka):";
                label18.Text = Convert.ToString(fine);
                //  label14.Text = "Buying Price";
                //  label16.Text = buyingPrice;

                dataGridView1.CurrentRow.Selected = true;

                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                label8.Visible = true;
                label6.Visible = true;
                label9.Visible = true;
                label7.Visible = true;
                label10.Visible = true;
                label12.Visible = true;
                label17.Visible = true;
                label13.Visible = true;
                label18.Visible = true;
                this.Update();
                //  MessageBox.Show("Updated borrowing");


                fine = 0;

            }

        }
        public void hide()
        {
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label8.Visible = false;
            label6.Visible = false;
            label9.Visible = false;
            label7.Visible = false;
            label10.Visible = false;
            label12.Visible = false;
            label17.Visible = false;
            label13.Visible = false;
            label18.Visible = false;
            this.Update();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            StudentHome mp = new StudentHome(sID);
            mp.Show();
        }
    }
}
