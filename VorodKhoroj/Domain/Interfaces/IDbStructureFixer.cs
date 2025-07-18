namespace VorodKhoroj.Domain.Interfaces;

public interface IDbStructureFixer
{
    /// <summary>
    ///     مایگریشن وجود ستون ایدی و در صورت نداشتن اضافه شود
    /// </summary>
    void EnsureIdColumnExists();
}