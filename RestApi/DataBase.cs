using RestApi.Models;

namespace RestApi.Controllers;

public class DataBase
{
    public static List<Animal> Animals { get; } = new List<Animal>();
    public static List<Visit> Visits { get; } = new List<Visit>();
}