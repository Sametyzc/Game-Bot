using Emgu.CV;
using Emgu.CV.Structure;
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
        public bool FotografCekilecekMi;
        public int baslangic_x;
        public int baslangic_y;
        public int son_x;
        public int son_y;
        public int kutu_x;
        public int kutu_y;
        public Bitmap alaninResmi;
        public Bitmap kutuResmi;



        ///////////////////////////////////////////////////
        public Calisma()
        {
            baslangic_x = 0;
            baslangic_y = 0;
            son_x = 0;
            son_y = 0;
            FotografCekilecekMi = false;
            alaninResmi = null;
            kutuResmi = (Bitmap)Image.FromFile("Resimler/kutu1.png");
        }
        public bool Kutu_Bul()
        {
            Image<Bgr, byte> kaynak = new Image<Bgr, byte>(alaninResmi);
            Image<Bgr, byte> nesne = new Image<Bgr, byte>(kutuResmi); //Aranan Nesne

            //Template Matching MatchTemplate ile uygulanmaktadır.
            using (Image<Gray, float> result = kaynak.MatchTemplate(nesne, Emgu.CV.CvEnum.TemplateMatchingType.CcoeffNormed))
            {
                double[] minValues, maxValues;
                Point[] minLocations, maxLocations;
                result.MinMax(out minValues, out maxValues, out minLocations, out maxLocations);

                //Benzerlik eşiği. İdeal olanı siz seçeceksiniz.
                if (maxValues[0] > 0.8)
                {
                    kutu_x = (minLocations[0].X + maxLocations[0].X) / 2 + baslangic_x;
                    kutu_y = (minLocations[0].Y + maxLocations[0].Y) / 2 + baslangic_y;
                    return true;
                }
            }
            return false;
        }
    }
}
