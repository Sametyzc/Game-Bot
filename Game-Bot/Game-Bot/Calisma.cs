using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MouseControl;
using System.Threading;

namespace Game_Bot
{
    class Calisma
    {
        private bool kutuBulunduMu;
        private bool haritaVarMi;

        private int baslangic_x;
        private int baslangic_y;
        private int son_x;
        private int son_y;
        private int sira;
        private int gemiHizi;

        private Rectangle isaret_bolgesi;

        private Graphics graphics_resim;

        private Point haritaYeri;
        private Point kutuYeri;
        private Point Ekran;
        private Point haritaTiklamaYeri;

        private Bitmap alaninResmi;
        private Bitmap kesilenIsaret;

        private Image<Bgr, byte> kaynak;
        private Image<Bgr, byte> kutuResmi;
        private Image<Bgr, byte> haritaResmi;
        private Image<Bgr, byte> isaretResmi;

        private Random random_sayi;

        ///////////////////////////////////////////////////
        public bool KutuBulunduMu
        { get { return kutuBulunduMu; } }
        public bool HaritaVarMi
        {
            get { return haritaVarMi; }
        }

        public int Baslangic_x
        {
            get { return baslangic_x; }
            set
            {
                if (value < 0)
                    baslangic_x = 0;
                else
                    baslangic_x = value;
            }
        }
        public int Baslangic_y
        {
            get { return baslangic_y; }
            set
            {
                if (value < 0)
                    baslangic_y = 0;
                else
                    baslangic_y = value;
            }
        }
        public int Son_x
        {
            get { return son_x; }
            set
            {
                if (value < 0)
                    son_x = 0;
                else
                    son_x = value;
            }
        }
        public int Son_y
        {
            get { return son_y; }
            set
            {
                if (value < 0)
                    son_y = 0;
                else
                    son_y = value;
            }
        }
        public int GemiHizi
        {
            get { return gemiHizi; }
        }

        public Point HaritaYeri
        {
            get { return haritaYeri; }
        }
        public Point KutuYeri
        {
            get { return kutuYeri; }
        }



        ///////////////////////////////////////////////////
        public Calisma(int Ekran_Genisligi, int Ekran_Yuksekligi, int Gemi_Hizi)
        {
            baslangic_x = 0;
            baslangic_y = 0;
            son_x = 0;
            son_y = 0;
            Ekran.X = Ekran_Genisligi;
            Ekran.Y = Ekran_Yuksekligi;
            gemiHizi = Gemi_Hizi;
            kutuBulunduMu = false;
            haritaVarMi = false;
            alaninResmi = null;
            sira = 0;
            random_sayi = new Random();

            //Ekranda aranan nesneler dosyalardan çekildi
            kutuResmi = new Image<Bgr, byte>((Bitmap)Image.FromFile("Resimler/kutu1.png"));
            haritaResmi = new Image<Bgr, byte>((Bitmap)Image.FromFile("Resimler/Harita.png"));
            isaretResmi = new Image<Bgr, byte>((Bitmap)Image.FromFile("Resimler/isaret.png"));
        }

        private int SureHesapla()
        {
            //iki nokta arasındaki uzaklık formulü
            return 200 + ((int)Math.Sqrt(Math.Pow(Math.Abs(kutuYeri.Y - (Ekran.Y / 2)), 2) + Math.Pow(Math.Abs(kutuYeri.X - (Ekran.X / 2)), 2))) * 1000 / (gemiHizi - 20);
        }

        private void Sol_Tikla(Point TiklamaYeri)
        {
            //Mouse imleci tıklanacak yere hareket ettirilir
            Cursor.Position = TiklamaYeri;
            //imlecin o anki konumuna sol tıklama yapar
            Mouse_.Sol_Tiklama();
        }

        public void Baslangıc_Degerlerini_Ata()
        {
            if (son_x < baslangic_x)
            {
                int temp = son_x;
                son_x = baslangic_x;
                baslangic_x = temp;
            }
            if (son_y < baslangic_y)
            {
                int temp = son_y;
                son_y = baslangic_y;
                baslangic_y = temp;
            }

            alaninResmi = new Bitmap(son_x - baslangic_x, son_y - baslangic_y);
            graphics_resim = Graphics.FromImage(alaninResmi);

            Alanin_Resmini_Cek();
            Harita_Bul();
            isaret_bolgesi = new Rectangle(haritaYeri.X + haritaResmi.Width / 2 - 20, haritaYeri.Y - 25, 25, 20);

        }

        public void Alanin_Resmini_Cek()
        {
            graphics_resim.CopyFromScreen(baslangic_x, baslangic_y, 0, 0, alaninResmi.Size);
            kaynak = new Image<Bgr, byte>(alaninResmi);
        }

        public void Isaretin_Resmini_Cek()
        {
            kesilenIsaret = alaninResmi.Clone(isaret_bolgesi, alaninResmi.PixelFormat);
        }

        public void Harita_Bul()
        {
            using (Image<Gray, float> sonuc = kaynak.MatchTemplate(haritaResmi, Emgu.CV.CvEnum.TemplateMatchingType.CcoeffNormed))
            {
                double[] minValues, maxValues;
                Point[] minLocations, maxLocations;
                sonuc.MinMax(out minValues, out maxValues, out minLocations, out maxLocations);

                if (maxValues[0] > 0.3)
                {
                    haritaVarMi = true;
                    //Haritanın yeri alınır
                    haritaYeri = new Point(maxLocations[0].X, maxLocations[0].Y);
                }
            }
        }

