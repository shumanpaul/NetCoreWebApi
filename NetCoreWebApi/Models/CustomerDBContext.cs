using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace NetCoreWebApi.Models
{
    /// <summary>
    /// Database Conext Class to coordinate  Entity Framework functionality for Customer data model
    /// </summary>
    public class CustomerDBContext : DbContext
    {
        public CustomerDBContext(DbContextOptions<CustomerDBContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> TodoItems { get; set; }
    }
}
