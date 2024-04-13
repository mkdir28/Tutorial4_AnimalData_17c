namespace Tutorial4_AnimalData.models;

public class Visit: Animal
{
    public int id_visit { get; set; }
    public DateTime date_of_visit { get; set; }
    public string animal { get; set; }
    public string visit_description { get; set; }
    public int price { get; set; }

}