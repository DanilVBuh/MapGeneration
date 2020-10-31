using MapGeneration.Generate;
using MapGeneration.Iterate;
using MapGeneration.Models.Biomes;
using MapGeneration.Models.Builders;
using MapGeneration.Models.Generators;
using MapGeneration.Models.Iterators;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapGeneration.Models
{
    public class Map : Area
    {
        private int Width { get; set; } = 100;
        private int Height { get; set; } = 100;

        private static Map Instance { get; set; }

        public ICollection<Biome> Biomes { get; set; }

        public ICollection<GeneratorStrategy> Generators { get; set; }

        private Map()
        {
            this.Tiles = new Collection<Tile>();
            this.Biomes = new Collection<Biome>();
            this.Generators = new Collection<GeneratorStrategy>();
            this.Generate();
            //this.Update();
        }

        public static Map GetInstance()
        {
            if (Instance == null)
            {
                Instance = new Map();
            }
            return Instance;
        }

        public void Generate()
        {
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    this.Tiles.Add(new Tile
                    {
                        X = x,
                        Y = y,
                        Colour = Color.DarkGreen
                    });
                }
            }
            this.Generators.Add(new TempGenerator());
            this.Generators.Add(new MountainGenerator(new MountainBuilder()));
            this.Generators.Add(new MountainGenerator(new MountainBuilder()));
            this.Generators.Add(new MountainGenerator(new MountainBuilder()));
            this.Generators.Add(new MountainGenerator(new MountainBuilder()));
        }

        public void Update()
        {
            foreach (GeneratorStrategy gs in Generators)
            {
                gs.Execute(this);
            }
        }

        public int GetWidth()
        {
            return this.Width;
        }

        public int GetHeight()
        {
            return this.Height;
        }

        public void Draw(Graphics g, int tileWidth)
        {
            Iterator iterator = CreateIterator();
            while (iterator.HasMore())
            {
                Tile tile = iterator.GetNext();
                if (tile.Biome != null)
                {
                    SolidBrush back = new SolidBrush(tile.Biome.BiomeBackColor);
                    g.FillRectangle(back, tile.X * tileWidth, tile.Y * tileWidth, tileWidth, tileWidth);
                }
                SolidBrush b = new SolidBrush(tile.Colour);
                g.FillRectangle(b, tile.X * tileWidth, tile.Y * tileWidth, tileWidth, tileWidth);
            }
            /*iterator = CreateIterator();
            while (iterator.HasMore())
            {
                Tile tile = iterator.GetNext();
                if (tile.Biome != null)
                {
                    SolidBrush back = new SolidBrush(tile.Biome.BiomeBackColor);
                    g.FillRectangle(back, tile.X * tileWidth, tile.Y * tileWidth, tileWidth, tileWidth);
                }
                SolidBrush b = new SolidBrush(tile.Colour);
                g.FillRectangle(b, tile.X * tileWidth, tile.Y * tileWidth, tileWidth, tileWidth);
            }*/
        }

        public Iterator CreateTempIterator()
        {
            return new TempIterator(this);
        }

        public Iterator CreateEmptinessIterator()
        {
            return new EmptinessIterator(this);
        }

        public override Iterator CreateIterator()
        {
            return new AreaIterator(this);
        }
    }
}