        public bool Isaret_Bul()
        {
            kaynak = new Image<Bgr, byte>(kesilenIsaret);

            using (Image<Gray, float> sonuc = kaynak.MatchTemplate(isaretResmi, Emgu.CV.CvEnum.TemplateMatchingType.CcoeffNormed))
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
        //Belli bir periyotta haritada gezinmesi için
        private Point Harita_Tiklama_Yeri(bool Artirma_YapilsinMi)
        {
            //Bu parametrenin alınma sebebi ise eğer ekranda bir kutu varsa gemi onu aldıktan sonra hareketsiz kalacağı için sıradaki konuma tıklamya çalışacak
            //Tıkladığı yerin civarına ulaşana kadar yolda kutu dahi görse istikametini değiştirmeyecek
            //Diğer bir noktaya sadece gemi durduysa ve etrafta kutu yoksa ilerliyecek böylece daha verimli şekilde haritada dolaşacak
            int x;
            int y;

            if (!Artirma_YapilsinMi)
            {
                sira++;
                if (sira == 6)
                    sira = 0;
            }
            //Haritanın sol üstüne tıklamak için
            if (sira == 0)
            {
                x = random_sayi.Next(30, haritaResmi.Size.Width / 4);
                y = random_sayi.Next(10, haritaResmi.Size.Height / 5);

            }
            //Haritanın sağ üstüne tıklamak için
            else if (sira == 1)
            {
                x = random_sayi.Next(haritaResmi.Size.Width * 4 / 5, haritaResmi.Size.Width - 10);
                y = random_sayi.Next(5, haritaResmi.Size.Height / 5);

            }
            //Haritanın sağ orta tarafına tıklamak için
            else if (sira == 2)
            {
                x = haritaResmi.Size.Width / 2 + random_sayi.Next(-10, 10);
                y = haritaResmi.Size.Height / 2 + random_sayi.Next(-10, 10);
            }
            //Haritanın sağ altına tıklamak için
            else if (sira == 3)
            {
                x = random_sayi.Next(haritaResmi.Size.Width * 3 / 4, haritaResmi.Size.Width - 30);
                y = random_sayi.Next(haritaResmi.Size.Height * 4 / 5, haritaResmi.Size.Height - 10);
            }
            //Haritanın sol altına tıklamak için
            else if (sira == 4)
            {
                x = random_sayi.Next(5, haritaResmi.Size.Width / 5);
                y = random_sayi.Next(haritaResmi.Size.Height * 4 / 5, haritaResmi.Size.Height - 10);
            }
            //Haritanın sol ortasına tıklamak için
            else
            {
                x = haritaResmi.Size.Width / 2 + random_sayi.Next(-10, 10);
                y = haritaResmi.Size.Height / 2 + random_sayi.Next(-10, 10);
            }
            //Periyodu böyle yapmamın sebebi haritanın sol ve sag kısımlarında çok az kutu bulunması aynı zamanda haritanun üst ve alt kısımlarında daha fazla kutu olması
            //Böylece daha verimli bir şekilde kutu toplaması yapılabiliniyor
            haritaTiklamaYeri.X = HaritaYeri.X + Baslangic_x + x;
            haritaTiklamaYeri.Y = HaritaYeri.Y + Baslangic_y + y;
            return haritaTiklamaYeri;
        }

        public bool Kutu_Bul_Tikla()
        {
            Alanin_Resmini_Cek();
            using (Image<Gray, float> sonuc = kaynak.MatchTemplate(kutuResmi, Emgu.CV.CvEnum.TemplateMatchingType.CcoeffNormed))
            {
                //Buradaki min ve max arasında ne fark var bilmiyorum ama max kullanınca sorun olmuyor
                double[] minValues, maxValues;
                Point[] minLocations, maxLocations;
                sonuc.MinMax(out minValues, out maxValues, out minLocations, out maxLocations);
                //Bunların dizi olmasının sebebi aranan nesneden resim içinde birden fazla olabileceği için
                //Buradaki 0.8 benzerlik katsayısı eğer 1 yapsaydık aranan resminin aynısını tıpkısını bulmayqa çalışırdı
                if (maxValues[0] > 0.8)
                {
                    //Buraya gelindiyse aranan nesnemize benzeyen bir nesne bulunmuş demektir
                    kutuBulunduMu = true;
                    //Kordinatarı alınır
                    //Bunlara baslangic_x degerlerinin eklenme sebebi bulunan nesnenin kordinatlarının bizim resmini çektiğimiz alana göre olması
                    //Buna ekrana göre referans almak için alanın baslangıcının eklenmesi gerek.
                    kutuYeri.X = kutuResmi.Size.Width / 2 + maxLocations[0].X + baslangic_x;
                    kutuYeri.Y = kutuResmi.Size.Height / 2 + maxLocations[0].Y + baslangic_y;
                    Sol_Tikla(kutuYeri);
                    //Kutunun uzaklığına oranla artacak şekilde  bekleme yapar 
                    //Bu sure kutuya gidiş suresi ve kutunun alınma suresi toplamlarıdır
                    Thread.Sleep(SureHesapla());
                    return true;
                }
                return false;
            }
        }

        public void Gemi_Hareketi_Yap()
        {
            Isaretin_Resmini_Cek();
            if (haritaVarMi && !Isaret_Bul())
            {
                //Eger gemi durduysa ve harita varsa burası çalışır
                Sol_Tikla(Harita_Tiklama_Yeri(kutuBulunduMu));
                //Eger buraya geldiysek resim içerisinde kutu yok demektir o yüzden bunu false yaptık
                kutuBulunduMu = false;
                Thread.Sleep(500);
            }
        }

    }
}
