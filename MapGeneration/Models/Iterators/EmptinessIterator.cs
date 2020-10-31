using MapGeneration.Iterate;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapGeneration.Models.Iterators
{
    public class EmptinessIterator : Iterator
    {
        private ICollection<Tile> Emptinnes { get; set; }
        private ICollection<Tile> Edge { get; set; }
        private ICollection<Tile> Reserved { get; set; }
        private Random Random { get; set; }
        private int Count { get; set; }
        private int CurrentCount { get; set; } = 0;

        public EmptinessIterator(Map area)
        {
            this.Edge = new Collection<Tile>();
            this.Reserved = new Collection<Tile>();
            this.Emptinnes = area.Tiles.Where(t => t.Biome == null).ToList();
            this.Random = new Random();
            int count = Random.Next(area.Tiles.Count / 16, area.Tiles.Count / 4);
            this.Count = Math.Min(count, Emptinnes.Count);
        }

        public Tile GetNext()
        {
            if (HasMore())
            {
                Tile tile;
                if (CurrentCount == 0)
                {
                    int randIndex = Random.Next(0, Emptinnes.Count);
                    tile = Emptinnes.ElementAt(randIndex);
                    Emptinnes.Remove(tile);
                    Edge.Add(tile);
                    MoveTile(tile);
                    CurrentCount++;
                    return tile;
                }
                if (Edge.Count != 0)
                {
                    int randTile = Random.Next(0, Edge.Count);
                    tile = Edge.ElementAt(randTile);
                    MoveTile(tile);
                    CurrentCount++;
                    if (!HasMore())
                    {
                        TryFillGaps();
                    }
                    return tile;
                }
                else
                {
                    Count = CurrentCount;
                }
                CurrentCount++;
                return null;
            }
            return null;
        }

        public bool HasMore()
        {
            return CurrentCount < Count;
        }

        private void TryFillGaps()
        {
            ICollection<Tile> gaps = Edge.Where(t => !Emptinnes.Any(c => c.IsNearWith(t))).ToList();
            if (gaps.Count != 0)
            {
                Edge.Clear();
                Edge = gaps;
                Count += gaps.Count;
            }
        }

        private void MoveTile(Tile tile)
        {
            Reserved.Add(tile);
            AddBorder(tile);
        }

        private void AddBorder(Tile tile)
        {
            ICollection<Tile> cache = Emptinnes.Where(t => t.IsNearWith(tile)).ToList();
            foreach (Tile t in cache)
            {
                Emptinnes.Remove(t);
                Edge.Add(t);
            }
            Edge.Remove(tile);
        }
    }
}
