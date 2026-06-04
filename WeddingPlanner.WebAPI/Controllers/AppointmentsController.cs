using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeddingPlanner.Domain.Entities;
using WeddingPlanner.Infrastructure.Persistence;

namespace WeddingPlanner.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AppointmentsController(AppDbContext context) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Appointment>>> GetAppointments() =>
        await context.Appointments.ToListAsync();

    [HttpPost]
    public async Task<ActionResult<Appointment>> PostAppointment(Appointment appointment)
    {
        context.Appointments.Add(appointment);
        await context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetAppointments), new { id = appointment.Id }, appointment);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> PutAppointment(int id, Appointment appointment)
    {
        if (id != appointment.Id) return BadRequest();
        context.Entry(appointment).State = EntityState.Modified;
        await context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteAppointment(int id)
    {
        var appointment = await context.Appointments.FindAsync(id);
        if (appointment is null) return NotFound();
        context.Appointments.Remove(appointment);
        await context.SaveChangesAsync();
        return NoContent();
    }
}
