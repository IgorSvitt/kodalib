namespace Kodalib.Interfaces.Base;

public interface IBaseRepository<T>
{
    void Create(T entity);

    Task<T> Get(int id);

    Task<List<T>> Select();

    void Delete(T entity);

    void Save();

}