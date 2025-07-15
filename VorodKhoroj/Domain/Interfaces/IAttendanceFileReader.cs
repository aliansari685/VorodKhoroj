namespace VorodKhoroj.Domain.Interfaces;

public interface IAttendanceFileReader
{
    List<Attendance> GetRecordsFromFile(string filePath);
}