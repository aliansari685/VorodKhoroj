namespace VorodKhoroj
{
    public class AppServices : IDisposable
    {
        private readonly DataRepository _repository;
        public List<Structure> Records { get; set; }

        public AppServices()
        {
            _repository = new();
        }
        public void LoadRecordsFromFile(string fileName)
        {
            Records = _repository.GetRecordsFromFile(fileName);
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
