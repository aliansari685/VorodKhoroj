using static VorodKhoroj.Domain.Enums;

namespace VorodKhoroj.Domain.Interfaces;

public interface IDbContextConfiguration
{
    AppDbContext? DbContext { get; }
    AppDbContext? DbContextMaster { get; }

    void InitializeDbContext(string server, string path, string name, DataBaseLocation location);
    void InitializeDbContextMaster(string server);
}