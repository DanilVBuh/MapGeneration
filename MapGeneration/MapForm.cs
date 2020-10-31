using MapGeneration.Models;
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
    public partial class MapForm : System.Windows.Forms.Form
    {
        Map MainMap;
        Graphics g;
        int x, y, w = 5;
        Random r;

        public MapForm()
        {
            InitializeComponent();
            this.MainMap = Map.GetInstance();
            r = new Random();
            //mapTimer.Enabled = false;
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
            this.MainMap.Draw(g, w);
            base.OnPaint(e);
        }

        private void mapTimer_Tick(object sender, EventArgs e)
        {
            this.MainMap.Update();
            this.Invalidate();
        }
        
    }
}
