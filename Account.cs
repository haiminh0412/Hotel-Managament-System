using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Hotel_Management_System_Winforrm
{
    class Account
    {
        private string taikhoan;
        private string matkhau;
        private int phanquyen;
        private int trangthai;

        public Account(string taikhoan, string matkhau, int phanquyen, int trangthai)
        {
            this.taikhoan = taikhoan;
            this.matkhau = matkhau;
            this.phanquyen = phanquyen;
            this.trangthai = trangthai;
        }

        public string Taikhoan { get => taikhoan; set => taikhoan = value; }
        public string Matkhau { get => matkhau; set => matkhau = value; }
        public int Phanquyen { get => phanquyen; set => phanquyen = value; }
        public int Trangthai { get => trangthai; set => trangthai = value; }
    }
}
