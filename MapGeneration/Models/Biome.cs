using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapGeneration.Models
{
    public abstract class Biome : Area
    {
        public Color BiomeColor { get; set; }
        public Color BiomeBackColor { get; set; }
        public void AddTile(Tile tile)
        {
            this.Tiles.Add(tile);
            tile.Biome = this;
        }
        public void RemoveTile(Tile tile)
        {
            this.Tiles.Remove(tile);
            tile.Biome = null;
        }
        public float GetAverageTemp()
        {
            float sum = 0f;
            foreach (Tile t in Tiles)
                sum += t.Temp;
            return sum / Tiles.Count;
        }
    }
}
