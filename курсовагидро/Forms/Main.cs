using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using курсовагидро.Forms;



namespace курсовагидро
{

    public partial class Main : MaterialForm
    {
        string file = "TextFile1.txt";
        private int count = 0;
        public Main()
        {
            InitializeComponent();

            dataGridView1.CellDoubleClick += dataGridView1_CellDoubleClick;


        }

        private void Main_Load(object sender, EventArgs e)
        {
            table.Columns.Add("Назва", typeof(string));
            table.Columns.Add("Країна", typeof(string));
            table.Columns.Add("Довжина", typeof(int));
            table.Columns.Add("Стік(м^3/c)", typeof(double));
            table.Columns.Add("Річний Стік(м^3/c)", typeof(double));
            table.Columns.Add("Площа басейну(км^2)", typeof(double));
            table.Columns.Add("Впадіння річки", typeof(string));

            // Створити список річок



            Dataclass.LoadRiversFromFile(file);
            // Додати річки до списку
            Dataclass.LoadLakesFromFile(file);
            Dataclass.LoadSeasFromFile(file);
            PrintAllBodiesOfWater();
            textBox3.TextChanged += textBox3_TextChanged;

            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders);
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = table;

            // Додати назви річок до комбо-боксу

            comboBox1.Items.Add("Річки");
            comboBox1.Items.Add("Озера");
            comboBox1.Items.Add("Моря");



        }
        DataTable table = new DataTable();


