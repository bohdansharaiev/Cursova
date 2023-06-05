using System;
using System.Collections.Generic;
using System.IO;
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
                MessageBox.Show("Помилка при перезаписі файла: " + ex.Message);
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
                        if (parts.Length >= 6 && parts[0] == "River")
                        {
                            string name = parts[1];
                            int length = int.Parse(parts[2]);
                            double flow = double.Parse(parts[3]);
                            string countries = parts[4];
                            int width = int.Parse(parts[5]);
                            
                            River river = new River(name, length, flow, countries, width);
                            rivers.Add(river);
                        }
                    }
                }
                RiverList.rivers = rivers;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка при завантаженні річок: " + ex.Message);
            }
        }
        public static void LoadLakesFromFile(string filePath)
        {
            try
            {
                List<Lake> lakes = new List<Lake>();
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(',');
                        if (parts.Length >= 6 && parts[0] == "Lake")
                        {
                            string name = parts[1];
                            int area = int.Parse(parts[2]);
                            double depth = double.Parse(parts[3]);
                            string countries = parts[4];
                            int width = int.Parse(parts[5]);
                            Lake lake = new Lake(name, area, depth, countries,width);
                            lakes.Add(lake);
                        }
                    }
                }
                Lakes.lakes = lakes;  // Replace the existing list with the loaded lakes
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка при завантаженні озер: " + ex.Message);
            }
        }

        public static void LoadSeasFromFile(string filePath)
        {
            try
            {
                List<Sea> seas = new List<Sea>();
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(',');
                        if (parts.Length >= 6 && parts[0] == "Sea")
                        {
                            string name = parts[1];
                            int area = int.Parse(parts[2]);
                            double maxDepth = double.Parse(parts[3]);
                            string countries = parts[4];
                            int width = int.Parse(parts[5]);
                            Sea sea = new Sea(name, area, maxDepth, countries,width);
                            seas.Add(sea);
                        }
                    }
                }
                Seas.seas = seas; 
              
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка при завантаженні морів: " + ex.Message);
            }
        }
        public static void SaveDataToFile(string filePath)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (River river in RiverList.rivers)
                    {
                        writer.WriteLine($"River,{river.Name},{river.Length},{river.Flow}," +
                            $"{river.Countries},{river.width}");
                    }

                   
                    foreach (Lake lake in Lakes.lakes)
                    {
                        writer.WriteLine($"Lake,{lake.Name},{lake.Length}," +
                            $"{lake.Flow},{lake.Countries},{lake.width}");
                    }

                    foreach (Sea sea in Seas.seas)
                    {
                        writer.WriteLine($"Sea,{sea.Name},{sea.Length}," +
                            $"{sea.Flow},{sea.Countries},{sea.width}");
                    }
                }

               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка при збереженні даних у файл: " + ex.Message);
            }
        }
    }
    }

    
