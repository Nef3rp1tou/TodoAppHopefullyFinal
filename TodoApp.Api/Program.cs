using Microsoft.EntityFrameworkCore;
using TodoApp.Api.Data;
using TodoApp.Api.Entities;
using TodoApp.Api.Interfaces.IRepositories;
using TodoApp.Api.Interfaces.IServices;
using TodoApp.Api.Repositories;
using TodoApp.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register the database context with a SQLite connection
builder.Services.AddDbContext<TodoDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register repositories and services
builder.Services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddTransient<ITodoRepository, TodoRepository>();
builder.Services.AddScoped<ITodoService<TodoItem>, TodoService>(); // Removed generic type argument here
builder.Services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));

// Add controllers
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization(); // Add this if you're using any form of authentication

// Map controller routes
app.MapControllers();

app.Run();