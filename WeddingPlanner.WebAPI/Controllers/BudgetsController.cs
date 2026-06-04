using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeddingPlanner.Domain.Entities;
using WeddingPlanner.Infrastructure.Persistence;

namespace WeddingPlanner.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BudgetsController(AppDbContext context) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<WeddingBudget>> GetBudget()
    {
        var budget = await context.Budgets.FirstOrDefaultAsync();
        if (budget is not null) return budget;

        budget = new WeddingBudget { TotalAmount = 0 };
        context.Budgets.Add(budget);
        await context.SaveChangesAsync();
        return budget;
    }

    [HttpPut]
    public async Task<IActionResult> UpdateBudget(WeddingBudget budget)
    {
        var existingBudget = await context.Budgets.FirstOrDefaultAsync();
        if (existingBudget is null) return NotFound();

        existingBudget.TotalAmount = budget.TotalAmount;
        await context.SaveChangesAsync();
        return Ok();
    }
}
