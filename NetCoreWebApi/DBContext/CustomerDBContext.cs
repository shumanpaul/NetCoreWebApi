using Microsoft.EntityFrameworkCore;
using NetCoreWebApi.Models;

namespace NetCoreWebApi.DBContext
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

        public DbSet<Customer> CustomerList { get; set; }
    }
}
