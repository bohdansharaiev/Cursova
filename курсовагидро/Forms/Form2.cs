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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static курсовагидро.Form1;

namespace курсовагидро
{
    public partial class Form2 : MaterialForm
    {
        public Form2()
        {
            InitializeComponent();
           
                   
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

                                int length = Convert.ToInt32(textBox2.Text);
                                double flow = Convert.ToDouble(textBox3.Text);
                                string countries = textBox4.Text;
                                int width = Convert.ToInt32(textBox5.Text);
                                string[] t = textBox6.Text.Split(';').Select(s => s.Trim()).ToArray();
                                bool yes = false;
                                foreach (River river in Rivers.rivers)
                                {
                                    if (river.Name == textBox1.Text)
                                    {
                                        yes = true;
                                        MessageBox.Show("Дана річка вже існує");
                                        textBox1.Text = "";
                                        textBox2.Text = "";
                                        textBox3.Text = "";
                                        textBox4.Text = "";
                                        textBox5.Text = "";
                                        textBox6.Text = "";
                                        break;
                                    }

                                }
                                
                                if (yes != true)
                                {

                                    yes = false;
                                    River newRiver = new River(textBox1.Text, length, flow, countries,width,t );
                                    Rivers.Add(newRiver);

                                    // Оновлення таблиці з водними об'єктами
                                    string file = "C:\\Users\\Богдан\\Desktop\\data.txt";
                                    Dataclass.ClearFile(file);
                                    Dataclass.SaveDataToFile(file);
                                    MessageBox.Show("Річку додано");
                                    // Очищення полів введення
                                    textBox1.Text = "";
                                    textBox2.Text = "";
                                    textBox3.Text = "";
                                    textBox4.Text = "";
                                    textBox5.Text = "";
                                    textBox6.Text = "";
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
                        else if (comboBox1.SelectedItem == "Озера")
                        {
                           
                            try
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
                                        break;
                                    }

                                }

                                if (yes != true)
                                {

                                    yes = false;
                                    Lakes.Add(new Lake(textBox1.Text, Convert.ToInt32(textBox2.Text), Convert.ToDouble(textBox3.Text), textBox4.Text,Convert.ToInt32(textBox5.Text)));
                                    MessageBox.Show("Озеро додано");
                                    textBox1.Text = "";
                                    textBox2.Text = "";
                                    textBox3.Text = "";
                                    textBox4.Text = "";
                                    textBox5.Text = "";
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
                                int width = Convert.ToInt32(textBox5.Text);
                                bool yes = false;
                                foreach (Sea sea in Seas.seas)
                                {
                                    if (sea.Name == textBox1.Text)
                                    {
                                        yes = true;
                                        MessageBox.Show("Дана річка вже існує");
                                        textBox1.Text = "";
                                        textBox2.Text = "";
                                        textBox3.Text = "";
                                        textBox4.Text = "";
                                        textBox5.Text = "";
                                        break;
                                    }

                                }

                                if (yes != true)
                                {
                                   
                                    yes = false;
                                    Seas.Add(new Sea(textBox1.Text, Convert.ToInt32(textBox2.Text), Convert.ToDouble(textBox3.Text), textBox4.Text, Convert.ToInt32(textBox5.Text)));
                                    MessageBox.Show("Море додано");
                                    textBox1.Text = "";
                                    textBox2.Text = "";
                                    textBox3.Text = "";
                                    textBox4.Text = "";
                                    textBox5.Text = "";
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
                    }
                    else
                    {
                        // User chose not to add the water body
                        MessageBox.Show("Відмінено");
                    }
                }
                else
                {
                    // Confirmation form was closed without a decision
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
