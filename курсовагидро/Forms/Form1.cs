using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using курсовагидро.Forms;
using static курсовагидро.Form1;


namespace курсовагидро
{

    public partial class Form1 : MaterialForm
    {
        

        public Form1()
        {
            InitializeComponent();
           
            dataGridView1.CellDoubleClick += dataGridView1_CellDoubleClick;
            System.Windows.Forms.Button button = new System.Windows.Forms.Button();
            int border = 10;
            SetRoundedButtonStyle(button1, border);
          
            SetRoundedButtonStyle(button3, border);
            SetRoundedButtonStyle(button4, border);
            
   


            // Встановити мінімальне та максимальне значення для тракбару
            trackBar1.Minimum = 0;
            trackBar1.Maximum = 7000;

            // Додати обробник події при зміні значення тракбару
            trackBar1.ValueChanged += TrackBar1_ValueChanged;

            // Оновити значення тракбару за замовчуванням
            trackBar1.Value = 0;
        }
       
        private void SetRoundedButtonStyle(Button button, int borderRadius)
        {
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.BackColor = SystemColors.GradientActiveCaption;
            button.FlatAppearance.MouseDownBackColor = SystemColors.GradientActiveCaption;
            button.FlatAppearance.MouseOverBackColor = Color.LightGray;

            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddArc(0, 0, borderRadius, borderRadius, 180, 90); // Ліва верхня дуга
            path.AddArc(button.Width - borderRadius, 0, borderRadius, borderRadius, 270, 90); // Права верхня дуга
            path.AddArc(button.Width - borderRadius, button.Height - borderRadius, borderRadius, borderRadius, 0, 90); // Права нижня дуга
            path.AddArc(0, button.Height - borderRadius, borderRadius, borderRadius, 90, 90); // Ліва нижня дуга
            path.CloseAllFigures();

            button.Region = new Region(path);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // Створити список річок
            Random rand = new Random();
            string file = "C:\\Users\\Богдан\\source\\repos\\курсоваgидро3\\курсовагидро\\file.txt";

            Dataclass.LoadRiversFromFile(file);
            // Додати річки до списку
            Dataclass.LoadLakesFromFile(file);
            Dataclass.LoadSeasFromFile(file);
            // Зміна коліру кнопки
         
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
            table.Columns.Add("Річний стік", typeof(double)); 
            table.Columns.Add("Площа басейну", typeof(double));
            table.Columns.Add("Впадіння річки", typeof(string));
            foreach (River river in Rivers.rivers)
            {
                table.Rows.Add(river.Name, river.Countries, river.Length, river.Flow, river.AnnualFlow,river.BasinArea, string.Join("; ", river.Tributaries));
            }

            foreach (Lake lake in Lakes.lakes)
            {
                table.Rows.Add(lake.Name, lake.Countries, lake.Length, lake.Flow, lake.AnnualFlow,lake.BasinArea); // Поле "Річний стік" для озер залишаємо порожнім
            }

            foreach (Sea sea in Seas.seas)
            {
                table.Rows.Add(sea.Name, sea.Countries, sea.Length, sea.Flow, sea.AnnualFlow,sea.BasinArea); // Поле "Річний стік" для морів залишаємо порожнім
            }

            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders);

            dataGridView1.DataSource = table;
            dataGridView1.Refresh();
        }
        // заповення таблиці
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
            
