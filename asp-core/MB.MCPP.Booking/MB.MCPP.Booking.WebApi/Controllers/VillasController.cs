using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MB.MCPP.BK.EfCore;
using AutoMapper;
using MB.MCPP.BK.Dtos.Villas;
using MB.MCPP.BK.Dtos.Lookups;
using MB.MCPP.BK.Entities.Villas;

namespace MB.MCPP.BK.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class VillasController : ControllerBase
    {
        #region Data and Const

        private readonly BookingDbContext _context;
        private readonly IMapper _mapper;

        public VillasController(BookingDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        #endregion

        #region Services

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VillaListDto>>> GetVillas()
        {
            var villas = await _context.Villas.ToListAsync();

            var villaDtos = _mapper.Map<List<VillaListDto>>(villas);

            return villaDtos;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VillaDetailsDto>> GetVilla(int id)
        {
            var villa = await _context
                                .Villas
                                .Include(villa => villa.Addons)
                                .Include(villa => villa.Images)
                                .SingleOrDefaultAsync(villa => villa.Id == id);

            if (villa == null)
            {
                return NotFound();
            }

            var villaDto = _mapper.Map<VillaDetailsDto>(villa);

            return villaDto;
        }

        [HttpPost]
        public async Task<ActionResult> CreateVilla(VillaDto villaDto)
        {
            var villa = _mapper.Map<Villa>(villaDto);
            await AddAddonsToVilla(villaDto.AddonIds, villa);

            _context.Villas.Add(villa);
            await _context.SaveChangesAsync();

            villaDto.Id = villa.Id;

            return CreatedAtAction("GetVilla", new { id = villa.Id }, villaDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VillaDto>> GetEditVilla(int id)
        {
            var villa = await _context
                                .Villas
                                .Include(villa => villa.Addons)
                                .SingleOrDefaultAsync(villa => villa.Id == id);

            if (villa == null)
            {
                return NotFound();
            }

            var villaDto = _mapper.Map<VillaDto>(villa);

            return villaDto;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditVilla(int id, VillaDto villaDto)
        {
            if (id != villaDto.Id)
            {
                return BadRequest();
            }

            var villa = _mapper.Map<Villa>(villaDto);
            _context.Entry(villa).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();

                await UpdateVillaAddons(villaDto.AddonIds, villaDto.Id);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VillaExists(id))
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
        public async Task<IActionResult> DeleteVilla(int id)
        {
            var villa = await _context.Villas.FindAsync(id);

            if (villa == null)
            {
                return NotFound();
            }

            _context.Villas.Remove(villa);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        #endregion

        #region Lookups

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LookupDto>>> GetLookup()
        {
            var villlookup = await _context
                                        .Villas
                                        .Select(villa => new LookupDto()
                                        {
                                            Value = villa.Id,
                                            Text = villa.Name
                                        })
                                        .ToListAsync();

            return villlookup;
        }

        #endregion

        #region Private 

        private bool VillaExists(int id)
        {
            return _context.Villas.Any(e => e.Id == id);
        }

        private bool VillaNameExists(string villaName)
        {
            return _context.Villas.Any(v => v.Name == villaName);
        }

        private async Task AddAddonsToVilla(List<int> addonIds, Villa villa)
        {
            var addons = await _context.Addons.Where(a => addonIds.Contains(a.Id)).ToListAsync();
            if (addons.Any())
            {
                villa.Addons.AddRange(addons);
            }
        }

        private async Task UpdateVillaAddons(List<int> addonIds, int villaId)
        {
            var villa = await _context.Villas.Include(v => v.Addons).SingleAsync(v => v.Id == villaId);
            villa.Addons.Clear();

            var addons = await _context.Addons.Where(a => addonIds.Contains(a.Id)).ToListAsync();
            if (addons.Any())
            {
                villa.Addons.AddRange(addons);
            }
        }


        #endregion
    }
}
