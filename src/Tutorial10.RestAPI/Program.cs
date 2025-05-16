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

app.MapGet("/api/employees",async (_2019sbdContext context, CancellationToken token) => 
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

app.MapGet("/api/employees/{id}", (int id) =>
{
    
});

app.MapPost("/api/employees", () =>
{
    
});

app.MapPut("/api/employees/{id}", (int id) =>
{
    
});

app.MapDelete("/api/employees/{id}", (int id) =>
{
    
});

app.Run();
