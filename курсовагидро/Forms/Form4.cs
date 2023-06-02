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
using курсовагидро.Forms;
namespace курсовагидро.Forms
{
    public partial class Form4 : Form
    {
        public Form4(string name, int length, string country, double flow, double annualFlow, double basinArea, string tributaries)
        {
            InitializeComponent();
            textBox1.Text = name;
            textBox2.Text = length.ToString();
            textBox3.Text = country;
            textBox4.Text = flow.ToString();
            textBox5.Text = annualFlow.ToString();
            textBox6.Text = basinArea.ToString();
            textBox7.Text = tributaries;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Retrieve the modified values from the TextBox controls
            string newName = textBox1.Text;
            int newLength = Convert.ToInt32(textBox2.Text);
            string newCountry = textBox3.Text;
            double newFlow = Convert.ToDouble(textBox4.Text);
            double newAnnualFlow = Convert.ToDouble(textBox5.Text);
            double newBasinArea = Convert.ToDouble(textBox6.Text);
            string newTributaries = textBox7.Text;

            // Perform the necessary modifications to the water body (e.g., update the values in the data source)

            // Save the modified water body to the file or database

            // Close the Form4
            this.Close();
        }
    }
}
