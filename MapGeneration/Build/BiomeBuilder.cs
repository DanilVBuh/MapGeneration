using MapGeneration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapGeneration.Build
{
    public abstract class BiomeBuilder
    {
        protected Map MapContext { get; set; }
        protected Biome Biome { get; set; }
        protected Random Random { get; set; }

        private bool IsBuilt = false;

        protected BiomeBuilder()
        {
            //this.MapContext = Map.GetInstance();
            this.Random = new Random();
        }

        public abstract void Reset();
        protected abstract void BuildCold();
        protected abstract void BuildNormal();
        protected abstract void BuildHot();
        protected abstract void UpdateCold();
        protected abstract void UpdateNormal();
        protected abstract void UpdateHot();
        public virtual void ActCold()
        {
            if (IsBuilt)
            {
                UpdateCold();
            }
            else
            {
                BuildCold();
            }
        }
        public virtual void ActNormal()
        {
            if (IsBuilt)
            {
                UpdateNormal();
            }
            else
            {
                BuildNormal();
            }
        }
        public virtual void ActHot()
        {
            if (IsBuilt)
            {
                UpdateHot();
            }
            else
            {
                BuildHot();
            }
        }



        public float GetTemp()
        {
            return Biome.GetAverageTemp();
        }
    }
}
