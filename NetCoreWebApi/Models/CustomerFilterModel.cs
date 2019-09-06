using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreWebApi.Models
{
    public class CustomerFilterModel : FilterModelBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public CustomerFilterModel() : base()
        {
            this.Limit = 3;
        }


        public override object Clone()
        {
            var jsonString = JsonConvert.SerializeObject(this);
            return JsonConvert.DeserializeObject(jsonString, this.GetType());
        }

    }
}
