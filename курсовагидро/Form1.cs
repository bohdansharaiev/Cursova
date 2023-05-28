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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static курсовагидро.Form1;

namespace курсовагидро
{

    public partial class Form1 : Form
    {
        Form2 frm2;

        public Form1()
        {
            InitializeComponent();
            button2.Click += button2_Click;
        }






      
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Створити список річок
            Random rand = new Random();

            // Додати річки до списку

            for(int i = 0; i < 20; i++)
            {
               int fr = rand.Next(700, 2000);
                Rivers.Add(new River("River", fr, 200, "Country"));
            }
            for (int i = 0; i < 20; i++)
            {
                int fl =  rand.Next(700, 2000);
                Lakes.Add(new Lake("Lake", fl, 200, "Country"));
            }
            for (int i = 0; i < 20; i++)
            {
                int fs = rand.Next(700, 2000);
                Seas.Add(new Sea("Sea", fs, 200, "Country"));
            }

          
                table.Columns.Add("Назва", typeof(string));
                table.Columns.Add("Страна", typeof(string));
                table.Columns.Add("Довжина", typeof(int));
                table.Columns.Add("Flow", typeof(double));

            PrintAllBodiesOfWater();
            textBox3.TextChanged += textBox3_TextChanged;
            // Додати назви морів до комбо-боксу та рядки до таблиці


            // Додати назви річок до комбо-боксу

            comboBox1.Items.Add("Річки");
            comboBox1.Items.Add("Озера");
            comboBox1.Items.Add("Моря");
         

        }
        DataTable table = new DataTable();
        // Оновлений метод друку всіх водних об'єктів
        private void PrintAllBodiesOfWater()
        {
            dataGridView1.DataSource = null;
            table.Rows.Clear();
            table.Columns.Clear();

            table.Columns.Add("Назва", typeof(string));
            table.Columns.Add("Страна", typeof(string));
            table.Columns.Add("Довжина", typeof(int));
            table.Columns.Add("Flow", typeof(double));
            table.Columns.Add("Річний стік", typeof(double)); // Додати стовпець для річного стоку

            foreach (River river in Rivers.rivers)
            {
                table.Rows.Add(river.Name, river.Countries, river.Length, river.Flow, river.AnnualFlow);
            }

            foreach (Lake lake in Lakes.lakes)
            {
                table.Rows.Add(lake.Name, lake.Countries, lake.Length, lake.Flow); // Поле "Річний стік" для озер залишаємо порожнім
            }

            foreach (Sea sea in Seas.seas)
            {
                table.Rows.Add(sea.Name, sea.Countries, sea.Length, sea.Flow); // Поле "Річний стік" для морів залишаємо порожнім
            }

            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders);

