using Tutorial4_AnimalData.models;

namespace Tutorial4_AnimalData.database;

public class MockDb
{
    public List<Animal> Animals { get; set; } = new List<Animal>();

    public MockDb()
    {
        Animals.Add((new Animal()));
        Animals.Add((new Animal()));
        Animals.Add((new Animal()));

    }
}