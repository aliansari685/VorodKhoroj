namespace VorodKhoroj.Interfaces;

public interface IAppDbContextProvider
{
    public AppDbContext? DbContext { get; }
    public AppDbContext? DbContextMaster { get; }
}