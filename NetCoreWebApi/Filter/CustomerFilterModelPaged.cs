using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreWebApi.Filter
{
    public class CustomerFilterModelPaged : CustomerFilterModel, ICloneable
    {
        public int Page { get; set; }
        public int Limit { get; set; }

        public CustomerFilterModelPaged() : base()
        {
            this.Page = 1;
            this.Limit = 10;
        }


        public object Clone()
        {
            var jsonString = JsonConvert.SerializeObject(this);
            return JsonConvert.DeserializeObject(jsonString, this.GetType());
        }

    }
}
