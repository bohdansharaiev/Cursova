using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace курсовагидро
{
    internal class Listlake
    {
    }
    public class Lake
    {
        public string Name;
        public int Length;
        public double Flow;

        public string Countries;
        public int width;
        public double AnnualFlow;
        public double BasinArea;
        public Lake(string name, int length, double flow, string countries,int width)
        {
            Name = name;
            Length = length;
            Flow = flow;
            Countries = countries;
            this.width = width;
            CalculateAnnualFlow(); 
            CalculateArea();
        }
        private void CalculateAnnualFlow()
        {
            AnnualFlow = Flow * 60 * 60 * 24 * 365;
        }
        private void CalculateArea()
        {
            BasinArea = Length * width;
        }
    }

    public static class Lakes
    {

        public static bool fl = true;
        public static List<Lake> lakes = new List<Lake>();
        public static Lake ActualLake;

        public static Lake SearchName(string name)
        {
            return lakes.Find(lake => lake.Name == name);
        }
        public static void Add(Lake lake)
        {
            lakes.Add(lake);
        }

    }
}
