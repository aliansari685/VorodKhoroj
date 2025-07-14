namespace VorodKhoroj.Classes
{
    public static class CommonHelper
    {
        /// <summary>
        /// اجرای سالم کوئری
        /// </summary>
        /// <param name="action"></param>
        public static void ExecuteSafeQuery(Action action)
        {
            try
            {
                action();
            }
            catch (DbUpdateException ex)
            {
                ShowMessage(ex);
            }
            catch (DbException ex)
            {
                CommonHelper.ShowMessage(ex);
            }
            catch (Exception ex)
            {
                CommonHelper.ShowMessage(ex);
            }
        }

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
    }
}