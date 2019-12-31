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
using System.Text.RegularExpressions;
using System.Security.Cryptography;

namespace LibraryManagementSystem
{
   
    public partial class Registration : Form
    {
        string password = null;
        ConnDB connDB = new ConnDB();
        SqlMethod sm = new SqlMethod();
        SqlCommand cmd = new SqlCommand();
        SqlConnection conn = new SqlConnection();
        string emailValStr = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";

        static string Encrypt(string value)
        {
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                UTF8Encoding utf8 = new UTF8Encoding();
                byte[] data = md5.ComputeHash(utf8.GetBytes(value));
                return Convert.ToBase64String(data);
            }
        }
        public Registration()
        {
            InitializeComponent();
        }
        

        

        private void label11_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home ss = new Home();
            ss.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            password = ConfirmPassword.Text;
            //string encryptedPassword = Encrypt(password);
            int phoneNumber = PhoneText.Text.Length;
            int passLength = PasswordText.Text.Length; 
            string gender = "";
            if (MaleButton.Checked)
            {
                gender = MaleButton.Text;

            }
            if (FemaleButton.Checked)
            {
                gender = FemaleButton.Text;

            }
            //this.Hide();
            //Home ss = new Home();
            // ss.Show();

            //check field empty or not
            if (string.IsNullOrEmpty(NameTextBox.Text) == true)
            {
                
                MessageBox.Show("Please enter First Name");
                NameTextBox.Focus();
            }
            else if (string.IsNullOrEmpty(LastNameTextBox.Text) == true)
            {
                
                MessageBox.Show("Please enter Last Name");
                LastNameTextBox.Focus();
            }
            else if (string.IsNullOrEmpty(EmailTextBox.Text) == true)
            {
                
                MessageBox.Show("Please enter Email");
                EmailTextBox.Focus();
               
            }
            else if (Regex.IsMatch(EmailTextBox.Text, emailValStr) == false)
            {
                MessageBox.Show("Invalid email!!");
                EmailTextBox.Focus();
            }

            else if (string.IsNullOrEmpty(StudentIDTextBox.Text) == true)
            {
                
                MessageBox.Show("Please enter your ID");
                StudentIDTextBox.Focus();
            }
            else if (string.IsNullOrEmpty(PhoneText.Text) == true)
            {
                
                MessageBox.Show("Please enter Phone Number");
                PhoneText.Focus();
            }
            
            else if (phoneNumber != 11  )
            {

                MessageBox.Show("Please enter valid phone number");
                PhoneText.Focus();
            }
            else if (string.IsNullOrEmpty(gender) == true)
            {

                MessageBox.Show("Please select gender");
                ConfirmPassword.Focus();
            }
            else if (string.IsNullOrEmpty(PasswordText.Text) == true)
            {
                
                MessageBox.Show("Please type Password");
                PasswordText.Focus();
            }
            else if (passLength <= 8 )
            {
                MessageBox.Show(Convert.ToString(passLength));
                MessageBox.Show("Your password should contain minimum 8 characters or numbers");
                PasswordText.Focus();
            }
            else if (string.IsNullOrEmpty(ConfirmPassword.Text) == true)
            {
               
                MessageBox.Show("Please type Password again");
                ConfirmPassword.Focus();
            }
            else if (PasswordText.Text != ConfirmPassword.Text)
            {
                 MessageBox.Show("You typed the wrond password");
                 PasswordText.Focus();
            }
            
            else
            {
               // conn.ConnectionString = @"Data Source=LAPTOP-UDPCMQEF;Initial Catalog=LibraryManagementSystem;Integrated Security=True";
              //  conn.Open();
                

                SqlCommand cmd = new SqlCommand("insert into Person" + "(first_name,last_name,password,email,student_id,gender,contact_no) values (@first_name,@last_name,aes_encrypt(@password, 'key'),@email,@student_id,@gender,@contact_no)", connDB.getConn());
                cmd.Parameters.AddWithValue("@first_name", NameTextBox.Text);
                cmd.Parameters.AddWithValue("@last_name", LastNameTextBox.Text);
                cmd.Parameters.AddWithValue("@email", EmailTextBox.Text);
                cmd.Parameters.AddWithValue("@student_id", StudentIDTextBox.Text);
                cmd.Parameters.AddWithValue("@gender", gender);
                cmd.Parameters.AddWithValue("@contact_no", PhoneText.Text);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.ExecuteNonQuery();
                MessageBox.Show("You are registered now");



            }

        }
        

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            
        }

        private void NameTextBox_TextChanged(object sender, EventArgs e)
        {
         
        }

        private void NameTextBox_Leave(object sender, EventArgs e)
        {
        }

        private void LastNameTextBox_Leave(object sender, EventArgs e)
        {
           
        }

        private void EmailTextBox_Leave(object sender, EventArgs e)
        {
            

        }

        private void StudentIDTextBox_Leave(object sender, EventArgs e)
        {

        }

        private void PhoneText_Leave(object sender, EventArgs e)
        {

        }

        private void PasswordText_Leave(object sender, EventArgs e)
        {
            PasswordText.PasswordChar = '*';
            PasswordText.MaxLength = 16;
        }

        private void ConfirmPassword_Leave(object sender, EventArgs e)
        {
            ConfirmPassword.PasswordChar = '*';
            ConfirmPassword.MaxLength = 16;
        }

        private void PasswordText_TextChanged(object sender, EventArgs e)
        {
            PasswordText.PasswordChar = '*';
            PasswordText.MaxLength = 16;
        }

        private void Registration_Load(object sender, EventArgs e)
        {

        }
    }
}
