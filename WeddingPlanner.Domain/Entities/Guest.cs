using System.ComponentModel.DataAnnotations;
using WeddingPlanner.SharedKernel;

namespace WeddingPlanner.Domain.Entities;

public class Guest : Entity
{
    [Required(ErrorMessage = "Imiê jest wymagane")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "Imiê musi mieæ od 2 do 50 znaków")]
    public string FirstName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Nazwisko jest wymagane")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "Nazwisko musi mieæ od 2 do 50 znaków")]
    public string LastName { get; set; } = string.Empty;

    public bool IsConfirmed { get; set; }
    public bool HasPlusOne { get; set; }
    public int? WeddingTableId { get; set; }
    public int? TableId { get; set; }
    public int? SeatNumber { get; set; }
    public int? SeatNumberPlusOne { get; set; }
}
