namespace RestApi.Models;

public class Visit
{
    public int Id { get; set;}
    public DateTime Date { get; set;}
    public int AnimalId { get; set;} 
    public string Description { get; set;}
    public decimal Price { get; set;}
    public Visit(int id, DateTime date, int animalId, string description, decimal price)
    {
        Id = id;
        Date = date;
        AnimalId = animalId;
        Description = description;
        Price = price;
    }

    public override string ToString()
    {
        return $"Id: {Id}, Date: {Date}, AnimalId: {AnimalId}";
    }
    
    }