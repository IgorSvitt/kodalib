namespace KodalibApi.Interfaces.Base;

public interface IBaseRepository<T>
{
    void Create(T entity);

    Task<T> GetById(int id);

    T GetByName(string name);
    
    Task<List<T>> Select();

    void Delete(T entity);

    void Save();

    void Update(T entity);

}