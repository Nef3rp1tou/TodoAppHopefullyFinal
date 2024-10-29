using TodoApp.Api.Entities;

namespace TodoApp.Api.Interfaces.IServices;


public interface ITodoService<T> : IBaseService<T> where T : class;