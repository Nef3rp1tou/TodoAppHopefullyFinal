using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApp.Api.Data;
using TodoApp.Api.Entities;
using TodoApp.Api.Interfaces.IRepositories;

namespace TodoApp.Api.Repositories;

public class TodoRepository(TodoDbContext todoDbContext) :  BaseRepository<TodoItem>(todoDbContext), ITodoRepository
{

}