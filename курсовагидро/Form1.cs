﻿using System;
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
            public bool vpad { get; set; }
        }
        public class Lake
        {
            public string Name { get; set; }
            public int Length { get; set; }
        }
        public class Sea
        {
            public string Name { get; set; }
            public int Length { get; set; }
            public bool vpad { get; set; }
        }
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Створити список річок


            // Додати річки до списку
            rivers.Add(new River { Name = "Дніпро", Length = 2200,vpad = true });
            rivers.Add(new River { Name = "Дунай", Length = 2860 ,vpad = true});
            rivers.Add(new River { Name = "Волга", Length = 3530 ,vpad =  false});
            lakes.Add(new Lake { Name = "Венеція", Length = 2200 });
            lakes.Add(new Lake { Name = "Байкал", Length = 2200 });
            lakes.Add(new Lake { Name = "Вікторія", Length = 2200 });
            seas.Add(new Sea { Name = "Чорне", Length = 2200, vpad = true });
            seas.Add(new Sea { Name = "Азовське", Length = 2200, vpad = false });
            seas.Add(new Sea { Name = "Мертве", Length = 2200, vpad = false });

            // Додати назви озер до комбо-боксу

            dataGridView1.Columns.Add("Name", "Назва");
            dataGridView1.Columns.Add("Area", "Площа (км²)");
            dataGridView1.Columns["Name"].Width = 150;
            dataGridView1.Columns["Area"].Width = 100;

            // Додати назви морів до комбо-боксу та рядки до таблиці


            dataGridView1.Columns.Add("Name", "Назва");
            dataGridView1.Columns.Add("Length", "Довжина (км)");
            dataGridView1.Columns["Name"].Width = 150;
            dataGridView1.Columns["Length"].Width = 100;
            // Додати назви річок до комбо-боксу

            comboBox1.Items.Add("Річки");
            comboBox1.Items.Add("Озера");
            comboBox1.Items.Add("Моря");
            foreach (River river in rivers)
            {
                dataGridView1.Rows.Add(river.Name, river.Length);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string selectedWaterBody = comboBox1.SelectedItem.ToString();
          

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
                        if (river.vpad == true)
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
                        if (sea.vpad == true)
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

        private void button2_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                // Перевірити, чи впадає річка в море

                // Вивести інформацію про всі річки в RichTextBox
                richTextBox1.Clear();
                foreach (River river in rivers)
                {
                    if (river.vpad == true)
                    {
                        richTextBox1.AppendText("Назва: " + river.Name + "\n");
                        richTextBox1.AppendText("Довжина: " + river.Length.ToString() + " км\n");
                    }
                }
            }

        }
    }
}




