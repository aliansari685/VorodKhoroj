namespace VorodKhoroj.Domain.Interfaces;

public interface IRepository<T>
{
    void Add(List<T> entity);
    void Update(List<T> entity);
    void Remove(List<T> entity);

}