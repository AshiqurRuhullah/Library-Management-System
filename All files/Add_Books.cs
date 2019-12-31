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
using System.Configuration;
using System.IO;

namespace LibraryManagementSystem
{
    public partial class AddingBookForm : Form
    {
        string imgLoc = "";
        string imageURL = null;
        //SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-52FDBMD\MSSQLSERVER01;Initial Catalog=LMSDB;Integrated Security=True");

        public AddingBookForm()
        {
            InitializeComponent();
        }


        private void AddingBookForm_Load(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            byte[] img = null;
            FileStream fs = new FileStream(imgLoc, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            img = br.ReadBytes((int)fs.Length);

            //Image img = pictureBox1.Image;
            //byte[] arr;
            //ImageConverter converter = new ImageConverter();
            //arr = (byte[])converter.ConvertTo(img, typeof(byte[]));

           
            AllMethods objMethods = new AllMethods();
            objMethods.Initialize();


            //string name = txtName.Text;
            //int age = Convert.ToInt32(txtAge.Text);

            //objMethods.Insert(name, age);

           // string book_id = BookIDText.Text;
            string material = textBox1.Text;
            string source_combo_box = textBox2.Text;
            string supplier_combo_box = textBox3.Text;
            string subject_combo_box = textBox4.Text;
            int shelf_text = Convert.ToInt32(ShelfText.Text);
            int buying_price = Convert.ToInt32(BuyingPriceText.Text);
            int selling_price = Convert.ToInt32(SellingPriceText.Text);
          //  DateTime dateTime = dateTimePicker.Value;
            int numberOfSellableBook = Convert.ToInt32(textBox6.Text);
            string bookTitle = BookTitleText.Text;
            string authorName = AuthorNameText.Text;
            string subTitle = SubtitleText.Text;
            string isbn = ISBNText.Text;
            int number_of_borrowable_books = Convert.ToInt32(NumberOfBorrowableBooksText.Text);
           // int number_of_not_borrowable_books = Convert.ToInt32(NumberOfNotBorrowableBooksText.Text);
           // int number_of_buyable_books = Convert.ToInt32(NumberOfBuyableableBooksText.Text);
            //string availability = AvailabilityComboBox.Text;
            int number_of_readable_books = Convert.ToInt32(readableBooksText.Text);
            string edition = editionText.Text;

            objMethods.Insert(bookTitle, authorName, subTitle, subject_combo_box, isbn, buying_price, selling_price,numberOfSellableBook, shelf_text, number_of_borrowable_books, number_of_readable_books, material, supplier_combo_box, source_combo_box, edition,img,imageURL);

            // Formtwo objFormTwo = new Formtwo();
            // objFormTwo.Show();
            this.Hide();
            AdminHome admin = new AdminHome();
            admin.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Select Book Picture";
            if(dlg.ShowDialog() == DialogResult.OK)
            {
                imgLoc = dlg.FileName.ToString();
                pictureBox1.Image = Image.FromFile(dlg.FileName);
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

