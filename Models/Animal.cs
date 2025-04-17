namespace apbd_cw6.Models;

public class Animal
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public double Weight { get; set; }
    public string Color { get; set; } = string.Empty;

    public override bool Equals(object? obj)
    {
        if (obj is not Animal other) return false;
        else return this.Id == other.Id;
    }

    public override int GetHashCode()
    {
        return this.Id.GetHashCode();
    }
}
