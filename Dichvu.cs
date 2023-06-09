using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Management_System_Winforrm
{
    class Dichvu
    {
        private string tendichvu;
        private string loaidichvu;
        private int soluong;
        private float gia;

        public Dichvu() {
            this.tendichvu = "";
            this.loaidichvu = "";
            this.soluong = 0;
            this.gia = 0.0f;
        }

        public Dichvu(string tendichvu, string loaidichvu, int soluong, float gia)
        {
            this.tendichvu = tendichvu;
            this.loaidichvu = loaidichvu;
            this.soluong = soluong;
            this.gia = gia;
        }

        public string Tendichvu { get => tendichvu; set => tendichvu = value; }
        public string Loaidichvu { get => loaidichvu; set => loaidichvu = value; }
        public int Soluong { get => soluong; set => soluong = value; }
        public float Gia { get => gia; set => gia = value; }
    }
}
