using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Bot
{
    class Calisma
    {
        public bool AlanBelirlenecekMi;
        private int baslangic_x;
        private int baslangic_y;
        private int son_x;
        private int son_y;

        public Calisma()
        {
            baslangic_x = 0;
            baslangic_y = 0;
            son_x = 0;
            son_y = 0;
            AlanBelirlenecekMi = false;
        }
        public void setBas_x(int bas_x)
        {
            baslangic_x = bas_x;
        }
        public void setBas_y(int bas_y)
        {
            baslangic_y = bas_y;
        }
        public void setSon_x(int son_x)
        {
            this.son_x = son_x;
        }
        public void setSon_y(int son_y)
        {
            this.son_y = son_y;
        }
    }
}
