namespace VorodKhoroj.Domain.Interfaces;

public interface IAttendanceDataService
{
    // کپی کردن لیستی از رکوردهای Attendance به دیتابیس
    public void CopyRecords(List<Attendance> recs);

    // افزودن لیستی از رکوردهای Attendance به دیتابیس
    public void AddAttendance(List<Attendance> rec);

    // به‌روزرسانی یک رکورد Attendance
    public void UpdateAttendance(Attendance rec);

    // حذف یک رکورد Attendance
    public void DeleteAttendance(Attendance rec);
}