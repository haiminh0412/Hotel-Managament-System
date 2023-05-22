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
    public partial class FrmQuanLyKhachHang : Form
    {
        private QuanLyKhachHang quanLyKhachHang;
        public FrmQuanLyKhachHang()
        {
            InitializeComponent();
            quanLyKhachHang = new QuanLyKhachHang();
        }

        private void TrangThai(String s)
        {
            switch (s)
            {
                case "Mac Dinh":
                    btnThem_QLKH.Enabled = true;
                    btnSua_QLKH.Enabled = false;
                    btnLuu_QLKH.Enabled = false;
                    btnXoa_QLKH.Enabled = false;
                    btnReset_QLKH.Enabled = true;

                    txtMaKH_QLKH.Enabled = true;
                    txtTenKH_QLKH.Enabled = true;
                    dtpNgaySinh_QLKH.Enabled = true;
                    rdoNam_QLKH.Enabled = true;
                    rdoNu_QLKH.Enabled = true;
                    txtCCCD_QLKH.Enabled = true;
                    txtEmail_QLKH.Enabled = true;
                    txtSDT_QLKH.Enabled = true;
                    break;
                case "Edit":
                    btnThem_QLKH.Enabled = false;
                    btnSua_QLKH.Enabled = true;
                    btnLuu_QLKH.Enabled = false;
                    btnXoa_QLKH.Enabled = true;
                    btnReset_QLKH.Enabled = false;

                    txtMaKH_QLKH.Enabled = false;
                    txtTenKH_QLKH.Enabled = false;
                    dtpNgaySinh_QLKH.Enabled = false;
                    rdoNam_QLKH.Enabled = false;
                    rdoNu_QLKH.Enabled = false;
                    txtCCCD_QLKH.Enabled = false;
                    txtEmail_QLKH.Enabled = false;
                    txtSDT_QLKH.Enabled = false;
                    break;

                case "Xoa":
                    btnThem_QLKH.Enabled = false;
                    btnSua_QLKH.Enabled = false;
                    btnLuu_QLKH.Enabled = false;
                    btnXoa_QLKH.Enabled = true;
                    btnReset_QLKH.Enabled = false;

                    txtMaKH_QLKH.Enabled = false;
                    txtTenKH_QLKH.Enabled = false;
                    dtpNgaySinh_QLKH.Enabled = false;
                    rdoNam_QLKH.Enabled = false;
                    rdoNu_QLKH.Enabled = false;
                    txtCCCD_QLKH.Enabled = false;
                    txtEmail_QLKH.Enabled = false;
                    txtSDT_QLKH.Enabled = false;
                    break;

                case "Sua":
                    btnThem_QLKH.Enabled = false;
                    btnSua_QLKH.Enabled = true;
                    btnLuu_QLKH.Enabled = true;
                    btnXoa_QLKH.Enabled = false;
                    btnReset_QLKH.Enabled = false;

                    txtMaKH_QLKH.Enabled = false;
                    txtTenKH_QLKH.Enabled = true;
                    dtpNgaySinh_QLKH.Enabled = true;
                    rdoNam_QLKH.Enabled = true;
                    rdoNu_QLKH.Enabled = true;
                    txtCCCD_QLKH.Enabled = true;
                    txtEmail_QLKH.Enabled = true;
                    txtSDT_QLKH.Enabled = true;
                    break;

                default:
                    break;
            }
        }

        private void BangKhachHang()
        {
            try
            {
                dgvThongTinKhachHang.DataSource = quanLyKhachHang.ThongTinKhachHang();
            }
            catch
            {
                MessageBox.Show(
                        "Loi hien thi!",
                        "Loi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
            }
        }
        private void reset()
        {
            txtMaKH_QLKH.Text = "";
            txtTenKH_QLKH.Text = "";
            dtpNgaySinh_QLKH.Value = DateTime.Now;
            rdoNam_QLKH.Checked = true;
            rdoNu_QLKH.Checked = false;
            txtCCCD_QLKH.Text = "";
            txtEmail_QLKH.Text = "";
            txtSDT_QLKH.Text = "";
            txtNhapTimKiem_QLKH.Text = "";
            cboTruongTimKiem_QLKH.SelectedIndex = 0;
            BangKhachHang();
        }
        private void FrmQuanLyKhachHang_Load(object sender, EventArgs e)
        {
            TrangThai("Mac Dinh");
            reset();
        }

        private void btnReset_QLKH_Click(object sender, EventArgs e)
        {
            reset();
        }

        private KhachHang taoKhachHang()
        {
            string manhanvien = txtMaKH_QLKH.Text;
            string ten = txtTenKH_QLKH.Text;
            DateTime ngaysinh = Convert.ToDateTime(dtpNgaySinh_QLKH.Value);
            string gioitinh = rdoNam_QLKH.Checked ? "Nam" : "Nu";
            string sdt = txtSDT_QLKH.Text;
            string cmnd = txtCCCD_QLKH.Text;
            string email = txtEmail_QLKH.Text;
            KhachHang khachang = new KhachHang(manhanvien, ten, ngaysinh, gioitinh, sdt, cmnd, email);
            return khachang;
        }

        private void btnThem_QLKH_Click(object sender, EventArgs e)
        {
            KhachHang khachHang = taoKhachHang();
            if (quanLyKhachHang.ThemNhanVien(khachHang))
            {
                BangKhachHang();
            }
            else
            {
                MessageBox.Show(
                        "Them khong thanh cong!",
                        "Thong bao",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
            }
        }

        private void btnSua_QLKH_Click(object sender, EventArgs e)
        {
            TrangThai("Sua");
        }

        private void btnLuu_QLKH_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                  "Ban co chac chan muon luu?",
                  "Thong bao",
                  MessageBoxButtons.YesNo,
                  MessageBoxIcon.Question
              );
            if (result == DialogResult.Yes)
            {
                KhachHang khachHang = taoKhachHang();
                if (quanLyKhachHang.SuaKhachHang(khachHang))
                {
                    BangKhachHang();
                }
                else
                {
                    MessageBox.Show(
                     "Luu khong thanh cong!",
                     "Thong bao",
                     MessageBoxButtons.OK,
                     MessageBoxIcon.Information
                    );
                }
                TrangThai("Edit");
            }
        }

        private void btnXoa_QLKH_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                    "Ban co chac chan muon xoa?",
                    "Thong bao",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

            if (result == DialogResult.Yes)
            {
                string makh = txtMaKH_QLKH.Text;
                if (quanLyKhachHang.XoaKhachHang(makh))
                {
                    BangKhachHang();
                }
                else
                {
                    MessageBox.Show(
                      "Xoa khong thanh cong!",
                      "Thong bao",
                      MessageBoxButtons.OK,
                      MessageBoxIcon.Information
                  );
                }
            }
            TrangThai("Edit");
        }

        private void btnTim_QLKH_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboTruongTimKiem_QLKH.SelectedItem.ToString() == "")
                {
                    BangKhachHang();
                }
                else
                {
                    try
                    {
                        dgvThongTinKhachHang.DataSource = quanLyKhachHang.TimKiem(cboTruongTimKiem_QLKH.SelectedItem.ToString(), txtNhapTimKiem_QLKH.Text);
                    }
                    catch
                    {
                        MessageBox.Show("Error!");
                    }
                }
            }
            catch
            {
                MessageBox.Show(
                    "Loi tim kiem!",
                    "Loi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                   );
            }
        }

        private void panel8_Click(object sender, EventArgs e)
        {
            reset();
            TrangThai("Mac Dinh");
        }

        private void panel7_Click(object sender, EventArgs e)
        {
            reset();
            TrangThai("Mac Dinh");
        }

        private void dgvThongTinKhachHang_Click(object sender, EventArgs e)
        {
            TrangThai("Edit");
        }

        private void dgvThongTinKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index < dgvThongTinKhachHang.RowCount - 1)
            {
                DataGridViewRow row = dgvThongTinKhachHang.Rows[index];
                txtMaKH_QLKH.Text = row.Cells[0].Value.ToString();
                txtTenKH_QLKH.Text = row.Cells[1].Value.ToString();
                dtpNgaySinh_QLKH.Value = Convert.ToDateTime(row.Cells[2].Value);
                string gioitinh = row.Cells[3].Value.ToString();
                if (gioitinh == "Nam") rdoNam_QLKH.Checked = true;
                else rdoNu_QLKH.Checked = true;
                txtSDT_QLKH.Text = row.Cells[4].Value.ToString();
                txtCCCD_QLKH.Text = row.Cells[5].Value.ToString();
                txtEmail_QLKH.Text = row.Cells[6].Value.ToString();
            }
        }

        private void cboTruongTimKiem_QLKH_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtNhapTimKiem_QLKH.Text = "";
        }
    }
}
