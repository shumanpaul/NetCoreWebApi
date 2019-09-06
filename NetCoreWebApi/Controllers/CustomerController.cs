using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetCoreWebApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

    /// <summary>
    /// Customer COntroller
    /// </summary>

namespace NetCoreWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerDBContext _context;

        public CustomerController(CustomerDBContext context)
        {
            _context = context;

            if (_context.CustomerList.Count() == 0)
            {
                // Create a new Customer if collection is empty,
                // which means you can't delete all Customers.
                _context.CustomerList.Add(new Customer { FirstName = "John", LastName = "Smith", DateOfBirth = System.DateTime.Now.Date.AddYears(-10) });
                _context.CustomerList.Add(new Customer { FirstName = "Smith", LastName = "John", DateOfBirth = System.DateTime.Now.Date.AddYears(-20) });
                _context.SaveChanges();
            }
        }

        // GET api/customer/version
        [HttpGet("version")]
        public string Version()
        {
            return "Version 1.0.0";
        }

        // GET: api/Customer
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomerList()
        {
            return await _context.CustomerList.ToListAsync();
        }

        // GET: api/Customer/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(long id)
        {
            var customer = await _context.CustomerList.FindAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            return customer;
        }

        // POST: api/Customer
        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
        {
            if (ModelState.IsValid)
            {

                _context.CustomerList.Add(customer);
                await _context.SaveChangesAsync();
            }

            return CreatedAtAction(nameof(GetCustomer), new { id = customer.Id }, customer);
        }

        // PUT: api/Customer/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(long id, Customer customer)
        {
            if (id != customer.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {

                _context.Entry(customer).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }

            return NoContent();
        }

        // DELETE: api/Customer/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(long id)
        {
            var customer = await _context.CustomerList.FindAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            _context.CustomerList.Remove(customer);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }

    //Default controller template 
    //[Route("api/[controller]")]
    //public class CustomerController : Controller
    //{
    //    // GET: api/<controller>
    //    [HttpGet]
    //    public IEnumerable<string> Get()
    //    {
    //        return new string[] { "value1", "value2" };
    //    }

    //    // GET api/<controller>/5
    //    [HttpGet("{id}")]
    //    public string Get(int id)
    //    {
    //        return "value";
    //    }

    //    // POST api/<controller>
    //    [HttpPost]
    //    public void Post([FromBody]string value)
    //    {
    //    }

    //    // PUT api/<controller>/5
    //    [HttpPut("{id}")]
    //    public void Put(int id, [FromBody]string value)
    //    {
    //    }

    //    // DELETE api/<controller>/5
    //    [HttpDelete("{id}")]
    //    public void Delete(int id)
    //    {
    //    }
}

