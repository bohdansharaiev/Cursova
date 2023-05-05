using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static курсовагидро.Form1;

namespace курсовагидро
{
    public partial class Form1 : Form
    {
        private List<River> rivers = new List<River>();
        private List<Lake> lakes = new List<Lake>();
        private List<Sea> seas = new List<Sea>();
        public Form1()
        {
            InitializeComponent();



        }
       
        public class River
        {
            public string Name { get; set; }
            public int Length { get; set; }
            public bool Vpad { get; set; }
            public double Flow { get; set; }
            public double BasinArea { get; set; }
            public string Location { get; set; }
            public bool Navigable { get; set; }
            public string Countries { get; set; }
        }

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
            rivers.Add(new River { Name = "Дніпро", Length = 2200, Vpad = true, Flow = 1738, BasinArea = 504000, Location = "Europe", Navigable = true, Countries = "Ukraine, Russia, Belarus" });
            rivers.Add(new River { Name = "Дунай", Length = 2860, Vpad = true, Flow = 2000, BasinArea = 817000, Location = "Europe", Navigable = true, Countries = "Germany, Austria, Slovakia, Hungary, Croatia, Serbia, Romania, Bulgaria, Ukraine" });
            rivers.Add(new River { Name = "Волга", Length = 3530, Vpad = false, Flow = 2500, BasinArea = 1390000, Location = "Europe", Navigable = true, Countries = "Russia" });

            lakes.Add(new Lake { Name = "Венеція", Length = 54, Depth = 5, Volume = 35.5, Countries = "Italy" });
            lakes.Add(new Lake { Name = "Байкал", Length = 636, Depth = 1637, Volume = 23600, Countries = "Russia" });
            lakes.Add(new Lake { Name = "Вікторія", Length = 322, Depth = 84, Volume = 2850, Countries = "Uganda, Kenya, Tanzania" });

            seas.Add(new Sea { Name = "Чорне", Length = 580, Vpad = true, Volume = 547000, AverageDepth = 1240, Countries = "Ukraine, Russia, Turkey, Romania, Bulgaria, Georgia" });
            seas.Add(new Sea { Name = "Азовське", Length = 360, Vpad = false, Volume = 11100, AverageDepth = 7, Countries = "Russia, Ukraine" });
            seas.Add(new Sea { Name = "Мертве", Length = 50, Vpad = false, Volume = 11100, AverageDepth = 7, Countries = "Russia, Ukraine" });



            dataGridView1.Columns.Add("Name", "Назва");
            dataGridView1.Columns.Add("Area", "Площа (км²)");
            dataGridView1.Columns.Add("Vpad", "Впадає");
            dataGridView1.Columns.Add("Depth", "Глибина (км²)");
            dataGridView1.Columns.Add("Location", "Місце");
            dataGridView1.Columns.Add("Flow", "Flow (км²)");
            dataGridView1.Columns["Name"].Width = 150;
            dataGridView1.Columns["Area"].Width = 100;
            dataGridView1.Columns["Vpad"].Width = 100;
            dataGridView1.Columns["Depth"].Width = 100;
            dataGridView1.Columns["Location"].Width = 100;

            // Додати назви морів до комбо-боксу та рядки до таблиці


            // Додати назви річок до комбо-боксу

            comboBox1.Items.Add("Річки");
            comboBox1.Items.Add("Озера");
            comboBox1.Items.Add("Моря");
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            dataGridView1.Rows.Clear();






         
           

