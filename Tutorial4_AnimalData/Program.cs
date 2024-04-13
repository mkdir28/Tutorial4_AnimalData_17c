using Tutorial4_AnimalData.database;
using Tutorial4_AnimalData.endpoint;
using Tutorial4_AnimalData.models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddSingleton<MockDb>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

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

//minimalAPI
app.MapAnimalsEndpoint();
//controllers
app.MapControllers();
app.Run();