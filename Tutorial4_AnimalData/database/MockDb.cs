using Tutorial4_AnimalData.models;

namespace Tutorial4_AnimalData.database;

public class MockDb
{
    //add an animal
    public List<Animal> Animals { get; set; } = new List<Animal>();

    public MockDb()
    {
        Animals.Add((new Animal{id = 1, name = "Andy", category = "dog", wheight = 10, fur_color = "black"}));
        Animals.Add((new Animal{id = 2, name = "Jacke", category = "cat", wheight = 7, fur_color = "white"}));
        Animals.Add((new Animal{id = 3, name = "Lizi", category = "cat", wheight = 8, fur_color = "orange"}));
        Animals.Add((new Animal{id = 4, name = "Jasper", category = "dog", wheight = 15, fur_color = "black"}));
        Animals.Add((new Animal{id = 5, name = "Lusi", category = "dog", wheight = 10, fur_color = "grey"}));

    }
}