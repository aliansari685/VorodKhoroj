namespace VorodKhoroj.Domain.Interfaces;

public interface IUserDataService
{
    /// <summary>
    /// اضافه کردن کاربر
    /// </summary>
    /// <param name="rec"></param>
    public void AddUser(List<User> rec);

    /// <summary>
    /// اپدیت کردن کاربر
    /// </summary>
    /// <param name="rec"></param>
    public void UpdateUser(User rec);
}