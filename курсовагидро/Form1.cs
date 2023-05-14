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



        public List<Sea> seas = new List<Sea>();



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
        public void Print(List<River> riversList, List<Lake> lakesList)
        {
            dataGridView1.DataSource = null;
            table.Rows.Clear();
            table.Columns.Clear();

            table.Columns.Add("Назва", typeof(string));
            table.Columns.Add("Страна", typeof(string));
            table.Columns.Add("Довжина", typeof(int));
            table.Columns.Add("Flow", typeof(double));

            if (comboBox1.SelectedItem == "Річки")
            {
                foreach (River river in riversList)
                {
                    table.Rows.Add(river.Name, river.Countries, river.Length, river.Flow);
                }
            }
            else if (comboBox1.SelectedItem == "Озера")
            {
                foreach (Lake lake in lakesList)
                {
                    table.Rows.Add(lake.Name, lake.Countries, lake.Length, lake.Flow);
                }
            }
            else if (comboBox1.SelectedItem == "Моря")
            {
                // Add code to populate table with data for "Моря"
            }

            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders);

            dataGridView1.DataSource = table;
            dataGridView1.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Print(Rivers.rivers, Lakes.lakes);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string name = textBox2.Text;
            River riverToDelete = null;
            Lake lakeToDelete = null;

            if (comboBox1.SelectedItem == "Річки")
            {
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

                    foreach (River river in Rivers.rivers)
                    {
                        dataGridView1.Rows.Add(river.Name);
                    }
                }
            }
            else if (comboBox1.SelectedItem == "Озера")
            {
                foreach (Lake lake in Lakes.lakes)
                {
                    if (lake.Name == name)
                    {
                        lakeToDelete = lake;
                        break;
                    }
                }

                if (lakeToDelete != null)
                {
                    Lakes.lakes.Remove(lakeToDelete);

                    foreach (Lake lake in Lakes.lakes)
                    {
                        dataGridView1.Rows.Add(lake.Name);
                    }
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Clear the data grid view
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            // Clear the table
            table.Rows.Clear();
            table.Columns.Clear();

            // Add columns to the table based on the selected item in the combo box
            if (comboBox1.SelectedItem == "Річки")
            {
                table.Columns.Add("Назва", typeof(string));
                table.Columns.Add("Страна", typeof(string));
                table.Columns.Add("Довжина", typeof(int));
                table.Columns.Add("Flow", typeof(double));
            }
            else if (comboBox1.SelectedItem == "Озера")
            {
                table.Columns.Add("Назва", typeof(string));
                table.Columns.Add("Страна", typeof(string));
                table.Columns.Add("Довжина", typeof(int));
                table.Columns.Add("Площа", typeof(double));
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            frm2 = new Form2();
            frm2.ShowDialog();
        }
    }
}


