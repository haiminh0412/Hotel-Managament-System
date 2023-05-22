using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Hotel_Management_System_Winforrm
{
    class QuanLyNhanVien
    {
        private DataTable dataTable;
        private SqlDataAdapter sqlDataAdapter;

        public DataTable ThongTinNhanVien()
        {
            dataTable = new DataTable();
            string query = "select * from nhanvien";
            using (SqlConnection sqlConnection = Connection.getConnection())
            {
                sqlConnection.Open();
                sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);
                sqlDataAdapter.Fill(dataTable);
                sqlConnection.Close();
            }
            return dataTable;
        }

        public bool ThemNhanVien(NhanVien nhanVien)
        {
            SqlConnection sqlConnection = Connection.getConnection();
            string query = "insert into Nhanvien values(@id, @ten, @ngaysinh, @gioitinh, @sdt, @cmnd, @email)";
            try
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@id", nhanVien.Manhanvien);
                sqlCommand.Parameters.AddWithValue("@ten", nhanVien.Tennhanvien);
                sqlCommand.Parameters.AddWithValue("@ngaysinh", nhanVien.Ngaysinh);
                sqlCommand.Parameters.AddWithValue("@gioitinh", nhanVien.Gioitinh);
                sqlCommand.Parameters.AddWithValue("@sdt", nhanVien.Sodienthoai);
                sqlCommand.Parameters.AddWithValue("@cmnd", nhanVien.Cmmnd);
                sqlCommand.Parameters.AddWithValue("@email", nhanVien.Email);
                sqlCommand.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
            return true;
        }

        public bool XoaNhanVien(string manv)
        {
            SqlConnection sqlConnection = Connection.getConnection();
            string query = "delete from NhanVien where Manv = '" + manv + "'";
            try
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
            return true;
        }

        public bool SuaNhanVien(NhanVien nhanVien)
        {
            SqlConnection sqlConnection = Connection.getConnection();
            string query = "update nhanvien set Tennv = @ten, Ngaysinh = @ngaysinh, gioitinh = @gioitinh, sdt = @sdt, Cmnd = @cmnd, Email = @email where Manv = @manv";
            try
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@manv", nhanVien.Manhanvien);
                sqlCommand.Parameters.AddWithValue("@ten", nhanVien.Tennhanvien);
                sqlCommand.Parameters.AddWithValue("@ngaysinh", nhanVien.Ngaysinh);
                sqlCommand.Parameters.AddWithValue("@gioitinh", nhanVien.Gioitinh);
                sqlCommand.Parameters.AddWithValue("@sdt", nhanVien.Sodienthoai);
                sqlCommand.Parameters.AddWithValue("@cmnd", nhanVien.Cmmnd);
                sqlCommand.Parameters.AddWithValue("@email", nhanVien.Email);
                sqlCommand.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
            return true;
        }

        public DataTable TimKiem(string truongtimkiem, string giatritimkiem)
        {
            string query = "select * from Nhanvien where " + truongtimkiem + " like '%" + giatritimkiem + "%'";
            using (SqlConnection sqlConnection = Connection.getConnection())
            {
                sqlConnection.Open();
                dataTable = new DataTable();
                sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);
                sqlDataAdapter.Fill(dataTable);
                sqlConnection.Close();
            }
            return dataTable;
        }

    }
}