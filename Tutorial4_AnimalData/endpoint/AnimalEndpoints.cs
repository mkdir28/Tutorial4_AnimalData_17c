using Tutorial4_AnimalData.database;
using Tutorial4_AnimalData.models;

namespace Tutorial4_AnimalData.endpoint;

public static class AnimalEndpoints
{
    public static void MapAnimalsEndpoint(this WebApplication app)
    {
        var _mockDb = new MockDb().Animals;
        var _mockDbVisits = new MockDb().Visits;

        app.MapGet("/api/animals", () => Results.Ok(_mockDb))
            .WithName("GetAnimals")
            .WithOpenApi();
// 200 - Ok
// 201 - Created
        // app.MapPost("/animals-minimal/{id}", (Animal animal) =>
        // {
        //     Console.WriteLine(animal.id);
        //     Console.WriteLine(animal.name);
        //
        //     return Results.Created();
        // });
        app.MapGet("/animals-minimal/{id:int}", (int id) =>
            {
                var animal = _mockDb.FirstOrDefault(s => s.id == id);
                return animal == null ? Results.NotFound($"Animal with id {id} was not found") : Results.Ok(animal);
            })
            .WithName("GetAnimal")
            .WithOpenApi();
        // retrieve a specific animal by id
        // app.MapGet("/api/animals/{id:int}", (int id) =>
        //     {
        //         var animals = new MockDb().Animals;
        //         animals.FirstOrDefault(s => s.id == id);
        //         return animals == null ? Results.NotFound($"Animal with id {id} was not found") : Results.Ok(animals);
        //     })
        //     .WithName("GetAnimals")
        //     .WithOpenApi();
        app.MapPost("/api/animals", (Animal animal) =>
            {
                _mockDb.Add(animal);
                return Results.StatusCode(StatusCodes.Status201Created);
            })
            .WithName("CreateAnimal")
            .WithOpenApi();
        
// app.MapGet("/api/students", () => Results.Ok(_students))
//     .WithName("GetStudents")
//     .WithOpenApi();
//
// app.MapGet("/api/students/{id:int}", (int id) =>
//     {
//         var student = _students.FirstOrDefault(s => s.IdStudent == id);
//         return student == null ? Results.NotFound($"Student with id {id} was not found") : Results.Ok(student);
//     })
//     .WithName("GetStudent")
//     .WithOpenApi();
        app.MapPut("/api/animals/{id:int}", (int id, Animal animal) =>
            {
                var animalToEdit = _mockDb.FirstOrDefault(s => s.id == id);
                if (animalToEdit == null)
                {
                    return Results.NotFound($"Student with id {id} was not found");
                }
                _mockDb.Remove(animalToEdit);
                _mockDb.Add(animal);
                return Results.NoContent();
            })
            .WithName("UpdateAnimal")
            .WithOpenApi();
        
        app.MapDelete("/api/animals/{id:int}", (int id) =>
            {
                var animalToDelete = _mockDb.FirstOrDefault(s => s.id == id);
                if (animalToDelete == null)
                {
                    return Results.NoContent();
                }
                _mockDb.Remove(animalToDelete);
                return Results.NoContent();
            })
            .WithName("DeleteAnimal")
            .WithOpenApi();
        
        app.MapGet("{id:int}/visits", (int id)=>
        {
            var visitToAnimal = _mockDbVisits.FirstOrDefault(a => a.id == id);
            return Results.Ok(visitToAnimal);
        })
        .WithName("GetVisits")
        .WithOpenApi();
        
        app.MapPost("{id:int}/visits", (Visit visit) =>
        {
            _mockDbVisits.Add(visit);
            return Results.StatusCode(StatusCodes.Status201Created);
        })
        .WithName("GetVisit")
        .WithOpenApi();
        
        app.Run();
    }
}