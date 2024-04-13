using Tutorial4_AnimalData.database;
using Tutorial4_AnimalData.models;

namespace Tutorial4_AnimalData.endpoint;

public static class AnimalEndpoints
{
    public static void MapAnimalsEndpoint(this WebApplication app)
    {
        app.MapGet("/animals", () =>
        {
            //process data
            return Results.Ok();
        });
// 200 - Ok
// 201 - Created
        app.MapPost("/animals-minimal/{id}", (Animal animal) =>
        {
            Console.WriteLine(animal.id);
            Console.WriteLine(animal.name);

            return Results.Created();
        });
        // retrieve a specific animal by id
        app.MapGet("/api/animals/{id:int}", (int id) =>
            {
                var animals = new MockDb().Animals;
                animals.FirstOrDefault(s => s.id == id);
                return animals == null ? Results.NotFound($"Animal with id {id} was not found") : Results.Ok(animals);
            })
            .WithName("GetAnimals")
            .WithOpenApi();
        //add an animal
        app.MapPost("/api/animals", (Animal animal) =>
            {
                Animals.Add(animal);
                return Results.StatusCode(StatusCodes.Status201Created);
            })
            .WithName("AddStudent")
            .WithOpenApi();
        
        
        app.MapDelete("/api/animals/{id:int}", (int id) =>
            {
                var studentToDelete = _students.FirstOrDefault(s => s.IdStudent == id);
                if (studentToDelete == null)
                {
                    return Results.NoContent();
                }
                _students.Remove(studentToDelete);
                return Results.NoContent();
            })
            .WithName("DeleteStudent")
            .WithOpenApi();

        app.Run();
    }
}