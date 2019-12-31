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
    public partial class AddingBookForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-52FDBMD\MSSQLSERVER01;Initial Catalog=LMSDB;Integrated Security=True");

        public AddingBookForm(AdminHome admin)
        {
            InitializeComponent();
        }

        public delegate void UpdateDelegate(object sender, UpdateEventArgs args);
        public event UpdateDelegate UpdateEventHandler;

        public class UpdateEventArgs : EventArgs
        {
            public string Data { get; set; }
        }
        protected void insert()
        {
            UpdateEventArgs args = new UpdateEventArgs();
            UpdateEventHandler.Invoke(this, args);
        }

        private void AddingBookForm_Load(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            try
            {
                string query = "INSERT INTO [dbo].[Books]([book_title],[authorname],[subtitle],[subject],[isbn],[buying_price],[selling_price],[Added_time],[sellable_book],[buyable_book],[readable],[not_borrowable],[materialType],[supplier],[source],[availability],[shelfNo] ,[Edition]) VALUES
           (<book_title, nvarchar(150),>
           ,<authorname, varchar(50),>
           ,<subtitle, nvarchar(150),>
           ,<subject, varchar(50),>
           ,<isbn, varchar(50),>
           ,<buying_price, float,>
           ,<selling_price, float,>
           ,<Added_time, datetime,>
           ,<sellable_book, int,>
           ,<buyable_book, int,>
           ,<readable, int,>
           ,<not_borrowable, int,>
           ,<materialType, varchar(50),>
           ,<supplier, nvarchar(50),>
           ,<source, nvarchar(50),>
           ,<availability, varchar(50),>
           ,<shelfNo, int,>
           ,<Edition, varchar(50),>)";
                SqlDataAdapter adp = new SqlDataAdapter(query, con);
                // DataTable dt = new DataTable();
                adp.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            } 
        
        }
        }
    }

