using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Hotel_Management_System_Winforrm
{
    public partial class FrmSignUp : Form
    {
        FrmLogin frmLogin;
        Account tk;
        public FrmSignUp()
        {
            InitializeComponent();
            frmLogin = new FrmLogin();
        }

        private void lkLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            frmLogin.ShowDialog();
        }

        private void FrmSignUp_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmLogin.Show();
        }
        public bool checkAccount(string check)
        {
            return Regex.IsMatch(check, "^[a-z A-Z 0-9]{6,24}$");
        }
        public bool checkSdt(string check)
        {
            return Regex.IsMatch(check, "^[0-9]{0,10}$");
        }

        public bool checkPassword(string check)
        {
            return Regex.IsMatch(check, "^[a-zA-Z0-9.!@#$%^&*(),.?\":{}|<> ]{6,24}$");
        }
        QuanLyTaiKhoan ql = new QuanLyTaiKhoan();
        private void btnSignUp_Click(object sender, EventArgs e)
        {
            string tenTk = txtUserName.Text;
            string mk = txtPassword.Text;
            string tenLeTan = txtName.Text;
            DateTime ngaysinh = dtpBirthDay.Value;

            string gioitinh = (rdoFemale.Checked ? rdoFemale.Text : rdoMale.Text);
            string sdt = txtPhone.Text;
            if (!checkPassword(mk))
            {
                MessageBox.Show("Vui Lòng Nhập Đúng Thông Tin Yêu Cầu Dộ Dài 6-24 Kí Tự", "Cảnh Báo Sai Thông Tin", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return;
            }
            if (!checkSdt(sdt))
            {
                MessageBox.Show("Vui Lòng Nhập Đúng Thông Tin Yêu Cầu Dộ Dài Và Không Chứa Những Chữ Cái Đặc Biệt", "Cảnh Báo Sai Thông Tin", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return;
            }
            if (!checkAccount(tenTk))
            {
                MessageBox.Show("Vui Lòng Nhập Đúng Thông Tin Yêu Cầu Dộ Dài 6-24 Kí Tự Và Không Chứa Những Chữ Cái Đặc Biệt", "Cảnh Báo Sai Thông Tin", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return;
            }
            if (txtConfirmPassword.Text != mk)
            {
                MessageBox.Show("Vui Lòng Nhập Đúng Mật Khẩu", "Cảnh Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            }
            if (ql.Account("Select * from DangNhap where sdt = '" + sdt + "'").Count() != 0)
            {
                MessageBox.Show("Số Điện Thoại Đã Được Đăng Kí Vui Lòng Đăng Kí Số Khác", "Cảnh Báo Đăng Nhập", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return;
            }
            if (!checkSdt(sdt))
            {
                MessageBox.Show("Vui Lòng Nhập Đúng Thông Tin Yêu Cầu Dộ Dài  Không Chứa Những Chữ Cái Đặc Biệt", "Cảnh Báo Sai Thông Tin", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return;
            }
            tk = new Account(tenTk, mk, tenLeTan, sdt, ngaysinh, gioitinh);
            if (ql.insert(tk))
            {
                MessageBox.Show("Thành Công");
            }
            else
            {
                MessageBox.Show("Thất Bại");
            }

        }

        private void FrmSignUp_Load(object sender, EventArgs e)
        {

        }
    }
}
