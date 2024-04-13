using Microsoft.AspNetCore.Mvc;
using Tutorial4_AnimalData.database;
using Tutorial4_AnimalData.models;

namespace Tutorial4_AnimalData.controllers;
[ApiController]
[Route("[controller]")]
public class AnimalsController: ControllerBase
{
    private readonly MockDb _mockDb;

    public AnimalsController(MockDb mockDb)
    {
        _mockDb = mockDb;
    }
    [HttpGet("/api/animals")]
    public IActionResult GetAnimals()
    {
        //retrieve a list of animals
        //var animals = StaticData.animals;
        var animals = _mockDb.Animals;
        return Ok(animals);
    }
//FirstOrDefault - Returns the first element of a sequence, or a specified default value if the sequence contains no elements.

    // retrieve a specific animal by id
    [HttpGet("/api/animals/{id:int}")]
    public IActionResult GetAnomalsById(int id)
    {
        var animals= _mockDb.Animals.FirstOrDefault(a => a.id == id);
        return animals == null ? NotFound($"The Animal with {id} not found") : Ok();
    }
    
    //add an animal
    [HttpPost("/api/animals")]
    public IActionResult AddAnimal(Animal animal)
    {
        _mockDb.Animals.Add(animal);
        return StatusCode(StatusCodes.Status201Created);
    }

    [HttpPut("{/api/animals/{id:int}")]
    public IActionResult editAnimal(int id, Animal animal)
    {
        var animalToEdit = _mockDb.Animals.FirstOrDefault(a => a.id == id);
        if (animalToEdit == null)
        {
            return (IActionResult)Results.NotFound($"Animal with id {id} was not found");
        }
        _mockDb.Animals.Remove(animalToEdit);
        _mockDb.Animals.Add(animal);
        return NoContent();
    }

    [HttpDelete("/api/animals/{id:int}")]
    public IActionResult deleteAnimal(int id)
    {
        var animalToDelete = _mockDb.Animals.FirstOrDefault(a => a.id == id);
        if (animalToDelete == null)
        {
            return (IActionResult)Results.NoContent();
        }
        _mockDb.Animals.Remove(animalToDelete);
        return NoContent();
    }
    
    //retrieve a list of visits associated with a given animal
    [HttpGet("{id:int}/visits")]
    public IActionResult getVisits(int id)
    {
        var visitToAnimal = _mockDb.Visits.FirstOrDefault(a => a.id == id);
        return Ok(visitToAnimal);
    }
    
    //we would like to be able to add new visits
    [HttpPost("{id:int}/visits")]
    public IActionResult addVisit(Visit visit)
    {
        _mockDb.Visits.Add(visit);
        return StatusCode(StatusCodes.Status201Created);
    }
}