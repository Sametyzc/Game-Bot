using MouseControl;
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

namespace Game_Bot
{
    public partial class Form1 : Form
    {

        static Calisma calisma = new Calisma(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, 576);
        CizimFormu cF = new CizimFormu(calisma);

        bool ilkDeger_AtandiMi = false;
        bool alan_BelirlenecekMi = false;
        bool P_BasildiMi = false;
        int AvantajSayac;


        //Tıklanacak kutunun gemiye uzaklığına göre bekleme yapmak için uzaklık hesaplama


        public Form1()
        {
            InitializeComponent();
            Label_Bilgilendirme.Text = "Fotoğraf çekilecek yeri seçiniz.";
            //Başka bir yere tıklansada formun üstte kalmasını sağlamak için
            TopMost = true;
        }

        private void ResimCekmekIcınTikla_Click(object sender, EventArgs e)
        {
            ResimCekmekIcınTikla.Text = "Alanı Belirlemek için tıklayın.";
            ilkDeger_AtandiMi = false;
            alan_BelirlenecekMi = true;
            cF.Visible = false;
            timer1.Start();
            timer2.Stop();
            cF.fotoCekmeyeBasla = false;
            cF.Controls.Clear();
            P_BasildiMi = false;
        }

        //Alan belirlemekte kullanılan timer
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (alan_BelirlenecekMi)
            {
                //Mouse sol tıkına basıldığını anlamak için bu işlemi yaptık
                if (Mouse_.Sol_TikaBasildiMi() != 0)
                {
                    //ilk deger atanmadıysa sol tıklamaya basmaya devam ettiğimizi gösteriyor
                    //Eger ilk deger atandıysa sol tıka basılmış ve sürüklemeye devam ediyor demektir
                    //Buraya sadece sol tıka ilk bastığımız anda giriş yapılacak
                    if (!ilkDeger_AtandiMi)
                    {
                        calisma.Baslangic_x = Cursor.Position.X;
                        calisma.Baslangic_y = Cursor.Position.Y;
                    }
                    //İlk deger atanmışsa ve sürüklemeye devam edip bıraktıysak sol click bırakılmadan önce 
                    //son kez buraya girer ve kaldırılma kordinatlarını almış oluruz
                    else
                    {
                        calisma.Son_x = Cursor.Position.X;
                        calisma.Son_y = Cursor.Position.Y;
                    }
                    //Timer ilk defa çalıştıysa ilk kordinatları almak için bu gerekli
                    ilkDeger_AtandiMi = true;
                }

            }
            //Eger ilk deger atandıysa ve sol tıka artık basılmıyorsa bu alanın çizildiği anlamına gelir
            if (ilkDeger_AtandiMi && Mouse_.Sol_TikaBasildiMi() == 0)
            {
                alan_BelirlenecekMi = false;
                ResimCekmekIcınTikla.Text = "Tekrar belirlemek için tıklayın.";


                //Cizim formundan belirlenen alana bir şekil çizilip alan belirtilir
                cF.Ciz(calisma.Baslangic_x, calisma.Baslangic_y, (calisma.Son_x - calisma.Baslangic_x), (calisma.Son_y - calisma.Baslangic_y));
                cF.KabulButonuOlustur();
                cF.Activate();
                cF.Show();

                timer1.Stop();
                timer2.Start();
            }
        }
        //Ekranın sürekli resmini çekip işleme işleminin yapıldığı timer
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (cF.fotoCekmeyeBasla)
            {
                pictureBox1.Image = calisma.Isaretin_Resmini_Cek();
                if (!P_BasildiMi)
                {
                    Label_Sure.Text = "Çalışma Süresi: " + calisma.Calisma_Suresi_Hesapla();
                    Label_Bilgi.Text = "Baslatmak için P tuşuna Basınız";

                    if (Mouse_.P_Basildimi() != 0)
                    {
                        P_BasildiMi = true;
                    }
                    else if (calisma.Kutu_Bul_Tikla())
                    {
                        AvantajSayac++;
                        textBox1.Text = AvantajSayac.ToString();
                    }
                    else
                    {
                        calisma.Gemi_Hareketi_Yap();
                    }
                }
                else
                {
                    Label_Bilgi.Text = "Baslatmak için P tuşuna Basınız";
                    if (Mouse_.P_Basildimi() != 0)
                    {
                        P_BasildiMi = false;
                    }
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
