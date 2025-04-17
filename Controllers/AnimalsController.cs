using Microsoft.AspNetCore.Mvc;
using apbd_cw6.Models;

namespace apbd_cw6.Controllers;

[ApiController]
[Route("[controller]")]
public class AnimalsController : ControllerBase
{
    internal static ISet<Animal> Animals { get; set; } = new HashSet<Animal>()
    {
        new() { Id = 1, Name = "Tofik", Category = "dog", Color = "golden", Weight = 7.5 },
        new() { Id = 2, Name = "Tosia", Category = "chinchilla", Color = "dark gray", Weight = 0.75 },
    };

    [HttpGet]
    public IActionResult GetAnimals(string? animalName)
    {
        return this.Ok(animalName is not null ? AnimalsController.Animals.Where(a => a.Name.Equals(animalName, StringComparison.CurrentCultureIgnoreCase)) : AnimalsController.Animals);
    }

    [HttpGet("{id}/visits")]
    public IActionResult GetAnimalsVisits(int id)
    {
        return this.Ok(VisitsController.Visits.Where(v => v.AnimalId == id));
    }

    [HttpGet("{id}")]
    public IActionResult GetAnimalById(int id)
    {
        var animal = AnimalsController.Animals.Where(a => a.Id == id).SingleOrDefault();

        return animal is not null ? this.Ok(animal) : this.NotFound();
    }

    [HttpPost]
    public IActionResult AddAnimal(string name, string category, string color, double weight)
    {
        Animal animal = new()
        {
            Id = AnimalsController.Animals.Select(a => a.Id).Max() + 1,
            Name = name, Category = category, Color = color, Weight = weight
        };

        AnimalsController.Animals.Add(animal);

        return this.CreatedAtAction(nameof(this.AddAnimal), animal);
    }

    [HttpPatch("{id}")]
    public IActionResult EditAnimalById(int id, string? name, string? category, string? color, double? weight)
    {
        var animal = AnimalsController.Animals.Where(a => a.Id == id).SingleOrDefault();

        if (animal is null) return this.BadRequest();

        if (name is not null) animal.Name = name;
        if (category is not null) animal.Category = category;
        if (color is not null) animal.Color = color;
        if (weight is not null) animal.Weight = (double)weight;

        return this.Ok(animal);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteAnimalById(int id)
    {
        var animal = AnimalsController.Animals.Where(a => a.Id == id).SingleOrDefault();

        if (animal is null) return this.BadRequest();

        return AnimalsController.Animals.Remove(animal) ? this.Ok(animal) : this.NotFound();
    }
}
