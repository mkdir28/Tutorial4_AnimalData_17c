using Tutorial4_AnimalData.models;

namespace Tutorial4_AnimalData.database;

public class StaticData
{
    public static List<Animal> animals = new List<Animal>()
    {
        new Animal(),
        new Animal(),
        new Animal(),
        new Animal(),
    };
}