            table.Columns.Add("Площа басейну", typeof(double));
            if (comboBox1.SelectedItem != null)
            {

                if (comboBox1.SelectedItem == "Річки")
                {
                    dataGridView1.DataSource = null;
                    table.Rows.Clear();
                    table.Columns.Clear();

                    table.Columns.Add("Назва", typeof(string));
                    table.Columns.Add("Страна", typeof(string));
                    table.Columns.Add("Довжина", typeof(int));
                    table.Columns.Add("Flow", typeof(double));
                    table.Columns.Add("Річний стік", typeof(double)); // Додати стовпець для річного стоку

                    table.Columns.Add("Площа басейну", typeof(double));
                    table.Columns.Add("Впадіння річки", typeof(string));

                    foreach (River river in riversList)
                    {
                        table.Rows.Add(river.Name, river.Countries, river.Length, river.Flow, river.AnnualFlow, river.BasinArea,
                string.Join("; ", river.Tributaries));


                    }
                }
                if (comboBox1.SelectedItem == "Озера")
                {
                    foreach (Lake lake in lakesList)
                    {
                        table.Rows.Add(lake.Name, lake.Countries, lake.Length, lake.Flow, lake.AnnualFlow, lake.BasinArea);
                    }
                }
                if (comboBox1.SelectedItem == "Моря")
                {
                    foreach (Sea sea in seasList)
                    {
                        table.Rows.Add(sea.Name, sea.Countries, sea.Length, sea.Flow, sea.AnnualFlow, sea.BasinArea);
                    }
                }
            }
            else
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
        // видалення
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0) // Проверяем, что ячейка не заголовок
            {
                // Получаем выбранный элемент
                var selectedRow = dataGridView1.Rows[e.RowIndex];
                var name = selectedRow.Cells["Назва"].Value.ToString();
                var country = selectedRow.Cells["Страна"].Value.ToString();

                // Отображаем форму подтверждения удаления
                var confirmForm = new Form3();
                var confirmResult = confirmForm.ShowDialog();

                if (confirmResult == DialogResult.OK && confirmForm.AddRiver)
                {
                    // Удаляем элемент из списка
                    if (comboBox1.SelectedItem != null) // Проверяем, что комбобокс выбран
                    {
                        // Удаляем элемент из списка
                        if (comboBox1.SelectedItem.ToString() == "Річки")
                        {
                            var riverToRemove = Rivers.rivers.Find(river => river.Name == name && river.Countries == country);
                            if (riverToRemove != null)
                            {
                                Rivers.rivers.Remove(riverToRemove);
                            }
                            Print(Rivers.rivers, Lakes.lakes, Seas.seas);
                        }
                        else if (comboBox1.SelectedItem.ToString() == "Озера")
                        {
                            var lakeToRemove = Lakes.lakes.Find(lake => lake.Name == name && lake.Countries == country);
                            if (lakeToRemove != null)
                            {
                                Lakes.lakes.Remove(lakeToRemove);
                            }
                            Print(Rivers.rivers, Lakes.lakes, Seas.seas);
                        }
                        else if (comboBox1.SelectedItem.ToString() == "Моря")
                        {
                            var seaToRemove = Seas.seas.Find(sea => sea.Name == name && sea.Countries == country);
                            if (seaToRemove != null)
                            {
                                Seas.seas.Remove(seaToRemove);
                            }
                            Print(Rivers.rivers, Lakes.lakes, Seas.seas);
                        }
                        MessageBox.Show("Водойму видалено");
                        string file = "C:\\Users\\Богдан\\source\\repos\\курсоваgидро3\\курсовагидро\\file.txt";
                        Dataclass.ClearFile(file);
                        Dataclass.SaveDataToFile(file);
                    }
                    else
                    {
                        // Удаляем элемент из всех списков
                        var riverToRemove = Rivers.rivers.Find(river => river.Name == name && river.Countries == country);
                        if (riverToRemove != null)
                        {
                            Rivers.rivers.Remove(riverToRemove);
                        }
                        var lakeToRemove = Lakes.lakes.Find(lake => lake.Name == name && lake.Countries == country);
                        if (lakeToRemove != null)
                        {
                            Lakes.lakes.Remove(lakeToRemove);
                        }
                        var seaToRemove = Seas.seas.Find(sea => sea.Name == name && sea.Countries == country);
                        if (seaToRemove != null)
                        {
                            Seas.seas.Remove(seaToRemove);
                        }
                        // Обновляем таблицу
                        PrintAllBodiesOfWater();
                        string file = "C:\\Users\\Богдан\\source\\repos\\курсоваgидро3\\курсовагидро\\file.txt";
                        Dataclass.ClearFile(file);
                        Dataclass.SaveDataToFile(file);
                        MessageBox.Show("Водойму видалено");
                    }
                }
                else
                {
                    MessageBox.Show("Відміна");
                }
            }
            else
            {
                MessageBox.Show("Ви вибрали невірний рядок");
            }
        }
        public void textBox3_TextChanged(object sender, EventArgs e)
        {
            string searchText = textBox3.Text.ToLower();

            // Очистити таблицю перед оновленням
            table.Rows.Clear();

            if (searchText != null)
            {
                if(comboBox1.SelectedItem != null)
                {
                    if (comboBox1.SelectedItem != null && comboBox1.SelectedItem.ToString() == "Річки")
                    {
                        foreach (River river in Rivers.rivers)
                        {
                            if (river.Name.ToLower().IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0)
                            {
                                table.Rows.Add(river.Name, river.Countries, river.Length, river.Flow, river.AnnualFlow,river.BasinArea, string.Join("; ", river.Tributaries));
                            }
                        }
                    }
                    else if (comboBox1.SelectedItem == "Озера")
                {
                    foreach (Lake lake in Lakes.lakes)
                    {
                        if (lake.Name.ToLower().IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            table.Rows.Add(lake.Name, lake.Countries, lake.Length, lake.Flow, lake.AnnualFlow);
                        }
                    }
                }
                else if (comboBox1.SelectedItem == "Моря")
                {
                    foreach (Sea sea in Seas.seas)
                    {
                        if (sea.Name.ToLower().IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            table.Rows.Add(sea.Name, sea.Countries, sea.Length, sea.Flow, sea.AnnualFlow);
                        }
                    }
                }
                }
                else 
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
                            table.Rows.Add(lake.Name, lake.Countries, lake.Length, lake.Flow, lake.AnnualFlow); ;
                        }
                    }

                    foreach (Sea sea in Seas.seas)
                    {
                        if (sea.Name.ToLower().IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            table.Rows.Add(sea.Name, sea.Countries, sea.Length, sea.Flow, sea.AnnualFlow);
                        }
                    }
                }

            }
            else
            {


                if (string.IsNullOrEmpty(comboBox1.Text) || comboBox1.Text == "Випадаюче меню")
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
            if (dataGridView1.SelectedCells.Count > 0)
            {
                int rowIndex = dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[rowIndex];

                string name = selectedRow.Cells["Назва"].Value.ToString();
                int length = Convert.ToInt32(selectedRow.Cells["Довжина"].Value);
                string country = selectedRow.Cells["Страна"].Value.ToString();
                double flow = Convert.ToDouble(selectedRow.Cells["Flow"].Value);
                double annualFlow = Convert.ToDouble(selectedRow.Cells["Річний стік"].Value);
                double basinArea = Convert.ToDouble(selectedRow.Cells["Площа басейну"].Value);
                string tributaries = "";
                Rivers.ActualRiver = Rivers.SearchName(name);
                foreach (DataGridViewCell cell in selectedRow.Cells)
                {
                    if (cell.OwningColumn.Name == "Впадіння річки")
                    {
                        tributaries = cell.Value.ToString();
                        break;
                    }
                }

                Form4 form4 = new Form4(name);
                form4.ShowDialog();
            }
        }


        private void button4_Click(object sender, EventArgs e)
        {
            
            // Создаем новый экземпляр Form2 и присваиваем его переменной form2
            Form2 form2 = new Form2();

            // Открываем форму диалога
            form2.ShowDialog();


        }

        private void TrackBar1_ValueChanged(object sender, EventArgs e)
        {
            // Очистити таблицю перед додаванням даних
            dataGridView1.DataSource = null;
            table.Rows.Clear();
            table.Columns.Clear();

            // Додати стовпці до таблиці
            table.Columns.Add("Назва", typeof(string));
            table.Columns.Add("Страна", typeof(string));
            table.Columns.Add("Довжина", typeof(int));
            table.Columns.Add("Flow", typeof(double));
            table.Columns.Add("Річний стік", typeof(double));
            table.Columns.Add("Площа басейну", typeof(double));
            label4.Text = Convert.ToString(trackBar1.Value);
            if (trackBar1.Value != 0)
            {




                // Очистити таблицю перед додаванням даних
                dataGridView1.DataSource = null;
                table.Rows.Clear();
                table.Columns.Clear();

                // Додати стовпці до таблиці
                table.Columns.Add("Назва", typeof(string));
                table.Columns.Add("Страна", typeof(string));
                table.Columns.Add("Довжина", typeof(int));
                table.Columns.Add("Flow", typeof(double));
                table.Columns.Add("Річний стік", typeof(double));
                table.Columns.Add("Площа басейну", typeof(double));

                label4.Text = Convert.ToString(trackBar1.Value);
                if (comboBox1.SelectedItem != null)
                {
                    if (comboBox1.SelectedItem == "Річки")
                    {
                        foreach (River river in Rivers.rivers)
                        {
                            if (river.Length <= trackBar1.Value)
                            {
                                table.Rows.Add(river.Name, river.Countries, river.Length, river.Flow, river.AnnualFlow, river.BasinArea);
                            }
                        }
                    }
                    if (comboBox1.SelectedItem == "Озера")
                    {
                        foreach (Lake lake in Lakes.lakes)
                        {
                            if (lake.Length <= trackBar1.Value)
                            {
                                table.Rows.Add(lake.Name, lake.Countries, lake.Length, lake.Flow, lake.AnnualFlow, lake.BasinArea);
                            }
                        }
                    }
                    if (comboBox1.SelectedItem == "Моря")
                    {
                        foreach (Sea sea in Seas.seas)
                        {
                            if (sea.Length <= trackBar1.Value)
                            {
                                table.Rows.Add(sea.Name, sea.Countries, sea.Length, sea.Flow, sea.AnnualFlow, sea.BasinArea);
                            }
                        }
                    }
                }
                else
                {


                    foreach (River river in Rivers.rivers)
                    {
                        if (river.Length <= trackBar1.Value)
                        {
                            table.Rows.Add(river.Name, river.Countries, river.Length, river.Flow, river.AnnualFlow, river.BasinArea);
                        }
                    }

                    foreach (Lake lake in Lakes.lakes)
                    {
                        if (lake.Length <= trackBar1.Value)
                        {
                            table.Rows.Add(lake.Name, lake.Countries, lake.Length, lake.Flow, lake.AnnualFlow, lake.BasinArea);
                        }
                    }

                    foreach (Sea sea in Seas.seas)
                    {
                        if (sea.Length <= trackBar1.Value)
                        {
                            table.Rows.Add(sea.Name, sea.Countries, sea.Length, sea.Flow, sea.AnnualFlow, sea.BasinArea);
                        }
                    }
                }

                // Встановити джерело даних таблиці і оновити DataGridView
                dataGridView1.DataSource = table;
                dataGridView1.Refresh();

            }
            else
            {
                Print(Rivers.rivers, Lakes.lakes, Seas.seas);

            }
            // Встановити джерело даних таблиці і оновити DataGridView
            dataGridView1.DataSource = table;
            dataGridView1.Refresh();
        }
    }
}


