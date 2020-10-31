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

        /*public override void Execute(Map map)
        {
            this.Generate();
        }

        public override void Generate()
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
                Builder.Reset();
                Generated = !Generated;
                this.Generate();
            }
        }*/
    }
}
