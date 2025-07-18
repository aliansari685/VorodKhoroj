namespace VorodKhoroj.Domain.Interfaces;

public interface IDataLoader
{
    /// <summary>
    /// لیست رکوردهای حضور و غیاب بارگذاری شده
    /// </summary>
    public List<Attendance> AttendancesRecords { get; set; }

    /// <summary>
    /// پروایدر منبع دریافت کاربران ک دیتابیس باشه یا فایل
    /// </summary>
    public IUserDataProvider ListProvider { get; set; }

    /// <summary>
    /// لیست کاربران از پروایدر مشخص
    /// </summary>
    public IList UserList => ListProvider.GetUserDataProvider();

    /// <summary>
    /// بارگذاری داده از فایل
    /// </summary>
    /// <param name="fileName"></param>
    /// <param name="isListProvider"></param>
    public void LoadFromFile(string fileName, bool isListProvider = true);

    /// <summary>
    /// بارگذاری داده‌ها از دیتابیس
    /// </summary>
    public void LoadFromDb();

}