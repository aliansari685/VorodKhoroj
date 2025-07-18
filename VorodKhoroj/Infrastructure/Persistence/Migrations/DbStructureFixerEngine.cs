namespace VorodKhoroj.Infrastructure.Persistence.Migrations
{
    public class DbStructureFixerEngine
    {
        /// <summary>
        /// برای دیتابیس های قدیمی که ستون ایدی ندارن ستون ایدی با امنیت اطلاعات قدیمی اضافه میشود
        /// </summary>
        /// <param name="appDbContext"></param>
        public void EnsureIdColumnExists(AppDbContext appDbContext)
        {
            string addIdColumnSql = @"
                                -- حذف کلید ترکیبی قدیمی اگر وجود دارد
                                IF EXISTS (
                                    SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS 
                                    WHERE TABLE_NAME = 'Attendances' AND CONSTRAINT_TYPE = 'PRIMARY KEY' AND CONSTRAINT_NAME = 'PK_Attendances'
                                )
                                BEGIN
                                    ALTER TABLE Attendances DROP CONSTRAINT PK_Attendances;
                                END;
                                
                                -- اضافه کردن ستون Id اگر وجود ندارد
                                IF NOT EXISTS (
                                    SELECT * FROM INFORMATION_SCHEMA.COLUMNS
                                    WHERE TABLE_NAME = 'Attendances' AND COLUMN_NAME = 'Id'
                                )
                                BEGIN
                                    ALTER TABLE Attendances ADD Id INT IDENTITY(1,1) NOT NULL;
                                END;
                                
                                -- اضافه کردن کلید اصلی جدید روی Id
                                IF NOT EXISTS (
                                    SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS 
                                    WHERE TABLE_NAME = 'Attendances' AND CONSTRAINT_TYPE = 'PRIMARY KEY'
                                )
                                BEGIN
                                    ALTER TABLE Attendances ADD CONSTRAINT PK_Attendances_Id PRIMARY KEY (Id);
                                END;
                                ";

            appDbContext.Database.ExecuteSqlRaw(addIdColumnSql);

        }
    }
}
