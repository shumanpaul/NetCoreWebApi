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
                _context.CustomerList.Add(new Customer { Id = 1, FirstName = "John", LastName = "Smith", DateOfBirth = System.DateTime.Now.Date });
                _context.SaveChanges();
            }
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

