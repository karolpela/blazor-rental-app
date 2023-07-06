using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentalApp.Server.Data;
using RentalApp.Shared.Converters;
using RentalApp.Shared.Models.Equipment;

namespace RentalApp.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EquipmentController : ControllerBase
{
    private readonly RentalAppContext _context;

    private readonly JsonSerializerOptions _serializerOptions;

    public EquipmentController(RentalAppContext context)
    {
        _context = context;
        _serializerOptions = new JsonSerializerOptions
        {
            WriteIndented = true
        };
        _serializerOptions.Converters.Add(new SportsEquipmentConverter());
    }

    // GET: api/Equipment
    [HttpGet]
    public async Task<ActionResult<IEnumerable<SportsEquipment>>> GetEquipment(bool availableOnly = false)
    {
        if (_context.Equipment == null) return NotFound();

        IQueryable<SportsEquipment> query = _context.Equipment;

        if (availableOnly)
            // An assumpion is made here that not every client will return the equipment on time,
            // so only the equipment available right now will be of use, as bookings for the future
            // may lead to cancellations and, in consequence, to unhappy customers.
            query = _context.Equipment
                .Include(se => se.Rentals)
                .Where(se => se.Rentals.All(r => r.EndDate != null));

        return await query.ToListAsync();
    }

    // GET: api/Equipment/5
    [HttpGet("{id}")]
    public async Task<ActionResult<SportsEquipment>> GetSportsEquipment(int id)
    {
        if (_context.Equipment == null) return NotFound();

        var sportsEquipment = await _context.Equipment.FindAsync(id);

        if (sportsEquipment == null) return NotFound();

        return sportsEquipment;
    }

    // PUT: api/Equipment/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    // [HttpPut("{id}")]
    // public async Task<IActionResult> PutSportsEquipment(int id, SportsEquipment sportsEquipment)
    // {
    //     if (id != sportsEquipment.Id)
    //     {
    //         return BadRequest();
    //     }
    //
    //     _context.Entry(sportsEquipment).State = EntityState.Modified;
    //
    //     try
    //     {
    //         await _context.SaveChangesAsync();
    //     }
    //     catch (DbUpdateConcurrencyException)
    //     {
    //         if (!SportsEquipmentExists(id))
    //         {
    //             return NotFound();
    //         }
    //         else
    //         {
    //             throw;
    //         }
    //     }
    //
    //     return NoContent();
    // }

    // POST: api/Equipment
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    // [HttpPost]
    // public async Task<ActionResult<SportsEquipment>> PostSportsEquipment(SportsEquipment sportsEquipment)
    // {
    //     if (_context.Equipment == null)
    //     {
    //         return Problem("Entity set 'RentalAppContext.Equipment'  is null.");
    //     }
    //
    //     _context.Equipment.Add(sportsEquipment);
    //     await _context.SaveChangesAsync();
    //
    //     return CreatedAtAction("GetSportsEquipment", new { id = sportsEquipment.Id }, sportsEquipment);
    // }

    // DELETE: api/Equipment/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSportsEquipment(int id)
    {
        var sportsEquipment = await _context.Equipment.FindAsync(id);
        if (sportsEquipment == null) return NotFound();

        _context.Equipment.Remove(sportsEquipment);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool SportsEquipmentExists(int id)
    {
        return (_context.Equipment?.Any(e => e.Id == id)).GetValueOrDefault();
    }
}