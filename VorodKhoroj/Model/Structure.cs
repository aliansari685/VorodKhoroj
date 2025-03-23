namespace VorodKhoroj.Model
{
    public class Structure
    {
        private enum LoginTypeEnum
        {
            Face = 15,
            Finger = 1
        }

        public static string LoginType_String(string number)
        {
            var num = int.Parse(number);
            return ((LoginTypeEnum)num).ToString();
        }
        public int UserId { get; set; }
        public DateTime DateTime { get; set; }

        public string LoginType { get; set; }
        //   public string DateTime { get; set; }

    }
}
