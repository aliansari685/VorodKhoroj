namespace VorodKhoroj.Services
{
    public class FileProvider(DataRepository repository, List<Attendance> records) : IDataProvider
    {
        public IList GetDataProvider()
        {
            return repository.GetUsersAttendances(records);
        }
    }
}
