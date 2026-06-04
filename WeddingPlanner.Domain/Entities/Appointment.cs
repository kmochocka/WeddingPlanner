using System.ComponentModel.DataAnnotations;
using WeddingPlanner.SharedKernel;

namespace WeddingPlanner.Domain.Entities;

public class Appointment : Entity
{
    [Required(ErrorMessage = "Tytu³ jest wymagany")]
    [StringLength(100, ErrorMessage = "Tytu³ jest za d³ugi")]
    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    [Required]
    public DateTime StartTime { get; set; }

    [Required]
    public DateTime EndTime { get; set; }

    public bool IsReminderSent { get; set; }
}