using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BiologiaTrainingEgeApp
{
    public partial class SolveInfoForm : Form
    {
        public static int[] tasksQuantity;
        public static TextBox[] textBoxes;
        public SolveInfoForm()
        {
            InitializeComponent();
            textBoxes = [textBox1, textBox2, textBox3, textBox4, textBox5, textBox6, textBox7, textBox8, textBox9, textBox10, textBox11, textBox12, textBox13, textBox14, textBox15, textBox16, textBox17, textBox18, textBox19, textBox20, textBox21, textBox22, textBox23, textBox24, textBox25, textBox26, textBox27, textBox28];
            tasksQuantity = [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0];
        }

        private void buttonSolve_Click(object sender, EventArgs e)
        {

        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            new MainMenuForm().Show();
            this.Close();
        }
    }
}
