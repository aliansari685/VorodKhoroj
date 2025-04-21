namespace VorodKhoroj.Classes
{
    public static class CommonHelper
    {
        public static string GetCallerMethod([CallerMemberName] string methodName = "")
        {
            return methodName;
        }

        public static void ShowMessage(Exception ex)
        {
            using (LogContext.PushProperty("Method", GetCallerMethod()))
            {
                string text = $@"خطای داخلی{'\n'}{ex.Message}{'\n'}{ex.InnerException?.Message}";
                string caption = "خطا";
                Log.Error(text);
                MessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public static void ShowMessage(string message)
        {
            string caption = "پیام";
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static bool IsValid(params string[] str) => !str.Any(string.IsNullOrWhiteSpace);

        public static bool IsValid(params int[] values) => values is { Length: > 0 } && values.All(v => v != 0);

        public static bool IsValid(params object[]? obj)
        {

            return obj is { Length: > 0 } && obj.All(o => o is not null);

        }


    }
}