using MapGeneration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapGeneration.Iterate
{
    public interface Iterator
    {
        public Tile GetNext();
        public bool HasMore();
    }
}
