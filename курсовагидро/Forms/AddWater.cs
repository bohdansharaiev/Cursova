using MaterialSkin.Controls;
using System;
using System.Drawing;
using System.Windows.Forms;


namespace курсовагидро
{
    public partial class AddWater : MaterialForm
    {
        string file = "TextFile1.txt";
        public AddWater()
        {
            InitializeComponent();
           
       

        }
        private void Form2_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Річки");
            comboBox1.Items.Add("Озера");
            comboBox1.Items.Add("Моря");
          
            
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
            
                Accept form3 = new Accept();
                DialogResult result = form3.ShowDialog();

               
                if (result == DialogResult.OK)
                {
                    if (form3.AddRiver)
                    {
                        if (comboBox1.SelectedItem.ToString() == "Річки")
                        {

                            // перевірка на пусті поля
                            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                                string.IsNullOrWhiteSpace(textBox2.Text) ||
                                string.IsNullOrWhiteSpace(textBox3.Text) ||
                                string.IsNullOrWhiteSpace(textBox4.Text) ||
                                string.IsNullOrWhiteSpace(textBox5.Text))
                            {
                                MessageBox.Show("Будь ласка, заповніть всі поля.");
                                return;
                            }

                            // перевірка на введення числових значень більше 0
                            if (!int.TryParse(textBox2.Text, out int length) || length <= 0 ||
                                !double.TryParse(textBox3.Text, out double flow) || flow <= 0 ||
                                string.IsNullOrWhiteSpace(textBox4.Text) ||
                                !int.TryParse(textBox5.Text, out int width) || width <= 0)
                            {
                                MessageBox.Show("введіть коректні числові значення більше 0.");
                                return;
                            }

                            // перевірка чи існує вже річка
                            foreach (River river in RiverList.rivers)
                            {
                                if (river.Name == textBox1.Text)
                                {
                                    MessageBox.Show("Дана річка вже існує");
                                    textBox1.Text = "";
                                    textBox2.Text = "";
                                    textBox3.Text = "";
                                    textBox4.Text = "";
                                    textBox5.Text = "";
                                    return;
                                }
                            }

                            // Додаємо ріку
                            River newRiver = new River(textBox1.Text, length, flow,
                                textBox4.Text, width);
                            RiverList.Add(newRiver);

                            MessageBox.Show("Річку додано");

                            Dataclass.ClearFile(file);
                            Dataclass.SaveDataToFile(file);

                            // Очищення полів введення
                            textBox1.Text = "";
                            textBox2.Text = "";
                            textBox3.Text = "";
                            textBox4.Text = "";
                            textBox5.Text = "";
                        }
                        else if (comboBox1.SelectedItem.ToString() == "Озера")
                        {

                            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
     string.IsNullOrWhiteSpace(textBox2.Text) ||
     string.IsNullOrWhiteSpace(textBox3.Text) ||
     string.IsNullOrWhiteSpace(textBox4.Text) ||
     string.IsNullOrWhiteSpace(textBox5.Text))
                            {
                                MessageBox.Show("Будь ласка, заповніть всі поля.");
                                return;
                            }
                            else
                            {
                                int length;
                                double area;
                                int depth;

                                if (!int.TryParse(textBox2.Text, out length) || length <= 0 ||
                                    !double.TryParse(textBox3.Text, out area) || area <= 0 ||
                                    !int.TryParse(textBox5.Text, out depth) || depth <= 0)
                                {
                                    MessageBox.Show("введіть коректні числові значення більше 0.");
                                    return;
                                }

                                foreach (Lake lake in Lakes.lakes)
                                {
                                    if (lake.Name == textBox1.Text)
                                    {
                                        MessageBox.Show("Дане озеро вже існує");
                                        textBox1.Text = "";
                                        textBox2.Text = "";
                                        textBox3.Text = "";
                                        textBox4.Text = "";
                                        textBox5.Text = "";
                                        return;
                                    }
                                }

                                Lakes.Add(new Lake(textBox1.Text, length, area, textBox4.Text, depth));

                                MessageBox.Show("Озеро додано");

                                Dataclass.ClearFile(file);
                                Dataclass.SaveDataToFile(file);

                                textBox1.Text = "";
                                textBox2.Text = "";
                                textBox3.Text = "";
                                textBox4.Text = "";
                                textBox5.Text = "";
                            }
                        }
                        else if (comboBox1.SelectedItem.ToString() == "Моря")
                        {

                            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
           string.IsNullOrWhiteSpace(textBox2.Text) ||
           string.IsNullOrWhiteSpace(textBox3.Text) ||
           string.IsNullOrWhiteSpace(textBox4.Text) ||
           string.IsNullOrWhiteSpace(textBox5.Text))
                            {
                                MessageBox.Show("Будь ласка, заповніть всі поля.");
                                return;
                            }
                            else
                            {
                                int length;
                                double area;
                                int maxDepth;

                                if (!int.TryParse(textBox2.Text, out length) || length <= 0 ||
                                    !double.TryParse(textBox3.Text, out area) || area <= 0 ||
                                    !int.TryParse(textBox5.Text, out maxDepth) || maxDepth <= 0)
                                {
                                    MessageBox.Show("введіть коректні числові значення" +
                                        " більше 0.");
                                    return;
                                }

                                foreach (Sea sea in Seas.seas)
                                {
                                    if (sea.Name == textBox1.Text)
                                    {
                                        MessageBox.Show("Дане море вже існує");
                                        textBox1.Text = "";
                                        textBox2.Text = "";
                                        textBox3.Text = "";
                                        textBox4.Text = "";
                                        textBox5.Text = "";
                                        return;
                                    }
                                }

                                Seas.Add(new Sea(textBox1.Text, length, area, textBox4.Text, maxDepth));

                                MessageBox.Show("Море додано");

                                Dataclass.ClearFile(file);
                                Dataclass.SaveDataToFile(file);

                                textBox1.Text = "";
                                textBox2.Text = "";
                                textBox3.Text = "";
                                textBox4.Text = "";
                                textBox5.Text = "";
                            }
                        }
                    }
                    else
                    {
                        
                        MessageBox.Show("Відмінено");
                    }
                }
                else
                {
                    MessageBox.Show("Відмінено");
                }
            }
            else
            {
               
                MessageBox.Show("Виберіть водне тіло");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
         
            this.Close();
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                string selectedItem = comboBox1.SelectedItem.ToString();
                if (selectedItem == "Річки")
                {
                    panel1.BackgroundImage = Properties.Resources.river_image; 
                }
                else if (selectedItem == "Озера")
                {
                    panel1.BackgroundImage = Properties.Resources.lake_image; 
                }
                else if (selectedItem == "Моря")
                {
                    panel1.BackgroundImage = Properties.Resources.sea_image; 
                }
                panel1.BackgroundImageLayout = ImageLayout.Stretch;
            }
            else
            {
                panel1.Hide();
            }
        }
    }
}
