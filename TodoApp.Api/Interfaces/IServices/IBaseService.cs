namespace TodoApp.Api.Interfaces.IServices;

public interface IBaseService<T> where T : class
{
    Task<IEnumerable<T>> GetAll();
    Task<T> GetById(int id);
    Task<T> Create(T obj);
    Task<T> Update(int id, T obj);
    Task<bool> Delete(int id);
}