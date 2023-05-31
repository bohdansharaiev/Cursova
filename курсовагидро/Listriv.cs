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

        public double AnnualFlow; // Додати поле для річного стоку

        public River(string name, int length, double flow, string countries)
        {
            Name = name;
            Length = length;
            Flow = flow;
            Countries = countries;
            CalculateAnnualFlow(); // Обчислити річний сток при створенні об'єкта
        }

        private void CalculateAnnualFlow()
        {
            // Обчислити річний сток і присвоїти його полю AnnualFlow
            // Припустимо, що величина Flow вимірюється в кубометрах на секунду.
            // Для обчислення річного стоку потрібно помножити потік на кількість секунд у році (60 секунд * 60 хвилин * 24 години * 365 днів).
            AnnualFlow = Flow * 60 * 60 * 24 * 365;
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
