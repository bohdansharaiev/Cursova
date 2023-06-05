using MaterialSkin.Controls;
using System;
using System.Drawing;
using System.Windows.Forms;



namespace курсовагидро.Forms
{
    public partial class EditWater : MaterialForm
    {

        private string objectType; 
        private string name;
        string file = "TextFile1.txt";
        public EditWater(string name, string objectType)
        {
          
        
            this.name = name;
            InitializeComponent();
            textBox1.Text = name;
            this.objectType = objectType;
            if (objectType == "Річки")
            {
                this.Text = "Редагування річок";
                textBox2.Text = Convert.ToString(RiverList.ActualRiver.Length);
                textBox3.Text = RiverList.ActualRiver.Countries;
                textBox4.Text = Convert.ToString(RiverList.ActualRiver.Flow);
                textBox5.Text = Convert.ToString(RiverList.ActualRiver.
                    AnnualFlow);
                textBox6.Text = Convert.ToString(RiverList.ActualRiver.
                    BasinArea);

            }
            else if (objectType == "Озера")
            {
                this.Text = "Редагування озер";
                textBox2.Text = Convert.ToString(Lakes.ActualLake.Length);
                textBox3.Text = Lakes.ActualLake.Countries;
                textBox4.Text = Convert.ToString(Lakes.ActualLake.Flow);
                textBox5.Text = Convert.ToString(Lakes.ActualLake.AnnualFlow);
                textBox6.Text = Convert.ToString(Lakes.ActualLake.BasinArea);

            }
            else if (objectType == "Моря")
            {
                this.Text = "Редагування морів";
                textBox2.Text = Convert.ToString(Seas.ActualSea.Length);
                textBox3.Text = Seas.ActualSea.Countries;
                textBox4.Text = Convert.ToString(Seas.ActualSea.Flow);
                textBox5.Text = Convert.ToString(Seas.ActualSea.AnnualFlow);
                textBox6.Text = Convert.ToString(Seas.ActualSea.BasinArea);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // перевірка на пусті поля
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text) ||
                string.IsNullOrWhiteSpace(textBox4.Text) ||
                string.IsNullOrWhiteSpace(textBox5.Text)||
                string.IsNullOrWhiteSpace(textBox6.Text))

            {
                MessageBox.Show("Будь ласка, заповніть всі поля.");
                return;
            }
            if (!int.TryParse(textBox2.Text, out int length) ||
    !int.TryParse(textBox4.Text, out int flow) ||
    !double.TryParse(textBox5.Text, out double annualFlow) ||
    !double.TryParse(textBox6.Text, out double basinArea))
            {
                MessageBox.Show("Невірний формат даних.");
                return;
            }
            if (objectType == "Річки")
            {
                RiverList.ActualRiver.Name = textBox1.Text;
                RiverList.ActualRiver.Length = Convert.ToInt32(textBox2.Text);
                RiverList.ActualRiver.Countries = textBox3.Text;
                RiverList.ActualRiver.Flow = Convert.ToInt32(textBox4.Text);
                RiverList.ActualRiver.AnnualFlow = Convert.
                    ToDouble(textBox5.Text);
                RiverList.ActualRiver.BasinArea = Convert.
                    ToDouble(textBox6.Text);
                MessageBox.Show("Річку відредаговано");
            }
            else if (objectType == "Озера")
            {
                Lakes.ActualLake.Name = textBox1.Text;
                Lakes.ActualLake.Length = Convert.ToInt32(textBox2.Text);
                Lakes.ActualLake.Countries = textBox3.Text;
                Lakes.ActualLake.Flow = Convert.ToInt32(textBox4.Text);
                Lakes.ActualLake.AnnualFlow = Convert.ToDouble(textBox5.Text);
                Lakes.ActualLake.BasinArea = Convert.ToDouble(textBox6.Text);
                MessageBox.Show("Озеро відредаговано");
            }
            else if (objectType == "Моря")
            {
                Seas.ActualSea.Name = textBox1.Text;
                Seas.ActualSea.Length = Convert.ToInt32(textBox2.Text);
                Seas.ActualSea.Countries = textBox3.Text;
                Seas.ActualSea.Flow = Convert.ToInt32(textBox4.Text);
                Seas.ActualSea.AnnualFlow = Convert.ToDouble(textBox5.Text);
                Seas.ActualSea.BasinArea = Convert.ToDouble(textBox6.Text);
                MessageBox.Show("Море відредаговано");
            }
            Dataclass.ClearFile(file);
            Dataclass.SaveDataToFile(file);
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

