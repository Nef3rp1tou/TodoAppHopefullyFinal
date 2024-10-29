using Microsoft.EntityFrameworkCore;
using TodoApp.Api.Entities;

namespace TodoApp.Api.Data;

public class TodoDbContext : DbContext
{
   public DbSet<TodoItem> TodoItems { get; set; }
   
   public TodoDbContext(DbContextOptions options) : base(options) { }
   
}