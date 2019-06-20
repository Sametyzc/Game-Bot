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
        public bool FotografCekilecekMi, kutuBulunduMu, haritaVarMi;
        public int baslangic_x;
        public int baslangic_y;
        public int son_x;
        public int son_y;
        public int kutu_x;
        public int kutu_y;
        int sira;
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
            sira = 0;
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
        public Point Harita_Tiklama_Yeri(bool Artirma_YapilsinMi)
        {

            int x;
            int y;

            if (!Artirma_YapilsinMi)
            {
                sira++;
                if (sira == 6)
                    sira = 0;
            }

            if (sira == 0)
            {
                x = r.Next(30, haritaResmi.Size.Width / 4);
                y = r.Next(10, haritaResmi.Size.Height / 5);

            }
            else if (sira == 1)
            {
                x = r.Next(haritaResmi.Size.Width * 4 / 5, haritaResmi.Size.Width - 10);
                y = r.Next(5, haritaResmi.Size.Height / 5);

            }
            else if (sira == 2)
            {
                x = haritaResmi.Size.Width / 2 + r.Next(-10, 10);
                y = haritaResmi.Size.Height / 2 + r.Next(-10, 10);
            }
            else if (sira == 3)
            {
                x = r.Next(haritaResmi.Size.Width * 3 / 4, haritaResmi.Size.Width - 30);
                y = r.Next(haritaResmi.Size.Height * 4 / 5, haritaResmi.Size.Height - 10);
            }
            else if (sira == 4)
            {
                x = r.Next(5, haritaResmi.Size.Width / 5);
                y = r.Next(haritaResmi.Size.Height * 4 / 5, haritaResmi.Size.Height - 10);
            }
            else
            {
                x = haritaResmi.Size.Width / 2 + r.Next(-10, 10);
                y = haritaResmi.Size.Height / 2 + r.Next(-10, 10);
            }

            Tiklama_Yeri.X = haritaYeri.X + baslangic_x + x;
            Tiklama_Yeri.Y = haritaYeri.Y + baslangic_y + y;
            return Tiklama_Yeri;
        }
    }
}
