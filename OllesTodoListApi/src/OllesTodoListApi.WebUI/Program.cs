using Microsoft.AspNetCore.Mvc;
using OllesTodoListApi.WebUI.ResponseModels;

namespace OllesTodoListApi.WebUI;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the pipeline
        // builder.Services.AddWebUIServices(); 

        builder.Services.AddEndpointsApiExplorer(); 
        builder.Services.AddSwaggerGen(o => 
        {
            o.SwaggerDoc("v1", new() 
            {
                Version = "v1",
                Title = "Olles Todo List API"
            });
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline

        app.UseHttpsRedirection();

        app.UseSwagger();
        app.UseSwaggerUI();

        // Adding minimal API endpoints, break this out of Program.cs eventually

        app.MapGet("/todoItems", () =>
        {
            var todoItems = new List<TodoItemResponseModel>()
            {
                new() { Id = 1, Title = "First item", Status = "Complete" },
                new() { Id = 2, Title = "Second item", Status = "Not complete"}
            };

            return todoItems;
        });

        app.MapGet("/todoItems/{id}", (long id) =>
        {
            var todoItem = new TodoItemResponseModel() { Id = id, Title = $"{id}:th item", Status = "Not complete" };
           
            return todoItem;
        });

        app.Run();
    }
}