            if (comboBox1.SelectedItem != null)
            {
                string selectedWaterBody = comboBox1.SelectedItem.ToString();
                // Ваш код здесь


                if (selectedWaterBody == "Річки")
                {
                    foreach (River river in rivers)
                    {
                        if (checkBox1.Checked)
                        {
                            // Перевірити, чи впадає річка в море

                            // Вивести інформацію про всі річки в RichTextBox


                            if (river.Vpad == true)
                            {
                                dataGridView1.Rows.Add(river.Name, river.Length, river.Vpad, river.Location);
                            }

                        }
                        else
                        {
                            dataGridView1.Rows.Add(river.Name, river.Length, river.Vpad, river.Location);
                        }
                    }
                }
                if (selectedWaterBody == "Озера")
                {

                    foreach (Lake lake in lakes)
                    {
                        dataGridView1.Rows.Add(lake.Name, lake.Length, lake.Countries);
                    }
                }
                if (selectedWaterBody == "Моря")
                {
                    foreach (Sea sear in seas)
                    {
                        dataGridView1.Rows.Add(sear.Name, sear.Length, sear.Vpad, sear.Countries);
                    }
                }
                if (selectedWaterBody == "Річки")
                {
                    // Вивести інформацію про всі річки в RichTextBox

                    // Перевірити, чи впадає річка в море

                    // Вивести інформацію про всі річки в RichTextBox
                    richTextBox1.Clear();
                    foreach (River river in rivers)
                    {
                        if (checkBox1.Checked)
                        {
                            if (river.Vpad == true)
                            {
                                richTextBox1.AppendText("Назва: " + river.Name + "\n");
                                richTextBox1.AppendText("Довжина: " + river.Length.ToString() + " км\n");
                            }
                        }
                        else
                        {
                            richTextBox1.AppendText("Назва: " + river.Name + "\n");
                            richTextBox1.AppendText("Довжина: " + river.Length.ToString() + " км\n");
                        }
                    }
                }
                else if (selectedWaterBody == "Озера")
                {
                    // Вивести інформацію про всі озера в RichTextBox
                    richTextBox1.Clear();
                    foreach (Lake lake in lakes)
                    {
                        richTextBox1.AppendText("Назва: " + lake.Name + "\n");
                        richTextBox1.AppendText("Довжина: " + lake.Length.ToString() + " км\n");
                    }
                }
                else if (selectedWaterBody == "Моря")
                {
                    // Вивести інформацію про всі моря в RichTextBox
                    richTextBox1.Clear();
                    foreach (Sea sea in seas)
                    {
                        if (checkBox2.Checked)
                        {
                            if (sea.Vpad == true)
                            {


                                richTextBox1.AppendText("Назва: " + sea.Name + "\n");
                            }
                        }
                        else
                        {
                            richTextBox1.AppendText("Назва: " + sea.Name + "\n");
                        }
                    }
                }
                
            }
            else
            {
                MessageBox.Show("Необходимо выбрать водное тело.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string selectedWaterBody = comboBox1.SelectedItem.ToString();
            if (selectedWaterBody == "Річки")
            {
                string name = textBox1.Text;
                River newRiver = new River { Name = name };

                rivers.Add(newRiver);
            }
            else if (selectedWaterBody == "Озера")
            {
                string name = textBox1.Text;
                Lake newLake = new Lake { Name = name };

                lakes.Add(newLake);
            }
            else if (selectedWaterBody == "Моря")
            {

                string name = textBox1.Text;
                Sea newSea = new Sea { Name = name };

                seas.Add(newSea);
            }
            }

        private void button3_Click(object sender, EventArgs e)
        {
            string selectedWaterBody = comboBox1.SelectedItem.ToString();
            if (selectedWaterBody == "Річки")
            {
                string name = textBox2.Text;

                River riverToDelete = null;
                foreach (River river in rivers)
                {
                    if (river.Name == name)
                    {
                        riverToDelete = river;
                        break;
                    }
                }

                if (riverToDelete != null)
                {
                    rivers.Remove(riverToDelete);
                    dataGridView1.Rows.Clear();
                    foreach (River river in rivers)
                    {
                        dataGridView1.Rows.Add(river.Name);
                    }
                }
            }



            string selectedWaterBody2 = comboBox1.SelectedItem.ToString();
            if (selectedWaterBody2 == "Озера")
            {
                string name = textBox2.Text;

                Lake lakeToDelete = null;
                foreach (Lake lake in lakes)
                {
                    if (lake.Name == name)
                    {
                        lakeToDelete = lake;
                        break;
                    }
                }

                if (lakeToDelete != null)
                {
                    lakes.Remove(lakeToDelete);
                    dataGridView1.Rows.Clear();
                    foreach (Lake lake in lakes)
                    {
                        dataGridView1.Rows.Add(lake.Name);
                    }
                }
            }
            string selectedWaterBody3 = comboBox1.SelectedItem.ToString();
            if (selectedWaterBody3 == "Моря")
            {
                string name = textBox2.Text;

                Sea seaToDelete = null;
                foreach (Sea sea in seas)
                {
                    if (sea.Name == name)
                    {
                        seaToDelete = sea;
                        break;
                    }
                }

                if (seaToDelete != null)
                {
                    seas.Remove(seaToDelete);
                    dataGridView1.Rows.Clear();
                    foreach (Sea sea in seas)
                    {
                        dataGridView1.Rows.Add(sea.Name);
                    }
                }
            }
        }
    }
   
}








