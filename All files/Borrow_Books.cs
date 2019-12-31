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
    public partial class 
        Borrow_Books : Form
    {
        string bID = "";
        string sID = "";
        string bookName = "";
        string borrowable = "";
        string rfid = "";
        int bookID;
        // DateTime date = new DateTime();
        ConnDB conn = new ConnDB();
        SqlMethod sm = new SqlMethod();
        public Borrow_Books(string sid, string bid)
        {
            InitializeComponent();
            bID = bid;
            sID = sid;
            SqlCommand cmd = new SqlCommand();
            cmd = sm.selectData("select* from Books_extend where book_id = '" + Convert.ToInt32(bID) + "'");
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                borrowable = dr["borrowable"].ToString();
                bookName = (dr["Title"].ToString());
                rfid = (dr["rf_id"].ToString());
            }
            // MessageBox.Show(borrowable);
            // MessageBox.Show(bookName);
            label8.Text = bookName;
        }

        private void Borrow_Books_Load(object sender, EventArgs e)
        {

        }

        private void Borrow_Books_Load_1(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(borrowable) > 0)
            {
                borrowable = Convert.ToString(Convert.ToInt32(borrowable) - 1);
                sm.updateData("UPDATE [dbo].[Books_extend] SET [borrowable] = '" + Convert.ToInt32(borrowable) + "'WHERE book_id ='" + bID + "'");

                SqlCommand cmdd = new SqlCommand();
                cmdd = sm.selectData("select * from Books where rf_id = '" + rfid + "' and book_number = (select min(book_number) from books where borrowable = '1') and borrowable = 1");
                SqlDataReader drr = cmdd.ExecuteReader();
                // avaiableCopy = Convert.ToInt32(sellCopy) - totalCopy;
                if (drr.Read())
                {
                    bookID = Convert.ToInt32((drr["book_id"].ToString()));
                   // MessageBox.Show(Convert.ToString(bookID));
                }



                //DateTime date = DateTime.Now.ToString("dd-MM-yyyy");
                string d = DateTime.Today.ToString("dd-MM-yyyy");
                //DateTime date = Convert.ToDateTime(d);
                // DateTime date = DateTime.Parse(d);
                DateTime date = Convert.ToDateTime(d,System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);
                Random rnd = new Random();
                string randomCode = (rnd.Next(1000)).ToString();
                string issueID = sID + randomCode + bookID;
                MessageBox.Show("Confirmed, your issue id: '" + issueID + "'");
                sm.insertData("INSERT INTO Borrow_history (student_id,book_id, issue_id, date) VALUES ('" + Convert.ToString(sID) + "','" + Convert.ToString(bookID) + "','" + issueID + "','" + date + "');");
                sm.updateData("UPDATE [dbo].[Books] SET [borrowable] = '0' where book_id = '" + bookID + "'");
            }
            else
            {
                MessageBox.Show("No borrow able copy left!");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            StudentHome mp = new StudentHome(sID);
            this.Hide();
            mp.Show();
        }
    }
}
