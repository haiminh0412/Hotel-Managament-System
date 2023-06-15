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
        SqlCommand sqlCommand;
        SqlDataAdapter adapter;
        // dung de truy van cac cau lenh insert update delete v.v
        SqlDataReader reader; // doc trong database
        public List<Account> Account(string query)
        {
            List<Account> list = new List<Account>();
            using (SqlConnection sqlConnection = Connection.getConnection())
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                reader = sqlCommand.ExecuteReader(); // tien hanh doc
                while (reader.Read()) // read doc tung dong
                {
                    list.Add(new Account(reader.GetString(0), reader.GetString(1)));
                }

                sqlConnection.Close();
            }

            return list;
        }
        public DataTable getNhanVien()
        {
            DataTable dt = new DataTable();
            string query = "select * from DangNhap";
            using (SqlConnection sqlConnection = Connection.getConnection())
            {
                sqlConnection.Open();

                adapter = new SqlDataAdapter(query, sqlConnection);
                adapter.Fill(dt);
                sqlConnection.Close();
            }
            return dt;
        }
        public bool insert(Account tk)
        {
            SqlConnection sqlConnection = Connection.getConnection();
            string query = "insert into DangNhap values (@taikhoan,@matkhau,@Ten,@ngaysinh,@gioitinh,@sdt)";
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@taikhoan", tk.Tentaikhoan);
                sqlCommand.Parameters.AddWithValue("@matkhau", tk.Matkhau);
                sqlCommand.Parameters.AddWithValue("@Ten", tk.Tennv);
                sqlCommand.Parameters.AddWithValue("@gioitinh", tk.Gioitinh);
                sqlCommand.Parameters.AddWithValue("@sdt", tk.Sdt);
                sqlCommand.Parameters.AddWithValue("@ngaysinh", tk.Ngaysinh.ToShortDateString());
                sqlCommand.ExecuteNonQuery();

            }
            catch
            {

            }
            finally
            {
                sqlConnection.Close();
            }
            return true;
        }
        public bool Update(string password, string tentk, string mkcu)
        {
            SqlConnection sqlConnection = Connection.getConnection();
            string query = "update DangNhap set matkhau = '" + password + "' where taikhoan = '" + tentk + "' and matkhau = '" + mkcu + "' ";
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@matkhau", password);
                sqlCommand.ExecuteNonQuery();

            }
            catch
            {

            }
            finally
            {
                sqlConnection.Close();
            }
            return true;
        }
        public bool UpdateTK(string password, string name, string gt, string ngaysinh, string taikhoan)
        {
            SqlConnection sqlConnection = Connection.getConnection();
            string query = "UPDATE DangNhap SET Ten = @Ten, gioitinh = @gioitinh, ngaysinh = @ngaysinh, taikhoan = @taikhoan WHERE taikhoan = @taikhoan and  matkhau = '" + password + "' ";

            try
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@Ten", name);
                sqlCommand.Parameters.AddWithValue("@gioitinh", gt);
                sqlCommand.Parameters.AddWithValue("@ngaysinh", ngaysinh);
                sqlCommand.Parameters.AddWithValue("@taikhoan", taikhoan);
                sqlCommand.ExecuteNonQuery();
            }
            catch
            {
            }
            finally
            {
                sqlConnection.Close();
            }

            return true;
        }

        public DataTable getThongTinNhanVien()
        {
            DataTable dt = new DataTable();
            string query = "select Ten as 'Tên Nhân Viên' ,taikhoan as 'Tài Khoản', ngaysinh as 'Ngày Sinh' , gioitinh as 'Giới Tính'  from DangNhap";
            using (SqlConnection sqlConnection = Connection.getConnection())
            {
                sqlConnection.Open();
                adapter = new SqlDataAdapter(query, sqlConnection);
                adapter.Fill(dt);
                sqlConnection.Close();
            }
            return dt;
        }
    }
}
