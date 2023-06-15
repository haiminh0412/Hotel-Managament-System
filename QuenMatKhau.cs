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
    public partial class QuenMatKhau : Form
    {
        public QuenMatKhau()
        {
            InitializeComponent();
        }
        QuanLyTaiKhoan ql = new QuanLyTaiKhoan();
        private void btn_RePass_Click(object sender, EventArgs e)
        {
            string sdt = txtRePassWord.Text;
            if (sdt == String.Empty)
            {
                MessageBox.Show("Vui Lòng Nhập Sdt", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            else
            {
                string query = "select * from DangNhap  where sdt = '" + sdt + "'";
                if (ql.Account(query).Count != 0)
                {
                    label3.Text = "Tên Tài Khoản: " + ql.Account(query)[0].Tentaikhoan + " Mật Khẩu: " + ql.Account(query)[0].Matkhau;
                }
                else
                {
                    MessageBox.Show("Số Điện Thoại Này Không Tồn Tại Trong Hệ Thống");
                }
            }
        }

        private void QuenMatKhau_Load(object sender, EventArgs e)
        {

        }
    }
}
