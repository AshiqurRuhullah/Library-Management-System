using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace LibraryManagementSystem
{
    public partial class updatepassword : Form
    {
        ConnDB connDB = new ConnDB();
        SqlMethod sm = new SqlMethod();
        string email = FogottenPassword.to;
        public updatepassword()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtResetPass.Text == txtResetPassVar.Text)
            {
                try
                {
                    // SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-UDPCMQEF;Initial Catalog=LibraryManagementSystem;Integrated Security=True");
                    // SqlCommand cmd = new SqlCommand("UPDATE [dbo].[login] SET [password] = '" + txtResetPassVar.Text + "'WHERE username='" + userName + "'", connDB.getConn());
                    sm.updateData("UPDATE [dbo].[Person] SET [password] = '" + txtResetPassVar.Text + "'WHERE email='" + email + "'");
                    //  con.Open();
                   // cmd.ExecuteNonQuery();
                  //  con.Close();
                    MessageBox.Show("Password Reseted Successfully");


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("The new Password doesn't match. Please Re-enter your password");
            }
        }
    }
}
