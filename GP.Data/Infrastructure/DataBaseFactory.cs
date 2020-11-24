using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP.Data.Infrastructure
{
    public class DataBaseFactory : Disposable, IDatabaseFactory
    {
        private GPContext dataContext = null;
        public GPContext GPContext { get { return dataContext; } }
        public DataBaseFactory()
        {
            dataContext = new GPContext();
        }
        protected override void DisposeCore()
        {
            if (dataContext != null) dataContext.Dispose();
        }
    }
}
