using MapGeneration.Build;
using MapGeneration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapGeneration.Generate
{
    public abstract class Generator : GeneratorStrategy
    {
        private BiomeBuilder Builder { get; set; }

        public Generator(BiomeBuilder builder)
        {
            this.Builder = builder;
        }

        public abstract void Generate(float averageTemp);
        public abstract void Execute(Map map);
    }
}
