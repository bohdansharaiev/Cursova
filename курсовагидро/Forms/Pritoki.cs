using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace курсовагидро.Forms
{
    public partial class Pritoki : Form
    {
        public Pritoki()
        {
            InitializeComponent();
           
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
           
            string tr = textBox1.Text;
            if (!int.TryParse(tr, out int tr_int))
            {
                River river = Rivers.SearchName(tr);
                if (river != null)
                {
                    if (Rivers.ActualRiver != null && Rivers.ActualRiver.Trib.Contains(river))
                    {
                        MessageBox.Show("Дана притока вже існує");
                    }
                    else
                    {
                        if (Rivers.ActualRiver != null)
                        {
                            Rivers.ActualRiver.Trib.Add(river);
                            Rivers.ActualRiver.CalculateAnnualFlow();
                            Rivers.ActualRiver.CalculateArea();
                            double totalFlow = Rivers.ActualRiver.AnnualFlow;
                            double totalArea = Rivers.ActualRiver.BasinArea;
                            MessageBox.Show($"Сума приток річки {Rivers.ActualRiver.Name}: Стік {totalFlow}, Площа {totalArea}");
                       
                        }
                        else
                        {
                            MessageBox.Show("Виберіть річку, до якої додати притоку");
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
                MessageBox.Show("Введіть коректне значення для притоки");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}