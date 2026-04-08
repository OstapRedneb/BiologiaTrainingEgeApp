using BiologiaTrainingEgeApp.Storages;
using BiologiaTrainingEgeApp.MainUserInfo;
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
    public partial class LoginForm : Form
    {
        public LoginForm()
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
            {
                MessageBox.Show("Вы не ввели логин", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!textBoxLogin.Text.All(c => '0' <= c && c <= '9' || 'A' <= c && c <= 'z' || 'А' <= c && c <= 'я'))
            {
                MessageBox.Show("Логин должен состоять только из цифр и букв", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(UserStorage.GetAll().All(user => user.Login != textBoxLogin.Text))
            {
                MessageBox.Show("Пользователя с таким логином нет", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (UserStorage.GetAll().SingleOrDefault(user => user.Login == textBoxLogin.Text)?.Password != textBoxPassword.Text)
            {
                MessageBox.Show("Неверный пароль", "Неудача", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                UserInfo.User = UserStorage.GetAll().SingleOrDefault(user => user.Login == textBoxLogin.Text);
                buttonBack_Click(this, new EventArgs());
            }
        }
    }
}
