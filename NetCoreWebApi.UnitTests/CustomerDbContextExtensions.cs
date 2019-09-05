﻿using System;
using NetCoreWebApi.Models;

namespace NetCoreWebApi.UnitTests
{
    public static class CustomerDbContextExtensions
    {
        public static void Seed(this CustomerDBContext dbContext)
        {
            dbContext.CustomerList.Add(new Customer { Id = 1, FirstName = "John", LastName = "Smith", DateOfBirth = System.DateTime.Now.Date });
            dbContext.SaveChanges();

        }
    }
}