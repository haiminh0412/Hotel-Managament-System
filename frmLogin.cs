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
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            txtUerName.Focus();
        }

        private void txtUerName_Click(object sender, EventArgs e)
        {
            txtUerName.Text = "";
            txtUerName.ForeColor = Color.Black;
        }

        private void lklblSignUp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmSignUp frmSignUp = new FrmSignUp();
            this.Hide();
            frmSignUp.ShowDialog();
        }
        private void login()
        {
            HotelManagement hotelManagement = new HotelManagement();
            this.Hide();
            hotelManagement.Show();
        }
        QuanLyTaiKhoan qltk = new QuanLyTaiKhoan();

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string tentk = txtUerName.Text;
            string mk = txtPassword.Text;
            if (tentk == String.Empty || mk == String.Empty)
            {
                MessageBox.Show("Vui Lòng Nhập Đầy Đủ Thông Tin", "Cảnh Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning); return;
            }
            else
            {
                string query = "select * from DangNhap where taikhoan = '" + tentk + "' and matkhau = '" + mk + "'";
                if (qltk.Account(query).Count > 0)
                {
                    MessageBox.Show("Đăng Nhập Thành Công", "", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    login();
                }
                else
                {
                    MessageBox.Show("Tên tài khoản hoặc mật khẩu không chính xác", "Cảnh Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                }
            }


        }
        private void lklblForgetPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            QuenMatKhau ql = new QuenMatKhau();
            ql.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmDoiMatKhau fr = new FrmDoiMatKhau();
            fr.Show();
        }
    }
}
