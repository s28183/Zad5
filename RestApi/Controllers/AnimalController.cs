using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using RestApi.Models;

namespace RestApi.Controllers;

[Route("api/animals")]
[ApiController]
public class AnimalController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAnimals()
    {
        return Ok(DataBase.Animals);
    }

    [HttpGet("{id:int}")]
    public IActionResult GetAnimal(int id)
    {
        var animal = DataBase.Animals.FirstOrDefault(a => a.IdAnimal == id);
        if (animal == null)
        {
            return NotFound("Nie znaleziono zwierzęcia o id: " + id);
        }

        return Ok(animal);
    }

    [HttpPost]
    public IActionResult CreateAnimal(Animal animal)
    {
        DataBase.Animals.Add(animal);
        return CreatedAtAction(nameof(GetAnimal), new { id = animal.IdAnimal }, animal);
    }

    [HttpPut("{id:int}")]
    public IActionResult UpdateAnimal(int id, Animal updatedAnimal)
    {
        var animalToEdit = DataBase.Animals.FirstOrDefault(a => a.IdAnimal == id);
        if (animalToEdit == null)
        {
            return NotFound("Nie znaleziono zwierzęcia o id: " + id);
        }
        animalToEdit.Name = "Automatyczny";
        animalToEdit.Category = "Automatyczny";
        animalToEdit.Weight = 1;
        animalToEdit.FurColor = "Automatyczny";

        return NoContent();
    }
    
    [HttpDelete("{id:int}")]
    public IActionResult DeleteAnimal(int id)
    {
        var animalToDelete = DataBase.Animals.FirstOrDefault(a => a.IdAnimal == id);
        if (animalToDelete == null)
        {
            return NotFound("Nie znaleziono zwierzęcia o id: " + id);
        }

        DataBase.Animals.Remove(animalToDelete);
        return NoContent();
    }
}