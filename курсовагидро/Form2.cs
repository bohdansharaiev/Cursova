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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Rivers.Add(new River(textBox1.Text, Convert.ToInt32(textBox2.Text), Convert.ToDouble(textBox3.Text), textBox4.Text));

        }
    }
}
