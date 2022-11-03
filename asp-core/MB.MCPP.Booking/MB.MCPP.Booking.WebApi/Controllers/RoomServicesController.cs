using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MB.MCPP.BK.EfCore;
using MB.MCPP.BK.Entities;

namespace MB.MCPP.BK.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RoomServicesController : ControllerBase
    {
        #region Data and Const

        private readonly BookingDbContext _context;

        public RoomServicesController(BookingDbContext context)
        {
            _context = context;
        }

        #endregion

        #region Services

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomService>>> GetRoomServices()
        {
            return await _context.RoomServices.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RoomService>> GetRoomService(int id)
        {
            var roomService = await _context.RoomServices.FindAsync(id);

            if (roomService == null)
            {
                return NotFound();
            }

            return roomService;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoomService(int id, RoomService roomService)
        {
            if (id != roomService.Id)
            {
                return BadRequest();
            }

            _context.Entry(roomService).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoomServiceExists(id))
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
        public async Task<ActionResult<RoomService>> PostRoomService(RoomService roomService)
        {
            _context.RoomServices.Add(roomService);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRoomService", new { id = roomService.Id }, roomService);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoomService(int id)
        {
            var roomService = await _context.RoomServices.FindAsync(id);
            if (roomService == null)
            {
                return NotFound();
            }

            _context.RoomServices.Remove(roomService);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        #endregion

        #region Private
        private bool RoomServiceExists(int id)
        {
            return _context.RoomServices.Any(e => e.Id == id);
        }

        #endregion
    }
}
