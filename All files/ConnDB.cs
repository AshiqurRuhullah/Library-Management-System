using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace LibraryManagementSystem
{
    class ConnDB
    {
        private SqlConnection conn;

        public SqlConnection getConn()
        {
            conn = new SqlConnection(@"Data Source=LAPTOP-UDPCMQEF;Initial Catalog=LibraryManagementSystem;Integrated Security=True");
            conn.Open();
            return conn;
        }
        public void getClose()
        {
            if(conn != null)
            {
                conn.Close();
            }
        }
    }
}
