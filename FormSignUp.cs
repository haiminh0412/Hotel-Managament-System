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
    public partial class FrmSignUp : Form
    {
        FrmLogin frmLogin;
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
    }
}
