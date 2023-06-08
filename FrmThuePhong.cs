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
    public partial class FrmThuePhong : Form
    {
        private string tenphong;
        private double giaphong;
        private int songuoitoida;
        private int songayo;
        private string trangthai;
        private Button btnPhong;

        public FrmThuePhong(string tenphong, Button btnPhong)
        {
            InitializeComponent();
            this.tenphong = tenphong;
            this.btnPhong = btnPhong;
        }

        QLThuePhong qLThuePhong = new QLThuePhong();

        public string Trangthai { get => trangthai; set => trangthai = value; }

        private bool KiemTraThongTin()
        {
            return !String.IsNullOrEmpty(txtTenKhach_ThuePhong.Text) && !String.IsNullOrEmpty(txtSDT_ThuePhong.Text)
                && !String.IsNullOrEmpty(txtCMND_ThuePhong.Text) && !String.IsNullOrEmpty(txtSoNguoiO_ThuePhong.Text)
                && !String.IsNullOrEmpty(cboQuocTich_ThuePhong.Text)
                && txtTenKhach_ThuePhong.ForeColor == Color.Black && txtSDT_ThuePhong.ForeColor == Color.Black
                && txtSoNguoiO_ThuePhong.ForeColor == Color.Black;
        }

        public void macdinh()
        {
            trangthai = qLThuePhong.trangthai(tenphong);
            txtTenKhach_ThuePhong.Text = "";
            txtSDT_ThuePhong.Text = "";
            dtpNgaySinh_ThuePhong.Value = DateTime.Now;
            dtpNgayDen_ThuePhong.Value = DateTime.Now;
            dtpNguoiDi_ThuePhong.Value = DateTime.Now;
            txtSoNguoiO_ThuePhong.Text = "0";
            txtCMND_ThuePhong.Text = "";
            txtTienPhaiTra_ThuePhong.Text = txtGiaPhong_ThuePhong.Text;
            try
            {
                dgvBangPhong_ThuePhong.DataSource = qLThuePhong.thongTinNguoiThuePhong(tenphong);
                dgvThuePhong.DataSource = qLThuePhong.thongTinThuePhong(tenphong);
            }
            catch
            {
                MessageBox.Show("Lỗi hiển thị bảng");
            }
            cboQuocTich_ThuePhong.SelectedItem = "Việt Nam (Vietnam)";
            rdoNam_ThuePhong.Checked = true;
        }

       

        private ThuePhong TaoThongTinThuePhong()
        {
            string tenphonng = txtPhong_ThuePhong.Text;
            string loaiphong = txtLoaiPhong_ThuePhong.Text;
            string tenkhach = txtTenKhach_ThuePhong.Text;
            DateTime ngaysinh = Convert.ToDateTime(dtpNgaySinh_ThuePhong.Value);
            string gioitinh = rdoNam_ThuePhong.Checked ? "Nam" : "Nữ";
            string sodienthoai = txtSDT_ThuePhong.Text;
            string cmnd = txtCMND_ThuePhong.Text;
            int songuoio = Convert.ToInt32(txtSoNguoiO_ThuePhong.Text);
            string quoctich = cboQuocTich_ThuePhong.SelectedItem.ToString();
            DateTime ngayden = Convert.ToDateTime(dtpNgayDen_ThuePhong.Value);
            DateTime ngaydi = Convert.ToDateTime(dtpNguoiDi_ThuePhong.Value);
            double tienphaitra = Convert.ToDouble(txtTienPhaiTra_ThuePhong.Text);

            ThuePhong thuephong = new ThuePhong(tenphong, loaiphong, tenkhach, ngaysinh, gioitinh, sodienthoai,
                cmnd, songuoio, quoctich, ngayden, ngaydi, tienphaitra);
            return thuephong;
        }

        private bool KiemTraSDT()
        {
            if (String.IsNullOrEmpty(txtSDT_ThuePhong.Text)) return true;

            string sdt = txtSDT_ThuePhong.Text;
            for (int i = 0; i < sdt.Length; ++i)
            {
                if (sdt[i] < '0' || sdt[i] > '9')
                    return false;
            }
            return true;
        }

        private bool KiemTraSoNguoiO()
        {
            if (String.IsNullOrEmpty(txtSoNguoiO_ThuePhong.Text)) return true;

            string songuoio = txtSoNguoiO_ThuePhong.Text;
            for (int i = 0; i < songuoio.Length; ++i)
            {
                if (songuoio[i] < '0' || songuoio[i] > '9')
                    return false;
            }
            return Convert.ToInt32(songuoio) > 0 && Convert.ToInt32(songuoio) <= songuoitoida;
        }

        private void txtSDT_ThuePhong_TextChanged(object sender, EventArgs e)
        {
            if (!KiemTraSDT()) txtSDT_ThuePhong.ForeColor = Color.Red;
            else txtSDT_ThuePhong.ForeColor = Color.Black;
        }

        private void txtSoNguoiO_ThuePhong_TextChanged(object sender, EventArgs e)
        {
            if (!KiemTraSoNguoiO()) txtSoNguoiO_ThuePhong.ForeColor = Color.Red;
            else txtSoNguoiO_ThuePhong.ForeColor = Color.Black;
        }

        private void btnTimKiem_ThuePhong_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtCMND_ThuePhong.Text))
            {
                MessageBox.Show("Dien day du cmmd hoac hochieu!");
                return;
            }

            try
            {
                dgvBangPhong_ThuePhong.DataSource = qLThuePhong.timKiem(txtCMND_ThuePhong.Text, tenphong);
            }
            catch
            {
                MessageBox.Show("Lỗi tìm kiếm!");
            }
        }

        private void btnThuePhong_ThuePhong_Click(object sender, EventArgs e)
        {
            if (!KiemTraThongTin())
            {
                MessageBox.Show("Thông tin thiếu hoặc định dạng sai!");
                return;
            }

            ThuePhong thuePhong = TaoThongTinThuePhong();

            if(trangthai != "Trong")
            {
                MessageBox.Show("Phòng đang bảo trì hoặc đã có người ở");
                return;
            }

            if (qLThuePhong.thuephongchokhach(thuePhong))
            {
                dgvThuePhong.DataSource = qLThuePhong.thongTinThuePhong(tenphong);
                if (qLThuePhong.xoaThongTinDatPhong(thuePhong.Cmnd, tenphong)) dgvBangPhong_ThuePhong.DataSource = qLThuePhong.thongTinNguoiThuePhong(tenphong);
                qLThuePhong.capNhapTrangThai(tenphong);
                trangthai = "Co nguoi o";
                btnPhong.BackColor = Color.Red;
            }
            else
            {
                MessageBox.Show("Lỗi đặt phòng!");
            }
            macdinh();
        }

        private void dgvBangPhong_ThuePhong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = (DataGridViewRow)dgvBangPhong_ThuePhong.Rows[e.RowIndex];
            if (e.RowIndex >= 0 && e.RowIndex < dgvBangPhong_ThuePhong.RowCount - 1)
            {
                txtTenKhach_ThuePhong.Text = row.Cells[2].Value.ToString();
                dtpNgaySinh_ThuePhong.Value = Convert.ToDateTime(row.Cells[3].Value);
                if (row.Cells[4].Value.ToString() == "Nam") rdoNam_ThuePhong.Checked = true;
                else rdoNu_ThuePhong.Checked = true;

                txtSDT_ThuePhong.Text = row.Cells[5].Value.ToString();
                txtCMND_ThuePhong.Text = row.Cells[6].Value.ToString();
                txtSoNguoiO_ThuePhong.Text = row.Cells[7].Value.ToString();
                cboQuocTich_ThuePhong.Text = row.Cells[8].Value.ToString();
                dtpNgayDen_ThuePhong.Value = Convert.ToDateTime(row.Cells[9].Value);
                dtpNguoiDi_ThuePhong.Value = Convert.ToDateTime(row.Cells[10].Value);
                txtTienPhaiTra_ThuePhong.Text = row.Cells[12].Value.ToString();
            }
            else { }
        }

        private void dtpNguoiDi_ThuePhong_ValueChanged(object sender, EventArgs e)
        {
            songayo = dtpNguoiDi_ThuePhong.Value.DayOfYear - dtpNgayDen_ThuePhong.Value.DayOfYear + 1;
            giaphong = qLThuePhong.giaphong(tenphong) * songayo;
            txtGiaPhong_ThuePhong.Text = giaphong.ToString();
            txtTienPhaiTra_ThuePhong.Text = txtGiaPhong_ThuePhong.Text;
        }

        private void btnReset_ThuePhong_Click(object sender, EventArgs e)
        {
            macdinh();
        }

        private void FrmThuePhong_Load(object sender, EventArgs e)
        {
            txtPhong_ThuePhong.Text = tenphong;
            txtLoaiPhong_ThuePhong.Text = qLThuePhong.loaiphong(tenphong);
            giaphong = qLThuePhong.giaphong(tenphong);
            songuoitoida = qLThuePhong.songuoitoda(tenphong);
            txtGiaPhong_ThuePhong.Text = giaphong.ToString();
            macdinh();
        }
    }
}
