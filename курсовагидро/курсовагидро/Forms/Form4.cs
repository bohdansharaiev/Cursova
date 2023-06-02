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
    public partial class Form4 : Form
    {
       
        
          
        public Form4(string name)
        {
            InitializeComponent();
            textBox1.Text = name;

            textBox2.Text = Convert.ToString(Rivers.ActualRiver.Length);
            textBox3.Text = Rivers.ActualRiver.Countries;
            textBox4.Text = Convert.ToString(Rivers.ActualRiver.Flow);
            textBox5.Text = Convert.ToString(Rivers.ActualRiver.AnnualFlow);
            textBox6.Text = Convert.ToString(Rivers.ActualRiver.BasinArea);
     
           

        }

       
  

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Rivers.ActualRiver.Name = textBox1.Text;
            Rivers.ActualRiver.Length = Convert.ToInt32(textBox2.Text);
            Rivers.ActualRiver.Countries = textBox3.Text;
            Rivers.ActualRiver.Flow = Convert.ToInt32(textBox4.Text);
            Rivers.ActualRiver.AnnualFlow = Convert.ToDouble(textBox5.Text);
            Rivers.ActualRiver.BasinArea = Convert.ToInt32(textBox6.Text);

        }
    }
}
