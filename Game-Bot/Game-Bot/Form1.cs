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
        CizimFormu cF = new CizimFormu();
        bool ilkDeger_AtandiMi = false;
        Calisma calisma = new Calisma();


        public Form1()
        {
            InitializeComponent();
            Label_Bilgilendirme.Text = "Fotoğraf çekilecek yeri seçiniz.";
            this.TopMost = true;
        }
        private void ResimCekmekIcınTikla_Click(object sender, EventArgs e)
        {
            ResimCekmekIcınTikla.Text = "Alanı Belirlemek için tıklayın.";
            ilkDeger_AtandiMi = false;
            calisma.FotografCekilecekMi = true;
            cF.Visible = false;
            timer1.Start();
            timer2.Stop();
            timer3.Stop();
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
                    Label_Bilgilendirme.Text = "Bas_x : " + calisma.baslangic_x + "  Bas_y : " + calisma.baslangic_y
                        + "  Son_x : " + calisma.son_x + "  son_y : " + calisma.son_y;

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
                timer1.Stop();
                timer2.Start();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (cF.fotoCekmeyeBasla)
            {
                Bitmap OyunResmi = new Bitmap(calisma.son_x - calisma.baslangic_x, calisma.son_y - calisma.baslangic_y);
                Graphics g = Graphics.FromImage(OyunResmi);
                g.CopyFromScreen(calisma.baslangic_x, calisma.baslangic_y, 0, 0, OyunResmi.Size);
                calisma.alaninResmi = OyunResmi;
                if (calisma.Kutu_Bul())
                {
                    Cursor.Position = new Point(Screen.PrimaryScreen.Bounds.Width / 2 + 75, Screen.PrimaryScreen.Bounds.Height / 2);
                    Mouse_.Sol_Tiklama();
                    timer2.Stop();
                    Label_Bilgilendirme.Text = "Bulundu";
                    timer3.Start();
                }
                else
                {
                    Label_Bilgilendirme.Text = "Bulunamadı";
                }

            }
        }

        private void timer3_Tick_1(object sender, EventArgs e)
        {
            if (calisma.kutuBulunduMu)
            {
                Thread.Sleep(1500);
                timer3.Stop();
                calisma.kutuBulunduMu = calisma.Kutu_Bul();
                Cursor.Position = new Point(calisma.kutu_x, calisma.kutu_y);
                Mouse_.Sol_Tiklama();
                Thread.Sleep(1000);
                calisma.kutuBulunduMu = false;
                calisma.kutu_x = 0;
                calisma.kutu_y = 0;
                timer2.Start();
            }
            else
            {
                timer3.Stop();
                timer2.Start();
            }
        }
    }
}
