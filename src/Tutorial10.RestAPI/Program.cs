using Microsoft.EntityFrameworkCore;
using Tutorial10.RestAPI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var _connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<_2019sbdContext>(options => options.UseSqlServer(_connectionString));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/api/jobs", async (_2019sbdContext context, CancellationToken token) =>
{
    try
    {
        return Results.Ok(await context.Jobs.ToListAsync(token));
    }
    catch(Exception ex)
    {
        return Results.Problem(ex.Message);
    }
});

app.MapGet("/api/departments",async (_2019sbdContext context, CancellationToken token) => {
    
    try
    {
        return Results.Ok(await context.Departemnts.ToListAsync(token));
    }
    catch(Exception ex)
    {
        return Results.Problem(ex.Message);
    }
});

app.MapGet("/api/employees", async (_2019sbdContext context, CancellationToken token) => 
{
    try
    {
        return Results.Ok(await context.Employees.ToListAsync(token));
    }
    catch(Exception ex)
    {
        return Results.Problem(ex.Message);
    }
    
});

app.MapGet("/api/employees/{id}", async (_2019sbdContext context, CancellationToken token, int id) =>
{
    try
    {
        return Results.Ok( context.Employees.Single(x => x.Id == id));
    }
    catch(Exception ex)
    {
        return Results.Problem(ex.Message);
    }   
});

app.MapPost("/api/employees", async (_2019sbdContext context, CancellationToken token, Employee emp)=>
{
    try
    {
        context.Employees.Add(emp);
        return Results.Created($"/api/employees/{emp.Id}", emp);
    }
    catch(Exception ex)
    {
        return Results.Problem(ex.Message);
    }   
});

app.MapPut("/api/employees/{id}", (int id) =>
{
    
});

app.MapDelete("/api/employees/{id}", (int id) =>
{
    
});

app.Run();
