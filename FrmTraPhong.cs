using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel_Management_System_Winforrm
{
    public partial class FrmTraPhong : Form
    {
        private TraPhong traPhong;
        private string tenphong;
        private QuanLyTraPhong quanLyTraPhong;

        public FrmTraPhong(string tenphong)
        {
            InitializeComponent();
            this.tenphong = tenphong;
            traPhong = new TraPhong();
        }

        private void FrmTraPhong_Load(object sender, EventArgs e)
        {
            try
            {
                dgvBangDichVu.DataSource = traPhong.hienThiBangDichVu(tenphong);
            }
            catch
            {
                MessageBox.Show("Loi hien thi bang");
            }

            quanLyTraPhong = new QuanLyTraPhong();
            if(traPhong.hienThiThongTin(quanLyTraPhong, tenphong))
            {
                txtPhong.Text = tenphong;
                txtLoaiPhong.Text = quanLyTraPhong.Loaiphong;
                txtTenKhach.Text = quanLyTraPhong.Tenkhachhang;
                dtpNgaySinh.Value = quanLyTraPhong.Ngaysinh;
                if (quanLyTraPhong.Gioitinh == "Nam") rdoNam.Checked = true;
                else rdoNu.Checked = true;
                txtSDT.Text = quanLyTraPhong.Sodienthoai;
                txtCMND.Text = quanLyTraPhong.Cmnd;
                cboQuocTich.SelectedItem = quanLyTraPhong.Quoctich;
                dtpNgayDen.Value = quanLyTraPhong.Ngayden;
                dtpNguoiDi.Value = quanLyTraPhong.Ngaydi;
                txtTienPhong.Text = quanLyTraPhong.Tienphong.ToString();
            }
            else
            {
                MessageBox.Show("Loi hien thi thong tin");
            }
            float tiendichvu =  traPhong.tienDichVu(tenphong);
            txtTienDichVu.Text = tiendichvu.ToString();

            float tongtien = tiendichvu + quanLyTraPhong.Tienphong;
            txtTongTien.Text = tongtien.ToString();
        }

        private bool kiemTraSoHopLe(string s)
        {
            if (String.IsNullOrEmpty(s)) return false;

            for(int i = 0; i < s.Length; ++i)
            {
                if (s[i] < '0' || s[i] > '9') return false;
            }
            float num = float.Parse(s);
            return num >= float.Parse(txtTongTien.Text);
        }
        private void txtTienKhachTra_TextChanged(object sender, EventArgs e)
        {
            if(kiemTraSoHopLe(txtTienKhachTra.Text))
            {
                float tienthua = float.Parse(txtTienKhachTra.Text) - float.Parse(txtTongTien.Text);
                txtTienKhachTra.ForeColor = Color.Black;
                txtTraChoKhach.Text = tienthua.ToString();
            }
            else
            {
                txtTienKhachTra.ForeColor = Color.Red;
                txtTraChoKhach.Text = "0";
            }
        }

        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
            InHoaDon inHoaDon = new InHoaDon();
            inHoaDon.Show();
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if(txtTienKhachTra.ForeColor != Color.Red)
            {
                if(!traPhong.themThongTinTraPhong(quanLyTraPhong, float.Parse(txtTienDichVu.Text), float.Parse(txtTongTien.Text)))
                {
                    MessageBox.Show("ERROR!");
                }
                txtTienKhachTra.ReadOnly = true;
                MessageBox.Show("Thanh toan thanh cong!");
            }
        }
    }
}
