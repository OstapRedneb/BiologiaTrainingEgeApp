using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BiologiaTrainingEgeApp.Classes;
using BiologiaTrainingEgeApp.MainUserInfo;

namespace BiologiaTrainingEgeApp
{
    public partial class ResultForm : Form
    {
        private List<UserAnswerResult> _results;

        public ResultForm(List<UserAnswerResult> results)
        {
            InitializeComponent();
            _results = results;
            LoadResults();
        }

        private void LoadResults()
        {
            dataGridViewResults.AutoGenerateColumns = false;
            dataGridViewResults.Columns.Clear();


            DataGridViewTextBoxColumn colNumber = new DataGridViewTextBoxColumn
            {
                HeaderText = "№ задания",
                DataPropertyName = "TaskNumber",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };
            dataGridViewResults.Columns.Add(colNumber);


            DataGridViewTextBoxColumn colUserAnswer = new DataGridViewTextBoxColumn
            {
                HeaderText = "Ответ пользователя",
                DataPropertyName = "UserAnswer",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };
            dataGridViewResults.Columns.Add(colUserAnswer);


            DataGridViewTextBoxColumn colCorrectAnswer = new DataGridViewTextBoxColumn
            {
                HeaderText = "Правильный ответ",
                DataPropertyName = "CorrectAnswer",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };
            dataGridViewResults.Columns.Add(colCorrectAnswer);


            dataGridViewResults.DataSource = _results;


            foreach (DataGridViewRow row in dataGridViewResults.Rows)
            {
                if (row.DataBoundItem is UserAnswerResult result)
                {
                    row.DefaultCellStyle.BackColor = result.IsCorrect ? Color.LightGreen : Color.LightCoral;
                }
            }
        }

        private void buttonFinish_Click(object sender, EventArgs e)
        {
            UserInfo.User.CountTasks += _results.Count;
            new MainMenuForm().Show();
            this.Close();
        }
    }
}
