﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreWebApi.Filter
{
    public class CustomerFilterModelPaged : PagingModelBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public CustomerFilterModelPaged() : base()
        {
            this.Limit = 10;
        }


        public override object Clone()
        {
            var jsonString = JsonConvert.SerializeObject(this);
            return JsonConvert.DeserializeObject(jsonString, this.GetType());
        }

    }
}