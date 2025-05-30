namespace VorodKhoroj.Services;

public class AppDbContextProvider
{
    public AppDbContext? DbContext { get; set; }
    public AppDbContext? DbContextMaster { get; set; }
}