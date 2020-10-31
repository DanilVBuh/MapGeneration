using MapGeneration.Iterate;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapGeneration.Models
{
    public abstract class Area : IterableArea
    {
        public ICollection<Tile> Tiles { get; set; }

        protected Area()
        {
            this.Tiles = new Collection<Tile>();
        }

        public abstract Iterator CreateIterator();
    }
}
