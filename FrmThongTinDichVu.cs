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
    public partial class FrmThongTinDichVu : Form
    {
        private string tenphong;
        private float tongtienphaitra;
        private float tiendichvu;

        public FrmThongTinDichVu(string tenphong)
        {
            InitializeComponent();
            this.tenphong = tenphong;
        }

        QLDichVu qLDichVu = new QLDichVu();

        private void inThongTin(Dichvu dichvu)
        {
            txtTenSanPham.Text = dichvu.Tendichvu;
            txtSoLuong.Text = dichvu.Soluong.ToString();
            txtGia.Text = dichvu.Gia.ToString();
            txtLoaiSanPham.Text = dichvu.Loaidichvu;
        }

        private float TienDichVu()
        {
            tiendichvu = float.Parse(txtChonSoLuong.Text) * float.Parse(txtGia.Text);
            return tiendichvu;
        }

        private void btnTraSua_Click(object sender, EventArgs e)
        {
            Dichvu dichvu = new Dichvu();
            if (qLDichVu.thongTinDichVu(btnTraSua.Text, dichvu))
            {
                inThongTin(dichvu);
            }
            else
            {
                MessageBox.Show("Loi!");
            }
        }

        private void btnBia_Click(object sender, EventArgs e)
        {
            Dichvu dichvu = new Dichvu();
            if (qLDichVu.thongTinDichVu(btnBia.Text, dichvu))
            {
                inThongTin(dichvu);
            }
            else
            {
                MessageBox.Show("Loi!");
            }
        }

        private void btnSnack_Click(object sender, EventArgs e)
        {
            Dichvu dichvu = new Dichvu();
            if (qLDichVu.thongTinDichVu(btnSnack.Text, dichvu))
            {
                inThongTin(dichvu);
            }
            else
            {
                MessageBox.Show("Loi!");
            }
        }

        private void btnHotDog_Click(object sender, EventArgs e)
        {
            Dichvu dichvu = new Dichvu();
            if (qLDichVu.thongTinDichVu(btnHotDog.Text, dichvu))
            {
                inThongTin(dichvu);
            }
            else
            {
                MessageBox.Show("Loi!");
            }
        }

        private void btnSup_Click(object sender, EventArgs e)
        {
            Dichvu dichvu = new Dichvu();
            if (qLDichVu.thongTinDichVu(btnSup.Text, dichvu))
            {
                inThongTin(dichvu);
            }
            else
            {
                MessageBox.Show("Loi!");
            }
        }

        private void btnKFC_Click(object sender, EventArgs e)
        {
            Dichvu dichvu = new Dichvu();
            if (qLDichVu.thongTinDichVu(btnKFC.Text, dichvu))
            {
                inThongTin(dichvu);
            }
            else
            {
                MessageBox.Show("Loi!");
            }
        }

        private void btnMiXao_Click(object sender, EventArgs e)
        {
            Dichvu dichvu = new Dichvu();
            if (qLDichVu.thongTinDichVu(btnMiXao.Text, dichvu))
            {
                inThongTin(dichvu);
            }
            else
            {
                MessageBox.Show("Loi!");
            }
        }

        private void btnCaPhe_Click(object sender, EventArgs e)
        {
            Dichvu dichvu = new Dichvu();
            if (qLDichVu.thongTinDichVu(btnCaPhe.Text, dichvu))
            {
                inThongTin(dichvu);
            }
            else
            {
                MessageBox.Show("Loi!");
            }
        }

        private void btnComRang_Click(object sender, EventArgs e)
        {
            Dichvu dichvu = new Dichvu();
            if (qLDichVu.thongTinDichVu(btnComRang.Text, dichvu))
            {
                inThongTin(dichvu);
            }
            else
            {
                MessageBox.Show("Loi!");
            }
        }

        private void btnCoca_Click(object sender, EventArgs e)
        {
            Dichvu dichvu = new Dichvu();
            if (qLDichVu.thongTinDichVu(btnCoca.Text, dichvu))
            {
                inThongTin(dichvu);
            }
            else
            {
                MessageBox.Show("Loi!");
            }
        }

        private bool kiemTraDatSoLuong()
        {
            if (txtChonSoLuong.Text == "" || txtSoLuong.Text == "") return true;

            string datsoluong = txtChonSoLuong.Text.Trim();
            for(int i = 0; i < datsoluong.Length; ++i)
            {
                if (datsoluong[i] < '0' || datsoluong[i] > '9')
                    return false;
            }
            int datslg = Convert.ToInt32(datsoluong);
            return datslg >= 0 && datslg <= Convert.ToInt32(txtSoLuong.Text);
        }

        private void txtChonSoLuong_TextChanged(object sender, EventArgs e)
        {
            if(txtGia.Text == "" || txtChonSoLuong.Text == "")
            {
                txtGiaDichVu.Text = "0";
                return;
            }

            if (kiemTraDatSoLuong())
            {
                txtChonSoLuong.ForeColor = Color.Black;
                tiendichvu = TienDichVu();
                txtGiaDichVu.Text = tiendichvu.ToString();
                
            }
            else
            {
                txtChonSoLuong.ForeColor = Color.Red;
                txtGiaDichVu.Text = "0";
            }
        }

        private float tongTienPhaiTra()
        {
            float tongtien = float.Parse(txtTienPhong.Text) + float.Parse(txtTienDichVu.Text);
            return tongtien;
        }

        private void FrmThongTinDichVu_Load(object sender, EventArgs e)
        {
            txtPhong.Text = tenphong;
            txtTienDichVu.Text = "0";
            txtChonSoLuong.Text = "0";
            txtSoLuong.Text = "0";
            txtGia.Text = "0";
            txtGiaDichVu.Text = "0";
            ThuePhong thuePhong = new ThuePhong();
            if (qLDichVu.thongTinKhachThuePhong(thuePhong, tenphong))
            {
                txtLoaiPhong.Text = thuePhong.Loaiphong;
                txtTenKhach.Text = thuePhong.Tenkhachhang;
                dtpNgaySinh.Value = thuePhong.Ngaysinh;
                if (thuePhong.Gioitinh == "Nam") rdoNam.Checked = true;
                else rdoNu.Checked = true;
                txtSDT.Text = thuePhong.Sodienthoai;
                txtCMND.Text = thuePhong.Cmnd;
                cboQuocTich.Text = thuePhong.Quoctich.ToString();
                dtpNgayDen.Value = thuePhong.Ngayden;
                dtpNguoiDi.Value = thuePhong.Ngaydi;
                txtTienPhong.Text = thuePhong.Tienphaitra.ToString();
                tongtienphaitra = tongTienPhaiTra();
                txtTongTien.Text = tongtienphaitra.ToString();
            }
            else
            {
                MessageBox.Show("Lỗi hiển thị thông tin khách đang ở!");
            }

            try
            {
                dgvBangDichVu.DataSource = qLDichVu.bangdatdichvu(txtPhong.Text);
            }
            catch
            {
                MessageBox.Show("Lỗi hiển thị bảng dịch vụ!");
            }
        }

        private void btnDatDichVu_Click(object sender, EventArgs e)
        {
            if (txtChonSoLuong.Text == "0") return;

            if(txtChonSoLuong.Text == "" || txtChonSoLuong.ForeColor == Color.Red)
            {
                MessageBox.Show("Vui lòng nhập số lượng cho đúng!");
                return;
            }

            int soluongdat = qLDichVu.timSoLuongDat(txtTenSanPham.Text, txtPhong.Text);
  
            try
            {
                string phong = txtPhong.Text;
                string tendichvu = txtTenSanPham.Text;
                string loaidichvu = txtLoaiSanPham.Text;
                float gia = float.Parse(txtGia.Text);
                int soluong = Convert.ToInt32(txtSoLuong.Text);
                int soluongkhachdat = Convert.ToInt32(txtChonSoLuong.Text);
                float tiendichvu = float.Parse(txtGiaDichVu.Text);
                soluongdat += soluongkhachdat;
                if(soluongdat == soluongkhachdat && qLDichVu.themdichvu(phong, tendichvu, loaidichvu, gia, soluong, soluongkhachdat, tiendichvu))
                {
                    try
                    {
                        dgvBangDichVu.DataSource = qLDichVu.bangdatdichvu(phong);
                    }
                    catch
                    {
                        MessageBox.Show("Lỗi hiển thị bảng dịch vụ!");
                    }
                }
                else if(qLDichVu.capNhapBangDatDichVu(tendichvu, soluongdat, gia, phong))
                {
                    try
                    {
                        dgvBangDichVu.DataSource = qLDichVu.bangdatdichvu(phong);
                    }
                    catch
                    {
                        MessageBox.Show("Lỗi hiển thị bảng dịch vụ!");
                    }
                }
                else
                {
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Lỗi thêm dịch vụ! ");
            }

            int soluongconlai = Convert.ToInt32(txtSoLuong.Text) - Convert.ToInt32(txtChonSoLuong.Text);
            if (qLDichVu.capNhapSoLuongDichVu(txtTenSanPham.Text, soluongconlai))
            {
                txtSoLuong.Text = soluongconlai.ToString();
            }
            else
            {
                MessageBox.Show("Cap nhap so luong bi loi!");
            }

            tiendichvu += Convert.ToInt32(txtGiaDichVu.Text);
            txtTienDichVu.Text = tiendichvu.ToString();
            tongtienphaitra = tongTienPhaiTra();
            txtTongTien.Text = tongtienphaitra.ToString();

            txtChonSoLuong.Text = "0";
        }
    }
}