using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP.Data.Infrastructure
{
   public  interface IDatabaseFactory : IDisposable
    {
        GPContext GPContext { get; }
    }
}
