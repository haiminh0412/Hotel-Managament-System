using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Hotel_Management_System_Winforrm
{
    class QuanLyTaiKhoan
    {
        private DataTable dataTable;
        private SqlDataAdapter sqlDataAdapter;

        public DataTable ThongTinTaiKhoan()
        {
            dataTable = new DataTable();
            string query;
            using(SqlConnection sqlConnection = Connection.getConnection())
            {
                sqlConnection.Open();



                sqlConnection.Close();
            }

            return dataTable;
        }

    }
}
