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
        public static void ClearFile(string filePath)
        {
            try
            {


                File.WriteAllText(filePath, string.Empty);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка при експорті даних: " + ex.Message);
            }
        }
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

        public static void SaveRiversToFile(string filePath)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (var river in Rivers.rivers)
                    {
                        writer.WriteLine($"River,{river.Name},{river.Length},{river.Flow},{river.Countries}");
                    }
                }
                MessageBox.Show($"Річки збережено у файл {filePath}");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка при збереженні річок: " + ex.Message);
            }
        }

        public static void LoadRiversFromFile(string filePath)
        {
            try
            {
                List<River> rivers = new List<River>();
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(',');
                        if (parts.Length >= 5 && parts[0] == "River")
                        {
                            string name = parts[1];
                            int length = int.Parse(parts[2]);
                            double flow = double.Parse(parts[3]);
                            string countries = parts[4];
                            River river = new River(name, length, flow, countries);
                            rivers.Add(river);
                        }
                    }
                }
                Rivers.rivers = rivers;  // Replace the existing list with the loaded rivers
                MessageBox.Show($"Річки завантажено з файлу {filePath}");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка при завантаженні річок: " + ex.Message);
            }
        }
    }
    }

    
