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

        private void trangthai(string s)
        {
            switch(s)
            {
                case "macdinh":
                    txtChonSoLuong.ReadOnly = false;
                    btnDatDichVu.Enabled = true;
                    btnHuyDichVu.Enabled = false;
                    btnSuaDichVu.Enabled = false;
                    btnLuu.Enabled = false;
                    break;

                case "cell-click":
                    txtChonSoLuong.ReadOnly = true;
                    btnDatDichVu.Enabled = false;
                    btnHuyDichVu.Enabled = true;
                    btnSuaDichVu.Enabled = true;
                    btnLuu.Enabled = false;
                    break;

                case "Sua":
                    txtChonSoLuong.ReadOnly = false;
                    btnDatDichVu.Enabled = false;
                    btnHuyDichVu.Enabled = false;
                    btnSuaDichVu.Enabled = false;
                    btnLuu.Enabled = true;
                    break;

                default:
                    break;
            }
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
            tiendichvu = 0.0f;
            txtPhong.Text = tenphong;
            txtChonSoLuong.Text = "0";
            txtSoLuong.Text = "0";
            txtGia.Text = "0";
            txtGiaDichVu.Text = "0";
            trangthai("macdinh");
            try
            {
                dgvBangDichVu.DataSource = qLDichVu.bangdatdichvu(txtPhong.Text);
            }
            catch
            {
                MessageBox.Show("Lỗi hiển thị bảng dịch vụ!");
            }

            for (int i = 0; i < dgvBangDichVu.Rows.Count - 1; ++i)
            {
                tiendichvu += float.Parse(dgvBangDichVu.Rows[i].Cells[5].Value.ToString());
            }
            txtTienDichVu.Text = tiendichvu.ToString();

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
        }

        private void DatDichVu()
        {
            if (txtChonSoLuong.Text == "0") return;

            if (txtChonSoLuong.Text == "" || txtChonSoLuong.ForeColor == Color.Red)
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
                float giadv = float.Parse(txtGiaDichVu.Text);
                soluongdat += soluongkhachdat;

                int soluongconlai = Convert.ToInt32(txtSoLuong.Text) - Convert.ToInt32(txtChonSoLuong.Text);
                if (qLDichVu.capNhapSoLuongDichVu(txtTenSanPham.Text, soluongconlai))
                {
                    txtSoLuong.Text = soluongconlai.ToString();
                }
                else
                {
                    MessageBox.Show("Cap nhap so luong bi loi!");
                }

                if (soluongdat == soluongkhachdat && qLDichVu.themdichvu(phong, tendichvu, loaidichvu, gia, soluongkhachdat, giadv))
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
                else if (qLDichVu.capNhapBangDatDichVu(tendichvu, soluongdat, gia, phong))
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

            tiendichvu = 0.0f;
            for (int i = 0; i < dgvBangDichVu.Rows.Count - 1; ++i)
            {
                tiendichvu += float.Parse(dgvBangDichVu.Rows[i].Cells[5].Value.ToString());
            }
            txtTienDichVu.Text = tiendichvu.ToString();
            tongtienphaitra = tongTienPhaiTra();
            txtTongTien.Text = tongtienphaitra.ToString();
            reset();
            trangthai("macdinh");
        }

        private void btnDatDichVu_Click(object sender, EventArgs e)
        {
            DatDichVu();
        }

        private void huyDichVu()
        {
            DialogResult result = MessageBox.Show(
                  "Bạn có chắc muốn xóa không?",
                  "Thông báo!",
                  MessageBoxButtons.YesNo,
                  MessageBoxIcon.Question
              );

            if (result == DialogResult.Yes)
            {
                txtTienDichVu.Text = (float.Parse(txtTienDichVu.Text) - float.Parse(txtGiaDichVu.Text)).ToString();
                tongtienphaitra = tongTienPhaiTra();
                txtTongTien.Text = tongtienphaitra.ToString();
                int soluongdat = Convert.ToInt32(txtChonSoLuong.Text);
                soluongdat += Convert.ToInt32(txtSoLuong.Text);
                qLDichVu.capNhapSoLuongDichVu(txtTenSanPham.Text, soluongdat);
                if (qLDichVu.xoaDichVu(txtTenSanPham.Text, tenphong))
                {
                    dgvBangDichVu.DataSource = qLDichVu.bangdatdichvu(tenphong);
                }
                else
                {
                    MessageBox.Show("Loi xoa dich vu!");
                }
                reset();
                trangthai("macdinh");
            }
        }

        private void btnHuyDichVu_Click(object sender, EventArgs e)
        {
            huyDichVu();
        }

        private void dgvBangDichVu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            trangthai("cell-click");
            DataGridViewRow row = (DataGridViewRow)dgvBangDichVu.Rows[e.RowIndex];
            if (e.RowIndex >= 0 && e.RowIndex < dgvBangDichVu.RowCount - 1)
            {
                txtTenSanPham.Text = row.Cells[1].Value.ToString();
                txtLoaiSanPham.Text = row.Cells[2].Value.ToString();
                txtGia.Text = row.Cells[3].Value.ToString();
                txtChonSoLuong.Text = row.Cells[4].Value.ToString();
                txtGiaDichVu.Text = row.Cells[5].Value.ToString();
                int soluong = qLDichVu.soLuongSanPham(txtTenSanPham.Text);
                txtSoLuong.Text = soluong.ToString();
            }
        }

        private void btnSuaDichVu_Click(object sender, EventArgs e)
        {
            trangthai("Sua");
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            
               DialogResult result = MessageBox.Show(
                   "Bạn có chắc muốn lưu không?",
                   "Thông báo!",
                   MessageBoxButtons.YesNo,
                   MessageBoxIcon.Question
               );

            if (result == DialogResult.Yes)
            {
                string tendichvu = txtTenSanPham.Text;
                int soluongdat = Convert.ToInt32(txtChonSoLuong.Text);
                float gia = float.Parse(txtGia.Text);
                if (qLDichVu.capNhapBangDatDichVu(tendichvu, soluongdat, gia, tenphong))
                {
                    try
                    {
                        dgvBangDichVu.DataSource = qLDichVu.bangdatdichvu(tenphong);
                    }
                    catch
                    {
                        MessageBox.Show("Lỗi hiển thị bảng dịch vụ!");
                    }
                    tiendichvu = 0.0f;
                    for (int i = 0; i < dgvBangDichVu.Rows.Count - 1; ++i)
                    {
                        tiendichvu += float.Parse(dgvBangDichVu.Rows[i].Cells[5].Value.ToString());
                    }
                    txtTienDichVu.Text = tiendichvu.ToString();
                    tongtienphaitra = tongTienPhaiTra();
                    txtTongTien.Text = tongtienphaitra.ToString();
                    reset();
                    trangthai("macdinh");
                }
            }
        }

        private void reset()
        {
            txtChonSoLuong.ReadOnly = false;
            txtChonSoLuong.Text = "";
            txtTenSanPham.Text = "";
            txtLoaiSanPham.Text = "";
            txtGia.Text = "0";
            txtSoLuong.Text = "0";
            txtChonSoLuong.Text = "0";
            txtGiaDichVu.Text = "0";
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            reset();
        }
    }
}