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

namespace курсовагидро
{
    public partial class Form3 : MaterialForm
    {
        public bool AddRiver { get; set; }

        public Form3()
        {
            InitializeComponent();
            AddRiver = false; // Default value is set to false

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddRiver = true; // Set the flag to indicate that a river should be added
            this.DialogResult = DialogResult.OK; // Set the dialog result to OK
            this.Close(); // Close the form
        }
      
        private void button2_Click(object sender, EventArgs e)
        {
            AddRiver = false; // Set the flag to indicate that no action should be taken
            this.DialogResult = DialogResult.Cancel; // Set the dialog result to Cancel
            this.Close(); // Close the form
        }
    }
}
