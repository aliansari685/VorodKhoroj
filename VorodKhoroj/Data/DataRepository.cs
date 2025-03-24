namespace VorodKhoroj.Data
{
    public class DataRepository
    {
        private enum LoginTypeEnum
        {
            Face = 15,
            Finger = 1
        }

        public string LoginType_String(string number)
        {
            var num = int.Parse(number);
            return ((LoginTypeEnum)num).ToString();
        }

        public List<Attendance> GetRecordsFromFile(string FileAddress)
        {
            List<Attendance> _records = new();
            foreach (var line in File.ReadAllLines(FileAddress))
            {
                var values = line.Split('\t');
                if (values.Length == 6)
                {
                    _records.Add(new()
                    {
                        UserId = int.Parse(values[0]),
                        DateTime = PersianDateHelper.ConvertToShamsi(values[1]),
                        LoginType = LoginType_String(values[4])
                    });
                }
            }

            return _records;
        }

        public List<Attendance> GetRecordsFromDB(AppDbContext _context)
        {
            return _context.Attendances.ToList();
        }
        public object GetRecordsFromDB_Bind(AppDbContext _context)
        {
            return _context.Attendances.Local;
        }

        public void AddAttendances(IEnumerable<Attendance> records, AppDbContext _context)
        {
            _context.Attendances.AddRangeAsync(records);
            _context.SaveChangesAsync();
            _context.Database.GetDbConnection().Close();
        }
    }
}