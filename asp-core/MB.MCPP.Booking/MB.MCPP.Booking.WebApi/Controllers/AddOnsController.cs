using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MB.MCPP.BK.EfCore;
using MB.MCPP.BK.Entities;
using AutoMapper;
using MB.MCPP.BK.Dtos.AddOns;

namespace MB.MCPP.BK.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AddonsController : ControllerBase
    {
        #region Data and Const

        private readonly BookingDbContext _context;
        private readonly IMapper _mapper;

        public AddonsController(BookingDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        #endregion

        #region Services

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AddOnDto>>> GetAddons()
        {
            var addOns = await _context.AddOns.ToListAsync();
            var addOnDtos = _mapper.Map<List<AddOnDto>>(addOns);
            return addOnDtos;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AddOn>> GetAddon(int id)
        {
            var addon = await _context.AddOns.FindAsync(id);

            if (addon == null)
            {
                return NotFound();
            }

            return addon;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditAddon(int id, AddOn addon)
        {
            if (id != addon.Id)
            {
                return BadRequest();
            }

            _context.Entry(addon).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AddonExists(id))
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
        public async Task<ActionResult<AddOn>> CreateAddon(AddOn addon)
        {
            _context.AddOns.Add(addon);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAddon", new { id = addon.Id }, addon);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAddon(int id)
        {
            var addon = await _context.AddOns.FindAsync(id);
            if (addon == null)
            {
                return NotFound();
            }

            _context.AddOns.Remove(addon);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        #endregion

        #region Private
        private bool AddonExists(int id)
        {
            return _context.AddOns.Any(e => e.Id == id);
        }

        #endregion
    }
}
