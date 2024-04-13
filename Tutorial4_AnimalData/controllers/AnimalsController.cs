using Microsoft.AspNetCore.Mvc;
using Tutorial4_AnimalData.database;
using Tutorial4_AnimalData.models;

namespace Tutorial4_AnimalData.controllers;
[ApiController]
[Route("[controller]")]
public class AnimalsController: ControllerBase
{
    // private readonly MockDb _mockDb;
    //
    //     public AnimalsController(MockDb _mockDb)
    // {
    //     this._mockDb = _mockDb;
    // }
    [HttpGet]
    public IActionResult GetAnimals()
    {
        //retrieve a list of animals
        //var animals = StaticData.animals;
        var animals = new MockDb().Animals;
        return Ok();
    }
//FirstOrDefault - Returns the first element of a sequence, or a specified default value if the sequence contains no elements.

    // retrieve a specific animal by id
    [HttpGet("{id}")]
    public IActionResult GetAnomalsById(int id)
    {
        var animals = new MockDb().Animals;
        animals.FirstOrDefault(s => s.id == id);
        return (IActionResult)(animals == null ? Results.NotFound($"The Animal with {id} not found") : Results.Ok());
    }
    
    //add an animal
    [HttpPost("/animal")]
    public IActionResult AddAnimal(Animal animal)
    {
        var animals = new MockDb().Animals;
        animals.Add(animal);
        return (IActionResult)Results.StatusCode(StatusCodes.Status201Created);
    }

    [HttpPut("{/api/animals/{id:int}")]
    public IActionResult editAnimal(int id, Animal animal)
    {
        var animals = new MockDb().Animals;
        var animalToEdit = animals.FirstOrDefault(s => s.id == id);
        if (animalToEdit == null)
        {
            return (IActionResult)Results.NotFound($"Animal with id {id} was not found");
        }
        animals.Remove(animalToEdit);
        animals.Add(animal);
        return (IActionResult)Results.NoContent();
    }

    [HttpDelete("/api/animals/{id:int}")]
    public IActionResult deleteAnimal()
    {
        
    }
}