        //  метод друку всіх водних об'єктів
        private void PrintAllBodiesOfWater()
        {

            table.Rows.Clear();



            foreach (River river in RiverList.rivers)
            {
                // Додавання основної річки до таблиці
                table.Rows.Add(river.Name, river.Countries, river.Length, river.Flow,
                    river.AnnualFlow, river.BasinArea,"");

                foreach (River tributary in river.Trib)
                {
                    // додавання притоки
                    table.Rows.Add($"притока: {tributary.Name}", tributary.Countries,
                        tributary.Length, tributary.Flow,
                        tributary.AnnualFlow, tributary.BasinArea, river.Name);
                }
            }

            foreach (Lake lake in Lakes.lakes)
            {
                table.Rows.Add(lake.Name, lake.Countries, lake.Length, lake.Flow,
                    lake.AnnualFlow, lake.BasinArea);
            }

            foreach (Sea sea in Seas.seas)
            {
                table.Rows.Add(sea.Name, sea.Countries, sea.Length, sea.Flow,
                    sea.AnnualFlow, sea.BasinArea);
            }


            dataGridView1.Refresh();
        }
        // заповення таблиці
        public void Print(List<River> riversList, List<Lake> lakesList, List<Sea> seasList)
        {

            table.Rows.Clear();
            if (comboBox1.SelectedItem != null)
            {

                if (comboBox1.SelectedItem.ToString() == "Річки")
                {
                    foreach (River river in riversList)
                    {
                        // Додавання основної річки до таблиці
                        table.Rows.Add(river.Name, river.Countries, river.Length, river.Flow,
                            river.AnnualFlow, river.BasinArea, "");

                        foreach (River tributary in river.Trib)
                        {
                            // Додавання притоків до таблиці та відображення інформації про головну річку
                            table.Rows.Add($"- {tributary.Name}", tributary.Countries,
                                tributary.Length, tributary.Flow,
                                tributary.AnnualFlow, tributary.BasinArea, river.Name);
                        }
                    }
                }
                if (comboBox1.SelectedItem.ToString() == "Озера")
                {
                    foreach (Lake lake in lakesList)
                    {
                        table.Rows.Add(lake.Name, lake.Countries, lake.Length,
                            lake.Flow, lake.AnnualFlow, lake.BasinArea);
                    }
                }
                if (comboBox1.SelectedItem.ToString() == "Моря")
                {
                    foreach (Sea sea in seasList)
                    {
                        table.Rows.Add(sea.Name, sea.Countries, sea.Length,
                            sea.Flow, sea.AnnualFlow, sea.BasinArea);
                    }
                }
                dataGridView1.DataSource = null; // Звільнити джерело даних
                dataGridView1.DataSource = table; // Прив'язати таблицю знову
                dataGridView1.Refresh(); // Оновити відображення таблиці
            }
            else
            {
                PrintAllBodiesOfWater();
            }


            dataGridView1.DataSource = null; // Звільнити джерело даних
            dataGridView1.DataSource = table; // Прив'язати таблицю знову
            dataGridView1.Refresh(); // Оновити відображення таблиці
        }
        // видалення
        private void dataGridView1_CellDoubleClick(object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // отримуємо елементи
                var selectedRow = dataGridView1.Rows[e.RowIndex];
                string name = selectedRow.Cells["Назва"].Value.ToString();
                string country = selectedRow.Cells["Країна"].Value.ToString();

                // підтвердження дії
                Accept confirmForm = new Accept();
                DialogResult confirmResult = confirmForm.ShowDialog();

                if (confirmResult == DialogResult.OK && confirmForm.AddRiver)
                {

                    if (comboBox1.SelectedItem != null)
                    {
                        // Удаляем элемент из списка
                        if (comboBox1.SelectedItem.ToString() == "Річки")
                        {

                           River riverToRemove = RiverList.SearchName(name);
                         
                            if (riverToRemove != null)
                            {
                                RiverList.rivers.Remove(riverToRemove);
                            }
                        }
                        else if (comboBox1.SelectedItem.ToString() == "Озера")
                        {
                            Lake lakeToRemove = Lakes.SearchName(name);
                            if (lakeToRemove != null)
                            {
                                Lakes.lakes.Remove(lakeToRemove);
                            }
                            

                        }
                        else if (comboBox1.SelectedItem.ToString() == "Моря")
                        {
                            Sea seaToRemove = Seas.SearchName(name);
                            if (seaToRemove != null)
                            {
                                Seas.seas.Remove(seaToRemove);
                            }
                        }
                        MessageBox.Show("Водойму видалено");
                        Print(RiverList.rivers, Lakes.lakes, Seas.seas);
                        Dataclass.ClearFile(file);
                        Dataclass.SaveDataToFile(file);
                    }
                    else
                    {
                        // Удаляем элемент из всех списков
                        River riverToRemove = RiverList.SearchName(name);

                        if (riverToRemove != null)
                        {
                            RiverList.rivers.Remove(riverToRemove);
                        }
                       
                         Lake lakeToRemove = Lakes.SearchName(name);
                        if (lakeToRemove != null)
                        {
                            Lakes.lakes.Remove(lakeToRemove);
                        }
                        Sea seaToRemove = Seas.SearchName(name);
                        if (seaToRemove != null)
                        {
                            Seas.seas.Remove(seaToRemove);
                        }
                        // Обновляем таблицу
                        Print(RiverList.rivers, Lakes.lakes, Seas.seas);

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
            table.Rows.Clear();


            if (searchText != null)
            {
                if (comboBox1.SelectedItem != null)
                {
                    if (comboBox1.SelectedItem != null &&
                        comboBox1.SelectedItem.ToString() == "Річки")
                    {
                        foreach (River river in RiverList.rivers)
                        {
                            if (river.Name.ToLower().IndexOf(searchText) >= 0)

                            {
                              table.Rows.Add(river.Name, river.Countries, 
                                  river.Length,
                                    river.Flow, river.AnnualFlow, river.BasinArea
        );
                            }
                        }
                    }
                    else if (comboBox1.SelectedItem.ToString() == "Озера")
                    {
                        foreach (Lake lake in Lakes.lakes)
                        {
                            if (lake.Name.ToLower().IndexOf(searchText) >= 0)
                            {
                                table.Rows.Add(lake.Name, 
                                    lake.Countries, lake.Length,
                                    lake.Flow, lake.AnnualFlow,lake.BasinArea);
                            }
                        }
                    }
                    else if (comboBox1.SelectedItem.ToString() == "Моря")
                    {
                        foreach (Sea sea in Seas.seas)
                        {
                            if (sea.Name.ToLower().IndexOf(searchText
                             ) >= 0)
                            {
                                table.Rows.Add(sea.Name, sea.Countries, sea.Length,
                                    sea.Flow, sea.AnnualFlow,sea.BasinArea);
                            }
                        }
                    }
                }
                else
                {
                    // Пошук по всіх елементах списків
                    foreach (River river in RiverList.rivers)
                    {
                        if (river.Name.ToLower().IndexOf(searchText) >= 0)
                        {
                            table.Rows.Add(river.Name,
                                river.Countries, river.Length, river.Flow, river.AnnualFlow);
                        }
                    }

                    foreach (Lake lake in Lakes.lakes)
                    {
                        if (lake.Name.ToLower().IndexOf(searchText
                            ) >= 0)
                        {
                            table.Rows.Add(lake.Name, lake.Countries,
                                lake.Length, lake.Flow, lake.AnnualFlow); ;
                        }
                    }

                    foreach (Sea sea in Seas.seas)
                    {
                        if (sea.Name.ToLower().IndexOf(searchText) >= 0)
                        {
                            table.Rows.Add(sea.Name, sea.Countries, sea.Length, sea.Flow,
                                sea.AnnualFlow);
                        }
                    }
                }

            }
            else
            {


                if (string.IsNullOrEmpty(comboBox1.Text) || comboBox1.Text == 
                    "Випадаюче меню")
                {
                    Print(RiverList.rivers, Lakes.lakes, Seas.seas);
                }

            }
        }
        private void button1_Click(object sender, EventArgs e)
        {

            dataGridView1.Refresh();
            Print(RiverList.rivers, Lakes.lakes, Seas.seas);

            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;

            }



        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedCells.Count > 0)
            {
                int rowIndex = dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[rowIndex];

                
                string name = selectedRow.Cells[0].Value.ToString(); 

                if (comboBox1.SelectedItem != null)
                {

                    // Виклик форми редагування
                    if (comboBox1.SelectedItem.ToString() == "Річки")
                    {
                        RiverList.ActualRiver = RiverList.SearchName(name);
                        EditWater form4 = new EditWater(name, "Річки");
                        form4.ShowDialog();
                    }
                    else if (comboBox1.SelectedItem.ToString() == "Озера")
                    {
                        Lakes.ActualLake = Lakes.SearchName(name);
                        EditWater form4 = new EditWater(name, "Озера");
                        form4.ShowDialog();
                    }
                    else if (comboBox1.SelectedItem.ToString() == "Моря")
                    {
                        Seas.ActualSea = Seas.SearchName(name);
                        EditWater form4 = new EditWater(name, "Моря");
                        form4.ShowDialog();
                    }

                }
                else
                {
                    MessageBox.Show("Будь ласка, виберіть тип об'єкту!");
                    return;
                }
                // Оновлення таблиці
                Print(RiverList.rivers, Lakes.lakes, Seas.seas);
            }
            else
            {
                MessageBox.Show("Виберіть тип водойми");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AddWater form2 = new AddWater();
            form2.ShowDialog();
            Print(RiverList.rivers, Lakes.lakes, Seas.seas);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Print(RiverList.rivers, Lakes.lakes, Seas.seas);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                int rowIndex = dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[rowIndex];

           
                string name = selectedRow.Cells[0].Value.ToString(); 

                if (comboBox1.SelectedItem != null)
                {

                    // Виклик форми додавання приток
                    if (comboBox1.SelectedItem.ToString() == "Річки")
                    {
                        RiverList.ActualRiver = RiverList.SearchName(name);
                        Tributaries form5 = new Tributaries();
                        form5.ShowDialog();
                    }
                    else if (comboBox1.SelectedItem.ToString() == "Озера")
                    {
                        Lakes.ActualLake = Lakes.SearchName(name);
                        MessageBox.Show("Неможливо виконати для озер");
                    }
                    else if (comboBox1.SelectedItem.ToString() == "Моря")
                    {
                        Seas.ActualSea = Seas.SearchName(name);
                        MessageBox.Show("Неможливо виконати для морів");
                    }

                }
                else
                {
                    MessageBox.Show("Будь ласка, виберіть тип об'єкту!");
                    return;
                }
                // Оновлення таблиці
                Print(RiverList.rivers, Lakes.lakes, Seas.seas);
            }
            else
            {
                MessageBox.Show("Виберіть тип водойми");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox3.Text = "";
        }
     
        private void button6_Click(object sender, EventArgs e)
        {

            count++;
            if (count % 2 == 0)
            {
                button6.BackgroundImage = Properties.Resources.moon;
                panel3.BackColor = Color.LightSlateGray;
                label1.BackColor = Color.LightSlateGray;
            }
            else
            {
                button6.BackgroundImage = Properties.Resources.sun;
                label1.BackColor = Color.White;
                panel3.BorderStyle = BorderStyle.None;
                panel3.BackColor = Color.White;
                
            }
            button6.BackgroundImageLayout = ImageLayout.Stretch;
        }
    }
}


