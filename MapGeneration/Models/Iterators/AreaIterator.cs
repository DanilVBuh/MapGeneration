﻿using MapGeneration.Iterate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapGeneration.Models.Iterators
{
    public class AreaIterator : Iterator
    {
        private Map Area { get; set; }
        private Tile CurrentTile { get; set; }
        private int CurrentIterate { get; set; } = -1;

        public AreaIterator(Map area)
        {
            this.Area = area;
        }

        public Tile GetNext()
        {
            if (HasMore())
            {
                CurrentIterate++;
                return Area.Tiles.ElementAt(CurrentIterate);
            }
            return null;
        }

        public bool HasMore()
        {
            return CurrentIterate < Area.Tiles.Count() - 1;
        }
    }
}
