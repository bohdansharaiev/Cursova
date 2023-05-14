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
        public Sea(string name, int length, double flow, string countries)
        {
            Name = name;
            Length = length;
            Flow = flow;
            Countries = countries;
        }
    }

    public static class Seas
    {
        public static bool fl = true;
        public static List<Sea> seas = new List<Sea>();

        public static void Add(Sea sea)
        {
            seas.Add(sea);
        }

    }
}
