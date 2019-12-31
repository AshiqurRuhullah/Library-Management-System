using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace LibraryManagementSystem
{
    public partial class FogottenPassword : Form
    {
        public string randomCode;
        public static string to;
        public FogottenPassword()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home ss = new Home();
            ss.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string from, password, messageBody;
            Random rand = new Random();
            randomCode = (rand.Next(999999)).ToString();
            MailMessage message = new MailMessage();
            to = (textBox1.Text).ToString();
            from = "lmsaiub@gmail.com";
            password = "@iub54321";
            messageBody = "Your 6 digit verification code is: " + randomCode;
            message.To.Add(to);
            message.From = new MailAddress(from);
            message.Body = messageBody;
            message.Subject = "Password reseting Code";
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(from, password);
            try
            {
                smtp.Send(message);
                MessageBox.Show("Code Send Successfully");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }



        private void button3_Click(object sender, EventArgs e)
        {
            if (randomCode == (verificiationCode.Text).ToString())
            {
                to = textBox1.Text;
                updatepassword up = new updatepassword();
                this.Hide();
                up.Show();
            }
            else
            {
                MessageBox.Show("Wrong Code");
            }
        }

        private void FogottenPassword_Load(object sender, EventArgs e)
        {

        }
    }
}
