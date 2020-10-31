using MapGeneration.Build;
using MapGeneration.Iterate;
using MapGeneration.Models.Biomes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapGeneration.Models.Builders
{
    public class MountainBuilder : BiomeBuilder
    {
        float MinH = 0;
        float MaxH = 0;
        public override void Reset()
        {
            Biome = new MountainBiome();
            MapContext = Map.GetInstance();
            Iterator iterator = MapContext.CreateEmptinessIterator();
            while (iterator.HasMore())
            {
                Tile tile = iterator.GetNext();
                Biome.AddTile(tile);
            }
        }

        protected override void BuildCold()
        {
            Biome.BiomeBackColor = Color.FromArgb(190, 190, 190);
            Biome.BiomeColor = Color.FromArgb(60, 60, 60);
            SetHeight();
            //float h = Biome.Tiles.Select(t => t.Height).FirstOrDefault();
            foreach (Tile t in Biome.Tiles)
            {
                int alpha = 255 - (int)(255 * (t.Height - MinH) / (MaxH - MinH));
                t.Colour = Color.FromArgb(alpha, Biome.BiomeColor);
            }
        }

        protected override void BuildHot()
        {
            BuildCold();
        }

        protected override void BuildNormal()
        {
            BuildCold();
        }

        protected override void UpdateCold()
        {
            BuildCold();
        }

        protected override void UpdateHot()
        {
            BuildCold();
        }

        protected override void UpdateNormal()
        {
            BuildCold();
        }

        private void SetHeight()
        {
            float limitHeight = 0f;
            ICollection<Tile> tiles = Biome.Tiles.ToList();
            ICollection<Tile> heights = new Collection<Tile>();
            Queue<Tile> q = new Queue<Tile>();
            int randIndex = Random.Next(0, tiles.Count);
            Tile tile = tiles.ElementAt(randIndex);
            tiles.Remove(tile);
            tile.Height = 0f;
            q.Enqueue(tile);
            while (q.Count != 0)
            {
                Tile tl = q.Dequeue();
                heights.Add(tl);
                ICollection<Tile> cache = tiles.Where(t => t.IsNearWith(tl)).ToList();
                foreach (Tile t in cache)
                {
                    t.Height = tl.Height + 75 * (float)Random.NextDouble();
                    limitHeight = Math.Max(t.Height, limitHeight);
                    q.Enqueue(t);
                    tiles.Remove(t);
                }
            }
            float bot = 100;
            MaxH = 0;
            MinH = limitHeight + bot;
            foreach (Tile t in heights)
            {
                t.Height = limitHeight - t.Height + bot;
                MaxH = Math.Max(t.Height, MaxH);
                MinH = Math.Min(t.Height, MinH);
            }
        }
    }
}
