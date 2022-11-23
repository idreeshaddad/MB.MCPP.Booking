using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MB.MCPP.BK.EfCore;
using MB.MCPP.BK.Entities;
using AutoMapper;
using MB.MCPP.BK.Dtos.Villas;

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
        public async Task<ActionResult<IEnumerable<VillaDto>>> GetVillas()
        {
            var villas = await _context.Villas.ToListAsync();

            var villaDtos = _mapper.Map<List<VillaDto>>(villas);

            return villaDtos;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VillaDto>> GetVilla(int id)
        {
            var villa = await _context
                                .Villas
                                .Include(villa => villa.AddOns)
                                .SingleAsync(villa => villa.Id == id);

            if (villa == null)
            {
                return NotFound();
            }

            var villaDto = _mapper.Map<VillaDto>(villa);
            villaDto.AddOnIds = villa.AddOns.Select(o => o.Id).ToList();

            return villaDto;
        }

        [HttpPost]
        public async Task<ActionResult> CreateVilla(VillaDto villaDto)
        {
            var villa = _mapper.Map<Villa>(villaDto);
            await AddAddOnsToVilla(villaDto.AddOnIds, villa);

            _context.Villas.Add(villa);
            await _context.SaveChangesAsync();

            villaDto.Id = villa.Id;

            return CreatedAtAction("GetVilla", new { id = villa.Id }, villaDto);
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

                await UpdateVillaAddOns(villaDto.AddOnIds, villaDto.Id);
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

        #region Private 

        private bool VillaExists(int id)
        {
            return _context.Villas.Any(e => e.Id == id);
        }

        private bool VillaNameExists(string villaName)
        {
            return _context.Villas.Any(v => v.Name == villaName);
        }

        private async Task AddAddOnsToVilla(List<int> addOnIds, Villa villa)
        {
            var addOns = await _context.AddOns.Where(a => addOnIds.Contains(a.Id)).ToListAsync();
            if (addOns.Any())
            {
                villa.AddOns.AddRange(addOns);
            }
        }

        private async Task UpdateVillaAddOns(List<int> addOnIds, int villaId)
        {
            var villa = await _context.Villas.Include(v => v.AddOns).SingleAsync(v => v.Id == villaId);
            villa.AddOns.Clear();

            var addOns = await _context.AddOns.Where(a => addOnIds.Contains(a.Id)).ToListAsync();
            if (addOns.Any())
            {
                villa.AddOns.AddRange(addOns);
            }
        }


        #endregion
    }
}
