using MapGeneration.Build;
using MapGeneration.Generate;
using System;
using System.Collections.Generic;
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
            throw new NotImplementedException();
        }

        public override void Generate(float averageTemp)
        {
            throw new NotImplementedException();
        }
    }
}
