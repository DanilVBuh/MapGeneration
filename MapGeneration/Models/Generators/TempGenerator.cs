using MapGeneration.Generate;
using MapGeneration.Iterate;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapGeneration.Models.Generators
{
    public class TempGenerator : GeneratorStrategy
    {
        private bool Generated { get; set; } = false;
        Random Random;

        public void Execute(Map map)
        {
            //this.Generated = false;
            this.Random = new Random();
            this.Update(map);
        }

        private void Generate(Map map)
        {
            float[] temps = Noise2d.GenerateNoiseMap(map.GetWidth(), map.GetHeight(), 5);
            foreach (Tile x in map.Tiles)
            {
                x.Temp = 5f + 30 * temps[(int)x.Y * map.GetWidth() + (int)x.X];
            }
        }

        private void Update(Map map)
        {
            if (Generated)
            {
                Iterator tempIterator = map.CreateTempIterator();
                while (tempIterator.HasMore())
                {
                    tempIterator.GetNext().Temp += (float)Random.NextDouble() - 0.5f;
                }
            }
            else
            {
                Generated = !Generated;
                this.Generate(map);
            }

            /*var iterator = map.CreateTempIterator();
            while (iterator.HasMore())
            {
                var tile = iterator.GetNext();
                if (tile.Temp < 15)
                {
                    tile.Colour = Color.Blue;
                }
                else if (tile.Temp > 25)
                {
                    tile.Colour = Color.Red;
                }
                else
                {
                    tile.Colour = Color.Green;
                }
            }*/
        }
    }
}
