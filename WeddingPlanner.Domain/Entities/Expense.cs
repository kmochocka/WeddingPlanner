using System.ComponentModel.DataAnnotations;
using WeddingPlanner.SharedKernel;

namespace WeddingPlanner.Domain.Entities;

public class Expense : Entity
{
    [Required(ErrorMessage = "Nazwa wydatku jest wymagana")]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;

    [Range(0, 1000000, ErrorMessage = "Kwota nie mo¿e byæ ujemna")]
    public decimal Amount { get; set; }

    [Required(ErrorMessage = "Wybierz kategoriê")]
    public string Category { get; set; } = "Inne";

    public bool IsPaid { get; set; }
}