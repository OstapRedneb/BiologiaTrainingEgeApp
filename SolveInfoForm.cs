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
        private TextBox[] textBoxes;
        private List<int> exceptionTasks = new List<int>();

        public static int[] TasksQuantity { get; set; }

        public SolveInfoForm()
        {
            InitializeComponent();
            textBoxes = [textBox1, textBox2, textBox3, textBox4, textBox5, textBox6, textBox7, textBox8, textBox9, textBox10, textBox11, textBox12, textBox13, textBox14, textBox15, textBox16, textBox17, textBox18, textBox19, textBox20, textBox21, textBox22, textBox23, textBox24, textBox25, textBox26, textBox27, textBox28];
            TasksQuantity = [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0];
        }

        private void buttonSolve_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < textBoxes.Length; i++)
            {
                if (int.TryParse(textBoxes[i].Text, out int number) && 0 <= number && number <= 100)
                    TasksQuantity[i] = number;
                else
                    exceptionTasks.Add(i + 1);
            }

            if (exceptionTasks.Any())
            {
                MessageBox.Show("Значения в полях должны быть от 0 до 100 включительно. У вас допущены ошибки в поле(ях):\n" +
                    $"{string.Join(", ", exceptionTasks)}\n" +
                    "Эти поля будут автоматически зменены на 0.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                for (int i = 0; i < textBoxes.Length; i++)
                    if (exceptionTasks.Contains(i + 1))
                        textBoxes[i].Text = "0";

                exceptionTasks.Clear();
                return;
            }

            new SolveTaskForm().Show();
            this.Close();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            new MainMenuForm().Show();
            this.Close();
        }
    }
}
