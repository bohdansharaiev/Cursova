using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace курсовагидро
{
    internal class Listsea
    {
    }
    public class Sea
    {
        public string Name;
        public int Length;
        public double Flow;

        public string Countries;
        public int width;
        public double AnnualFlow;
        public double BasinArea;
        public Sea(string name, int length, double flow,
            string countries, int width)

        {
            Name = name;
            Length = length;
            Flow = flow;
            Countries = countries;
            this.width = width;
            CalculateAnnualFlow(); 
            CalculateArea();
        }
        // річний стік
        private void CalculateAnnualFlow()
        {
            AnnualFlow = Flow * 60 * 60 * 24 * 365;
        }
        // площа басейну
        private void CalculateArea()
        {
            BasinArea = Length * width;
        }
    }

    public static class Seas
    {
        public static bool fl = true;
        public static List<Sea> seas = new List<Sea>();
        public static Sea ActualSea;
   
        public static Sea SearchName(string name)
        {
            return seas.Find(sea => sea.Name == name);
        }
        public static void Add(Sea sea)
        {
            seas.Add(sea);
        }

    }
}
