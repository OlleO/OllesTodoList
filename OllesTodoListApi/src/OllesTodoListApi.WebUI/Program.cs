using MediatR;
using Microsoft.AspNetCore.Mvc;
using OllesTodoList.Application;
using OllesTodoList.Application.Operations;
using OllesTodoListApi.Infrastructure;
using OllesTodoListApi.WebUI.ResponseModels;

namespace OllesTodoListApi.WebUI;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the pipeline
        builder.Services.AddApplicationServices();
        builder.Services.AddInfrastructureServices();
        builder.Services.AddWebUIServices(); 

        var app = builder.Build();

        // Configure the HTTP request pipeline

        app.UseHttpsRedirection();

        app.UseSwagger();
        app.UseSwaggerUI();

        // Adding minimal API endpoints, break this out of Program.cs eventually

        app.MapGet("/todoItems", async ([FromServices] IMediator mediator, CancellationToken ct) =>
        {
            var query = new GetAll.Query();

            var result = (await mediator.Send(query, ct)).TodoItems;

            var todoItems = result.Select(x =>
                new TodoItemResponseModel()
                {
                    Id = x.Id,
                    Title = x.Title,
                    Status = x.Status
                });

            return todoItems;
        });

        app.MapGet("/todoItems/{id}", async ([FromServices] IMediator mediator, long id, CancellationToken ct) =>
        {
            var query = new GetById.Query(id);

            var result = (await mediator.Send(query, ct)).TodoItem;

            var todoItem = new TodoItemResponseModel() { Id = result.Id, Title = result.Title, Status = result.Status };
           
            return todoItem;
        });

        app.Run();
    }
}
