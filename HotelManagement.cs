using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace Hotel_Management_System_Winforrm
{
    public partial class HotelManagement : Form
    {
      
        public HotelManagement()
        {
            InitializeComponent();
        }

        private void đặtPhòngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Button btnPhong = contextMenuStrip1.SourceControl as Button;
            string tenphong = btnPhong.Text;
            FrmDatPhong frmDatPhong = new FrmDatPhong(tenphong);
            frmDatPhong.Text = tenphong;
            frmDatPhong.Show();
        }

        private void thuêPhòngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Button btnPhong = contextMenuStrip1.SourceControl as Button;

            if(btnPhong.BackColor == Color.Red)
            {
                MessageBox.Show("Phong dang co nguoi o");
                return;
            }

            string tenphong = btnPhong.Text;
            FrmThuePhong frmThuePhong = new FrmThuePhong(tenphong, btnPhong);
            frmThuePhong.Text = tenphong;
            frmThuePhong.Show();
        }

        public string TrangThai(string phong)
        {
            string query = "select trangthai from phong where phong = '" + phong + "'";
            string trangthai = "";
            SqlConnection sqlConnection = null;

            try
            {
                sqlConnection = Connection.getConnection();
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                trangthai = (string)sqlCommand.ExecuteScalar();
            }
            catch
            {
                return "";
            }
            finally
            {
                sqlConnection.Close();
            }
            return trangthai;
        }

        private void HotelManagement_Load(object sender, EventArgs e)
        {
            if (TrangThai(btnP101.Text) == "Co nguoi o") btnP101.BackColor = Color.Red;
            if (TrangThai(btnP102.Text) == "Co nguoi o") btnP102.BackColor = Color.Red;
            if (TrangThai(btnP103.Text) == "Co nguoi o") btnP103.BackColor = Color.Red;
            if (TrangThai(btnP104.Text) == "Co nguoi o") btnP104.BackColor = Color.Red;
            if (TrangThai(btnP105.Text) == "Co nguoi o") btnP105.BackColor = Color.Red;
            if (TrangThai(btnP106.Text) == "Co nguoi o") btnP106.BackColor = Color.Red;
            if (TrangThai(btnP107.Text) == "Co nguoi o") btnP107.BackColor = Color.Red;
            if (TrangThai(btnP108.Text) == "Co nguoi o") btnP108.BackColor = Color.Red;
            if (TrangThai(btnP201.Text) == "Co nguoi o") btnP201.BackColor = Color.Red;
            if (TrangThai(btnP202.Text) == "Co nguoi o") btnP202.BackColor = Color.Red;
            if (TrangThai(btnP203.Text) == "Co nguoi o") btnP203.BackColor = Color.Red;
            if (TrangThai(btnP204.Text) == "Co nguoi o") btnP204.BackColor = Color.Red;
            if (TrangThai(btnP205.Text) == "Co nguoi o") btnP205.BackColor = Color.Red;
            if (TrangThai(btnP206.Text) == "Co nguoi o") btnP206.BackColor = Color.Red;
            if (TrangThai(btnP207.Text) == "Co nguoi o") btnP207.BackColor = Color.Red;
            if (TrangThai(btnP208.Text) == "Co nguoi o") btnP208.BackColor = Color.Red;
            if (TrangThai(btnP301.Text) == "Co nguoi o") btnP301.BackColor = Color.Red;
            if (TrangThai(btnP302.Text) == "Co nguoi o") btnP302.BackColor = Color.Red;
            if (TrangThai(btnP303.Text) == "Co nguoi o") btnP303.BackColor = Color.Red;
            if (TrangThai(btnP304.Text) == "Co nguoi o") btnP304.BackColor = Color.Red;
            if (TrangThai(btnP305.Text) == "Co nguoi o") btnP305.BackColor = Color.Red;
            if (TrangThai(btnP306.Text) == "Co nguoi o") btnP306.BackColor = Color.Red;
            if (TrangThai(btnP307.Text) == "Co nguoi o") btnP307.BackColor = Color.Red;
            if (TrangThai(btnP308.Text) == "Co nguoi o") btnP308.BackColor = Color.Red;
        }

        private void đặtDịchVụToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Button btnPhong = contextMenuStrip1.SourceControl as Button;
            if(btnPhong.BackColor == Color.Red)
            {
                string tenphong = btnPhong.Text;
                FrmThongTinDichVu frmThongTinDichVu = new FrmThongTinDichVu(tenphong);
                frmThongTinDichVu.Text = tenphong;
                frmThongTinDichVu.Show();
            }
        }

        private void trảPhòngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Button btnPhong = contextMenuStrip1.SourceControl as Button;
            string tenphong = btnPhong.Text;
            if(btnPhong.BackColor == Color.Red)
            {
                FrmTraPhong frmTraPhong = new FrmTraPhong(tenphong);
                frmTraPhong.Text = tenphong;
                frmTraPhong.Show();
            }
            else
            {
                MessageBox.Show("Phong trong!");
            }
        }
    }
}