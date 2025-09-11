using Microsoft.EntityFrameworkCore;
using Solution.Data;
using Solution.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

//Database
var connectionString = builder.Configuration.GetConnectionString("TodoDbContext");
builder.Services.AddDbContext<TodoDbContext>(options =>
  options.UseSqlServer(connectionString));

//Dependency Injecion
builder.Services.AddTransient<ITodoService, TodoService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();


app.MapGet("/list", async (ITodoService service) =>
{
    return await service.ListAllAsync();    
});

app.MapPost("/create", async (Todo model, ITodoService service) =>
{
    await service.CreateAsync(model);

    return Results.Created();
});

app.MapDelete("delete/{id:int}", async (int id, ITodoService service) =>
{
    await service.DeleteAsync(id);

    return Results.Ok();    
});

app.MapPut("update", async (Todo model, ITodoService service) =>
{
    await service.UpdateAsync(model);

    return Results.Ok();
});
app.MapPut("ready/{id:int}", async (int id, ITodoService service) =>
{
    await service.ReadyAsync(id);

    return Results.Ok();
});

app.Run();