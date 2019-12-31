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
    public partial class Financial : Form
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
        string DateTimee = "";
        DateTime DateTime;
        string buyingPrice = "";
        string buyingCopy = "";
        string select = "Buying";
        string idFromDataGrid = "";
        string returnedDate = "";
        int fine = 0;
        public Financial()
        {
            InitializeComponent();
          
                hide();
            
            SqlCommand comm = new SqlCommand();
            comm = sm.selectData("select * from Borrow_history where borrow_status ='not_returned'");
            SqlDataAdapter sdrr = new SqlDataAdapter(comm);
            DataTable dtt = new DataTable();
            sdrr.Fill(dtt);
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = dtt;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(bID != "")
            {
                hide();
                SqlCommand comm1 = new SqlCommand();
                sm.updateData("UPDATE [dbo].[Borrow_history] SET [borrow_status] = 'returned' WHERE book_id ='" + bID + "'");
                comm1 = sm.selectData("select * from Borrow_history where borrow_status ='not_returned'");
                MessageBox.Show("Successfully returned!!");
                SqlDataAdapter sdrr = new SqlDataAdapter(comm1);
                DataTable dtt1 = new DataTable();
                sdrr.Fill(dtt1);
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = dtt1;
                MessageBox.Show("Successfully returned!!");
            }

            else
            {
                MessageBox.Show("Please select first");
            }
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

                dataGridView1.CurrentRow.Selected = true;
                idFromDataGrid = dataGridView1.Rows[e.RowIndex].Cells["issue_id"].FormattedValue.ToString();

                SqlCommand cmdm = new SqlCommand();
                cmdm = sm.selectData("select * from Borrow_history where issue_id = '" + idFromDataGrid + "' and borrow_status ='not_returned'");
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
                label13.Visible = true;
                label17.Visible = true;
                label18.Visible = true;
                this.Update();
                //  MessageBox.Show("Updated borrowing");


                fine = 0;

            

        }
        public void hide()
        {
            label3.Visible = false;
            this.Update();
            label4.Visible = false;
            this.Update();
            label5.Visible = false;
            this.Update();
            label8.Visible = false;
            this.Update();
            label6.Visible = false;
            this.Update();
            label9.Visible = false;
            this.Update();
            label7.Visible = false;
            this.Update();
            label10.Visible = false;
            this.Update();
          //  label11.Visible = false;
            this.Update();
          //  label15.Visible = false;
            this.Update();
           // label14.Visible = false;
            this.Update();
          //  label16.Visible = false;
            this.Update();
            label12.Visible = false;
            label13.Visible = false;
            label17.Visible = false;
            label18.Visible = false;
            this.Update();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminHome mp = new AdminHome();
            mp.Show();
        }
    }
}
