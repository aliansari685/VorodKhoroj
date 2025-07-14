using VorodKhoroj.Application.Services;
using VorodKhoroj.Domain.Interfaces;

namespace VorodKhoroj.Application.Coordinators;

// بارگذاری داده‌ها از فایل یا دیتابیس
public class DataLoaderCoordinator(DataRepository dataRepository, AttendanceFileReader attendanceFileReader)
{
    public List<Attendance> Records { get; set; } = [];
    public IUserDataProvider? ListProvider { get; set; }

    /// <summary>
    /// بارگذاری داده‌ها از فایل تکست یا مشابه
    /// </summary>
    /// <param name="fileName">نام فایل ورودی</param>
    /// <param name="isListProvider">آیا ListProvider تنظیم شود</param>
    public void LoadFromFile(string fileName, bool isListProvider = true)
    {
        Records = attendanceFileReader.GetRecordsFromFile(fileName);
        ListProvider = isListProvider ? new FileProvider(dataRepository, Records) : null;
    }

    /// <summary>
    /// بارگذاری داده‌ها از دیتابیس
    /// </summary>
    public void LoadFromDb(AppDbContext? dbContext)
    {
        if (dbContext != null)
        {
            Records = dbContext.Attendances.ToList();
            ListProvider = new DbProvider(dbContext);
        }
        else
            throw new Exception("خطا در دیتابیس");

    }

}