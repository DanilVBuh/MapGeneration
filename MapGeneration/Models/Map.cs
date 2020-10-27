using MapGeneration.Models.Biomes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapGeneration.Models
{
    public class Map : Area
    {
        private static Map Instance { get; set; }

        public ICollection<Biome> Biomes { get; set; }

        private Map()
        {

        }

        public Map GetInstance()
        {
            if(Instance == null)
            {
                Instance = new Map();
            }
            return Instance;
        }

        public void Generate()
        {

        }

        public void Update()
        {

        }
    }
}
