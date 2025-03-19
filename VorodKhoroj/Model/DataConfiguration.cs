using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Serilog;
using VorodKhoroj.Classes;

namespace VorodKhoroj.Model
{
    public class DataConfiguration
    {
        public static DataTable table = new();
        public enum LoginType
        {
            Face = 15, Finger = 1
        }
        public static void LoadDataFromFile(string FileAddress)
        {
            try
            {

                table.Columns.Add(nameof(Structure.UserId), new Structure().UserId.GetType());
                table.Columns.Add(nameof(Structure.DateTime), new Structure().DateTime.GetType());
                //   table.Columns.Add("Col3", typeof(int));
                //  table.Columns.Add("Col4", typeof(int));
                table.Columns.Add(nameof(Structure.LoginType), new Structure().LoginType.GetType());
                //table.Columns.Add("Col6", typeof(int));

                // خواندن و پردازش فایل
                foreach (var line in File.ReadAllLines(FileAddress))
                {
                    var values = line.Split('\t'); // جدا کردن با TAB
                    if (values.Length == 6)
                    {
                        table.Rows.Add(
                            int.Parse(values[0]),
                            CommonHelpers.ConvertToShamsi(values[1]),
                           // int.Parse(values[2]),
                           //    int.Parse(values[3]),
                           CommonHelpers.ConvertToLoginType(values[4])
                        //      ,  int.Parse(values[5])
                        );
                    }
                }
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
        public string DateTime { get; set; }
        public int LoginType { get; set; }
    }

}
