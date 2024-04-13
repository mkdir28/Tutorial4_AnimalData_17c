using Tutorial4_AnimalData.models;

namespace Tutorial4_AnimalData.database;

public class MockDb
{
    //add an animal
    public List<Animal> Animals { get; set; } = new List<Animal>();
    public List<Visit> Visits { get; set; } = new List<Visit>();

    public MockDb()
    {
        Animals.Add((new Animal{id = 1, name = "Andy", category = "dog", wheight = 10, fur_color = "black"}));
        Animals.Add((new Animal{id = 2, name = "Jacke", category = "cat", wheight = 7, fur_color = "white"}));
        Animals.Add((new Animal{id = 3, name = "Lizi", category = "cat", wheight = 8, fur_color = "orange"}));
        Animals.Add((new Animal{id = 4, name = "Jasper", category = "dog", wheight = 15, fur_color = "black"}));
        Animals.Add((new Animal{id = 5, name = "Lusi", category = "dog", wheight = 10, fur_color = "grey"}));
        
        Visits.Add((new Visit{id_visit = 1, date_of_visit = DateTime.Parse("2024-04-15 13:30:00") , animal = "dog", visit_description = "bandage the paw", price = 100}));
        Visits.Add((new Visit{id_visit = 1, date_of_visit = DateTime.Parse("2024-04-16 17:15:00"), animal = "cat", visit_description = "routine inspection", price = 50}));

    }
}