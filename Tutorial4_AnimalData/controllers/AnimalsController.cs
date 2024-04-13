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
}