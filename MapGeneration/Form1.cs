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
        int x = 10, y = 10, w = 5;
        Random r;

        public Form1()
        {
            InitializeComponent();
            //g = mapPanel.CreateGraphics();
            r = new Random();
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
            for (y = 10; y < 610; y += w)
            {
                for (x = 10; x < 610; x += w)
                {
                    int c = r.Next(100000, 999999);
                    Color color = (Color)new ColorConverter().ConvertFromString("#" + c.ToString());
                    SolidBrush b = new SolidBrush(color);
                    g.FillRectangle(b, x, y, w, w);
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
