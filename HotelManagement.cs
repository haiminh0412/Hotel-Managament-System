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
    public partial class HotelManagement : Form
    {
      
        public HotelManagement()
        {
            InitializeComponent();
        }

        private void quảnLýThuêPhòngToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void càiĐặtToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
          
        }

        private void dgvThongTinNhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void HotelManagement_Load(object sender, EventArgs e)
        {
          
        }

        private void tabQLNV_Click(object sender, EventArgs e)
        {
            
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmLogin frmLogin = new FrmLogin();
            this.Close();
            frmLogin.Show();
        }

        private void quảnLýNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmQuanLyNhanVien frmQuanLyNhanVien = new FrmQuanLyNhanVien();
            frmQuanLyNhanVien.Show();
        }

        private void quảnLýKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmQuanLyKhachHang frmQuanLyKhachHang = new FrmQuanLyKhachHang();
            frmQuanLyKhachHang.Show();
        }
    }
}
