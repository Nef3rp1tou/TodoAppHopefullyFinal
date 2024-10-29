using Microsoft.AspNetCore.Mvc;
using TodoApp.Api.Entities;

namespace TodoApp.Api.Interfaces.IRepositories;

public interface ITodoRepository : IBaseRepository<TodoItem>
{
    
}