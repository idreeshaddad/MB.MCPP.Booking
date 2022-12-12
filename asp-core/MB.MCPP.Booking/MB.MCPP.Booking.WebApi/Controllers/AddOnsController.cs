using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MB.MCPP.BK.EfCore;
using MB.MCPP.BK.Entities;
using AutoMapper;
using MB.MCPP.BK.Dtos.Addons;
using MB.MCPP.BK.Dtos.Lookups;

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
        public async Task<ActionResult<IEnumerable<AddonDto>>> GetAddons()
        {
            var addons = await _context.Addons.ToListAsync();
            var addonDtos = _mapper.Map<List<AddonDto>>(addons);
            return addonDtos;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Addon>> GetAddon(int id)
        {
            var addon = await _context.Addons.FindAsync(id);

            if (addon == null)
            {
                return NotFound();
            }

            return addon;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditAddon(int id, Addon addon)
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
        public async Task<ActionResult<Addon>> CreateAddon(Addon addon)
        {
            _context.Addons.Add(addon);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAddon", new { id = addon.Id }, addon);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAddon(int id)
        {
            var addon = await _context.Addons.FindAsync(id);
            if (addon == null)
            {
                return NotFound();
            }

            _context.Addons.Remove(addon);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        #endregion

        #region Lookups

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LookupDto>>> GetLookup()
        {
            var addonlookup = await _context
                                        .Addons
                                        .Select(addon => new LookupDto()
                                        {
                                            Value = addon.Id,
                                            Text = addon.Name
                                        })
                                        .ToListAsync();

            return addonlookup;
        }

        #endregion

        #region Private
        private bool AddonExists(int id)
        {
            return _context.Addons.Any(e => e.Id == id);
        }

        #endregion
    }
}
