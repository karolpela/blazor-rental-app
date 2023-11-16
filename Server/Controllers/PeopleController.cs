using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentalApp.Server.Data;
using RentalApp.Shared.Models;

// ReSharper disable All

namespace RentalApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly RentalAppContext _context;

        public PeopleController(RentalAppContext context)
        {
            _context = context;
        }

        // GET: api/People
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> GetPeople([FromQuery] string? role,
            [FromQuery] string? sort = "id")
        {
            if (_context.People == null)
            {
                return NotFound();
            }

            IQueryable<Person> query = _context.People;

            if (!string.IsNullOrWhiteSpace(role))
            {
                var roleFilterResult = ApplyRoleFilter(query, role);
                if (roleFilterResult.Result is BadRequestObjectResult)
                {
                    return roleFilterResult.Result;
                }

                query = roleFilterResult.Query ?? query;
            }

            if (!string.IsNullOrEmpty(sort))
            {
                var sortResult = ApplySort(query, sort);
                if (sortResult.Result is BadRequestObjectResult)
                {
                    return sortResult.Result;
                }

                query = sortResult.Query ?? query;
            }

            return await query.ToListAsync();
        }

        private (IQueryable<Person>? Query, ActionResult? Result) ApplyRoleFilter(IQueryable<Person> query, string role)
        {
            var roles = role.Split('+')
                .Select(r => Enum.TryParse<PersonRole>(r, true, out var result) ? result : (PersonRole?)null)
                .ToList();

            if (roles.Any(r => r == null))
            {
                return (null, BadRequest(new { message = "One or more invalid roles" }));
            }

            PersonRole? combinedRoles = roles.Aggregate((current, next) => current | next!.Value);

            query = query.Where(p => (p.Role & combinedRoles) == combinedRoles);

            return (query, null);
        }

        private (IQueryable<Person>? Query, ActionResult? Result) ApplySort(IQueryable<Person> query, string sort)
        {
            switch (sort.ToLower())
            {
                case "id":
                    query = query.OrderBy(p => p.Id);
                    break;
                case "firstname":
                    query = query.OrderBy(p => p.FirstName);
                    break;
                case "lastname":
                    query = query.OrderBy(p => p.LastName);
                    break;
                case "role":
                    query = query.OrderBy(p => p.Role);
                    break;
                case "phonenumber":
                    query = query.OrderBy(p => p.PhoneNumber);
                    break;
                default:
                    return (null, BadRequest(new { message = "Invalid sort parameter" }));
            }

            return (query, null);
        }

        // GET: api/People/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetPerson(int id)
        {
            if (_context.People == null)
            {
                return NotFound();
            }

            var person = await _context.People.FindAsync(id);

            if (person == null)
            {
                return NotFound();
            }

            return person;
        }

        // PUT: api/People/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPerson(int id, Person person)
        {
            if (id != person.Id)
            {
                return BadRequest();
            }

            _context.Entry(person).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonExists(id))
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

        // POST: api/People
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Person>> PostPerson(Person person)
        {
            // Input validation
            if ((person.Role & PersonRole.Client) == PersonRole.Client)
            {
                // Person is a client
                if (string.IsNullOrEmpty(person.PhoneNumber))
                {
                    return BadRequest(new { message = "PhoneNumberRequired" });
                }

                // Check if PhoneNumber is unique
                var exists = await _context.People.AnyAsync(p => p.PhoneNumber == person.PhoneNumber);
                if (exists)
                {
                    return BadRequest(new { message = "PhoneNumberNotUnique" });
                }
            }

            if ((person.Role & PersonRole.Attendant) == PersonRole.Attendant
                || (person.Role & PersonRole.Mechanic) == PersonRole.Mechanic
                || (person.Role & PersonRole.Owner) == PersonRole.Owner)
            {
                // Person is an attendant, mechanic or owner
                if (string.IsNullOrEmpty(person.EmployeeId))
                {
                    return BadRequest(new
                        { message = "EmpIdRequired" });
                }

                // Check if EmployeeId is unique
                var exists = await _context.People.AnyAsync(p => p.EmployeeId == person.EmployeeId);
                if (exists)
                {
                    return BadRequest(new { message = "EmpIdNotUnique" });
                }
            }

            try
            {
                if (_context.People == null)
                {
                    return Problem("Entity set 'RentalAppContext.People' is null.");
                }

                _context.People.Add(person);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                // Generic error message, in case another type of DbUpdateException occurs.
                return BadRequest(new { message = "Could not create person. An error occurred." });
            }

            return CreatedAtAction("GetPerson", new { id = person.Id }, person);
        }


        // DELETE: api/People/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson(int id)
        {
            if (_context.People == null)
            {
                return NotFound();
            }

            var person = await _context.People.FindAsync(id);
            if (person == null)
            {
                return NotFound();
            }

            _context.People.Remove(person);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PersonExists(int id)
        {
            return (_context.People?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}