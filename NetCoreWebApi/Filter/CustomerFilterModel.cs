using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreWebApi.Filter
{
    /// <summary>
    /// Filter Model class for Customer
    /// </summary>
    public class CustomerFilterModel
    {
        /// <summary>
        /// FIlter Field for First Name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Filter Field for LastName
        /// </summary>
        public string LastName { get; set; }       

    }
}
