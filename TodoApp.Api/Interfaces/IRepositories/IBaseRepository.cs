namespace TodoApp.Api.Interfaces.IRepositories;

public interface IBaseRepository<T>  where T : class
{
    Task<IEnumerable<T>> GetAll();
    Task<T> GetById(int id);
    Task<T> Create(T obj);
    Task<T> Update(int id, T obj);
    Task<bool> Delete(int id);
}