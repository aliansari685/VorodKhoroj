namespace VorodKhoroj.Model
{
    public class DataRepository
    {
        public List<Structure> GetRecordsFromFile(string FileAddress)
        {
            List<Structure> _records = new();
            try
            {
                foreach (var line in File.ReadAllLines(FileAddress))
                {
                    var values = line.Split('\t');
                    if (values.Length == 6)
                    {
                        _records.Add(new()
                        {

                            UserId = int.Parse(values[0]),
                            DateTime = PersianDateHelper.ConvertToShamsi(values[1]),
                            LoginType = Structure.LoginType_String(values[4])
                        });
                    }
                }

                return _records;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }

}

//public static DataTable ConvertToDataTable(List<Structure> _Records)
//{
//    DataTable Records_Table = new();

//    try
//    {
//        Records_Table.Columns.Add(nameof(Structure.UserId), typeof(object));
//        Records_Table.Columns.Add(nameof(Structure.DateTime), typeof(object));
//        Records_Table.Columns.Add(nameof(Structure.LoginType), typeof(object));
//        foreach (var temp in _Records)
//        {
//            Records_Table.Rows.Add(temp.UserId, temp.DateTime, temp.LoginType);
//        }
//        return Records_Table;

//    }
//    catch (Exception ex)
//    {
//        Log.Error(ex.Message);
//        throw new Exception(ex.Message);
//    }
//}