using MaterialSkin;
using MaterialSkin.Controls;
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
using курсовагидро.Forms;


namespace курсовагидро.Forms
{
    public partial class EditWater : MaterialForm
    {

        private string objectType; //  поле для визначення типу об'єкту (річка, озеро або море)
        private string name;
        string file = "TextFile1.txt";
        public EditWater(string name, string objectType)
        {
          
        
            this.name = name;
            InitializeComponent();
            textBox1.Text = name;
            this.objectType = objectType;
            SetRoundedButtonStyle(button1, 10);
            SetRoundedButtonStyle(button2, 10);
            if (objectType == "Річки")
            {
                textBox2.Text = Convert.ToString(Rivers.ActualRiver.Length);
                textBox3.Text = Rivers.ActualRiver.Countries;
                textBox4.Text = Convert.ToString(Rivers.ActualRiver.Flow);
                textBox5.Text = Convert.ToString(Rivers.ActualRiver.AnnualFlow);
                textBox6.Text = Convert.ToString(Rivers.ActualRiver.BasinArea);

            }
            else if (objectType == "Озера")
            {

                textBox2.Text = Convert.ToString(Lakes.ActualLake.Length);
                textBox3.Text = Lakes.ActualLake.Countries;
                textBox4.Text = Convert.ToString(Lakes.ActualLake.Flow);
                textBox5.Text = Convert.ToString(Lakes.ActualLake.AnnualFlow);
                textBox6.Text = Convert.ToString(Lakes.ActualLake.BasinArea);

            }
            else if (objectType == "Моря")
            {

                textBox2.Text = Convert.ToString(Seas.ActualSea.Length);
                textBox3.Text = Seas.ActualSea.Countries;
                textBox4.Text = Convert.ToString(Seas.ActualSea.Flow);
                textBox5.Text = Convert.ToString(Seas.ActualSea.AnnualFlow);
                textBox6.Text = Convert.ToString(Seas.ActualSea.BasinArea);

            }
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
            // Права верхня дуга
            path.AddArc(button.Width - borderRadius, 0, borderRadius, borderRadius, 270, 90);
            
            path.AddArc(button.Width - borderRadius,
                button.Height - borderRadius, borderRadius, borderRadius, 0, 90); // Права нижня дуга
            path.AddArc(0, button.Height - borderRadius, borderRadius, borderRadius, 90, 90);
            // Ліва нижня дуга
            path.CloseAllFigures();

            button.Region = new Region(path);
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (objectType == "Річки")
            {
                Rivers.ActualRiver.Name = textBox1.Text;
                Rivers.ActualRiver.Length = Convert.ToInt32(textBox2.Text);
                Rivers.ActualRiver.Countries = textBox3.Text;
                Rivers.ActualRiver.Flow = Convert.ToInt32(textBox4.Text);
                Rivers.ActualRiver.AnnualFlow = Convert.ToDouble(textBox5.Text);
                Rivers.ActualRiver.BasinArea = Convert.ToDouble(textBox6.Text);
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

