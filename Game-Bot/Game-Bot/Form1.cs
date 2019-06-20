using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Game_Bot;
using GUIControlling;

namespace Game_Bot
{
    public partial class Form1 : Form
    {

        Calisma calisma = new Calisma();
        CizimFormu cF = new CizimFormu();

        //Ekran genişliğini ve yüksekliği alığ daha sonra kullanmak üzere değişkenlere atadık
        static int ekran_genisligi = Screen.PrimaryScreen.Bounds.Width;
        static int ekran_yuksekligi = Screen.PrimaryScreen.Bounds.Height;
        bool ilkDeger_AtandiMi = false;
        int AvantajSayac;

        Point Tiklama_yeri;
        Rectangle kesilecek_Bolge;
        Bitmap OyunResmi;
        Bitmap isaret;
        Graphics g;

        //Tıklanacak kutunun gemiye uzaklığına göre bekleme yapmak için uzaklık hesaplama
        private int SureHesapla(int x_g, int y_g)
        {
            //iki nokta arasındaki uzaklık formulü
            return (int)Math.Sqrt(Math.Pow(Math.Abs(y_g - (ekran_yuksekligi / 2)), 2) + Math.Pow(Math.Abs(x_g - (ekran_genisligi / 2)), 2)); ;
        }

        public Form1()
        {
            InitializeComponent();
            Label_Bilgilendirme.Text = "Fotoğraf çekilecek yeri seçiniz.";
            Tiklama_yeri = new Point();
            //Başka bir yere tıklansada formun üstte kalmasını sağlamak için
            TopMost = true;
        }

        private void ResimCekmekIcınTikla_Click(object sender, EventArgs e)
        {
            ResimCekmekIcınTikla.Text = "Alanı Belirlemek için tıklayın.";
            ilkDeger_AtandiMi = false;
            calisma.FotografCekilecekMi = true;
            cF.Visible = false;
            timer1.Start();
            timer2.Stop();
            cF.fotoCekmeyeBasla = false;
            cF.Controls.Clear();

        }

        //Alan belirlemekte kullanılan timer
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (calisma.FotografCekilecekMi)
            {
                //Mouse sol tıkına basıldığını anlamak için bu işlemi yaptık
                if ((Mouse_.Sol_TikaBasildiMi() & 0x8000) != 0)
                {
                    //ilk deger atanmadıysa sol tıklamaya basmaya devam ettiğimizi gösteriyor
                    //Eger ilk deger atandıysa sol tıka basılmış ve sürüklemeye devam ediyor demektir
                    //Buraya sadece sol tıka ilk bastığımız anda giriş yapılacak
                    if (!ilkDeger_AtandiMi)
                    {
                        calisma.baslangic_x = Cursor.Position.X;
                        calisma.baslangic_y = Cursor.Position.Y;
                    }
                    //İlk deger atanmışsa ve sürüklemeye devam edip bıraktıysak sol click bırakılmadan önce 
                    //son kez buraya girer ve kaldırılma kordinatlarını almış oluruz
                    else
                    {
                        calisma.son_x = Cursor.Position.X;
                        calisma.son_y = Cursor.Position.Y;
                    }
                    //Timer ilk defa çalıştıysa ilk kordinatları almak için bu gerekli
                    ilkDeger_AtandiMi = true;

                }

            }
            //Eger ilk deger atandıysa ve sol tıka artık basılmıyorsa bu alanın çizildiği anlamına gelir
            if (ilkDeger_AtandiMi && Mouse_.Sol_TikaBasildiMi() == 0)
            {
                calisma.FotografCekilecekMi = false;
                ResimCekmekIcınTikla.Text = "Tekrar belirlemek için tıklayın.";

                //Cizim formundan belirlenen alana bir şekil çizilip alan belirtilir
                cF.Ciz(calisma.baslangic_x, calisma.baslangic_y, (calisma.son_x - calisma.baslangic_x), (calisma.son_y - calisma.baslangic_y));
                cF.KabulButonuOlustur();
                cF.Activate();
                cF.Show();
                //Resmin çekileceği bitmap oluşturulup hazırlanır.
                OyunResmi = new Bitmap(Math.Abs(calisma.son_x - calisma.baslangic_x), Math.Abs(calisma.son_y - calisma.baslangic_y));
                g = Graphics.FromImage(OyunResmi);
                timer1.Stop();
                timer2.Start();
            }
        }
        //Ekranın sürekli resmini çekip işleme işleminin yapıldığı timer
        private void timer2_Tick(object sender, EventArgs e)
        {
            //Fotoğraf çekileceğini onaylamak için kullanılan butondan gelen kontrol 
            if (cF.fotoCekmeyeBasla)
            {
                //Ekranın fotoğrafı her tick için tekrar çekilir
                g.CopyFromScreen(calisma.baslangic_x, calisma.baslangic_y, 0, 0, OyunResmi.Size);
                calisma.alaninResmi = OyunResmi;
                //Çalışmaya ilk kez başlandığında haritanın yerini bulmak için kullanılır sadece bir kez çalışır
                if (!calisma.haritaVarMi)
                {
                    calisma.Harita_Bul();
                    kesilecek_Bolge = new Rectangle(calisma.haritaYeri.X + calisma.haritaResmi.Width / 2 - 10, calisma.haritaYeri.Y - 20, 40, 20);

                }
                //Harita bulunduysa haritanın üzerinde gemi hareket ederken cıkan işaretin yeri de bulunur.
                //Bunu geminin hareket edip etmediğini anlamka için kullanacağız
                isaret = OyunResmi.Clone(kesilecek_Bolge, OyunResmi.PixelFormat);
                //Eger kutu bulunursa burası çalışacak
                if (calisma.Kutu_Bul())
                {
                    AvantajSayac++;
                    textBox1.Text = AvantajSayac.ToString();
                    //tıklanacak yerin kordinatları kutunun şu an ki konumuna ayarlanır
                    Tiklama_yeri.X = calisma.kutu_x;
                    Tiklama_yeri.Y = calisma.kutu_y;
                    //Mouse imleci tıklanacak yere hareket ettirilir
                    Cursor.Position = Tiklama_yeri;
                    //imlecin o anki konumuna sol tıklama yapar
                    Mouse_.Sol_Tiklama();
                    //Kutunun uzaklığına oranla artacak şekilde  bekleme yapar 
                    //Bu sure kutuya gidiş suresi ve kutunun alınma suresi toplamlarıdır
                    Thread.Sleep(SureHesapla(calisma.kutu_x, calisma.kutu_y) * 3);

                }
                //Eger kutu yoksa gemimizin haritada hareket etmesi gerekir 
                //Bu iki parametereye bağlıdır birincisi harita olmalı ikincisi ise geminin hareket ettiğini gösteren işaretin olmaması durumudur
                else if (calisma.haritaVarMi && !calisma.Isaret_Bul(isaret))
                {
                    //Eger gemi durduysa ve harita varsa burasu çalışır
                    //imleç harita üzerinde bir noktaya getirilir
                    Cursor.Position = calisma.Harita_Tiklama_Yeri(calisma.kutuBulunduMu);
                    //Eger buraya geldiysek resim içerisinde kutu yok demektir o yüzden bunu false yaptık
                    calisma.kutuBulunduMu = false;
                    Mouse_.Sol_Tiklama();
                    Thread.Sleep(1500);
                }


            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AvantajSayac = 0;
            textBox1.Text = AvantajSayac.ToString();
        }
    }
}
