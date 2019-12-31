using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace LibraryManagementSystem
{
    class SqlMethod
    {
        ConnDB connDB = new ConnDB();
        public void insertData(string query)
        {
            SqlCommand cmd = new SqlCommand(query,connDB.getConn());
            cmd.ExecuteNonQuery();

        }
        public void updateData(string query)
        {
            SqlCommand cmd = new SqlCommand(query, connDB.getConn());
            cmd.ExecuteNonQuery();

        }
        public void deleteData(string query)
        {
            SqlCommand cmd = new SqlCommand(query, connDB.getConn());
            cmd.ExecuteNonQuery();

        }
        public SqlCommand selectData(string query)
        {
            SqlCommand cmd = new SqlCommand(query, connDB.getConn());
            cmd.ExecuteNonQuery();
            return cmd;

        }
    }
}
