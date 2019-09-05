using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreWebApi.Models
{
    /// <summary>
    /// Customer data model
    /// </summary>
    public class Customer
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //Store only the Date part of DateTime
        public DateTime DateOfBirth {
            get {
                return DateOfBirth;
            }
            set {
                DateOfBirth = value.Date;
            }
        }
    }
}
