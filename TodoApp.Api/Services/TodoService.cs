using TodoApp.Api.Entities;
using TodoApp.Api.Interfaces.IRepositories;
using TodoApp.Api.Interfaces.IServices;

namespace TodoApp.Api.Services
{
    public class TodoService : BaseService<TodoItem>, ITodoService<TodoItem>
    {
        private readonly IBaseRepository<TodoItem> _repository;

        // Constructor
        public TodoService(IBaseRepository<TodoItem> repository) : base(repository)
        {
            _repository = repository;
        }

        // Implement any additional service methods here
    }
}