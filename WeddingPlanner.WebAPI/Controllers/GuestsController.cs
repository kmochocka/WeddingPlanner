using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeddingPlanner.Domain.Entities;
using WeddingPlanner.Infrastructure.Persistence;

namespace WeddingPlanner.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GuestsController(AppDbContext context) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Guest>>> GetGuests() =>
        await context.Guests.ToListAsync();

    [HttpPost]
    public async Task<ActionResult<Guest>> PostGuest(Guest guest)
    {
        context.Guests.Add(guest);
        await context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetGuests), new { id = guest.Id }, guest);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> PutGuest(int id, Guest guest)
    {
        if (id != guest.Id) return BadRequest();
        context.Entry(guest).State = EntityState.Modified;
        await context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteGuest(int id)
    {
        var guest = await context.Guests.FindAsync(id);
        if (guest is null) return NotFound();
        context.Guests.Remove(guest);
        await context.SaveChangesAsync();
        return NoContent();
    }
}
