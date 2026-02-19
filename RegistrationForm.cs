using BiologiaTrainingEgeApp.Classes;
using BiologiaTrainingEgeApp.Storages;
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
    public partial class RegistrationForm : Form
    {
        public RegistrationForm()
        {
            InitializeComponent();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            new MainMenuForm().Show();
            this.Close();
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxLogin.Text))
                MessageBox.Show("Вы не ввели логин", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (!textBoxLogin.Text.All(c => '0' <= c && c <= '9' || 'A' <= c && c <= 'z' || 'А' <= c && c <= 'я'))
                MessageBox.Show("Логин должен состоять только из цифр и букв", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (textBoxCopyPassword.Text != textBoxPassword.Text)
                MessageBox.Show("Пароли должны совпадать", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (string.IsNullOrWhiteSpace(textBoxPassword.Text))
                MessageBox.Show("Вы не ввели пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (textBoxPassword.Text.Length <= 6)
                MessageBox.Show("Пароль должен состоять более чем из 6 символов", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (!textBoxPassword.Text.All(c => '0' <= c && c <= '9' || 'A' <= c && c <= 'z' || 'А' <= c && c <= 'я'))
                MessageBox.Show("Пароль должен состоять только из цифр и букв", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

            User user = new User() {Login = textBoxLogin.Text, Id = Guid.NewGuid(), Password = textBoxPassword.Text};
            
            if (!UserStorage.Add(user))
                MessageBox.Show("Пользователь с данным логином уже существует", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
