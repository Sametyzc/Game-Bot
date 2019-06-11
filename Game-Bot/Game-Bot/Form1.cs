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
        }
        private void ResimCekmekIcınTikla_Click(object sender, EventArgs e)
        {
            ResimCekmekIcınTikla.Text = "Alanı Belirlemek için tıklayın.";
            ilkDeger_AtandiMi = false;
            calisma.FotografCekilecekMi = true;
            cF.Visible = false;
            timer1.Start();
            cF.Controls.Clear();
           /* Bitmap OyunResmi = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            Graphics g = Graphics.FromImage(OyunResmi);
            g.CopyFromScreen(0, 0, 0, 0, OyunResmi.Size);*/
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            if (calisma.FotografCekilecekMi)
            {
                if ((Mouse.Sol_TikaBasildiMi() & 0x8000) != 0)
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
            if (ilkDeger_AtandiMi && Mouse.Sol_TikaBasildiMi() == 0)
            {
                calisma.FotografCekilecekMi = false;
                ResimCekmekIcınTikla.Text = "Tekrar belirlemek için tıklayın.";
                cF.Ciz(calisma.baslangic_x, calisma.baslangic_y, (calisma.son_x - calisma.baslangic_x), (calisma.son_y - calisma.baslangic_y));
                cF.KabulButonuOlustur();
                cF.Activate();
                cF.Show();
                timer1.Stop();
            }
        }
    }
}
