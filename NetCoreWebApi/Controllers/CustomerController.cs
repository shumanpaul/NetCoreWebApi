using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetCoreWebApi.Models;
using System;
using NetCoreWebApi.DBContext;
using NetCoreWebApi.Filter;

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
                _context.CustomerList.Add(new Customer { FirstName = "Nancy", LastName = "Davolio", DateOfBirth = System.DateTime.Now.Date.AddYears(-20) });
                _context.CustomerList.Add(new Customer { FirstName = "Andrew", LastName = "Fuller", DateOfBirth = DateTime.Parse("1963-08-30") });
                _context.CustomerList.Add(new Customer { FirstName = "Janet", LastName = "Leverling", DateOfBirth = DateTime.Parse("1937-09-19") });
                _context.CustomerList.Add(new Customer { FirstName = "Margaret", LastName = "Peacock", DateOfBirth = DateTime.Parse("1955-03-04") });
                _context.CustomerList.Add(new Customer { FirstName = "Steven", LastName = "Buchanan", DateOfBirth = DateTime.Parse("1963-07-02") });
                _context.CustomerList.Add(new Customer { FirstName = "Michael", LastName = "Suyama", DateOfBirth = DateTime.Parse("1960-05-29") });
                _context.CustomerList.Add(new Customer { FirstName = "Robert", LastName = "King", DateOfBirth = DateTime.Parse("1958-01-09") });
                _context.CustomerList.Add(new Customer { FirstName = "Laura", LastName = "Callahan", DateOfBirth = DateTime.Parse("1966-01-27") });
                _context.CustomerList.Add(new Customer { FirstName = "Anne", LastName = "Dodsworth", DateOfBirth = DateTime.Parse("1948-12-08") });
                _context.SaveChanges();
            }
        }

        // GET api/customer/version
        [HttpGet("version")]
        public string Version()
        {
            return "Version 1.0.0";
        }

        //// GET: api/Customer
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Customer>>> GetCustomerList()
        //{
        //    return await _context.CustomerList.ToListAsync();
        //}

        // GET api/customer  
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomerListAsync([FromQuery] CustomerFilterModel filter)
        {

            //Filtering logic  
            Func<CustomerFilterModel, IEnumerable<Customer>> filterData = (filterModel) =>
            {
                return _context.CustomerList.Where(p => p.FirstName.Contains(filterModel.FirstName ?? String.Empty, StringComparison.InvariantCultureIgnoreCase)
                &&
                p.LastName.Contains(filterModel.LastName ?? String.Empty, StringComparison.InvariantCultureIgnoreCase)
                );

            };           
            
            //Filter Data
           var result = filterData(filter);
           return await Task.FromResult(result.ToList());
        }


        // GET api/customer/paged  
        [HttpGet("Paged")]
        public ActionResult<PagedCollectionResponse<Customer>> GetCustomerListPaged([FromQuery] CustomerFilterModelPaged filter)
        {

            //Filtering logic  
            Func<CustomerFilterModelPaged, IEnumerable<Customer>> filterData = (filterModel) =>
            {
                return _context.CustomerList.Where(p => p.FirstName.Contains(filterModel.FirstName ?? String.Empty, StringComparison.InvariantCultureIgnoreCase)
                &&
                p.LastName.Contains(filterModel.LastName ?? String.Empty, StringComparison.InvariantCultureIgnoreCase)
                )
                .Skip((filterModel.Page - 1) * filter.Limit)
                .Take(filterModel.Limit);
            };

            //Get the data for the current page  
            var result = new PagedCollectionResponse<Customer>();
            result.Items = filterData(filter);

            //Get next page URL string  
            CustomerFilterModelPaged nextFilter = filter.Clone() as CustomerFilterModelPaged;
            nextFilter.Page += 1;
            String nextUrl = filterData(nextFilter).Count() <= 0 ? null : this.Url.Action("GetCustomerListPaged", null, nextFilter, Request.Scheme);

            //Get previous page URL string  
            CustomerFilterModelPaged previousFilter = filter.Clone() as CustomerFilterModelPaged;
            previousFilter.Page -= 1;
            String previousUrl = previousFilter.Page <= 0 ? null : this.Url.Action("GetCustomerListPaged", null, previousFilter, Request.Scheme);

            result.NextPage = !String.IsNullOrWhiteSpace(nextUrl) ? new Uri(nextUrl) : null;
            result.PreviousPage = !String.IsNullOrWhiteSpace(previousUrl) ? new Uri(previousUrl) : null;

            return result;

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

