using System;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace LibraryManagementSystem
{
    class AllMethods
    {
        ConnDB connDB = new ConnDB();
        SqlMethod sm = new SqlMethod();
        //Global Variable 

        public SqlConnection connection;

        //intialize connection
        public void Initialize()
        {
            // string connectionString = @"Data Source=LAPTOP-UDPCMQEF;Initial Catalog=LibraryManagementSystem;Integrated Security=True";
            // connection = new SqlConnection(connectionString);
            //connDB.getConn();
        }

        //open connection 
        public bool OpenConnection()
        {
            try
            {
                connDB.getConn();
                return true;
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error is: " + ex);
                return false;
            }
        }

        //close 
        public bool CloseConnection()
        {
            try
            {
                connDB.getClose();
                return true;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error is: " + ex);
                return false;
            }
        }

        //Insertion Method 
        public void Insert(string bookTitle, string AuthorName, string SubTitle, string Subject,string ISBN, int BuyingPrice, int sellingPrice, int SellableBook, int ShelfNo,int borrowable, int readable, string MaterialType, string SupplierName, string Source, string Edition, byte[] Image, string ImageUrl)
        {
           

            try
            {
                int book_number = 1;
                string rf_id = "";
                Random random = new Random();
                int rand= random.Next(1000);
                rf_id = Convert.ToString(rand) + bookTitle;
                sm.insertData("INSERT INTO Books_extend (Title,Author,Subtitle,Subject,ISBN,buying_price,selling_price,sellable_book,shelfNo, borrowable, readableBook, materialType, supplier, source, edition,imageBook, imageURL,rf_id) VALUES('" + bookTitle + "', '" + AuthorName + "', '" + SubTitle + "', '" + Subject + "', '" + ISBN + "', '" + BuyingPrice + "', '" + sellingPrice + "', '" + SellableBook + "', '" + ShelfNo + "','" + borrowable + "', '" + readable + "','" + MaterialType + "', '" + SupplierName + "', '" + Source + "',  '" + Edition + "', '" + Image + "', '" + ImageUrl + "','"+rf_id+"')");
                // int count;
                int sellBook = SellableBook;
                int borrowBook = borrowable;
                int readBook = readable;
                while(sellBook > 0)
                {
                    SellableBook = 1;
                    borrowable = 0;
                    readable = 0;
                    sm.insertData("INSERT INTO Books (Title,Author,Subtitle,Subject,ISBN,buying_price,selling_price,sellable_book,shelfNo, borrowable, readableBook, materialType, supplier, source, edition,imageBook, imageURL,rf_id,book_number) VALUES('" + bookTitle + "', '" + AuthorName + "', '" + SubTitle + "', '" + Subject + "', '" + ISBN + "', '" + BuyingPrice + "', '" + sellingPrice + "', '" + SellableBook + "', '" + ShelfNo + "','" + borrowable + "', '" + readable + "','" + MaterialType + "', '" + SupplierName + "', '" + Source + "',  '" + Edition + "', '" + Image + "', '" + ImageUrl + "','" + rf_id + "','"+book_number+"')");
                    sellBook--;
                    book_number++;
                }
                book_number = 1;
                while (borrowBook > 0)
                {
                    SellableBook = 0;
                    borrowable = 1;
                    readable = 0;
                    sm.insertData("INSERT INTO Books (Title,Author,Subtitle,Subject,ISBN,buying_price,selling_price,sellable_book,shelfNo, borrowable, readableBook, materialType, supplier, source, edition,imageBook, imageURL,rf_id,book_number) VALUES('" + bookTitle + "', '" + AuthorName + "', '" + SubTitle + "', '" + Subject + "', '" + ISBN + "', '" + BuyingPrice + "', '" + sellingPrice + "', '" + SellableBook + "', '" + ShelfNo + "','" + borrowable + "', '" + readable + "','" + MaterialType + "', '" + SupplierName + "', '" + Source + "',  '" + Edition + "', '" + Image + "', '" + ImageUrl + "','" + rf_id + "','" + book_number + "')");
                    borrowBook--;
                    book_number++;
                }
                book_number = 1;
                while (readBook > 0)
                {
                    SellableBook = 0;
                    borrowable = 0;
                    readable = 1;
                    sm.insertData("INSERT INTO Books (Title,Author,Subtitle,Subject,ISBN,buying_price,selling_price,sellable_book,shelfNo, borrowable, readableBook, materialType, supplier, source, edition,imageBook, imageURL,rf_id,book_number) VALUES('" + bookTitle + "', '" + AuthorName + "', '" + SubTitle + "', '" + Subject + "', '" + ISBN + "', '" + BuyingPrice + "', '" + sellingPrice + "', '" + SellableBook + "', '" + ShelfNo + "','" + borrowable + "', '" + readable + "','" + MaterialType + "', '" + SupplierName + "', '" + Source + "',  '" + Edition + "', '" + Image + "', '" + ImageUrl + "','" + rf_id + "','" + book_number + "')");
                    readBook--;
                    book_number++;
                }
               // sm.insertData("INSERT INTO Books (Title,Author,Subtitle,Subject,ISBN,buying_price,selling_price,sellable_book,buyable_book,not_borrowable,shelfNo, borrowable, readableBook, materialType, supplier, source, edition,imageBook, imageURL) VALUES('" + bookTitle + "', '" + AuthorName + "', '" + SubTitle + "', '" + Subject + "', '" + ISBN + "', '" + BuyingPrice + "', '" + sellingPrice + "', '" + SellableBook + "', '" + buyableBook + "','" + notBorrowable + "', '" + ShelfNo + "','" + borrowable + "', '" + readable + "','" + MaterialType + "', '" + SupplierName + "', '" + Source + "',  '" + Edition + "', '" + Image + "', '" +ImageUrl+ "')");
              //  OpenConnection();
                this.CloseConnection();
               
                    MessageBox.Show("You data is successfuly inserted.");          

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error is: " + ex);
            }
        }

        /*public void Select(ComboBox cb)
        {
            SqlCommand objCommand = connection.CreateCommand();
            objCommand.CommandText = "SELECT [stdName] FROM[dbo].[testingTable]";
            OpenConnection();

            SqlDataReader objReader = objCommand.ExecuteReader();

            while (objReader.Read())
            {
                // cb.Items.Add(objReader.ToString());
                cb.Items.Add(objReader.GetValue(0).ToString());
            }

            this.CloseConnection();
        }*/
    }
}