using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace MapGeneration.Models
{
    public class Tile
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Height { get; set; }
        public float Temp { get; set; }
        public Color Colour { get; set; }
    }
}
