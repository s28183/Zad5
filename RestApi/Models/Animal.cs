namespace RestApi.Models;

public class Animal
{
    private static int NextId = 1;  
    public int IdAnimal { get; }
    public string Name { get; set; }
    public string Category { get; set; }
    public double Weight { get; set; }
    public string FurColor { get; set; }

    public Animal(string name, string category, double weight, string furColor)
    {
        IdAnimal = NextId++;  
        Name = name;
        Category = category;
        Weight = weight;
        FurColor = furColor;
    }

    public override string ToString()
    {
        return $"Id: {IdAnimal}, Name: {Name},Category: {Category}, Weight: {Weight}, Color: {FurColor}";
    }
}