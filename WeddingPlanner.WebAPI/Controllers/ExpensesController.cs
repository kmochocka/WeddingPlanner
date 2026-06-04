using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeddingPlanner.Domain.Entities;
using WeddingPlanner.Infrastructure.Persistence;

namespace WeddingPlanner.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExpensesController(AppDbContext context) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Expense>>> GetExpenses() =>
        await context.Expenses.ToListAsync();

    [HttpPost]
    public async Task<ActionResult<Expense>> PostExpense(Expense expense)
    {
        context.Expenses.Add(expense);
        await context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetExpenses), new { id = expense.Id }, expense);
    }

    [HttpGet("summary")]
    public async Task<ActionResult<object>> GetBudgetSummary()
    {
        var total = await context.Expenses.SumAsync(e => e.Amount);
        var paid = await context.Expenses.Where(e => e.IsPaid).SumAsync(e => e.Amount);
        return new { TotalCost = total, TotalPaid = paid, Remaining = total - paid };
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> PutExpense(int id, Expense expense)
    {
        if (id != expense.Id) return BadRequest();
        context.Entry(expense).State = EntityState.Modified;
        await context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteExpense(int id)
    {
        var expense = await context.Expenses.FindAsync(id);
        if (expense is null) return NotFound();
        context.Expenses.Remove(expense);
        await context.SaveChangesAsync();
        return NoContent();
    }
}
