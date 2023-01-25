using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MB.MCPP.BK.EfCore;
using AutoMapper;
using MB.MCPP.BK.Dtos.Customers;
using MB.MCPP.BK.Dtos.Lookups;
using MB.MCPP.BK.WebApi.Helpers.ImageUploader;
using MB.MCPP.BK.Entities.Customers;
using MB.MCPP.BK.Dtos.Uploaders;
using MB.MCPP.BK.Entities.Villas;
using NuGet.Packaging;

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
        public async Task<ActionResult<CustomerDetailsDto>> GetCustomer(int id)
        {
            var customer = await _context
                                    .Customers
                                    .Include(customer => customer.Images)
                                    .SingleOrDefaultAsync(customer => customer.Id == id);
            if (customer == null)
            {
                return NotFound();
            }

            var customerDto = _mapper.Map<CustomerDetailsDto>(customer);

            return customerDto;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditCustomer(int id, CustomerDto customerDto)
        {
            if (id != customerDto.Id)
            {
                return BadRequest();
            }

            var customer = _mapper.Map<Customer>(customerDto);
            UpdateCustomerImage(customerDto.Images, id);

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

        [HttpPost]
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

        private async Task UpdateCustomerImage(List<UploaderImageDto> images, int id)
        {
            var customer = await _context.Customers.Include(c => c.Images).SingleAsync(c => c.Id == id);
            customer.Images.Clear();

            var customerImages = _mapper.Map<List<UploaderImageDto>, List<CustomerImage>>(images);

            customer.Images.AddRange(customerImages);
        }

        #endregion
    }
}
