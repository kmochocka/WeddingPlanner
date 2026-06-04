namespace WeddingPlanner.SharedKernel.DTOs;

public class GuestDto
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public bool IsConfirmed { get; set; }
    public bool HasPlusOne { get; set; }
}

public class CreateGuestDto
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public bool HasPlusOne { get; set; }
}