using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Management_System_Winforrm
{
    class NhanVien
    {
        private string manhanvien;
        private string tennhanvien;
        private DateTime ngaysinh;
        private string gioitinh;
        private string sodienthoai;
        private string cmmnd;
        private string email;
        private Account taikhoan;

        public NhanVien(string manhanvien, string tennhanvien, DateTime ngaysinh, string gioitinh, string sodienthoai, string cmmnd, string email)
        {
            this.manhanvien = manhanvien;
            this.tennhanvien = tennhanvien;
            this.ngaysinh = ngaysinh;
            this.gioitinh = gioitinh;
            this.sodienthoai = sodienthoai;
            this.cmmnd = cmmnd;
            this.email = email;
        }

        public string Manhanvien { get => manhanvien; set => manhanvien = value; }
        public string Tennhanvien { get => tennhanvien; set => tennhanvien = value; }
        public DateTime Ngaysinh { get => ngaysinh; set => ngaysinh = value; }
        public string Gioitinh { get => gioitinh; set => gioitinh = value; }
        public string Sodienthoai { get => sodienthoai; set => sodienthoai = value; }
        public string Cmmnd { get => cmmnd; set => cmmnd = value; }
        public string Email { get => email; set => email = value; }
        internal Account Taikhoan { get => taikhoan; set => taikhoan = value; }
    }
}