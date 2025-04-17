namespace apbd_cw6.Models;

public class Visit
{
    public DateTime DateOfVisit { get; set; }
    public int AnimalId { get; set; }
    public string? Description { get; set; }
    public double Price { get; set; }

    public override int GetHashCode()
    {
        return HashCode.Combine
        (
            this.DateOfVisit.GetHashCode(),
            this.AnimalId.GetHashCode(),
            this.Description is not null ? this.Description.GetHashCode() : 0,
            this.Price.GetHashCode()
        );
    }

    public override bool Equals(object? obj)
    {
        if (obj is Visit other) return this.GetHashCode() == other.GetHashCode();
        else return false;
    }
}
