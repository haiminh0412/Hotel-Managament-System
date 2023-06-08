using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Hotel_Management_System_Winforrm
{
    class QuanLyPhong
    {
        private DataTable dataTable;
        private SqlDataAdapter sqlDataAdapter;

        public DataTable ThongTinNhanVien()
        {
            dataTable = new DataTable();
            string query = "select * from phong";
            using (SqlConnection sqlConnection = Connection.getConnection())
            {
                sqlConnection.Open();
                sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);
                sqlDataAdapter.Fill(dataTable);
                sqlConnection.Close();
            }
            return dataTable;
        }

        public bool ThemPhong(Phong phong)
        {
            SqlConnection sqlConnection = Connection.getConnection();
            string query = "insert into Phong values(@id, @ten, @loaiphong, @mota, @songuoitoida, @trangthai)";
            try
            {
              
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

        public bool XoaPhong(string maphong)
        {
            SqlConnection sqlConnection = Connection.getConnection();
            string query = "delete from Phong where MaPhong = '" + maphong + "'";
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

        public bool SuaPhong(Phong phong)
        {
            SqlConnection sqlConnection = Connection.getConnection();
            string query = "update Phong set TenPhong = @ten, LoaiPhong = @loaiphong, Mota = @Mota, songtoida = @songtoida, trangthai = @trangthai where MaPhong = @maphong";
            try
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
             
                sqlCommand.Parameters.AddWithValue("@ten", phong.Tenphong);
                sqlCommand.Parameters.AddWithValue("@loaiphong", phong.Loaiphong);
                sqlCommand.Parameters.AddWithValue("@Mota", phong.Motaphong);
                sqlCommand.Parameters.AddWithValue("@songtoida", phong.Songuoitoida);
                sqlCommand.Parameters.AddWithValue("@trangthai", phong.Trangthai);
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
            string query = "select * from Phong where " + truongtimkiem + " like '%" + giatritimkiem + "%'";
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