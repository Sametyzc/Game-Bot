using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Bot
{
    class Calisma
    {
        private const int V = 0;
        public bool FotografCekilecekMi;
        public int baslangic_x;
        public int baslangic_y;
        public int son_x;
        public int son_y;
        public Bitmap alaninResmi;

        public Calisma()
        {
            baslangic_x = 0;
            baslangic_y = 0;
            son_x = 0;
            son_y = 0;
            FotografCekilecekMi = false;
            alaninResmi = null;
        }
  
    }
}
