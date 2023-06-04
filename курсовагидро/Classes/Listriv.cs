using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace курсовагидро
{
    internal class Listriv
    {

    }

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

        public River(string name, int length, double flow, string countries, int width)
        {
            Name = name;
            Length = length;
            Flow = flow;
            Countries = countries;
            this.width = width;

            CalculateAnnualFlow();
            CalculateArea();
        }

       public void CalculateAnnualFlow()
        {
            AnnualFlow = Flow * 60 * 60 * 24 * 365;

            foreach (River tributary in Trib)
            {
                AnnualFlow += tributary.AnnualFlow;
            }
        }

       public void CalculateArea()
        {
            BasinArea = Length * width;

            foreach (River tributary in Trib)
            {
                BasinArea += tributary.BasinArea;
            }
        }
    }

    public static class Rivers
    {
        public static bool fl = true;

        public static River ActualRiver;
        public static List<River> rivers = new List<River>();

        public static River SearchName(string name)
        {
            foreach (River river in rivers)
            {
                if (river.Name == name)
                {
                    return river;
                }
            }
            return null;
        }

        public static void Add(River river)
        {
            rivers.Add(river);
        }

        public static double CalculateTotalFlow(River river)
        {
            double totalFlow = river.Flow;

            foreach (River tributary in river.Trib)
            {
                totalFlow += CalculateTotalFlow(tributary);
            }

            return totalFlow;
        }

        public static double CalculateTotalArea(River river)
        {
            double totalArea = river.BasinArea;

            foreach (River tributary in river.Trib)
            {
                totalArea += CalculateTotalArea(tributary);
            }

            return totalArea;
        }
    }
}
