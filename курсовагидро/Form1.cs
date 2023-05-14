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






      
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Створити список річок


            // Додати річки до списку




          





            // Додати назви морів до комбо-боксу та рядки до таблиці


            // Додати назви річок до комбо-боксу

            comboBox1.Items.Add("Річки");
            comboBox1.Items.Add("Озера");
            comboBox1.Items.Add("Моря");

        }
        DataTable table = new DataTable();
        public void Print(List<River> riversList, List<Lake> lakesList, List<Sea> seasList)
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

            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders);

            dataGridView1.DataSource = table;
            dataGridView1.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Print(Rivers.rivers, Lakes.lakes, Seas.seas);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string name = textBox2.Text;
          
            if (comboBox1.SelectedItem == "Річки")
            {
                River riverToDelete = Rivers.rivers.Find(r => r.Name == name);
                if (riverToDelete != null)
                {
                    Rivers.rivers.Remove(riverToDelete);
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = Rivers.rivers;
                }
                else
                {
                    MessageBox.Show("Невірна назва");
                }
            }
            else if (comboBox1.SelectedItem == "Озера")
            {
                Lake lakeToDelete = Lakes.lakes.Find(l => l.Name == name);
                if (lakeToDelete != null)
                {
                    Lakes.lakes.Remove(lakeToDelete);
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = Lakes.lakes;
                }
                else
                {
                    MessageBox.Show("Невірна назва");
                }
            }
            else if (comboBox1.SelectedItem == "Моря")
            {
                Sea seaToDelete = Seas.seas.Find(s => s.Name == name);
                if (seaToDelete != null)
                {
                    Seas.seas.Remove(seaToDelete);
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = Seas.seas;
                }
                else
                {
                    MessageBox.Show("Невірна назва");
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
                table.Columns.Add("Flow", typeof(double));
            }

            else if (comboBox1.SelectedItem == "Моря")
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


