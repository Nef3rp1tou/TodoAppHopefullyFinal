using TodoApp.Api.Interfaces.IRepositories;
using TodoApp.Api.Interfaces.IServices;

namespace TodoApp.Api.Services;

public class BaseService<T> : IBaseService<T> where T: class
{
    private readonly IBaseRepository<T> _repository;

    public BaseService(IBaseRepository<T> repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<T>> GetAll()
    {
        return await _repository.GetAll();
    }

    public async Task<T> GetById(int id)
    {
        return await _repository.GetById(id);
    }

    public async Task<T> Create(T obj)
    {
        return await _repository.Create(obj);
    }

    public async Task<T> Update(int id, T obj)
    {
        return await _repository.Update(id, obj);
    }

    public async Task<bool> Delete(int id)
    {
        return await _repository.Delete(id);
    }
}