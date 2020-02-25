using Domain;
using Domain.SearchCriterias;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerRepository customerRepository;

        public CustomersController(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }


        // api/customers

        //[HttpGet]
        //public IActionResult Get()
        //{
        //    var customers = customerRepository.Get();

        //    return Ok(customers);

        //}

        // api/customers/10

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var customer = customerRepository.Get(id);

            return Ok(customer);
        }

        // api/customers/marcin

        [HttpGet("{login}")]
        public IActionResult Get(string login)
        {
            var customer = customerRepository.Get(login);

            return Ok(customer);
        }

      
        // api/customers/Lublin/Dworcowa

        [HttpGet("{city}/{street}")]
        public IActionResult Get(string city, string street)
        {
            throw new NotImplementedException();
        }


        // api/customers?city=Lublin&street=Dworcowa
        //[HttpGet]
        //public IActionResult GetByAddress(string city, string street)
        //{
        //    throw new NotImplementedException();
        //}

        // api/customers?city=Lublin&street=Dworcowa
        [HttpGet]
        public IActionResult GetByAddress([FromQuery] CustomerSearchCriteria criteria)
        {
            var customers = customerRepository.Get(criteria);

            return Ok(customers);
        }

        [HttpPost]
        public IActionResult Post(Customer customer)
        {
            customerRepository.Add(customer);

            return CreatedAtAction(nameof(GetById), new { Id = customer.Id }, customer);
        }

        // PUT /api/customers/10
        [HttpPut("{id}")]
        public IActionResult Put(int id, Customer customer)
        {
            if (id != customer.Id)
                return BadRequest();

            customerRepository.Update(customer);

            return NoContent();

        }

        // DELETE /api/customers/10
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            customerRepository.Remove(id);

            return NoContent();
        }

    }
}
