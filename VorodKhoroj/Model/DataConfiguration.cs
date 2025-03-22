namespace VorodKhoroj.Model
{
    public class DataConfiguration
    {
        public static List<Structure> Records = new();

        public enum LoginType
        {
            Face = 15, Finger = 1
        }

        public static void LoadDataFromFile(string FileAddress)
        {
            try
            {
                foreach (var line in File.ReadAllLines(FileAddress))
                {
                    var values = line.Split('\t');
                    if (values.Length == 6)
                    {
                        Records.Add(new Structure
                        {
                            UserId = int.Parse(values[0]),
                            DateTime = CommonHelpers.ConvertToShamsi(values[1]),
                            LoginType = CommonHelpers.ConvertToLoginType(values[4])
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public static DataTable ConvertToDataTable(List<Structure> _Records)
        {
            DataTable Records_Table = new();

            try
            {
                Records_Table.Columns.Add(nameof(Structure.UserId), typeof(object));
                Records_Table.Columns.Add(nameof(Structure.DateTime), typeof(object));
                Records_Table.Columns.Add(nameof(Structure.LoginType), typeof(object));
                foreach (var temp in _Records)
                {
                    Records_Table.Rows.Add(temp.UserId, temp.DateTime, temp.LoginType);
                }
                return Records_Table;

            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                throw new Exception(ex.Message);
            }
        }
    }

    public class Structure
    {
        public int UserId { get; set; }
        public DateTime DateTime { get; set; }
        //   public string DateTime { get; set; }
        public string LoginType { get; set; }
    }

}

//public static void LoadDataFromFile1(string FileAddress) //convert to datatable
//{
//    try
//    {

//        table.Columns.Add(nameof(Structure.UserId), new Structure().UserId.GetType());
//        table.Columns.Add(nameof(Structure.DateTime), new Structure().DateTime.GetType());
//        //   table.Columns.Add("Col3", typeof(int));
//        //  table.Columns.Add("Col4", typeof(int));
//        table.Columns.Add(nameof(Structure.LoginType), new Structure().LoginType.GetType());
//        //table.Columns.Add("Col6", typeof(int));

//        // خواندن و پردازش فایل
//        foreach (var line in File.ReadAllLines(FileAddress))
//        {
//            var values = line.Split('\t'); // جدا کردن با TAB
//            if (values.Length == 6)
//            {
//                table.Rows.Add(
//                    int.Parse(values[0]),
//                    CommonHelpers.ConvertToShamsi(values[1]),
//                    // int.Parse(values[2]),
//                    //    int.Parse(values[3]),
//                    CommonHelpers.ConvertToLoginType(values[4])
//                //      ,  int.Parse(values[5])
//                );
//            }
//        }
//    }
//    catch (Exception ex)
//    {
//        Log.Error(ex.Message);
//        throw new Exception(ex.Message);
//    }
//}