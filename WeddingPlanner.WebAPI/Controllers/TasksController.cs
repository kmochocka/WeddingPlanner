using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeddingPlanner.Domain.Entities;
using WeddingPlanner.Infrastructure.Persistence;

namespace WeddingPlanner.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TasksController(AppDbContext context) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TaskItem>>> GetTasks() =>
        await context.Tasks.ToListAsync();

    [HttpPost]
    public async Task<ActionResult<TaskItem>> PostTask(TaskItem task)
    {
        context.Tasks.Add(task);
        await context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetTasks), new { id = task.Id }, task);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> PutTask(int id, TaskItem task)
    {
        if (id != task.Id) return BadRequest();
        context.Entry(task).State = EntityState.Modified;
        await context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteTask(int id)
    {
        var task = await context.Tasks.FindAsync(id);
        if (task is null) return NotFound();
        context.Tasks.Remove(task);
        await context.SaveChangesAsync();
        return NoContent();
    }
}
