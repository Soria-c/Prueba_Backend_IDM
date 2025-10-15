using System.Text.Json;
using Models;
using Persistence;

namespace ShoppingCart;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        // builder.Services.AddAuthorization();

        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();
        builder.Services.AddSwaggerGen();
        builder.Services.AddControllers();

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        // if (app.Environment.IsDevelopment())
        // {
        app.MapOpenApi();
        app.UseSwagger();
        app.UseSwaggerUI();
        // }

        app.MapControllers();
        string jsonString = File.ReadAllText("./Persistence/db.json");
        // System.Console.WriteLine(jsonString);
        Persistence.DB.products = JsonSerializer.Deserialize<Models.Product>(jsonString, options);
        // app.UseHttpsRedirection();

        // app.UseAuthorization();

        app.Run();
    }
}
