namespace VorodKhoroj.Classes
{
    public static class CommonHelper
    {
        /// <summary>
        /// نمایش پیغام خطا با جزییات Exception و لاگ انداختن خطا
        /// </summary>
        public static void ShowMessage(Exception ex, [CallerMemberName] string methodName = "")
        {
            string innerMessage = ex.InnerException?.Message ?? "";
            string text = $"خطای داخلی{'\n'}{ex.Message}" + (string.IsNullOrWhiteSpace(innerMessage) ? "" : $"\n{innerMessage}");
            string caption = "خطا";
            Log.Error(ex, "MethodName: {MethodName}", methodName);
            MessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// نمایش پیغام متنی ساده
        /// </summary>
        public static void ShowMessage(string message)
        {
            const string caption = "پیام";
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

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
}