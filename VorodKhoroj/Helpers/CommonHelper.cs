namespace VorodKhoroj.Classes
{
    public static class CommonHelper
    {
        public static void ShowMessage(Exception ex, [CallerMemberName] string methodName = "")
        {
            string text = $@"خطای داخلی{'\n'}{ex.Message}{'\n'}{ex.InnerException?.Message}";
            string caption = "خطا";
            Log.Error(ex, "MethodName: {MethodName}", methodName);
            MessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void ShowMessage(string message)
        {
            string caption = "پیام";
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static bool IsValid(params string[] str) => !str.Any(string.IsNullOrWhiteSpace);

        public static bool IsValid(params int[] values) => values is { Length: > 0 } && values.All(v => v != 0);

        public static bool IsValid(params MaskedTextBox[] values) => values is { Length: > 0 } && values.All(v => v.MaskFull);


    }
}