using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentalApp.Server.Data;
using RentalApp.Shared.Models;

namespace RentalApp.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProtectiveGearController : ControllerBase
{
    private readonly RentalAppContext _context;

    public ProtectiveGearController(RentalAppContext context)
    {
        _context = context;
    }

    // GET: api/ProtectiveGear
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProtectiveGear>>> GetProtectiveGear(bool availableOnly = false)
    {
        if (_context.ProtectiveGear == null) return NotFound();

        IQueryable<ProtectiveGear> query = _context.ProtectiveGear;

        if (availableOnly)
            // An assumpion is made here that not every client will return the gear on time,
            // so only the gear available right now will be of use, as bookings for the future
            // may lead to cancellations and, in consequence, to unhappy customers.
            query = _context.ProtectiveGear
                .Include(se => se.Rentals)
                .Where(se => se.Rentals.All(r => r.EndDate != null));

        return await query.ToListAsync();
    }

    // GET: api/ProtectiveGear/5
    [HttpGet("{id}")]
    public async Task<ActionResult<ProtectiveGear>> GetProtectiveGear(int id)
    {
        if (_context.ProtectiveGear == null) return NotFound();
        var protectiveGear = await _context.ProtectiveGear.FindAsync(id);

        if (protectiveGear == null) return NotFound();

        return protectiveGear;
    }

    // PUT: api/ProtectiveGear/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutProtectiveGear(int id, ProtectiveGear protectiveGear)
    {
        if (id != protectiveGear.Id) return BadRequest();

        _context.Entry(protectiveGear).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ProtectiveGearExists(id))
                return NotFound();
            throw;
        }

        return NoContent();
    }

    // POST: api/ProtectiveGear
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<ProtectiveGear>> PostProtectiveGear(ProtectiveGear protectiveGear)
    {
        if (_context.ProtectiveGear == null) return Problem("Entity set 'RentalAppContext.ProtectiveGear'  is null.");
        _context.ProtectiveGear.Add(protectiveGear);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetProtectiveGear", new { id = protectiveGear.Id }, protectiveGear);
    }

    // DELETE: api/ProtectiveGear/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProtectiveGear(int id)
    {
        if (_context.ProtectiveGear == null) return NotFound();
        var protectiveGear = await _context.ProtectiveGear.FindAsync(id);
        if (protectiveGear == null) return NotFound();

        _context.ProtectiveGear.Remove(protectiveGear);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ProtectiveGearExists(int id)
    {
        return (_context.ProtectiveGear?.Any(e => e.Id == id)).GetValueOrDefault();
    }
}