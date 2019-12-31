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
using System.Security.Cryptography;

namespace LibraryManagementSystem
{
    public partial class Home : Form
    {
        string password = null;
        ConnDB conndb = new ConnDB();
        SqlMethod sm = new SqlMethod();
        string studentID = "";

        static string Decrypt(string value)
        {
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                UTF8Encoding utf8 = new UTF8Encoding();
                byte[] results = md5.ComputeHash(utf8.GetBytes(value));
                return Convert.ToBase64String(results);
            }
        }


        public Home()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // this.Hide();
            // Form2 ss = new Form2();
            // ss.Show();
            
            try
            {
                password = PasswordText.Text.Trim();
               // string DecryptedPassword = Decrypt(password);
                
                //SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-UDPCMQEF;Initial Catalog=LibraryManagementSystem;Integrated Security=True");
                //con.Open();

                //string query = "select person_id,email,password,person_type from Person where email= '" + txtusername.Text.Trim() + "'and password = '" + PasswordText.Text.Trim() + "'";
                // SqlCommand cmd = new SqlCommand(cmdText: );
                //DataSet ds = new DataSet();
                SqlDataAdapter adp = new SqlDataAdapter();
                 adp.SelectCommand = new SqlCommand();
                adp.SelectCommand = sm.selectData("select person_id,email,password,person_type from Person where email= '" + txtusername.Text.Trim() + "'and password = '" + password + "'");
                
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count == 1)
                {
                    string status = "";
                    studentID = dt.Rows[0][0].ToString();
                    status = dt.Rows[0][3].ToString();
                    
                    if(status == "admin")
                    {
                        AdminHome adminHome = new AdminHome();
                        this.Hide();
                        adminHome.Show();
                    }
                   else if(status == "Active")
                    {
                        StudentHome mp = new StudentHome(studentID);
                        this.Hide();
                        mp.Show();
        

                    } 
                    
                }

                else
                {
                    MessageBox.Show("Check your username and password");
                    //AdminHome adminHome = new AdminHome();
                    //this.Hide();
                    //adminHome.Show();
                    //MainPage mp = new MainPage(studentID);
                    //this.Hide();
                    //mp.Show();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Registration ss = new Registration();
            ss.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            FogottenPassword fp = new FogottenPassword();
            this.Hide();
            fp.Show();

        }

        private void Home_Load(object sender, EventArgs e)
        {








        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                PasswordText.UseSystemPasswordChar = false;
            }
            else
            {
                PasswordText.UseSystemPasswordChar = true;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {


        }
    }
}
