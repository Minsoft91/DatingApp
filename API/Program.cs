using API.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddCors();

builder.Services.AddDbContext<DataContext>(options => 
{
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseCors(builder => 
{
    builder.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:4200");
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
