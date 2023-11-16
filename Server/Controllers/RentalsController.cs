using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentalApp.Server.Data;
using RentalApp.Shared.Models;

namespace RentalApp.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RentalsController : ControllerBase
{
    private readonly RentalAppContext _context;

    public RentalsController(RentalAppContext context)
    {
        _context = context;
    }

    // GET: api/Rentals
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Rental>>> GetRentals(bool activeOnly = false)
    {
        if (_context.Rentals == null) return NotFound();

        IQueryable<Rental> query = _context.Rentals
            .Include(r => r.Client)
            .Include(r => r.Equipment)
            .Include(r => r.ProtectiveGear);

        if (activeOnly) query = query.Where(r => r.EndDate == null);

        return await query.ToListAsync();
    }

    // GET: api/Rentals/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Rental>> GetRental(int id)
    {
        if (_context.Rentals == null) return NotFound();

        var rental = await _context.Rentals.FindAsync(id);

        if (rental == null) return NotFound();

        return rental;
    }

    // PUT: api/Rentals/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutRental(int id, Rental rental)
    {
        if (id != rental.Id) return BadRequest();

        _context.Entry(rental).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!RentalExists(id))
                return NotFound();
            throw;
        }

        return NoContent();
    }

    // POST: api/Rentals
    [HttpPost]
    public async Task<ActionResult<Rental>> PostRental(Rental rental)
    {
        if (_context.Rentals == null) return Problem("Entity set 'RentalAppContext.Rentals'  is null.");

        // The entities are serialized in the JSON,
        // so they have to be attached before saving a Rental
        // in order to prevent EF from trying to insert existing objects
        _context.Equipment.Attach(rental.Equipment);
        _context.People.Update(rental.Client); // PESEL may be added
        foreach (var gear in rental.ProtectiveGear) _context.ProtectiveGear.Attach(gear);

        _context.Rentals.Add(rental);
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateException ex)
        {
            if (RentalExists(rental.Id)) return Conflict();

            return Problem("Failed to save the rental due to a database update exception: " + ex.Message);
        }

        return CreatedAtAction("GetRental", new { id = rental.Id }, rental);
    }

    // DELETE: api/Rentals/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRental(int id)
    {
        if (_context.Rentals == null) return NotFound();

        var rental = await _context.Rentals.FindAsync(id);
        if (rental == null) return NotFound();

        _context.Rentals.Remove(rental);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool RentalExists(int id)
    {
        return (_context.Rentals?.Any(e => e.Id == id)).GetValueOrDefault();
    }
}