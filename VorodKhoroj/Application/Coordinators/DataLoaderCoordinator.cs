
namespace VorodKhoroj.Application.Coordinators;

// بارگذاری داده‌ها از فایل یا دیتابیس
public class DataLoaderCoordinator(IAttendanceRepository attendanceRepository, IAttendanceFileReader attendanceTextFileReader, IDbContextConfiguration dbContextConfiguration) : IDataLoader
{
    /// <summary>
    /// لیست رکوردهای حضور و غیاب بارگذاری شده
    /// </summary>
    public List<Attendance> AttendancesRecords { get; set; } = [];

    public required IUserDataProvider ListProvider { get; set; }

    public IList UserList => ListProvider.GetUserDataProvider();

    /// <summary>
    /// بارگذاری داده‌ها از فایل تکست یا مشابه
    /// </summary>
    /// <param name="fileName">نام فایل ورودی</param>
    /// <param name="isListProvider">آیا ListProvider تنظیم شود</param>
    public void LoadFromFile(string fileName, bool isListProvider = true)
    {
        AttendancesRecords = attendanceTextFileReader.GetRecordsFromFile(fileName);
        ListProvider = (isListProvider ? new FileProvider(attendanceRepository, AttendancesRecords) : null) ?? throw new NullReferenceException("شی خالی است");
    }

    /// <summary>
    /// بارگذاری داده‌ها از دیتابیس
    /// </summary>
    public void LoadFromDb()
    {
        if (dbContextConfiguration.DbContext == null)
            throw new Exception("خطا در دیتابیس");

        AttendancesRecords = dbContextConfiguration.DbContext.Attendances.ToList();
        ListProvider = new DbProvider(dbContextConfiguration.DbContext);
    }
}