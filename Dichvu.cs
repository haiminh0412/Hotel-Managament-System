using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Management_System_Winforrm
{
    class Dichvu
    {
        private string madichvu;
        private string tendichvu;
        private string loaidichvu;
        private int soluong;
        private float gia;

        public Dichvu(string madichvu, string tendichvu, string loaidichvu, int soluong, float gia)
        {
            this.madichvu = madichvu;
            this.tendichvu = tendichvu;
            this.loaidichvu = loaidichvu;
            this.soluong = soluong;
            this.gia = gia;
        }

        public string Madichvu { get => madichvu; set => madichvu = value; }
        public string Tendichvu { get => tendichvu; set => tendichvu = value; }
        public string Loaidichvu { get => loaidichvu; set => loaidichvu = value; }
        public int Soluong { get => soluong; set => soluong = value; }
        public float Gia { get => gia; set => gia = value; }
    }
}
