using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Hotel_Management_System_Winforrm
{
    class QLDichVu
    {
        DataTable dataTable;
        SqlDataAdapter sqlDataAdapter;

        public bool thongTinDichVu(string tendichvu, Dichvu dichvu)
        {
            string query = "SELECT TOP 1 * FROM dichvu WHERE tendichvu = @tendichvu";
            SqlConnection sqlConnection = null;
            SqlDataReader reader = null;
            try
            {
                sqlConnection = Connection.getConnection();
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@tendichvu", tendichvu);
                reader = sqlCommand.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        dichvu.Tendichvu = reader["tendichvu"].ToString();
                        dichvu.Loaidichvu = reader["loaidichvu"].ToString();
                        dichvu.Gia = float.Parse(reader["gia"].ToString());
                        dichvu.Soluong = Convert.ToInt32(reader["soluong"]);
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

        public bool thongTinKhachThuePhong(ThuePhong thuePhong, string tenphong)
        {
            string query = "SELECT TOP 1 * FROM thuephong where phong = @tenphong";
            SqlConnection sqlConnection = null;
            SqlDataReader reader = null;
            try
            {
                sqlConnection = Connection.getConnection();
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@tenphong", tenphong);
                reader = sqlCommand.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        thuePhong.Tenphong = reader["phong"].ToString();
                        thuePhong.Loaiphong = reader["loaiphong"].ToString();
                        thuePhong.Tenkhachhang = reader["tenkhachhang"].ToString();
                        thuePhong.Ngaysinh = Convert.ToDateTime(reader["ngaysinh"]);
                        thuePhong.Gioitinh = reader["gioitinh"].ToString();
                        thuePhong.Sodienthoai = reader["sodienthoai"].ToString();
                        thuePhong.Cmnd = reader["cmnd"].ToString();
                        thuePhong.Songuoio = Convert.ToInt32(reader["songuoio"]);
                        thuePhong.Quoctich = reader["quoctich"].ToString();
                        thuePhong.Ngayden = Convert.ToDateTime(reader["ngayden"]);
                        thuePhong.Ngaydi = Convert.ToDateTime(reader["ngaydi"]);
                        thuePhong.Tienphaitra = float.Parse(reader["tienphaitra"].ToString());
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

        public int timSoLuongDat(string tendichvu, string phong)
        {
            string query = "select soluongkhachdat from bangdatdichvu where tendichvu = @tendichvu and phong = @phong";
            SqlConnection sqlConnection = null;
            int soluongdat = 0;
            try
            {
                sqlConnection = Connection.getConnection();
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@tendichvu", tendichvu);
                sqlCommand.Parameters.AddWithValue("@phong", phong);
                if (sqlCommand.ExecuteScalar() != null)
                {
                    soluongdat = (int)sqlCommand.ExecuteScalar();
                }
            }
            catch
            {
                return 0;
            }
            finally
            {
                sqlConnection.Close();
            }
            return soluongdat;
        }

        public bool capNhapBangDatDichVu(string tendichvu, int soluongdat, float gia, string phong)
        {
            string query = "update bangdatdichvu set soluongkhachdat = @soluongdat, tongtien = @tongtien where tendichvu = @tendichvu and phong = @phong";
            SqlConnection sqlConnection = null;
            try
            {
                sqlConnection = Connection.getConnection();
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@phong", phong);
                sqlCommand.Parameters.AddWithValue("@tendichvu", tendichvu);
                sqlCommand.Parameters.AddWithValue("@soluongdat", soluongdat);
                sqlCommand.Parameters.AddWithValue("@tongtien", gia * soluongdat);
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

        public bool capNhapSoLuongDichVu(string tendichvu, int soluongconlai)
        {
            string query = "update dichvu set soluong = @soluongconlai where tendichvu = @tendichvu";
            SqlConnection sqlConnection = null;
            try
            {
                sqlConnection = Connection.getConnection();
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@soluongconlai", soluongconlai);
                sqlCommand.Parameters.AddWithValue("@tendichvu", tendichvu);
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

        public DataTable bangdatdichvu(string phong)
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

        public bool themdichvu(string phong, string tendv, string loaidv, float gia, int soluong, int soluongkhachdat, float tongtien)
        {
            string query = "insert into bangdatdichvu values(@phong, @tendichvu, @loaidichvu, @gia,  @soluong, @soluongkhachdat, @tongtien)";
            SqlConnection sqlConnection = null;
            try
            {
                sqlConnection = Connection.getConnection();
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@phong", phong);
                sqlCommand.Parameters.AddWithValue("@tendichvu", tendv);
                sqlCommand.Parameters.AddWithValue("@loaidichvu", loaidv);
                sqlCommand.Parameters.AddWithValue("@gia", gia);
                sqlCommand.Parameters.AddWithValue("@soluong", soluong);
                sqlCommand.Parameters.AddWithValue("@soluongkhachdat", soluongkhachdat);
                sqlCommand.Parameters.AddWithValue("@tongtien", tongtien);
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
            return true ;
        }
    }
}
