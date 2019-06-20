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

        static int ekran_genisligi = Screen.PrimaryScreen.Bounds.Width;
        static int ekran_yuksekligi = Screen.PrimaryScreen.Bounds.Height;
        bool ilkDeger_AtandiMi = false;

        Point Tiklama_yeri;
        Rectangle kesilecek_Bolge;
        Bitmap OyunResmi;
        Bitmap isaret;
        Graphics g;

        private int SureHesapla(int x_g, int y_g)
        {
            return (int)Math.Sqrt(Math.Pow(Math.Abs(y_g - (ekran_yuksekligi / 2)), 2) + Math.Pow(Math.Abs(x_g - (ekran_genisligi / 2)), 2)); ;
        }
        public Form1()
        {
            InitializeComponent();
            Label_Bilgilendirme.Text = "Fotoğraf çekilecek yeri seçiniz.";
            Tiklama_yeri = new Point();
            // kesilecek_Bolge = new Rectangle(0, 0, 0, 0);
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

        private void timer1_Tick(object sender, EventArgs e)
        {

            if (calisma.FotografCekilecekMi)
            {
                if ((Mouse_.Sol_TikaBasildiMi() & 0x8000) != 0)
                {
                    if (!ilkDeger_AtandiMi)
                    {
                        calisma.baslangic_x = Cursor.Position.X;
                        calisma.baslangic_y = Cursor.Position.Y;
                    }
                    else
                    {
                        calisma.son_x = Cursor.Position.X;
                        calisma.son_y = Cursor.Position.Y;
                    }
                    ilkDeger_AtandiMi = true;

                }

            }
            if (ilkDeger_AtandiMi && Mouse_.Sol_TikaBasildiMi() == 0)
            {
                calisma.FotografCekilecekMi = false;
                ResimCekmekIcınTikla.Text = "Tekrar belirlemek için tıklayın.";

                cF.Ciz(calisma.baslangic_x, calisma.baslangic_y, (calisma.son_x - calisma.baslangic_x), (calisma.son_y - calisma.baslangic_y));
                cF.KabulButonuOlustur();
                cF.Activate();
                cF.Show();

                OyunResmi = new Bitmap(Math.Abs(calisma.son_x - calisma.baslangic_x), Math.Abs(calisma.son_y - calisma.baslangic_y));
                g = Graphics.FromImage(OyunResmi);
                timer1.Stop();
                timer2.Start();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (cF.fotoCekmeyeBasla)
            {

                g.CopyFromScreen(calisma.baslangic_x, calisma.baslangic_y, 0, 0, OyunResmi.Size);
                calisma.alaninResmi = OyunResmi;

                if (!calisma.haritaVarMi)
                {
                    calisma.Harita_Bul();
                    kesilecek_Bolge = new Rectangle(calisma.haritaYeri.X + calisma.haritaResmi.Width / 2 - 10, calisma.haritaYeri.Y - 20, 40, 20);

                }

                isaret = OyunResmi.Clone(kesilecek_Bolge, OyunResmi.PixelFormat);

                if (calisma.Kutu_Bul())
                {
                    Tiklama_yeri.X = calisma.kutu_x;
                    Tiklama_yeri.Y = calisma.kutu_y;
                    Cursor.Position = Tiklama_yeri;
                    Mouse_.Sol_Tiklama();
                    Thread.Sleep(SureHesapla(calisma.kutu_x, calisma.kutu_y) * 3);

                }
                else if (calisma.haritaVarMi && !calisma.Isaret_Bul(isaret))
                {
                    Cursor.Position = calisma.Harita_Tiklama_Yeri(calisma.kutuBulunduMu);
                    calisma.kutuBulunduMu = false;
                    Mouse_.Sol_Tiklama();
                    Thread.Sleep(2000);
                }


            }
        }
    }
}
