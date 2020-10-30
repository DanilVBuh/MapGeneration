using MapGeneration.Build;
using MapGeneration.Generate;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapGeneration.Models.Generators
{
    public class MountainGenerator : Generator
    {
        public MountainGenerator(BiomeBuilder builder) : base(builder)
        {
        }

        public override void Execute(Map map)
        {
            var iterator = map.CreateTempIterator();
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
            }
        }

        public override void Generate(float averageTemp)
        {
            throw new NotImplementedException();
        }
    }
}
