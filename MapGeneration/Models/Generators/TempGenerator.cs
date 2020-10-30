using MapGeneration.Generate;
using MapGeneration.Iterate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapGeneration.Models.Generators
{
    public class TempGenerator : GeneratorStrategy
    {
        Random Random;

        public void Execute(Map map)
        {
            this.Random = new Random();
            this.Update(map);
        }

        private void Update(Map map)
        {
            Iterator tempIterator = map.CreateTempIterator();
            while (tempIterator.HasMore())
            {
                tempIterator.GetNext().Temp = (float)Random.Next(5, 36) + (float)Random.NextDouble() - 0.5f;
            }
        }
    }
}
