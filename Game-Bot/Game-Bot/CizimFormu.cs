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
        Point bolge;
        public bool fotoCekmeyeBasla = false;
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
            float[] cizgiAraliklari = { 5, 5 };
            Pen pen = new Pen(Color.Red, 1);
            pen.DashPattern = cizgiAraliklari;
            e.Graphics.DrawRectangle(pen, r);
        }
        public void KabulButonuOlustur()
        {

            Button kabul_buton = new Button();
            Label kabul_label = new Label();
            if (bolge.Y - 70 < 0)
            {
                kabul_label.Location = new Point(bolge.X, bolge.Y + 10);
                kabul_buton.Location = new Point(bolge.X, bolge.Y + 40);
            }
            else
            {
                kabul_label.Location = new Point(bolge.X, bolge.Y - 70);
                kabul_buton.Location = new Point(bolge.X, bolge.Y - 40);
            }

            kabul_label.Text = "Onaylamak için aşağıdaki butona basınız.Tekrar denemek için ilk bastığınız butona tıklayın.";
            kabul_label.Font = new Font("Constantia", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            kabul_label.Name = "Kabul_Buton";
            kabul_label.Width = 800;
            kabul_label.Height = 20;
            kabul_label.Visible = true;


            kabul_buton.Name = "Kabul_Buton";
            kabul_buton.Height = 40;
            kabul_buton.Width = 150;
            kabul_buton.Text = "Onaylamak için tıklayın.";
            kabul_buton.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(162)));
            kabul_buton.Visible = true;
            kabul_buton.Click += new EventHandler(kabul_buton_Click);
            kabul_buton.BackColor = Color.Gray;
            Controls.Add(kabul_label);
            Controls.Add(kabul_buton);
        }
        private void kabul_buton_Click(object sender, EventArgs e)
        {
            fotoCekmeyeBasla = true;
            Controls.Clear();
        }

        public void Ciz(int x, int y, int uzunluk, int genislik)
        {
            r = new Rectangle(x, y, uzunluk, genislik);
            PaintEventArgs e = new PaintEventArgs(CreateGraphics(), r);
            OnPaint(e);
            bolge = new Point(x, y);
        }

    }
}
