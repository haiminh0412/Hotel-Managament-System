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
        private string tentaikhoan;
        private string matkhau;
        private string tennv;
        private string sdt;
        private DateTime ngaysinh;
        private string gioitinh;
        public string Tentaikhoan { get => tentaikhoan; set => tentaikhoan = value; }
        public string Matkhau { get => matkhau; set => matkhau = value; }

        public string Tennv { get => tennv; set => tennv = value; }
        public string Sdt { get => sdt; set => sdt = value; }
        public DateTime Ngaysinh { get => ngaysinh; set => ngaysinh = value; }
        public string Gioitinh { get => gioitinh; set => gioitinh = value; }

        public Account(string tentaikhoan, string matkhau)
        {
            this.Tentaikhoan = tentaikhoan;
            this.Matkhau = matkhau;
        }
        public Account() { }

        public Account(string tentaikhoan, string matkhau, string tennv, string sdt, DateTime ngaysinh, string gioitinh)
        {
            this.tentaikhoan = tentaikhoan;
            this.matkhau = matkhau;
            this.tennv = tennv;
            this.sdt = sdt;
            this.ngaysinh = ngaysinh;
            this.gioitinh = gioitinh;
        }
    }
}
