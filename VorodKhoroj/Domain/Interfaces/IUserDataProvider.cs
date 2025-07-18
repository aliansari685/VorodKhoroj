namespace VorodKhoroj.Domain.Interfaces
{
    /// <summary>
    /// عملیات دریافت کربران از پروایدر های مشخص شده
    /// Factory Pattern
    /// </summary>

    public interface IUserDataProvider
    {
        /// <summary>
        /// دریافت لیست کاربران
        /// </summary>
        /// <returns></returns>
        IList GetUserDataProvider();
    }
}
