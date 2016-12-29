using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryDomain
{
  public  class SortedClassifications: SortedSet<Classification>
        {

      public new Boolean Add(Classification classification)
      {

          if (base.Contains(classification)) return false;
          if (this.Count(m => m.Ranking != classification.Ranking)>0) return false;
          return base.Add(classification);
      }
    }
}
