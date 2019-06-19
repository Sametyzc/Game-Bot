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
        public bool FotografCekilecekMi, kutuBulunduMu,haritaVarMi;
        public int baslangic_x;
        public int baslangic_y;
        public int son_x;
        public int son_y;
        public int kutu_x;
        public int kutu_y;
        public Point haritaYeri;
        public Bitmap alaninResmi;
        public Bitmap kutuResmi;
        public Bitmap haritaResmi;
        public Bitmap isaretResmi;
        public Image<Bgr, byte> kaynak;
        public Image<Bgr, byte> aranan;
        public Random r;
        public Point Tiklama_Yeri;
        ///////////////////////////////////////////////////
        public Calisma()
        {
            baslangic_x = 0;
            baslangic_y = 0;
            son_x = 0;
            son_y = 0;
            kutu_x = 0;
            kutu_y = 0;
            FotografCekilecekMi = false;
            kutuBulunduMu = false;
            haritaVarMi = false;
            alaninResmi = null;
            r = new Random();
            Tiklama_Yeri = new Point();
            kutuResmi = (Bitmap)Image.FromFile("Resimler/kutu1.png");
            haritaResmi = (Bitmap)Image.FromFile("Resimler/Harita.png");
            isaretResmi = (Bitmap)Image.FromFile("Resimler/isaret.png");
        }
        public bool Kutu_Bul()
        {
            kaynak = new Image<Bgr, byte>(alaninResmi);
            aranan = new Image<Bgr, byte>(kutuResmi);

            using (Image<Gray, float> sonuc = kaynak.MatchTemplate(aranan, Emgu.CV.CvEnum.TemplateMatchingType.CcoeffNormed))
            {
                double[] minValues, maxValues;
                Point[] minLocations, maxLocations;
                sonuc.MinMax(out minValues, out maxValues, out minLocations, out maxLocations);

                if (maxValues[0] > 0.8)
                {
                    kutuBulunduMu = true;
                    kutu_x = aranan.Size.Width / 2 + maxLocations[0].X + baslangic_x;
                    kutu_y = aranan.Size.Height / 2 + maxLocations[0].Y + baslangic_y;
                    return true;
                }
            }
            return false;
        }
        public void Harita_Bul()
        {
            kaynak = new Image<Bgr, byte>(alaninResmi);
            aranan = new Image<Bgr, byte>(haritaResmi);

            using (Image<Gray, float> sonuc = kaynak.MatchTemplate(aranan, Emgu.CV.CvEnum.TemplateMatchingType.CcoeffNormed))
            {
                double[] minValues, maxValues;
                Point[] minLocations, maxLocations;
                sonuc.MinMax(out minValues, out maxValues, out minLocations, out maxLocations);

                if (maxValues[0] > 0.3)
                {
                    haritaVarMi = true;
                    haritaYeri = new Point(maxLocations[0].X, maxLocations[0].Y);
                }
            }
        }
        public bool Isaret_Bul(Bitmap kaynak_gelen)
        {
            kaynak = new Image<Bgr, byte>(kaynak_gelen);
            aranan = new Image<Bgr, byte>(isaretResmi);

            using (Image<Gray, float> sonuc = kaynak.MatchTemplate(aranan, Emgu.CV.CvEnum.TemplateMatchingType.CcoeffNormed))
            {
                double[] minValues, maxValues;
                Point[] minLocations, maxLocations;
                sonuc.MinMax(out minValues, out maxValues, out minLocations, out maxLocations);

                if (maxValues[0] > 0.3)
                {
                    return true;
                }
                return false;
            }
        }
        public Point Harita_Tiklama_Yeri()
        {
            Tiklama_Yeri.X = haritaYeri.X + baslangic_x + r.Next(haritaResmi.Size.Width);
            Tiklama_Yeri.Y = haritaYeri.Y + baslangic_y + r.Next(haritaResmi.Size.Height);
            return Tiklama_Yeri;
        }
    }
}
