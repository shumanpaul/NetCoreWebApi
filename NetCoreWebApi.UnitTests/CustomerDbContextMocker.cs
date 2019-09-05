using System;
using Microsoft.EntityFrameworkCore;
using NetCoreWebApi.Models;


namespace NetCoreWebApi.UnitTests
{
    public static class CustomerDbContextMocker
    {
        public static CustomerDBContext GetCustomerDBContext(string dbName)
        {
            // Create options for DbContext instance
            var options = new DbContextOptionsBuilder<CustomerDBContext>()
                .UseInMemoryDatabase(databaseName: dbName)
                .Options;

            // Create instance of DbContext
            var dbContext = new CustomerDBContext(options);

            // Add entities in memory
            dbContext.Seed();

            return dbContext;
        }
    }
}
