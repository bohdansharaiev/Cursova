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
        public double AnnualFlow; // Додати поле для річного стоку
        public int BasinArea;
        public string[] Tributaries; // Масив для зберігання прилеглих річок

        public River(string name, int length, double flow, string countries, int width,string[] tributaries)
        {
            Name = name;
            Length = length;
            Flow = flow;
            Countries = countries;
            this.width = width;
            Tributaries = tributaries;
            CalculateAnnualFlow();
            this.AnnualFlow = AnnualFlow ;
            CalculateArea();
            this.BasinArea = BasinArea;
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

    public static class Rivers
    {
        public static bool fl = true;

        public static River ActualRiver;
        public static List<River> rivers = new List<River>();
        public static River SearchName(string name)
        {
            foreach(River river in rivers)
            {
                if(river.Name == name)
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
    }
    

}
