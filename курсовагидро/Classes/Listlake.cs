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
        public int BasinArea;
        public Lake(string name, int length, double flow, string countries,int width)
        {
            Name = name;
            Length = length;
            Flow = flow;
            Countries = countries;
            this.width = width;
            CalculateAnnualFlow(); // Обчислити річний сток при створенні об'єкта
            CalculateArea();
        }
        private void CalculateAnnualFlow()
        {
            // Обчислити річний сток і присвоїти його полю AnnualFlow
            // Припустимо, що величина Flow вимірюється в кубометрах на секунду.
            // Для обчислення річного стоку потрібно помножити потік на кількість секунд у році (60 секунд * 60 хвилин * 24 години * 365 днів).
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

        public static void Add(Lake Lake)
        {
            lakes.Add(Lake);
        }

    }
}
