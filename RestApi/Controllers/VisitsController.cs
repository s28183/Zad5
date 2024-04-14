using Microsoft.AspNetCore.Mvc;
using RestApi.Models;

namespace RestApi.Controllers;

[Route("api/visits")]
[ApiController]
public class VisitsController : ControllerBase
{
    private static readonly List<Visit> _visits = new();

    [HttpGet]
    public IActionResult GetVisits()
    {
        return Ok(DataBase.Visits);
    }

    [HttpGet("animal/{animalId:int}")]
    public IActionResult GetVisitsForAnimal(int animalId)
    {
        var wizytyAnimals = DataBase.Visits.Where(v => v.AnimalId == animalId).ToList();
        if (!wizytyAnimals.Any())
        {
            return NotFound("Nie znaleziono wizyt dla id: " + animalId);
        }
        return Ok(wizytyAnimals);
    }

    [HttpPost]
    public IActionResult CreateVisit(Visit visit)
    {
        DataBase.Visits.Add(visit);
        return CreatedAtAction(nameof(GetVisits), new { id = visit.Id }, visit);
    }

    [HttpPut("{id:int}")]
    public IActionResult UpdateVisit(int id, Visit visit)
    {
        var wizytaEdit = DataBase.Visits.FirstOrDefault(v => v.Id == id);
        if (wizytaEdit == null)
        {
            return NotFound("Nie znaleziono dla id: " + id);
        }
        wizytaEdit.AnimalId = visit.AnimalId;
        wizytaEdit.Description = visit.Description;
        wizytaEdit.Price = visit.Price;
        wizytaEdit.Date = visit.Date;

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteVisit(int id)
    {
        var wizytaDelete = DataBase.Visits.FirstOrDefault(v => v.Id == id);
        if (wizytaDelete == null)
        {
            return NotFound("Nie znaleziono dla id: " + id);
        }
        DataBase.Visits.Remove(wizytaDelete);
        return NoContent();
    }
}
