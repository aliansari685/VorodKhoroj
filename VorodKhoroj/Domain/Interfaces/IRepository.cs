namespace VorodKhoroj.Domain.Interfaces;

/// <summary>
/// اینترفیس مشترک بین ریپازیتوری ها با مدل دلخواه
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IRepository<T>
{
    void Add(List<T> entity, AppDbContext dbContext);
    void Update(List<T> entity, AppDbContext dbContext);
    void Remove(List<T> entity, AppDbContext dbContext);

}