            dataGridView1.DataSource = table;
            dataGridView1.Refresh();
        }
        public void Print(List<River> riversList, List<Lake> lakesList, List<Sea> seasList)
        {
            dataGridView1.DataSource = null;
            table.Rows.Clear();
            table.Columns.Clear();

            table.Columns.Add("Назва", typeof(string));
            table.Columns.Add("Страна", typeof(string));
            table.Columns.Add("Довжина", typeof(int));
            table.Columns.Add("Flow", typeof(double));
            table.Columns.Add("Річний стік", typeof(double)); // Додати стовпець для річного стоку

            if (comboBox1.SelectedItem == "Річки")
            {
                foreach (River river in riversList)
                {
                    table.Rows.Add(river.Name, river.Countries, river.Length, river.Flow,river.AnnualFlow);
                }
            }
            if (comboBox1.SelectedItem == "Озера")
            {
                foreach (Lake lake in lakesList)
                {
                    table.Rows.Add(lake.Name, lake.Countries, lake.Length, lake.Flow);
                }
            }
          if (comboBox1.SelectedItem == "Моря")
            {
                foreach (Sea sea in seasList)
                {
                    table.Rows.Add(sea.Name, sea.Countries, sea.Length, sea.Flow);
                }
            }
            if (comboBox1.SelectedItem == null)
            {
                PrintAllBodiesOfWater();
            }

            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders);

            dataGridView1.DataSource = table;
            dataGridView1.Refresh();
        }
        public void textBox3_TextChanged(object sender, EventArgs e)
        {
            string searchText = textBox3.Text.ToLower();

            // Очистити таблицю перед оновленням
            table.Rows.Clear();

            if (searchText != null)
            {
                if (comboBox1.SelectedItem == "Річки")
                {
                    foreach (River river in Rivers.rivers)
                    {
                        if (river.Name.ToLower().IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            table.Rows.Add(river.Name, river.Countries, river.Length, river.Flow, river.AnnualFlow);
                        }
                    }
                }
                else if (comboBox1.SelectedItem == "Озера")
                {
                    foreach (Lake lake in Lakes.lakes)
                    {
                        if (lake.Name.ToLower().IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            table.Rows.Add(lake.Name, lake.Countries, lake.Length, lake.Flow);
                        }
                    }
                }
                else if (comboBox1.SelectedItem == "Моря")
                {
                    foreach (Sea sea in Seas.seas)
                    {
                        if (sea.Name.ToLower().IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            table.Rows.Add(sea.Name, sea.Countries, sea.Length, sea.Flow);
                        }
                    }
                }
                else if (string.IsNullOrEmpty(comboBox1.Text))
                {
                    // Пошук по всіх елементах списків
                    foreach (River river in Rivers.rivers)
                    {
                        if (river.Name.ToLower().IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            table.Rows.Add(river.Name, river.Countries, river.Length, river.Flow, river.AnnualFlow);
                        }
                    }

                    foreach (Lake lake in Lakes.lakes)
                    {
                        if (lake.Name.ToLower().IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            table.Rows.Add(lake.Name, lake.Countries, lake.Length, lake.Flow);
                        }
                    }

                    foreach (Sea sea in Seas.seas)
                    {
                        if (sea.Name.ToLower().IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            table.Rows.Add(sea.Name, sea.Countries, sea.Length, sea.Flow);
                        }
                    }
                }

            }
            else
            {


                if (string.IsNullOrEmpty(comboBox1.Text))
                {
                    Print(Rivers.rivers, Lakes.lakes, Seas.seas);
                }

            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
           
               
                Print(Rivers.rivers, Lakes.lakes, Seas.seas);
               
          
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string name = textBox2.Text;
            string selectedType = comboBox1.SelectedItem.ToString();
            bool deleted = false;

            if (selectedType == "Річки")
            {
                River riverToDelete = Rivers.rivers.Find(r => r.Name == name);
                if (riverToDelete != null)
                {
                    Rivers.rivers.Remove(riverToDelete);
                    deleted = true;
                }
            }
            else if (selectedType == "Озера")
            {
                Lake lakeToDelete = Lakes.lakes.Find(l => l.Name == name);
                if (lakeToDelete != null)
                {
                    Lakes.lakes.Remove(lakeToDelete);
                    deleted = true;
                }
            }
            else if (selectedType == "Моря")
            {
                Sea seaToDelete = Seas.seas.Find(s => s.Name == name);
                if (seaToDelete != null)
                {
                    Seas.seas.Remove(seaToDelete);
                    deleted = true;
                }
            }

            if (deleted)
            {
                Print(Rivers.rivers, Lakes.lakes, Seas.seas);
            }
            else
            {
                MessageBox.Show("Невірна назва або водне тіло не знайдено.");
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
                table.Columns.Add("Назва(річки)", typeof(string));
                table.Columns.Add("Страна", typeof(string));
                table.Columns.Add("Довжина", typeof(int));
                table.Columns.Add("Flow", typeof(double));
            }
            else if (comboBox1.SelectedItem == "Озера")
            {
                table.Columns.Add("Назва(озера)", typeof(string));
                table.Columns.Add("Страна", typeof(string));
                table.Columns.Add("Довжина", typeof(int));
                table.Columns.Add("Flow", typeof(double));
            }

            else if (comboBox1.SelectedItem == "Моря")
            {
                table.Columns.Add("Назва(моря)", typeof(string));
                table.Columns.Add("Страна", typeof(string));
                table.Columns.Add("Довжина", typeof(int));
                table.Columns.Add("Площа", typeof(double));
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Створюємо новий екземпляр Form2 і присвоюємо його змінній frm
            Form2 form2 = new Form2();
           
            form2.Show();
     


        }

        private void button2_Click(object sender, EventArgs e)
        {
            string filePath = textBox1.Text;
            Dataclass.ClearFile(filePath);
            Dataclass.ExportData(filePath);
        }

       

    }
}


