using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Hotel_Management_System_Winforrm
{
    class TraPhong
    {
        DataTable dataTable;
        SqlDataAdapter sqlDataAdapter;

        public DataTable hienThiBangDichVu(string phong)
        {
            string query = "select * from bangdatdichvu where phong = '" + phong + "'";
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

        public bool hienThiThongTin(QuanLyTraPhong quanLyTraPhong, string phong)
        {
            string query = "select top 1 * from thuephong where phong = @phong";
            SqlConnection sqlConnection = null;
            SqlDataReader reader = null;
            try
            {
                sqlConnection = Connection.getConnection();
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@phong", phong);
                reader = sqlCommand.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        quanLyTraPhong.Tenphong = reader["phong"].ToString();
                        quanLyTraPhong.Loaiphong = reader["loaiphong"].ToString();
                        quanLyTraPhong.Tenkhachhang = reader["tenkhachhang"].ToString();
                        quanLyTraPhong.Ngaysinh = Convert.ToDateTime(reader["ngaysinh"]);
                        quanLyTraPhong.Gioitinh = reader["gioitinh"].ToString();
                        quanLyTraPhong.Sodienthoai = reader["sodienthoai"].ToString();
                        quanLyTraPhong.Cmnd = reader["cmnd"].ToString();
                        quanLyTraPhong.Songuoio = Convert.ToInt32(reader["songuoio"]);
                        quanLyTraPhong.Quoctich = reader["quoctich"].ToString();
                        quanLyTraPhong.Ngayden = Convert.ToDateTime(reader["ngayden"]);
                        quanLyTraPhong.Ngaydi = Convert.ToDateTime(reader["ngaydi"]);
                        quanLyTraPhong.Tienphong = float.Parse(reader["tienphaitra"].ToString());
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
                return false;
            }
            finally
            {
                if (reader != null && !reader.IsClosed)
                    reader.Close();

                if (sqlConnection != null && sqlConnection.State == ConnectionState.Open)
                    sqlConnection.Close();
            }
            return true;
        }

        public float tienDichVu(string tenphong)
        {
            string query = "select tongtien from bangdatdichvu where phong = @phong";
            SqlConnection sqlConnection = null;
            SqlDataReader reader = null;
            float tongtien = 0.0f;
            try
            {
                sqlConnection = Connection.getConnection();
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@phong", tenphong);
                reader = sqlCommand.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        float gia = float.Parse(reader["tongtien"].ToString());
                        tongtien += gia;
                    }
                }
                else
                {
                    return 0.0f;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
            }
            finally
            {
                if (reader != null && !reader.IsClosed)
                    reader.Close();

                if (sqlConnection != null && sqlConnection.State == ConnectionState.Open)
                    sqlConnection.Close();
            }
            return tongtien;
        }

        public bool themThongTinTraPhong(QuanLyTraPhong quanLyTraPhong, float tiendichvu, float tongtien)
        {
            string query = "insert into traphong (phong, loaiphong, tenkhachhang, ngaysinh, gioitinh, sodienthoai, cmnd, songuoio, " +
                 "quoctich, ngayden, ngaydi, tienphong, tiendichvu, tongtien) " +
                 "values (@phong, @loaiphong, @tenkhachhang, @ngaysinh, @gioitinh, @sodienthoai, @cmnd, @songuoio, " +
                 "@quoctich, @ngayden, @ngaydi, @tienphong, @tiendichvu, @tongtien)";

            SqlConnection sqlConnection = null;
            try
            {
                sqlConnection = Connection.getConnection();
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@phong", quanLyTraPhong.Tenphong);
                sqlCommand.Parameters.AddWithValue("@loaiphong", quanLyTraPhong.Loaiphong);
                sqlCommand.Parameters.AddWithValue("@tenkhachhang", quanLyTraPhong.Tenkhachhang);
                sqlCommand.Parameters.AddWithValue("@ngaysinh", quanLyTraPhong.Ngaysinh);
                sqlCommand.Parameters.AddWithValue("@gioitinh", quanLyTraPhong.Gioitinh);
                sqlCommand.Parameters.AddWithValue("@sodienthoai", quanLyTraPhong.Sodienthoai);
                sqlCommand.Parameters.AddWithValue("@cmnd", quanLyTraPhong.Cmnd);
                sqlCommand.Parameters.AddWithValue("@songuoio", quanLyTraPhong.Songuoio);
                sqlCommand.Parameters.AddWithValue("@quoctich", quanLyTraPhong.Quoctich);
                sqlCommand.Parameters.AddWithValue("@ngayden", quanLyTraPhong.Ngayden);
                sqlCommand.Parameters.AddWithValue("@ngaydi", quanLyTraPhong.Ngaydi);
                sqlCommand.Parameters.AddWithValue("@tienphong", quanLyTraPhong.Tienphong);
                sqlCommand.Parameters.AddWithValue("@tiendichvu", tiendichvu);
                sqlCommand.Parameters.AddWithValue("@tongtien", tongtien);
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
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
