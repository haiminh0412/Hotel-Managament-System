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

        private void btnLogin_Click(object sender, EventArgs e)
        {
            HotelManagement hotelManagement = new HotelManagement();
            this.Hide();
            hotelManagement.Show();
        }
    }
}
