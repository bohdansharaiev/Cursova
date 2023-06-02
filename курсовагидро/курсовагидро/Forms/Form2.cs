using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

using static курсовагидро.Form1;

namespace курсовагидро
{
    public partial class Form2 : MaterialForm
    {
        public Form2()
        {
            InitializeComponent();
            int border = 10;
            SetRoundedButtonStyle(button1, border);
            SetRoundedButtonStyle(button2, border);
       

        }
        private void SetRoundedButtonStyle(Button button, int borderRadius)
        {
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.BackColor = Color.Gray;
            button.FlatAppearance.MouseDownBackColor = Color.Gray;
            button.FlatAppearance.MouseOverBackColor = Color.LightGray;

            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddArc(0, 0, borderRadius, borderRadius, 180, 90); // Ліва верхня дуга
            path.AddArc(button.Width - borderRadius, 0, borderRadius, borderRadius, 270, 90); // Права верхня дуга
            path.AddArc(button.Width - borderRadius, button.Height - borderRadius, borderRadius, borderRadius, 0, 90); // Права нижня дуга
            path.AddArc(0, button.Height - borderRadius, borderRadius, borderRadius, 90, 90); // Ліва нижня дуга
            path.CloseAllFigures();

            button.Region = new Region(path);
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Річки");
            comboBox1.Items.Add("Озера");
            comboBox1.Items.Add("Моря");
            textBox6.Visible = false;
            label6.Visible = false;
            
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                // Open the third form for confirmation
                Form3 form3 = new Form3();
                DialogResult result = form3.ShowDialog();

                // Check the result of the confirmation form
                if (result == DialogResult.OK)
                {
                    if (form3.AddRiver)
                    {
                        if (comboBox1.SelectedItem == "Річки")
                        {

                            try
                            {
                                int length;
                                double flow;
                                string countries;
                                int width;
                                string[] t;

                                // Check if any field is empty
                                if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text) ||
                                    string.IsNullOrWhiteSpace(textBox3.Text) || string.IsNullOrWhiteSpace(textBox4.Text) ||
                                    string.IsNullOrWhiteSpace(textBox5.Text) || string.IsNullOrWhiteSpace(textBox6.Text))
                                {
                                    MessageBox.Show("Будь ласка, заповніть всі поля.");
                                    return;
                                }

                                // Parse the values from the text boxes
                                length = Convert.ToInt32(textBox2.Text);
                                flow = Convert.ToDouble(textBox3.Text);
                                countries = textBox4.Text;
                                width = Convert.ToInt32(textBox5.Text);
                                t = textBox6.Text.Split(';').Select(s => s.Trim()).ToArray();

                                // перевірка чи існує вже річка
                                foreach (River river in Rivers.rivers)
                                {
                                    if (river.Name == textBox1.Text)
                                    {
                                        MessageBox.Show("Дана річка вже існує");
                                        textBox1.Text = "";
                                        textBox2.Text = "";
                                        textBox3.Text = "";
                                        textBox4.Text = "";
                                        textBox5.Text = "";
                                        textBox6.Text = "";
                                        return;
                                    }
                                }

                                // Додаємо ріку
                                River newRiver = new River(textBox1.Text, length, flow, countries, width, t);
                                Rivers.Add(newRiver);

                                // Оновлення таблиці з водними об'єктами

                                MessageBox.Show("Річку додано");
                                string file = "C:\\Users\\Богдан\\source\\repos\\курсоваgидро3\\курсовагидро\\file.txt";
                                Dataclass.ClearFile(file);
                                Dataclass.SaveDataToFile(file);

                                // Очищення полів введення
                                textBox1.Text = "";
                                textBox2.Text = "";
                                textBox3.Text = "";
                                textBox4.Text = "";
                                textBox5.Text = "";
                                textBox6.Text = "";
                            }
                            catch (Exception ex)
                            {
                                if (ex.TargetSite.Name == "ToInt32")
                                {
                                    textBox2.BackColor = Color.Red; // Зміна кольору текстового поля textBox2 на червоний
                                }
                                else if (ex.TargetSite.Name == "ToDouble")
                                {
                                    textBox3.BackColor = Color.Red; // Зміна кольору текстового поля textBox3 на червоний
                                }

                                MessageBox.Show("Помилка неправильний тип даних: " + ex.Message);
                            }
                        }
                        else if (comboBox1.SelectedItem == "Озера")
                        {

                            try
                            {
                                // Check if any field is empty
                                if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text) ||
                                    string.IsNullOrWhiteSpace(textBox3.Text) || string.IsNullOrWhiteSpace(textBox4.Text) ||
                                    string.IsNullOrWhiteSpace(textBox5.Text))
                                {
                                    MessageBox.Show("Будь ласка, заповніть всі поля.");
                                    return;
                                }
                                else
                                {
                                    bool yes = false;
                                    foreach (Lake lake in Lakes.lakes)
                                    {
                                        if (lake.Name == textBox1.Text)
                                        {
                                            yes = true;
                                            MessageBox.Show("Дане озеро вже існує");
                                            textBox1.Text = "";
                                            textBox2.Text = "";
                                            textBox3.Text = "";
                                            textBox4.Text = "";
                                            textBox5.Text = "";
                                            return;
                                        }
                                    }

                                    if (!yes)
                                    {
                                        Lakes.Add(new Lake(textBox1.Text, Convert.ToInt32(textBox2.Text),
                                            Convert.ToDouble(textBox3.Text), textBox4.Text, Convert.ToInt32(textBox5.Text)));

                                        MessageBox.Show("Озеро додано");
                                        string file = "C:\\Users\\Богдан\\source\\repos\\курсоваgидро3\\курсовагидро\\file.txt";
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
                            catch (Exception ex)
                            {
                                if (ex.TargetSite.Name == "ToInt32")
                                {
                                    textBox2.BackColor = Color.Red; // Зміна кольору текстового поля textBox2 на червоний
                                }
                                else if (ex.TargetSite.Name == "ToDouble")
                                {
                                    textBox3.BackColor = Color.Red; // Зміна кольору текстового поля textBox3 на червоний
                                }

                                MessageBox.Show("Помилка неправильний тип даних: " + ex.Message);
                            }
                        }
                        else if (comboBox1.SelectedItem == "Моря")
                        {

                            try
                            {
                                // Check if any field is empty
                                if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text) ||
                                    string.IsNullOrWhiteSpace(textBox3.Text) || string.IsNullOrWhiteSpace(textBox4.Text) ||
                                    string.IsNullOrWhiteSpace(textBox5.Text))
                                {
                                    MessageBox.Show("Будь ласка, заповніть всі поля.");
                                    return;
                                }
                                else
                                {
                                    bool yes = false;
                                    foreach (Sea sea in Seas.seas)
                                    {
                                        if (sea.Name == textBox1.Text)
                                        {
                                            yes = true;
                                            MessageBox.Show("Дане море вже існує");
                                            textBox1.Text = "";
                                            textBox2.Text = "";
                                            textBox3.Text = "";
                                            textBox4.Text = "";
                                            textBox5.Text = "";
                                            return;
                                        }
                                    }

                                    if (!yes)
                                    {
                                        Seas.Add(new Sea(textBox1.Text, Convert.ToInt32(textBox2.Text),
                                            Convert.ToDouble(textBox3.Text), textBox4.Text, Convert.ToInt32(textBox5.Text)));

                                        MessageBox.Show("Море додано");
                                        string file = "C:\\Users\\Богдан\\source\\repos\\курсоваgидро3\\курсовагидро\\file.txt";
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
                            catch (Exception ex)
                            {
                               

                                MessageBox.Show("Помилка неправильний тип даних: " + ex.Message);
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
                    // Відміна додавання
                    MessageBox.Show("Відмінено");
                }
            }
            else
            {
                textBox6.Visible = false;
                MessageBox.Show("Виберіть водне тіло");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
         
            this.Close();
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == "Річки")
            {
                textBox6.Visible = true;
                label6.Visible = true;
            }
            else
            {
                textBox6.Visible = false;
                label6.Visible = false;
            }
        }
    }
}
