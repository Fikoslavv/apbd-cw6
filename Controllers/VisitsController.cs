using Microsoft.AspNetCore.Mvc;
using apbd_cw6.Models;

namespace apbd_cw6.Controllers;

[ApiController]
[Route("[controller]")]
public class VisitsController : ControllerBase
{
    internal static ISet<Visit> Visits { get; set; } = new HashSet<Visit>();

    [HttpGet]
    public IActionResult GetVisitsByAnimalId(int? animalId)
    {
        return this.Ok(animalId is not null ? VisitsController.Visits.Where(a => a.AnimalId == animalId) : VisitsController.Visits);
    }

    [HttpPost]
    public IActionResult AddVisit(DateTime dateOfVisit, int animalId, string? description, double price)
    {
        if (!AnimalsController.Animals.Where(a => a.Id == animalId).Any()) return this.BadRequest();

        Visit visit = new()
        {
            DateOfVisit = dateOfVisit,
            AnimalId = animalId,
            Description = description,
            Price = price,
        };

        VisitsController.Visits.Add(visit);

        return this.Ok(visit);
    }
}
