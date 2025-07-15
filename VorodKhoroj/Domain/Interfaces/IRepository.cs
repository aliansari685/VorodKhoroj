namespace VorodKhoroj.Domain.Interfaces;

public interface IRepository<T>
{
    void Add(T entity);
    void Update(T entity);
    void Remove(T entity);
    T GetById(int id);
    IEnumerable<T> GetAll();
}