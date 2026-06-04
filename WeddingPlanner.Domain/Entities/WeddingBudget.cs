using System.ComponentModel.DataAnnotations;
using WeddingPlanner.SharedKernel;

namespace WeddingPlanner.Domain.Entities;

public class WeddingBudget : Entity
{
    [Range(0, 10000000, ErrorMessage = "Kwota musi byæ dodatnia")]
    public decimal TotalAmount { get; set; }
}
