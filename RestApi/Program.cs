using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using RestApi.Controllers;
using RestApi.Models;

public class Program
{
    public static void Main(string[] args){
        DataBase.Animals.Add(new Animal ("Rex","Dog", 15,"Brown"));
        DataBase.Animals.Add(new Animal ("Siu","Kot", 30,"Brown"));
        DataBase.Visits.Add(new Visit(1, DateTime.Now, DataBase.Animals[0].IdAnimal, "Szybki check", 2));
        DataBase.Visits.Add(new Visit(2, DateTime.Now.AddDays(1), DataBase.Animals[1].IdAnimal, "Szybki check2", 1));

    var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddControllers();
    var app = builder.Build();

// Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }


    app.UseHttpsRedirection();

    app.MapControllers();
    app.Run();

   
    }

    
}