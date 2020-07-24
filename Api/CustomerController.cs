using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using AutoMapper;
using Vidly.DTOs;
using Vidly.Models;

namespace Vidly.Api
{
    public class CustomerController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpGet]
        [Route("api/customer")]
        public IHttpActionResult GetCustomers()
        {
            return Ok(_context.Customers
                .Include(c => c.MembershipType)
                .ToList()
                .Select(Mapper.Map<Customer, CustomerDto>));
        }

        [HttpGet]
        [Route("api/customer/{id}", Name = "GetCustomer")]
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers
                .Include(c => c.MembershipType)
                .FirstOrDefault(c => c.Id == id);

            if (customer == null)
                return BadRequest();

            var customerDto = Mapper.Map<Customer, CustomerDto>(customer);
            return Ok(customerDto);
        }

        [HttpPost]
        [Route("api/customer")]
        public IHttpActionResult PostCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);

            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDto.Id = customer.Id;

            return CreatedAtRoute("GetCustomer",
                new { id = customerDto.Id }, customerDto);
        }

        [HttpPut]
        [Route("api/customer/{id}")]
        public IHttpActionResult UpdateCustomer(int id, CustomerDto customerDto)
        {
            var customerFromDb = _context.Customers.Find(id);

            if (customerFromDb == null)
                return NotFound();

            Mapper.Map(customerDto, customerFromDb);

            _context.SaveChanges();
            return Ok();

        }

        [HttpDelete]
        [Route("api/customer/{id}")]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var customerFromDb = _context.Customers.Find(id);

            if (customerFromDb == null)
                return BadRequest();

            _context.Customers.Remove(customerFromDb);

            _context.SaveChanges();
            return Ok();
        }
    }
}
