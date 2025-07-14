namespace VorodKhoroj.Helpers;

public static class Validation
{
    /// <summary>
    /// اعتبارسنجی رشته‌ها (غیرخالی بودن)
    /// </summary>
    public static bool IsValid(params string[] str) => !str.Any(string.IsNullOrWhiteSpace);

    /// <summary>
    /// اعتبارسنجی اعداد (نبود صفر)
    /// </summary>
    public static bool IsValid(params int[] values) => values is { Length: > 0 } && values.All(v => v != 0);

    /// <summary>
    /// اعتبارسنجی MaskedTextBoxها (پر بودن کامل ماسک)
    /// </summary>
    public static bool IsValid(params MaskedTextBox[] values) => values is { Length: > 0 } && values.All(v => v.MaskFull);
}