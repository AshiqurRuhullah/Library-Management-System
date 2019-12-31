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
using System.IO;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace LibraryManagementSystem
{
    public partial class Buy_Books : Form
    {
        string sellCopy = "";
        string bookName = "";
        string bookPrice = "";
        int avaiableCopy;
        int totalPrice;
        int bid;
        int studentID;
        string rfid = "";
        int totalCopy = 1;
        int bookID;
        ConnDB conn = new ConnDB();
        SqlMethod sm = new SqlMethod();
       // string bookID = "";
      //  string filename = "";
        public Buy_Books(string bID, string sid)
        {
            InitializeComponent();
            bid = Convert.ToInt32(bID);
            studentID = Convert.ToInt32(sid);
        }

        private void Buy_Books_Load(object sender, EventArgs e)
        {

            SqlCommand cmd = new SqlCommand();
            cmd = sm.selectData("select* from Books_extend where book_id = '" + bid + "'");
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                sellCopy = dr["sellable_book"].ToString();
                bookName = (dr["Title"].ToString());
                bookPrice = (dr["selling_price"].ToString());
                rfid = (dr["rf_id"].ToString());
             }
            SqlCommand cmdd = new SqlCommand();
            cmdd = sm.selectData("select imageBook from Books_extend where book_id = '" + bid + "'");
            SqlDataReader reader = cmdd.ExecuteReader();
            reader.Read();
            if(reader.HasRows)
            {
                byte[] img = (byte[])(reader[0]);
                if(img != null)
                {
                   
                        byte[] picture = img;
                        //MemoryStream ms = new MemoryStream(picture, 0, picture.Length);
                        //BinaryFormatter bf = new BinaryFormatter();
                        //bf.Serialize(ms, img);
                        //pictureBox1.Image = new Bitmap(ms);

                }
            }


            SqlCommand cm = new SqlCommand();
            cm = sm.selectData("select * from Books_extend where book_id = '" + bid + "'");
            SqlDataAdapter daa = new SqlDataAdapter(cm);
            DataSet ds = new DataSet();
            daa.Fill(ds);
            //MemoryStream ms = new MemoryStream((byte[])ds.Tables[0].Rows[0][18]);
           //
         //   pictureBox1.Image = new Bitmap(ms);
            label8.Text = bookName;
            textBox1.Text = Convert.ToString(totalCopy);
            Price();
            label7.Text = Convert.ToString(totalPrice);
            label3.Text = sellCopy;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            totalCopy++;
            Price();
            textBox1.Text = Convert.ToString(totalCopy);
            label7.Text = Convert.ToString(totalPrice);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(totalCopy != 0)
            {
                totalCopy--;
                Price();
                textBox1.Text = Convert.ToString(totalCopy);
                label7.Text = Convert.ToString(totalPrice);
            }
            
        }
        public void Price()
        {
            totalPrice = Convert.ToInt32(totalCopy) * Convert.ToInt32(bookPrice);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            bool loop = true;
            int i = 0;
            avaiableCopy = Convert.ToInt32(sellCopy) - totalCopy;
            sm.updateData("UPDATE [dbo].[Books_extend] SET [sellable_book] = '" + avaiableCopy + "'WHERE book_id ='" + bid + "'");
            SqlCommand cmd = new SqlCommand();
            cmd = sm.selectData("select * from Books_extend where rf_id = '" + rfid + "'");
            SqlDataReader dr = cmd.ExecuteReader();
           
            if (dr.Read())
            {
                sellCopy = dr["sellable_book"].ToString();
                bookName = (dr["Title"].ToString());
                bookPrice = (dr["selling_price"].ToString());
            }
           
            label3.Text = sellCopy;
            while (totalCopy > 0)
            {
                if(totalCopy <= Convert.ToInt32(sellCopy))
                {
                        i = 1;
                        SqlCommand cmdd = new SqlCommand();
                        cmdd = sm.selectData("select * from Books where rf_id = '" + rfid + "' and book_number = (select min(book_number) from books where sellable_book = '1')");
                        SqlDataReader drr = cmdd.ExecuteReader();
                       // avaiableCopy = Convert.ToInt32(sellCopy) - totalCopy;
                        if (drr.Read())
                        {
                            bookID = Convert.ToInt32((drr["book_id"].ToString()));
                       // MessageBox.Show(Convert.ToString(bookID));
                        }
                       // sm.updateData("UPDATE [dbo].[Books_extend] SET [sellable_book] = '" + avaiableCopy + "'WHERE book_id ='" + bid + "'");




                        sm.updateData("UPDATE [dbo].[Books] SET [sellable_book] = '0' where book_id = '" + bookID + "'");

                        
                        DateTime date = DateTime.Now;
                        Random rnd = new Random();
                        string randomCode = (rnd.Next(1000)).ToString();
                        string issueID = Convert.ToString(studentID) + randomCode + Convert.ToString(bookID);
                        MessageBox.Show("Thanks for buying, your issue id: '" + issueID + "'");
                        sm.insertData("INSERT INTO Sale (student_id,book_id, date,issue_id,buying_price) VALUES ('" + Convert.ToString(studentID) + "','" + Convert.ToString(bookID) + "','" + date + "','" + issueID + "','"+bookPrice+"')");
                    }
                totalCopy--;
            }
            if(i == 0)
            {
                MessageBox.Show("limit reached !!");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            StudentHome mp = new StudentHome(Convert.ToString(studentID));
            this.Hide();
            mp.Show();
        }



    }

}
