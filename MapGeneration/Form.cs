using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapGeneration
{
    public partial class Form1 : Form
    {
        Graphics g;
        int x, y, w = 5;
        Random r;

        public Form1()
        {
            InitializeComponent();
            r = new Random();
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
            SolidBrush bl = new SolidBrush(Color.FromArgb(60,60,60));
            g.FillRectangle(bl, 0, 0, this.Width - 16, this.Height - 39);
            for (y = 0; y < this.Height - 39; y += w)
            {
                for (x = 0; x < this.Width - 16; x += w)
                {
                    int rc = r.Next(128, 256);
                    int gc = r.Next(0, 256);
                    int bc = r.Next(0, 256);
                    int alph = ((x + y) * 255) / (this.Width - 16 + this.Height - 39);
                    //Color whit = Color.FromArgb(alph, 0, 0, 0);
                    //SolidBrush b = new SolidBrush(Color.FromArgb(255 - alph, rc, gc, bc));
                    SolidBrush b = new SolidBrush(Color.FromArgb(rc, Color.DarkGreen));
                    //SolidBrush bx = new SolidBrush(Color.FromArgb((255 - alph)/2, 255, 255, 255));
                    g.FillRectangle(b, x, y, w, w);
                    //g.FillRectangle(bx, x, y, w, w);
                }
            }
            base.OnPaint(e);
        }

        private void mapTimer_Tick(object sender, EventArgs e)
        {
            this.Invalidate();
        }
    }
}
