using MapGeneration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapGeneration.Generate
{
    public interface GeneratorStrategy
    {
        public abstract void Execute(Map map);
    }
}
