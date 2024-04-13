using Microsoft.AspNetCore.Mvc;
using Tutorial4_AnimalData.database;

namespace Tutorial4_AnimalData.controllers;
[ApiController]
[Route("[controller]")]
public class AnimalsController: ControllerBase
{
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
    [HttpGet("/animal")]
    public IActionResult Get
}