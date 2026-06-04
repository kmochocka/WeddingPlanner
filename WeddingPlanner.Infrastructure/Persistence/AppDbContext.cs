using Microsoft.EntityFrameworkCore;
using WeddingPlanner.Domain.Entities;

namespace WeddingPlanner.Infrastructure.Persistence;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Guest> Guests => Set<Guest>();
    public DbSet<Expense> Expenses => Set<Expense>();
    public DbSet<TaskItem> Tasks => Set<TaskItem>();
    public DbSet<Appointment> Appointments => Set<Appointment>();
    public DbSet<WeddingBudget> Budgets => Set<WeddingBudget>();
    public DbSet<Table> Tables => Set<Table>();
}
