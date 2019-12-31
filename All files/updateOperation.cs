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
using System.Drawing.Imaging;

namespace LibraryManagementSystem
{
    public partial class updateOperation : Form
    {
        string imageurl = null;

       
        ConnDB connDB = new ConnDB();
        SqlMethod sm = new SqlMethod();
        string bID= "" ;
        int one = 1;
        int i = 1;
        string rfId = "";
        int id  ;
        int sell;
        int borrow ;
        string name = "";
        int read ;
        int sellBook;
        int borrowBook;
        int readBook;
        string imageUrl = "";
        int book_number = 1;
          


        public updateOperation(string bid)
        {
           
            InitializeComponent();
           
                bID = bid;
            Image img = pictureBox1.Image;
            byte[] arr;
            ImageConverter converter = new ImageConverter();
            arr = (byte[])converter.ConvertTo(img, typeof(byte[]));


            SqlCommand cmd1 = new SqlCommand();
            // MessageBox.Show(bID);
            id = Convert.ToInt32(bID);
            //   MessageBox.Show("dhukche");
            cmd1 = sm.selectData("select* from Books_extend where book_id = '" + bID + "'");
            SqlDataReader drr = cmd1.ExecuteReader();

            if (drr.Read())
            {
                sellBook = Convert.ToInt32((drr["sellable_book"].ToString())) ;
                borrowBook = Convert.ToInt32((drr["borrowable"].ToString()));
                readBook = Convert.ToInt32((drr["readableBook"].ToString()));
                imageUrl = (drr["imageURL"].ToString());

            }

            SqlCommand cmdd = new SqlCommand();
            // MessageBox.Show(bID);
            // id = Convert.ToInt32(bID);
            //   MessageBox.Show("dhukche");
            cmdd = sm.selectData("select* from Books_extend where book_id = '" + bID + "'");
            SqlDataReader dr = cmdd.ExecuteReader();

            if (dr.Read())
            {
                textBox1.Text = (dr["Title"].ToString());
                textBox2.Text = (dr["Author"].ToString());
                textBox3.Text = (dr["Subtitle"].ToString());
                textBox4.Text = (dr["Subject"].ToString());
                textBox5.Text = (dr["ISBN"].ToString());
                textBox6.Text = (dr["buying_price"].ToString());
                textBox7.Text = (dr["selling_price"].ToString());
                textBox8.Text = (dr["sellable_book"].ToString());
                // textBox8.Text = (dr["sellable_book"].ToString());
                //textBox12.Text = (dr["borrowable"].ToString());
                textBox11.Text = (dr["shelfNo"].ToString());
                textBox12.Text = (dr["borrowable"].ToString());
                textBox13.Text = (dr["readableBook"].ToString());
                textBox14.Text = (dr["materialType"].ToString());
                textBox15.Text = (dr["supplier"].ToString());
                textBox16.Text = (dr["source"].ToString());
                textBox17.Text = (dr["edition"].ToString());
                rfId = (dr["rf_id"].ToString());
                sell = Convert.ToInt32(textBox8.Text);
                borrow = Convert.ToInt32(textBox12.Text);
                read = Convert.ToInt32(textBox13.Text);

                // pictureBox1.Image = (dr["imageBook"].);


            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int SellableBook;
            int borrowable;
            int readable;
            int BuyingPrice = Convert.ToInt32(textBox6.Text);
            int sellingPrice = Convert.ToInt32(textBox7.Text);
            book_number = sellBook + 1;
            sell = Convert.ToInt32(textBox8.Text) ;
            borrow = Convert.ToInt32(textBox12.Text);
            read = Convert.ToInt32(textBox13.Text);

            while (sell > sellBook)
            {
               // MessageBox.Show("in the sell increase");
                SellableBook = 1;
                borrowable = 0;
                readable = 0;
                book_number++;        
                sm.insertData("INSERT INTO Books (Title,Author,Subtitle,Subject,ISBN,buying_price,selling_price,sellable_book,shelfNo, borrowable, readableBook, materialType, supplier, source, edition,imageBook, imageURL,rf_id,book_number) VALUES('" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "', '" + textBox4.Text + "', '" + textBox5.Text + "', '" + textBox6.Text + "', '" + textBox7.Text + "', '"+SellableBook+"', '" + textBox11.Text + "','" + borrowable + "', '" + readable + "','" + textBox14.Text + "', '" + textBox15.Text + "', '" + textBox16.Text + "',  '" + textBox17.Text + "', '" + pictureBox1.Image + "', '" + imageUrl + "','" + rfId + "','" + book_number + "')");
                sell--;
               
               // sm.insertData("INSERT INTO Books (Title,Author,Subtitle,Subject,ISBN,buying_price,selling_price,sellable_book,shelfNo, borrowable, readableBook, materialType, supplier, source, edition,imageBook, imageURL,rf_id,book_number) VALUES('" + bookTitle + "', '" + AuthorName + "', '" + SubTitle + "', '" + Subject + "', '" + ISBN + "', '" + BuyingPrice + "', '" + sellingPrice + "', '" + SellableBook + "', '" + ShelfNo + "','" + borrowable + "', '" + readable + "','" + MaterialType + "', '" + SupplierName + "', '" + Source + "',  '" + Edition + "', '" + Image + "', '" + ImageUrl + "','" + rf_id + "','" + book_number + "')");
            }
            book_number = 1;
            book_number = borrowBook + 1;
            while (borrow > borrowBook)
            {
                SellableBook = 0;
                borrowable = 1;
                book_number++;
                readable = 0;
                sm.insertData("INSERT INTO Books (Title,Author,Subtitle,Subject,ISBN,buying_price,selling_price,sellable_book,shelfNo, borrowable, readableBook, materialType, supplier, source, edition,imageBook, imageURL,rf_id,book_number) VALUES('" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "', '" + textBox4.Text + "', '" + textBox5.Text + "', '" + textBox6.Text + "', '" + textBox7.Text + "', '" + SellableBook + "', '" + textBox11.Text + "','" + borrowable + "', '" + readable + "','" + textBox14.Text + "', '" + textBox15.Text + "', '" + textBox16.Text + "',  '" + textBox17.Text + "', '" + pictureBox1.Image + "', '" + imageUrl + "','" + rfId + "','" + book_number + "')");
                borrow--;
           //     MessageBox.Show("in the borrow increase");

            }
            book_number = 1;
            book_number = readBook + 1;
            while (read > readBook)
            {
                SellableBook = 0;
                borrowable = 0;
                readable = 1;
                book_number++;
                sm.insertData("INSERT INTO Books (Title,Author,Subtitle,Subject,ISBN,buying_price,selling_price,sellable_book,shelfNo, borrowable, readableBook, materialType, supplier, source, edition,imageBook, imageURL,rf_id,book_number) VALUES('" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "', '" + textBox4.Text + "', '" + textBox5.Text + "', '" + textBox6.Text + "', '" + textBox7.Text + "', '" + SellableBook + "', '" + textBox11.Text + "','" + borrowable + "', '" + readable + "','" + textBox14.Text + "', '" + textBox15.Text + "', '" + textBox16.Text + "',  '" + textBox17.Text + "', '" + pictureBox1.Image + "', '" + imageUrl + "','" + rfId + "','" + book_number + "')");
                read--;
            //    MessageBox.Show("in the read increase");
                // sm.insertData("INSERT INTO Books (Title,Author,Subtitle,Subject,ISBN,buying_price,selling_price,sellable_book,shelfNo, borrowable, readableBook, materialType, supplier, source, edition,imageBook, imageURL,rf_id,book_number) VALUES('" + bookTitle + "', '" + AuthorName + "', '" + SubTitle + "', '" + Subject + "', '" + ISBN + "', '" + BuyingPrice + "', '" + sellingPrice + "', '" + SellableBook + "', '" + ShelfNo + "','" + borrowable + "', '" + readable + "','" + MaterialType + "', '" + SupplierName + "', '" + Source + "',  '" + Edition + "', '" + Image + "', '" + ImageUrl + "','" + rf_id + "','" + book_number + "')");
            }
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
          //  book_number = 1;
           // book_number = sellBook;
            while (sell < sellBook)
            {
                //MessageBox.Show("in the sell de");
             //   book_number--;
                sm.insertData("delete from books where rf_id = '"+rfId+ "' and book_number = (select max(book_number) from books where sellable_book = '1') and sellable_book = '1'");
               // readBook--;
                sell++;
             //   MessageBox.Show("in the sell de");
                // sm.insertData("INSERT INTO Books (Title,Author,Subtitle,Subject,ISBN,buying_price,selling_price,sellable_book,shelfNo, borrowable, readableBook, materialType, supplier, source, edition,imageBook, imageURL,rf_id,book_number) VALUES('" + bookTitle + "', '" + AuthorName + "', '" + SubTitle + "', '" + Subject + "', '" + ISBN + "', '" + BuyingPrice + "', '" + sellingPrice + "', '" + SellableBook + "', '" + ShelfNo + "','" + borrowable + "', '" + readable + "','" + MaterialType + "', '" + SupplierName + "', '" + Source + "',  '" + Edition + "', '" + Image + "', '" + ImageUrl + "','" + rf_id + "','" + book_number + "')");
            }
            //book_number = 1;
           // book_number = borrowBook;
            
            while (borrow < borrowBook)
            {
                // book_number--;
               // MessageBox.Show("in the borrow de");
                sm.insertData("delete from books where rf_id = '" + rfId + "' and book_number = (select max(book_number) from books where borrowable = '1') and borrowable = '1'");
                // readBook--;
              //  MessageBox.Show("in the borrow de");

                borrow++;
                // sm.insertData("INSERT INTO Books (Title,Author,Subtitle,Subject,ISBN,buying_price,selling_price,sellable_book,shelfNo, borrowable, readableBook, materialType, supplier, source, edition,imageBook, imageURL,rf_id,book_number) VALUES('" + bookTitle + "', '" + AuthorName + "', '" + SubTitle + "', '" + Subject + "', '" + ISBN + "', '" + BuyingPrice + "', '" + sellingPrice + "', '" + SellableBook + "', '" + ShelfNo + "','" + borrowable + "', '" + readable + "','" + MaterialType + "', '" + SupplierName + "', '" + Source + "',  '" + Edition + "', '" + Image + "', '" + ImageUrl + "','" + rf_id + "','" + book_number + "')");
            }
          // book_number = 1;
         //   book_number = borrowBook;
            while (read < readBook)
               
            {
               // book_number--;
                sm.insertData("delete from books where rf_id = '" + rfId + "' and book_number = (select max(book_number) from books where readableBook = '1') and readableBook = '1'");
                // readBook--;
                read++;
              //  MessageBox.Show("in the read de");
                // sm.insertData("INSERT INTO Books (Title,Author,Subtitle,Subject,ISBN,buying_price,selling_price,sellable_book,shelfNo, borrowable, readableBook, materialType, supplier, source, edition,imageBook, imageURL,rf_id,book_number) VALUES('" + bookTitle + "', '" + AuthorName + "', '" + SubTitle + "', '" + Subject + "', '" + ISBN + "', '" + BuyingPrice + "', '" + sellingPrice + "', '" + SellableBook + "', '" + ShelfNo + "','" + borrowable + "', '" + readable + "','" + MaterialType + "', '" + SupplierName + "', '" + Source + "',  '" + Edition + "', '" + Image + "', '" + ImageUrl + "','" + rf_id + "','" + book_number + "')");
            }



            SqlCommand cmd = new SqlCommand();

            sm.updateData("UPDATE [dbo].[Books_extend] SET [Title] = '" + textBox1.Text + "', [Author] = '" + textBox2.Text + "', [SubTitle] = '" + textBox3.Text + "',[Subject] = '" +textBox4.Text+ "',[ISBN] = '" +textBox5.Text+ "',[buying_price] = '" +BuyingPrice+ "',[selling_price] = '" +sellingPrice+ "',[sellable_book] = '" + Convert.ToInt32(textBox8.Text) + "',[shelfNo] = '" + Convert.ToInt32(textBox11.Text) + "',[borrowable] = '" + Convert.ToInt32(textBox12.Text) + "' ,[readableBook] = '" + Convert.ToInt32(textBox13.Text) + "',[materialType] = '" +textBox14.Text+ "',[supplier] = '" +textBox15.Text+ "',[source] = '" +textBox16.Text+ "',[edition] = '" +textBox17.Text+ "',[imageBook] = '" +pictureBox1.Image + "'  WHERE book_id = '" + bID + "'");
            sm.updateData("UPDATE [dbo].[Books] SET [Title] = '" + textBox1.Text + "', [Author] = '" + textBox2.Text + "', [SubTitle] = '" + textBox3.Text + "',[Subject] = '" + textBox4.Text + "',[ISBN] = '" + textBox5.Text + "',[buying_price] = '" + BuyingPrice + "',[selling_price] = '" + sellingPrice + "',[shelfNo] = '" + Convert.ToInt32(textBox11.Text) + "',[materialType] = '" + textBox14.Text + "',[supplier] = '" + textBox15.Text + "',[source] = '" + textBox16.Text + "',[edition] = '" + textBox17.Text + "',[imageBook] = '" + pictureBox1.Image + "'  WHERE rf_id = '" + rfId + "'");
            this.Hide();
            AdminHome admin = new AdminHome();
            admin.Show();

        }

        private void updateOperation_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to Exit..!", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                this.Hide();
                AdminHome admin = new AdminHome();
                admin.Show();

            }

            else
            {
                
                e.Cancel = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog open_file_dialog = new OpenFileDialog())
            {
                if (open_file_dialog.ShowDialog() == DialogResult.OK)
                {
                    imageurl = open_file_dialog.FileName;
                    pictureBox1.Image = Image.FromFile(open_file_dialog.FileName);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminHome ah = new AdminHome();
            ah.Show();
        }
    }
}
