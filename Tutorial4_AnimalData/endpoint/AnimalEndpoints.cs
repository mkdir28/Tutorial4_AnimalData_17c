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
    }
}