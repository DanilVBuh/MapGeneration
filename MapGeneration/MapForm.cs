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
            mapTimer.Enabled = false;
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
            SolidBrush bl = new SolidBrush(Color.FromArgb(60, 60, 60));
            g.FillRectangle(bl, 0, 0, this.Width - 16, this.Height - 39);
            /*for (y = 0; y < this.Height - 39; y += w)
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
            }*/
            //this.MainMap.Draw(g, w);
            GenerateNoiseMap(Width, Height, g, 40);
            base.OnPaint(e);
        }

        private void mapTimer_Tick(object sender, EventArgs e)
        {
            this.MainMap.Update();
            this.Invalidate();
        }

        private void GenerateNoiseMap(int width, int height, Graphics graphics, int octaves)
        {
            var data = new float[width * height];

            /// track min and max noise value. Used to normalize the result to the 0 to 1.0 range.
            var min = float.MaxValue;
            var max = float.MinValue;

            /// rebuild the permutation table to get a different noise pattern. 
            /// Leave this out if you want to play with changing the number of octaves while 
            /// maintaining the same overall pattern.
            Noise2d.Reseed();

            var frequency = 0.5f;
            var amplitude = 1f;
            var persistence = 0.25f;

            for (var octave = 0; octave < octaves; octave++)
            {
                /// parallel loop - easy and fast.
                Parallel.For(0
                    , width * height
                    , (offset) =>
                    {
                        var i = offset % width;
                        var j = offset / width;
                        var noise = Noise2d.Noise(i * frequency * 1f / width, j * frequency * 1f / height);
                        noise = data[j * width + i] += noise * amplitude;

                        min = Math.Min(min, noise);
                        max = Math.Max(max, noise);

                    }
                );

                frequency *= 2;
                amplitude /= 2;
            }

            var colors = data.Select(
                (f) =>
                {
                    var norm = (int)(255 * (f - min) / (max - min));
                    return Color.FromArgb(norm, norm, norm);
                }
            ).ToArray();

            for (y = 0; y < height; y++)
            {
                for (x = 0; x < width; x++)
                {
                    SolidBrush b = new SolidBrush(colors[y * width + x]);
                    g.FillRectangle(b, x, y, 1, 1);
                }
            }
        }
    }
}
