using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static курсовагидро.Form1;

namespace курсовагидро
{
   
    public partial class Form1 : Form
    {
        Form2 frm2;
      
        public Form1()
        {
            InitializeComponent();
        }

      
        public List<Lake> lakes = new List<Lake>();
        public List<Sea> seas = new List<Sea>();
        
        public class Lake
        {
            public string Name { get; set; }
            public int Length { get; set; }
            public int Depth { get; set; }
            public double Volume { get; set; }
            public string Countries { get; set; }
        }

        public class Sea
        {
            public string Name { get; set; }
            public int Length { get; set; }
            public bool Vpad { get; set; }
            public double Volume { get; set; }
            public double AverageDepth { get; set; }
            public string Countries { get; set; }
        }
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Створити список річок
         

            // Додати річки до списку
           

            lakes.Add(new Lake { Name = "Венеція", Length = 54, Depth = 5, Volume = 35.5, Countries = "Italy" });
            lakes.Add(new Lake { Name = "Байкал", Length = 636, Depth = 1637, Volume = 23600, Countries = "Russia" });
            lakes.Add(new Lake { Name = "Вікторія", Length = 322, Depth = 84, Volume = 2850, Countries = "Uganda, Kenya, Tanzania" });

            seas.Add(new Sea { Name = "Чорне", Length = 580, Vpad = true, Volume = 547000, AverageDepth = 1240, Countries = "Ukraine, Russia, Turkey, Romania, Bulgaria, Georgia" });
            seas.Add(new Sea { Name = "Азовське", Length = 360, Vpad = false, Volume = 11100, AverageDepth = 7, Countries = "Russia, Ukraine" });
            seas.Add(new Sea { Name = "Мертве", Length = 50, Vpad = false, Volume = 11100, AverageDepth = 7, Countries = "Russia, Ukraine" });



          

            // Додати назви морів до комбо-боксу та рядки до таблиці


            // Додати назви річок до комбо-боксу

            comboBox1.Items.Add("Річки");
            comboBox1.Items.Add("Озера");
            comboBox1.Items.Add("Моря");
            
        }
        DataTable table = new DataTable();
        public void Print(List<River> list)
        {
            dataGridView1.DataSource = null;
            table.Rows.Clear();
            table.Columns.Clear();

            table.Columns.Add("Назва", typeof(string));
            table.Columns.Add("Страна", typeof(string));
            table.Columns.Add("Довжина", typeof(int));
           
            table.Columns.Add("Flow", typeof(double));
            
            foreach (River river in list)
            {
                table.Rows.Add(river.Name, river.Length, river.Flow, river.Countries);
                
            }
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //dataGridView1.AutoResizeColumns();
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders);

            dataGridView1.DataSource = table;
            dataGridView1.Refresh();
        }


      
        private void button1_Click(object sender, EventArgs e)
        {
            Print(Rivers.rivers);
            
        }
       
        private void button4_Click(object sender, EventArgs e)
        {
             frm2 = new Form2();
            frm2.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string name = textBox2.Text;
            River riverToDelete = null;
            foreach (River river in Rivers.rivers)
            {
                if (river.Name == name)
                {
                    riverToDelete = river;
                    break;
                }
            }

            if (riverToDelete != null)
            {
                Rivers.rivers.Remove(riverToDelete);
                dataGridView1.Rows.Clear();
                foreach (River river in Rivers.rivers)
                {
                    dataGridView1.Rows.Add(river.Name);
                }
            }
        }
    }
   
}




