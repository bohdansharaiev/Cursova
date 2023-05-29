using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static курсовагидро.Form1;

namespace курсовагидро
{
    public partial class Form2 : Form
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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {

                if (comboBox1.SelectedItem == "Річки")
                {
                    try
                    {
                        int length = Convert.ToInt32(textBox2.Text);
                        double flow = Convert.ToDouble(textBox3.Text);
                        string countries = textBox4.Text;

                        River newRiver = new River(textBox1.Text, length, flow, countries);
                        Rivers.Add(newRiver);

                        // Оновлення таблиці з водними об'єктами
                        

                        // Очищення полів введення
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";
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




                if (comboBox1.SelectedItem == "Озера")
                {
                    try
                    {
                        Lakes.Add(new Lake(textBox1.Text, Convert.ToInt32(textBox2.Text), Convert.ToDouble(textBox3.Text), textBox4.Text));
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";
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
                if (comboBox1.SelectedItem == "Моря")
                {
                    try
                    {
                        Seas.Add(new Sea(textBox1.Text, Convert.ToInt32(textBox2.Text), Convert.ToDouble(textBox3.Text), textBox4.Text));
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";
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
                MessageBox.Show("Виберіть водне тіло");
            }
            }

        private void button2_Click(object sender, EventArgs e)
        {
         
            this.Close();
            
        }
    }
}
