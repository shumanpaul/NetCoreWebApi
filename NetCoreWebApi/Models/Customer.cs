using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreWebApi.Models
{
    /// <summary>
    /// Customer data model
    /// </summary>
    public class Customer
    {
        /// <summary>
        /// Id Unique Key
        /// </summary>
       public long Id { get; set; }


        /// <summary>
        /// First Name of Customer
        /// </summary>
        [StringLength(60, MinimumLength = 3)]
        [Display(Name = "First Name")]
        [Required]
        public string FirstName { get; set; }

        /// <summary>
        /// Last Name of Customer
        /// </summary>
        [StringLength(60, MinimumLength = 3)]
        [Display(Name = "Last Name")]
        [Required]
        public string LastName { get; set; }

        /// <summary>
        /// DOB of Customer
        /// </summary>
        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
    }
}
