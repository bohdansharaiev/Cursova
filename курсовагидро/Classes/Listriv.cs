using System;
using System.Collections.Generic;


namespace курсовагидро
{
    internal class Listriv
    {

    }
    // класс річки
    public class River
    {
        public string Name;
        public int Length;
        public double Flow;
        public string Countries;
        public int width;
        public double AnnualFlow;
        public double BasinArea;
        public List<River> Trib = new List<River>();

        public River(string name, int length, double flow,
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
        // метод розрахунку річного стоку
       public void CalculateAnnualFlow()
        {
            AnnualFlow = Flow * 60 * 60 * 24 * 365;

            foreach (River tributary in Trib)
            {
                AnnualFlow += tributary.AnnualFlow;
            }
        }
        // метод розрахунку площи басейну
        public void CalculateArea()
        {
            BasinArea = Length * width;

            foreach (River tributary in Trib)
            {
                BasinArea += tributary.BasinArea;
            }
        }
    }

    public static class RiverList
    {
        public static bool fl = true;

        public static River ActualRiver;
        public static List<River> rivers = new List<River>();
        // метод пошуку річки по назві
        public static River SearchName(string name)
        {
            return rivers.Find(river => river.Name == name);
        }

        public static void Add(River river)
        {
            rivers.Add(river);
        }

    }
}
