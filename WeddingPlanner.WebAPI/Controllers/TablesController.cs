using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeddingPlanner.Domain.Entities;
using WeddingPlanner.Infrastructure.Persistence;

namespace WeddingPlanner.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TablesController(AppDbContext context) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Table>>> GetTables() =>
        await context.Tables.ToListAsync();

    [HttpPost]
    public async Task<ActionResult<Table>> PostTable(Table table)
    {
        context.Tables.Add(table);
        await context.SaveChangesAsync();
        return Ok(table);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> PutTable(int id, Table table)
    {
        if (id != table.Id) return BadRequest();
        context.Entry(table).State = EntityState.Modified;
        await context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteTable(int id)
    {
        var table = await context.Tables.FindAsync(id);
        if (table is null) return NotFound();
        context.Tables.Remove(table);
        await context.SaveChangesAsync();
        return NoContent();
    }
}
