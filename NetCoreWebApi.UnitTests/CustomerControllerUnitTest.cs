using System;
using System.Collections;
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
        #region Get
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
            var response = controller.GetCustomerListAsync(new CustomerFilterModel());
            dbContext.Dispose();

            // Assert
            Assert.NotNull(response.Result);
        }   

        /// <summary>
        /// Filter based on FIrst Name
        /// </summary>
        [Fact]
        public void TestGetCustomersFilterFirstName()
        {
            // Arrange
            var dbContext = CustomerDbContextMocker.GetCustomerDBContext(nameof(TestGetCustomersFilterFirstName));
            var controller = new CustomerController(dbContext);
            var filter = new CustomerFilterModel { FirstName = "Jo" };

            // Act
            var response = controller.GetCustomerListAsync(filter);
            dbContext.Dispose();

            // Assert
            Assert.NotNull(response.Result);            
        }

        /// <summary>
        /// Filter based on Last Name
        /// </summary>
        [Fact]
        public void TestGetCustomersFilterLastName()
        {
            // Arrange
            var dbContext = CustomerDbContextMocker.GetCustomerDBContext(nameof(TestGetCustomersFilterLastName));
            var controller = new CustomerController(dbContext);
            var filter = new CustomerFilterModel { LastName = "it" };

            // Act
            var response = controller.GetCustomerListAsync(filter);
            dbContext.Dispose();

            // Assert
            Assert.NotNull(response.Result);
        }

        /// <summary>
        /// Filter based on First Name and Last Name
        /// </summary>
        [Fact]
        public void TestGetCustomersFilterFirstAndLastName()
        {
            // Arrange
            var dbContext = CustomerDbContextMocker.GetCustomerDBContext(nameof(TestGetCustomersFilterFirstAndLastName));
            var controller = new CustomerController(dbContext);
            var filter = new CustomerFilterModel { FirstName = "Jo", LastName = "it" };

            // Act
            var response = controller.GetCustomerListAsync(filter);
            dbContext.Dispose();

            // Assert
            Assert.NotNull(response.Result);
        }

        /// <summary>
        /// Filter based on First Name and Last Name with no result
        /// </summary>
        [Fact]
        public void TestGetCustomersFilterFirstAndLastNameNoResult()
        {
            // Arrange
            var dbContext = CustomerDbContextMocker.GetCustomerDBContext(nameof(TestGetCustomersFilterFirstAndLastNameNoResult));
            var controller = new CustomerController(dbContext);
            var filter = new CustomerFilterModel { FirstName = "abc", LastName = "xyz" };

            // Act
            var response = controller.GetCustomerListAsync(filter);
            dbContext.Dispose();

            // Assert
            Assert.NotNull(response.Result);
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
        #endregion

        #region Post

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
        #endregion

        #region Put

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
        #endregion

        #region Delete

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
        #endregion

        // Generate a random number
        public int RandomNumber(int max)
        {
            Random random = new Random();
            return random.Next(max);
        }
    }
}
