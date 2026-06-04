namespace WeddingPlanner.SharedKernel.DTOs;

public class TableDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Shape { get; set; } = "Round";
    public int Capacity { get; set; }
    public double PositionX { get; set; }
    public double PositionY { get; set; }
}

public class CreateTableDto
{
    public string Name { get; set; } = string.Empty;
    public string Shape { get; set; } = "Round";
    public int Capacity { get; set; }
}