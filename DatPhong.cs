using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Hotel_Management_System_Winforrm
{
    class DatPhong
    {
        DataTable dataTable;
        SqlDataAdapter sqlDataAdapter;

        public DataTable thongTinDatPhong(string phong)
        {
            string query = "select * from datphong where phong = '" + phong + "'";
            using (SqlConnection sqlConnection = Connection.getConnection())
            {
                sqlConnection.Open();
                 SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
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

        public bool datphongchokhach(ThongTinDatPhong thongTinDatPhong) 
        {
            string query = "insert into datphong values(@phong, @loaiphong, @tenkhachhang, @ngaysinh, @gioitinh, @sodienthoai, @cmnd, @songuoio, @quoctich, @ngayden, @ngaydi, @tiendatcoc, @tienphaitra)";
            SqlConnection sqlConnection = null;
            try
            {
                sqlConnection = Connection.getConnection();
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@phong", thongTinDatPhong.Tenphong);
                sqlCommand.Parameters.AddWithValue("@loaiphong", thongTinDatPhong.Loaiphong);
                sqlCommand.Parameters.AddWithValue("@tenkhachhang", thongTinDatPhong.Tenkhachhang);
                sqlCommand.Parameters.AddWithValue("@ngaysinh", thongTinDatPhong.Ngaysinh);
                sqlCommand.Parameters.AddWithValue("@gioitinh", thongTinDatPhong.Gioitinh);
                sqlCommand.Parameters.AddWithValue("@sodienthoai", thongTinDatPhong.Sodienthoai);
                sqlCommand.Parameters.AddWithValue("@cmnd", thongTinDatPhong.Cmnd);
                sqlCommand.Parameters.AddWithValue("@songuoio", thongTinDatPhong.Songuoio);
                sqlCommand.Parameters.AddWithValue("@quoctich", thongTinDatPhong.Quoctich);
                sqlCommand.Parameters.AddWithValue("@ngayden", thongTinDatPhong.Ngayden);
                sqlCommand.Parameters.AddWithValue("@ngaydi", thongTinDatPhong.Ngaydi);
                sqlCommand.Parameters.AddWithValue("@tiendatcoc", thongTinDatPhong.Tiendatcoc);
                sqlCommand.Parameters.AddWithValue("@tienphaitra", thongTinDatPhong.Tienphaitra);
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

        public bool suaThongTinDatPhong(ThongTinDatPhong thongTinDatPhong, string tenphong)
        {
            string query = "update datphong set tenkhachhang = @tenkhachhang, ngaysinh = @ngaysinh, gioitinh = @gioitinh, sodienthoai = @sodienthoai, songuoio = @songuoio, quoctich = @quoctich, ngayden = @ngayden, ngaydi = @ngaydi where cmnd = @cmnd and phong = '" + tenphong + "'";
            SqlConnection sqlConnection = null;
            try
            {
                sqlConnection = Connection.getConnection();
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@tenkhachhang", thongTinDatPhong.Tenkhachhang);
                sqlCommand.Parameters.AddWithValue("@ngaysinh", thongTinDatPhong.Ngaysinh);
                sqlCommand.Parameters.AddWithValue("@gioitinh", thongTinDatPhong.Gioitinh);
                sqlCommand.Parameters.AddWithValue("@sodienthoai", thongTinDatPhong.Sodienthoai);
                sqlCommand.Parameters.AddWithValue("@cmnd", thongTinDatPhong.Cmnd);
                sqlCommand.Parameters.AddWithValue("@songuoio", thongTinDatPhong.Songuoio);
                sqlCommand.Parameters.AddWithValue("@quoctich", thongTinDatPhong.Quoctich);
                sqlCommand.Parameters.AddWithValue("@ngayden", thongTinDatPhong.Ngayden);
                sqlCommand.Parameters.AddWithValue("@ngaydi", thongTinDatPhong.Ngaydi);
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
            string query = "delete from datphong where cmnd = '" + cmnd + "'" + " and phong = '" + tenphong + "'";
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

        
    }
}