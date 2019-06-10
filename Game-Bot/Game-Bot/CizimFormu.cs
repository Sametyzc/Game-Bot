using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game_Bot
{
    public partial class CizimFormu : Form
    {
        Rectangle r;
        int x;
        int y;
        int uzunluk;
        int genislik;
        public CizimFormu()
        {
            InitializeComponent();
            this.TopMost = true;
            this.DoubleBuffered = true;
            this.ShowInTaskbar = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.BackColor = Color.Purple;
            this.TransparencyKey = Color.Purple;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(Pens.Black, r);
            this.Invalidate(); //cause repaint
        }
        public void Ciz(int x,int y,int uzunluk,int genislik)
        {
            Graphics g = this.CreateGraphics();
            r = new Rectangle(x, y, uzunluk, genislik);
            PaintEventArgs e = new PaintEventArgs(g, r);
            OnPaint(e);
        }

    }
}
