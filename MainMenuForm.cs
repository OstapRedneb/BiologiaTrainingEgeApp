using BiologiaTrainingEgeApp.MainUserInfo;

namespace BiologiaTrainingEgeApp
{
    public partial class MainMenuForm : Form
    {
        public MainMenuForm()
        {
            InitializeComponent();
            labelAcount.Text = UserInfo.User?.Login ?? "Нет аккаунта";
        }

        private void MainMenuForm_Load(object sender, EventArgs e)
        {

        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonReadLections_Click(object sender, EventArgs e)
        {
            var startInfo = new System.Diagnostics.ProcessStartInfo
            {
                FileName = "https://media.foxford.ru/exams",
                UseShellExecute = true,
                Verb = "open"
            };
            System.Diagnostics.Process.Start(startInfo);

        }

        private void buttonSolve_Click(object sender, EventArgs e)
        {
            if (!(UserInfo.User is null))
            {
                new SolveInfoForm().Show();
                this.Hide();
            }
            else
            {
                DialogResult result = MessageBox.Show($"Вы не можете решать задания без учётной записи.\nСоздать учётную запись?", "Извините", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (result == DialogResult.Yes)
                    buttonRegistration_Click(this, new EventArgs());
            }
        }

        private void buttonCreateTests_Click(object sender, EventArgs e)
        {
            if (!(UserInfo.User is null))
            {
                ChooseAndCreateForm creatForm = new ChooseAndCreateForm();
                creatForm.Show();
                this.Hide();
            }
            else
            {
                DialogResult result = MessageBox.Show($"Вы не можете создавть задания без учётной записи.\nСоздать учётную запись?", "Извините", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (result == DialogResult.Yes)
                    buttonRegistration_Click(this, new EventArgs());
            }
        }

        private void buttonAdmin_Click(object sender, EventArgs e)
        {
            if (UserInfo.User is null || !UserInfo.User.IsAdmin) 
            {
                MessageBox.Show("У вас нет прав администратора для работы с этой панелью!", "Пинок!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                //Comming soon ;)
            }
        }

        private void buttonAboutUs_Click(object sender, EventArgs e)
        {
            var startInfo = new System.Diagnostics.ProcessStartInfo
            {
                FileName = "https://github.com/OstapRedneb/BiologiaTrainingEgeApp",
                UseShellExecute = true,
                Verb = "open"
            };
            System.Diagnostics.Process.Start(startInfo);
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Hide();
        }

        private void buttonRegistration_Click(object sender, EventArgs e)
        {
            RegistrationForm registrationForm = new RegistrationForm();
            registrationForm.Show();
            this.Hide();
        }
    }
}
