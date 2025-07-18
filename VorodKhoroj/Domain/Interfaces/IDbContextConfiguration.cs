using static VorodKhoroj.Domain.Enums;

namespace VorodKhoroj.Domain.Interfaces;

public interface IDbContextConfiguration
{
    /// <summary>
    /// کانتکس اصلی دیتابیس
    /// </summary>
    AppDbContext? DbContext { get; }

    /// <summary>
    /// کانتکس مستر دیتابیس
    /// </summary>
    AppDbContext? DbContextMaster { get; }

    /// <summary>
    /// ایجاد و نیو کردن کانتکس جدید
    /// </summary>
    /// <param name="server"></param>
    /// <param name="path"></param>
    /// <param name="name"></param>
    /// <param name="location"></param>
    void InitializeDbContext(string server, string path, string name, DataBaseLocation location);

    /// <summary>
    /// ایجاد و نیو کردن کانتکس برای مستر
    /// </summary>
    /// <param name="server"></param>
    void InitializeDbContextMaster(string server);
}