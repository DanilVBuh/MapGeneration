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
        protected const float COLD_TEMP = 15f;
        protected const float HOT_TEMP = 25f;
        protected bool Generated { get; set; }
        protected BiomeBuilder Builder { get; set; }

        public Generator(BiomeBuilder builder)
        {
            this.Generated = false;
            this.Builder = builder;
        }

        public virtual void Generate()
        {
            if (Generated)
            {
                float temp = Builder.GetTemp();
                if (temp < COLD_TEMP)
                {
                    Builder.ActCold();
                }
                else if (temp > HOT_TEMP)
                {
                    Builder.ActHot();
                }
                else
                {
                    Builder.ActNormal();
                }
            }
            else
            {
                Generated = !Generated;
                Builder.Reset();
                this.Generate();
            }
        }

        public virtual void Execute(Map map)
        {
            this.Generate();
        }
    }
}
