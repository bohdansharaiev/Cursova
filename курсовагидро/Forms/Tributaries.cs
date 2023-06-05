using MaterialSkin.Controls;
using System;
using System.Windows.Forms;

namespace курсовагидро.Forms
{
    public partial class Tributaries : MaterialForm
    {
        public Tributaries()
        {
            InitializeComponent();
            this.Text = $"Притоки річки {RiverList.ActualRiver.Name}";
            label1.Text = $"Додайте притоку до річки: {RiverList.ActualRiver.Name}";

        }
        
        private void button1_Click(object sender, EventArgs e)
        {
           
            string tr = textBox1.Text;
            if (!int.TryParse(tr, out int tr_int))
            {
                River river = RiverList.SearchName(tr);
                if (river != null)
                {
                    if (RiverList.ActualRiver != null && RiverList.
                        ActualRiver.Trib.Contains(river))
                    {
                        MessageBox.Show("Дана притока вже існує");
                        
                    }
                    else
                    {
                        if (RiverList.ActualRiver != null && RiverList.ActualRiver.Name != river.Name)
                        {
                            RiverList.ActualRiver.Trib.Add(river);
                            RiverList.ActualRiver.CalculateAnnualFlow();
                            RiverList.ActualRiver.CalculateArea();
                            double totalFlow = RiverList.ActualRiver.AnnualFlow;
                            double totalArea = RiverList.ActualRiver.BasinArea;
                            MessageBox.Show($"Сума приток річки " +
                                $"{RiverList.ActualRiver}:" +
                                $" Стік {totalFlow}, Площа {totalArea}");
                            this.Close();
                       
                        }
                        else
                        {
                            MessageBox.Show("Виберіть річку," +
                                " до якої додати притоку");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Річку не знайдено");
                }
            }
            else
            {
                MessageBox.Show("Введіть коректне " +
                    "значення для притоки");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}