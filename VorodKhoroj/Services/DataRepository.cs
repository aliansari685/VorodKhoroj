namespace VorodKhoroj.Services
{
    public class DataRepository
    {
        private void ExecuteSafeQuery(Action action)
        {
            try
            {
                action();
            }
            catch (DbUpdateException ex)
            {
                CommonHelper.ShowMessage(ex);
            }
            catch (DbException ex)
            {
                CommonHelper.ShowMessage(ex);
            }
            catch (Exception ex)
            {
                CommonHelper.ShowMessage(ex);
            }
        }

        public List<Attendance> GetRecordsFromFile(string fileAddress)
        {
            List<Attendance> records = [];
            foreach (var line in File.ReadAllLines(fileAddress))
            {
                var values = line.Split('\t');
                if (values.Length == 6)
                {
                    records.Add(new Attendance
                    {
                        UserId = int.Parse(values[0]),
                        DateTime = PersianDateHelper.ConvertToShamsi(values[1]),
                        LoginType = GetLoginType(values[4])
                    });
                }
            }

            return records;
        }

        public string GetLoginType(string number)
        {
            var num = int.Parse(number);
            return num switch
            {
                15 => "Face",
                1 => "Finger",
                _ => "",
            };
        }
        public int[] GetUsersAttendances(List<Attendance> list)
        {
            return list.Select(x => x.UserId).Distinct().ToArray();
        }


        //DataBase:
        public void AddAttendancesAndUsers(List<Attendance> records, AppDbContext context)
        {
            ExecuteSafeQuery(() =>
            {
                //Add User AttendancesList From UserID in Attendance
                var users = GetUsersAttendances(records)
                    .Select(id => new User { UserId = id })
                    .ToList();

                context.Users.AddRange(users);
                _ = context.SaveChanges();

                //Add Attendance AttendancesList
                context.Attendances.AddRange(records);
                _ = context.SaveChanges();

                context.Database.GetDbConnection().Close();
            });

        }
        public void AddAttendance(List<Attendance> records, AppDbContext context)
        {
            ExecuteSafeQuery(() =>
            {
                context.Attendances.AddRange(records);
                context.SaveChanges();
            });
        }

        public void DeleteAttendance(List<Attendance> records, AppDbContext context)
        {
            ExecuteSafeQuery(() =>
            {
                context.Attendances.RemoveRange(records);
                _ = context.SaveChanges();
            });
        }

        public void UpdateAttendance(List<Attendance> records, AppDbContext context)
        {
            ExecuteSafeQuery(() =>
            {
                context.Attendances.UpdateRange(records);
                _ = context.SaveChanges();
            });

        }
        public void AddAttendanceUser(List<User> records, AppDbContext context)
        {
            ExecuteSafeQuery(() =>
            {
                context.Users.AddRange(records);
                _ = context.SaveChanges();
            });
        }
        public void UpdateAttendanceUser(List<User> records, AppDbContext context)
        {
            ExecuteSafeQuery(() =>
            {
                context.Users.UpdateRange(records);
                _ = context.SaveChanges();
            });
        }
    }
}