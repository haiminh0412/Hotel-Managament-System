 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Management_System_Winforrm
{
    class Phong
    {
        private string tenphong;
        private string loaiphong;
        private string motaphong;
        private int songuoitoida;
        private string trangthai;
        private double giaphong;

        public Phong(string tenphong, string loaiphong, string motaphong, int songuoitoida, string trangthai, double giaphong)
        {
            this.tenphong = tenphong;
            this.loaiphong = loaiphong;
            this.motaphong = motaphong;
            this.songuoitoida = songuoitoida;
            this.trangthai = trangthai;
            this.giaphong = giaphong;
        }

        public string Tenphong { get => tenphong; set => tenphong = value; }
        public string Loaiphong { get => loaiphong; set => loaiphong = value; }
        public string Motaphong { get => motaphong; set => motaphong = value; }
        public int Songuoitoida { get => songuoitoida; set => songuoitoida = value; }
        public string Trangthai { get => trangthai; set => trangthai = value; }
        public double Giaphong { get => giaphong; set => giaphong = value; }
    }
}