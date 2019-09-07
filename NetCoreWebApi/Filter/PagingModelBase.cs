using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreWebApi.Filter
{
    public abstract class PagingModelBase : ICloneable
    {
        public int Page { get; set; }
        public int Limit { get; set; }

        public PagingModelBase()
        {
            this.Page = 1;
            this.Limit = 100;
        }

        public abstract object Clone();
    }
}
