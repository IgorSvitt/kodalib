namespace KodalibApi.Interfaces.Base;

public interface IBaseRepository<T>
{
    void Create(T entity);

    void Delete(T entity);

    void Save();

    void Update(T entity);

}