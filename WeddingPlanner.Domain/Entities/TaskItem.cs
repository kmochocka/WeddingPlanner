using System.ComponentModel.DataAnnotations;
using WeddingPlanner.SharedKernel;

namespace WeddingPlanner.Domain.Entities;

public class TaskItem : Entity
{
    [Required(ErrorMessage = "Tytu³ zadania jest wymagany")]
    [StringLength(200)]
    public string Title { get; set; } = string.Empty;

    public bool IsCompleted { get; set; }

    public string? AssignedPerson { get; set; }

    public DateTime? DueDate { get; set; }
}