using System.ComponentModel.DataAnnotations;

public class Table
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Nazwa sto³u jest wymagana")]
    public string Name { get; set; } = "";

    [Required]
    public string Shape { get; set; } = "Round";

    [Range(1, 20, ErrorMessage = "Stó³ musi pomieœciæ od 1 do 20 osób")]
    public int Capacity { get; set; } = 8;

    public double PositionX { get; set; }
    public double PositionY { get; set; }
}