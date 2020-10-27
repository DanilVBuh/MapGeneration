using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapGeneration.Iterate
{
    public interface IterableArea
    {
        public Iterator CreateIterator();
    }
}
