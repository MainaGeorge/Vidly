using System.Collections.Generic;
using System.Linq;
using System.Net;
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
        public IEnumerable<CustomerDto> GetCustomers()
        {
            return _context.Customers.ToList().Select(Mapper.Map<Customer, CustomerDto>);
        }

        [HttpGet]
        public CustomerDto GetCustomer(int id)
        {
            var customer = _context.Customers.Find(id);

            if (customer == null)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var customerDto = Mapper.Map<Customer, CustomerDto>(customer);
            return customerDto;
        }

        [HttpPost]
        public CustomerDto PostCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);

            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDto.Id = customer.Id;

            return customerDto;
        }

        [HttpPut]
        public void UpdateCustomer(int id, CustomerDto customerDto)
        {
            var customerFromDb = _context.Customers.Find(id);

            if (customerFromDb == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            Mapper.Map(customerDto, customerFromDb);

            _context.SaveChanges();

        }

        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var customerFromDb = _context.Customers.Find(id);

            if (customerFromDb == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _context.Customers.Remove(customerFromDb);

            _context.SaveChanges();
        }
    }
}
