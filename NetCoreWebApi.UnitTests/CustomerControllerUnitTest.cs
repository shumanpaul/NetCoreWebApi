using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetCoreWebApi.Controllers;
using Xunit;

namespace NetCoreWebApi.UnitTests
{
    public class CustomerControllerUnitTest
    {
        /// <summary>
        /// Test Get Method
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task TestGetCustomersAsync()
        {
            // Arrange
            var dbContext = CustomerDbContextMocker.GetCustomerDBContext(nameof(TestGetCustomersAsync));
            var controller = new CustomerController(dbContext);

            // Act            
            dbContext.Dispose();

            // Assert
            Assert.Equal(3,2);
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

            // Act            
            dbContext.Dispose();

            // Assert
            Assert.Equal(3, 2);
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

            // Act            
            dbContext.Dispose();

            // Assert
            Assert.Equal(3, 2);
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

            // Act            
            dbContext.Dispose();

            // Assert
            Assert.Equal(3, 2);
        }
    }
}
