using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MB.MCPP.BK.EfCore;
using MB.MCPP.BK.Entities;
using MB.MCPP.BK.Dtos.Bookings;
using AutoMapper;

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

            booking.TotalPrice = await GetBookingPriceInternal(bookingDto.VillaId, booking.NumberOfDays);

            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookingDto>> GetEditBooking(int id)
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

            var bookingDetailsDto = _mapper.Map<BookingDto>(booking);

            return bookingDetailsDto;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditBooking(int id, BookingDto bookingDto)
        {
            if (id != bookingDto.Id)
            {
                return BadRequest();
            }

            var booking = _mapper.Map<Booking>(bookingDto);
            booking.TotalPrice = await GetBookingPriceInternal(bookingDto.VillaId, booking.NumberOfDays);

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

        [HttpGet]
        public async Task<ActionResult<double>> GetBookingPrice(int villaId, DateTime bookingStart, DateTime bookingEnd)
        {
            var numberOfDays = (bookingEnd - bookingStart).Days;
            var price = await GetBookingPriceInternal(villaId, numberOfDays);

            return price;
        }

        #endregion

        #region Private

        private bool BookingExists(int id)
        {
            return _context.Bookings.Any(e => e.Id == id);
        }

        private async Task<double> GetBookingPriceInternal(int villaId, int numberOfDays)
        {
            var villa = await _context
                                .Villas
                                .Include(v => v.Addons)
                                .SingleAsync(v => v.Id == villaId);

            var totalPrice = villa.Price * numberOfDays;

            totalPrice += villa.Addons.Sum(a => a.Price);

            return totalPrice;
        }

        #endregion
    }
}