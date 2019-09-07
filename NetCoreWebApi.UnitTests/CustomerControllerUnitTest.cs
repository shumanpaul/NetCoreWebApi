using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetCoreWebApi.Controllers;
using NetCoreWebApi.Filter;
using NetCoreWebApi.Models;
using Xunit;
using ViewResult = Microsoft.AspNetCore.Mvc.ViewResult;

namespace NetCoreWebApi.UnitTests
{
    public class CustomerControllerUnitTest
    {
        /// <summary>
        /// Test Get Method
        /// </summary>
        /// <returns></returns>
        [Fact]
        public void TestGetCustomers()
        {
            // Arrange
            var dbContext = CustomerDbContextMocker.GetCustomerDBContext(nameof(TestGetCustomers));
            var controller = new CustomerController(dbContext);

            // Act
            var response = controller.GetCustomerList(new CustomerFilterModel());
            dbContext.Dispose();

            // Assert
            Assert.NotNull(response.Value.Items);
        }

        /// <summary>
        /// Test Get by ID Method
        /// </summary>
        /// <returns></returns>
        [Fact]

        public async Task TestGetCustomerByIdAsync()
        {
            // Arrange
            var dbContext = CustomerDbContextMocker.GetCustomerDBContext(nameof(TestGetCustomerByIdAsync));
            var controller = new CustomerController(dbContext);
            var id = RandomNumber(int.MaxValue);
            var request = new Customer
            {
                Id = id,
                FirstName = "Shuman",
                LastName = "Castellino",
                DateOfBirth = System.DateTime.Now.AddYears(-20).Date
            };

            //Act
            var postResponse = await controller.PostCustomer(request);
            var response = await controller.GetCustomer(id);            

            dbContext.Dispose();

            // Assert
            Assert.NotNull(response.Value);
            //var actionResult = Assert.IsType<ActionResult<Customer>>(response.Value);
            //Assert.IsType<NotFoundObjectResult>(actionResult.Result);

        }

        /// <summary>
        /// Test Post Method
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task TestPostCustomerAsync()
        {
            // Arrange
            var dbContext = CustomerDbContextMocker.GetCustomerDBContext(nameof(TestPostCustomerAsync));
            var controller = new CustomerController(dbContext);            
            var id = RandomNumber(int.MaxValue);

            var request = new Customer
            {
                Id = id,
                FirstName = "Shuman",
                LastName = "Paul",
                DateOfBirth = System.DateTime.Now.AddYears(-20).Date            };

            //Act
            var response = await controller.PostCustomer(request);

            dbContext.Dispose();

            // Assert
            Assert.IsType<CreatedAtActionResult>(response.Result);
        }

        /// <summary>
        /// Test Put Method
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task TestPutCustomerAsync()
        {
            // Arrange
            var dbContext = CustomerDbContextMocker.GetCustomerDBContext(nameof(TestPutCustomerAsync));
            var controller = new CustomerController(dbContext);
            var id = RandomNumber(int.MaxValue);
            var request = new Customer
            {
                Id = id,
                FirstName = "Shuman",
                LastName = "Castellino",
                DateOfBirth = System.DateTime.Now.AddYears(-20).Date
            };

            //Act
            var postResponse = await controller.PostCustomer(request);

            dbContext.Dispose();
            dbContext = CustomerDbContextMocker.GetCustomerDBContext(nameof(TestPutCustomerAsync));
            controller = new CustomerController(dbContext);

            var modifiedRequest = new Customer
            {
                Id = id,
                FirstName = "Shuman",
                LastName = "Castellino",
                DateOfBirth = System.DateTime.Now.AddYears(-20).Date
            };

            var response = await controller.PutCustomer(id, modifiedRequest);

            dbContext.Dispose();

            // Assert
            Assert.IsType<NoContentResult>(response);
        }

        /// <summary>
        /// Test Delete Method
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task TestDeleteCustomerAsync()
        {
            // Arrange
            var dbContext = CustomerDbContextMocker.GetCustomerDBContext(nameof(TestDeleteCustomerAsync));
            var controller = new CustomerController(dbContext);
            var id = RandomNumber(int.MaxValue);
            var request = new Customer
            {
                Id= id,
                FirstName = "Shuman",
                LastName = "Castellino",
                DateOfBirth = System.DateTime.Now.AddYears(-20).Date
            };

            //Act
            var postResponse = await controller.PostCustomer(request);
            var response = await controller.DeleteCustomer(id);

            dbContext.Dispose();

            // Assert
            Assert.IsType<NoContentResult>(response);
        }

        // Generate a random number
        public int RandomNumber(int max)
                {
                    Random random = new Random();
                    return random.Next(max);
                }
    }
}
