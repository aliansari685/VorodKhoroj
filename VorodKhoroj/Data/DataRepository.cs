namespace VorodKhoroj.Data
{
    public class DataRepository
    {
        private enum LoginTypeEnum
        {
            Face = 15,
            Finger = 1
        }

        public int[] GetUsersAttendances(List<Attendance> list)
        {
            return list.Select(x => x.UserId).Distinct().ToArray() ;
        }

        public string LoginType_String(string number)
        {
            var num = int.Parse(number);
            return ((LoginTypeEnum)num).ToString();
        }

        public List<Attendance> GetRecordsFromFile(string fileAddress)
        {
            List<Attendance> records = new();
            foreach (var line in File.ReadAllLines(fileAddress))
            {
                var values = line.Split('\t');
                if (values.Length == 6)
                {
                    records.Add(new Attendance
                    {
                        UserId = int.Parse(values[0]),
                        DateTime = PersianDateHelper.ConvertToShamsi(values[1]),
                        LoginType = LoginType_String(values[4])
                    });
                }
            }

            return records;
        }

        public List<Attendance> GetRecordsFromDb(AppDbContext context)
        {
            return context.Attendances.ToList();
        }
        public object GetRecordsFromDB_Bind(AppDbContext context)
        {
            return context.Attendances.Local;
        }

        public void AddAttendances(IEnumerable<Attendance> records, AppDbContext context)
        {
            context.Attendances.AddRange(records);
            context.SaveChangesAsync();
            context.Database.GetDbConnection().Close();
            Task.Delay(1000);
        }
    }
}