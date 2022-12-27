using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MB.MCPP.BK.EfCore;
using MB.MCPP.BK.Entities;
using AutoMapper;
using MB.MCPP.BK.Dtos.Customers;
using FluentValidation;
using System;
using FluentValidation.Results;
using MB.MCPP.BK.Dtos.Lookups;
using MB.MCPP.BK.WebApi.Helpers.ImageUploader;

namespace MB.MCPP.BK.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        #region Data and Const

        private readonly BookingDbContext _context;
        private readonly IMapper _mapper;
        private readonly IImageUploader _fileUploader;

        public CustomersController(BookingDbContext context, IMapper mapper, IImageUploader fileUploader)
        {
            _context = context;
            _mapper = mapper;
            _fileUploader = fileUploader;
        }

        #endregion

        #region Services

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerListDto>>> GetCustomers()
        {
            var customers = await _context.Customers.ToListAsync();

            var customerDtos = _mapper.Map<List<CustomerListDto>>(customers);

            return customerDtos;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            var customer = await _context.Customers.FindAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            return customer;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditCustomer(int id, Customer customer)
        {
            if (id != customer.Id)
            {
                return BadRequest();
            }

            _context.Entry(customer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost, DisableRequestSizeLimit]
        public async Task<ActionResult> CreateCustomer(CustomerDto customerDto)
        {
            var customer = _mapper.Map<Customer>(customerDto);

            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCustomer", new { id = customer.Id }, customer);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        #endregion

        #region Lookups

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LookupDto>>> GetLookup()
        {
            var customerLookup = await _context
                                        .Customers
                                        .Select(customer => new LookupDto()
                                        {
                                            Value = customer.Id,
                                            Text = customer.FullName
                                        })
                                        .ToListAsync();

            return customerLookup;
        }

        #endregion

        #region Private
        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.Id == id);
        }

        #endregion
    }
}
