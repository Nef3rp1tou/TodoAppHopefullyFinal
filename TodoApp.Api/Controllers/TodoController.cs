using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TodoApp.Api.Entities;
using TodoApp.Api.Interfaces.IServices;
using TodoApp.Api.Services;

namespace TodoApp.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TodoController : ControllerBase
{
    private readonly ITodoService<TodoItem> _todoService;

    public TodoController(ITodoService<TodoItem> todoService)
    {
        _todoService = todoService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TodoItem>>> GetAllAsync()
    {
        return Ok(await _todoService.GetAll());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TodoItem>> GetByIdAsync(int id)
    {
        return Ok(await _todoService.GetById(id));
    }

    [HttpPost]
    public async Task<ActionResult<TodoItem>> CreateAsync(TodoItem todoItem)
    {
        return Ok(await _todoService.Create(todoItem));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<TodoItem>> UpdateAsync(int id, TodoItem todoItem)
    {
        return Ok(await _todoService.Update(id, todoItem));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteAsync(int id)
    {
        return Ok(await _todoService.Delete(id));
    }
}