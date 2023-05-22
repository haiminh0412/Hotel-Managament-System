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
    public partial class FrmQuanLyNhanVien : Form
    {
        private QuanLyNhanVien quanLyNhanVien;

        public FrmQuanLyNhanVien()
        {
            InitializeComponent();
            quanLyNhanVien = new QuanLyNhanVien();
        }

        private void TrangThai(String s)
        {
            switch(s)
            {
                case "Mac Dinh":
                    btnThem_QLNV.Enabled = true;
                    btnSua_QLNV.Enabled = false;
                    btnLuu_QLNV.Enabled = false;
                    btnXoa_QLNV.Enabled = false;
                    btnReset_QLNV.Enabled = true;

                    txtMaNhanVien_QLNV.Enabled = true;
                    txtTenNhanVien__QLNV.Enabled = true;
                    dtpNgaySinh_QLNV.Enabled = true;
                    rdoNam_QLNV.Enabled = true;
                    rdoNu_QLNV.Enabled = true;
                    txtCCCD_QLNV.Enabled = true;
                    txtEmail_QLNV.Enabled = true;
                    txtSDT_QLNV.Enabled = true;
                    break;
                case "Edit":
                    btnThem_QLNV.Enabled = false;
                    btnSua_QLNV.Enabled = true;
                    btnLuu_QLNV.Enabled = false;
                    btnXoa_QLNV.Enabled = true;
                    btnReset_QLNV.Enabled = false;

                    txtMaNhanVien_QLNV.Enabled = false;
                    txtTenNhanVien__QLNV.Enabled = false;
                    dtpNgaySinh_QLNV.Enabled = false;
                    rdoNam_QLNV.Enabled = false;
                    rdoNu_QLNV.Enabled = false;
                    txtCCCD_QLNV.Enabled = false;
                    txtEmail_QLNV.Enabled = false;
                    txtSDT_QLNV.Enabled = false;
                    break;

                case "Xoa":
                    btnThem_QLNV.Enabled = false;
                    btnSua_QLNV.Enabled = false;
                    btnLuu_QLNV.Enabled = false;
                    btnXoa_QLNV.Enabled = true;
                    btnReset_QLNV.Enabled = false;

                    txtMaNhanVien_QLNV.Enabled = false;
                    txtTenNhanVien__QLNV.Enabled = false;
                    dtpNgaySinh_QLNV.Enabled = false;
                    rdoNam_QLNV.Enabled = false;
                    rdoNu_QLNV.Enabled = false;
                    txtCCCD_QLNV.Enabled = false;
                    txtEmail_QLNV.Enabled = false;
                    txtSDT_QLNV.Enabled = false;
                    break;

                case "Sua":
                    btnThem_QLNV.Enabled = false;
                    btnSua_QLNV.Enabled = true;
                    btnLuu_QLNV.Enabled = true;
                    btnXoa_QLNV.Enabled = false;
                    btnReset_QLNV.Enabled = false;

                    txtMaNhanVien_QLNV.Enabled = false;
                    txtTenNhanVien__QLNV.Enabled = true;
                    dtpNgaySinh_QLNV.Enabled = true;
                    rdoNam_QLNV.Enabled = true;
                    rdoNu_QLNV.Enabled = true;
                    txtCCCD_QLNV.Enabled = true;
                    txtEmail_QLNV.Enabled = true;
                    txtSDT_QLNV.Enabled = true;
                    break;

                default:
                    break;
            }
        }

        private void FrmQuanLyNhanVien_Load(object sender, EventArgs e)
        {
            TrangThai("Mac Dinh");
            reset();
        }

        private void dgvThongTinNhanVien_Click(object sender, EventArgs e)
        {
            TrangThai("Edit");
        }

        private void BangNhanVien()
        {
            try
            {
                dgvThongTinNhanVien.DataSource = quanLyNhanVien.ThongTinNhanVien();
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
            txtMaNhanVien_QLNV.Text = "";
            txtTenNhanVien__QLNV.Text = "";
            dtpNgaySinh_QLNV.Value = DateTime.Now;
            rdoNam_QLNV.Checked = true;
            rdoNu_QLNV.Checked = false;
            txtCCCD_QLNV.Text = "";
            txtEmail_QLNV.Text = "";
            txtSDT_QLNV.Text = "";
            txtNhapTimKiem_QLNV.Text = "";
            cboTruongTK_QLNV.SelectedIndex = 0;
            BangNhanVien();
        }

        private void btnReset_QLNV_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void panel5_Click(object sender, EventArgs e)
        {
            reset();
            TrangThai("Mac Dinh");
        }

        private void panel4_Click(object sender, EventArgs e)
        {
            reset();
            TrangThai("Mac Dinh");
        }

        private void btnXoa_QLNV_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                    "Ban co chac chan muon xoa?",
                    "Thong bao",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                ); 
            
            if(result == DialogResult.Yes)
            {
                string manv = txtMaNhanVien_QLNV.Text;
                if(quanLyNhanVien.XoaNhanVien(manv))
                {
                    BangNhanVien();
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

        private void btnSua_QLNV_Click(object sender, EventArgs e)
        {
            TrangThai("Sua");
        }

        private NhanVien taoNhanVien()
        {
            string manhanvien = txtMaNhanVien_QLNV.Text;
            string ten = txtTenNhanVien__QLNV.Text;
            DateTime ngaysinh = Convert.ToDateTime(dtpNgaySinh_QLNV.Value);
            string gioitinh = rdoNam_QLNV.Checked ? "Nam" : "Nu";
            string sdt = txtSDT_QLNV.Text;
            string cmnd = txtCCCD_QLNV.Text;
            string email = txtEmail_QLNV.Text;
            NhanVien nhanvien = new NhanVien(manhanvien, ten, ngaysinh, gioitinh, sdt, cmnd, email);
            return nhanvien;
        }
        private void btnThem_QLNV_Click(object sender, EventArgs e)
        {
            NhanVien nhanvien = taoNhanVien();
            if(quanLyNhanVien.ThemNhanVien(nhanvien))
            {
                BangNhanVien();
            }
            else
            {
                MessageBox.Show(
                        "Them khong thanh cong!",
                        "Thong bao",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    ) ;
            }
        }

        private void dgvThongTinNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index < dgvThongTinNhanVien.RowCount - 1)
            {
                DataGridViewRow row = dgvThongTinNhanVien.Rows[index];
                txtMaNhanVien_QLNV.Text = row.Cells[0].Value.ToString();
                txtTenNhanVien__QLNV.Text = row.Cells[1].Value.ToString();
                dtpNgaySinh_QLNV.Value = Convert.ToDateTime(row.Cells[2].Value);
                string gioitinh = row.Cells[3].Value.ToString();
                if (gioitinh == "Nam") rdoNam_QLNV.Checked = true;
                else rdoNu_QLNV.Checked = true;
                txtSDT_QLNV.Text = row.Cells[4].Value.ToString();
                txtCCCD_QLNV.Text = row.Cells[5].Value.ToString();
                txtEmail_QLNV.Text = row.Cells[6].Value.ToString();
            }
        }

        private void btnLuu_QLNV_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                   "Ban co chac chan muon luu?",
                   "Thong bao",
                   MessageBoxButtons.YesNo,
                   MessageBoxIcon.Question
               );
            if(result == DialogResult.Yes)
            {
                NhanVien nhanvien = taoNhanVien();
                if (quanLyNhanVien.SuaNhanVien(nhanvien))
                {
                    BangNhanVien();
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

        private void btnTim_QLNV_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboTruongTK_QLNV.SelectedItem.ToString() == "")
                {
                    BangNhanVien();
                }
                else
                {
                    try
                    {
                        dgvThongTinNhanVien.DataSource = quanLyNhanVien.TimKiem(cboTruongTK_QLNV.SelectedItem.ToString(), txtNhapTimKiem_QLNV.Text);
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

        private void cboTruongTK_QLNV_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtNhapTimKiem_QLNV.Text = "";
        }
    }
}