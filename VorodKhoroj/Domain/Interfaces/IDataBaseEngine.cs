namespace VorodKhoroj.Domain.Interfaces
{
    public interface IDataBaseEngine
    {
        /// <summary>
        /// اجیاد دیتابیس با نام دلخواه و مسیر 
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="dbName"></param>
        void CreateDatabase(string filePath, string dbName);

        /// <summary>
        /// ایحاد جدول
        /// </summary>
        void CreateTables();

        /// <summary>
        /// قطع اتصال به دیتابیس متصل شده
        /// </summary>
        /// <param name="dbPathName"></param>
        /// <param name="dbName"></param>
        void DetachDatabase(string dbPathName, string dbName);

        /// <summary>
        /// تست اتصال ب سرور و اینستنس
        /// </summary>
        /// <param name="serverName"></param>
        /// <returns></returns>
        bool TestServerConnection(string serverName);
    }
}