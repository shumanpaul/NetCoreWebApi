using System;
using NetCoreWebApi.DBContext;
using NetCoreWebApi.Models;

namespace NetCoreWebApi.UnitTests
{
    public static class CustomerDbContextExtensions
    {
        public static void Seed(this CustomerDBContext dbContext)
        {
            dbContext.CustomerList.Add(new Customer { FirstName = "John", LastName = "Smith", DateOfBirth = System.DateTime.Now.Date.AddYears(-10) });
            dbContext.CustomerList.Add(new Customer { FirstName = "Nancy", LastName = "Davolio", DateOfBirth = System.DateTime.Now.Date.AddYears(-20) });
            dbContext.CustomerList.Add(new Customer { FirstName = "Andrew", LastName = "Fuller", DateOfBirth = DateTime.Parse("1963-08-30") });
            dbContext.CustomerList.Add(new Customer { FirstName = "Janet", LastName = "Leverling", DateOfBirth = DateTime.Parse("1937-09-19") });
            dbContext.CustomerList.Add(new Customer { FirstName = "Margaret", LastName = "Peacock", DateOfBirth = DateTime.Parse("1955-03-04") });
            dbContext.CustomerList.Add(new Customer { FirstName = "Steven", LastName = "Buchanan", DateOfBirth = DateTime.Parse("1963-07-02") });
            dbContext.CustomerList.Add(new Customer { FirstName = "Michael", LastName = "Suyama", DateOfBirth = DateTime.Parse("1960-05-29") });
            dbContext.CustomerList.Add(new Customer { FirstName = "Robert", LastName = "King", DateOfBirth = DateTime.Parse("1958-01-09") });
            dbContext.CustomerList.Add(new Customer { FirstName = "Laura", LastName = "Callahan", DateOfBirth = DateTime.Parse("1966-01-27") });
            dbContext.CustomerList.Add(new Customer { FirstName = "Anne", LastName = "Dodsworth", DateOfBirth = DateTime.Parse("1948-12-08") });

            dbContext.SaveChanges();

        }
    }
}
