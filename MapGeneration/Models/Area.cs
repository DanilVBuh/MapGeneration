using MapGeneration.Iterate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapGeneration.Models
{
    public abstract class Area : IterableArea
    {
        public ICollection<Tile> Tiles { get; set; }

        public Iterator CreateIterator()
        {
            throw new NotImplementedException();
        }
    }
}
