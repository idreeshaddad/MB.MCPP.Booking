using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MB.MCPP.BK.EfCore;
using MB.MCPP.BK.Entities;
using MB.MCPP.BK.Dtos.Bookings;
using AutoMapper;
using System.Security.Policy;

namespace MB.MCPP.BK.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        #region Data and Const

        private readonly BookingDbContext _context;
        private readonly IMapper _mapper;

        public BookingsController(BookingDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        #endregion

        #region Services

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookingListDto>>> GetBookings()
        {
            var bookings = await _context
                                    .Bookings
                                    .Include(b => b.Villa)
                                    .Include(b => b.Customer)
                                    .ToListAsync();

            var bookingDtos = _mapper.Map<List<BookingListDto>>(bookings);

            return bookingDtos;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookingDetailsDto>> GetBooking(int id)
        {
            var booking = await _context
                                    .Bookings
                                    .Include(b => b.Villa)
                                    .Include(b => b.Customer)
                                    .SingleOrDefaultAsync(b => b.Id == id);

            if (booking == null)
            {
                return NotFound();
            }

            var bookingDetailsDto = _mapper.Map<BookingDetailsDto>(booking);

            return bookingDetailsDto;
        }

        [HttpPost]
        public async Task<ActionResult> CreateBooking(BookingDto bookingDto)
        {
            var booking = _mapper.Map<Booking>(bookingDto);

            booking.TotalPrice = await GetBookingPrice(bookingDto.VillaId);

            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditBooking(int id, BookingDto bookingDto)
        {
            if (id != bookingDto.Id)
            {
                return BadRequest();
            }

            var booking = _mapper.Map<Booking>(bookingDto);
            booking.TotalPrice = await GetBookingPrice(bookingDto.VillaId);

            _context.Entry(booking).State = EntityState.Modified;
            // _context.Update(booking); those two do the same thing

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookingExists(id))
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
 
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            if (booking == null)
            {
                return NotFound();
            }

            _context.Bookings.Remove(booking);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        #endregion

        #region Private

        private bool BookingExists(int id)
        {
            return _context.Bookings.Any(e => e.Id == id);
        }

        private async Task<double> GetBookingPrice(int villaId)
        {
            var villa = await _context
                                .Villas
                                .Include(v => v.Addons)
                                .SingleAsync(v => v.Id == villaId);

            var totalPrice = villa.Price;

            totalPrice += villa.Addons.Sum(a => a.Price);

            return totalPrice;
        }

        #endregion
    }
}
