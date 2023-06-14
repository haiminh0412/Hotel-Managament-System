using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Management_System_Winforrm
{
    class QuanLyTraPhong
    {
        private string tenphong;
        private string loaiphong;
        private string tenkhachhang;
        private DateTime ngaysinh;
        private string gioitinh;
        private string sodienthoai;
        private string cmnd;
        private int songuoio;
        private string quoctich;
        private DateTime ngayden;
        private DateTime ngaydi;
        private float tienphong;


        public QuanLyTraPhong() { }

        public QuanLyTraPhong(string tenphong, string loaiphong, string tenkhachhang, DateTime ngaysinh, string gioitinh, string sodienthoai, string cmnd, int songuoio, string quoctich, DateTime ngayden, DateTime ngaydi, float tienphong)
        {
            this.tenphong = tenphong;
            this.loaiphong = loaiphong;
            this.tenkhachhang = tenkhachhang;
            this.ngaysinh = ngaysinh;
            this.gioitinh = gioitinh;
            this.sodienthoai = sodienthoai;
            this.cmnd = cmnd;
            this.songuoio = songuoio;
            this.quoctich = quoctich;
            this.ngayden = ngayden;
            this.ngaydi = ngaydi;
            this.tienphong = tienphong;
        }

        public string Tenphong { get => tenphong; set => tenphong = value; }
        public string Loaiphong { get => loaiphong; set => loaiphong = value; }
        public string Tenkhachhang { get => tenkhachhang; set => tenkhachhang = value; }
        public DateTime Ngaysinh { get => ngaysinh; set => ngaysinh = value; }
        public string Gioitinh { get => gioitinh; set => gioitinh = value; }
        public string Sodienthoai { get => sodienthoai; set => sodienthoai = value; }
        public string Cmnd { get => cmnd; set => cmnd = value; }
        public int Songuoio { get => songuoio; set => songuoio = value; }
        public string Quoctich { get => quoctich; set => quoctich = value; }
        public DateTime Ngayden { get => ngayden; set => ngayden = value; }
        public DateTime Ngaydi { get => ngaydi; set => ngaydi = value; }
        public float Tienphong { get => tienphong; set => tienphong = value; }
    }
}