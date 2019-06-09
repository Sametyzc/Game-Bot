using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Game_Bot;
using GUIControlling;

namespace Game_Bot
{
    public partial class Form1 : Form
    {

        Calisma calisma = new Calisma();
        public Form1()
        {
            InitializeComponent();
            timer1.Start();
        }
        private void ResimCekmekIcınTikla_Click(object sender, EventArgs e)
        {
            this.Hide();
            Bitmap OyunResmi = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            Graphics g = Graphics.FromImage(OyunResmi);
            g.CopyFromScreen(0, 0, 0, 0, OyunResmi.Size);
            Resim form2 = new Resim(OyunResmi);
            form2.Activate();
            form2.Show(); 
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(Mouse.Sol_TikaBasildiMi())
            {
                label1.Text = "Sol Tika Basıldi";
            }
        }
    }
}
