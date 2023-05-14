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
        public Lake(string name, int length, double flow, string countries)
        {
            Name = name;
            Length = length;
            Flow = flow;
            Countries = countries;
        }
    }

    public static class Lakes
    {
        public static bool fl = true;
        public static List<Lake> lakes = new List<Lake>();

        public static void Add(Lake Lake)
        {
            lakes.Add(Lake);
        }

    }
}
