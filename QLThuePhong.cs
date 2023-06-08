using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Hotel_Management_System_Winforrm
{
    class QLThuePhong
    {
        DataTable dataTable;
        SqlDataAdapter sqlDataAdapter;

        public DataTable thongTinNguoiThuePhong(string tenphong)
        {
            string query = "select * from datphong where phong = '" + tenphong + "'";
            using(SqlConnection sqlConnection = Connection.getConnection())
            {
                sqlConnection.Open();
                sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);
                dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                sqlConnection.Close();
            }
            return dataTable;
        }

        public DataTable thongTinThuePhong(string tenphong)
        {
            string query = "select * from thuephong where phong = '" + tenphong + "'";
            using (SqlConnection sqlConnection = Connection.getConnection())
            {
                sqlConnection.Open();
                sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);
                dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                sqlConnection.Close();
            }
            return dataTable;
        }

        public int songuoitoda(string phong)
        {
            string query = "select songuoitoida from phong where phong = @phong";
            int songuoi = 0;
            SqlConnection sqlConnection = null;
            try
            {
                sqlConnection = Connection.getConnection();
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@phong", phong);
                songuoi = (int)sqlCommand.ExecuteScalar();
            }
            catch
            {
                return 0;
            }
            finally
            {
                sqlConnection.Close();
            }
            return songuoi;
        }

        public string loaiphong(string phong)
        {
            string query = "select loaiphong from phong where phong = @phong";
            string loaiphong = "";
            SqlConnection sqlConnection = null;
            try
            {
                sqlConnection = Connection.getConnection();
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@phong", phong);
                loaiphong = (string)sqlCommand.ExecuteScalar();
            }
            catch
            {
                return "ERROR!";
            }
            finally
            {
                sqlConnection.Close();
            }
            return loaiphong;
        }

        public string trangthai(string phong)
        {
            string query = "select trangthai from phong where phong = @phong";
            string trangthai = "";
            SqlConnection sqlConnection = null;
            try
            {
                sqlConnection = Connection.getConnection();
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@phong", phong);
                trangthai = (string)sqlCommand.ExecuteScalar();
            }
            catch
            {
                return "ERROR!";
            }
            finally
            {
                sqlConnection.Close();
            }
            return trangthai;
        }

        public bool capNhapTrangThai(string tenphong)
        {
            string query = "update phong set trangthai = 'Co nguoi o' where phong = '" + tenphong + "'";
            SqlConnection sqlConnection = null;
            try
            {
                sqlConnection = Connection.getConnection();
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

        public double giaphong(string phong)
        {
            string query = "select giaphong from phong where phong = @phong";
            double giaphong = 10.0;
            SqlConnection sqlConnection = null;
            try
            {
                sqlConnection = Connection.getConnection();
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@phong", phong);
                giaphong = (double)sqlCommand.ExecuteScalar();
            }
            catch
            {
                return 0.0;
            }
            finally
            {
                sqlConnection.Close();
            }
            return giaphong;
        }

        public bool thuephongchokhach(ThuePhong thuePhong)
        {
            string query = "insert into thuephong values(@phong, @loaiphong, @tenkhachhang, @ngaysinh, @gioitinh, @sodienthoai, @cmnd, @songuoio, @quoctich, @ngayden, @ngaydi, @tienphaitra)";
            SqlConnection sqlConnection = null;
            try
            {
                sqlConnection = Connection.getConnection();
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@phong", thuePhong.Tenphong);
                sqlCommand.Parameters.AddWithValue("@loaiphong", thuePhong.Loaiphong);
                sqlCommand.Parameters.AddWithValue("@tenkhachhang", thuePhong.Tenkhachhang);
                sqlCommand.Parameters.AddWithValue("@ngaysinh", thuePhong.Ngaysinh);
                sqlCommand.Parameters.AddWithValue("@gioitinh", thuePhong.Gioitinh);
                sqlCommand.Parameters.AddWithValue("@sodienthoai", thuePhong.Sodienthoai);
                sqlCommand.Parameters.AddWithValue("@cmnd", thuePhong.Cmnd);
                sqlCommand.Parameters.AddWithValue("@songuoio", thuePhong.Songuoio);
                sqlCommand.Parameters.AddWithValue("@quoctich", thuePhong.Quoctich);
                sqlCommand.Parameters.AddWithValue("@ngayden", thuePhong.Ngayden);
                sqlCommand.Parameters.AddWithValue("@ngaydi", thuePhong.Ngaydi);
                sqlCommand.Parameters.AddWithValue("@tienphaitra", thuePhong.Tienphaitra);
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

        public bool xoaThongTinDatPhong(string cmnd, string tenphong)
        {
            string query = "delete from datphong where cmnd = '" + cmnd + "' and phong = '" + tenphong + "'";
            SqlConnection sqlConnection = null;
            try
            {
                sqlConnection = Connection.getConnection();
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
        public DataTable timKiem(string cmnd, string tenphong)
        {
            string query = "select * from datphong where cmnd = '" + cmnd + "' and phong = '" + tenphong + "'";
            using (SqlConnection sqlConnection = Connection.getConnection())
            {
                sqlConnection.Open();
                sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);
                dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                sqlConnection.Close();
            }
            return dataTable;
        }
    }
}