using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreWebApi.Filter
{
    /// <summary>
    /// Filter Model class for Customer with Paging
    /// Extends CustomerFilterModel and implements ICloneable
    /// </summary>
    public class CustomerFilterModelPaged : CustomerFilterModel, ICloneable
    {
        /// <summary>
        /// Property for Page No.
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// Property to Limit no. of records in a page
        /// </summary>
        public int Limit { get; set; }

        /// <summary>
        /// COnstructor to initialise the Paging properties
        /// </summary>
        public CustomerFilterModelPaged() : base()
        {
            this.Page = 1;
            this.Limit = 10;
        }


        /// <summary>
        /// For deep copy
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            var jsonString = JsonConvert.SerializeObject(this);
            return JsonConvert.DeserializeObject(jsonString, this.GetType());
        }

    }
}
