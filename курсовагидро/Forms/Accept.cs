using MaterialSkin.Controls;
using System;
using System.Windows.Forms;

namespace курсовагидро
{
    public partial class Accept : MaterialForm
    {
        public bool AddRiver { get; set; }

        public Accept()
        {
            InitializeComponent();
            AddRiver = false; 

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddRiver = true; // прапорець тру
            this.DialogResult = DialogResult.OK; // результат ОК
            this.Close(); 
        }
      
        private void button2_Click(object sender, EventArgs e)
        {
            AddRiver = false; // не видаляємо
            this.DialogResult = DialogResult.Cancel; // Відміна
            this.Close(); 
        }

      
    }
}
