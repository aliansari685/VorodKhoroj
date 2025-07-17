namespace VorodKhoroj.Domain.Interfaces;

public interface IDataLoader
{
    public List<Attendance> Records { get; set; }
    public IUserDataProvider? ListProvider { get; set; }

    public void LoadFromFile(string fileName, bool isListProvider = true);

    public void LoadFromDb(AppDbContext? dbContext);

}