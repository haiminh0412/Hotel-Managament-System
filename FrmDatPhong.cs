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
    public partial class FrmDatPhong : Form
    {
        string loaiphong;
        string tenphong;
        double giaphong;
        double tiencoc;
        int songayo;
        int songuoitoda;
        DatPhong datPhong = new DatPhong();

        public FrmDatPhong(string tenphong)
        {
            InitializeComponent();
            this.tenphong = tenphong;
        }

        private void trangthai(string tt)
        {
            switch (tt)
            {
                case "Them":
                    btnDatPhong_DatPhong.Enabled = true;
                    btnSuaThongTin_DatPhong.Enabled = false;
                    btnHuyDat_DatPhong.Enabled = false;
                    btnLuu_DatPhong.Enabled = false;
                    btnReset_DatPhong.Enabled = true;

                    txtTenKhach_DatPhong.Enabled = true;
                    txtSDT_DatPhong.Enabled = true;
                    dtpNgaySinh_DatPhong.Enabled = true;
                    rdoNam_DatPhong.Enabled = true;
                    rdoNu_DatPhong.Enabled = true;
                    txtCMND_DatPhong.Enabled = true;
                    txtSoNguoiO_DatPhong.Enabled = true;
                    cboQuocTich_DatPhong.Enabled = true;
                    dtpNgayDen_DatPhong.Enabled = true;
                    dtpNguoiDi_DatPhong.Enabled = true;
                    txtTienDatCoc_DatPhong.Enabled = true;
                    txtTenKhach_DatPhong.Focus();
                    break;

                case "Click":
                    btnDatPhong_DatPhong.Enabled = false;
                    btnSuaThongTin_DatPhong.Enabled = true;
                    btnHuyDat_DatPhong.Enabled = true;
                    btnLuu_DatPhong.Enabled = false;
                    btnReset_DatPhong.Enabled = true;

                    txtTenKhach_DatPhong.Enabled = false;
                    txtSDT_DatPhong.Enabled = false;
                    dtpNgaySinh_DatPhong.Enabled = false;
                    rdoNam_DatPhong.Enabled = false;
                    rdoNu_DatPhong.Enabled = false;
                    txtCMND_DatPhong.Enabled = false;
                    txtSoNguoiO_DatPhong.Enabled = false;
                    cboQuocTich_DatPhong.Enabled = false;
                    dtpNgayDen_DatPhong.Enabled = false;
                    dtpNguoiDi_DatPhong.Enabled = false;
                    txtTienDatCoc_DatPhong.Enabled = false;
                    break;

                case "Sua":
                    btnDatPhong_DatPhong.Enabled = false;
                    btnSuaThongTin_DatPhong.Enabled = false;
                    btnHuyDat_DatPhong.Enabled = false;
                    btnLuu_DatPhong.Enabled = true;
                    btnReset_DatPhong.Enabled = true;

                    txtTenKhach_DatPhong.Enabled = true;
                    txtSDT_DatPhong.Enabled = true;
                    dtpNgaySinh_DatPhong.Enabled = true;
                    rdoNam_DatPhong.Enabled = true;
                    rdoNu_DatPhong.Enabled = true;
                    txtCMND_DatPhong.Enabled = true;
                    txtSoNguoiO_DatPhong.Enabled = true;
                    cboQuocTich_DatPhong.Enabled = true;
                    dtpNgayDen_DatPhong.Enabled = true;
                    dtpNguoiDi_DatPhong.Enabled = true;
                    txtTienDatCoc_DatPhong.Enabled = true;
                    break;

                case "Huy":
                    btnDatPhong_DatPhong.Enabled = false;
                    btnSuaThongTin_DatPhong.Enabled = false;
                    btnHuyDat_DatPhong.Enabled = true;
                    btnLuu_DatPhong.Enabled = false;
                    btnReset_DatPhong.Enabled = true;

                    txtTenKhach_DatPhong.Enabled = false;
                    txtSDT_DatPhong.Enabled = false;
                    dtpNgaySinh_DatPhong.Enabled = false;
                    rdoNam_DatPhong.Enabled = false;
                    rdoNu_DatPhong.Enabled = false;
                    txtCMND_DatPhong.Enabled = false;
                    txtSoNguoiO_DatPhong.Enabled = false;
                    cboQuocTich_DatPhong.Enabled = false;
                    dtpNgayDen_DatPhong.Enabled = false;
                    dtpNguoiDi_DatPhong.Enabled = false;
                    txtTienDatCoc_DatPhong.Enabled = false;
                    break;

                default:
                    break;
            }
        }

        private bool KiemTraThongTin()
        {
            double value;
            return !String.IsNullOrEmpty(txtTenKhach_DatPhong.Text) && !String.IsNullOrEmpty(txtSDT_DatPhong.Text)
                && !String.IsNullOrEmpty(txtCMND_DatPhong.Text) && !String.IsNullOrEmpty(txtSoNguoiO_DatPhong.Text)
                && !String.IsNullOrEmpty(cboQuocTich_DatPhong.Text)
                && !String.IsNullOrEmpty(txtTienDatCoc_DatPhong.Text) && Double.TryParse(txtTienDatCoc_DatPhong.Text, out value)
                && txtTenKhach_DatPhong.ForeColor == Color.Black && txtSDT_DatPhong.ForeColor == Color.Black
                && txtSoNguoiO_DatPhong.ForeColor == Color.Black && txtTienDatCoc_DatPhong.ForeColor == Color.Black;
        }

        private bool kiemtraTienDatCoc()
        {
            return Convert.ToDouble(txtTienDatCoc_DatPhong.Text) >= Convert.ToDouble(txtTienCoc_DatPhong.Text);
        }

        private void FrmDatPhong_Load(object sender, EventArgs e)
        {
            trangthai("Them");
            txtSoNguoiO_DatPhong.Text = "0";
            cboQuocTich_DatPhong.SelectedItem = "Việt Nam (Vietnam)";
            txtPhong_DatPhong.Text = tenphong;
            txtLoaiPhong_DatPhong.Text = datPhong.loaiphong(tenphong);
            giaphong = datPhong.giaphong(tenphong);
            songuoitoda = datPhong.songuoitoda(tenphong);
            txtGiaPhong_DatPhong.Text = giaphong.ToString();
            tiencoc = giaphong * 0.5;
            txtTienCoc_DatPhong.Text = tiencoc.ToString();
            rdoNam_DatPhong.Checked = true;
            try
            {
                dgvBangPhong_DatPhong.DataSource = datPhong.thongTinDatPhong(tenphong);
            }
            catch
            {
                MessageBox.Show("Lỗi hiển thị bảng đặt phòng!");
            }
        }

        private ThongTinDatPhong TaoThongTinDatPhong()
        {
            string tenphonng = txtPhong_DatPhong.Text;
            string loaiphong = txtLoaiPhong_DatPhong.Text;
            string tenkhach = txtTenKhach_DatPhong.Text;
            DateTime ngaysinh = Convert.ToDateTime(dtpNgaySinh_DatPhong.Value);
            string gioitinh = rdoNam_DatPhong.Checked ? "Nam" : "Nữ";
            string sodienthoai = txtSDT_DatPhong.Text;
            string cmnd = txtCMND_DatPhong.Text;
            int songuoio = Convert.ToInt32(txtSoNguoiO_DatPhong.Text);
            string quoctich = cboQuocTich_DatPhong.SelectedItem.ToString();
            DateTime ngayden = Convert.ToDateTime(dtpNgayDen_DatPhong.Value);
            DateTime ngaydi = Convert.ToDateTime(dtpNguoiDi_DatPhong.Value);
            double tiendatcoc = Convert.ToDouble(txtTienDatCoc_DatPhong.Text);
            double tienphaitra = Convert.ToDouble(txtTienPhaiTra_DatPhong.Text);

            ThongTinDatPhong thongTinDatPhong = new ThongTinDatPhong(tenphong, loaiphong, tenkhach, ngaysinh, gioitinh, sodienthoai,
                cmnd, songuoio, quoctich, ngayden, ngaydi, tiendatcoc, tienphaitra);
            return thongTinDatPhong;
        }

        private void btnDatPhong_DatPhong_Click(object sender, EventArgs e)
        {
            trangthai("Them");

            if (!KiemTraThongTin())
            {
                MessageBox.Show("Thông tin thiếu hoặc định dạng sai!");
                return;
            }

            if(!kiemtraTienDatCoc())
            {
                MessageBox.Show("Tien coc khong du!");
                return;
            }

            ThongTinDatPhong thongTinDatPhong = TaoThongTinDatPhong();
           
            if(datPhong.datphongchokhach(thongTinDatPhong))
            {
                dgvBangPhong_DatPhong.DataSource = datPhong.thongTinDatPhong(tenphong);
            }
            else
            {
                MessageBox.Show("Lỗi đặt phòng!");
            }

        }

        private void dgvBangPhong_DatPhong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            trangthai("Click");
            DataGridViewRow row = (DataGridViewRow)dgvBangPhong_DatPhong.Rows[e.RowIndex];
            if (e.RowIndex >= 0 && e.RowIndex < dgvBangPhong_DatPhong.RowCount - 1)
            {
                txtTenKhach_DatPhong.Text = row.Cells[2].Value.ToString();
                dtpNgaySinh_DatPhong.Value = Convert.ToDateTime(row.Cells[3].Value);
                if (row.Cells[4].Value.ToString() == "Nam") rdoNam_DatPhong.Checked = true;
                else rdoNu_DatPhong.Checked = true;

                txtSDT_DatPhong.Text = row.Cells[5].Value.ToString();
                txtCMND_DatPhong.Text = row.Cells[6].Value.ToString();
                txtSoNguoiO_DatPhong.Text = row.Cells[7].Value.ToString();
                cboQuocTich_DatPhong.Text = row.Cells[8].Value.ToString();
                dtpNgayDen_DatPhong.Value = Convert.ToDateTime(row.Cells[9].Value);
                dtpNguoiDi_DatPhong.Value = Convert.ToDateTime(row.Cells[10].Value);
                txtTienDatCoc_DatPhong.Text = row.Cells[11].Value.ToString();
                txtTienPhaiTra_DatPhong.Text = row.Cells[12].Value.ToString();
            }
            else { }
        }

        private void btnSuaThongTin_DatPhong_Click(object sender, EventArgs e)
        {
            trangthai("Sua");
        }

        private void btnHuyDat_DatPhong_Click(object sender, EventArgs e)
        {
            trangthai("Huy");

            DialogResult result = MessageBox.Show(
                    "Bạn có chắc chắn muốn hủy?",
                    "Thông báo",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

            if (result == DialogResult.Yes)
            {
                if (datPhong.xoaThongTinDatPhong(txtCMND_DatPhong.Text, tenphong))
                {
                    dgvBangPhong_DatPhong.DataSource = datPhong.thongTinDatPhong(tenphong);
                }
                else
                {
                    MessageBox.Show("Lỗi xóa thông tin đặt phòng!");
                }
            }
        }

        private void txtTienDatCoc_DatPhong_TextChanged(object sender, EventArgs e)
        {
            double tiendatcoc = 0.0;
            if (String.IsNullOrEmpty(txtTienDatCoc_DatPhong.Text) || !Double.TryParse(txtTienDatCoc_DatPhong.Text, out tiendatcoc))
            {
                txtTienDatCoc_DatPhong.ForeColor = Color.Red;
                txtTienPhaiTra_DatPhong.Text = "0";
            }
            else
            {
                txtTienDatCoc_DatPhong.ForeColor = Color.Black;
                tiendatcoc = Convert.ToDouble(txtTienDatCoc_DatPhong.Text);
                double tienconlai = Convert.ToDouble(txtGiaPhong_DatPhong.Text) - tiendatcoc;
                txtTienPhaiTra_DatPhong.Text = tienconlai.ToString();
            }
        }

        private void dtpNguoiDi_DatPhong_ValueChanged(object sender, EventArgs e)
        {
            songayo = dtpNguoiDi_DatPhong.Value.DayOfYear - dtpNgayDen_DatPhong.Value.DayOfYear + 1;
            giaphong = datPhong.giaphong(tenphong) * songayo;
            txtGiaPhong_DatPhong.Text = giaphong.ToString();
            tiencoc = giaphong * 0.5;
            txtTienCoc_DatPhong.Text = tiencoc.ToString();
        }

        private bool KiemTraSDT()
        {
            if (String.IsNullOrEmpty(txtSDT_DatPhong.Text)) return true;

            string sdt = txtSDT_DatPhong.Text;
            for(int i = 0; i < sdt.Length; ++i)
            {
                if (sdt[i] < '0' || sdt[i] > '9')
                    return false;
            }
            return true;
        }

        private void txtSDT_DatPhong_TextChanged(object sender, EventArgs e)
        {
            if (!KiemTraSDT()) txtSDT_DatPhong.ForeColor = Color.Red;
            else txtSDT_DatPhong.ForeColor = Color.Black;
        }

        private bool KiemTraSoNguoiO()
        {
            if (String.IsNullOrEmpty(txtSoNguoiO_DatPhong.Text)) return true;
                
            string songuoio = txtSoNguoiO_DatPhong.Text;
            for (int i = 0; i < songuoio.Length; ++i)
            {
                if (songuoio[i] < '0' || songuoio[i] > '9')
                    return false;
            }
            return Convert.ToInt32(songuoio) >= 1 && Convert.ToInt32(songuoio) <= songuoitoda;
        }

        private void txtSoNguoiO_DatPhong_TextChanged(object sender, EventArgs e)
        {
            if (!KiemTraSoNguoiO()) txtSoNguoiO_DatPhong.ForeColor = Color.Red;
            else txtSoNguoiO_DatPhong.ForeColor = Color.Black;
        }

        private void btnReset_DatPhong_Click(object sender, EventArgs e)
        {
            trangthai("Them");
            txtTenKhach_DatPhong.Text = "";
            dtpNgaySinh_DatPhong.Value = DateTime.Now;
            dtpNgayDen_DatPhong.Value = DateTime.Now;
            dtpNguoiDi_DatPhong.Value = DateTime.Now;
            txtSoNguoiO_DatPhong.Text = "";
            txtSDT_DatPhong.Text = "";
            rdoNam_DatPhong.Checked = true;
            rdoNu_DatPhong.Checked = false;
            txtCMND_DatPhong.Text = "";
            cboQuocTich_DatPhong.SelectedItem = "Việt Nam (Vietnam)";
            txtTienDatCoc_DatPhong.Text = "";
        }

        private void btnLuu_DatPhong_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                    "Bạn có chắc chắn muốn lưu?",
                    "Thông báo",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

            if (!KiemTraThongTin())
            {
                MessageBox.Show("Thông tin thiếu hoặc định dạng sai!");
                return;
            }

            if (!kiemtraTienDatCoc())
            {
                MessageBox.Show("Tien coc khong du!");
                return;
            }

            ThongTinDatPhong thongTinDatPhong = TaoThongTinDatPhong();
            if (result == DialogResult.Yes)
            {
                if (datPhong.suaThongTinDatPhong(thongTinDatPhong, tenphong))
                {
                    dgvBangPhong_DatPhong.DataSource = datPhong.thongTinDatPhong(tenphong);
                }
                else
                {
                    MessageBox.Show("Lỗi sửa thông tin phòng!");
                }
            }
        }


    }
}