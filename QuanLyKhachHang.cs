using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Hotel_Management_System_Winforrm
{
    class QuanLyKhachHang
    {
        private DataTable dataTable;
        private SqlDataAdapter sqlDataAdapter;

        public DataTable ThongTinKhachHang()
        {
            dataTable = new DataTable();
            string query = "select * from khachhang";
            using (SqlConnection sqlConnection = Connection.getConnection())
            {
                sqlConnection.Open();
                sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);
                sqlDataAdapter.Fill(dataTable);
                sqlConnection.Close();
            }
            return dataTable;
        }

        public bool ThemNhanVien(KhachHang khachhang)
        {
            SqlConnection sqlConnection = Connection.getConnection();
            string query = "insert into khachhang values(@id, @ten, @ngaysinh, @gioitinh, @sdt, @cmnd, @email)";
            try
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@id", khachhang.Makhachhang);
                sqlCommand.Parameters.AddWithValue("@ten", khachhang.Tenkhachhang);
                sqlCommand.Parameters.AddWithValue("@ngaysinh", khachhang.Ngaysinh);
                sqlCommand.Parameters.AddWithValue("@gioitinh", khachhang.Gioitinh);
                sqlCommand.Parameters.AddWithValue("@sdt", khachhang.Sodienthoai);
                sqlCommand.Parameters.AddWithValue("@cmnd", khachhang.Cmmnd);
                sqlCommand.Parameters.AddWithValue("@email", khachhang.Email);
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

        public bool XoaKhachHang(string makh)
        {
            SqlConnection sqlConnection = Connection.getConnection();
            string query = "delete from KhachHang where Makh = '" + makh + "'";
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

        public bool SuaKhachHang(KhachHang khachHang)
        {
            SqlConnection sqlConnection = Connection.getConnection();
            string query = "update khachhang set Tenkh = @ten, Ngaysinh = @ngaysinh, gioitinh = @gioitinh, sdt = @sdt, Cmnd = @cmnd, Email = @email where Makh = @makh";
            try
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@makh", khachHang.Makhachhang);
                sqlCommand.Parameters.AddWithValue("@ten", khachHang.Tenkhachhang);
                sqlCommand.Parameters.AddWithValue("@ngaysinh", khachHang.Ngaysinh);
                sqlCommand.Parameters.AddWithValue("@gioitinh", khachHang.Gioitinh);
                sqlCommand.Parameters.AddWithValue("@sdt", khachHang.Sodienthoai);
                sqlCommand.Parameters.AddWithValue("@cmnd", khachHang.Cmmnd);
                sqlCommand.Parameters.AddWithValue("@email", khachHang.Email);
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
            string query = "select * from khachhang where " + truongtimkiem + " like '%" + giatritimkiem + "%'";
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
