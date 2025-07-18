namespace VorodKhoroj.Domain.Interfaces;

public interface IDataBaseInitializer
{
    /// <summary>
    /// نام پایگاه داده
    /// </summary>
    public string DbName { get; }

    /// <summary>
    /// تنظیم نام دیتابیس (بدون پسوند) از مسیر فایل داده شده
    /// </summary>
    public void SetDbName(string dbPath);

    /// <summary>
    /// مسیر دیتابیس
    /// </summary>
    public string DbPathName { get; }

    /// <summary>
    /// تنظیم مسیر فایل دیتابیس
    /// </summary>
    public void SetDbPath(string dbPathname);

    /// <summary>
    /// ایجاد دیتابیس جدید با مسیر و نام مشخص
    /// </summary>
    public void CreateDatabase();

    /// <summary>
    /// جدا کردن دیتابیس از سرور (Detach)
    /// </summary>
    public void DetachDatabase();

    /// <summary>
    /// ایجاد جداول در دیتابیس فعلی
    /// </summary>
    public void CreateTables();

    /// <summary>
    /// تست ارتباط با سرور SQL
    /// </summary>
    public bool TestServerName(string server);

}