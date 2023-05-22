using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Management_System_Winforrm
{
    class Phong
    {
        private string maphong;
        private string tenphong;
        private string loaiphong;
        private string motaphong;
        private int songuoitoida;
        private string trangthai;

        public Phong(string maphong, string tenphong, string loaiphong, string motaphong, int songuoitoida, string trangthai)
        {
            this.maphong = maphong;
            this.tenphong = tenphong;
            this.loaiphong = loaiphong;
            this.motaphong = motaphong;
            this.songuoitoida = songuoitoida;
            this.trangthai = trangthai;
        }

        public string Maphong { get => maphong; set => maphong = value; }
        public string Tenphong { get => tenphong; set => tenphong = value; }
        public string Loaiphong { get => loaiphong; set => loaiphong = value; }
        public string Motaphong { get => motaphong; set => motaphong = value; }
        public int Songuoitoida { get => songuoitoida; set => songuoitoida = value; }
        public string Trangthai { get => trangthai; set => trangthai = value; }
    }
}
