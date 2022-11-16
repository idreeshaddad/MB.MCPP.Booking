using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MB.MCPP.BK.EfCore;
using MB.MCPP.BK.Entities;
using AutoMapper;
using MB.MCPP.BK.Dtos.Rooms;

namespace MB.MCPP.BK.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        #region Data and Const

        private readonly BookingDbContext _context;
        private readonly IMapper _mapper;

        public RoomsController(BookingDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        #endregion

        #region Services

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomDto>>> GetRooms()
        {
            var rooms = await _context.Rooms.ToListAsync();

            var roomDtos = _mapper.Map<List<RoomDto>>(rooms);

            return roomDtos;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RoomDto>> GetRoom(int id)
        {
            var room = await _context
                                .Rooms
                                .Include(room => room.Services)
                                .SingleAsync(room => room.Id == id);

            if (room == null)
            {
                return NotFound();
            }

            var roomDto = _mapper.Map<RoomDto>(room);

            return roomDto;
        }

        [HttpPost]
        public async Task<ActionResult> CreateRoom(RoomDto roomDto)
        {
            var room = _mapper.Map<Room>(roomDto);

            _context.Rooms.Add(room);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRoom", new { id = room.Id }, room);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditRoom(int id, RoomDto roomDto)
        {
            if (id != roomDto.Id)
            {
                return BadRequest();
            }

            var room = _mapper.Map<Room>(roomDto);

            _context.Entry(room).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoomExists(id))
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
        public async Task<IActionResult> DeleteRoom(int id)
        {
            var room = await _context.Rooms.FindAsync(id);

            if (room == null)
            {
                return NotFound();
            }

            _context.Rooms.Remove(room);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        #endregion

        #region Private 
        private bool RoomExists(int id)
        {
            return _context.Rooms.Any(e => e.Id == id);
        }

        #endregion
    }
}
