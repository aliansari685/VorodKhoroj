namespace VorodKhoroj.Domain.Interfaces;

public interface IAttendanceFileReader
{
    /// <summary>
    /// خواندن داده از فایل
    /// </summary>
    /// <param name="filePath"></param>
    /// <returns></returns>
    List<Attendance> GetRecordsFromFile(string filePath);
}