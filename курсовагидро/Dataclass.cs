using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static курсовагидро.Form1;
using System.IO;
using Newtonsoft.Json;
using System.Windows.Forms;

namespace курсовагидро
{



    public class Dataclass
    {

        public static void ExportData(string filePath)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (var river in Rivers.rivers)
                    {
                        writer.WriteLine($"River,{river.Name},{river.Length},{river.Flow},{river.Countries}");
                    }
                    foreach (var lake in Lakes.lakes)
                    {
                        writer.WriteLine($"Lake,{lake.Name},{lake.Length},{lake.Flow},{lake.Countries}");
                    }
                    foreach (var sea in Seas.seas)
                    {
                        writer.WriteLine($"Sea,{sea.Name},{sea.Length},{sea.Flow},{sea.Countries}");
                    }
                }
                MessageBox.Show($"Дані експортовано до файлу {filePath}");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка при експорті даних: " + ex.Message);
            }
        }


    }
}
    
