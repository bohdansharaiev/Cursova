using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public River(string name, int length, double flow, string countries)
        {
            Name = name;
            Length = length;
            Flow = flow;
            Countries = countries;
        }
    }

    public static class Rivers
    {
        public static bool fl = true;
        public static List<River> rivers = new List<River>();

        public static void Add(River river)
        {
            rivers.Add(river);
        }

    }
    

}
